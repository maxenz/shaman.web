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
    public static class OperativeGradeDal
    {
        static conGradosOperativos conGradosOperativos;

        static OperativeGradeDal()
        {
            conGradosOperativos = new conGradosOperativos();
        }

        public static List<OperativeGrade> GetAll()
        {
            DataTable grades = conGradosOperativos.GetAll();
            return grades.DataTableToList<OperativeGrade>();
        }
    }
}
