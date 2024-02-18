﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlokService : IGenericService<Blok>
    {


        public List<Blok> GetBlokListWithCategory(int id);


    }
}
