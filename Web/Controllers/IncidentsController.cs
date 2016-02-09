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

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetAll()
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
        public IHttpActionResult GetById(string id)
        {
            try
            {
                return Ok(IncidentDal.GetById(id));
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

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetNewIncidentNumberToCreate()
        {
            try
            {
                return Ok(IncidentDal.GetNewIncidentNumberToCreate());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetFirst()
        {
            try
            {
                return Ok(IncidentDal.GetFirstIncident());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetLast()
        {
            try
            {
                return Ok(IncidentDal.GetLastIncident());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetPrevious(string id)
        {
            try
            {
                return Ok(IncidentDal.GetPreviousIncident(id));

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetNext(string id)
        {
            try
            {
                return Ok(IncidentDal.GetNextIncident(id));

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
