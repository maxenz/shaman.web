using ShamanExpressDLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Incident
    {
        #region Properties

        public long ID { get; set; }

        public string IncidenteId { get; set; }

        public string GradoColor { get; set; }

        public string AbreviaturaId { get; set; }

        public string NroIncidente { get; set; }

        public bool flgReclamo { get; set; }

        public string Sintomas { get; set; }

        public string DomicilioDescripcion { get; set; }

        public Domicile Domicilio { get; set; }

        public string ZonaColor { get; set; }

        public string LocalidadDescripcion { get; set; }

        public string Sexo { get; set; }

        public int Edad { get; set; }

        public string Movil { get; set; }

        public bool flgEnviado { get; set; }

        public string ErrorEnvio { get; set; }

        public string horLlamada { get; set; }

        public string Paciente { get; set; }

        public string MovilPreasignado { get; set; }

        public string Sanatorio { get; set; }

        public string ViajeId { get; set; }

        public string TpoDespacho { get; set; }

        public string TpoSalida { get; set; }

        public string TpoDesplazamiento { get; set; }

        public string TpoAtencion { get; set; }

        public string Aviso { get; set; }

        public int ZonaGeograficaId { get; set; }

        public DateTime FechaIncidente { get; set; }

        public string Telefono { get; set; }

        public string NroAfiliado { get; set; }

        public string Partido { get; set; }

        public decimal Copago { get; set; }

        public Locality Localidad { get; set; }

        public OperativeGrade GradoOperativo { get; set; }

        public long SituacionIvaId { get; set; }

        public string PlanId { get; set; }

        public Client Cliente { get; set; }

        #endregion

        #region Constructors

        public Incident(){}

        public Incident(conIncidentes objIncident)
        {   
            this.AbreviaturaId = objIncident.ID.ToString();
            this.Aviso = objIncident.Aviso;
            this.Edad = Convert.ToInt32(objIncident.Edad);
            this.GradoColor = objIncident.GradoOperativoId.ColorHexa;
            this.GradoOperativo = new OperativeGrade(objIncident.GradoOperativoId);
            this.horLlamada = objIncident.HorarioOperativo.horLlamada.ToShortTimeString();
            this.IncidenteId = objIncident.ID.ToString();
            this.NroIncidente = objIncident.NroIncidente;
            this.Paciente = objIncident.Paciente;
            this.Sexo = objIncident.Sexo;
            this.Sintomas = objIncident.Sintomas;
            this.FechaIncidente = objIncident.FecIncidente;
            this.Telefono = objIncident.Telefono;
            this.NroAfiliado = objIncident.NroAfiliado;
            this.Copago = objIncident.CoPago;
            this.PlanId = objIncident.PlanId;
            this.ID = objIncident.ID;
            

            if (objIncident.ClienteId != null)
            {
                this.SituacionIvaId = objIncident.ClienteId.SituacionIvaId.ID;
                this.Localidad = new Locality(objIncident.ClienteId.LocalidadId);
                this.Domicilio = new Domicile(objIncident.ClienteId.Domicilio);
                this.Cliente = new Client(objIncident.ClienteId);
            }
            
        }

        #endregion

    }
}
