using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LiftoffProj.Models;

namespace LiftoffProj.ViewModels
{
    public class AddPaintViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        public AddPaintViewModel()
        {

        }

    }
}
