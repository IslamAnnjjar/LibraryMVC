using ITI.Library.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Library.Presentation.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> RoleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(RoleCreateModel model)
        {
            if(!ModelState.IsValid)
                return View();
            else
            {
                var result  = 
                await RoleManager.CreateAsync(new IdentityRole()
                {
                    Name = model.Name
                });
                if(!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(i =>
                    {
                        ModelState.AddModelError("", i.Description);
                    });
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}
