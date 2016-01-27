using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;

namespace Domain
{
    public class Partido
    {

        public string AbreviaturaId { get; set; }

        public string Descripcion { get; set; }
        public long Id { get; set; }

        public Partido() { }

        public Partido(typPartidos typPartidos)
        {
            this.AbreviaturaId = typPartidos.AbreviaturaId;
            this.Descripcion = typPartidos.Descripcion;
            this.Id = typPartidos.ID;
        }

    }
}
