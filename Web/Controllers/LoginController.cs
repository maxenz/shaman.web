using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Data;
using DataAccess.Repositories;

namespace Shaman.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpPost]
        public HttpResponseMessage Authenticate()
        {
            string user = Request.Form["user"];
            string password = Request.Form["password"];
            if (UserDal.Login(user, password) > 0)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

        }


	}
}