using System.ComponentModel.DataAnnotations;

namespace BlogSite.Demo.Models
{
    public class UserLoginVM
    {
        [Display(Name = "UserName")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
    }
}
