using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;

namespace BlogSite.BusinessLayer.Concrete
{
    public class NewsLetterService : GenericService<NewsLetter>, INewsLetterService
    {
        public NewsLetterService(INewsLetterRepository repository) : base(repository)
        {
        }
    }
}
