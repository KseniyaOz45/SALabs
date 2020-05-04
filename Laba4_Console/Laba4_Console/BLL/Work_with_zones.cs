using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Laba4_Console.BLL
{
    public class Work_with_zones
    {
        Zone zone;
        MyModel db = new MyModel();

        public void Add_Zone(string name, string type, int order_id,Atraction[] atractions)
        {
            zone = new Zone { Name = name, Type = type};

            for (int i = 0; i < atractions.Length; i++)
            {
                db.AtractionEntities.Find(atractions[i].Id).Zones = new List<Zone> { zone };
            }

            db.ZoneEntities.Add(zone);
            db.SaveChanges();
        }

        public void Edit_Zone(int id, string name, string type,Atraction[] atractions)
        {
            zone = db.ZoneEntities.Find(id);
            zone.Name = name;
            zone.Type = type;
            zone.Atractions.Clear();

            for (int i = 0; i < atractions.Length; i++)
            {
                db.AtractionEntities.Find(atractions[i].Id).Zones = new List<Zone> { zone };
            }
            db.SaveChanges();
        }

        public void Del_Zone(int id)
        {
            zone = db.ZoneEntities.Find(id);
            foreach (var a in db.AtractionEntities.ToList())
            {
                if (a.Zones.Contains(zone))
                {
                    a.Zones.Remove(zone);
                }
            }
            db.ZoneEntities.Remove(zone);
            db.SaveChanges();
        }

        public void Print_all_zones()
        {
            var zones = db.ZoneEntities.ToList();
            foreach (var z in zones)
            {
                Console.WriteLine("ID: "+z.Id);
                Console.WriteLine("Name: " + z.Name);
                Console.WriteLine("Type: " + z.Type);
                foreach (var o in z.Orders)
                {
                    Console.WriteLine("Order: " + o.Name);
                }
                foreach (var a in z.Atractions)
                {
                    Console.WriteLine("Atraction: " + a.Name);
                }
            }
        }
    }
}
