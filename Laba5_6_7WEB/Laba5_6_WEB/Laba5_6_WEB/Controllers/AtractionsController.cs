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
    public class AtractionsController : ApiController
    {
        IOrderService orderService;

        //public AtractionsController()
        //{
        //    unitOfWork = new EFUnitOfWork("DefaultConnection");
        //    orderService = new OrderService(unitOfWork);
        //}

        public AtractionsController(IOrderService serv)
        {
            orderService = serv;
        }

        public IEnumerable<AtractionVM> GetAtractions()
        {
            IEnumerable<AtractionDTO> atrDtos = orderService.GetAtractions();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AtractionDTO, AtractionVM>()).CreateMapper();
            var atractions = mapper.Map<IEnumerable<AtractionDTO>, List<AtractionVM>>(atrDtos);
            return atractions;
        }

        public AtractionVM GetAtraction(int id)
        {
            AtractionDTO atr = orderService.GetAtraction(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AtractionDTO, AtractionVM>()).CreateMapper();
            var atr_VM = mapper.Map<AtractionVM>(atr);
            return atr_VM;
        }

        [HttpPost]
        public void CreateAtraction([FromBody]Atraction atraction)
        {
            try
            {
                var atrDto = new AtractionDTO { Id = atraction.Id, Name = atraction.Name, Type = atraction.Type, Capacity = atraction.Capacity };
                orderService.MakeAtraction(atrDto);
                //return ObjectContent("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
        }

        [HttpPut]
        public void EditAtraction([FromBody]Atraction atraction)
        {
            var atrDto = new AtractionDTO { Id = atraction.Id, Name = atraction.Name, Type = atraction.Type, Capacity = atraction.Capacity };
            orderService.EditAtraction(atrDto);
        }

        public void DeleteAtraction(int id)
        {
            var atrDto = orderService.GetAtraction(id);
            orderService.DeleteAtraction(atrDto);
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
