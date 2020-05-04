using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Laba4_Console.BLL
{
    public class Work_with_atractions
    {
        Atraction atraction;
        MyModel db = new MyModel();

        public void Add_Atraction(string name, string type , int capacity)
        {
            atraction = new Atraction { Name = name, Type = type,Capacity = capacity};
            db.AtractionEntities.Add(atraction);
            db.SaveChanges();
        }

        public void Edit_Atraction(int id, string name, string type ,int capacity,Zone[] zones)
        {
            atraction = db.AtractionEntities.Find(id);
            atraction.Name = name;
            atraction.Type = type;
            atraction.Capacity = capacity;
            atraction.Zones.Clear();

            for (int i = 0; i < zones.Length; i++)
            {
                db.ZoneEntities.Find(zones[i].Id).Atractions = new List<Atraction> { atraction };
            }

            db.SaveChanges();
        }

        public void Del_Atraction(int id)
        {
            atraction = db.AtractionEntities.Find(id);
            foreach (var z in db.ZoneEntities.ToList())
            {
                if (z.Atractions.Contains(atraction))
                {
                    z.Atractions.Remove(atraction);
                }
            }
            db.AtractionEntities.Remove(atraction);
            db.SaveChanges();
        }

        public void Print_all_atractions()
        {
            var atractions = db.AtractionEntities.ToList();
            foreach (var a in atractions)
            {
                Console.WriteLine("Id: "+a.Id);
                Console.WriteLine("Name: " + a.Name);
                Console.WriteLine("Type: " + a.Type);
                Console.WriteLine("Capasity: " + a.Capacity);
                foreach (var z in a.Zones)
                {
                    Console.WriteLine("Zone: "+z.Name);
                }
            }
        }
    }
}
