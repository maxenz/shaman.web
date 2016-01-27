using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;

namespace Domain
{
   public class GeographicZone
    {
        public string AbreviaturaId { get; set; }
        public string Descripcion { get; set; }
        public long Id { get; set; }
        public GeographicZone() { }

        public GeographicZone(typZonasGeograficas typZonasGeograficas)
        {
            this.AbreviaturaId = typZonasGeograficas.AbreviaturaId;
            this.Descripcion = typZonasGeograficas.Descripcion;
            this.Id = typZonasGeograficas.ID;
            
        }
    }
}
