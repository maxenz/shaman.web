using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shaman.ViewModels
{
    public class DispatchPopupViewModelData
    {
        public List<string> Alerts { get; set; }

        public DateTime IncidentDate { get; set; }

        public string IncidentNumber { get; set; }

        public string OperativeGrade { get; set; }

        public string OperativeGradeBackColor { get; set; }

        public string IncidentId { get; set; }

        public string Domicile { get; set; }

        public string Locality { get; set; }

        public int SelectedView { get; set; }

        public bool ViewEnabled { get; set; }

        public bool MovAptoGrado { get; set; }

        public bool MovZona { get; set; }

        public string Mobile { get; set; }

        public string MobileType { get; set; }

        public string State { get; set; }

        public DispatchPopupViewModelData()
        {
            this.ViewEnabled = true;
        }
    }
}