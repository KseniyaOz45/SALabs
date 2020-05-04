using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using Laba5_6_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laba5_6_WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<HeroDTO> heroDtos = orderService.GetHeroes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeroDTO, HeroVM>()).CreateMapper();
            var heroes = mapper.Map<IEnumerable<HeroDTO>, List<HeroVM>>(heroDtos);
            return View(heroes);
        }

        public ActionResult MakeHero(int? id)
        {
            try
            {
                HeroDTO hero = orderService.GetHero(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeroDTO, HeroVM>()).CreateMapper();
                HeroVM h = mapper.Map<HeroVM>(hero);
                return View(h);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeHero(HeroVM hero)
        {
            try
            {
                var heroDto = new HeroDTO { Id = hero.Id, Name = hero.Name};
                orderService.MakeHero(heroDto);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(hero);
        }

        public ActionResult DeleteHero(int? id)
        {
            try
            {
                HeroDTO hero = orderService.GetHero(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeroDTO, HeroVM>()).CreateMapper();
                HeroVM h = mapper.Map<HeroVM>(hero);
                return View(h);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult DeleteHero(HeroVM hero)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeroVM, HeroDTO>()).CreateMapper();
                HeroDTO h = mapper.Map<HeroDTO>(hero);
                orderService.DeleteHero(h);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(hero);
        }

        public ActionResult UpdateHero2(int? id)
        {
            try
            {
                HeroDTO hero = orderService.GetHero(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeroDTO, HeroVM>()).CreateMapper();
                HeroVM h = mapper.Map<HeroVM>(hero);
                return View(h);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult UpdateHero2(HeroVM hero)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeroVM, HeroDTO>()).CreateMapper();
                HeroDTO h = mapper.Map<HeroDTO>(hero);
                orderService.EditHero(h);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(hero);
        }

        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}