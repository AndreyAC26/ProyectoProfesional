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
    public class DetalleOrdenLN : IDetalleOrdenLN
    {
        //Conexion a Entidades
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();
        //Conexion a acceso datos

        private readonly IDetalleOrdenAD gobjDetalleOrdenAD = new DetalleOrdenAD(_objContextoAW);

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recDetalleOrden_Result> recDetalleOrden_PA()
        {
            List<recDetalleOrden_Result> lobjRespuesta = new List<recDetalleOrden_Result>();
            try
            {
                lobjRespuesta = gobjDetalleOrdenAD.recDetalleOrden_PA();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recDetalleOrdenxId_Result recDetalleOrdenXId_PA(int pId)
        {
            recDetalleOrdenxId_Result lobjRespuesta = new recDetalleOrdenxId_Result();
            try
            {
                lobjRespuesta = gobjDetalleOrdenAD.recDetalleOrdenXId_PA(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insDetalleOrden_PA(DetalleOrden pDetalleOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjDetalleOrdenAD.insDetalleOrden_PA(pDetalleOrden);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool modDetalleOrden_PA(DetalleOrden pDetalleOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjDetalleOrdenAD.modDetalleOrden_PA(pDetalleOrden);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool delDetalleOrden_PA(DetalleOrden pDetalleOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjDetalleOrdenAD.insDetalleOrden_PA(pDetalleOrden);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }


        //**************ENTIDADES**************//

        //Lista de DetalleOrden
        public List<DetalleOrden> recDetalleOrden_ENT()
        {
            List<DetalleOrden> lobjRespuesta = new List<DetalleOrden>();
            try
            {
                lobjRespuesta = gobjDetalleOrdenAD.recDetalleOrden_ENT();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //DetalleOrden por ID
        public DetalleOrden recDetalleOrdenXId_ENT(int pId)
        {
            DetalleOrden lobjRespuesta = new DetalleOrden();
            try
            {
                lobjRespuesta = gobjDetalleOrdenAD.recDetalleOrdenXId_ENT(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Insertar DetalleOrden
        public bool insDetalleOrden_ENT(DetalleOrden pDetalleOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjDetalleOrdenAD.insDetalleOrden_ENT(pDetalleOrden);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Modificar DetalleOrden
        public bool modDetalleOrden_ENT(DetalleOrden pDetalleOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjDetalleOrdenAD.modDetalleOrden_ENT(pDetalleOrden);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Borrar DetalleOrden
        public bool delDetalleOrden_ENT(DetalleOrden pDetalleOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjDetalleOrdenAD.delDetalleOrden_ENT(pDetalleOrden);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
