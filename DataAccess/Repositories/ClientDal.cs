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

        public static Client GetById(long id)
        {
            conClientes conClientes = new conClientes();
            conClientes.Abrir(id.ToString());
            return new Client(conClientes);
        }

        public static ClientMember GetByPhone(string phone)
        {
            conClientesIntegrantes conClientesIntegrantes = new conClientesIntegrantes();
            long idClientesIntegrantes = conClientesIntegrantes.GetByPhone(phone);
            if (idClientesIntegrantes > 0)
            {
                conClientesIntegrantes.Abrir(Convert.ToString(idClientesIntegrantes));
                return new ClientMember(conClientesIntegrantes);
            }

            return null;
        }

        public static List<Plan> GetAllPlansByClient(string client)
        {
            conClientes conClientes = new conClientes();
            conPlanes conPlanes = new conPlanes();
            conPlanes.CleanProperties(conPlanes);
            long id = conClientes.GetIDByAbreviaturaId(client);
            if (id != 0)
            {
                DataTable plans = conPlanes.GetAll(id);
                return plans.DataTableToList<Plan>();
            }

            return null;
        }

        public static Client GetIdByAbreviaturaId(string clientAbreviaturaId)
        {
            conClientes conClientes = new conClientes();
            Client client = null;
            long id = conClientes.GetIDByAbreviaturaId(clientAbreviaturaId, true);
            if (id != 0)
            {
                client = GetById(id);
                client.EstadoMorosidad = conClientes.GetEstadoMorosidad(id);
                client.Id = id;
            }

            return client;

        }

        public static string GetEstadoMorosidad(long clienteId)
        {
            conClientes conClientes = new conClientes();
            Client client = null;
            //long id = conClientes.GetIDByAbreviaturaId(clienteId, true);
            if (clienteId != 0)
            {
                return conClientes.GetEstadoMorosidad(clienteId);
            }

            return String.Empty;
        }

        public static ClientMember GetIdByNroAfiliado(string clientAbreviaturaId, string affiliateNumber)
        {
            conClientesIntegrantes conClientesIntegrantes = new conClientesIntegrantes();
            long clientId = GetIdByAbreviaturaId(clientAbreviaturaId).Id;
            long id = conClientesIntegrantes.GetIDByNroAfiliado(clientId, affiliateNumber);

            if (id != 0)
            {
                conClientesIntegrantes.Abrir(Convert.ToString(id));
                return new ClientMember(conClientesIntegrantes);
            }

            return null;

        }

        public static List<ClientMember> GetClientMembersByClient(string clientAbreviaturaId)
        {
            conClientesIntegrantes conClientesIntegrantes = new conClientesIntegrantes();
            long clientId = GetIdByAbreviaturaId(clientAbreviaturaId).Id;
            DataTable dtClientMembers = conClientesIntegrantes.GetQueryBaseByCliente(clientId);

            return dtClientMembers.DataTableToList<ClientMember>();

        }

        public static List<Client> GetAll()
        {
            conClientes conClientes = new conClientes();
            DataTable dtClients = conClientes.GetAll();
            return dtClients.DataTableToList<Client>();
        }

        public static List<ClientMember> GetAllClientMembers()
        {
            conClientesIntegrantes conClientesIntegrantes = new conClientesIntegrantes();
            DataTable dtClientMembers = conClientesIntegrantes.GetAll();
            return dtClientMembers.DataTableToList<ClientMember>();
        }

    }
}
