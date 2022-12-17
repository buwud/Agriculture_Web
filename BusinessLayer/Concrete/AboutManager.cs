using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AboutManager : IAboutService
	{
		private readonly IAboutDal _aboutDal;

		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public void Delete(About t)
		{
			_aboutDal.Delete(t);
		}

		public About GetById(int id)
		{
			return _aboutDal.GetById(id);
		}

		public List<About> GetListAll()
		{
			return _aboutDal.GetListAll();
		}

		public void Insert(About t)
		{
			_aboutDal.Insert(t);
		}

		public void Update(About t)
		{
			_aboutDal.Update(t);
		}
	}
}
