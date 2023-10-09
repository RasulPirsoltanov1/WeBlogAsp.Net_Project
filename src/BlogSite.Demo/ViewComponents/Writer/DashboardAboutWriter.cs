using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.ViewComponents.Writer
{
    public class DashboardAboutWriter:ViewComponent
    {
        IWriterService _writerService;
        UserManager<AppUser> _userManager;

        public DashboardAboutWriter(IWriterService writerService, UserManager<AppUser> userManager)
        {
            _writerService = writerService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var writer = (await _writerService.values.Include(x=>x.Country).Where(x=>x.Mail==User.Identity.Name).ToListAsync())[0];
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
    }
}
