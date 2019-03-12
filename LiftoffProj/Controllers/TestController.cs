using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Imgur.API;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiftoffProj.Controllers
{
    public class TestController : Controller
    {
        // GET: /<controller>/
        public async Task <IActionResult> Index()
        {
            return View();
            //try
            //{
            //    var client = new ImgurClient("9b0da4acf24db98", "c62e73e153e722dfa8cbe2531b59d8f3be69fbe7");
            //    var endpoint = new ImageEndpoint(client);
            //    IImage image;
            //    using (var fs = new FileStream(@"test.jpg", FileMode.Open))
            //    {
            //        image = await endpoint.UploadImageStreamAsync(fs);
            //    }
            //    var Image = endpoint.GetImageAsync(image.Id).GetAwaiter().GetResult();

            //    return View(image.Id);
            //}
            //catch (ImgurException imgurEx)
            //{
            //    return BadRequest(imgurEx.Message);
            //}
            
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }


    }

}
