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
    public class UsuariosAD : IUsuariosAD
    {
        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public UsuariosAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recUsuarios_Result> recUsuarios_PA()
        {
            List<recUsuarios_Result> lobjRespuesta = new List<recUsuarios_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recUsuarios().ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recUsuarioxId_Result recIUsuariosXId_PA(string pId)
        {
            recUsuarioxId_Result lobjRespuesta = new recUsuarioxId_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.recUsuarioxId(pId).FirstOrDefault();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insUsuarios_PA(Usuarios pUsuarios)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.insUsuario(pUsuarios.Usuario, pUsuarios.Contraseña, pUsuarios.Estado) == 1)
                {
                    lobjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool modUsuarios_PA(Usuarios pUsuarios)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.modUsuario(pUsuarios.Usuario, pUsuarios.Contraseña, pUsuarios.Estado) == 1)
                {
                    lobjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool delUsuarios_PA(Usuarios pUsuarios)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.delUsuario(pUsuarios.Usuario) == 1)
                {
                    lobjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
