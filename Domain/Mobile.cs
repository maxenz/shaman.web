using ShamanExpressDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Mobile
    {
        public int ID { get; set; }

        public string Movil { get; set; }

        public string ColorZona { get; set; }

        public string ValorGrilla { get; set; }

        public string ColorSuceso { get; set; }

        public string Color { get; set; }

        public int TipoMovilId { get; set; }

        public int ZonaGeograficaId { get; set; }

        public Mobile() { }

        public Mobile(conMoviles conMoviles)
        {
            this.ID = Convert.ToInt32(conMoviles.ID);
            this.Movil = conMoviles.Movil;         
        }
    }

    
}
