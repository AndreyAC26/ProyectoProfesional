using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using MVCMuncheese.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMuncheese.Controllers
{
    public class OrdenesController : Controller
    {

        // GET: Ordenes

        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public ActionResult Ordenes()
        {

            srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient();
            ViewBag.Tipo_Producto = new SelectList(db.recTipo_Producto_PA().ToList(), "Id_tipo_producto", "Nombre_tipo_pro");
            ViewBag.Producto = new SelectList(db.recProductos_ENT().ToList(), "Id_producto", "Nombre");
            return View();
        }

        

        [HttpGet]
        public JsonResult obtenerProductosPorTipo(int idTipoProducto)
        {
            srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient();
            var productos = db.recProductos_ENT().Where(p => p.Tipo_producto == idTipoProducto).ToList();

            return Json(productos, JsonRequestBehavior.AllowGet);
        }


        //*********ENTIDADES*********//
        public ActionResult listarOrdenes_ENT()
        {
            List<Ordenes> lobjRespuesta = new List<Ordenes>();
            List<modeloOrdenes> lobjRespuestaModelo = new List<modeloOrdenes>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recOrdenes_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloOrdenes objModeloOrdenes;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloOrdenes = new modeloOrdenes();
                            objModeloOrdenes.Id_Orden = lcr.Id_Orden;
                            objModeloOrdenes.Cantidad = lcr.Cantidad;
                            objModeloOrdenes.Descipcion = lcr.Descipcion;
                            objModeloOrdenes.Mesa = lcr.Mesa;
                            objModeloOrdenes.Precio = lcr.Precio;
                            objModeloOrdenes.Estado = lcr.Estado;
                            objModeloOrdenes.Id_producto = lcr.Id_producto;
                            objModeloOrdenes.Tipo_orden = lcr.Tipo_orden;

                            // Obtener el nombre del producto
                            using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR2 = new srvMuncheese.IsrvMuncheeseClient())
                            {
                                Productos producto = srvWCF_CR2.recProductos_ENT().Where(x => x.Id_producto == lcr.Id_producto).FirstOrDefault();
                                if (producto != null)
                                {
                                    objModeloOrdenes.Nombre_producto = producto.Nombre;
                                }
                            }

                            lobjRespuestaModelo.Add(objModeloOrdenes);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return View(lobjRespuestaModelo);
        }

        public ActionResult agregarOrdenes_ENT()
        {
            return View();
        }

        public ActionResult modificarOrdenes_ENT(int pId)
        {
            Ordenes lobjRespuesta = new Ordenes();
            modeloOrdenes lobjModeloOrdenes;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recOrdenesXId_ENT(pId);
                    lobjModeloOrdenes = new modeloOrdenes();
                    lobjModeloOrdenes.Id_Orden = lobjRespuesta.Id_Orden;
                    lobjModeloOrdenes.Cantidad = lobjRespuesta.Cantidad;
                    lobjModeloOrdenes.Descipcion = lobjRespuesta.Descipcion;
                    lobjModeloOrdenes.Mesa = lobjRespuesta.Mesa;
                    lobjModeloOrdenes.Precio = lobjRespuesta.Precio;
                    lobjModeloOrdenes.Estado = lobjRespuesta.Estado;
                    lobjModeloOrdenes.Id_producto = lobjRespuesta.Id_producto;
                    lobjModeloOrdenes.Tipo_orden = lobjRespuesta.Tipo_orden;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloOrdenes);
        }

        public ActionResult eliminarOrdenes_ENT(int pId)
        {
            Ordenes lobjRespuesta = new Ordenes();
            modeloOrdenes lobjModeloOrdenes;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recOrdenesXId_ENT(pId);
                    lobjModeloOrdenes = new modeloOrdenes();
                    lobjModeloOrdenes.Id_Orden = lobjRespuesta.Id_Orden;
                    lobjModeloOrdenes.Cantidad = lobjRespuesta.Cantidad;
                    lobjModeloOrdenes.Descipcion = lobjRespuesta.Descipcion;
                    lobjModeloOrdenes.Mesa = lobjRespuesta.Mesa;
                    lobjModeloOrdenes.Precio = lobjRespuesta.Precio;
                    lobjModeloOrdenes.Estado = lobjRespuesta.Estado;
                    lobjModeloOrdenes.Id_producto = lobjRespuesta.Id_producto; 
                    lobjModeloOrdenes.Tipo_orden = lobjRespuesta.Tipo_orden;

                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloOrdenes);
        }

        public ActionResult detalleOrdenes_ENT(int pId)
        {
            Ordenes lobjRespuesta = new Ordenes();
            modeloOrdenes lobjModeloOrdenes;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recOrdenesXId_ENT(pId);
                    lobjModeloOrdenes = new modeloOrdenes();
                    lobjModeloOrdenes.Id_Orden = lobjRespuesta.Id_Orden;
                    lobjModeloOrdenes.Cantidad = lobjRespuesta.Cantidad;
                    lobjModeloOrdenes.Descipcion = lobjRespuesta.Descipcion;
                    lobjModeloOrdenes.Mesa = lobjRespuesta.Mesa;
                    lobjModeloOrdenes.Precio = lobjRespuesta.Precio;
                    lobjModeloOrdenes.Estado = lobjRespuesta.Estado;
                    lobjModeloOrdenes.Id_producto = lobjRespuesta.Id_producto;
                    lobjModeloOrdenes.Tipo_orden = lobjRespuesta.Tipo_orden;

                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloOrdenes);
        }


        /*****Acciones entidades Ordenes******/
        public ActionResult accionesEntidades(string enviarAccion, modeloOrdenes pModeloOrdenes)
        {
            Ordenes pOrdenes = new Ordenes();
            pOrdenes.Id_Orden = pModeloOrdenes.Id_Orden;
            pOrdenes.Cantidad = pModeloOrdenes.Cantidad;
            pOrdenes.Descipcion = pModeloOrdenes.Descipcion;
            pOrdenes.Mesa = pModeloOrdenes.Mesa;
            pOrdenes.Precio = pModeloOrdenes.Precio;
            pOrdenes.Estado = pModeloOrdenes.Estado;
            pOrdenes.Id_producto = pModeloOrdenes.Id_producto;
            pOrdenes.Tipo_orden = pModeloOrdenes.Tipo_orden;



            switch (enviarAccion)
            {
                case "Agregar":
                    return insertarOrd_ENT(pOrdenes);
                case "Modificar":
                    return modificarOrd_ENT(pOrdenes);
                case "Eliminar":
                    return eliminarOrd_ENT(pOrdenes);
                default:
                    return RedirectToAction("listarOrdenes_ENT");
            }
        }

        public ActionResult insertarOrd_ENT(Ordenes pOrdenes)
        {
            List<Ordenes> lobjRespuesta = new List<Ordenes>();
            List<modeloOrdenes> lobjRespuestaModelo = new List<modeloOrdenes>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insOrdenes_ENT(pOrdenes))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recOrdenes_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloOrdenes objModeloOrdenes;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloOrdenes = new modeloOrdenes();
                            objModeloOrdenes.Id_Orden = lcr.Id_Orden;
                            objModeloOrdenes.Cantidad = lcr.Cantidad;
                            objModeloOrdenes.Descipcion = lcr.Descipcion;
                            objModeloOrdenes.Mesa = lcr.Mesa;
                            objModeloOrdenes.Precio = lcr.Precio;
                            objModeloOrdenes.Estado = lcr.Estado;
                            objModeloOrdenes.Id_producto = lcr.Id_producto;
                            objModeloOrdenes.Tipo_orden = lcr.Tipo_orden;
                            lobjRespuestaModelo.Add(objModeloOrdenes);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return RedirectToAction("listarOrdenes_ENT");
        }

        public ActionResult modificarOrd_ENT(Ordenes pOrdenes)
        {
            List<Ordenes> lobjRespuesta = new List<Ordenes>();
            List<modeloOrdenes> lobjRespuestaModelo = new List<modeloOrdenes>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modOrdenes_ENT(pOrdenes))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recOrdenes_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloOrdenes objModeloOrdenes;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloOrdenes = new modeloOrdenes();
                            objModeloOrdenes.Id_Orden = lcr.Id_Orden;
                            objModeloOrdenes.Cantidad = lcr.Cantidad;
                            objModeloOrdenes.Descipcion = lcr.Descipcion;
                            objModeloOrdenes.Mesa = lcr.Mesa;
                            objModeloOrdenes.Precio = lcr.Precio;
                            objModeloOrdenes.Estado = lcr.Estado;
                            objModeloOrdenes.Id_producto = lcr.Id_producto;
                            objModeloOrdenes.Tipo_orden = lcr.Tipo_orden;
                            lobjRespuestaModelo.Add(objModeloOrdenes);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            //return View("listarOrdenes_ENT", lobjRespuestaModelo);
            return RedirectToAction("listarOrdenes_ENT");
        }

        public ActionResult eliminarOrd_ENT(Ordenes pOrdenes)
        {
            List<Ordenes> lobjRespuesta = new List<Ordenes>();
            List<modeloOrdenes> lobjRespuestaModelo = new List<modeloOrdenes>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delOrdenes_ENT(pOrdenes))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recOrdenes_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloOrdenes objModeloOrdenes;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloOrdenes = new modeloOrdenes();
                            objModeloOrdenes.Id_Orden = lcr.Id_Orden;
                            objModeloOrdenes.Cantidad = lcr.Cantidad;
                            objModeloOrdenes.Descipcion = lcr.Descipcion;
                            objModeloOrdenes.Mesa = lcr.Mesa;
                            objModeloOrdenes.Precio = lcr.Precio;
                            objModeloOrdenes.Estado = lcr.Estado;
                            objModeloOrdenes.Id_producto = lcr.Id_producto;
                            objModeloOrdenes.Tipo_orden = lcr.Tipo_orden;
                            lobjRespuestaModelo.Add(objModeloOrdenes);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return RedirectToAction("listarOrdenes_ENT");
        }


    }
}