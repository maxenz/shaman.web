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

        static conIncidentesViajes conIncidentesViajes;

        static TravelIncidentDal()
        {
            conIncidentesViajes = new conIncidentesViajes();
        }

        public static TravelIncident GetDespachoPopupInformation(int id)
        {
            if (id > 0)
            {
                conIncidentesViajes.Abrir(id.ToString());
                return new TravelIncident(conIncidentesViajes);
            }

            return null;
        }
    }
}
