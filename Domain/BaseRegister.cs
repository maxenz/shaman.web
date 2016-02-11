using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;
using System.Runtime.Serialization;

namespace Domain
{
    public class BaseRegister
    {
        public long RegUsuarioId { get; set; }
        public long RegTerminalId { get; set; }
        public DateTime RegFechaHora { get; set; }
        public long Id { get; set; }
    }
}
