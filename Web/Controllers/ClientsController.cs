using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shaman.Controllers
{
    public class ClientsController : BaseApiController
    {
        public IHttpActionResult GetPlans(long clientId)
        {
            try
            {
                return Ok(ClientDal.GetAllPlansByClient(clientId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult GetClientWithValidation(string client)
        {
            try
            {
                return Ok(ClientDal.GetIdByAbreviaturaId(client));

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult GetAffiliateWithValidation(string clientAbreviaturaId, string affiliateNumber)
        {
            try
            {
                return Ok(ClientDal.GetIdByNroAfiliado(clientAbreviaturaId, affiliateNumber));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
