using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;
using Domain;
using Domain.Utils;
using System.Data;

namespace DataAccess.Repositories
{
    public static class IncidentDal
    {
        public static List<Incident> GetAll()
        {
            DataTable operativa = new conIncidentes().GetOperativa();
            return operativa.DataTableToList<Incident>();
        }
    }
}
