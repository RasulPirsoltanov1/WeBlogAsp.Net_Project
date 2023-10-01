using BlogSite.BusinessLayer.Abstract;
using BlogSite.BusinessLayer.Concrete;
using BlogSite.BusinessLayer.Extensions;
using BlogSite.DataAccessLayer.Context;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.Controllers
{
    public class WriterController : Controller
    {
        IWriterService _writerService;
        ICountryService _countryService;

        public WriterController(IWriterService writerService, ICountryService countryService)
        {
            _writerService = writerService;
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            ViewBag.Countries = await _countryService.GetAllAsync();
            Writer? writer = await _writerService.values.FirstOrDefaultAsync(x => x.Mail == User.Identity.Name);
            return View(writer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Writer writer, IFormFile? image)
        {
            Writer? dbWriter = await _writerService.values.FirstOrDefaultAsync(x => x.Mail == User.Identity.Name);
            if (ModelState.IsValid)
            {
                dbWriter.Name = writer.Name;
                dbWriter.About = writer.About;
                dbWriter.Mail = writer.Mail;
                dbWriter.CountryId = writer.CountryId;
                dbWriter.Password = writer.Password;
                if (image != null)
                {
                    await IFormFileExtension.DeleteFileAsync(dbWriter.Image);
                    dbWriter.Image = await image.UploadFileToAsync("writers", "profilImages");
                }
                await _writerService.UpdateAsync(dbWriter);
                return RedirectToAction("Index","Dashboard");
            }
            ViewBag.Countries = await _countryService.GetAllAsync();
            return View(dbWriter);
        }
    }
}
