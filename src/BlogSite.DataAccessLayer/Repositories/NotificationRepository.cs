using BlogSite.DataAccessLayer.Abstract;
using BlogSite.DataAccessLayer.Context;
using BlogSite.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccessLayer.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
