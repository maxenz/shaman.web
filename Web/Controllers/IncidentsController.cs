using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shaman.Controllers
{
    public class IncidentsController : BaseApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(IncidentDal.GetAll());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
