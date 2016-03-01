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

        #endregion

        #region Public Methods

        public static TravelIncident GetDespachoPopupInformation(int id)
        {
            conIncidentesViajes.CleanProperties(conIncidentesViajes);
            if (id > 0)
            {
                conIncidentesViajes.Abrir(id.ToString());
                return new TravelIncident(conIncidentesViajes);
            }

            return null;
        }

        public static DatabaseValidationResult Dispatch(Suggestion suggestion)
        {

            string sugType = SuggestionTypes.Soporte.ToString();

            conIncidentesSucesos.CleanProperties(conIncidentesSucesos);
            conSucesos.CleanProperties(conSucesos);

            conIncidentesSucesos.IncidenteViajeId.SetObjectId(suggestion.ID.ToString());
            conIncidentesSucesos.FechaHoraSuceso = DateTime.Now;
            conIncidentesSucesos.SucesoIncidenteId.SetObjectId(conSucesos.GetIDByAbreviaturaId(sugType).ToString());
            conIncidentesSucesos.MovilId.SetObjectId(suggestion.Movil.ID.ToString());

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
