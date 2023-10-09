using BlogSite.Demo.Models;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM userRegisterVM)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Email = userRegisterVM.Mail,
                    NameSurname = userRegisterVM.NameSurname,
                    UserName = userRegisterVM.UserName,
                };
                var result=await _userManager.CreateAsync(appUser,userRegisterVM.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
            }
            return View();
        }
    }
}
