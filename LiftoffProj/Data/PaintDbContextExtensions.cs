using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftoffProj.Models;

namespace LiftoffProj.Data
{
    public static class PaintDbContextExtensions
    {
     

        public static void EnsureDatabaseSeeded(this PaintDbContext context)
        {
            if (!context.Paints.Any())
            {
                foreach (Dictionary<string, string> paint in PaintData.ReturnPaints())
                {
                    string paintKey = "";
                    string paintValue = "";
                    foreach (string key in paint.Keys)
                    {
                        paintKey = key;
                    }
                    foreach (string value in paint.Values)
                    {
                        paintValue = value;
                    }
                    Paint newPaint = new Paint
                    {
                        Name = paintKey,
                        Color = paintValue,
                    };

                    context.Paints.Add(newPaint);
                    context.SaveChanges();
                }
            }

        }
    }
}
