using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
	public class RegisterController : Controller
	{
		private IWriterService _writerService;

		public RegisterController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> IndexAsync(Writer writer)
		{
			if (ModelState.IsValid)
			{
				writer.About = "test";
				writer.Status = true;
				await _writerService.AddAsync(writer);
				return RedirectToAction("Index","Blog");
			}
			else
			{
				return View();
			}

		}
	}
}
