using BlogSite.BusinessLayer.Abstract;
using BlogSite.BusinessLayer.Concrete;
using BlogSite.BusinessLayer.Extensions;
using BlogSite.DataAccessLayer.Context;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.Controllers
{
    public class WriterController : Controller
    {
        IWriterService _writerService;
        ICountryService _countryService;
        UserManager<AppUser> _userManager;
        AppDbContext _appDbContext;

        public WriterController(IWriterService writerService, ICountryService countryService, UserManager<AppUser> userManager, AppDbContext appDbContext)
        {
            _writerService = writerService;
            _countryService = countryService;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            ViewBag.Countries = await _countryService.GetAllAsync();
            AppUser? writer = await _userManager.FindByNameAsync(User?.Identity?.Name);
            return View(writer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AppUser appUser, IFormFile? image, string password, string currentPassword)
        {
            var dbUser = await _userManager.FindByNameAsync(User?.Identity?.Name);

            if (dbUser != null)
            {
                dbUser.Email = appUser.Email;
                dbUser.UserName = appUser.UserName??"User1";
                dbUser.NameSurname = appUser.NameSurname??"User1";
                dbUser.About = appUser.About;
                dbUser.CountryId = appUser.CountryId;
                if (image != null)
                {
                    await IFormFileExtension.DeleteFileAsync(dbUser?.Image);
                    dbUser.Image = await image.UploadFileToAsync("uploads", "writers");
                }
                if (password != null && currentPassword != null)
                {
                    var result = await _userManager.ChangePasswordAsync(dbUser, currentPassword, password);
                    if (!result.Succeeded)
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                await _userManager.UpdateAsync(dbUser);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.Countries = await _countryService.GetAllAsync();
            return View(dbUser);
        }
    }
}


//Writer? dbWriter = await _writerService.values.FirstOrDefaultAsync(x => x.Mail == User.Identity.Name);
//if (ModelState.IsValid)
//{
//    dbWriter.Name = writer.Name;
//    dbWriter.About = writer.About;
//    dbWriter.Mail = writer.Mail;
//    dbWriter.CountryId = writer.CountryId;
//    dbWriter.Password = writer.Password;
//    if (image != null)
//    {
//        await IFormFileExtension.DeleteFileAsync(dbWriter.Image);
//    }
//    await _writerService.UpdateAsync(dbWriter);
//    return RedirectToAction("Index","Dashboard");
//}
//ViewBag.Countries = await _countryService.GetAllAsync();
//return View(dbWriter);