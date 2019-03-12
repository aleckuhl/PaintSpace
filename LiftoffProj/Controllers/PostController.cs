using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftoffProj.Data;
using LiftoffProj.Models;
using Microsoft.AspNetCore.Mvc;
using LiftoffProj.ViewModels;
using Microsoft.AspNetCore.Http;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API;
using Imgur.API.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiftoffProj.Controllers
{
    public class PostController : Controller
    {
        private readonly PaintDbContext context;

        public PostController(PaintDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Post> posts = context.Posts.ToList();
            return View(posts);
        }

        public IActionResult Add()
        {

            AddPostViewModel addPostViewModel = new AddPostViewModel(context.Paints.ToList());
            return View(addPostViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPostViewModel addPostViewModel, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                IList<PaintPost> paints = new List<PaintPost>();
                //Paint newPaint =
                //    context.Paints.SingleOrDefault(c => c.ID == addPostViewModel.PaintID);

                paints.Add(new PaintPost { PaintID = addPostViewModel.PaintID });
                var client = new ImgurClient("9b0da4acf24db98", "c62e73e153e722dfa8cbe2531b59d8f3be69fbe7");
                var endpoint = new ImageEndpoint(client);
                List<PostLink> imageLinks = new List<PostLink>();
                var filePath = Path.GetTempFileName();
                foreach (var file in files)
                {
                    try
                    {
                        IImage image;
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        using (var fs = new FileStream(filePath, FileMode.Open))
                        {
                            image = await endpoint.UploadImageStreamAsync(fs);
                        }
                        imageLinks.Add(new PostLink() { StreamLink = image.Link });

                    }
                    catch (ImgurException imgurEx)
                    {
                        return BadRequest(imgurEx.Message);
                    }
                }
                Post newPost = new Post
                {
                    Title = addPostViewModel.Title,
                    Description = addPostViewModel.Description,
                    PaintPosts = paints,
                    ImageLinks = imageLinks,
                };
                context.Posts.Add(newPost);
                context.SaveChanges();

                return Redirect("/Post");
            }
            else
            {
                return View(addPostViewModel);
            }

        }

        [HttpGet]
        [Route("/Post/ViewPost/{id}")]
        public IActionResult ViewPost([FromRoute] int id)
        {
            Post post = context.Posts.Include(p => p.ImageLinks).Single(c => c.ID == id);
            List<Paint> paints = context.PaintPosts
                .Include(p => p.Paint)
                .Where(c => c.PostID == id)
                .Select(x => x.Paint).ToList();
            ViewPostViewModel viewPostViewModel = new ViewPostViewModel
            {
                Post = post,
                Paints = paints,
            };
            return View(viewPostViewModel);
        }
    }
}
