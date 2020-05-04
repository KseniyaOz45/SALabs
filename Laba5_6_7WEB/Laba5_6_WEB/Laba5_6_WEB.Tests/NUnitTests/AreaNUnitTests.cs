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
    public class AreaNUnitTests
    {
        [Test]
        public void Can_OrderService_Add_Area()
        {
            AreaDTO atrDto = new AreaDTO() { Id = 4, Name = "Area4" };
            var Areas = new List<Area>
            {
                new Area { Id = 1, Name = "Area1"},
                new Area { Id = 2, Name = "Area2"},
                new Area { Id = 3, Name = "Area3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Areas.GetAll).Returns(Areas);

            OrderService service = new OrderService(mock.Object);
            service.MakeArea(atrDto);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, Area>()).CreateMapper();
            var atr = mapper.Map<Area>(atrDto);

            Areas.Add(atr);
            var Areas_after = service.GetAreas();

            mock.Verify(t => t.Areas.Create(It.IsAny<Area>()));
            Assert.That(Areas_after.Count(), Is.EqualTo(4));
        }

        [Test]
        public void Can_OrderService_Edit_Area_With_Id_2()
        {
            AreaDTO atrDto = new AreaDTO() { Id = 2, Name = "Area2_NEW" };
            var Areas = new List<Area>
            {
                new Area { Id = 1, Name = "Area1"},
                new Area { Id = 2, Name = "Area2"},
                new Area { Id = 3, Name = "Area3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Areas.GetAll).Returns(Areas);

            OrderService service = new OrderService(mock.Object);
            service.EditArea(atrDto);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, Area>()).CreateMapper();
            var atr = mapper.Map<Area>(atrDto);

            Areas.Where(a => a.Id == atrDto.Id).FirstOrDefault().Name = atrDto.Name;
            var Areas_after = service.GetAreas();

            mock.Verify(t => t.Areas.Update(It.IsAny<Area>()));
            Assert.That(Areas_after.Where(a => a.Id == atrDto.Id).FirstOrDefault().Name, Is.EqualTo("Area2_NEW"));
        }

        [Test]
        public void Can_OrderService_Delete_Area_With_Id_2()
        {
            AreaDTO atrDto = new AreaDTO() { Id = 2, Name = "Area2" };
            var Areas = new List<Area>
            {
                new Area { Id = 1, Name = "Area1"},
                new Area { Id = 2, Name = "Area2"},
                new Area { Id = 3, Name = "Area3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Areas.GetAll).Returns(Areas);

            OrderService service = new OrderService(mock.Object);
            service.DeleteArea(atrDto);

            Areas.RemoveAt(atrDto.Id);
            var Areas_after = service.GetAreas();

            mock.Verify(t => t.Areas.Delete(atrDto.Id));
            Assert.That(Areas_after.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Can_OrderService_Get_Area_With_Id_2()
        {
            int id = 2;
            var Areas = new List<Area>
            {
                new Area { Id = 1, Name = "Area1"},
                new Area { Id = 2, Name = "Area2"},
                new Area { Id = 3, Name = "Area3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Areas.Get(id)).Returns(Areas.Find(a => a.Id == id));

            OrderService service = new OrderService(mock.Object);
            var atr = service.GetArea(id);

            mock.Verify(t => t.Areas.Get(id));
            Assert.That(atr.Name, Is.EqualTo("Area2"));
        }

        [Test]
        public void Can_OrderService_Get_All_Areas()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Areas.GetAll).Returns(new List<Area>
            {
                 new Area { Id = 1, Name = "Area1"},
                 new Area { Id = 2, Name = "Area2"},
                 new Area { Id = 3, Name = "Area3"},
            });

            OrderService service = new OrderService(mock.Object);
            var Areas = service.GetAreas();

            mock.Verify(t => t.Areas.GetAll);
            Assert.That(Areas.ToList().Count(), Is.EqualTo(3));
        }
    }
}
