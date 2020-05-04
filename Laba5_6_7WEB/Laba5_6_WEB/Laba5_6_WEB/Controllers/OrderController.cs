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
    public class OrderController : Controller
    {
        IOrderService orderService;
        public OrderController(IOrderService serv)
        {
            orderService = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<OrderDTO> orderDtos = orderService.GetOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderVM>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderVM>>(orderDtos);
            return View(orders);
        }

        public ActionResult MakeOrder(int? id)
        {
            try
            {
                OrderDTO order = orderService.GetOrder(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderVM>()).CreateMapper();
                OrderVM h = mapper.Map<OrderVM>(order);
                return View(h);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderVM order)
        {
            try
            {
                var orderDto = new OrderDTO { Id = order.Id, Name = order.Name, Type = order.Type, Time = order.Time, Price=order.Price, HeroId = order.Id, AreaId = order.AreaId, AtractionId = order.AtractionId };
                orderService.MakeOrder(orderDto);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }

        public ActionResult DeleteOrder(int? id)
        {
            try
            {
                OrderDTO order = orderService.GetOrder(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderVM>()).CreateMapper();
                OrderVM o = mapper.Map<OrderVM>(order);
                return View(o);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult DeleteOrder(OrderVM order)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderVM, OrderDTO>()).CreateMapper();
                OrderDTO o = mapper.Map<OrderDTO>(order);
                orderService.DeleteOrder(o);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }

        public ActionResult UpdateOrder2(int? id)
        {
            try
            {
                OrderDTO order = orderService.GetOrder(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderVM>()).CreateMapper();
                OrderVM o = mapper.Map<OrderVM>(order);
                return View(o);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult UpdateOrder2(OrderVM order)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderVM, OrderDTO>()).CreateMapper();
                OrderDTO o = mapper.Map<OrderDTO>(order);
                orderService.EditOrder(o);
                return Content("<h2>Success!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }

        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}