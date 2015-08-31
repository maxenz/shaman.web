using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Incident
    {
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

        public string dmLatitud { get; set; }

        public string dmLongitud { get; set; }

        public int GradoOperativoId { get; set; }

        public int ZonaGeograficaId { get; set; }

    }
}
