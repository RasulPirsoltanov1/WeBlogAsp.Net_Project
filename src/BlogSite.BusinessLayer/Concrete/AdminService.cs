using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;

namespace BlogSite.BusinessLayer.Concrete
{
    public partial class AdminService : GenericService<Admin>, IAdminService
    {
        public AdminService(IAdminRepository repository) : base(repository)
        {
        }
    }

}
