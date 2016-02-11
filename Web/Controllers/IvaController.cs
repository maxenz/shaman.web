using System;
using System.Web.Http;
using DataAccess.Repositories;

namespace Shaman.Controllers
{
    public class IvaController : BaseApiController
    {
        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetSituations()
        {
            try
            {
                
                return Ok(IvaDal.GetAllSituations());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
