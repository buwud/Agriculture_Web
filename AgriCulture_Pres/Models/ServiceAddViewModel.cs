using System.ComponentModel.DataAnnotations;

namespace AgriCulture_Pres.Models
{
    public class ServiceAddViewModel
    {
        [Display(Name="Title")]
        [Required(ErrorMessage ="Title cannot be empty!")]
        public string? Title { get; set; }


        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image path cannot be empty!")]
        public string? Image { get; set; }


        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description cannot be empty!")]
        public string? Description { get; set; }
    }
}