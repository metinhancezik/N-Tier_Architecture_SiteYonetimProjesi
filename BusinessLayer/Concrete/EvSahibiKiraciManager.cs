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
    public class EvSahibiKiraciManager : IEvSahibiKiraciService
    {
        IEvSahibiKiraci _evSahibi;

        public EvSahibiKiraciManager(IEvSahibiKiraci evSahibi)
        {
            _evSahibi = evSahibi;
        }

        public EntityLayer.Concrete.EvSahibiKiraci GetById(int id)
        {
            return _evSahibi.GetByID(id);
        }

        public List<EntityLayer.Concrete.EvSahibiKiraci> GetList()
        {
            return _evSahibi.GetListAll();
        }

        public void TAdd(EntityLayer.Concrete.EvSahibiKiraci t)
        {
            _evSahibi.Insert(t);
        }

        public void TDelete(EntityLayer.Concrete.EvSahibiKiraci t)
        {
            _evSahibi.Delete(t);
        }

        public void TUpdate(EntityLayer.Concrete.EvSahibiKiraci t)
        {
            _evSahibi.Update(t);
        }
    }
}
