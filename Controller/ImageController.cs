using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controller
{   
    [ApiController]
    [Route("Image")]
    public class ImageController:ControllerBase
    {
        [HttpPost("AddImage")]
        public ActionResult AddImage(IFormFile file)
        {
            string fullPath = Directory.GetCurrentDirectory() + "/Images";

            string name = DateTime.Now.Ticks.ToString() + file.FileName;

            string filePath = fullPath + "/" + name;

            var stream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(stream);

            return Ok("Images/" + name);

        }
    }
}
