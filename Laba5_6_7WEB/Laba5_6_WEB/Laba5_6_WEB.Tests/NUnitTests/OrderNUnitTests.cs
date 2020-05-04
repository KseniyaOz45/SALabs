using AutoMapper;
using BLL.DTO;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5_6_WEB.Tests.NUnitTests
{
    [TestFixture]
    public class OrderNUnitTests
    {
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        List<Order> orders;
        List<Area> areas;
        List<Atraction> atractions;
        List<Hero> heroes;

        [SetUp]
        public void Setup()
        {
            orders = new List<Order>()
            {
                 new Order { Id = 1, Name = "Order1", HeroId = 1, AreaId = 1, AtractionId = 1},
                 new Order { Id = 2, Name = "Order2", HeroId = 2, AreaId = 2, AtractionId = 2},
                 new Order { Id = 3, Name = "Order3", HeroId = 3, AreaId = 3, AtractionId = 3}
            };

            areas = new List<Area>()
            {
                new Area { Id = 1, Name = "Area1"},
                new Area { Id = 2, Name = "Area2"},
                new Area { Id = 3, Name = "Area3"}
            };

            atractions = new List<Atraction>()
            {
                new Atraction { Id = 1, Name = "Atraction1"},
                new Atraction { Id = 2, Name = "Atraction2"},
                new Atraction { Id = 3, Name = "Atraction3"}
            };

            heroes = new List<Hero>()
            {
                 new Hero { Id = 1, Name = "Hero1"},
                 new Hero { Id = 2, Name = "Hero2"},
                 new Hero { Id = 3, Name = "Hero3"}
            };
        }

        [Test]
        public void Can_OrderService_Add_New_Order()
        {
            OrderDTO orderDTO = new OrderDTO() { Id = 4, Name = "Order4", HeroId = 1, AreaId = 2, AtractionId = 3 };
            mock.Setup(m => m.Orders.GetAll).Returns(orders);
            mock.Setup(m => m.Heroes.GetAll).Returns(heroes);
            mock.Setup(m => m.Atractions.GetAll).Returns(atractions);
            mock.Setup(m => m.Areas.GetAll).Returns(areas);

            OrderService service = new OrderService(mock.Object);
            service.MakeOrder(orderDTO);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var order = mapper.Map<Order>(orderDTO);
            orders.Add(order);

            mock.Verify(t => t.Orders.Create(It.IsAny<Order>()));
            Assert.That(orders.Count(), Is.EqualTo(4));
        }

        [Test]
        public void Can_OrderService_Edit_Order_With_Id_2()
        {
            OrderDTO orderDTO = new OrderDTO() { Id = 2, Name = "Order2_NEW", HeroId = 1, AreaId = 2, AtractionId = 3 };
            mock.Setup(m => m.Orders.GetAll).Returns(orders);
            mock.Setup(m => m.Heroes.GetAll).Returns(heroes);
            mock.Setup(m => m.Atractions.GetAll).Returns(atractions);
            mock.Setup(m => m.Areas.GetAll).Returns(areas);

            OrderService service = new OrderService(mock.Object);
            service.EditOrder(orderDTO);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var order = mapper.Map<Order>(orderDTO);
            orders.Where(o=>o.Id==order.Id).FirstOrDefault().Name = order.Name;

            mock.Verify(t => t.Orders.Update(It.IsAny<Order>()));
            Assert.That(orders.Where(o => o.Id == order.Id).FirstOrDefault().Name, Is.EqualTo("Order2_NEW"));
        }

        [Test]
        public void Can_OrderService_Delete_Order_With_Id_2()
        {
            OrderDTO orderDTO = new OrderDTO() { Id = 2, Name = "Order2", HeroId = 1, AreaId = 2, AtractionId = 3 };
            mock.Setup(m => m.Orders.GetAll).Returns(orders);
            mock.Setup(m => m.Heroes.GetAll).Returns(heroes);
            mock.Setup(m => m.Atractions.GetAll).Returns(atractions);
            mock.Setup(m => m.Areas.GetAll).Returns(areas);

            OrderService service = new OrderService(mock.Object);
            service.DeleteOrder(orderDTO);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var order = mapper.Map<Order>(orderDTO);
            orders.RemoveAt(order.Id);

            mock.Verify(t => t.Orders.Delete(orderDTO.Id));
            Assert.That(orders.Count, Is.EqualTo(2));
        }

        [Test]
        public void Can_OrderService_Get_Order_With_Id_2()
        {
            int id = 2;
            mock.Setup(m => m.Orders.Get(id)).Returns(orders.Where(o=>o.Id==id).FirstOrDefault());

            OrderService service = new OrderService(mock.Object);
            var order = service.GetOrder(id);

            mock.Verify(t => t.Orders.Get(id));
            Assert.That(order.Name, Is.EqualTo("Order2"));
        }

        [Test]
        public void Can_OrderService_Get_All_Orders()
        {
            mock.Setup(m => m.Orders.GetAll).Returns(orders);

            OrderService service = new OrderService(mock.Object);
            var results = service.GetOrders();

            mock.Verify(t => t.Orders.GetAll);
            Assert.That(results.ToList().Count, Is.EqualTo(3));
        }
    }
}
