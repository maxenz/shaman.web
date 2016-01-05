using DataAccess.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Shaman.Controllers
{
    public class MobilesController : BaseApiController
    {

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(MobileDal.GetAll());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
