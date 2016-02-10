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
        public string NumeroAfiliado { get; set; }
        public Clasificacion Clasificacion { get; set; }
        public DateTime FechaServicio { get; set; }
        public bool CargaHistorica { get; set; }
    }
}