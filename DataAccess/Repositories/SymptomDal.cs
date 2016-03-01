using System.Collections.Generic;
using ShamanExpressDLL;
using Domain;
using Domain.Utils;
using System.Data;

namespace DataAccess.Repositories
{
    public static class SymptomDal
    {

        public static List<Symptom> GetAll()
        {
            conSintomas conSintomas = new conSintomas();
            DataTable symptons = conSintomas.GetAll();
            return symptons.DataTableToList<Symptom>();
        }
    }
}
