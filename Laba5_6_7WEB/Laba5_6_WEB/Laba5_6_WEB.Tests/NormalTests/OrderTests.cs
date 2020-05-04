using System;
using System.Collections.Generic;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Laba5_6_WEB.Tests.OrderTests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Can_OrderService_Add_New_Order()
        {
            OrderDTO order = new OrderDTO() { Id = 4, Name = "Order4" , HeroId = 1, AreaId = 2, AtractionId = 3};

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Orders.GetAll).Returns(new List<Order>
            {
                 new Order { Id = 1, Name = "Order1", HeroId = 1, AreaId = 1, AtractionId = 1},
                 new Order { Id = 2, Name = "Order2", HeroId = 2, AreaId = 2, AtractionId = 2},
                 new Order { Id = 3, Name = "Order3", HeroId = 3, AreaId = 3, AtractionId = 3}
            });
            mock.Setup(m => m.Heroes.GetAll).Returns(new List<Hero>
            {
                 new Hero { Id = 1, Name = "Hero1"},
                 new Hero { Id = 2, Name = "Hero2"},
                 new Hero { Id = 3, Name = "Hero3"}
            });
            mock.Setup(m => m.Atractions.GetAll).Returns(new List<Atraction>
            {
                 new Atraction { Id = 1, Name = "Atraction1"},
                 new Atraction { Id = 2, Name = "Atraction2"},
                 new Atraction { Id = 3, Name = "Atraction3"}
            });
            mock.Setup(m => m.Areas.GetAll).Returns(new List<Area>
            {
                 new Area { Id = 1, Name = "Area1"},
                 new Area { Id = 2, Name = "Area2"},
                 new Area { Id = 3, Name = "Area3"}
            });

            OrderService service = new OrderService(mock.Object);
            service.MakeOrder(order);

            mock.Verify(t => t.Orders.Create(It.IsAny<Order>()));
        }

        [TestMethod]
        public void Can_OrderService_Edit_Order()
        {
            OrderDTO order = new OrderDTO() { Id = 3, Name = "Order3NEW", HeroId = 2, AreaId = 1, AtractionId = 3 };

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Orders.GetAll).Returns(new List<Order>
            {
                 new Order { Id = 1, Name = "Order1", HeroId = 1, AreaId = 1, AtractionId = 1},
                 new Order { Id = 2, Name = "Order2", HeroId = 2, AreaId = 2, AtractionId = 2},
                 new Order { Id = 3, Name = "Order3", HeroId = 3, AreaId = 3, AtractionId = 3},
            });
            mock.Setup(m => m.Heroes.GetAll).Returns(new List<Hero>
            {
                 new Hero { Id = 1, Name = "Hero1"},
                 new Hero { Id = 2, Name = "Hero2"},
                 new Hero { Id = 3, Name = "Hero3"}
            });
            mock.Setup(m => m.Atractions.GetAll).Returns(new List<Atraction>
            {
                 new Atraction { Id = 1, Name = "Atraction1"},
                 new Atraction { Id = 2, Name = "Atraction2"},
                 new Atraction { Id = 3, Name = "Atraction3"}
            });
            mock.Setup(m => m.Areas.GetAll).Returns(new List<Area>
            {
                 new Area { Id = 1, Name = "Area1"},
                 new Area { Id = 2, Name = "Area2"},
                 new Area { Id = 3, Name = "Area3"}
            });

            OrderService service = new OrderService(mock.Object);
            service.EditOrder(order);

            mock.Verify(t => t.Orders.Update(It.IsAny<Order>()));
        }

        [TestMethod]
        public void Can_OrderService_Delete_Order()
        {
            OrderDTO order = new OrderDTO() { Id = 3, Name = "Order3", HeroId = 3, AreaId = 3, AtractionId = 3 };

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Orders.GetAll).Returns(new List<Order>
            {
                 new Order { Id = 1, Name = "Order1", HeroId = 1, AreaId = 1, AtractionId = 1},
                 new Order { Id = 2, Name = "Order2", HeroId = 2, AreaId = 2, AtractionId = 2},
                 new Order { Id = 3, Name = "Order3", HeroId = 3, AreaId = 3, AtractionId = 3},
            });
            mock.Setup(m => m.Heroes.GetAll).Returns(new List<Hero>
            {
                 new Hero { Id = 1, Name = "Hero1"},
                 new Hero { Id = 2, Name = "Hero2"},
                 new Hero { Id = 3, Name = "Hero3"}
            });
            mock.Setup(m => m.Atractions.GetAll).Returns(new List<Atraction>
            {
                 new Atraction { Id = 1, Name = "Atraction1"},
                 new Atraction { Id = 2, Name = "Atraction2"},
                 new Atraction { Id = 3, Name = "Atraction3"}
            });
            mock.Setup(m => m.Areas.GetAll).Returns(new List<Area>
            {
                 new Area { Id = 1, Name = "Area1"},
                 new Area { Id = 2, Name = "Area2"},
                 new Area { Id = 3, Name = "Area3"}
            });

            OrderService service = new OrderService(mock.Object);
            service.DeleteOrder(order);

            mock.Verify(t => t.Orders.Delete(order.Id));
        }

        [TestMethod]
        public void Can_OrderService_Get_All_Orderes()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Orders.GetAll).Returns(new List<Order>
            {
                 new Order { Id = 1, Name = "Order1"},
                 new Order { Id = 2, Name = "Order2"},
                 new Order { Id = 3, Name = "Order3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.GetOrders();

            mock.Verify(t => t.Orders.GetAll);
        }

        [TestMethod]
        public void Can_OrderService_Get_Order_With_Id_2()
        {

            OrderDTO[] Order = {
                new OrderDTO { Id=1, Name="Order1"},
                new OrderDTO { Id=2, Name="Order2"},
                new OrderDTO { Id=3, Name="Order3"},
            };

            Mock<IOrderService> mock = new Mock<IOrderService>();
            mock.Setup(r => r.GetOrder(2)).Returns(Order[1]);

            IOrderService service = mock.Object;
            var h = service.GetOrder(2);
            Assert.AreEqual("Order2", h.Name);

        }
    }
}
