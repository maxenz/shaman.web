using Domain;
using Shaman.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shaman.ViewModels
{
    public class IncidentViewModel
    {
        public string Advertise { get; set; }
        public string AffiliateNumber { get; set; }
        public string Client { get; set; }
        public long Id { get; set; }
        public DateTime IncDate { get; set; }
        public string LocAbreviature { get; set; }
        public string Number { get; set; }
        public string Partido { get; set; }
        public string Patient { get; set; }
        public string PhoneNumber { get; set; }
        public string Symptoms { get; set; }
        public DomicileViewModel Domicile { get; set; }
        public IvaViewModel IvaSituationSelected { get; set; }
        public OperativeGradeViewModel OperativeGradeSelected { get; set; }
        public SexViewModel SexSelected { get; set; }

        public Incident ConvertViewModelToIncident()
        {
            Incident incident = new Incident();
            incident.FechaIncidente = this.IncDate;
            incident.NroIncidente = this.Number;
            incident.NroAfiliado = this.AffiliateNumber;      
            incident.GradoOperativo = new OperativeGrade();
            incident.GradoOperativo.Id = this.OperativeGradeSelected.Id;
            incident.Domicilio = this.Domicile.ConvertViewModelToDomicile();         
            incident.Paciente = this.Patient;

            return incident;
        }
    }
}