using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace BlogSite.Demo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        IMessage2Service _message2Service;

        public WriterMessageNotification(IMessage2Service message2Service)
        {
            _message2Service = message2Service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var messsages2 =await _message2Service.values.Include(x=>x.Reciever).Include(x=>x.Sender).Where(x=>x.Reciever.Mail== User.Identity.Name).ToListAsync();
            ViewBag.Count=messsages2.Count;
            return View(messsages2);
        }
    }
}
