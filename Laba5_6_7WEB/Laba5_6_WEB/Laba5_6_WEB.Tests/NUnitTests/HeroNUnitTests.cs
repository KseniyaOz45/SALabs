using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5_6_WEB.Tests.NUnitTests
{
    [TestFixture]
    public class HeroNUnitTests
    {
        [Test]
        public void Can_ServiceModule_Add_A_New_Hero()
        {
            HeroDTO heroDto = new HeroDTO() { Id = 4, Name = "Hero4" };
            var heroes = new List<Hero>
            {
                new Hero { Id = 1, Name = "Hero1"},
                new Hero { Id = 2, Name = "Hero2"},
                new Hero { Id = 3, Name = "Hero3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Heroes.GetAll).Returns(heroes);

            OrderService service = new OrderService(mock.Object);
            service.MakeHero(heroDto);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeroDTO, Hero>()).CreateMapper();
            var hero = mapper.Map<Hero>(heroDto);

            heroes.Add(hero);
            var heroes_after = service.GetHeroes();

            mock.Verify(t => t.Heroes.Create(It.IsAny<Hero>()));
            Assert.That(heroes_after.Count(), Is.EqualTo(4));
        }

        [Test]
        public void Can_ServiceModeule_Edit_A_Hero_With_Id_2()
        {
            HeroDTO heroDto = new HeroDTO() { Id = 2, Name = "Hero2_NEW" };
            var heroes = new List<Hero>
            {
                new Hero { Id = 1, Name = "Hero1"},
                new Hero { Id = 2, Name = "Hero2"},
                new Hero { Id = 3, Name = "Hero3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Heroes.GetAll).Returns(heroes);

            OrderService service = new OrderService(mock.Object);
            service.EditHero(heroDto);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeroDTO, Hero>()).CreateMapper();
            var hero = mapper.Map<Hero>(heroDto);

            heroes.Where(h=>h.Id == hero.Id).FirstOrDefault().Name = hero.Name;
            var heroes_after = service.GetHeroes();

            mock.Verify(t => t.Heroes.Update(It.IsAny<Hero>()));
            Assert.That(heroes_after.Where(h => h.Id == hero.Id).FirstOrDefault().Name, Is.EqualTo("Hero2_NEW"));
        }

        [Test]
        public void Can_ServiceModule_Delete_A_Hero_With_Id_2()
        {
            HeroDTO heroDto = new HeroDTO() { Id = 2, Name = "Hero2" };
            var heroes = new List<Hero>
            {
                new Hero { Id = 1, Name = "Hero1"},
                new Hero { Id = 2, Name = "Hero2"},
                new Hero { Id = 3, Name = "Hero3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Heroes.GetAll).Returns(heroes);

            OrderService service = new OrderService(mock.Object);
            service.DeleteHero(heroDto);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeroDTO, Hero>()).CreateMapper();
            var hero = mapper.Map<Hero>(heroDto);

            heroes.RemoveAt(heroDto.Id);
            var heroes_after = service.GetHeroes();

            mock.Verify(t => t.Heroes.Delete(heroDto.Id));
            Assert.That(heroes_after.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Can_ServiceModule_Get_A_Hero_With_Id_2()
        {
            int id = 2;
            var heroes = new List<Hero>
            {
                new Hero { Id = 1, Name = "Hero1"},
                new Hero { Id = 2, Name = "Hero2"},
                new Hero { Id = 3, Name = "Hero3"},
            };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Heroes.Get(id)).Returns(heroes.Where(h=>h.Id==id).FirstOrDefault());

            OrderService service = new OrderService(mock.Object);
            var hero = service.GetHero(id);

            mock.Verify(t => t.Heroes.Get(id));
            Assert.That(hero.Name, Is.EqualTo("Hero2"));
        }

        [Test]
        public void Can_ServiceModule_Get_All_Heroes()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Heroes.GetAll).Returns(new List<Hero>
            {
                 new Hero { Id = 1, Name = "Hero1"},
                 new Hero { Id = 2, Name = "Hero2"},
                 new Hero { Id = 3, Name = "Hero3"},
            });

            OrderService service = new OrderService(mock.Object);
            var heroes = service.GetHeroes();

            mock.Verify(t => t.Heroes.GetAll);
            Assert.That(3, Is.EqualTo(heroes.ToList().Count()));
        }
    }
}
