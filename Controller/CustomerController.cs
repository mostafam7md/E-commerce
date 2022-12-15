using AutoMapper;
using ECommerce.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controller
{   [ApiController]
    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        ECommerceDb _Context;
        IMapper _Mapper;

        public CustomerController(ECommerceDb context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }
        [HttpPost("CustomerRegister")]
        public ActionResult CustomerRegister([FromBody] CustomerRegister c)
        {
            var res = _Context.customers.Where(s => s.CustomerEmail == c.CustomerEmail).FirstOrDefault();
            if (res != null)
            {
                return BadRequest("this email allready have an account");
            }
            Customer c1 = _Mapper.Map<Customer>(c);
            _Context.customers.Add(c1);
            _Context.SaveChanges();
            return Ok(c1);
        }
        [HttpPost("CustomerLogin")]
        public ActionResult CustomerLogin([FromBody] CustomerLogin c)
        {
            var customer = _Context.customers.Where(s => s.CustomerEmail ==
            c.CustomerEmail && s.Password == c.Password).FirstOrDefault();
            if (customer == null)
            {
                return Unauthorized("incorrect Email or password ");
            }
            return Ok(customer);
        }
        [HttpPut("EditCustomer")]
        public ActionResult EditCustomer(int id, [FromBody] CustomerRegister c)
        {
            var customer = _Context.customers.Where(c=>c.CustomerId==id).AsNoTracking().FirstOrDefault();
            if (customer == null)
            {
                return BadRequest("there's no customer with the same id");
            }
            Customer customer1 = new Customer()
            {
                CustomerId = id,
                CustomerEmail = c.CustomerEmail ?? customer.CustomerEmail,
                Password = c.Password ?? customer.Password,
                FName = c.FName ?? customer.FName,
                LName = c.LName ?? customer.LName,
                Phone = c.Phone ?? customer.Phone
            };
            _Context.customers.Update(customer1);
            _Context.SaveChanges();
            return Ok(customer1);
        }
  
        [HttpGet("PinLogin")]
        public ActionResult LoginPin(int pin,int id)
        {
            var res = _Context.customers.Find(id);
            if (pin == res.Pin)
            {
                return Ok(res);
            }
            return BadRequest("Wrong Pin");
        }
        [HttpDelete("DeleteAccount")]
        public ActionResult DeleteAccount([FromForm] int id)
        {
            var customer = _Context.customers.Find(id);

            if (customer == null)
            {
                return BadRequest("there's no customer with this id");
            }

            _Context.customers.Remove(customer);
            _Context.SaveChanges();

            return Ok("done");

        }
        
  
    }
}
