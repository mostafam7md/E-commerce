using AutoMapper;
using ECommerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        ECommerceDb _Context;
        IMapper _Mapper;
        public OrderController(ECommerceDb context,IMapper mapper)
        {
            _Mapper = mapper;
            _Context = context;
        }
        
        [HttpPost("CreateOrder")]
        public ActionResult CreateOrder(OrderDTO o)
        {
            Order order = _Mapper.Map<Order>(o);
            
            order.date = DateTime.Now;
            order.Address = o.Address;
            order.CustomerId = o.CustomerId;
            _Context.orders.Add(order);
            _Context.SaveChanges();    
            float sum = 0f;
            foreach (var item in o.list)
            {
            OrderItem u = new OrderItem();
               
                u.prodId = item.prodId;
                u.Quantity = item.Quantity;
                u.OrderId = order.OrderId;
                u.Price = item.Price;
                sum = sum + ((float)u.Quantity * u.Price);
                _Context.orderItems.Add(u);
                _Context.SaveChanges();
            }
            order.TotalPrice = sum;
            _Context.orders.Add(order);
            _Context.SaveChanges();
            return Ok("done");

        }

        [HttpGet("GetOrders")]
        public ActionResult GetOrders()
        {
            var res = _Context.orders.Include(c=>c.orderItems).ToList();
            return Ok(res);
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(int id)
        {
            var o = _Context.orderItems.Find(id);

            if (o == null)
            {
                return BadRequest("there's no orderitem with this id");
            }

            _Context.orderItems.Remove(o);
            _Context.SaveChanges();
            return Ok();
        }
    }
}
