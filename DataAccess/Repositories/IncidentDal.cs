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
            conIncidentes conIncidentes = new conIncidentes();
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

        public static Incident Get(string id)
        {
            return GetAll().Find(x => x.IncidenteId.ToString().Equals(id));
            //conIncidentes conIncidentes = new conIncidentes();
            //if (conIncidentes.Abrir(id))
            //    return new Incident(conIncidentes);

            //return null;
        }

        public static Incident GetNextIncident(string id)
        {
            conIncidentes conIncidentes = new conIncidentes();
            long incidentId = conIncidentes.MoveNext(new DateTime(2015, 08, 12), Convert.ToInt64(id));
            return Get(incidentId.ToString());
        }

        public static Incident GetPreviousIncident(string id)
        {
            conIncidentes conIncidentes = new conIncidentes();
            long incidentId = conIncidentes.MovePrevious(new DateTime(2015, 08, 12), Convert.ToInt64(id));
            return Get(incidentId.ToString());
        }

        public static Incident GetFirstIncident(string id)
        {
            conIncidentes conIncidentes = new conIncidentes();
            long incidentId = conIncidentes.MoveFirst(new DateTime(2015,08,12));
            return Get(incidentId.ToString());
        }

        public static Incident GetLastIncident(string id)
        {
            conIncidentes conIncidentes = new conIncidentes();
            long incidentId = conIncidentes.MoveLast(new DateTime(2015, 08, 12));
            Incident inc = Get(incidentId.ToString());
            return inc;

        }
    }
}
