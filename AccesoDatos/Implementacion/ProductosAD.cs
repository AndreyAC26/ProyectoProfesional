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
    public class ProductosAD : IProductosAD
    {
        //Conexion a la base de datos
        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public ProductosAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        //**************ENTIDADES**************//

        //Lista de todos los Productos
        public List<Productos> recProductos_ENT()
        {
            List<Productos> lobjRespuesta = new List<Productos>();
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                lobjRespuesta = gObjConexionAW.Productos.ToList();
            }
            catch (Exception lEx)
            {
                //throw lEx;
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            finally
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = true;
            }
            return lobjRespuesta;
        }

        //Lista de los Productos por el ID
        public Productos recProductosXId_ENT(int pId)
        {
            Productos lobjRespuesta = new Productos();
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                lobjRespuesta = gObjConexionAW.Productos.ToList().Find(cr => cr.Id_producto == pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = true;
            }
            return lobjRespuesta;
        }

        //Insertar Productos
        public bool insProductos_ENT(Productos pProductos)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.Productos.Find(pProductos.Id_producto);
                if (regEncontrado == null)
                {
                    gObjConexionAW.Productos.Add(pProductos);
                    gObjConexionAW.SaveChanges();
                    lobjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = true;
            }
            return lobjRespuesta;
        }

        //Modificar Productos
        public bool modProductos_ENT(Productos pProductos)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.Productos.Find(pProductos.Id_producto);
                if (regEncontrado != null)
                {
                    gObjConexionAW.Entry(regEncontrado).CurrentValues.SetValues(pProductos);
                    gObjConexionAW.Entry(regEncontrado).State = System.Data.Entity.EntityState.Modified;
                    gObjConexionAW.SaveChanges();
                    lobjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = true;
            }
            return lobjRespuesta;
        }

        //Borrar Productos
        public bool delProductos_ENT(Productos pProductos)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.Productos.Find(pProductos.Id_producto);
                if (regEncontrado != null)
                {
                    gObjConexionAW.Entry(regEncontrado).CurrentValues.SetValues(pProductos);
                    gObjConexionAW.Entry(regEncontrado).State = System.Data.Entity.EntityState.Deleted;
                    gObjConexionAW.SaveChanges();
                    lobjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = true;
            }
            return lobjRespuesta;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//

        //public List<recProductos_Result> recProductos_PA()
        //{
        //    List<recProductos_Result> lobjRespuesta = new List<recProductos_Result>();
        //    try
        //    {
        //        lobjRespuesta = gObjConexionAW.recProductos().ToList();
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
        //        lobjRespuesta = gObjConexionAW.recProductosxId(pId).FirstOrDefault();
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
        //        if (gObjConexionAW.insProducto(pProductos.Id_producto, pProductos.Nombre,
        //            pProductos.Tipo_producto, pProductos.Precio, pProductos.Descripcion) == 1)
        //        {
        //            lobjRespuesta = true;
        //        }
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
        //        if (gObjConexionAW.insertProducto(pProductos.Nombre,
        //            pProductos.Tipo_producto, pProductos.Precio, pProductos.Descripcion) == 1)
        //        {
        //            lobjRespuesta = true;
        //        }
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
        //        if (gObjConexionAW.modProductos(pProductos.Id_producto, pProductos.Nombre,
        //            pProductos.Tipo_producto, pProductos.Precio, pProductos.Descripcion) == 1)
        //        {
        //            lobjRespuesta = true;
        //        }
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
        //        if (gObjConexionAW.delproducto(pProductos.Id_producto) == 1)
        //        {
        //            lobjRespuesta = true;
        //        }
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return lobjRespuesta;
        //}
    }
}
