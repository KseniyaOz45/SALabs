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
    public class OrdersController : ApiController
    {
        IOrderService orderService;

        //public AtractionsController()
        //{
        //    unitOfWork = new EFUnitOfWork("DefaultConnection");
        //    orderService = new OrderService(unitOfWork);
        //}

        public OrdersController(IOrderService serv)
        {
            orderService = serv;
        }

        public IEnumerable<OrderVM> GetOrders()
        {
            IEnumerable<OrderDTO> orderDtos = orderService.GetOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderVM>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderVM>>(orderDtos);
            return orders;
        }

        public OrderVM GetOrder(int id)
        {
            OrderDTO order = orderService.GetOrder(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderVM>()).CreateMapper();
            var order_VM = mapper.Map<OrderVM>(order);
            return order_VM;
        }

        [HttpPost]
        public void CreateOrder([FromBody]Order order)
        {
            try
            {
                var orderDto = new OrderDTO { Id = order.Id, Name = order.Name, Type = order.Type, Time = order.Time, Price = order.Price, HeroId = order.HeroId, AreaId = order.AreaId, AtractionId = order.AtractionId };
                orderService.MakeOrder(orderDto);
                //return ObjectContent("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
        }

        [HttpPut]
        public void EditOrder([FromBody]Order order)
        {
            var orderDto = new OrderDTO { Id = order.Id, Name = order.Name, Type = order.Type, Time = order.Time, Price = order.Price, HeroId = order.HeroId, AreaId = order.AreaId, AtractionId = order.AtractionId };
            orderService.EditOrder(orderDto);
        }

        public void DeleteOrder(int id)
        {
            var orderDto = orderService.GetOrder(id);
            orderService.DeleteOrder(orderDto);
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
