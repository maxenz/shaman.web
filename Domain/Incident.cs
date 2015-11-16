using ShamanExpressDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Incident
    {
        #region Properties

        public int ID { get; set; }

        public string IncidenteId { get; set; }

        public string GradoColor { get; set; }

        public string AbreviaturaId { get; set; }

        public string Cliente { get; set; }

        public string NroIncidente { get; set; }

        public bool flgReclamo { get; set; }

        public string Sintomas { get; set; }

        public string Domicilio { get; set; }

        public string ZonaColor { get; set; }

        public string Localidad { get; set; }

        public string LocalidadDescripcion { get; set; }

        public string Sexo { get; set; }

        public int Edad { get; set; }

        public string Movil { get; set; }

        public bool flgEnviado { get; set; }

        public string ErrorEnvio { get; set; }

        public string horLlamada { get; set; }

        public string Paciente { get; set; }

        public string dmReferencia { get; set; }

        public string MovilPreasignado { get; set; }

        public string Sanatorio { get; set; }

        public string ViajeId { get; set; }

        public string TpoDespacho { get; set; }

        public string TpoSalida { get; set; }

        public string TpoDesplazamiento { get; set; }

        public string TpoAtencion { get; set; }

        public string Aviso { get; set; }

        public decimal dmLatitud { get; set; }

        public decimal dmLongitud { get; set; }

        public string GradoOperativoId { get; set; }

        public int ZonaGeograficaId { get; set; }

        public DateTime FechaIncidente { get; set; }

        public string Telefono { get; set; }

        public string NroAfiliado { get; set; }

        public string Partido { get; set; }

        public string Calle { get; set; }

        public long Altura { get; set; }

        public string Piso { get; set; }

        public string Departamento { get; set; }

        public string EntreCalle1 { get; set; }

        public string EntreCalle2 { get; set; }

        public decimal Copago { get; set; }

        public string SexoEdad
        {
            get
            {
                return String.Format("{0}{1}", this.Sexo, this.Edad);
            }
        }

        #endregion

        #region Constructors

        public Incident(){}

        public Incident(conIncidentes objIncident)
        {
            
            this.AbreviaturaId = objIncident.ID.ToString();
            this.Aviso = objIncident.Aviso;
            this.Cliente = objIncident.ClienteId.RazonSocial;
            this.dmLatitud = objIncident.ClienteId.Domicilio.dmLatitud;
            this.dmLongitud = objIncident.ClienteId.Domicilio.dmLongitud;
            this.dmReferencia = objIncident.ClienteId.Domicilio.dmReferencia;
            this.Domicilio = objIncident.ClienteId.Domicilio.Domicilio;
            this.Edad = Convert.ToInt32(objIncident.Edad);
            this.GradoColor = objIncident.GradoOperativoId.ColorHexa;
            this.GradoOperativoId = objIncident.GradoOperativoId.AbreviaturaId;
            this.horLlamada = objIncident.HorarioOperativo.horLlamada.ToShortTimeString();
            this.IncidenteId = objIncident.ID.ToString();
            this.Localidad = objIncident.ClienteId.LocalidadId.AbreviaturaId;
            this.NroIncidente = objIncident.NroIncidente;
            this.Paciente = objIncident.Paciente;
            this.Sexo = objIncident.Sexo;
            this.Sintomas = objIncident.Sintomas;
            this.FechaIncidente = objIncident.FecIncidente;
            this.Telefono = objIncident.Telefono;
            this.NroAfiliado = objIncident.NroAfiliado;
            this.LocalidadDescripcion =  objIncident.ClienteId.LocalidadId.Descripcion;
            this.Partido = objIncident.ClienteId.LocalidadId.PartidoId.Descripcion;
            this.Calle = objIncident.ClienteId.Domicilio.dmCalle;
            this.Altura = objIncident.ClienteId.Domicilio.dmAltura;
            this.Piso = objIncident.ClienteId.Domicilio.dmPiso;
            this.Departamento = objIncident.ClienteId.Domicilio.dmDepto;
            this.EntreCalle1 = objIncident.ClienteId.Domicilio.dmEntreCalle1;
            this.EntreCalle2 = objIncident.ClienteId.Domicilio.dmEntreCalle2;
            this.Copago = objIncident.CoPago;

        }

        #endregion

    }
}
