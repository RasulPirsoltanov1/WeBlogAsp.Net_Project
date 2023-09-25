using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;

namespace BlogSite.BusinessLayer.Concrete
{
	public class AboutService : GenericService<About>, IAboutService
	{
		public AboutService(IAboutRepository repository) : base(repository)
		{
		}
	}
}
