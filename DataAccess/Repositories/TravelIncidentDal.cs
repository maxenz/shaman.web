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
    public static class TravelIncidentDal
    {

        #region Properties

        private static conIncidentesViajes conIncidentesViajes { get; set; }
        private static conIncidentesSucesos conIncidentesSucesos { get; set; }
        private static conSucesosIncidentes conSucesos { get; set; }
        private static conMovilesActuales conMovilActual { get; set; }

        #endregion

        #region Public Methods

        public static TravelIncident GetDespachoPopupInformation(int id)
        {
            conIncidentesViajes = new conIncidentesViajes();
            if (id > 0)
            {
                conIncidentesViajes.Abrir(id.ToString());
                return new TravelIncident(conIncidentesViajes);
            }

            return null;
        }

        public static DatabaseValidationResult Dispatch(TravelIncident ti)
        {
            conMovilActual = new conMovilesActuales();
            conSucesos = new conSucesosIncidentes();
            conIncidentesSucesos = new conIncidentesSucesos();
            conIncidentesViajes = new conIncidentesViajes();
            conMovilActual.CleanProperties(conMovilActual);
            ti.MovilId = MobileDal.GetMobileByNumber(ti.Movil).ID;
            conMovilActual.Abrir(conMovilActual.GetIDAndValidation(ti.MovilId, ti.Movil, false).ToString());
            string sugType = "S";

            if (ti.ViewType > 0)
            {
                sugType = "Z";
            } else
            {
                if (modDeclares.shamanConfig.flgTpoSalidaBase == 1)
                {
                    if (conSucesos.GetIDByAbreviaturaId("B") > 0)
                    {
                        if (conMovilActual.SucesoIncidenteId.AbreviaturaId == "L")
                        {
                            sugType = "B";
                        }
                    }
                }
            }

            conIncidentesSucesos.CleanProperties(conIncidentesSucesos);
            conSucesos.CleanProperties(conSucesos);

            conIncidentesSucesos.IncidenteViajeId.SetObjectId(ti.Id.ToString());
            conIncidentesSucesos.FechaHoraSuceso = DateTime.Now;
            conIncidentesSucesos.SucesoIncidenteId.SetObjectId(conSucesos.GetIDByAbreviaturaId(sugType).ToString());
            conIncidentesSucesos.MovilId.SetObjectId(ti.MovilId.ToString());

            if (conIncidentesSucesos.addSuceso(conIncidentesSucesos))
            {
                return new DatabaseValidationResult("", true);
                //shaman mensajeria
            }
            
            return new DatabaseValidationResult("No se pudo despachar la sugerencia.", false);
        }

        #endregion


    }
}
