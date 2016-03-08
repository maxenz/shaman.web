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

        #region Static Methods
        public static List<IncidentGridDTO> GetAll()
        {
            conIncidentes conIncidentes = new conIncidentes();
            DataTable operativa = conIncidentes.GetOperativaDX();
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
            conlckIncidentes conLckIncidentes = new conlckIncidentes();
            return conLckIncidentes.getNewIncidente(DateTime.Now);

        }

        public static Incident GetPreviousIncident(string id)
        {
            conIncidentes conIncidentes = new conIncidentes();
            long incId = conIncidentes.MovePrevious(DateTime.Now, Convert.ToInt64(id));
            return GetById(Convert.ToString(incId));
        }

        public static Incident GetNextIncident(string id)
        {
            conIncidentes conIncidentes = new conIncidentes();
            long incId = conIncidentes.MoveNext(DateTime.Now, Convert.ToInt64(id));
            return GetById(Convert.ToString(incId));
        }

        public static Incident GetFirstIncident()
        {
            conIncidentes conIncidentes = new conIncidentes();
            long id = conIncidentes.MoveFirst(DateTime.Now);
            return GetById(Convert.ToString(id));
        }

        public static Incident GetLastIncident()
        {
            conIncidentes conIncidentes = new conIncidentes();
            long id = conIncidentes.MoveLast(DateTime.Now);
            return GetById(Convert.ToString(id));
        }

        public static Incident GetByPhone(string phone)
        {
            conIncidentes conIncidentes = new conIncidentes();
            long incidentId = conIncidentes.GetByPhone(phone);

            if (incidentId > 0)
            {
                conIncidentes ci = new conIncidentes();
                ci.Abrir(Convert.ToString(incidentId));
                return new Incident(ci);
            }

            return null;

        }

        public static Incident GetById(string id)
        {
            conIncidentes conIncidentes = new conIncidentes();
            conIncidentes.Abrir(id);
            return new Incident(conIncidentes);
        }

        public static DatabaseValidationResult SaveIncident(Incident incident)
        {
            modDeclares.dllMode = true;
            conIncidentes conIncidentes = new conIncidentes();
            conIncidentes.CleanProperties(conIncidentes);
            conIncidentesDomicilios conIncidentesDomicilios = new conIncidentesDomicilios();
            conLocalidades conLocalidades = new conLocalidades();
            conIncidentesObservaciones conIncidentesObservaciones = new conIncidentesObservaciones();
            conlckIncidentes conlckIncidentes = new conlckIncidentes();
            DateTime pFec = incident.FechaIncidente;
            string pNic = incident.NroIncidente;
            string pCliAbr = incident.Cliente.AbreviaturaId;
            long pCli = incident.Cliente.Id;
            string pAfl = incident.NroAfiliado;
            long pGdo = incident.GradoOperativo.Id;
            string pDom = incident.Domicilio.Description;
            long pLoc = incident.Localidad.ID;
            string pPac = incident.Paciente;
            bool pAddPac = false;
            bool vAddNew = true;

            if (pCli == 0) pCli = modDeclares.shamanConfig.ClienteDefaultId.ID;

            if (pGdo == 0)
            {
                conGradosOperativos objGrado = new conGradosOperativos();
                pGdo = objGrado.GetDefault();
                objGrado = null;
            }

            string errors = "";

            if (conIncidentes.ValidarIncidente(pFec, pNic, pCliAbr, pCli, pAfl, pGdo, pDom, pLoc, pPac, ref pAddPac, ref errors))
            {
                // --> Cabecera del incidente
                if (incident.ID > 0) vAddNew = false;
                conIncidentes.FecIncidente = pFec;
                conIncidentes.NroIncidente = pNic;
                if (modDeclares.shamanConfig.modNumeracion == 1) conIncidentes.TrasladoId = Convert.ToInt64(incident.NroIncidente);
                conIncidentes.Telefono = incident.Telefono;
                conIncidentes.ClienteId.SetObjectId(Convert.ToString(pCli));
                conIncidentes.ClienteIntegranteId.SetObjectId(Convert.ToString(incident.NroAfiliado));
                conIncidentes.ClienteId.AbreviaturaId = pCliAbr;
                conIncidentes.ClienteId.ID = pCli;
                conIncidentes.NroAfiliado = pAfl;
                conIncidentes.GradoOperativoId.SetObjectId(pGdo.ToString());
                conIncidentes.Paciente = pPac;
                conIncidentes.Sexo = incident.Sexo;
                conIncidentes.Edad = incident.Edad;
                conIncidentes.PlanId = incident.PlanId ?? "";
                conIncidentes.Sintomas = incident.Sintomas;
                conIncidentes.CoPago = Convert.ToInt64(incident.Copago);
                conIncidentes.flgIvaGravado = Convert.ToInt32(incident.SituacionIvaId);
                if (modDeclares.shamanConfig.opeNroInterno == 0)
                {
                    conIncidentes.Aviso = incident.Aviso ?? "";

                }
                else
                {
                    conIncidentes.NroInterno = incident.Aviso ?? "";
                }

                // --> Domicilio de IDA

                conIncidentesDomicilios.CleanProperties(conIncidentesDomicilios);
                conIncidentesDomicilios.LocalidadId.SetObjectId(incident.Localidad.ID.ToString());
                conIncidentesDomicilios.Domicilio.dmEntreCalle1 = incident.Domicilio.BetweenStreet1 ?? "";
                conIncidentesDomicilios.Domicilio.dmEntreCalle2 = incident.Domicilio.BetweenStreet2 ?? "";
                conIncidentesDomicilios.Domicilio.dmCalle = incident.Domicilio.Street ?? "";
                conIncidentesDomicilios.Domicilio.dmPiso = incident.Domicilio.Floor ?? "";
                conIncidentesDomicilios.Domicilio.dmDepto = incident.Domicilio.Department ?? "";
                conIncidentesDomicilios.Domicilio.dmAltura = incident.Domicilio.Height;
                conIncidentesDomicilios.Domicilio.dmReferencia = incident.Domicilio.Reference ?? "";

                if (conIncidentesDomicilios.TipoOrigen == 0)
                {
                    var dom = conIncidentesDomicilios.Domicilio;
                    modGPShaman.SetLatLong(ref dom, Convert.ToDecimal(conIncidentesDomicilios.LocalidadId.GetObjectId()));
                    conIncidentesDomicilios.Domicilio = dom;
                }
                else
                {
                    //
                }

                conIncidentesObservaciones.CleanProperties(conIncidentesObservaciones);
                conIncidentesObservaciones.Observaciones = incident.Observaciones;

                string dateFormatted = String.Format("{0:yyyy-MM-dd HH:mm:ss}", "1899-12-30 00:00:00");
                bool saved = conIncidentes.SetIncidente(conIncidentes, conIncidentesDomicilios, conIncidentesObservaciones, Convert.ToDateTime(dateFormatted));
                if (saved)
                {
                    conlckIncidentes.CleanProperties(conlckIncidentes);
                    conlckIncidentes.unlockIncidente(conIncidentes.FecIncidente, conIncidentes.NroIncidente);
                    return new DatabaseValidationResult(errors, true);
                }
            }

            return new DatabaseValidationResult(errors, false);


        }
        #endregion

    }
}
