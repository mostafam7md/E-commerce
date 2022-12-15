using AutoMapper;
using ECommerce.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controller
{   [ApiController]
    [Route("Vendor")]
    public class VendorController:ControllerBase
    {
        ECommerceDb _Context;
        IMapper _Mapper;

        public VendorController(ECommerceDb context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }
        [HttpPost("VendorRegister")]
        public ActionResult VendorRegister([FromBody] VendorRegister v)
        {
            var res = _Context.vendors.Where(s => s.Email == v.Email).FirstOrDefault();
            if (res != null)
            {
                return BadRequest("this email allready have an account");
            }
            Vendor v1 = _Mapper.Map<Vendor>(v);
            _Context.vendors.Add(v1);
            _Context.SaveChanges();
            return Ok(v1);
        }
        [HttpPost("VendorLogin")]
        public ActionResult VendorLogin([FromBody] VendorLogin c)
        {
            var vendor = _Context.vendors.Where(s => s.Email ==
            c.Email && s.Password == c.Password).FirstOrDefault();
            if (vendor == null)
            {
                return Unauthorized("incorrect Email or password ");
            }
            return Ok(vendor);
        }
        [HttpPut("EditVendor")]
        public ActionResult EditCustomer(int id, [FromBody] VendorRegister v)
        {
            var vendor = _Context.vendors.Find(id);
            if (vendor == null)
            {
                return BadRequest("there's no customer with the same id");
            }
            Vendor vendor1 = new Vendor()
            {
                VendorId = id,
                Email = v.Email ?? vendor.Email,
                Password = v.Password ?? vendor.Password,
                Phone = v.Phone ?? vendor.Phone,
                City = v.City ?? vendor.City,
                Adress = v.Adress ?? vendor.Adress,
                SSN = v.SSN??v.SSN,
                Type=v.Type??v.Type
            };
            _Context.vendors.Update(vendor1);
            _Context.SaveChanges();
            return Ok(vendor1);
        }
        [HttpDelete("DeleteAccount")]
        public ActionResult DeleteAccount([FromForm] int id)
        {
            
            var vendor = _Context.vendors.Find(id);

            if (vendor == null)
            {
                return BadRequest("there's no Vendor with this id");
            }

            _Context.vendors.Remove(vendor);
            _Context.SaveChanges();

            return Ok("done");

        }

    }
}
