using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            List<Atraction> atractions = Database.Atractions.GetAll.ToList();
            List<Hero> heroes = Database.Heroes.GetAll.ToList();
            List<Area> areas = Database.Areas.GetAll.ToList();

            Hero hero = heroes.Where(h => h.Id == orderDto.HeroId).FirstOrDefault();
            Atraction atraction = atractions.Where(h => h.Id == orderDto.AtractionId).FirstOrDefault();
            Area area = areas.Where(h => h.Id == orderDto.AreaId).FirstOrDefault();

            // валидация
            if (hero == null)
                throw new ValidationException("Order не найден", "");
            
            Order order = new Order
            {
                Name = orderDto.Name,
                Type = orderDto.Type,
                Time = orderDto.Time,
                Price = orderDto.Price,
                HeroId = hero.Id,
                AtractionId = atraction.Id,
                AreaId = area.Id
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        public void MakeArea(AreaDTO areaDto)
        {
            Area area = new Area
            {
                Name = areaDto.Name,
                Type = areaDto.Type
            };
            Database.Areas.Create(area);
            Database.Save();
        }

        public void MakeAtraction(AtractionDTO atractionDto)
        {
            Atraction atraction = new Atraction
            {
                Name = atractionDto.Name,
                Type = atractionDto.Type,
                Capacity = atractionDto.Capacity
            };
            Database.Atractions.Create(atraction);
            Database.Save();
        }

        public HeroDTO MakeHero(HeroDTO heroDto)
        {
            Hero hero = new Hero
            {
                Name = heroDto.Name
            };
            Database.Heroes.Create(hero);
            Database.Save();
            return heroDto;
        }

        public void EditOrder(OrderDTO orderDto)
        {
            List<Atraction> atractions = Database.Atractions.GetAll.ToList();
            List<Hero> heroes = Database.Heroes.GetAll.ToList();
            List<Area> areas = Database.Areas.GetAll.ToList();
            List<Order> orders = Database.Orders.GetAll.ToList();

            Hero hero = heroes.Where(h => h.Id == orderDto.HeroId).FirstOrDefault();
            Atraction atraction = atractions.Where(h => h.Id == orderDto.AtractionId).FirstOrDefault();
            Area area = areas.Where(h => h.Id == orderDto.AreaId).FirstOrDefault();
            Order order = orders.Where(h => h.Id == orderDto.Id).FirstOrDefault();

            // валидация
            if (hero == null ||atraction==null||area == null)
                throw new ValidationException("Order не найден", "");

            if (order == null)
            {
                throw new ValidationException("Order не найден", "");
            }
            else
            {
                order.Name = orderDto.Name;
                order.Type = orderDto.Type;
                order.Time = orderDto.Time;
                order.Price = orderDto.Price;
                order.HeroId = hero.Id;
                order.AtractionId = atraction.Id;
                order.AreaId = area.Id;
            }

            Database.Orders.Update(order);
            Database.Save();
        }

        public void EditArea(AreaDTO areaDto)
        {
            List<Area> areas = Database.Areas.GetAll.ToList();
            Area area = areas.Where(h => h.Id == areaDto.Id).FirstOrDefault();

            if (area == null)
            {
                throw new ValidationException("Area не найден", "");
            }
            else
            {
                area.Name = areaDto.Name;
                area.Type = areaDto.Type;
            }

            Database.Areas.Update(area);
            Database.Save();
        }

        public void EditAtraction(AtractionDTO atractionDto)
        {
            List<Atraction> atractions = Database.Atractions.GetAll.ToList();
            Atraction atr = atractions.Where(h => h.Id == atractionDto.Id).FirstOrDefault();

            if (atr == null)
            {
                throw new ValidationException("Atraction не найден", "");
            }
            else
            {
                atr.Name = atractionDto.Name;
                atr.Type = atractionDto.Type;
                atr.Capacity = atractionDto.Capacity;
            }

            Database.Atractions.Update(atr);
            Database.Save();
        }

        public void EditHero(HeroDTO heroDto)
        {
            List<Hero> heroes = Database.Heroes.GetAll.ToList();
            Hero hero = heroes.Where(h=>h.Id == heroDto.Id).FirstOrDefault();

            if (hero == null)
            {
                throw new ValidationException("Hero не найден", "");
            }
            else
            {
                hero.Name = heroDto.Name;
            }

            Database.Heroes.Update(hero);
            Database.Save();
        }

        public void DeleteOrder(OrderDTO orderDto)
        {
            List<Atraction> atractions = Database.Atractions.GetAll.ToList();
            List<Hero> heroes = Database.Heroes.GetAll.ToList();
            List<Area> areas = Database.Areas.GetAll.ToList();
            List<Order> orders = Database.Orders.GetAll.ToList();

            Hero hero = heroes.Where(h => h.Id == orderDto.HeroId).FirstOrDefault();
            Atraction atraction = atractions.Where(h => h.Id == orderDto.AtractionId).FirstOrDefault();
            Area area = areas.Where(h => h.Id == orderDto.AreaId).FirstOrDefault();
            Order order = orders.Where(h => h.Id == orderDto.Id).FirstOrDefault();

            // валидация
            if (hero == null || atraction == null || area == null)
                throw new ValidationException("Order не найден", "");

            if (order == null)
            {
                throw new ValidationException("Order не найден", "");
            }
            else
            {
                Database.Orders.Delete(order.Id);
            }
            Database.Save();
        }

        public void DeleteArea(AreaDTO areaDto)
        {
            List<Area> areas = Database.Areas.GetAll.ToList();
            Area area = areas.Where(h => h.Id == areaDto.Id).FirstOrDefault();

            if (area == null)
            {
                throw new ValidationException("Area не найден", "");
            }
            else
            {
                Database.Areas.Delete(area.Id);
            }
            Database.Save();
        }

        public void DeleteAtraction(AtractionDTO atractionDto)
        {
            List<Atraction> atractions = Database.Atractions.GetAll.ToList();
            Atraction atr = atractions.Where(h => h.Id == atractionDto.Id).FirstOrDefault();

            if (atr == null)
            {
                throw new ValidationException("Atraction не найден", "");
            }
            else
            {
                Database.Atractions.Delete(atr.Id);
            }
            Database.Save();
        }

        public void DeleteHero(HeroDTO heroDto)
        {
            List<Hero> heroes = Database.Heroes.GetAll.ToList();
            Hero hero = heroes.Where(h => h.Id == heroDto.Id).FirstOrDefault();

            if (hero == null)
            {
                throw new ValidationException("Hero не найден", "");
            }
            else
            {
                Database.Heroes.Delete(hero.Id);
            }
            Database.Save();
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Orders.GetAll);
        }

        public IEnumerable<AreaDTO> GetAreas()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Area, AreaDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Area>, List<AreaDTO>>(Database.Areas.GetAll);
        }

        public IEnumerable<AtractionDTO> GetAtractions()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Atraction, AtractionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Atraction>, List<AtractionDTO>>(Database.Atractions.GetAll);
        }

        public IEnumerable<HeroDTO> GetHeroes()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Hero, HeroDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Hero>, List<HeroDTO>>(Database.Heroes.GetAll);
        }

        public OrderDTO GetOrder(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id order", "");
            var order = Database.Orders.Get(id.Value);
            if (order == null)
                throw new ValidationException("Order не найден", "");

            return new OrderDTO { Id = order.Id, Name = order.Name, Type = order.Type, Time = order.Time, Price= order.Price, HeroId = order.HeroId, AreaId = order.AreaId, AtractionId=order.AtractionId };
        }

        public AreaDTO GetArea(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id area", "");
            var area = Database.Areas.Get(id.Value);
            if (area == null)
                throw new ValidationException("Area не найден", "");

            return new AreaDTO { Id = area.Id,Name = area.Name, Type = area.Type};
        }

        public AtractionDTO GetAtraction(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id atraction", "");
            var atraction = Database.Atractions.Get(id.Value);
            if (atraction == null)
                throw new ValidationException("Atraction не найден", "");

            return new AtractionDTO { Id = atraction.Id,Name = atraction.Name, Type = atraction.Type, Capacity = atraction.Capacity};
        }

        public HeroDTO GetHero(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id hero", "");

            var hero = Database.Heroes.Get(id.Value);
            if (hero == null)
                throw new ValidationException("Hero не найден", "");

            return new HeroDTO { Id = hero.Id,Name = hero.Name };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
