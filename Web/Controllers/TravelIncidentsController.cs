using DataAccess.Repositories;
using Domain;
using Shaman.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Shaman.ViewModels.Converters;

namespace Shaman.Controllers
{
    public class TravelIncidentsController : BaseApiController
    {
        #region Get Methods

        [HttpGet]
        [HttpOptions]
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

        #endregion

        #region Post Methods

        [HttpPost]
        public IHttpActionResult Dispatch(TravelIncidentViewModel travelIncidentViewModel)
        {
            try
            {
                TravelIncident ti = TravelIncidentVMToTravelIncidentConverter.Convert(travelIncidentViewModel);
                DatabaseValidationResult result = TravelIncidentDal.Dispatch(ti);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion

    }
}
