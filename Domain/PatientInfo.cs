using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PatientInfo
    {
        public int InfoPacienteItemId { get; set; }
        public string InfoPacienteGrupo { get; set; }
        public string Descripcion { get; set; }
        public int ID { get; set; }
        public bool Checked { get; set; }
        public string Observaciones { get; set; }
    }
}
