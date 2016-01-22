using System;
using ShamanExpressDLL;

namespace Domain
{

    public class Client 
    {
        public string RazonSocial { get; set; }
        public string AbreviaturaId { get; set; }
        public bool Activo { get; set; }
        //public usrDomicilio Domicilio { get; set; }
        public string EstadoMorosidad { get; set; }

        public long Id { get; set; }

        public Client() { }

        public Client(conClientes conClientes)
        {
            this.RazonSocial = conClientes.RazonSocial;
            this.AbreviaturaId = conClientes.AbreviaturaId;
            this.Activo = Convert.ToBoolean(conClientes.Activo);
            //this.Domicilio = conClientes.Domicilio;
            this.Id = conClientes.ID;

        }
    }
}
