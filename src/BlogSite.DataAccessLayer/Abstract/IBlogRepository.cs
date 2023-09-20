using BlogSite.EntityLayer.Concrete;

namespace BlogSite.DataAccessLayer.Abstract
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<List<Blog>> GetListWithCategoryAsync();
    }

}
