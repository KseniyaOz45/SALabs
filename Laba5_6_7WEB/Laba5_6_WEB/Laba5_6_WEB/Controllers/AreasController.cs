using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using Laba5_6_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Laba5_6_WEB.Controllers
{
    public class AreasController : ApiController
    {
        IOrderService orderService;

        //public AtractionsController()
        //{
        //    unitOfWork = new EFUnitOfWork("DefaultConnection");
        //    orderService = new OrderService(unitOfWork);
        //}

        public AreasController(IOrderService serv)
        {
            orderService = serv;
        }

        public IEnumerable<AreaVM> GetAreas()
        {
            IEnumerable<AreaDTO> areaDtos = orderService.GetAreas();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, AreaVM>()).CreateMapper();
            var areas = mapper.Map<IEnumerable<AreaDTO>, List<AreaVM>>(areaDtos);
            return areas;
        }

        public AreaVM GetArea(int id)
        {
            AreaDTO area = orderService.GetArea(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, AreaVM>()).CreateMapper();
            var area_VM = mapper.Map<AreaVM>(area);
            return area_VM;
        }

        [HttpPost]
        public void CreateArea([FromBody]Area area)
        {
            try
            {
                var areaDto = new AreaDTO { Id = area.Id, Name = area.Name, Type = area.Type};
                orderService.MakeArea(areaDto);
                //return ObjectContent("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
        }

        [HttpPut]
        public void EditArea([FromBody]Area area)
        {
            var areaDto = new AreaDTO { Id = area.Id, Name = area.Name, Type = area.Type};
            orderService.EditArea(areaDto);
        }

        public void DeleteArea(int id)
        {
            var areaDto = orderService.GetArea(id);
            orderService.DeleteArea(areaDto);
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
