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

        public long Demora { get; private set; }
        public string Diagnostico { get; private set; }
        public string DiagnosticoId { get; private set; }
        public string Depto { get; private set; }
        public string MotivoNoRealizacionId { get; private set; }
        public string BaseOperativa { get; private set; }
        public string BaseOperativaId { get; private set; }
        public long MovilId { get; private set; }
        public string MotivoNoRealizacion { get; private set; }
        public long TipoMovilId { get; private set; }
        public string TipoMovil { get; private set; }
        public long MovilPreasignadoId { get; private set; }
        public string AbreviaturaId { get; private set; }
        public string GradoOperativoId { get; private set; }
        public string GradoColor { get; private set; }
        public long Altura { get; private set; }
        public string Calle { get; private set; }
        public string EntreCalle1 { get; private set; }
        public string EntreCalle2 { get; private set; }
        public string Piso { get; private set; }
        public string Domicilio { get; private set; }
        public int MovilActivo { get; private set; }
        public string Movil { get; private set; }
        public string MovilPreasignado { get; private set; }
        public string dmReferencia { get; private set; }
        public decimal dmLongitud { get; private set; }
        public decimal dmLatitud { get; private set; }
        public int flgStatus { get; private set; }
        public int flgModoDespacho { get; private set; }
        public DateTime HoraSolDerivacion { get; private set; }
        public DateTime HoraSalida { get; private set; }
        public DateTime HoraLlegada { get; private set; }
        public DateTime HoraLlamada { get; private set; }
        public DateTime HoraInternacion { get; private set; }
        public DateTime HoraInicial { get; private set; }
        public DateTime HoraFinalizacion { get; private set; }
        public DateTime HoraDespacho { get; private set; }
        public DateTime HoraDerivacion { get; private set; }
        public string LocalidadId { get; private set; }
        public DateTime FechaIncidente { get; private set; }
        public string NroIncidente { get; private set; }

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
