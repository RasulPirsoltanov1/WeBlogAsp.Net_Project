using BlogSite.BusinessLayer.Abstract;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Demo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]

    public class BlogController : Controller
    {
        IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> ExportBlogList()
        {
            var blogs =await _blogService.values.Include(x=>x.Category).ToListAsync();
            using (var workBook=new XLWorkbook())
            {
                var count = 1;
                var workSheet = workBook.Worksheets.Add("Blog List");
                workSheet.Cell(1, 1).Value = "Id";
                workSheet.Cell(1, 2).Value = "Title";
                workSheet.Cell(1, 3).Value = "Category";
                foreach (var item in blogs)
                {
                    count++;
                    workSheet.Cell(count,1).Value=item.Id;
                    workSheet.Cell(count,2).Value=item.Title;
                    workSheet.Cell(count,3).Value=item.Category?.Name;
                }
                var stream = new MemoryStream();
                workBook.SaveAs(stream);
                stream.Seek(0, SeekOrigin.Begin);

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "blog_list.xlsx");
            }
        }
    }
}
