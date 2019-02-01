using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LiftoffProj.Models;

namespace LiftoffProj.Data
{
    public class PaintDbContext : DbContext
    {
        public DbSet<Paint> Paints { get; set; }

        public DbSet<Post> Posts { get; set; }

        public PaintDbContext(DbContextOptions<PaintDbContext> options)
           : base(options)
        { }

    
    }
}
