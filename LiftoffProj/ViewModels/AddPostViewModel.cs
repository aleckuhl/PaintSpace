using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LiftoffProj.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiftoffProj.ViewModels
{
    public class AddPostViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int PaintID { get; set; }



        public List<SelectListItem> Paints { get; set; }

        public MultiSelectList paintsList;

        public AddPostViewModel(IEnumerable<Paint> paints)
        {

            Paints = new List<SelectListItem>();

            foreach (Paint paint in paints)
            {
                Paints.Add(new SelectListItem
                {
                    Value = (paint.ID).ToString(),
                    Text = paint.Name.ToString()
                });
            }

            paintsList = new MultiSelectList(Paints);
        }

        public AddPostViewModel()
        {

        }
    }
}
