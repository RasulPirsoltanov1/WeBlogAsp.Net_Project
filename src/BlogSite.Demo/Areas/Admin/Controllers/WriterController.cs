using BlogSite.BusinessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace BlogSite.Demo.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class WriterController : Controller
    {
        IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> WriterList()
        {
            var writers = await _writerService.GetAllAsync();
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(new
            {
                jsonWriters = jsonWriters
            });
        }
        public async Task<Writer> WriterGetById(int id)
        {
            var writer = await _writerService.GetByIdAsync(id);
            return writer;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Writer writer)
        {
            if (ModelState.IsValid)
            {
                await _writerService.AddAsync(writer);
                return Ok();
            }
            else
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return Json(errors);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _writerService.DeleteAsync(id);
            return Ok();
        }
    }
}
