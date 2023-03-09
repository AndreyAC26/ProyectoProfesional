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
    public class UsuariosLN : IUsuariosLN

    {//Conexion a Entidades
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();

        //Conexion a acceso datos

        private readonly IUsuariosAD gobjUsuariosAD = new UsuariosAD(_objContextoAW);

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recUsuarios_Result> recUsuarios_PA()
        {
            List<recUsuarios_Result> lobjRespuesta = new List<recUsuarios_Result>();
            try
            {
                lobjRespuesta = gobjUsuariosAD.recUsuarios_PA();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recUsuarioxId_Result recUsuariosXId_PA(string pId)
        {
            recUsuarioxId_Result lobjRespuesta = new recUsuarioxId_Result();
            try
            {
                lobjRespuesta = gobjUsuariosAD.recIUsuariosXId_PA(pId);
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
                lobjRespuesta = gobjUsuariosAD.insUsuarios_PA(pUsuarios);
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
                lobjRespuesta = gobjUsuariosAD.modUsuarios_PA(pUsuarios);
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
                lobjRespuesta = gobjUsuariosAD.insUsuarios_PA(pUsuarios);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
