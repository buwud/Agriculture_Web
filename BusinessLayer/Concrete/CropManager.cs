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
    public class CropManager : ICropService
    {
        private readonly ICropDal _cropDal;

        public CropManager(ICropDal cropDal)
        {
            _cropDal = cropDal;
        }

        public void Delete(Crop t)
        {
            _cropDal.Delete(t);
        }

        public Crop GetById(int id)
        {
            return _cropDal.GetById(id);
        }

        public List<Crop> GetListAll()
        {
            return _cropDal.GetListAll();
        }

        public void Insert(Crop t)
        {
            _cropDal.Insert(t);
        }

        public void Update(Crop t)
        {
            _cropDal.Update(t);
        }
    }
}
