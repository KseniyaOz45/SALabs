using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class DBInitializer : DropCreateDatabaseAlways<Laba5_6_7_Context>
    {
        protected override void Seed(Laba5_6_7_Context context)
        {
            new List<Hero>
            {
                new Hero(){ Name = "Hero_1"},
                new Hero(){ Name = "Hero_2"},
                new Hero(){ Name = "Hero_3"},
                new Hero(){ Name = "Hero_4"},
                new Hero(){ Name = "Hero_5"},
                new Hero(){ Name = "Hero_6"},
                new Hero(){ Name = "Hero_7"}
            }.ForEach(hero => context.Heroes.Add(hero));
            context.SaveChanges();

            new List<Atraction>
            {
                new Atraction(){ Name = "Atraction_1", Type = "Big", Capacity = 10},
                new Atraction(){ Name = "Atraction_2", Type = "Medium", Capacity = 5},
                new Atraction(){ Name = "Atraction_3", Type = "Small", Capacity = 3},
                new Atraction(){ Name = "Atraction_4", Type = "Big", Capacity = 15},
                new Atraction(){ Name = "Atraction_5", Type = "Medium", Capacity = 6},
                new Atraction(){ Name = "Atraction_6", Type = "Small", Capacity = 4},
                new Atraction(){ Name = "Atraction_7", Type = "Big", Capacity = 20}
            }.ForEach(atraction => context.Atractions.Add(atraction));
            context.SaveChanges();

            new List<Area>
            {
                new Area(){ Name = "Zone_1", Type = "Jungle"},
                new Area(){ Name = "Zone_2", Type = "Jungle"},
                new Area(){ Name = "Zone_3", Type = "Jungle"},
                new Area(){ Name = "Zone_4", Type = "Clowns"},
                new Area(){ Name = "Zone_5", Type = "Clowns"},
                new Area(){ Name = "Zone_6", Type = "Clowns"},
                new Area(){ Name = "Zone_7", Type = "Fable"},
                new Area(){ Name = "Zone_8", Type = "Fable"},
                new Area(){ Name = "Zone_9", Type = "Fable"}
            }.ForEach(area => context.Areas.Add(area));
            context.SaveChanges();

            new List<Order>
            {
                new Order()
                {
                    Name = "Order_1", Type = "Party", Time = 2, Price = 1000, HeroId = 1, AtractionId = 1, AreaId=1

                },
                new Order()
                {
                    Name = "Order_2", Type = "Birthday", Time = 5, Price = 5000,HeroId = 2, AtractionId = 2, AreaId=2

                },
                new Order()
                {
                    Name = "Order_3", Type = "Something", Time = 3, Price = 3000, HeroId = 3, AtractionId = 3, AreaId=3

                }
            }.ForEach(order => context.Orders.Add(order));
            context.SaveChanges();
        }
    }
}
