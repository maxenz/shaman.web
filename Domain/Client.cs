using System;
using ShamanExpressDLL;

namespace Domain
{

    public class Client 
    {
        public string RazonSocial { get; set; }
        public string AbreviaturaId { get; set; }
        public bool Activo { get; set; }
        public string EstadoMorosidad { get; set; }

        public long Id { get; set; }

        public IvaSituation SituacionIvaId { get; set; }

        public Client() { }

        public Client(conClientes conClientes)
        {
            this.RazonSocial = conClientes.RazonSocial;
            this.AbreviaturaId = conClientes.AbreviaturaId;
            this.Activo = Convert.ToBoolean(conClientes.Activo);
            this.Id = conClientes.ID;
            this.SituacionIvaId = new IvaSituation(conClientes.SituacionIvaId);
        }

        public Client(typClientes typClientes)
        {
            this.RazonSocial = typClientes.RazonSocial;
            this.AbreviaturaId = typClientes.AbreviaturaId;
            this.Activo = Convert.ToBoolean(typClientes.Activo);
            this.Id = typClientes.ID;
            this.SituacionIvaId = new IvaSituation(typClientes.SituacionIvaId);
        }
    }
}
