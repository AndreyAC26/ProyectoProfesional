using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using MVCMuncheese.Models;
using MVCMuncheese.Models.ViewModels;
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


        public ActionResult Ordenes(int mesa)
        {
            // Obtener información de la mesa seleccionada usando el número de mesa recibido como parámetro
            MesaViewModel mesaSeleccionada = null;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    var resultado = srvWCF_CR.recMesaXId_PA(mesa);
                    var estado = resultado.Estado == 1 ? "Activo" : "Ocupado";
                    mesaSeleccionada = new MesaViewModel { NumeroMesa = resultado.Id_Mesa, Estado = resultado.Estado, EstadoMesa = estado };
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            // Crear un nuevo modelo de vista de orden con la información de la mesa seleccionada
            var modeloOrdenes = new modeloOrdenes { Mesa = mesa };

            srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient();
            ViewBag.Tipo_Producto = new SelectList(db.recTipo_Producto_PA().ToList(), "Id_tipo_producto", "Nombre_tipo_pro");
            ViewBag.Producto = new SelectList(db.recProductos_ENT().ToList(), "Id_producto", "Nombre");
            return View(modeloOrdenes);
        }

        public JsonResult ObtenerProductosPorTipo(int idTipoProducto)
        {
            srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient();
            var productos = db.recObtenerProductosPorCategoria_ResultXId_PA(idTipoProducto);
            return Json(productos, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult obtenerProductosPorTipo(int Id_tipo_Producto)
        {
            using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
            {
                var productos = srvWCF_CR.recObtenerProductosPorCategoria_ResultXId_PA(Id_tipo_Producto);
                return Json(productos, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpGet]
        public JsonResult obtenerPrecioPorProducto(int Id_tipo_Producto)
        {
            srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient();
            var producto = db.recProductos_ENT().FirstOrDefault(p => p.Id_producto == Id_tipo_Producto);
            if (producto != null)
            {
                return Json(producto.Precio, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
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
                            objModeloOrdenes.Estado = lcr.Estado;
                            objModeloOrdenes.Fecha = (DateTime)lcr.Fecha;

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
                    lobjModeloOrdenes.Id_Orden = lobjRespuesta.Id_Orden;
                    lobjModeloOrdenes.Estado = lobjRespuesta.Estado;
                    lobjModeloOrdenes.Fecha = (DateTime)lobjRespuesta.Fecha;
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
                    lobjModeloOrdenes.Estado = lobjRespuesta.Estado;
                    lobjModeloOrdenes.Fecha = (DateTime)lobjRespuesta.Fecha;

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
                    lobjModeloOrdenes.Estado = lobjRespuesta.Estado;
                    lobjModeloOrdenes.Fecha = (DateTime)lobjRespuesta.Fecha;

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
            pOrdenes.Estado = pModeloOrdenes.Estado;
            pOrdenes.Fecha = pModeloOrdenes.Fecha;



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


        [HttpPost]
        public JsonResult insertarOrde_ENT(int Id_Orden, int Id_Mesa, int Id_Estado, string Estado, DateTime Fecha)
        {
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    srvWCF_CR.insOrdenes_ENT(new Ordenes
                    {
                        Id_Orden = Id_Orden,
                        Mesa = Id_Mesa,
                        Estado = Id_Estado,
                        Estados = Estado,
                        Fecha = Fecha
                    });
                }
                return Json(new { exito = true });
            }
            catch (Exception ex)
            {
                return Json(new { exito = false, errorMessage = ex.Message });
            }
        }

        //[HttpPost]
        //public JsonResult insertarOrde_ENT(Ordenes pOrden)
        //{
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            srvWCF_CR.insOrdenes_ENT(pOrden);
        //        }
        //        return Json(new { success = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, errorMessage = ex.Message });
        //    }
        //}


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
                            objModeloOrdenes.Estado = lcr.Estado;
                            objModeloOrdenes.Fecha = (DateTime)lcr.Fecha;
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
                            objModeloOrdenes.Estado = lcr.Estado;
                            objModeloOrdenes.Fecha = (DateTime)lcr.Fecha;
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
                            objModeloOrdenes.Estado = lcr.Estado;
                            objModeloOrdenes.Fecha = (DateTime)lcr.Fecha;
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