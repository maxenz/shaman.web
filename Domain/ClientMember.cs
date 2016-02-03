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

        public string TipoIntegrante { get; set; }

        public string Cliente { get; set; }

        public string NroAfiliado { get; set; }

        public long Documento { get; set; }

        public ClientMember() { }

        public ClientMember(conClientesIntegrantes conClientesIntegrantes )
        {
            this.Id = conClientesIntegrantes.ID;
            this.Nombre = conClientesIntegrantes.Nombre;
            this.Apellido = conClientesIntegrantes.Apellido;
            this.TipoIntegrante = conClientesIntegrantes.TipoIntegrante;
            this.NroAfiliado = conClientesIntegrantes.NroAfiliado;
            this.Documento = conClientesIntegrantes.NroDocumento;
            if (conClientesIntegrantes.ClienteId != null)
            {
                this.Cliente = conClientesIntegrantes.ClienteId.AbreviaturaId;
            }

        }
    }
}
