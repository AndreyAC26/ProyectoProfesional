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
    public class EstadoLN : IEstadoLN
    {
        //Conexion a Entidades
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();

        //Conexion a acceso datos

        private readonly IEstadoAD gobjEstadoAD = new EstadoAD(_objContextoAW);

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recEstados_Result> recEstados_PA()
        {
            List<recEstados_Result> lobjRespuesta = new List<recEstados_Result>();
            try
            {
                lobjRespuesta = gobjEstadoAD.recEstado_PA();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recEstadoxId_Result recEstadoXId_PA(int pId)
        {
            recEstadoxId_Result lobjRespuesta = new recEstadoxId_Result();
            try
            {
                lobjRespuesta = gobjEstadoAD.recIEstadoXId_PA(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insEstado_PA(Estado pEstado)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjEstadoAD.insEstado_PA(pEstado);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool modEstado_PA(Estado pEstado)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjEstadoAD.modEstado_PA(pEstado);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool delEstado_PA(Estado pEstado)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjEstadoAD.delEstado_PA(pEstado);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
