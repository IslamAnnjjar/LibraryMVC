using ITI.Library.Models;
using ITI.Library.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI.Library.Presentation.Controllers
{
   
    public class BookController : Controller
    {
        private readonly LibraryContext Context;
        private IConfiguration Con;
        
        public BookController(LibraryContext _Context, IConfiguration _Con)
        {
            Context = _Context;
            Con = _Con;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            ViewBag.Title = "Books | Index";
            ViewBag.Url = Con.GetSection("ImagesUrl").Value;
           
            var books = Context.Books.ToList();
            return View(books);
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Add()
        {
            ViewBag.Authors
                 = Context.Authors.Select(i => new SelectListItem(i.Name, i.ID.ToString()))
                 .ToList();
    
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(BookCreateModel model)
        {
            if(ModelState.IsValid == false)
            {
                ViewBag.Authors
                 = Context.Authors.Select(i => new SelectListItem(i.Name, i.ID.ToString()))
                 .ToList();
                ModelState.AddModelError("", "You Have 3 Times At most To Try To Add Book");
                return View();
            }
            else
            {
                Context.Books.Add(new Book
                {
                    ID = 0,
                    Title = model.Title,
                    AuthorID = model.AuthorID
                });
                Context.SaveChanges();
                ViewBag.Title = "Books | Index";
                ViewBag.Url = Con.GetSection("ImagesUrl").Value;
                return RedirectToAction("Get"); 
            }
        }
    }
}
