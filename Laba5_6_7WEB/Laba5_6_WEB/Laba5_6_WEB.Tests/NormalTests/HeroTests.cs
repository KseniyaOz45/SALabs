using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Laba5_6_WEB.Controllers;
using Laba5_6_WEB.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Laba5_6_WEB.Tests.HeroTests
{
    [TestClass]
    public class HeroTests
    {
        [TestMethod]
        public void Can_OrderService_Add_New_Hero()
        {
            HeroDTO hero = new HeroDTO() { Id = 4, Name = "Hero4" };
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Heroes.GetAll).Returns(new List<Hero>
            {
                 new Hero { Id = 1, Name = "Hero1"},
                 new Hero { Id = 2, Name = "Hero2"},
                 new Hero { Id = 3, Name = "Hero3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.MakeHero(hero);

            mock.Verify(t => t.Heroes.Create(It.IsAny<Hero>()));
        }

        [TestMethod]
        public void Can_OrderService_Edit_Hero()
        {
            HeroDTO hero = new HeroDTO() { Id = 3, Name = "Hero3" };

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Heroes.GetAll).Returns(new List<Hero>
            {
                 new Hero { Id = 1, Name = "Hero1"},
                 new Hero { Id = 2, Name = "Hero2"},
                 new Hero { Id = 3, Name = "Hero3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.EditHero(hero);

            mock.Verify(t => t.Heroes.Update(It.IsAny<Hero>()));
        }

        [TestMethod]
        public void Can_OrderService_Delete_Hero()
        {
            HeroDTO hero = new HeroDTO() { Id = 3, Name = "Hero3" };

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Heroes.GetAll).Returns(new List<Hero>
            {
                 new Hero { Id = 1, Name = "Hero1"},
                 new Hero { Id = 2, Name = "Hero2"},
                 new Hero { Id = 3, Name = "Hero3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.DeleteHero(hero);

            mock.Verify(t => t.Heroes.Delete(hero.Id));
        }

        [TestMethod]
        public void Can_OrderService_Get_All_Heroes()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.Heroes.GetAll).Returns(new List<Hero>
            {
                 new Hero { Id = 1, Name = "Hero1"},
                 new Hero { Id = 2, Name = "Hero2"},
                 new Hero { Id = 3, Name = "Hero3"},
            });

            OrderService service = new OrderService(mock.Object);
            service.GetHeroes();

            mock.Verify(t => t.Heroes.GetAll);
        }

        [TestMethod]
        public void Can_OrderService_Get_Hero_With_Id_2()
        {

            HeroDTO[] hero = {
                new HeroDTO { Id=1, Name="Hero1"},
                new HeroDTO { Id=2, Name="Hero2"},
                new HeroDTO { Id=3, Name="Hero3"},
            };

            Mock<IOrderService> mock = new Mock<IOrderService>();
            mock.Setup(r => r.GetHero(2)).Returns(hero[1]);

            IOrderService service = mock.Object;
            var h = service.GetHero(2);
            Assert.AreEqual("Hero2",h.Name);

        }
    }
}
