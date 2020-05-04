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
    public class AtractionController : Controller
    {
        IOrderService orderService;
        public AtractionController(IOrderService serv)
        {
            orderService = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<AtractionDTO> atrDtos = orderService.GetAtractions();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AtractionDTO, AtractionVM>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<AtractionDTO>, List<AtractionVM>>(atrDtos);
            return View(orders);
        }

        public ActionResult MakeAtraction(int? id)
        {
            try
            {
                AtractionDTO atr = orderService.GetAtraction(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AtractionDTO, AtractionVM>()).CreateMapper();
                AtractionVM h = mapper.Map<AtractionVM>(atr);
                return View(h);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeAtraction(AtractionVM atr)
        {
            try
            {
                var atractionDto = new AtractionDTO { Id = atr.Id, Name = atr.Name, Type = atr.Type,Capacity=atr.Capacity };
                orderService.MakeAtraction(atractionDto);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(atr);
        }

        public ActionResult DeleteAtraction(int? id)
        {
            try
            {
                AtractionDTO atraction = orderService.GetAtraction(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AtractionDTO, AtractionVM>()).CreateMapper();
                AtractionVM a = mapper.Map<AtractionVM>(atraction);
                return View(a);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult DeleteAtraction(AtractionVM atr)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AtractionVM, AtractionDTO>()).CreateMapper();
                AtractionDTO a = mapper.Map<AtractionDTO>(atr);
                orderService.DeleteAtraction(a);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(atr);
        }

        public ActionResult UpdateAtraction2(int? id)
        {
            try
            {
                AtractionDTO atr = orderService.GetAtraction(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AtractionDTO, AtractionVM>()).CreateMapper();
                AtractionVM a = mapper.Map<AtractionVM>(atr);
                return View(a);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult UpdateAtraction2(AtractionVM atr)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AtractionVM, AtractionDTO>()).CreateMapper();
                AtractionDTO h = mapper.Map<AtractionDTO>(atr);
                orderService.EditAtraction(h);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(atr);
        }

        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}