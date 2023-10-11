using BlogSite.BusinessLayer.Abstract;
using BlogSite.Demo.Models;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogSite.Demo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        SignInManager<AppUser> _signInManager;
        UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginVM userLoginVM)
        {
            var user = await _userManager.FindByNameAsync(userLoginVM.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "incorrect username or password");
                return View();
            }
            else if (!(await _userManager.CheckPasswordAsync(user, userLoginVM.Password)))
            {
                ModelState.AddModelError("", "incorrect username or password");
                return View();
            }
            await _signInManager.PasswordSignInAsync(user, userLoginVM.Password, true, false);
            return RedirectToAction("Index", "Dashboard");
        }
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //	var user = await _writerService.values.FirstOrDefaultAsync(x => x.Mail == writer.Mail && x.Password == writer.Password);
        //	if (user != null)
        //	{
        //		var claims = new Claim[] { new Claim(ClaimTypes.Name,user.Mail)
        //		};
        //		var claimsIdentity = new ClaimsIdentity(claims,"a"); 
        //		ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        //		await HttpContext.SignInAsync(claimsPrincipal);
        //		HttpContext.Session.SetString("userEmail", user.Mail);
        //		return RedirectToAction("Index", "Dashboard");
        //	}
        //	else
        //	{
        //		return View();
        //	}
        //}
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Blog");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
