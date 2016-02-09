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

        static conIncidentes conIncidentes;
        static conClientesIntegrantes conClientesIntegrantes;
        static conlckIncidentes conLckIncidentes;
        static IncidentDal()
        {

            conIncidentes = new conIncidentes();
            conClientesIntegrantes = new conClientesIntegrantes();
            conLckIncidentes = new conlckIncidentes();
        }

        public static List<Incident> GetAll()
        {
            DataTable operativa = conIncidentes.GetOperativa();
            return operativa.DataTableToList<Incident>();
        }

        public static List<ChartQuantity> GetChartCantidades(DateTime fecha)
        {
            DataTable chart = new conIncidentes().GetChartCantidades(fecha);
            return chart.DataTableToList<ChartQuantity>();
        }

        public static List<ChartTimes> GetChartTiempos(DateTime fecha)
        {
            DataTable chart = new conIncidentes().GetChartTiempos(fecha);
            return chart.DataTableToList<ChartTimes>();
        }

        public static string GetNewIncidentNumberToCreate()
        {
            return conLckIncidentes.getNewIncidente(DateTime.Now);

        }

        public static Incident GetPreviousIncident(string id)
        {
            long incId = conIncidentes.MovePrevious(DateTime.Now, Convert.ToInt64(id));
            return GetById(Convert.ToString(incId));
        }

        public static Incident GetNextIncident(string id)
        {
            long incId = conIncidentes.MoveNext(DateTime.Now, Convert.ToInt64(id));
            return GetById(Convert.ToString(incId));
        }

        public static Incident GetFirstIncident()
        {
            long id = conIncidentes.MoveFirst(DateTime.Now);
            return GetById(Convert.ToString(id));
        }

        public static Incident GetLastIncident()
        {
            long id = conIncidentes.MoveLast(DateTime.Now);
            return GetById(Convert.ToString(id));
        }

        public static Incident GetByPhone(string phone)
        {
            long incidentId = conIncidentes.GetByPhone(phone);

            if (incidentId > 0)
            {
                conIncidentes.Abrir(Convert.ToString(incidentId));
                return new Incident(conIncidentes);
            }

            return null;

        }

        public static Incident GetById(string id)
        {
            conIncidentes.Abrir(id);
            return new Incident(conIncidentes);
        }
    }
}
