using System;
using System.Collections.Generic;
using ShamanExpressDLL;
using Domain;
using Domain.Utils;
using System.Data;

namespace DataAccess.Repositories
{
    public static class IncidentDal
    {

        #region Properties

        static conIncidentes conIncidentes;
        static conClientesIntegrantes conClientesIntegrantes;
        static conlckIncidentes conLckIncidentes;

        #endregion

        #region Constructors
        static IncidentDal()
        {
            conIncidentes = new conIncidentes();
            conClientesIntegrantes = new conClientesIntegrantes();
            conLckIncidentes = new conlckIncidentes();
        }

        #endregion

        #region Static Methods
        public static List<IncidentGridDTO> GetAll()
        {
            DataTable operativa = conIncidentes.GetOperativa();
            return operativa.DataTableToList<IncidentGridDTO>();
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

        public static DatabaseValidationResult SaveIncident(Incident incident)
        {

            DateTime pFec = incident.FechaIncidente;
            string pNic = incident.NroIncidente;
            string pCliAbr = incident.Cliente.AbreviaturaId;
            long pCli = incident.Cliente.Id;
            string pAfl = incident.NroAfiliado;
            long pGdo = incident.GradoOperativo.Id;
            string pDom = incident.Domicilio.Description;
            long pLoc = incident.Localidad.ID;
            string pPac = incident.Paciente;
            bool pAddPac = true;

            if (conIncidentes.ValidarIncidente(pFec,pNic,pCliAbr,pCli,pAfl,pGdo,pDom,pLoc,pPac,ref pAddPac))
            {

            }

            return new DatabaseValidationResult();
        }
        #endregion

    }
}
