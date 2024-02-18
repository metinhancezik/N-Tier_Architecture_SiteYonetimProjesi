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
    public class BlokManager : IBlokService
    {
        IBlok _blok;

    
        public BlokManager(IBlok blok)
        {
            _blok = blok;
        }

        public List<Blok> GetBlokListWithCategory(int id)
        {
            return _blok.List(x => x.SiteID == id);
        }

        public Blok GetById(int id)
        {
            return _blok.GetByID(id);
        }

        public List<Blok> GetList()
        {
            return _blok.GetListAll();
        }


        public void TAdd(Blok t)
        {
            _blok.Insert(t);
        }

        public void TDelete(Blok t)
        {
            _blok.Delete(t);
        }

        public void TUpdate(Blok t)
        {
            _blok.Update(t);

        }
    }
}
