using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;

namespace Domain
{
    public class IvaSituation
    {
        public long ID { get; set; }
        public string AbreviaturaId { get; set; }

        public string Descripcion { get; set; }

        public string Letra { get; set; }

        public int AlicuotaIva { get; set; }

        public IvaSituation() { }

        public IvaSituation(typSituacionesIva typSituacionesIva)
        {
            this.ID = typSituacionesIva.ID;
            this.AbreviaturaId = typSituacionesIva.AbreviaturaId;
            this.Descripcion = typSituacionesIva.Descripcion;
            this.Letra = typSituacionesIva.Letra;
        }

        public IvaSituation(conSituacionesIva conSituacionesIva)
        {
            this.ID = conSituacionesIva.ID;
            this.AbreviaturaId = conSituacionesIva.AbreviaturaId;
            this.Descripcion = conSituacionesIva.Descripcion;
            this.Letra = conSituacionesIva.Letra;
        }

    }
}
