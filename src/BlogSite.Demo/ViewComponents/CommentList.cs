using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
