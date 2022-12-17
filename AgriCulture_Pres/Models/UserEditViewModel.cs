using System.ComponentModel.DataAnnotations;

namespace AgriCulture_Pres.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Enter your username")]
        public string? username { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }

        [Required(ErrorMessage = "Enter your email!")]
        public string? email { get; set; }

        public string? phoneNumber { get; set; }

        [Required(ErrorMessage = "Enter your password!")]
        public string? password { get; set; }

        [Required(ErrorMessage = "Enter your password again!")]
        [Compare("password", ErrorMessage = "Passwords do not match, try again!")]
        public string? confirmPassword { get; set; }
    }
}
