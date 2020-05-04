using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL;

namespace Laba4_Console.BLL
{
    public class Work_with_orders
    {
        Order order;
        OrderPrice orderPrice;
        Hero hero;
        List<Hero> heroes;
        MyModel db = new MyModel();

        public void Add_Order(int id, string name, string type, int time, int hero_id,Zone[] zones)
        {
            order = new Order { Name = name, Type = type, Time = time};

            orderPrice = new OrderPrice { Id = order.Id, Price = 1000, Order = order };

            order.OrderPrice = orderPrice;

            hero = db.HeroEntities.Find(hero_id);

            order.Hero = hero;

            db.HeroEntities.Find(hero_id).Orders = new List<Order> { order };

            for (int i=0;i<zones.Length;i++)
            {
                db.ZoneEntities.Find(zones[i].Id).Orders = new List<Order> { order };
            }


            db.OrderEntities.Add(order);
            db.OrderPrices.Add(orderPrice);
            db.SaveChanges();
        }

        public void Edit_Order(int id, string name, string type, int time, Hero hero, Zone[] zones)
        {
            order = db.OrderEntities.Find(id);
            heroes = db.HeroEntities.ToList();

            foreach (var h in heroes)
            {
                if (h.Orders.Contains(order))
                {
                    h.Orders.Remove(order);
                }
            }

            order.Name = name;
            order.Type = type;
            order.Time = time;
            order.Zones.Clear();

            db.HeroEntities.Find(hero.HeroId).Orders = new List<Order> { order };
            for (int i = 0; i < zones.Length; i++)
            {
                db.ZoneEntities.Find(zones[i].Id).Orders = new List<Order> { order };
            }

            db.SaveChanges();
        }

        public void Del_Order(int id)
        {
            order = db.OrderEntities.Find(id);

            foreach (var p in db.OrderPrices.ToList())
            {
                if (p.Id==id)
                {
                    db.OrderPrices.Remove(p);
                }
            }

            foreach (var h in db.HeroEntities.ToList())
            {
                if (h.Orders.Contains(order))
                {
                    h.Orders.Remove(order);
                }
            }

            foreach (var z in db.ZoneEntities.ToList())
            {
                if (z.Orders.Contains(order))
                {
                    z.Orders.Remove(order);
                }
            }
            
            db.OrderEntities.Remove(order);
            db.SaveChanges();
        }

        public void Print_all_orders()
        {
            var orders = db.OrderEntities.ToList();
            var heroes = db.HeroEntities.ToList();

            foreach (var o in orders)
            {
                foreach (var h in heroes)
                {
                    if (h.Orders.Contains(o))
                    {
                        o.Hero = h;
                    }
                }
                Console.WriteLine("ID: "+o.Id);
                Console.WriteLine("Name: " + o.Name);
                Console.WriteLine("Type: " + o.Type);
                Console.WriteLine("Time: " + o.Time);
                Console.WriteLine("Hero: " + o.Hero.Name);
                foreach (var z in o.Zones)
                {
                    Console.WriteLine("Zone: " + z.Name);
                    foreach(var a in z.Atractions)
                    {
                        Console.WriteLine("Atraction: " + a.Name);
                    }
                }
            }
        }
    }
}
