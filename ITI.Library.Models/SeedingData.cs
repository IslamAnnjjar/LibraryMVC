using ITI.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Library
{
    public static class SeedingData
    {
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<Author>()
                .HasData(new Author()
                {
                    ID = 1,
                    Name = "Jeffrey Richter"
                });

            builder.Entity<Book>()
                .HasData(new Book()
                {
                    ID = 1,
                    Title = "CLR via C#",
                    AuthorID = 1
                }); 
        }
    }
}
