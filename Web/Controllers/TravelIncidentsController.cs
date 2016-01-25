using DataAccess;
using DataAccess.Repositories;
using Domain;
using Shaman.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shaman.Controllers
{
    public class TravelIncidentsController : BaseApiController
    {

        public IHttpActionResult GetDespachoPopupInformation(int id, int psel)
        {
            try
            {
                TravelIncident travelIncident = TravelIncidentDal.GetDespachoPopupInformation(id);
                List<Suggestion> sugerencias = MobileDal.GetSugerencias(psel, 0, 0);//en funcion de un combo

                DespachoInformationViewModel viewModel = new DespachoInformationViewModel();
                viewModel.IncidentInfo = travelIncident;
                viewModel.Sugerencias = sugerencias;
                if (travelIncident == null && sugerencias == null)
                {
                    return Ok();
                }

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
