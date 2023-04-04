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
    public class MesasLN : IMesasLN
    {
        //Conexion a Entidades
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();

        //Conexion a acceso datos

        private readonly IMesasAD gobjMesasAD = new MesasAD(_objContextoAW);



        public List<recMesas_Result> recMesasActivas_PA()
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            try
            {
                lobjRespuesta = gobjMesasAD.recMesasActivas();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }


        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recMesas_Result> recMesas_PA()
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            try
            {
                lobjRespuesta = gobjMesasAD.recMesas_PA();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recMesaxId_Result recMesasXId_PA(int pId)
        {
            recMesaxId_Result lobjRespuesta = new recMesaxId_Result();
            try
            {
                lobjRespuesta = gobjMesasAD.recMesasXId_PA(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insMesas_PA(Mesas pMesas)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjMesasAD.insMesas_PA(pMesas);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool modMesas_PA(Mesas pMesas)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjMesasAD.modMesas_PA(pMesas);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool delMesas_PA(Mesas pMesas)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjMesasAD.delMesas_PA(pMesas);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
