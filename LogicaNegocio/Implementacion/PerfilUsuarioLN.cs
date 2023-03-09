using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using AccesoDatos;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion
{
    public class PerfilUsuarioLN : IPerfilUsuarioLN
    {
        //Conexion a Entidades
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();

        //Conexion a acceso datos

        private readonly IPerfilUsuarioAD gobjPerfilUsuarioAD = new PerfilUsuarioAD(_objContextoAW);

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recPerfilUsuario_Result> recPerfilUsuario_PA()
        {
            List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
            try
            {
                lobjRespuesta = gobjPerfilUsuarioAD.recPerfilUsuario_PA();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recPerfilUsuarioxId_Result recPerfilUsuarioXId_PA(int pId)
        {
            recPerfilUsuarioxId_Result lobjRespuesta = new recPerfilUsuarioxId_Result();
            try
            {
                lobjRespuesta = gobjPerfilUsuarioAD.recIPerfilUsuarioXId_PA(pId);
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
                lobjRespuesta = gobjPerfilUsuarioAD.insPerfilUsuario_PA(pPerfilUsuario);
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
                lobjRespuesta = gobjPerfilUsuarioAD.modPerfilUsuario_PA(pPerfilUsuario);
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
                lobjRespuesta = gobjPerfilUsuarioAD.delPerfilUsuario_PA(pPerfilUsuario);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
