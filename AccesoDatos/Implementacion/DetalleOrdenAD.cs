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
    public class DetalleOrdenAD : IDetalleOrdenAD
    {
        //Conexion a la base de datos

        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public DetalleOrdenAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }


        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recDetalleOrden_Result> recDetalleOrden_PA()
        {
            List<recDetalleOrden_Result> lobjRespuesta = new List<recDetalleOrden_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recDetalleOrden().ToList();
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
                lobjRespuesta = gObjConexionAW.recDetalleOrdenxId(pId).FirstOrDefault();
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
                if (gObjConexionAW.insDetalleOrden( pDetalleOrden.Id_Orden, pDetalleOrden.Id_producto,
                    pDetalleOrden.Cantidad, pDetalleOrden.Mesa, pDetalleOrden.Precio, pDetalleOrden.Tipo_orden,
                    pDetalleOrden.Descripcion) == 1)
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

        public bool modDetalleOrden_PA(DetalleOrden pDetalleOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.modDetalleOrden(pDetalleOrden.Id_Detalle, pDetalleOrden.Id_Orden, pDetalleOrden.Id_producto,
                    pDetalleOrden.Cantidad, pDetalleOrden.Mesa, pDetalleOrden.Precio, pDetalleOrden.Tipo_orden,
                    pDetalleOrden.Descripcion) == 1)
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

        public bool delDetalleOrden_PA(DetalleOrden pDetalleOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.delDetalleOrden(pDetalleOrden.Id_Detalle) == 1)
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


        //Entidades

        //Lista de todos los Ordenes
        public List<DetalleOrden> recDetalleOrden_ENT()
        {
            List<DetalleOrden> lobjRespuesta = new List<DetalleOrden>();
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                lobjRespuesta = gObjConexionAW.DetalleOrden.ToList();
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

        //Lista de los DetalleOrden por el ID
        public DetalleOrden recDetalleOrdenXId_ENT(int pId)
        {
            DetalleOrden lobjRespuesta = new DetalleOrden();
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                lobjRespuesta = gObjConexionAW.DetalleOrden.ToList().Find(cr => cr.Id_Detalle == pId);
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

        //Insertar DetalleOrden
        public bool insDetalleOrden_ENT(DetalleOrden pDetalleOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.DetalleOrden.Find(pDetalleOrden.Id_Detalle);
                if (regEncontrado == null)
                {
                    gObjConexionAW.DetalleOrden.Add(pDetalleOrden);
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

        //Modificar DetalleOrden
        public bool modDetalleOrden_ENT(DetalleOrden pDetalleOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.DetalleOrden.Find(pDetalleOrden.Id_Detalle);
                if (regEncontrado != null)
                {
                    gObjConexionAW.Entry(regEncontrado).CurrentValues.SetValues(pDetalleOrden);
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

        //Borrar DetalleOrden
        public bool delDetalleOrden_ENT(DetalleOrden pDetalleOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.DetalleOrden.Find(pDetalleOrden.Id_Detalle);
                if (regEncontrado != null)
                {
                    gObjConexionAW.Entry(regEncontrado).CurrentValues.SetValues(pDetalleOrden);
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
    }
}
