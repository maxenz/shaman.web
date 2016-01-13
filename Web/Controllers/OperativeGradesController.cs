using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Repositories;

namespace Shaman.Controllers
{
    public class OperativeGradesController : BaseApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(OperativeGradeDal.GetAll());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
