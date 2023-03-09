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
    public class EstadoAD : IEstadoAD
    {
        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public EstadoAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recEstados_Result> recEstado_PA()
        {
            List<recEstados_Result> lobjRespuesta = new List<recEstados_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recEstados().ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recEstadoxId_Result recIEstadoXId_PA(int pId)
        {
            recEstadoxId_Result lobjRespuesta = new recEstadoxId_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.recEstadoxId(pId).FirstOrDefault();
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
                if (gObjConexionAW.insEstado( pEstado.Estado1) == 1)
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

        public bool modEstado_PA(Estado pEstado)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.modEstado(pEstado.Id_Estado, pEstado.Estado1) == 1)
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

        public bool delEstado_PA(Estado pEstado)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.delEstado(pEstado.Id_Estado) == 1)
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
