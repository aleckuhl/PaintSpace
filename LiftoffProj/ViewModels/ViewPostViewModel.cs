using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftoffProj.Models;

namespace LiftoffProj.ViewModels
{
    public class ViewPostViewModel
    {
        public Post Post { get; set; }
        public IList<Paint> Paints { get; set; }
       
    }
}
