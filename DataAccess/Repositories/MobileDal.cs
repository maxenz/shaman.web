using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;
using System.Data;
using Domain;
using Domain.Utils;

namespace DataAccess.Repositories
{
    public static class MobileDal
    {
        public static List<Mobile> GetAll()
        {
            conMovilesActuales conMovilesActuales = new conMovilesActuales();
            DataTable mobiles = conMovilesActuales.GetMovilesOperativos();
            return mobiles.DataTableToList<Mobile>();
        }
    }
}
