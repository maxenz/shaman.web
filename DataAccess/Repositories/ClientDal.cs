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
    
        public static Client GetById(long id)
        {
            conClientes.Abrir(id.ToString());
            return new Client(conClientes);
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

        public static Client GetIdByAbreviaturaId(string clientDescription)
        {
            Client client = null;
            long id = conClientes.GetIDByAbreviaturaId(clientDescription, true);
            if (id != 0 )
            {
                client = GetById(id);
                client.EstadoMorosidad = conClientes.GetEstadoMorosidad(id);
                client.Id = id;
            }
     
            return client;
            
        }

        public static ClientMember GetIdByNroAfiliado(string clientAbreviaturaId, string affiliateNumber)
        {
            long clientId = GetIdByAbreviaturaId(clientAbreviaturaId).Id;
            ClientMember clientMember = null;
            long id = conClientesIntegrantes.GetIDByNroAfiliado(clientId, affiliateNumber);

            if (id != 0)
            {
                conClientesIntegrantes.Abrir(Convert.ToString(id));
                return new ClientMember(conClientesIntegrantes);
            }

            return clientMember;
            
        }

    }
}
