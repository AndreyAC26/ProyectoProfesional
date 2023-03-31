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
    public class OrdenesLN : IOrdenesLN
    {
        //Conexion a accesoDatos
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();
        //Conexion a acceso datos

        private readonly IOrdenesAD gobjOrdenesAD = new OrdenesAD(_objContextoAW);

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recOrdenes_Result> recOrdenes_PA()
        {
            List<recOrdenes_Result> lobjRespuesta = new List<recOrdenes_Result>();
            try
            {
                lobjRespuesta = gobjOrdenesAD.recOrdenes_PA();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recOrdenxId_Result recOrdenesXId_PA(int pId)
        {
            recOrdenxId_Result lobjRespuesta = new recOrdenxId_Result();
            try
            {
                lobjRespuesta = gobjOrdenesAD.recIOrdenesXId_PA(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }


        public ObtenerProductosPorCategoria_Result recObtenerProductosPorCategoria_ResultXId_PA(int pId)
        {
            ObtenerProductosPorCategoria_Result lobjRespuesta = new ObtenerProductosPorCategoria_Result();
            try
            {
                lobjRespuesta = gobjOrdenesAD.recObtenerProductosPorCategoria_ResultsXId_PA(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public ObtenerOrdenesDeMesa_Result recObtenerOrdenesDeMesa_PA(int pId)
        {
            ObtenerOrdenesDeMesa_Result lobjRespuesta = new ObtenerOrdenesDeMesa_Result();
            try
            {
                lobjRespuesta = gobjOrdenesAD.recObtenerOrdenesDeMesaXId_PA(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool insOrdenes_PA(Ordenes pOrdenes)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjOrdenesAD.insOrden_PA(pOrdenes);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //**************ENTIDADES**************//

        //Lista de Ordenes
        public List<Ordenes> recOrdenes_ENT()
        {
            List<Ordenes> lobjRespuesta = new List<Ordenes>();
            try
            {
                lobjRespuesta = gobjOrdenesAD.recOrdenes_ENT();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Ordenes por ID
        public Ordenes recOrdenesXId_ENT(int pId)
        {
            Ordenes lobjRespuesta = new Ordenes();
            try
            {
                lobjRespuesta = gobjOrdenesAD.recOrdenesXId_ENT(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Insertar Ordenes
        public bool insOrdenes_ENT(Ordenes pOrdenes)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjOrdenesAD.insOrdenes_ENT(pOrdenes);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Modificar Ordenes
        public bool modOrdenes_ENT(Ordenes pOrdenes)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjOrdenesAD.modOrdenes_ENT(pOrdenes);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Borrar Ordenes
        public bool delOrdenes_ENT(Ordenes pOrdenes)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjOrdenesAD.delOrdenes_ENT(pOrdenes);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
