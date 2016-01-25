using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shaman.ViewModels
{
    public class DespachoInformationViewModel
    {
        public TravelIncident IncidentInfo { get; set; }
        public List<Suggestion> Sugerencias { get; set; }

    }
}