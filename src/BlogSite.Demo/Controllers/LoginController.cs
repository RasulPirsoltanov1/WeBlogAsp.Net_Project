using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogSite.Demo.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		IWriterService _writerService;

		public LoginController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]

		public async Task<IActionResult> Index(Writer writer)
		{
			var user = await _writerService.values.FirstOrDefaultAsync(x => x.Mail == writer.Mail && x.Password == writer.Password);
			if (user != null)
			{
				var claims = new Claim[] { new Claim(ClaimTypes.Name,user.Mail)
				};
				var claimsIdentity = new ClaimsIdentity(claims,"a"); 
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
				await HttpContext.SignInAsync(claimsPrincipal);
				HttpContext.Session.SetString("userEmail", user.Mail);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				return View();
			}
		}
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Blog");
        }
    }
}
