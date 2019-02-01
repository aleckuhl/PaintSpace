using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiftoffProj.Data;
using LiftoffProj.Models;
using LiftoffProj.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiftoffProj.Controllers
{
    public class PaintController : Controller
    {
        private readonly PaintDbContext context;

        public PaintController(PaintDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
           
            //foreach(Dictionary<string,string> paint in PaintData.ReturnPaints())
            //{
            //    string paintKey = "";
            //    string paintValue = "";
            //    foreach(string key in paint.Keys)
            //    {
            //        paintKey = key;
            //    }
            //    foreach(string value in paint.Values)
            //    {
            //        paintValue = value;
            //    }
            //    Paint newPaint = new Paint
            //    {
            //        Name = paintKey,
            //        Color = paintValue,
            //    };

            //    context.Paints.Add(newPaint);
            //    context.SaveChanges();
            //}
            //Paint testPaint = new Paint
            //{
            //    Name = "test",
            //    Color = "0123",
            //};
            //context.Paints.Add(testPaint);
            //context.SaveChanges();
            IList<Paint> paints = context.Paints.ToList();
            return View(paints);
        }

        public IActionResult Add()
        {
            AddPaintViewModel addPaintViewModel = new AddPaintViewModel();
            return View(addPaintViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddPaintViewModel addPaintViewModel)
        {
            if (ModelState.IsValid)
            {

                Paint newPaint = new Paint
                {
                    Name = addPaintViewModel.Name,
                    Color = addPaintViewModel.Color,
                };
                context.Paints.Add(newPaint);
                context.SaveChanges();

                return Redirect("/Paint");
            }
            else
            {
                return View(addPaintViewModel);
            }
        }
    }
}
