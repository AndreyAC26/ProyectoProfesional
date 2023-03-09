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
    public class Tipo_ProductoLN : ITipo_ProductoLN
    {
        //Conexion a accesoDatos
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();
        //Conexion a acceso datos

        private readonly ITipo_Producto gobjTipo_ProductoAD = new Tipo_ProductoAD(_objContextoAW);


        //**************ENTIDADES**************//

        //Lista de Tipo_Producto
        public List<Tipo_Producto> recTipo_Producto_ENT()
        {
            List<Tipo_Producto> lobjRespuesta = new List<Tipo_Producto>();
            try
            {
                lobjRespuesta = gobjTipo_ProductoAD.recTipo_Producto_ENT();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Tipo_Producto por ID
        public Tipo_Producto recTipo_ProductoXId_ENT(int pId)
        {
            Tipo_Producto lobjRespuesta = new Tipo_Producto();
            try
            {
                lobjRespuesta = gobjTipo_ProductoAD.recTipo_ProductoXId_ENT(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Insertar Tipo_Producto
        public bool insTipo_Producto_ENT(Tipo_Producto pTipo_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjTipo_ProductoAD.insTipo_Producto_ENT(pTipo_Producto);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Modificar Tipo_Producto
        public bool modTipo_Producto_ENT(Tipo_Producto pTipo_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjTipo_ProductoAD.modTipo_Producto_ENT(pTipo_Producto);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Borrar Tipo_Producto
        public bool delTipo_Producto_ENT(Tipo_Producto pTipo_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjTipo_ProductoAD.delTipo_Producto_ENT(pTipo_Producto);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recTipo_Producto_Result> recTipo_Producto_PA()
        {
            List<recTipo_Producto_Result> lobjRespuesta = new List<recTipo_Producto_Result>();
            try
            {
                lobjRespuesta = gobjTipo_ProductoAD.recTipo_Producto_PA();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recTipo_ProductoxId_Result recTipo_ProductoXId_PA(int pId)
        {
            recTipo_ProductoxId_Result lobjRespuesta = new recTipo_ProductoxId_Result();
            try
            {
                lobjRespuesta = gobjTipo_ProductoAD.recTipo_ProductoXId_PA(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insTipo_Producto_PA(Tipo_Producto pTipo_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjTipo_ProductoAD.insTipo_Producto_PA(pTipo_Producto);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool modTipo_Producto_PA(Tipo_Producto pTipo_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjTipo_ProductoAD.modTipo_Producto_PA(pTipo_Producto);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool delTipo_Producto_PA(Tipo_Producto pTipo_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjTipo_ProductoAD.delTipo_Producto_PA(pTipo_Producto);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
