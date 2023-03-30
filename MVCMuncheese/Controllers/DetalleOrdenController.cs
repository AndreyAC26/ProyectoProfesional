using Entidades;
using MVCMuncheese.Models.ViewModels;
using MVCMuncheese.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMuncheese.Controllers
{
    public class DetalleOrdenController : Controller
    {
        // GET: DetalleOrden
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();


        
        public ActionResult DetalleOrden(int mesa)
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
            var modeloDetalleOrden = new modeloDetalleOrden { Mesa = mesa };

            srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient();
            ViewBag.Tipo_Producto = new SelectList(db.recTipo_Producto_PA().ToList(), "Id_tipo_producto", "Nombre_tipo_pro");
            var productos = db.recProductos_ENT().ToList();
            modeloDetalleOrden.Productos = productos;
            return View(modeloDetalleOrden);
        }


        public JsonResult ObtenerProductosPorTipo(int pTipo_Producto)
        {
            using (srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient())
            {
                var productos = db.recProductos_ENT()
                    .Where(p => p.Tipo_producto == pTipo_Producto)
                    .Select(p => new { Id_producto = p.Id_producto, Nombre = p.Nombre })
                    .ToList();
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
        public ActionResult listarDetalleOrden_ENT()
        {
            List<DetalleOrden> lobjRespuesta = new List<DetalleOrden>();
            List<modeloDetalleOrden> lobjRespuestaModelo = new List<modeloDetalleOrden>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recDetalleOrden_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloDetalleOrden objModeloDetalleOrden;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloDetalleOrden = new modeloDetalleOrden();
                            objModeloDetalleOrden.Id_Detalle = lcr.Id_Detalle;
                            objModeloDetalleOrden.Id_Orden = lcr.Id_Orden;
                            objModeloDetalleOrden.Id_producto = lcr.Id_producto;
                            objModeloDetalleOrden.Cantidad = lcr.Cantidad;
                            objModeloDetalleOrden.Mesa = lcr.Mesa;
                            objModeloDetalleOrden.Precio = lcr.Precio;
                            objModeloDetalleOrden.Tipo_orden = lcr.Tipo_orden;
                            objModeloDetalleOrden.Descripcion = lcr.Descripcion;

                            // Obtener el nombre del producto
                            using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR2 = new srvMuncheese.IsrvMuncheeseClient())
                            {
                                Productos producto = srvWCF_CR2.recProductos_ENT().Where(x => x.Id_producto == lcr.Id_producto).FirstOrDefault();
                                if (producto != null)
                                {
                                    objModeloDetalleOrden.Nombre_producto = producto.Nombre;
                                }
                            }

                            lobjRespuestaModelo.Add(objModeloDetalleOrden);
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

        public ActionResult agregarDetalleOrden_ENT()
        {
            return View();
        }

        public ActionResult modificarDetalleOrden_ENT(int pId)
        {
            DetalleOrden lobjRespuesta = new DetalleOrden();
            modeloDetalleOrden lobjModeloDetalleOrden;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recDetalleOrdenXId_ENT(pId);
                    lobjModeloDetalleOrden = new modeloDetalleOrden();
                    lobjModeloDetalleOrden.Id_Detalle = lobjRespuesta.Id_Detalle;
                    lobjModeloDetalleOrden.Id_Orden = lobjRespuesta.Id_Orden;
                    lobjModeloDetalleOrden.Id_producto = lobjRespuesta.Id_producto;
                    lobjModeloDetalleOrden.Cantidad = lobjRespuesta.Cantidad;
                    lobjModeloDetalleOrden.Mesa = lobjRespuesta.Mesa;
                    lobjModeloDetalleOrden.Precio = lobjRespuesta.Precio;
                    lobjModeloDetalleOrden.Tipo_orden = lobjRespuesta.Tipo_orden;
                    lobjModeloDetalleOrden.Descripcion = lobjRespuesta.Descripcion;

                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloDetalleOrden);
        }

        public ActionResult eliminarDetalleOrden_ENT(int pId)
        {
            DetalleOrden lobjRespuesta = new DetalleOrden();
            modeloDetalleOrden lobjModeloDetalleOrden;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recDetalleOrdenXId_ENT(pId);
                    lobjModeloDetalleOrden = new modeloDetalleOrden();
                    lobjModeloDetalleOrden.Id_Detalle = lobjRespuesta.Id_Detalle;
                    lobjModeloDetalleOrden.Id_Orden = lobjRespuesta.Id_Orden;
                    lobjModeloDetalleOrden.Id_producto = lobjRespuesta.Id_producto;
                    lobjModeloDetalleOrden.Cantidad = lobjRespuesta.Cantidad;
                    lobjModeloDetalleOrden.Mesa = lobjRespuesta.Mesa;
                    lobjModeloDetalleOrden.Precio = lobjRespuesta.Precio;
                    lobjModeloDetalleOrden.Tipo_orden = lobjRespuesta.Tipo_orden;
                    lobjModeloDetalleOrden.Descripcion = lobjRespuesta.Descripcion;


                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloDetalleOrden);
        }

        public ActionResult detalleDetalleOrden_ENT(int pId)
        {
            DetalleOrden lobjRespuesta = new DetalleOrden();
            modeloDetalleOrden lobjModeloDetalleOrden;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recDetalleOrdenXId_ENT(pId);
                    lobjModeloDetalleOrden = new modeloDetalleOrden();
                    lobjModeloDetalleOrden.Id_Detalle = lobjRespuesta.Id_Detalle;
                    lobjModeloDetalleOrden.Id_Orden = lobjRespuesta.Id_Orden;
                    lobjModeloDetalleOrden.Id_producto = lobjRespuesta.Id_producto;
                    lobjModeloDetalleOrden.Cantidad = lobjRespuesta.Cantidad;
                    lobjModeloDetalleOrden.Mesa = lobjRespuesta.Mesa;
                    lobjModeloDetalleOrden.Precio = lobjRespuesta.Precio;
                    lobjModeloDetalleOrden.Tipo_orden = lobjRespuesta.Tipo_orden;
                    lobjModeloDetalleOrden.Descripcion = lobjRespuesta.Descripcion;


                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloDetalleOrden);
        }


        /*****Acciones entidades DetalleOrden******/
        public ActionResult accionesEntidades(string enviarAccion, modeloDetalleOrden pModeloDetalleOrden)
        {
            DetalleOrden pDetalleOrden = new DetalleOrden();
            pDetalleOrden.Id_Detalle = pModeloDetalleOrden.Id_Detalle;
            pDetalleOrden.Id_Orden = pModeloDetalleOrden.Id_Orden;
            pDetalleOrden.Id_producto = pModeloDetalleOrden.Id_producto;
            pDetalleOrden.Cantidad = pModeloDetalleOrden.Cantidad;
            pDetalleOrden.Mesa = pModeloDetalleOrden.Mesa;
            pDetalleOrden.Precio = pModeloDetalleOrden.Precio;
            pDetalleOrden.Tipo_orden = pModeloDetalleOrden.Tipo_orden;
            pDetalleOrden.Descripcion = pModeloDetalleOrden.Descripcion;



            switch (enviarAccion)
            {
                case "Agregar":
                    return insertarDet_ENT(pDetalleOrden);
                case "Modificar":
                    return modificarDet_ENT(pDetalleOrden);
                case "Eliminar":
                    return eliminarDet_ENT(pDetalleOrden);
                default:
                    return RedirectToAction("listarDetalleOrden_ENT");
            }
        }


        public ActionResult insertarDet_ENT(DetalleOrden pDetalleOrden)
        {
            List<DetalleOrden> lobjRespuesta = new List<DetalleOrden>();
            List<modeloDetalleOrden> lobjRespuestaModelo = new List<modeloDetalleOrden>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {

                    if (srvWCF_CR.insDetalleOrden_ENT(pDetalleOrden))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recDetalleOrden_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloDetalleOrden objModeloDetalleOrden;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloDetalleOrden = new modeloDetalleOrden();
                            objModeloDetalleOrden.Id_Detalle = lcr.Id_Detalle;
                            objModeloDetalleOrden.Id_Orden = lcr.Id_Orden;
                            objModeloDetalleOrden.Id_producto = lcr.Id_producto;
                            objModeloDetalleOrden.Cantidad = lcr.Cantidad;
                            objModeloDetalleOrden.Mesa = lcr.Mesa;
                            objModeloDetalleOrden.Precio = lcr.Precio;
                            objModeloDetalleOrden.Tipo_orden = lcr.Tipo_orden;
                            objModeloDetalleOrden.Descripcion = lcr.Descripcion;
                            lobjRespuestaModelo.Add(objModeloDetalleOrden);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return RedirectToAction("listarDetalleOrden_ENT");
        }

        public ActionResult modificarDet_ENT(DetalleOrden pDetalleOrden)
        {
            List<DetalleOrden> lobjRespuesta = new List<DetalleOrden>();
            List<modeloDetalleOrden> lobjRespuestaModelo = new List<modeloDetalleOrden>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modDetalleOrden_ENT(pDetalleOrden))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recDetalleOrden_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloDetalleOrden objModeloDetalleOrden;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloDetalleOrden = new modeloDetalleOrden();
                            objModeloDetalleOrden.Id_Detalle = lcr.Id_Detalle;
                            objModeloDetalleOrden.Id_Orden = lcr.Id_Orden;
                            objModeloDetalleOrden.Id_producto = lcr.Id_producto;
                            objModeloDetalleOrden.Cantidad = lcr.Cantidad;
                            objModeloDetalleOrden.Mesa = lcr.Mesa;
                            objModeloDetalleOrden.Precio = lcr.Precio;
                            objModeloDetalleOrden.Tipo_orden = lcr.Tipo_orden;
                            objModeloDetalleOrden.Descripcion = lcr.Descripcion;
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return RedirectToAction("listarDetalleOrden_ENT");
        }

        public ActionResult eliminarDet_ENT(DetalleOrden pDetalleOrden)
        {
            List<DetalleOrden> lobjRespuesta = new List<DetalleOrden>();
            List<modeloDetalleOrden> lobjRespuestaModelo = new List<modeloDetalleOrden>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delDetalleOrden_ENT(pDetalleOrden))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recDetalleOrden_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloDetalleOrden objModeloDetalleOrden;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloDetalleOrden = new modeloDetalleOrden();
                            objModeloDetalleOrden.Id_Detalle = lcr.Id_Detalle;
                            objModeloDetalleOrden.Id_Orden = lcr.Id_Orden;
                            objModeloDetalleOrden.Id_producto = lcr.Id_producto;
                            objModeloDetalleOrden.Cantidad = lcr.Cantidad;
                            objModeloDetalleOrden.Mesa = lcr.Mesa;
                            objModeloDetalleOrden.Precio = lcr.Precio;
                            objModeloDetalleOrden.Tipo_orden = lcr.Tipo_orden;
                            objModeloDetalleOrden.Descripcion = lcr.Descripcion;
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return RedirectToAction("listarDetalleOrden_ENT");
        }

        //*********Procedimientos almacenados*********//
        public ActionResult listarDetalleOrden_PA()
        {
            List<recDetalleOrden_Result> lobjRespuesta = new List<recDetalleOrden_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recDetalleOrden_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult agregarDetalleOrden_PA()
        {
            return View();
        }

        public ActionResult modificarDetalleOrden_PA(int pId)
        {
            recDetalleOrdenxId_Result lobjRespuesta_PA = new recDetalleOrdenxId_Result();
            modeloDetalleOrden lobjRespuesta = new modeloDetalleOrden();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recDetalleOrdenXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Detalle = lobjRespuesta_PA.Id_Detalle;
                    lobjRespuesta.Id_Orden = lobjRespuesta_PA.Id_Orden;
                    lobjRespuesta.Id_producto = lobjRespuesta_PA.Id_producto;
                    lobjRespuesta.Cantidad = lobjRespuesta_PA.Cantidad;
                    lobjRespuesta.Mesa = lobjRespuesta_PA.Mesa;
                    lobjRespuesta.Precio = lobjRespuesta_PA.Precio;
                    lobjRespuesta.Tipo_orden = lobjRespuesta_PA.Tipo_orden;
                    lobjRespuesta.Descripcion = lobjRespuesta_PA.Descripcion;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult eliminarDetalleOrden_PA(int pId)
        {
            recDetalleOrdenxId_Result lobjRespuesta_PA = new recDetalleOrdenxId_Result();
            modeloDetalleOrden lobjRespuesta = new modeloDetalleOrden();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recDetalleOrdenXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Detalle = lobjRespuesta_PA.Id_Detalle;
                    lobjRespuesta.Id_Orden = lobjRespuesta_PA.Id_Orden;
                    lobjRespuesta.Id_producto = lobjRespuesta_PA.Id_producto;
                    lobjRespuesta.Cantidad = lobjRespuesta_PA.Cantidad;
                    lobjRespuesta.Mesa = lobjRespuesta_PA.Mesa;
                    lobjRespuesta.Precio = lobjRespuesta_PA.Precio;
                    lobjRespuesta.Tipo_orden = lobjRespuesta_PA.Tipo_orden;
                    lobjRespuesta.Descripcion = lobjRespuesta_PA.Descripcion;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detalleDetalleOrden_PA(int pId)
        {
            recDetalleOrdenxId_Result lobjRespuesta_PA = new recDetalleOrdenxId_Result();
            modeloDetalleOrden lobjRespuesta = new modeloDetalleOrden();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recDetalleOrdenXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Detalle = lobjRespuesta_PA.Id_Detalle;
                    lobjRespuesta.Id_Orden = lobjRespuesta_PA.Id_Orden;
                    lobjRespuesta.Id_producto = lobjRespuesta_PA.Id_producto;
                    lobjRespuesta.Cantidad = lobjRespuesta_PA.Cantidad;
                    lobjRespuesta.Mesa = lobjRespuesta_PA.Mesa;
                    lobjRespuesta.Precio = lobjRespuesta_PA.Precio;
                    lobjRespuesta.Tipo_orden = lobjRespuesta_PA.Tipo_orden;
                    lobjRespuesta.Descripcion = lobjRespuesta_PA.Descripcion;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }


        /*****Acciones procedimientos almacenados Ingredientes******/
        public ActionResult accionesPA(string enviarAccionPA, modeloDetalleOrden pModeloDetalleOrden)
        {
            try
            {
                DetalleOrden pDetalleOrden = new DetalleOrden();
                pDetalleOrden.Id_Detalle = pModeloDetalleOrden.Id_Detalle;
                pDetalleOrden.Id_Orden = pModeloDetalleOrden.Id_Orden;
                pDetalleOrden.Id_producto = pModeloDetalleOrden.Id_producto;
                pDetalleOrden.Cantidad = pModeloDetalleOrden.Cantidad;
                pDetalleOrden.Mesa = pModeloDetalleOrden.Mesa;
                pDetalleOrden.Precio = pModeloDetalleOrden.Precio;
                pDetalleOrden.Tipo_orden = pModeloDetalleOrden.Tipo_orden;
                pDetalleOrden.Descripcion = pModeloDetalleOrden.Descripcion;

                switch (enviarAccionPA)
                {
                    case "Agregar":
                        return insertarDeta_PA(pDetalleOrden);
                    case "Modificar":
                        return modificarDeta_PA(pDetalleOrden);
                    case "Eliminar":
                        return eliminarDeta_PA(pDetalleOrden);
                    default:
                        return RedirectToAction("listarDetalleOrden_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }


        public ActionResult insertarDeta_PA(DetalleOrden pDetalleOrden)
        {
            List<recDetalleOrden_Result> lobjRespuesta = new List<recDetalleOrden_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {

                    if (srvWCF_CR.insDetalleOrden_PA(pDetalleOrden))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recDetalleOrden_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarDetalleOrden_PA");
        }

        public ActionResult modificarDeta_PA(DetalleOrden pDetalleOrden)
        {
            List<recDetalleOrden_Result> lobjRespuesta = new List<recDetalleOrden_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modDetalleOrden_PA(pDetalleOrden))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recDetalleOrden_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarDetalleOrden_PA");
        }

        public ActionResult eliminarDeta_PA(DetalleOrden pDetalleOrden)
        {
            List<recDetalleOrden_Result> lobjRespuesta = new List<recDetalleOrden_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delDetalleOrden_PA(pDetalleOrden))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recDetalleOrden_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarDetalleOrden_PA");
        }
    }
}