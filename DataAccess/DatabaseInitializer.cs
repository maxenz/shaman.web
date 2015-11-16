using ShamanExpressDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess
{
    public static class DatabaseInitializer
    {
        public static void SetInitializer()
        {
            try
            {
                var startup = new StartUp();

                if (startup.GetValoresHardkey())
                {
                    if (startup.GetVariablesConexion(true, modDeclares.keyMode.keyRegistry))
                    {
                        if (startup.AbrirConexion(modDeclares.cnnDefault))
                        {
                            modFechas.InitDateVars();
                            modDeclares.shamanConfig = new conConfiguracion();
                            modDeclares.shamanConfig.UpConfig();
                            bool cambiar = false;
                            modDeclares.shamanSession = new conUsuarios();
                            modDeclares.shamanSession.Autenticar("JAVIER", "jj4842908", ref cambiar);
                        }
                    }
                } 
            }
            catch (Exception ex)
            {
                LogShaman sarasa = new LogShaman();
                sarasa.SetLog(ex.ToString());
            }
         
        }
    }
}
