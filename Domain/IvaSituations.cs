using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class IvaSituations
    {
        public long ID { get; set; }
        public string AbreviaturaId { get; set; }

        public string Descripcion { get; set; }

        public string Letra { get; set; }

        public int AlicuotaIva { get; set; }

    }
}
