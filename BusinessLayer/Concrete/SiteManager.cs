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
    public class SiteManager : ISiteService
    {
        ISite _site;

        public SiteManager(ISite site)
        {
             _site=site;
        }
        public Site GetById(int id)
        {
           return _site.GetByID(id);
        }

        public List<Site> GetList()
        {
            
            return _site.GetListAll();
        }

        public void TAdd(Site t)
        {
            _site.Insert(t);
        }

        public void TDelete(Site t)
        {
            _site.Delete(t);
        }

        public void TUpdate(Site t)
        {
            _site.Update(t);
        }
    }
}
