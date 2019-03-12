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

        public DbSet<PostLink> PostLinks { get; set; }

        public DbSet<PaintPost> PaintPosts { get; set; }

        public PaintDbContext(DbContextOptions<PaintDbContext> options)
           : base(options)
        { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PaintPost>()
        //        .HasKey(bc => new { bc.PaintID, bc.PostID });
        //    modelBuilder.Entity<PaintPost>()
        //        .HasOne(bc => bc.Paint)
        //        .WithMany(b => b.BookCategories)
        //        .HasForeignKey(bc => bc.BookId);
        //    modelBuilder.Entity<BookCategory>()
        //        .HasOne(bc => bc.Category)
        //        .WithMany(c => c.BookCategories)
        //        .HasForeignKey(bc => bc.CategoryId);
        //}
    }
}

