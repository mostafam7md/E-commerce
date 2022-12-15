using AutoMapper;
using ECommerce.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controller
{   [ApiController]
    [Route("Product")]
    public class ProductController:ControllerBase
    {
        ECommerceDb _Context;
        IMapper _Mapper;

        public ProductController(ECommerceDb context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }
        [HttpPost("AddProduct")]
        public ActionResult AddProduct(NewProduct p)
        {
            Product P1 = _Mapper.Map<Product>(p);
            _Context.products.Add(P1);
            _Context.SaveChanges();
            return Ok(P1);
        }
        [HttpGet("ShowProduct")]
        public ActionResult ShowProduct()
        {
            var p = _Context.products.ToList();
            return Ok(p);
        }
        [HttpDelete("DeleteProduct")]
        public ActionResult DeleteProduct([FromForm] int id)
        {
            var product = _Context.products.Find(id);

            if (product == null)
            {
                return BadRequest("there's no product with this id");
            }

            _Context.products.Remove(product);
            _Context.SaveChanges();

            return Ok("done");

        }
    }
}
