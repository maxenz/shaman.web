using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shaman.ViewModels.Converters
{
    public static class TravelIncidentVMToTravelIncidentConverter
    {
        public static TravelIncident Convert(TravelIncidentViewModel travelIncidentViewModel)
        {
            TravelIncident ti = new TravelIncident();
            ti.Movil = travelIncidentViewModel.Mobile;
            ti.TipoMovil = travelIncidentViewModel.MobileType;
            ti.IncidenteId = travelIncidentViewModel.IncidentId;
            ti.ViewType = travelIncidentViewModel.SelectedView;
            ti.Estado = travelIncidentViewModel.State;
            ti.MovAptoGrado = travelIncidentViewModel.MovAptoGrado;
            ti.MovZona = travelIncidentViewModel.MovZona;
            ti.Id = travelIncidentViewModel.Id;
            return ti;
        }
    }
}