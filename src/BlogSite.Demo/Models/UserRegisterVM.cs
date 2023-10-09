using System.ComponentModel.DataAnnotations;

namespace BlogSite.Demo.Models
{
    public class UserRegisterVM
    {
        [Display(Name = "Name and Surname")]
        [Required]
        public string NameSurname { get; set; }
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
        [Display(Name = "ConfirmPassword")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mail")]
        [Required]
        public string Mail { get; set; }
        [Display(Name = "UserName")]
        [Required]
        public string UserName { get; set; }
    }
}
