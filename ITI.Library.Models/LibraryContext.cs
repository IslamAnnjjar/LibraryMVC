using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Library.Models
{
    public class LibraryContext : IdentityDbContext<User>
    {

        public LibraryContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Author>? Authors { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<BookImage>? BookImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AuthorConfiguration().Configure
                (modelBuilder.Entity<Author>());
            new BookConfiguration().Configure(modelBuilder.Entity<Book>());
            new BookImageConfiguration().Configure(modelBuilder.Entity<BookImage>());

            modelBuilder.MapRelationships();
            modelBuilder.SeedData();
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

    }
}
