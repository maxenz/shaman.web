using DataAccess;
using DataAccess.Repositories;
using System;
using System.Web.Http;

namespace Shaman.Controllers
{
    public class SymptomsController : BaseApiController
    {
        [HttpGet]
        [HttpOptions]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(SymptomDal.GetAll());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
