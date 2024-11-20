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
    public class LoginAdminManager : ILoginAdminService
    {
        IAdminDal _adminDal;

        public LoginAdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin GetAdmmin(string usernama, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == usernama && x.AdminPassword == password);

        }
    }
}
