using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Demo.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values =await _categoryService.GetAllAsync();
            return View(values);
        }
    }
}
