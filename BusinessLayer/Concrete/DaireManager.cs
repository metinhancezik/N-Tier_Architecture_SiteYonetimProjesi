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
    public class DaireManager : IDaireService
    {
        IDaire _daire;
       
        public DaireManager(IDaire daire)
        {
            _daire = daire;
        }

        public Daire GetById(int id)
        {
            return _daire.GetByID(id);
        }

        public List<Daire> GetDaireListWithCategory(int id)
        {
            return _daire.List(x=>x.BlokID==id);
        }

        public List<Daire> GetList()
        {
           return _daire.GetListAll();
        }

        public void TAdd(Daire t)
        {
            _daire.Insert(t);
        }

        public void TDelete(Daire t)
        {
            _daire.Delete(t);
        }

        public void TUpdate(Daire t)
        {
            _daire.Update(t);
        }
    }
}
