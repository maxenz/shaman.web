using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;

namespace Domain
{
    public class BaseRegister
    {
        public typUsuarios RegUsuarioId { get; set; }
        public typTerminales RegTerminalId { get; set; }
        public DateTime RegFechaHora { get; set; }
        public long Id { get; set; }
    }
}
