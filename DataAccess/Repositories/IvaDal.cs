using System.Collections.Generic;
using ShamanExpressDLL;
using Domain;
using Domain.Utils;
using System.Data;

namespace DataAccess.Repositories
{
    public static class IvaDal
    {
        static conSituacionesIva conSituacionesIva;

        static IvaDal()
        {
            conSituacionesIva = new conSituacionesIva();            
        }

        public static List<IvaSituation> GetAllSituations()
        {
            DataTable ivaSituations = conSituacionesIva.GetAll();
            return ivaSituations.DataTableToList<IvaSituation>();
        }
    }
}
