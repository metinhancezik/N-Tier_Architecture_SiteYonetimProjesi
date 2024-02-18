using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AidatManager : IAidatService
    {
        IAidat _aidat;
      
        public AidatManager(IAidat aidat)
        {
            _aidat = aidat;
        }

   

        public Aidat GetById(int id)
        {
          return _aidat.GetByID(id);
        }

        public List<Aidat> GetList()
        {
            return _aidat.GetListAll();
        }

        public void TAdd(Aidat t)
        {
            _aidat.Insert(t);
        }

        public void TDelete(Aidat t)
        {
            _aidat.Delete(t);
        }

        public Aidat TGetByFilter(Expression<Func<Aidat, bool>> filter)
        {
            using (var context = new Context())
            {
                return context.Aidats.SingleOrDefault(filter);
            }
        }

        public void TUpdate(Aidat t)
        {
            _aidat.Update(t);
        }
    }
}

