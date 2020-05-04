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
    public class AreaController : Controller
    {
        IOrderService orderService;
        public AreaController(IOrderService serv)
        {
            orderService = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<AreaDTO> atrDtos = orderService.GetAreas();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, AreaVM>()).CreateMapper();
            var areas = mapper.Map<IEnumerable<AreaDTO>, List<AreaVM>>(atrDtos);
            return View(areas);
        }

        public ActionResult MakeArea(int? id)
        {
            try
            {
                AreaDTO area = orderService.GetArea(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, AreaVM>()).CreateMapper();
                AreaVM h = mapper.Map<AreaVM>(area);
                return View(h);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeArea(AreaVM area)
        {
            try
            {
                var areaDto = new AreaDTO { Id = area.Id, Name = area.Name, Type = area.Type};
                orderService.MakeArea(areaDto);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(area);
        }

        public ActionResult DeleteArea(int? id)
        {
            try
            {
                AreaDTO area = orderService.GetArea(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, AreaVM>()).CreateMapper();
                AreaVM a = mapper.Map<AreaVM>(area);
                return View(a);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult DeleteArea(AreaVM area)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaVM, AreaDTO>()).CreateMapper();
                AreaDTO a = mapper.Map<AreaDTO>(area);
                orderService.DeleteArea(a);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(area);
        }

        public ActionResult UpdateArea2(int? id)
        {
            try
            {
                AreaDTO area = orderService.GetArea(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, AreaVM>()).CreateMapper();
                AreaVM a = mapper.Map<AreaVM>(area);
                return View(a);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult UpdateArea2(AreaVM area)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaVM, AreaDTO>()).CreateMapper();
                AreaDTO a = mapper.Map<AreaDTO>(area);
                orderService.EditArea(a);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(area);
        }

        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}