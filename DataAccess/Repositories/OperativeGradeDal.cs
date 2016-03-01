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

        public static List<OperativeGrade> GetAll()
        {
            conGradosOperativos conGradosOperativos = new conGradosOperativos();
            DataTable grades = conGradosOperativos.GetAll();
            return grades.DataTableToList<OperativeGrade>();
        }
    }
}
