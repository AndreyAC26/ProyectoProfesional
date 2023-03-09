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
    public class ProductosLN : IProductosLN
    {
        //Conexion a accesoDatos
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();
        //Conexion a acceso datos

        private readonly IProductosAD gobjProductosAD = new ProductosAD(_objContextoAW);

        //**************ENTIDADES**************//

        //Lista de Productos
        public List<Productos> recProductos_ENT()
        {
            List<Productos> lobjRespuesta = new List<Productos>();
            try
            {
                lobjRespuesta = gobjProductosAD.recProductos_ENT();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Productos por ID
        public Productos recProductosXId_ENT(int pId)
        {
            Productos lobjRespuesta = new Productos();
            try
            {
                lobjRespuesta = gobjProductosAD.recProductosXId_ENT(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Insertar Productos
        public bool insProductos_ENT(Productos pProductos)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjProductosAD.insProductos_ENT(pProductos);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Modificar Producto
        public bool modProductos_ENT(Productos pProductos)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjProductosAD.modProductos_ENT(pProductos);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Borrar Producto
        public bool delProductos_ENT(Productos pProductos)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjProductosAD.delProductos_ENT(pProductos);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }


        //**************PROCEDIMIENTOS ALMACENADOS**************//
        //public List<recProductos_Result> recProductos_PA()
        //{
        //    List<recProductos_Result> lobjRespuesta = new List<recProductos_Result>();
        //    try
        //    {
        //        lobjRespuesta = gobjProductosAD.recProductos_PA();
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return lobjRespuesta;
        //}

        //public recProductosxId_Result recProductosXId_PA(int pId)
        //{
        //    recProductosxId_Result lobjRespuesta = new recProductosxId_Result();
        //    try
        //    {
        //        lobjRespuesta = gobjProductosAD.recProductosXId_PA(pId);
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return lobjRespuesta;
        //}
        //public bool insProductos_PA(Productos pProductos)
        //{
        //    bool lobjRespuesta = false;
        //    try
        //    {
        //        lobjRespuesta = gobjProductosAD.insProductos_PA(pProductos);
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return lobjRespuesta;
        //}

        //public bool insertProductos_PA(Productos pProductos)
        //{
        //    bool lobjRespuesta = false;
        //    try
        //    {
        //        lobjRespuesta = gobjProductosAD.insertProductos_PA(pProductos);
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return lobjRespuesta;
        //}

        //public bool modProductos_PA(Productos pProductos)
        //{
        //    bool lobjRespuesta = false;
        //    try
        //    {
        //        lobjRespuesta = gobjProductosAD.modProductos_PA(pProductos);
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return lobjRespuesta;
        //}

        //public bool delProductos_PA(Productos pProductos)
        //{
        //    bool lobjRespuesta = false;
        //    try
        //    {
        //        lobjRespuesta = gobjProductosAD.delProductos_PA(pProductos);
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return lobjRespuesta;
        //}
    }
}
