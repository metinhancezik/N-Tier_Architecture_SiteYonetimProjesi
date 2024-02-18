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
    public class GiderManager : IGiderService
    {
        IGider _gider;

        public GiderManager(IGider gider)
        {
            _gider = gider;
        }

        public Gider GetById(int id)
        {
            return _gider.GetByID(id);
        }

        public List<Gider> GetList()
        {
            return _gider.GetListAll();
        }

        public void TAdd(Gider t)
        {
            _gider.Insert(t);
        }

        public void TDelete(Gider t)
        {
            _gider.Delete(t);
        }

        public void TUpdate(Gider t)
        {
            _gider.Update(t);
        }
    }
}
