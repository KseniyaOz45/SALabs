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
    public class AreaRepository : IRepository<Area>
    {
        private Laba5_6_7_Context db;

        public AreaRepository(Laba5_6_7_Context context)
        {
            this.db = context;
        }

        public IEnumerable<Area> GetAll
        {
            get {
                  return db.Areas;
            }
        }

        public Area Get(int id)
        {
            return db.Areas.Find(id);
        }

        public void Create(Area area)
        {
            db.Areas.Add(area);
        }

        public void Update(Area area)
        {
            db.Entry(area).State = EntityState.Modified;
        }

        public IEnumerable<Area> Find(Func<Area, Boolean> predicate)
        {
            return db.Areas.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Area area = db.Areas.Find(id);
            if (area != null)
                db.Areas.Remove(area);
        }
    }
}
