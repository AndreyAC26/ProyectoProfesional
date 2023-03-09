using AccesoDatos.Interfaces;
using Entidades;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class SeguridadAD : ISeguridadAD
    {
        private MuncheeseEntidades gObjConexionSEG;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public SeguridadAD(MuncheeseEntidades lObjConexionSEG)
        {
            gObjConexionSEG = lObjConexionSEG;
        }

        public Usuarios recUsuario(string pUsrLogin)
        {
            Usuarios lobjRespuesta = new Usuarios();
            try
            {
                gObjConexionSEG.Configuration.ProxyCreationEnabled = false;
                lobjRespuesta = gObjConexionSEG.Usuarios.ToList().Find(us => us.Usuario == pUsrLogin);
            }
            catch (Exception lEx)
            {
                //throw lEx;
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            finally
            {
                gObjConexionSEG.Configuration.ProxyCreationEnabled = true;
            }
            return lobjRespuesta;
        }
    }
}
