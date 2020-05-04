using System;
using System.Collections.Generic;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Laba5_6_WEB.Tests.AtractionTests
{
    [TestClass]
    public class AtractionTests
    {
        [TestMethod]
        public void Can_OrderService_Add_New_Atraction()
        {
            AtractionDTO atr = new AtractionDTO() { Id = 4, Name = "Atraction4" };

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Atractions.GetAll).Returns(new List<Atraction>
            {
                 new Atraction { Id = 1, Name = "Atraction1"},
                 new Atraction { Id = 2, Name = "Atraction2"},
                 new Atraction { Id = 3, Name = "Atraction3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.MakeAtraction(atr);

            mock.Verify(t => t.Atractions.Create(It.IsAny<Atraction>()));
        }

        [TestMethod]
        public void Can_OrderService_Edit_Atraction()
        {
            AtractionDTO Atraction = new AtractionDTO() { Id = 3, Name = "Atraction3" };

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Atractions.GetAll).Returns(new List<Atraction>
            {
                 new Atraction { Id = 1, Name = "Atraction1"},
                 new Atraction { Id = 2, Name = "Atraction2"},
                 new Atraction { Id = 3, Name = "Atraction3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.EditAtraction(Atraction);

            mock.Verify(t => t.Atractions.Update(It.IsAny<Atraction>()));
        }

        [TestMethod]
        public void Can_OrderService_Delete_Atraction()
        {
            AtractionDTO Atraction = new AtractionDTO() { Id = 3, Name = "Atraction3" };

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Atractions.GetAll).Returns(new List<Atraction>
            {
                 new Atraction { Id = 1, Name = "Atraction1"},
                 new Atraction { Id = 2, Name = "Atraction2"},
                 new Atraction { Id = 3, Name = "Atraction3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.DeleteAtraction(Atraction);

            mock.Verify(t => t.Atractions.Delete(Atraction.Id));
        }

        [TestMethod]
        public void Can_OrderService_Get_All_Atractiones()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Atractions.GetAll).Returns(new List<Atraction>
            {
                 new Atraction { Id = 1, Name = "Atraction1"},
                 new Atraction { Id = 2, Name = "Atraction2"},
                 new Atraction { Id = 3, Name = "Atraction3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.GetAtractions();

            mock.Verify(t => t.Atractions.GetAll);
        }

        [TestMethod]
        public void Can_OrderService_Get_Atraction_With_Id_2()
        {

            AtractionDTO[] Atraction = {
                new AtractionDTO { Id=1, Name="Atraction1"},
                new AtractionDTO { Id=2, Name="Atraction2"},
                new AtractionDTO { Id=3, Name="Atraction3"},
            };

            Mock<IOrderService> mock = new Mock<IOrderService>();
            mock.Setup(r => r.GetAtraction(2)).Returns(Atraction[1]);

            IOrderService service = mock.Object;
            var h = service.GetAtraction(2);
            Assert.AreEqual("Atraction2", h.Name);

        }
    }
}
