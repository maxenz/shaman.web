using ShamanExpressDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TravelIncident
    {
        #region Properties

        public long Demora { get; set; }
        public string Diagnostico { get; set; }
        public string DiagnosticoId { get; set; }
        public string Depto { get; set; }
        public string MotivoNoRealizacionId { get; set; }
        public string BaseOperativa { get; set; }
        public string BaseOperativaId { get; set; }
        public long MovilId { get; set; }
        public string MotivoNoRealizacion { get; set; }
        public long TipoMovilId { get; set; }
        public string TipoMovil { get; set; }
        public long MovilPreasignadoId { get; set; }
        public string AbreviaturaId { get; set; }
        public string GradoOperativoId { get; set; }
        public string GradoColor { get; set; }
        public long Altura { get; set; }
        public string Calle { get; set; }
        public string EntreCalle1 { get; set; }
        public string EntreCalle2 { get; set; }
        public string Piso { get; set; }
        public string Domicilio { get; set; }
        public int MovilActivo { get; set; }
        public string Movil { get; set; }
        public string MovilPreasignado { get; set; }
        public string dmReferencia { get; set; }
        public decimal dmLongitud { get; set; }
        public decimal dmLatitud { get; set; }
        public int flgStatus { get; set; }
        public int flgModoDespacho { get; set; }
        public DateTime HoraSolDerivacion { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime HoraLlegada { get; set; }
        public DateTime HoraLlamada { get; set; }
        public DateTime HoraInternacion { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinalizacion { get; set; }
        public DateTime HoraDespacho { get; set; }
        public DateTime HoraDerivacion { get; set; }
        public string LocalidadId { get; set; }
        public DateTime FechaIncidente { get; set; }
        public string NroIncidente { get; set; }
        public string IncidenteId { get; set; }
        public int ViewType { get; set; }
        public string Estado { get; set; }
        public bool MovAptoGrado { get; set; }
        public bool MovZona { get; set; }

        public long Id { get; set; }

        #endregion

        #region Constructors

        public TravelIncident(){}

        public TravelIncident(conIncidentesViajes objIncidentViajes)
        {
            
            this.AbreviaturaId = objIncidentViajes.ID.ToString();
            this.Demora = objIncidentViajes.Demora;
            this.Diagnostico = objIncidentViajes.DiagnosticoId.Descripcion;
            this.DiagnosticoId = objIncidentViajes.DiagnosticoId.AbreviaturaId;
            this.GradoColor= objIncidentViajes.DiagnosticoId.GradoOperativoId.ColorHexa;
            this.flgModoDespacho = objIncidentViajes.flgModoDespacho;
            this.flgStatus = objIncidentViajes.flgStatus;
            this.HoraDerivacion = objIncidentViajes.HorarioOperativo.horDerivacion;
            this.HoraDespacho = objIncidentViajes.HorarioOperativo.horDespacho;
            this.HoraFinalizacion = objIncidentViajes.HorarioOperativo.horFinalizacion;
            this.HoraInicial = objIncidentViajes.HorarioOperativo.horInicial;
            this.HoraInternacion = objIncidentViajes.HorarioOperativo.horInternacion;
            this.HoraLlamada = objIncidentViajes.HorarioOperativo.horLlamada;
            this.HoraLlegada = objIncidentViajes.HorarioOperativo.horLlegada;
            this.HoraSalida = objIncidentViajes.HorarioOperativo.horSalida;
            this.HoraSolDerivacion = objIncidentViajes.HorarioOperativo.horSolDerivacion;
            this.Altura = objIncidentViajes.IncidenteDomicilioId.Domicilio.dmAltura;
            this.Calle = objIncidentViajes.IncidenteDomicilioId.Domicilio.dmCalle;
            this.Depto = objIncidentViajes.IncidenteDomicilioId.Domicilio.dmDepto;
            this.LocalidadId = objIncidentViajes.IncidenteDomicilioId.LocalidadId.AbreviaturaId;
            this.EntreCalle1 = objIncidentViajes.IncidenteDomicilioId.Domicilio.dmEntreCalle1;
            this.EntreCalle2 = objIncidentViajes.IncidenteDomicilioId.Domicilio.dmEntreCalle2;
            this.dmLatitud = objIncidentViajes.IncidenteDomicilioId.Domicilio.dmLatitud;
            this.dmLongitud = objIncidentViajes.IncidenteDomicilioId.Domicilio.dmLongitud;
            this.Piso = objIncidentViajes.IncidenteDomicilioId.Domicilio.dmPiso;
            this.dmReferencia = objIncidentViajes.IncidenteDomicilioId.Domicilio.dmReferencia;
            this.FechaIncidente = objIncidentViajes.IncidenteDomicilioId.IncidenteId.FecIncidente;
            this.NroIncidente = objIncidentViajes.IncidenteDomicilioId.IncidenteId.NroIncidente;
            this.GradoOperativoId = objIncidentViajes.IncidenteDomicilioId.IncidenteId.GradoOperativoId.AbreviaturaId;
            this.Domicilio = objIncidentViajes.IncidenteDomicilioId.Domicilio.Domicilio;
            this.MotivoNoRealizacionId = objIncidentViajes.MotivoNoRealizacionId.AbreviaturaId;
            this.MotivoNoRealizacion = objIncidentViajes.MotivoNoRealizacionId.Descripcion;
            this.MovilActivo = objIncidentViajes.MovilId.Activo;
            this.BaseOperativaId = objIncidentViajes.MovilId.BaseOperativaId.AbreviaturaId;
            this.BaseOperativa = objIncidentViajes.MovilId.BaseOperativaId.Descripcion;
            this.MovilId = objIncidentViajes.MovilId.ID;
            this.Movil = objIncidentViajes.MovilId.Movil;
            this.TipoMovilId = objIncidentViajes.MovilId.TipoMovilId.ID;
            this.TipoMovil = objIncidentViajes.MovilId.TipoMovilId.Descripcion;
            this.MovilPreasignadoId = objIncidentViajes.MovilPreasignadoId.ID;
            this.MovilPreasignado = objIncidentViajes.MovilPreasignadoId.Movil;
        }

        #endregion

    }
}
