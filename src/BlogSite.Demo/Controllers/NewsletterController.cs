using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    public class NewsletterController : Controller
    {
        INewsLetterService _newsLetterService;

        public NewsletterController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SubscribeMail(string Mail, int Id)
        {
            var existMail =await _newsLetterService.GetByExpressionAsync(x => x.Mail == Mail);
            if (existMail == null)
            {
                NewsLetter newsLetter = new NewsLetter()
                {
                    Mail = Mail,
                    Status = true
                };
                await _newsLetterService.AddAsync(newsLetter);
                if (Id != null && Id!=0)
                {
                    return RedirectToAction("Detail", "Blog", new { Id = Id });
                }
                else
                {
                    return RedirectToAction("Index", "About");
                }
            }
            if (Id != null && Id != 0)
            {
                return RedirectToAction("Detail", "Blog", new { Id = Id });
            }
            else
            {
                return RedirectToAction("Index", "About");
            }
        }
    }
}
