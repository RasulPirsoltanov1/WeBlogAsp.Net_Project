using BlogSite.BusinessLayer.Abstract;
using BlogSite.Demo.Areas.Admin.Models;
using BlogSite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.Areas.Admin.Controllers
{

    [Area("admin")]
    [Route("[area]/[controller]/[action]")]

    public class ChartController : Controller
    {
        ICategoryService _categoryService;

        public ChartController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public List<CategoryModel> CategoryChart()
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            categories.Add(new CategoryModel
            {
                Count = 1,
                Name = "Technology"
            });
            categories.Add(new CategoryModel
            {
                Count = 23,
                Name = "Sport"
            });
            categories.Add(new CategoryModel
            {
                Count = 1,
                Name = "Science"
            });
            return categories;
        }
        public async Task<object> DynamicCategoryChart()
        {
            var categories = await _categoryService.values.Include(x=>x.Blogs).Select(x=>new {
                Name=x.Name,
                Count=x.Blogs.Count
            }).ToListAsync();
            return categories;
        }
    }
}
