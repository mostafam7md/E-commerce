using ECommerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controller
{   [ApiController]
    public class CatogeryController:ControllerBase
    {
        ECommerceDb _Context;

        public CatogeryController(ECommerceDb context)
        {
            _Context = context;
        }
        [HttpGet("GetAllCatogery")]
        public ActionResult AllCatogery()
        {
            var p = _Context.catogeries.Include(c=>c.products).ToList();
            return Ok(p);
        }
        [HttpGet("GetOneCatogery")]
        public ActionResult GetOneCatogery (int id)
        {
            var p = _Context.catogeries.Where(c=>c.CatogeryId==id).Include(c => c.products).ToList();
            return Ok(p);
        }
    }
}
