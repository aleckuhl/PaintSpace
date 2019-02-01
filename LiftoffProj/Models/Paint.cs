using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProj.Models
{
    public class Paint
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        //public static Color HexToColor(string hexColor)
        //{
        //    Remove # if present
        //    if (hexColor.IndexOf('#') != -1)
        //        hexColor = hexColor.Replace("#", "");

        //    int red = 0;
        //    int green = 0;
        //    int blue = 0;

        //    if (hexColor.Length == 6)
        //    {
        //        #RRGGBB
        //        red = int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
        //        green = int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
        //        blue = int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);


        //    }
        //    else if (hexColor.Length == 3)
        //    {
        //        #RGB
        //        red = int.Parse(hexColor[0].ToString() + hexColor[0].ToString(), NumberStyles.AllowHexSpecifier);
        //        green = int.Parse(hexColor[1].ToString() + hexColor[1].ToString(), NumberStyles.AllowHexSpecifier);
        //        blue = int.Parse(hexColor[2].ToString() + hexColor[2].ToString(), NumberStyles.AllowHexSpecifier);
        //    }

        //    return Color.FromArgb(red, green, blue);
        //}
    }   
}
