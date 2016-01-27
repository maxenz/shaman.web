using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;

namespace Domain
{
    public class Province
    {

        public string AbreviaturaId { get; set; }

        public string Descripcion { get; set; }
        public long Id { get; set; }

        public Province() { }

        public Province(typProvincias typProvincias)
        {
            this.AbreviaturaId = typProvincias.AbreviaturaId;
            this.Descripcion = typProvincias.Descripcion;
            this.Id = typProvincias.ID;
        }

    }
}
