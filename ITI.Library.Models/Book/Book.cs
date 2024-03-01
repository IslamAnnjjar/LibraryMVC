using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Library.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public int AuthorID { get; set; }
        public virtual Author? Author { get; set; }
        public virtual ICollection<BookImage>? BookImages { get; set; }

        [NotMapped]
        public List<IFormFile>? Images {get;set;}
    }
}
