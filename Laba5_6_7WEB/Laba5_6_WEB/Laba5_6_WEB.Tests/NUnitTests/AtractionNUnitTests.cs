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
    public class AtractionNUnitTests
    {
        [Test]
        public void Can_OrderService_Add_Attraction()
        {
            AtractionDTO atrDto = new AtractionDTO() { Id = 4, Name = "Atraction4" };
            var atractions = new List<Atraction>
            {
                new Atraction { Id = 1, Name = "Atraction1"},
                new Atraction { Id = 2, Name = "Atraction2"},
                new Atraction { Id = 3, Name = "Atraction3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Atractions.GetAll).Returns(atractions);

            OrderService service = new OrderService(mock.Object);
            service.MakeAtraction(atrDto);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AtractionDTO, Atraction>()).CreateMapper();
            var atr = mapper.Map<Atraction>(atrDto);

            atractions.Add(atr);
            var atractions_after = service.GetAtractions();

            mock.Verify(t => t.Atractions.Create(It.IsAny<Atraction>()));
            Assert.That(atractions_after.Count(), Is.EqualTo(4));
        }

        [Test]
        public void Can_OrderService_Edit_Attraction_With_Id_2()
        {
            AtractionDTO atrDto = new AtractionDTO() { Id = 2, Name = "Atraction2_NEW" };
            var atractions = new List<Atraction>
            {
                new Atraction { Id = 1, Name = "Atraction1"},
                new Atraction { Id = 2, Name = "Atraction2"},
                new Atraction { Id = 3, Name = "Atraction3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Atractions.GetAll).Returns(atractions);

            OrderService service = new OrderService(mock.Object);
            service.EditAtraction(atrDto);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AtractionDTO, Atraction>()).CreateMapper();
            var atr = mapper.Map<Atraction>(atrDto);

            atractions.Where(a=>a.Id==atrDto.Id).FirstOrDefault().Name = atrDto.Name;
            var atractions_after = service.GetAtractions();

            mock.Verify(t => t.Atractions.Update(It.IsAny<Atraction>()));
            Assert.That(atractions_after.Where(a => a.Id == atrDto.Id).FirstOrDefault().Name, Is.EqualTo("Atraction2_NEW"));
        }

        [Test]
        public void Can_OrderService_Delete_Attraction_With_Id_2()
        {
            AtractionDTO atrDto = new AtractionDTO() { Id = 2, Name = "Atraction2" };
            var atractions = new List<Atraction>
            {
                new Atraction { Id = 1, Name = "Atraction1"},
                new Atraction { Id = 2, Name = "Atraction2"},
                new Atraction { Id = 3, Name = "Atraction3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Atractions.GetAll).Returns(atractions);

            OrderService service = new OrderService(mock.Object);
            service.DeleteAtraction(atrDto);
            
            atractions.RemoveAt(atrDto.Id);
            var atractions_after = service.GetAtractions();

            mock.Verify(t => t.Atractions.Delete(atrDto.Id));
            Assert.That(atractions_after.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Can_OrderService_Get_Attraction_With_Id_2()
        {
            int id = 2;
            var atractions = new List<Atraction>
            {
                new Atraction { Id = 1, Name = "Atraction1"},
                new Atraction { Id = 2, Name = "Atraction2"},
                new Atraction { Id = 3, Name = "Atraction3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Atractions.Get(id)).Returns(atractions.Find(a=>a.Id==id));

            OrderService service = new OrderService(mock.Object);
            var atr = service.GetAtraction(id);

            mock.Verify(t => t.Atractions.Get(id));
            Assert.That(atr.Name, Is.EqualTo("Atraction2"));
        }

        [Test]
        public void Can_OrderService_Get_All_Attractions()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Atractions.GetAll).Returns(new List<Atraction>
            {
                 new Atraction { Id = 1, Name = "Atraction1"},
                 new Atraction { Id = 2, Name = "Atraction2"},
                 new Atraction { Id = 3, Name = "Atraction3"},
            });

            OrderService service = new OrderService(mock.Object);
            var atractions = service.GetAtractions();

            mock.Verify(t => t.Atractions.GetAll);
            Assert.That(atractions.ToList().Count(),Is.EqualTo(3));
        }
    }
}
