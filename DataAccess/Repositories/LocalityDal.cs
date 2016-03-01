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

        public static Locality GetIdByAbreviaturaId(string locAbreviaturaId)
        {
            conLocalidades conLocalidades = new conLocalidades();
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
