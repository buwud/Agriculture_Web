using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public void AnnouncementStatus(int id)
        {
            using var context = new AgriCultureContext();
            Announcement a = context.Announcements.Find(id);
            if (a.Status)
                a.Status = false;
            else
                a.Status = true;
            context.SaveChanges();
        }
    }
}
