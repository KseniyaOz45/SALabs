using System;
using System.Collections.Generic;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Laba5_6_WEB.Tests.AreaTests
{
    [TestClass]
    public class AreaTests
    {
        [TestMethod]
        public void Can_OrderService_Add_New_Area()
        {
            AreaDTO atr = new AreaDTO() { Id = 4, Name = "Area4" };

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Areas.GetAll).Returns(new List<Area>
            {
                 new Area { Id = 1, Name = "Area1"},
                 new Area { Id = 2, Name = "Area2"},
                 new Area { Id = 3, Name = "Area3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.MakeArea(atr);

            mock.Verify(t => t.Areas.Create(It.IsAny<Area>()));
        }

        [TestMethod]
        public void Can_OrderService_Edit_Area()
        {
            AreaDTO Area = new AreaDTO() { Id = 3, Name = "Area3" };

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Areas.GetAll).Returns(new List<Area>
            {
                 new Area { Id = 1, Name = "Area1"},
                 new Area { Id = 2, Name = "Area2"},
                 new Area { Id = 3, Name = "Area3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.EditArea(Area);

            mock.Verify(t => t.Areas.Update(It.IsAny<Area>()));
        }

        [TestMethod]
        public void Can_OrderService_Delete_Area()
        {
            AreaDTO Area = new AreaDTO() { Id = 3, Name = "Area3" };

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Areas.GetAll).Returns(new List<Area>
            {
                 new Area { Id = 1, Name = "Area1"},
                 new Area { Id = 2, Name = "Area2"},
                 new Area { Id = 3, Name = "Area3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.DeleteArea(Area);

            mock.Verify(t => t.Areas.Delete(Area.Id));
        }

        [TestMethod]
        public void Can_OrderService_Get_All_Areaes()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Areas.GetAll).Returns(new List<Area>
            {
                 new Area { Id = 1, Name = "Area1"},
                 new Area { Id = 2, Name = "Area2"},
                 new Area { Id = 3, Name = "Area3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.GetAreas();

            mock.Verify(t => t.Areas.GetAll);
        }

        [TestMethod]
        public void Can_OrderService_Get_Area_With_Id_2()
        {

            AreaDTO[] Area = {
                new AreaDTO { Id=1, Name="Area1"},
                new AreaDTO { Id=2, Name="Area2"},
                new AreaDTO { Id=3, Name="Area3"},
            };

            Mock<IOrderService> mock = new Mock<IOrderService>();
            mock.Setup(r => r.GetArea(2)).Returns(Area[1]);

            IOrderService service = mock.Object;
            var h = service.GetArea(2);
            Assert.AreEqual("Area2", h.Name);

        }
    }
}
