using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;

namespace Domain
{
    public class ClientMember
    {

        public long Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public ClientMember(conClientesIntegrantes conClientesIntegrantes )
        {
            this.Id = conClientesIntegrantes.ID;
            this.Nombre = conClientesIntegrantes.Nombre;
            this.Apellido = conClientesIntegrantes.Apellido;
        }
    }
}
