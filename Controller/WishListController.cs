using AutoMapper;
using ECommerce.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controller
{   [ApiController]
    public class WishListController:ControllerBase
    {
        ECommerceDb _Context;
        IMapper _Mapper;

        public WishListController(ECommerceDb context,IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }
        [HttpPost("AddWishList")]
        public ActionResult AddWishList(int id,NewProduct product)
        {
            Product P1 = _Mapper.Map<Product>(product);
            Wishlist w = new Wishlist();
            var res = _Context.customers.Find(id);
            if (res == null)
            {
                return BadRequest("not found");
            }
            w.Image = product.Image;
            w.LongDescrprion = product.LongDescrprion;
            w.Name = product.Name;
            w.Price = product.Price;
            w.ProductId = P1.ProductId;
            w.ShortDescription = product.ShortDescription;
            _Context.wishlists.Add(w);
            _Context.SaveChanges();
            return Ok(w);
        }
        [HttpGet("showWishlist")]
        public ActionResult showWishlist()
        {
            var w = _Context.wishlists.ToList();
            return Ok(w);
        }
        [HttpDelete("DeleteWishList")]
        public ActionResult DeleteAccount([FromForm] int id)
        {
            var wishlist = _Context.wishlists.Find(id);

            if (wishlist == null)
            {
                return BadRequest("there's no wishlist with this id");
            }

            _Context.wishlists.Remove(wishlist);
            _Context.SaveChanges();

            return Ok("done");

        }
    }
}
