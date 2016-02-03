using DataAccess;
using DataAccess.Repositories;
using Domain;
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

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetByPhone(string phone)
        {
            try
            {
                Incident incident = IncidentDal.GetByPhone(phone);
                if (incident == null)
                {
                    ClientMember clientMember = ClientDal.GetByPhone(phone);
                    if (clientMember == null)
                    {
                        return Ok();
                    }
                    return Ok(clientMember);
                }

                return Ok(incident);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
}
