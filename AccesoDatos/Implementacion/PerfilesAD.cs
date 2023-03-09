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
    public class PerfilesAD : IPerfilesAD
    {

        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public PerfilesAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recPerfiles_Result> recPerfiles_PA()
        {
            List<recPerfiles_Result> lobjRespuesta = new List<recPerfiles_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recPerfiles().ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recMesaPerfilxId_Result recIPerfilesXId_PA(int pId)
        {
            recMesaPerfilxId_Result lobjRespuesta = new recMesaPerfilxId_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.recMesaPerfilxId(pId).FirstOrDefault();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insPerfiles_PA(Perfiles pPerfiles)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.insPerfil(pPerfiles.nombre_perfil) == 1)
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

        public bool modPerfiles_PA(Perfiles pPerfiles)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.modPerfil(pPerfiles.Perfil_Id, pPerfiles.nombre_perfil) == 1)
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

        public bool delPerfiles_PA(Perfiles pPerfiles)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.delPerfil(pPerfiles.Perfil_Id) == 1)
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
