using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace AgriCulture_Pres.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage= "Enter your username!")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Minimum 3 and maximum 30 characters allowed!")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Enter your password!")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Minimum 6 and maximum 30 characters allowed!")]
        public string? Password { get; set; }
    }
}
