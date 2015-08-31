using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;

namespace DataAccess
{
    public static class ClientDal
    {
        public static Client GetById(int id)
        {
            var conClientes = new conClientes();
            conClientes.Abrir("8873");
            Client client = new Client
            {
                Name = conClientes.RazonSocial,
                LastName = conClientes.CodigoPostal
            };

            return client;
        }
    }
}
