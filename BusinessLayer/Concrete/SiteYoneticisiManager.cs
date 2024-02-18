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
    public class SiteYoneticisiManager:ISiteYoneticisiService
    {
        ISiteYoneticisi _siteYoneticisi;

        public SiteYoneticisiManager(ISiteYoneticisi siteYoneticisi)
        {
            _siteYoneticisi = siteYoneticisi;
        }

        public SiteYoneticisi GetById(int id)
        {
           return _siteYoneticisi.GetByID(id);
        }

        public List<SiteYoneticisi> GetList()
        {
            return _siteYoneticisi.GetListAll();
        }

        public void TAdd(SiteYoneticisi t)
        {
            _siteYoneticisi.Insert(t);
        }

        public void TDelete(SiteYoneticisi t)
        {
            _siteYoneticisi.Delete(t);
        }

        public void TUpdate(SiteYoneticisi t)
        {
            _siteYoneticisi.Update(t);
        }
    }
}
