using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		private IWriterService _writerService;
		ICountryService _countryService;

		public RegisterController(IWriterService writerService, ICountryService countryService)
		{
			_writerService = writerService;
			_countryService = countryService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			ViewBag.Countries =await _countryService.GetAllAsync();
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(Writer writer)
		 {
			var existEmail = await _writerService.GetByExpressionAsync(w=>w.Mail==writer.Mail);
			if(existEmail.Count>0) {
				ModelState.AddModelError("", "this email has been used");
			}
			writer.About = "test";
			writer.Status = true;
			if (ModelState.IsValid)
			{
				await _writerService.AddAsync(writer);
				return RedirectToAction("Index","Blog");
			}
			else
			{
				ViewBag.Countries = await _countryService.GetAllAsync();
				return View();
			}
		}
	}
}
