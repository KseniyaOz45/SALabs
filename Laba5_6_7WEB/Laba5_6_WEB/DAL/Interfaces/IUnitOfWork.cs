using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Order> Orders { get; }
        IRepository<Area> Areas { get; }
        IRepository<Atraction> Atractions { get; }
        IRepository<Hero> Heroes { get; }
        void Save();
    }
}
