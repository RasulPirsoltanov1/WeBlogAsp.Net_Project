using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
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
	}
}
