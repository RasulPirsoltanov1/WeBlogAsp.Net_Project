using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.EntityLayer.Concrete
{
    public class Notification:BaseEntity
    {
        public string Type { get; set; }
        public string Symbol { get; set; }
        public string Detalis { get; set; }
    }
}
