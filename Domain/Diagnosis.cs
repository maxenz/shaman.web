using ShamanExpressDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Diagnosis
    {
        public long Id { get; set; }

        public string AbreviaturaId { get; set; }

        public string Descripcion { get; set; }

        public Diagnosis() { }

        public Diagnosis(typMotivosNoRealizacion motivoNoRealizacion)
        {
            this.Id = motivoNoRealizacion.ID;
            this.AbreviaturaId = motivoNoRealizacion.AbreviaturaId;
            this.Descripcion = motivoNoRealizacion.Descripcion;
        }
    }
}
