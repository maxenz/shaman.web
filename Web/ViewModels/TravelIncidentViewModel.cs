using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shaman.ViewModels
{
    public class TravelIncidentViewModel
    {
        public string IncidentId { get; set; }

        public int SelectedView { get; set; }

        public bool MovAptoGrado { get; set; }

        public bool MovZona { get; set; }

        public string Mobile { get; set; }

        public string MobileType { get; set; }

        public string State { get; set; }
    }
}