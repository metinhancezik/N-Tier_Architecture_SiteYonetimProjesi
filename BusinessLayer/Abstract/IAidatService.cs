using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAidatService : IGenericService<Aidat>
    {
        public Aidat TGetByFilter(Expression<Func<Aidat, bool>> filter);
    }
}
