using Entidades;
using MVCMuncheese.Models.ViewModels;
using MVCMuncheese.Models;
using MVCMuncheese.Controllers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesoDatos;

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
                    mesaSeleccionada = new MesaViewModel { NumeroMesa = resultado.Id_Mesa, nombreMesa = resultado.NombreMesa, Estado = resultado.Estado/*, EstadoMesa = estado */};

                    // Modificar el estado de la mesa a "Ocupado"
                    MesasController mesasController = new MesasController();
                    mesasController.modificarMesa_PA(new Mesas { Id_Mesa = mesaSeleccionada.NumeroMesa, NombreMesa = mesaSeleccionada.nombreMesa, Estado = 2 });


                    // Crear una nueva orden
                    var nuevaOrden = new Ordenes();


                    // Agregar la nueva orden a la base de datos
                    srvWCF_CR.insOrdenes_PAa(nuevaOrden);

                    // Obtener el último Id_Orden agregado

                    var ultimoIdOrden = srvWCF_CR.recOrdenes_PA().OrderByDescending(o => o.Id_Orden).FirstOrDefault().Id_Orden;

                    // Crear un modelo para la vista con el último Id_Orden y otros datos necesarios

                    var modeloDetalleOrden = new modeloDetalleOrden { Mesa = mesa, UltimoIdOrden = ultimoIdOrden };
                    srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient();
                    ViewBag.Tipo_Producto = new SelectList(db.recTipo_Producto_PA().ToList(), "Id_tipo_producto", "Nombre_tipo_pro");
                    var productos = db.recProductos_ENT().ToList();
                    modeloDetalleOrden.Productos = productos;
                    return View(modeloDetalleOrden);
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

        }


        public ActionResult DetalleOrdenCocina()
        {
            List<recDetalleOrdenConOrdenEstado1_Result> lobjRespuesta = new List<recDetalleOrdenConOrdenEstado1_Result>();
            List<modeloDetalleOrden> lobjDetalles = new List<modeloDetalleOrden>();  // Nuevo modelo

            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recDetalleOrdenEstado1_PA();

                    // Recorremos los detalles y cargamos el nombre del producto
                    foreach (var detalle in lobjRespuesta)
                    {
                        modeloDetalleOrden detalleNuevo = new modeloDetalleOrden();
                        detalleNuevo.Id_Orden = detalle.Id_Orden;
                        detalleNuevo.Id_producto = detalle.Id_producto;
                        detalleNuevo.Cantidad = detalle.Cantidad;
                        detalleNuevo.Tipo_orden = detalle.Tipo_orden;
                        detalleNuevo.Descripcion = detalle.Descripcion;


                        // Cargamos el nombre del producto
                        detalleNuevo.Nombre_producto = srvWCF_CR.recProductos_ENT().FirstOrDefault(x => x.Id_producto == detalle.Id_producto)?.Nombre;

                        lobjDetalles.Add(detalleNuevo);
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return View(lobjDetalles);  // Devolvemos la lista de detalles con el nuevo modelo
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

        //agrega una nueva orden
            public void insOrden_PA(Ordenes pOrdenes)
            {
                List<recOrdenes_Result> lobjRespuesta = new List<recOrdenes_Result>();
                try
                {
                        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                    {
                        if (srvWCF_CR.insOrdenes_PAa(pOrdenes))
                        {
                            //enviar mensaje positivo
                        }
                        else
                        {

                        }
                        {
                            //enviar mensaje negativo
                        }
                        lobjRespuesta = srvWCF_CR.recOrdenes_PA();
                    }
                }
                catch (Exception lEx)
                {
                    throw lEx;
                }
                //return RedirectToAction("listarOrdenes_ENT");
            }


        //*********Procedimientos almacenados*********//
        public ActionResult listarDetalleOrden_PA()
        {
            List<recDetalleOrden_Result> lobjRespuesta = new List<recDetalleOrden_Result>();
            List<modeloDetalleOrden> lobjDetalles = new List<modeloDetalleOrden>();  // Nuevo modelo

            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recDetalleOrden_PA();

                    // Recorremos los detalles y cargamos el nombre del producto
                    foreach (var detalle in lobjRespuesta)
                    {
                        modeloDetalleOrden detalleNuevo = new modeloDetalleOrden();
                        detalleNuevo.Id_Detalle = detalle.Id_Detalle;
                        detalleNuevo.Id_Orden = detalle.Id_Orden;
                        detalleNuevo.Id_producto = detalle.Id_producto;
                        detalleNuevo.Cantidad = detalle.Cantidad;
                        detalleNuevo.Mesa = detalle.Mesa;
                        detalleNuevo.Precio = detalle.Precio;
                        detalleNuevo.Tipo_orden = detalle.Tipo_orden;
                        detalleNuevo.Descripcion = detalle.Descripcion;


                        // Cargamos el nombre del producto
                        detalleNuevo.Nombre_producto = srvWCF_CR.recProductos_ENT().FirstOrDefault(x => x.Id_producto == detalle.Id_producto)?.Nombre;

                        lobjDetalles.Add(detalleNuevo);
                    }
                }
            }
                catch (Exception lEx)
                {
                    throw lEx;
                }

                return View(lobjDetalles);  // Devolvemos la lista de detalles con el nuevo modelo

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

       
        public ActionResult accionesPAA(string enviarAccionPA, List<DetalleOrden> datosOrdenes)
        {
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    foreach (DetalleOrden pDetalleOrden in datosOrdenes)
                    {
                        switch (enviarAccionPA)
                        {
                            case "Agregar":
                                insertarDetal_PA(pDetalleOrden);
                                break;

                            default:
                                return RedirectToAction("Mesas", "Mesas");
                        }
                    }
                }

                // enviar mensaje de éxito
                TempData["mensaje"] = "La orden se ha agregado correctamente.";
            }
            catch (Exception lEx)
            {
                throw lEx;
                //// enviar mensaje de error
                //TempData["mensajeError"] = "Error al agregar la orden.";
            }

            return RedirectToAction("Mesas", "Mesas");
        }

        public ActionResult insertarDetal_PA(DetalleOrden pDetalleOrden)
        {
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    // buscar el registro en la base de datos
                    var detalleExistente = srvWCF_CR.recDetalleOrden_PA()
                        .FirstOrDefault(d => d.Id_producto == pDetalleOrden.Id_producto && d.Id_Orden == pDetalleOrden.Id_Orden);

                    if (detalleExistente == null)
                    {
                        // el registro no existe en la base de datos, agregarlo
                        if (srvWCF_CR.insDetalleOrden_PA(pDetalleOrden))
                        {
                            //enviar mensaje positivo
                        }
                        else
                        {
                            //enviar mensaje negativo
                        }
                    }
                    else
                    {
                        // el registro ya existe en la base de datos, no hacer nada
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("Mesas", "Mesas");
        }



        /*****Acciones procedimientos almacenados DetalleOrden******/
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

        [HttpGet]
        public ActionResult insertarDetall_PA(DetalleOrden pDetalleOrden)
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
            return Json(new { success = true });
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
            return RedirectToAction("Mesas", "Mesas");
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