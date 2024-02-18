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
    public class UserManager : IUserService
    {
        IUser _user;

        public UserManager(IUser user)
        {
            _user = user;
        }

        public User GetById(int id)
        {
            return _user.GetByID(id);
        }

        public List<User> GetUserWithCategory(int id)
        {
            return _user.List(x => x.YoneticiID == id);
        }

        public List<User> GetList()
        {
           return _user.GetListAll();
        }

        public void TAdd(User t)
        {
            _user.Insert(t);
        }

        public void TDelete(User t)
        {
            _user.Delete(t);
        }

        public void TUpdate(User t)
        {
            _user.Update(t);
        }
    }
}
