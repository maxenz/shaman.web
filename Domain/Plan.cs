using ShamanExpressDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Plan
    {

        public string AbreviaturaId { get; set; }

        public string Descripcion { get; set; }

        public long Id { get; set; }

        public Plan() { }

        public Plan(conPlanes conPlanes)
        {
            this.Id = conPlanes.ID;
            this.AbreviaturaId = conPlanes.AbreviaturaId;
            this.Descripcion = conPlanes.Descripcion;
            //this.RegFechaHora = conPlanes.regFechaHora;
            //this.RegTerminalId = conPlanes.regTerminalId;
            //this.RegUsuarioId = conPlanes.regUsuarioId;
        }
    }
}
