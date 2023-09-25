using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
	public class ContactController : Controller
	{
		IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(Contact contact)
		{
			contact.Status = true;
			await _contactService.AddAsync(contact);
			return RedirectToAction(nameof(Index));
		}
	}
}
