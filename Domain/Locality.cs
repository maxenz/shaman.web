using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;

namespace Domain
{
    public class Locality
    {

        public string AbreviaturaId { get; set; }

        public string Descripcion { get; set; }

        public Partido Partido { get; set; }

        public Province Province { get; set; }

        public GeographicZone GeographicZone { get; set; }

        public Locality() { }

        public Locality(conLocalidades conLocalidades)
        {
            this.AbreviaturaId = conLocalidades.AbreviaturaId;
            this.Descripcion = conLocalidades.Descripcion;
            this.Partido = new Partido(conLocalidades.PartidoId);
            this.Province = new Province(conLocalidades.ProvinciaId);
            this.GeographicZone = new GeographicZone(conLocalidades.ZonaGeograficaId);
                 
        }

    }
}
