using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;

namespace DataAccess.Repositories
{
    public static class UserDal
    {
        public static long Login(string user, string password)
        {
            var conUsers = new conUsuarios();
            bool pChange = false;
            return conUsers.Autenticar(user, password,ref pChange);
        }
    }
}
