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
    public class PerfilUsuarioAD : IPerfilUsuarioAD
    {
        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public PerfilUsuarioAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recPerfilUsuario_Result> recPerfilUsuario_PA()
        {
            List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recPerfilUsuario().ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recPerfilUsuarioxId_Result recIPerfilUsuarioXId_PA(int pId)
        {
            recPerfilUsuarioxId_Result lobjRespuesta = new recPerfilUsuarioxId_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.recPerfilUsuarioxId(pId).FirstOrDefault();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insPerfilUsuario_PA(PerfilUsuario pPerfilUsuario)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.insPerfilUsuario(pPerfilUsuario.Perfil_Id, pPerfilUsuario.Usuario) == 1)
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

        public bool modPerfilUsuario_PA(PerfilUsuario pPerfilUsuario)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.modPerfilUsuario(pPerfilUsuario.Perfil_Id, pPerfilUsuario.Usuario, pPerfilUsuario.Id_PerfilUsuario) == 1)
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

        public bool delPerfilUsuario_PA(PerfilUsuario pPerfilUsuario)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.delPerfilUsuario(pPerfilUsuario.Id_PerfilUsuario) == 1)
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
