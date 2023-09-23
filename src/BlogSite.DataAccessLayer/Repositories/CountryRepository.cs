using BlogSite.DataAccessLayer.Abstract;
using BlogSite.DataAccessLayer.Context;
using BlogSite.EntityLayer.Concrete;

namespace BlogSite.DataAccessLayer.Repositories
{
	public class CountryRepository : GenericRepository<Country>, ICountryRepository
	{
		public CountryRepository(AppDbContext appDbContext) : base(appDbContext)
		{
		}
	}
}
