using System.Collections.Generic;
using ShamanExpressDLL;
using Domain;
using Domain.Utils;
using System.Data;

namespace DataAccess.Repositories
{
    public static class IvaDal
    {

        public static List<IvaSituation> GetAllSituations()
        {
            conSituacionesIva conSituacionesIva = new conSituacionesIva();
            DataTable ivaSituations = conSituacionesIva.GetAll();
            return ivaSituations.DataTableToList<IvaSituation>();
        }
    }
}
