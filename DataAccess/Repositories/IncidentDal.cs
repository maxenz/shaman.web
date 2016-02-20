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
        static conIncidentesDomicilios conIncidentesDomicilios;
        static conIncidentesObservaciones conIncidentesObservaciones;

        #endregion

        #region Constructors
        static IncidentDal()
        {
            conIncidentes = new conIncidentes();
            conIncidentes.GradoOperativoId = new typGradosOperativos();
            conIncidentes.ClienteId = new typClientes();
            conClientesIntegrantes = new conClientesIntegrantes();
            conLckIncidentes = new conlckIncidentes();
            conIncidentesDomicilios = new conIncidentesDomicilios();
            conIncidentesDomicilios.Domicilio = new usrDomicilio();
            conIncidentesObservaciones = new conIncidentesObservaciones();         
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

            string errors = "";

            if (conIncidentes.ValidarIncidente(pFec,pNic,pCliAbr,pCli,pAfl,pGdo,pDom,pLoc,pPac,ref pAddPac,ref errors, true))
            {

                conIncidentes.FecIncidente = pFec;
                conIncidentes.NroIncidente = pNic;
                conIncidentes.ClienteId.AbreviaturaId = pCliAbr;
                conIncidentes.ClienteId.ID = pCli;
                conIncidentes.NroAfiliado = pAfl;
                conIncidentes.GradoOperativoId.ID = pGdo;
                conIncidentes.Paciente = pPac;

                conIncidentesDomicilios.Domicilio.dmEntreCalle1 = incident.Domicilio.BetweenStreet1;
                conIncidentesDomicilios.Domicilio.dmEntreCalle2 = incident.Domicilio.BetweenStreet2;
                conIncidentesDomicilios.Domicilio.dmCalle = incident.Domicilio.Street;
                conIncidentesDomicilios.Domicilio.dmPiso = incident.Domicilio.Floor;
                conIncidentesDomicilios.Domicilio.dmDepto = incident.Domicilio.Department;
                conIncidentesDomicilios.Domicilio.dmAltura = incident.Domicilio.Height;


                bool saved = conIncidentes.SetIncidente(conIncidentes, conIncidentesDomicilios, conIncidentesObservaciones, pFec);
                if (saved)
                {
                    return new DatabaseValidationResult(errors, true);
                }
            }

            return new DatabaseValidationResult(errors,false);


        }
        #endregion

    }
}
