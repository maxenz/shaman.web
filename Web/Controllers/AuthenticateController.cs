using DataAccess.Repositories;
using Shaman.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shaman.Controllers
{
    public class AuthenticateController : BaseApiController
    {
        // POST api/<controller>
        public IHttpActionResult Post(UserViewModel user)
        {
            try
            {
                if (UserDal.Login(user.Username, user.Password) > 0)
                {
                    return Ok(user);
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}