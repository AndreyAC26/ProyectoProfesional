using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion
{
    public class SeguridadLN : ISeguridadLN
    {
        public static MuncheeseEntidades _objContextoSEG = new MuncheeseEntidades();

        private readonly ISeguridadAD gobjSeguridad = new SeguridadAD(_objContextoSEG);

        public Usuarios recUsuario(string pUsrLogin)
        {
            Usuarios lobjRespuesta = new Usuarios();
            try
            {
                lobjRespuesta = gobjSeguridad.recUsuario(pUsrLogin);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
