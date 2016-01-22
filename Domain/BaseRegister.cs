using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;
using System.Runtime.Serialization;

namespace Domain
{
    [DataContract]
    public class BaseRegister
    {
        public typUsuarios RegUsuarioId { get; set; }
        public typTerminales RegTerminalId { get; set; }
        public DateTime RegFechaHora { get; set; }
        public long Id { get; set; }
    }
}
