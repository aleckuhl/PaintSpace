using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftoffProj.Data;
using LiftoffProj.Models;
using Microsoft.AspNetCore.Mvc;
using LiftoffProj.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult Add(AddPostViewModel addPostViewModel)
        {
            if (ModelState.IsValid)
            {
                IList<Paint> paints = new List<Paint>();
                Paint newPaint =
                    context.Paints.SingleOrDefault(c => c.ID == addPostViewModel.PaintID);

                paints.Add(newPaint);

                Post newPost = new Post
                {
                    Title = addPostViewModel.Title,
                    Description = addPostViewModel.Description,
                    Paints = paints
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
    }
}
