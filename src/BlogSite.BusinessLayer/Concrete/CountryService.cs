using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;

namespace BlogSite.BusinessLayer.Concrete
{
	public class CountryService : GenericService<Country>, ICountryService
	{
		public CountryService(ICountryRepository repository) : base(repository)
		{
		}
	}
}
