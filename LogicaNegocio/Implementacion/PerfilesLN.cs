using AccesoDatos.Implementacion;
using AccesoDatos;
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
    public class PerfilesLN : IPerfilesLN
    {
        //Conexion a Entidades
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();

        //Conexion a acceso datos

        private readonly IPerfilesAD gobjPerfilesAD = new PerfilesAD(_objContextoAW);

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recPerfiles_Result> recPerfiles_PA()
        {
            List<recPerfiles_Result> lobjRespuesta = new List<recPerfiles_Result>();
            try
            {
                lobjRespuesta = gobjPerfilesAD.recPerfiles_PA();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recMesaPerfilxId_Result recPerfilesXId_PA(int pId)
        {
            recMesaPerfilxId_Result lobjRespuesta = new recMesaPerfilxId_Result();
            try
            {
                lobjRespuesta = gobjPerfilesAD.recIPerfilesXId_PA(pId);
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
                lobjRespuesta = gobjPerfilesAD.insPerfiles_PA(pPerfiles);
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
                lobjRespuesta = gobjPerfilesAD.modPerfiles_PA(pPerfiles);
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
                lobjRespuesta = gobjPerfilesAD.delPerfiles_PA(pPerfiles);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
