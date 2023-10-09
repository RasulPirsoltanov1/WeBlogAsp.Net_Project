using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.ViewComponents.Writer
{
    public class WriterNameAndImage : ViewComponent
    {
        IWriterService _writerService;
        UserManager<AppUser> _userManager;
        public WriterNameAndImage(IWriterService writerService, UserManager<AppUser> userManager)
        {
            _writerService = writerService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User?.Identity?.Name != null)
            {
                var user = await _userManager.FindByNameAsync(User?.Identity?.Name);

                return View(user);
            }
            return View(null);
        }
    }
}
