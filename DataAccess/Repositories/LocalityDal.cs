using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShamanExpressDLL;
using Domain;

namespace DataAccess.Repositories
{
    public static class LocalityDal
    {
        static conLocalidades conLocalidades;

        static LocalityDal()
        {
            conLocalidades = new conLocalidades();
        }

        public static Locality GetIdByAbreviaturaId(string locAbreviaturaId)
        {
            long id = conLocalidades.GetIDByAbreviaturaId(locAbreviaturaId);
            if (id != 0)
            {
                if (conLocalidades.Abrir(Convert.ToString(id)))
                {
                    return new Locality(conLocalidades);
                }
            }

            return null;
        }
    }
}
