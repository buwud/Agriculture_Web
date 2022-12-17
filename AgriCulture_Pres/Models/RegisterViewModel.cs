using System.ComponentModel.DataAnnotations;

namespace AgriCulture_Pres.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Enter your username!")]
		[DataType(DataType.Text)]
		[StringLength(20,MinimumLength =3, ErrorMessage ="Minimum 3 and maximum 30 characters allowed!")]
		public string? userName { get; set; }

        [Required(ErrorMessage ="Enter your e-mail address!")]
		[DataType(DataType.EmailAddress)]
		[StringLength(80)]
		public string? email { get; set; }

        [Required(ErrorMessage = "Enter your password!")]
		[DataType(DataType.Password)]
		[StringLength(30,MinimumLength =6,ErrorMessage ="Minimum 6 and maximum 30 characters allowed!")]
		public string? password { get; set; }

        [Required(ErrorMessage = "Enter your password again!")]
        [Compare("password",ErrorMessage ="Passwords do not match, try again!")]
		[DataType(DataType.Password)]
		[StringLength(30, MinimumLength = 6, ErrorMessage = "Minimum 6 and maximum 30 characters allowed!")]
		public string? passwordConfirm { get; set; }
    }
}