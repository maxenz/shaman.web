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
            
            if (modStartUp.GetValoresHardkey()) {
                if (modStartUp.GetVariablesConexion(true,modDeclares.keyMode.keyRegistry)) {
                    if (modDatabase.AbrirConexion(modDeclares.cnnDefault)) {
                        modFechas.InitDateVars();
                        modDeclares.shamanConfig = new conConfiguracion();
                        modDeclares.shamanConfig.UpConfig();
                        bool cambiar = false;
                        modDeclares.shamanSession = new conUsuarios();
                        modDeclares.shamanSession.Autenticar("JAVIER", "jj4842908",ref cambiar);
                    }
                }
            }          
        }
    }
}
