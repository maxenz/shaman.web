using DataAccess;
using DataAccess.Repositories;
using Domain;
using Shaman.ViewModels;
using System;
using System.Web.Http;

namespace Shaman.Controllers
{
    public class IncidentsController : BaseApiController
    {
        #region Get Methods

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

        #endregion

        #region Post Methods

        [HttpPost]
        public IHttpActionResult SaveIncident(IncidentViewModel incViewModel)
        {
            try
            {
                Incident incident = incViewModel.ConvertViewModelToIncident();

                incident.Cliente = ClientDal.GetIdByAbreviaturaId(incViewModel.Client);
                incident.Localidad = LocalityDal.GetIdByAbreviaturaId(incViewModel.LocAbreviature);

                DatabaseValidationResult validationResult = IncidentDal.SaveIncident(incident);
                return Ok(validationResult);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion

    }
}
