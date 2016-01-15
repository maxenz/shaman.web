using Domain;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;
using System.Data;

namespace DataAccess
{
    public static class ClientDal
    {

        static conClientes conClientes;
        static conClientesIntegrantes conClientesIntegrantes;
        static conPlanes conPlanes;

            static ClientDal()
        {
            conClientes = new conClientes();
            conClientesIntegrantes = new conClientesIntegrantes();
            conPlanes = new conPlanes();
            
        }
    
        public static Client GetById(int id)
        {
            conClientes.Abrir(id.ToString());
            Client client = new Client
            {
                Name = conClientes.RazonSocial,
                LastName = conClientes.CodigoPostal
            };

            return client;
        }

        public static ClientMember GetByPhone(string phone)
        {
            long idClientesIntegrantes = conClientesIntegrantes.GetByPhone(phone);
            if (idClientesIntegrantes > 0)
            {
                conClientesIntegrantes.Abrir(Convert.ToString(idClientesIntegrantes));
                return new ClientMember(conClientesIntegrantes);
            }

            return null;
        }

        public static List<Plan> GetAllPlansByClient(long clientId)
        {
            DataTable plans = conPlanes.GetAll(clientId);
            return plans.DataTableToList<Plan>();
        }

    }
}
