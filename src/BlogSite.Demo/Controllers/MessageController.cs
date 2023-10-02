using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.Controllers
{
    public class MessageController : Controller
    {
        IMessage2Service _message2Service;

        public MessageController(IMessage2Service message2Service)
        {
            _message2Service = message2Service;
        }

        public async Task<IActionResult> Index()
        {
            var messsages2 = await _message2Service.values.Include(x => x.Reciever).Include(x => x.Sender).Where(x => x.Reciever.Mail == User.Identity.Name).ToListAsync();
            ViewBag.Count = messsages2.Count;
            return View(messsages2);
        }
        public async Task<IActionResult> Detail(int Id)
        {
            var messsage2 = await _message2Service.values.Include(x => x.Reciever).Include(x => x.Sender).FirstOrDefaultAsync(x => x.Reciever.Mail == User.Identity.Name&&x.Id==Id);
            return View(messsage2);
        }
    }
}
