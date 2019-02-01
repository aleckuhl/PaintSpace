using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProj.Models
{
    public class PaintData
    {
        static List<Dictionary<string, string>> Paints = new List<Dictionary<string, string>>();

        public static void LoadPaints()
        {

            

            using (StreamReader reader = File.OpenText("Models/Paints.txt"))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    Dictionary<string, string> rowDict = RowToDict(line);
                    Paints.Add(rowDict);
                 
                }
            }
        }

        public static Dictionary<string,string> RowToDict(string row)
        {
            Dictionary<string, string> paintDict = new Dictionary<string, string>();

            row.Replace("Base", "");
            row.Replace("Layer", "");
            row.Replace("Shade", "");
            row.Replace("Dry", "");
            row.Replace("Glaze", "");
            string[] paintSplit = row.Split("#");
            paintDict.Add(paintSplit[0], paintSplit[1]); ;

            return paintDict;
        }

        public static List<Dictionary<string,string>> ReturnPaints()
        {
            List<Dictionary<string, string>> paints = new List<Dictionary<string, string>>();
            paints = Paints;
            return paints;
        }
    }
}
