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

        public static List<Suggestion> GetSugerencias(int tipoMovilId, long gradoOperativoId, long localidadId)
        {
            conMovilesActuales conMovilesActuales = new conMovilesActuales();
            DataTable sugerencias = conMovilesActuales.GetDTSugerenciaDespacho(tipoMovilId, gradoOperativoId, localidadId);
            return sugerencias.DataTableToList<Suggestion>();
        }

        public static Mobile GetMobileByNumber(string mobNumber)
        {
            conMoviles conMoviles = new conMoviles();
            long mobileId = conMoviles.GetIDByMovil(mobNumber);
            if (mobileId != 0)
            {
                conMoviles.Abrir(mobileId.ToString());
                return new Mobile(conMoviles);
            }
            return null;
        }
    }
}
