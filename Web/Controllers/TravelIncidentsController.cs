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
        public IHttpActionResult GetDespachoPopupInformation(int id, int psel, string grade, string loc)
        {
            try
            {
                Locality locality = LocalityDal.GetIdByAbreviaturaId(loc);
                TravelIncident travelIncident = TravelIncidentDal.GetDespachoPopupInformation(id);
                OperativeGrade operativeGrade = OperativeGradeDal.GetByAbreviaturaId(grade);
                List<Suggestion> sugerencias = MobileDal.GetSugerencias(psel, operativeGrade.Id, locality.ID);

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
