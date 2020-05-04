using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Laba5_6_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Laba5_6_WEB.Controllers
{
    public class HeroesController : ApiController
    {
        private IOrderService orderService;
        IUnitOfWork unitOfWork;

        //public HeroesController()
        //{
        //    unitOfWork = new EFUnitOfWork("DefaultConnection");
        //    orderService = new OrderService(unitOfWork);
        //}

        public HeroesController(IOrderService serv)
        {
            orderService = serv;
        }

        public IEnumerable<HeroVM> GetHeroes()
        {
            IEnumerable<HeroDTO> heroDtos = orderService.GetHeroes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeroDTO, HeroVM>()).CreateMapper();
            var heroes = mapper.Map<IEnumerable<HeroDTO>, List<HeroVM>>(heroDtos);
            return heroes;
        }

        public HeroVM GetHero(int id)
        {
            HeroDTO hero = orderService.GetHero(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeroDTO, HeroVM>()).CreateMapper();
            var hero_VM = mapper.Map<HeroVM>(hero);
            return hero_VM;
        }

        [HttpPost]
        public void CreateHero([FromBody]Hero herodto)
        {
            try
            {
                var heroDto = new HeroDTO { Id = herodto.Id, Name = herodto.Name };
                orderService.MakeHero(heroDto);
                //return ObjectContent("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
        }

        [HttpPut]
        public void EditHero([FromBody]Hero herodto)
        {
            var heroDto = new HeroDTO { Id = herodto.Id,Name = herodto.Name };
            orderService.EditHero(heroDto);
        }

        public void DeleteHero(int id)
        {
            var heroDto = orderService.GetHero(id);
            orderService.DeleteHero(heroDto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                orderService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
