using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AtractionRepository : IRepository<Atraction>
    {
        private Laba5_6_7_Context db;

        public AtractionRepository(Laba5_6_7_Context context)
        {
            this.db = context;
        }

        public IEnumerable<Atraction> GetAll
        {
            get{
                return db.Atractions;
            }
        }

        public Atraction Get(int id)
        {
            return db.Atractions.Find(id);
        }

        public void Create(Atraction atraction)
        {
            db.Atractions.Add(atraction);
        }

        public void Update(Atraction atraction)
        {
            db.Entry(atraction).State = EntityState.Modified;
        }

        public IEnumerable<Atraction> Find(Func<Atraction, Boolean> predicate)
        {
            return db.Atractions.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Atraction atraction = db.Atractions.Find(id);
            if (atraction != null)
                db.Atractions.Remove(atraction);
        }
    }
}
