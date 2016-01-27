using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shaman.Controllers
{
    public class LocalitiesController : BaseApiController
    {
        public IHttpActionResult GetLocalityByAbreviaturaId(string locAbreviaturaId)
        {
            try
            {
                return Ok(LocalityDal.GetIdByAbreviaturaId(locAbreviaturaId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
