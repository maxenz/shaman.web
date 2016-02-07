using System.Collections.Generic;
using ShamanExpressDLL;
using Domain;
using Domain.Utils;
using System.Data;

namespace DataAccess.Repositories
{
    public static class SymptomDal
    {
        static conSintomas conSintomas;

        static SymptomDal()
        {
            conSintomas = new conSintomas();
        }

        public static List<Symptom> GetAll()
        {
            DataTable symptons = conSintomas.GetAll();
            return symptons.DataTableToList<Symptom>();
        }
    }
}
