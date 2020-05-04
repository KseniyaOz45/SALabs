using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Laba4_Console.BLL
{
    public class Work_with_heroes
    {
        Hero hero;
        MyModel db = new MyModel();
        Order order;

        public void Add_Hero(int ID,string name)
        {
            hero = new Hero { HeroId = ID,Name = name};
            db.HeroEntities.Add(hero);
            db.SaveChanges();
        }

        public void Edit_Hero(int id,string name,Order[] orders)
        {
            hero = db.HeroEntities.Find(id);
            hero.Name = name;
            for (int i = 0; i < orders.Length; i++)
            {
                db.OrderEntities.Find(orders[i].Id).Hero = null;
                db.OrderEntities.Find(orders[i].Id).Hero = hero;
            }
            db.SaveChanges();
        }

        public void Del_Hero(int id)
        {
            hero = db.HeroEntities.Find(id);
            foreach (var o in db.OrderEntities.ToList())
            {
                if (o.Hero == hero)
                {
                    o.Hero = null;
                }
            }
            db.HeroEntities.Remove(hero);
            db.SaveChanges();
        }

        public void Print_all_heroes()
        {
            var heroes = db.HeroEntities.ToList();
            foreach (var h in heroes)
            {
                Console.WriteLine("Id: "+h.HeroId);
                Console.WriteLine("Name: " + h.Name);
                foreach (var o in h.Orders)
                {
                    Console.WriteLine("Order: " + o.Name);
                }
            }
        }
    }
}
