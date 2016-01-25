using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Suggestion
    {
        public int ID { get; set; }
        public string Movil { get; set; }
        public string TipoMovil { get; set; }
        public string Estado { get; set; }
        public int Sel { get; set; }
        public string FechaHoraTransmision { get; set; }
        public int Latitud { get; set; }
        public int Longitud { get; set; }
        public int Distancia { get; set; }
        public int Tiempo { get; set; }
        public string DistanciaTiempo { get; set; }
        public string Link { get; set; }
    }
}
