using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private Laba5_6_7_Context db;
        private OrderRepository orderRepository;
        private AreaRepository areaRepository;
        private AtractionRepository areactionRepository;
        private HeroRepository heroRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new Laba5_6_7_Context(connectionString);
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public IRepository<Area> Areas
        {
            get
            {
                if (areaRepository == null)
                    areaRepository = new AreaRepository(db);
                return areaRepository;
            }
        }

        public IRepository<Atraction> Atractions
        {
            get
            {
                if (areactionRepository == null)
                    areactionRepository = new AtractionRepository(db);
                return areactionRepository;
            }
        }

        public IRepository<Hero> Heroes
        {
            get
            {
                if (heroRepository == null)
                    heroRepository = new HeroRepository(db);
                return heroRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
