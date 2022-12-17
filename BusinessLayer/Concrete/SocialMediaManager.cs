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
	public class SocialMediaManager : ISocialMediaService
	{
		ISocialMediaDal _mediaDal;

		public SocialMediaManager(ISocialMediaDal mediaDal)
		{
			_mediaDal = mediaDal;
		}

		public void Delete(SocialMedia t)
		{
			_mediaDal.Delete(t);
		}

		public SocialMedia GetById(int id)
		{
			return _mediaDal.GetById(id);
		}

		public List<SocialMedia> GetListAll()
		{
			return _mediaDal.GetListAll();
		}

		public void Insert(SocialMedia t)
		{
			_mediaDal.Insert(t);
		}

		public void Update(SocialMedia t)
		{
			_mediaDal.Update(t);
		}
	}
}