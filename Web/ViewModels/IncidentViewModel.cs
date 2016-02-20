using Shaman.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shaman.ViewModels
{
    public class IncidentViewModel
    {
        public long CodigoCliente { get; set; }
        public Clasificacion Clasificacion { get; set; }
        public DateTime FechaServicio { get; set; }
        public bool CargaHistorica { get; set; }
        public long ID { get; set; }
        public string IncidenteId { get; set; }
        public string GradoColor { get; set; }
        public string NroIncidente { get; set; }
        public string Sintomas { get; set; }
        public string DomicilioDescripcion { get; set; }
        public string LocalidadDescripcion { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Movil { get; set; }
        public string ErrorEnvio { get; set; }
        public string horLlamada { get; set; }
        public string Paciente { get; set; }
        public string MovilPreasignado { get; set; }
        public string Sanatorio { get; set; }
        public string TpoDespacho { get; set; }
        public string TpoSalida { get; set; }
        public string TpoDesplazamiento { get; set; }
        public string TpoAtencion { get; set; }
        public string Aviso { get; set; }
        public DateTime FechaIncidente { get; set; }
        public string Telefono { get; set; }
        public string NroAfiliado { get; set; }
        public string Partido { get; set; }
        public decimal Copago { get; set; }
        public int GradoOperativoId { get; set; }
        public int LocalidadId { get; set; }
        public string DomicilioDestino { get; set; }
        public string LocalidadDestino { get; set; }
        public int TipoMorosidad { get; set; }
        public int SinCobertura { get; set; }

        public string PhoneNumber { get; set; }

    }
}