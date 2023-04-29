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

        /*****Acciones procedimientos almacenados Ordenes******/

        public ActionResult listarOrdenes_PA()
        {
            List<recOrdenes_Result> lobjRespuesta = new List<recOrdenes_Result>();
            List<modeloOrdenes> lobjModelos = new List<modeloOrdenes>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recOrdenes_PA();

                    // Convertir cada elemento de la lista a un modelo modeloOrdenes
                    foreach (var item in lobjRespuesta)
                    {
                        modeloOrdenes modelo = new modeloOrdenes();
                        modelo.Id_Orden = item.Id_Orden;
                        modelo.Estado = item.Estado;
                        modelo.Fecha = (DateTime)item.Fecha;

                        // Llamar al procedimiento almacenado "recEstadoXId_PA" para obtener el nombre del estado correspondiente al ID de estado
                        var Estado = srvWCF_CR.recEstadoXId_PA((int)item.Estado);
                        modelo.Nombre_estado = Estado.Estado;

                        lobjModelos.Add(modelo);
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lobjModelos);
        }



        public ActionResult agregarOrdenes_PA()
        {
            return View();
        }

        public ActionResult modificarOrdenes_PA(int pId)
        {
            recOrdenxId_Result lobjRespuesta_PA = new recOrdenxId_Result();
            modeloOrdenes lobjRespuesta = new modeloOrdenes();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recOrdenesXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Orden = lobjRespuesta_PA.Id_Orden;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                    lobjRespuesta.Fecha = (DateTime)lobjRespuesta_PA.Fecha;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult eliminarOrdenes_PA(int pId)
        {
            recOrdenxId_Result lobjRespuesta_PA = new recOrdenxId_Result();
            modeloOrdenes lobjRespuesta = new modeloOrdenes();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recOrdenesXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Orden = lobjRespuesta_PA.Id_Orden;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                    lobjRespuesta.Fecha = (DateTime)lobjRespuesta_PA.Fecha;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detalleOrdenes_PA(int pId)
        {
            recOrdenxId_Result lobjRespuesta_PA = new recOrdenxId_Result();
            modeloOrdenes lobjRespuesta = new modeloOrdenes();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recOrdenesXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Orden = lobjRespuesta_PA.Id_Orden;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                    lobjRespuesta.Fecha = (DateTime)lobjRespuesta_PA.Fecha;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }


        /*****Acciones procedimientos almacenados Ordenes******/
        public ActionResult accionesPA(string enviarAccion, modeloOrdenes pModeloOrdenes)
        {
            try
            {
                Ordenes pOrdenes = new Ordenes();
                pOrdenes.Id_Orden = pModeloOrdenes.Id_Orden;
                pOrdenes.Fecha = pModeloOrdenes.Fecha;
                pOrdenes.Estado = pModeloOrdenes.Estado;


                switch (enviarAccion)
                {
                    case "Agregar":
                        insOrden_PA(pOrdenes);
                        ViewBag.Mensaje = "La orden ha sido agregada satisfactoriamente";
                        break;
                    default:
                        ViewBag.Mensaje = "Ocurrió un error al realizar la acción solicitada";
                        break;

                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View();
        }


        public /*ActionResult*/ void insOrden_PA(Ordenes pOrdenes)
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


        public ActionResult accionesPAa(string enviarAccion, modeloOrdenes pModeloOrdenes)
        {
            try
            {
                Ordenes pOrdenes = new Ordenes();
                pOrdenes.Id_Orden = pModeloOrdenes.Id_Orden;
                pOrdenes.Estado = pModeloOrdenes.Estado;
                pOrdenes.Fecha = pModeloOrdenes.Fecha;


                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarOrden_PA(pOrdenes);

                    case "Modificar":
                        return modificarOrden_PA(pOrdenes);
                    case "Eliminar":
                        return eliminarOrden_PA(pOrdenes);
                    default:
                        return RedirectToAction("listarOrdenes_PA");
                }

            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarOrden_PA(Ordenes pOrdenes)
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
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recOrdenes_PA();

                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarOrdenes_PA", lobjRespuesta);
        }

        public ActionResult modificarOrden_PA(Ordenes pOrdenes)
        {
            List<recOrdenes_Result> lobjRespuesta = new List<recOrdenes_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modOrdenes_PA(pOrdenes))
                    {
                        //enviar mensaje positivo
                    }
                    else
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
            return View("listarOrdenes_PA", lobjRespuesta);
        }

        public ActionResult eliminarOrden_PA(Ordenes pOrdenes)
        {
            List<recOrdenes_Result> lobjRespuesta = new List<recOrdenes_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modOrdenes_PA(pOrdenes))
                    {
                        //enviar mensaje positivo
                    }
                    else
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
            return View("listarOrdenes_PA", lobjRespuesta);
        }


        //*********ENTIDADES*********//
        public JsonResult listarOrdenesJson()
        {
            List<Ordenes> lobjRespuesta = new List<Ordenes>();
            List<modeloOrdenes> lobjRespuestaModelo = new List<modeloOrdenes>();
            List<modeloEstado> lobjEstados = new List<modeloEstado>();

            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recOrdenes_ENT();
                    lobjEstados = srvWCF_CR.recEstado_PA().Select(x => new modeloEstado() { Id_Estado = x.Id_Estado, Estado = x.Estado }).ToList();

                    if (lobjRespuesta.Count > 0)
                    {
                        modeloOrdenes objModeloOrdenes;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloOrdenes = new modeloOrdenes();
                            objModeloOrdenes.Id_Orden = lcr.Id_Orden;
                            objModeloOrdenes.Estado = lcr.Estado;
                            objModeloOrdenes.Fecha = (DateTime)lcr.Fecha;

                            var estado = lobjEstados.FirstOrDefault(x => x.Id_Estado == lcr.Estado);
                            objModeloOrdenes.Nombre_estado = estado != null ? estado.Estado : "";

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

            return Json(lobjRespuestaModelo, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 0, VaryByParam = "none")]

        public ActionResult listarOrdenes_ENT()
        {
            List<recOrdenes_Result> lobjRespuesta = new List<recOrdenes_Result>();
            List<modeloOrdenes> lobjRespuestaModelo = new List<modeloOrdenes>();
            List<modeloEstado> lobjEstados = new List<modeloEstado>();  // Nueva lista de estados
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recOrdenes_PA();
                    // Encuentra el estado más reciente
                    int estadoReciente = (int)lobjRespuesta.Max(x => x.Estado);

                    // Filtra las órdenes para obtener solo aquellas con el estado más reciente
                    lobjRespuesta = lobjRespuesta.Where(x => x.Estado == estadoReciente).ToList();

                    // Cargamos la lista de estados
                    lobjEstados = srvWCF_CR.recEstado_PA().Select(x => new modeloEstado() { Id_Estado = x.Id_Estado, Estado = x.Estado }).ToList();
                    
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloOrdenes objModeloOrdenes;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloOrdenes = new modeloOrdenes();
                            objModeloOrdenes.Id_Orden = lcr.Id_Orden;
                            objModeloOrdenes.Estado = lcr.Estado;
                            objModeloOrdenes.Fecha = (DateTime)lcr.Fecha;

                            // Cargamos el nombre del estado
                            var estado = lobjEstados.FirstOrDefault(x => x.Id_Estado == lcr.Estado);
                            objModeloOrdenes.Nombre_estado = estado != null ? estado.Estado : "";

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
        public JsonResult insertarOrde_ENT(int Id_Orden,  int Id_Estado, DateTime Fecha)
        {
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    srvWCF_CR.insOrdenes_ENT(new Ordenes
                    {
                        Id_Orden = Id_Orden,
                        Estado = Id_Estado,
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