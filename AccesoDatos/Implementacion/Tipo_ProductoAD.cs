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
    public class Tipo_ProductoAD : ITipo_Producto
    {
        //Conexion a la base de datos
        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public Tipo_ProductoAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        //**************ENTIDADES**************//

        //Lista de todos los Tipo_Producto
        public List<Tipo_Producto> recTipo_Producto_ENT()
        {
            List<Tipo_Producto> lobjRespuesta = new List<Tipo_Producto>();
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                lobjRespuesta = gObjConexionAW.Tipo_Producto.ToList();
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

        //Lista de los Tipo_Producto por el ID
        public Tipo_Producto recTipo_ProductoXId_ENT(int pId)
        {
            Tipo_Producto lobjRespuesta = new Tipo_Producto();
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                lobjRespuesta = gObjConexionAW.Tipo_Producto.ToList().Find(cr => cr.Id_tipo_Producto == pId);
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

        //Insertar Tipo_Producto
        public bool insTipo_Producto_ENT(Tipo_Producto pTipo_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.Tipo_Producto.Find(pTipo_Producto.Id_tipo_Producto);
                if (regEncontrado == null)
                {
                    gObjConexionAW.Tipo_Producto.Add(pTipo_Producto);
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

        //Modificar Tipo_Producto
        public bool modTipo_Producto_ENT(Tipo_Producto pTipo_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.Tipo_Producto.Find(pTipo_Producto.Id_tipo_Producto);
                if (regEncontrado != null)
                {
                    gObjConexionAW.Entry(regEncontrado).CurrentValues.SetValues(pTipo_Producto);
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

        //Borrar Tipo_Producto
        public bool delTipo_Producto_ENT(Tipo_Producto pTipo_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.Tipo_Producto.Find(pTipo_Producto.Id_tipo_Producto);
                if (regEncontrado != null)
                {
                    gObjConexionAW.Entry(regEncontrado).CurrentValues.SetValues(pTipo_Producto);
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

        public List<recTipo_Producto_Result> recTipo_Producto_PA()
        {
            List<recTipo_Producto_Result> lobjRespuesta = new List<recTipo_Producto_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recTipo_Producto().ToList();
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
                lobjRespuesta = gObjConexionAW.recTipo_ProductoxId(pId).FirstOrDefault();
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
                if (gObjConexionAW.insTipo_Producto(pTipo_Producto.Id_tipo_Producto, pTipo_Producto.Nombre_tipo_pro) == 1)
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

        public bool modTipo_Producto_PA(Tipo_Producto pTipo_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.modTipo_Producto(pTipo_Producto.Id_tipo_Producto, pTipo_Producto.Nombre_tipo_pro) == 1)
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

        public bool delTipo_Producto_PA(Tipo_Producto pTipo_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.delTipo_Producto(pTipo_Producto.Id_tipo_Producto) == 1)
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
