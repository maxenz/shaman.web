using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;
using System.Runtime.Serialization;

namespace Domain
{

    public class OperativeGrade 
    {

        public decimal Orden { get; set; }

        public string ColorHexa { get; set; }

        public string AbreviaturaId { get; set; }

        public string Descripcion { get; set; }

        public long Id { get; set; }
        public OperativeGrade() { }

        public OperativeGrade(conGradosOperativos conGradosOperativos)
        {
            this.Id = conGradosOperativos.ID;
            this.Orden = conGradosOperativos.Orden;
            this.ColorHexa = conGradosOperativos.ColorHexa;
            this.AbreviaturaId = conGradosOperativos.AbreviaturaId;
            this.Descripcion = conGradosOperativos.Descripcion;
        }

        public OperativeGrade(typGradosOperativos typGradosOperativos)
        {
            this.Id = typGradosOperativos.ID;
            this.Orden = typGradosOperativos.Orden;
            this.ColorHexa = typGradosOperativos.ColorHexa;
            this.AbreviaturaId = typGradosOperativos.AbreviaturaId;
            this.Descripcion = typGradosOperativos.Descripcion;
        }
    }
}
