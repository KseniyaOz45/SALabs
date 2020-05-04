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
    public class HeroRepository : IRepository<Hero>
    {
        private Laba5_6_7_Context db;

        public HeroRepository(Laba5_6_7_Context context)
        {
            this.db = context;
        }

        public IEnumerable<Hero> GetAll
        {
            get{
                return db.Heroes;
            }
        }

        public Hero Get(int id)
        {
            return db.Heroes.Find(id);
        }

        public void Create(Hero hero)
        {
            db.Heroes.Add(hero);
        }

        public void Update(Hero hero)
        {
            db.Entry(hero).State = EntityState.Modified;
        }

        public IEnumerable<Hero> Find(Func<Hero, Boolean> predicate)
        {
            return db.Heroes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Hero hero = db.Heroes.Find(id);
            if (hero != null)
                db.Heroes.Remove(hero);
        }
    }
}
