using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string? NameSurname{ get; set; }
        public string? About { get; set; }
        public string? Image { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public virtual ICollection<Message2>? SendMessages { get; set; }
        public virtual ICollection<Message2>? RecieveMessages { get; set; }
    }
}
