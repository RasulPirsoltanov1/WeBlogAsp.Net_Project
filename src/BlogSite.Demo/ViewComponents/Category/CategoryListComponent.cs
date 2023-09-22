using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.ViewComponents.Category
{
    public class CategoryListComponent:ViewComponent
    {
        ICategoryService _categoryService;

        public CategoryListComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories =await _categoryService.values.Include(c=>c.Blogs).ToListAsync();
            return View(categories);
        }
    }
}
