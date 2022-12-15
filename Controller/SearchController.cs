using ECommerce.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controller
{   [ApiController]
    public class SearchController:ControllerBase
    {
        ECommerceDb _Context;

        public SearchController(ECommerceDb context)
        {
            _Context = context;
        }

        [HttpGet("Search")]
        public ActionResult Search(String s)
        {
            ArrayList res = new ArrayList();
            var p = _Context.products.Where(x => x.Name == s);
            var x = _Context.catogeries.Where(x => x.Name == s);
            res.Add(p);
            res.Add(x);
            return Ok(res);
        }
    }
}
