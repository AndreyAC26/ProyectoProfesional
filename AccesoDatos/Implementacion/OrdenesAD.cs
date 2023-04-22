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
    public class OrdenesAD : IOrdenesAD
    {
        //Conexion a la base de datos

        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public OrdenesAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }


        ////**************PROCEDIMIENTOS ALMACENADOS**************//


        public ObtenerProductosPorCategoria_Result recObtenerProductosPorCategoria_ResultsXId_PA(int pId)
        {
            ObtenerProductosPorCategoria_Result lobjRespuesta = new ObtenerProductosPorCategoria_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.ObtenerProductosPorCategoria(pId).FirstOrDefault();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public ObtenerOrdenesDeMesa_Result recObtenerOrdenesDeMesaXId_PA(int pId)
        {
            ObtenerOrdenesDeMesa_Result lobjRespuesta = new ObtenerOrdenesDeMesa_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.ObtenerOrdenesDeMesa(pId).FirstOrDefault();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public List<recOrdenes_Result> recOrdenes_PA()
        {
            List<recOrdenes_Result> lobjRespuesta = new List<recOrdenes_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recOrdenes().ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recOrdenxId_Result recIOrdenesXId_PA(int pId)
        {
            recOrdenxId_Result lobjRespuesta = new recOrdenxId_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.recOrdenxId(pId).FirstOrDefault();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool insOrden_PA(Ordenes pOrden)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.insOrden() == 1)
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


        //**************Entidades**************//

        //Lista de todos los Ordenes
        public List<Ordenes> recOrdenes_ENT()
        {
            List<Ordenes> lobjRespuesta = new List<Ordenes>();
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                lobjRespuesta = gObjConexionAW.Ordenes.ToList();
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

        //Lista de los Ordenes por el ID
        public Ordenes recOrdenesXId_ENT(int pId)
        {
            Ordenes lobjRespuesta = new Ordenes();
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                lobjRespuesta = gObjConexionAW.Ordenes.ToList().Find(cr => cr.Id_Orden == pId);
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

        //Insertar Ordenes
        public bool insOrdenes_ENT(Ordenes pOrdenes)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.Ordenes.Find(pOrdenes.Id_Orden);
                if (regEncontrado == null)
                {
                    gObjConexionAW.Ordenes.Add(pOrdenes);
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

        //Modificar Ordenes
        public bool modOrdenes_ENT(Ordenes pOrdenes)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.Ordenes.Find(pOrdenes.Id_Orden);
                if (regEncontrado != null)
                {
                    gObjConexionAW.Entry(regEncontrado).CurrentValues.SetValues(pOrdenes);
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

        //Borrar Ordenes
        public bool delOrdenes_ENT(Ordenes pOrdenes)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexionAW.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexionAW.Ordenes.Find(pOrdenes.Id_Orden);
                if (regEncontrado != null)
                {
                    gObjConexionAW.Entry(regEncontrado).CurrentValues.SetValues(pOrdenes);
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
