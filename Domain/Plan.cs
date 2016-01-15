using ShamanExpressDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Plan : BaseRegister
    {

        public typClientes ClienteId { get; set; }

        public string AbreviaturaId { get; set; }

        public string Descripcion { get; set; }

        public Plan() { }

        public Plan(conPlanes conPlanes)
        {
            this.ClienteId = conPlanes.ClienteId;
            this.AbreviaturaId = conPlanes.AbreviaturaId;
            this.Descripcion = conPlanes.Descripcion;
            this.RegFechaHora = conPlanes.regFechaHora;
            this.RegTerminalId = conPlanes.regTerminalId;
            this.RegUsuarioId = conPlanes.regUsuarioId;
        }
    }
}
