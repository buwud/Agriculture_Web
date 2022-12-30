using BusinessLayer.Abstract;
using EntityLayer.Concrete;

namespace AgriCulture_Pres.Models
{
    public class AboutModel
    {
		public List<Team> teams { get; set; }
		public List<About>? abouts { get; set; }
    }
}
