using BlogSite.BusinessLayer.Concrete;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BusinessLayer.Abstract
{
    public class ICategoryService : GenericService<Category>, IGenericService<Category>
    {
        public ICategoryService(ICategoryRepository repository) : base(repository)
        {
        }
    }
}
