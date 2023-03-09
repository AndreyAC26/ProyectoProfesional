using Entidades;
using MVCMuncheese.Models;
using MVCMuncheese.Models.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesoDatos;


namespace MVCMuncheese.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            List<TablaViewModel> lst = null;
            using (CapaEntidades db = new CapaEntidades())
            {
                 lst = (from d in db.Tipo_Producto
                    select new TablaViewModel
                    {
                        Id_tipo_Producto = d.Id_tipo_Producto,
                        Nombre_tipo_pro = d.Nombre_tipo_pro
                    }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre_tipo_pro.ToString(),
                    Value = d.Id_tipo_Producto.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;

                return View();
        }





        //*********ENTIDADES*********//
        public ActionResult listarProductos_ENT()
        {
            List<Productos> lobjRespuesta = new List<Productos>();
            List<modeloProductos> lobjRespuestaModelo = new List<modeloProductos>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recProductos_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloProductos objModeloProductos;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloProductos = new modeloProductos();
                            objModeloProductos.Id_producto = lcr.Id_producto;
                            objModeloProductos.Nombre = lcr.Nombre;
                            objModeloProductos.Tipo_producto = lcr.Tipo_producto;
                            objModeloProductos.Precio = lcr.Precio;
                            objModeloProductos.Descripcion = lcr.Descripcion;
                            lobjRespuestaModelo.Add(objModeloProductos);
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
        public ActionResult agregarProducto_ENT()
        {
            List<TablaViewModel> lst = null;
            using (CapaEntidades db = new CapaEntidades())
            {
                lst = (from d in db.Tipo_Producto
                       select new TablaViewModel
                       {
                           Id_tipo_Producto = d.Id_tipo_Producto,
                           Nombre_tipo_pro = d.Nombre_tipo_pro
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre_tipo_pro.ToString(),
                    Value = d.Id_tipo_Producto.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;

            return View();
        }

        public ActionResult agregarProductos_ENT()
        {

            return View();
        }

        public ActionResult modificarProductos_ENT(int pId)
        {
            Productos lobjRespuesta = new Productos();
            modeloProductos lobjModeloProductos;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recProductosXId_ENT(pId);
                    lobjModeloProductos = new modeloProductos();
                    lobjModeloProductos.Id_producto = lobjRespuesta.Id_producto;
                    lobjModeloProductos.Nombre = lobjRespuesta.Nombre;
                    lobjModeloProductos.Tipo_producto = lobjRespuesta.Tipo_producto;
                    lobjModeloProductos.Precio = lobjRespuesta.Precio;
                    lobjModeloProductos.Descripcion = lobjRespuesta.Descripcion;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloProductos);
        }

        public ActionResult eliminarProductos_ENT(int pId)
        {
            Productos lobjRespuesta = new Productos();
            modeloProductos lobjModeloProductos;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recProductosXId_ENT(pId);
                    lobjModeloProductos = new modeloProductos();
                    lobjModeloProductos.Id_producto = lobjRespuesta.Id_producto;
                    lobjModeloProductos.Nombre = lobjRespuesta.Nombre;
                    lobjModeloProductos.Tipo_producto = lobjRespuesta.Tipo_producto;
                    lobjModeloProductos.Precio = lobjRespuesta.Precio;
                    lobjModeloProductos.Descripcion = lobjRespuesta.Descripcion;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloProductos);
        }

        public ActionResult detalleProductos_ENT(int pId)
        {
            Productos lobjRespuesta = new Productos();
            modeloProductos lobjModeloProductos;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recProductosXId_ENT(pId);
                    lobjModeloProductos = new modeloProductos();
                    lobjModeloProductos.Id_producto = lobjRespuesta.Id_producto;
                    lobjModeloProductos.Nombre = lobjRespuesta.Nombre;
                    lobjModeloProductos.Tipo_producto = lobjRespuesta.Tipo_producto;
                    lobjModeloProductos.Precio = lobjRespuesta.Precio;
                    lobjModeloProductos.Descripcion = lobjRespuesta.Descripcion;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloProductos);
        }


        /*****Acciones entidades Productos******/
        public ActionResult accionesEntidades(string enviarAccion, modeloProductos pModeloProductos)
        {
            Productos pProductos = new Productos();
            pProductos.Id_producto = pModeloProductos.Id_producto;
            pProductos.Nombre = pModeloProductos.Nombre;
            pProductos.Tipo_producto = pModeloProductos.Tipo_producto;
            pProductos.Precio = pModeloProductos.Precio;
            pProductos.Descripcion = pModeloProductos.Descripcion;
            // Obtener el id del tipo de producto seleccionado
            int Id_tipo_producto = -1;
            int.TryParse(pModeloProductos.Tipo_producto.ToString(), out Id_tipo_producto);
            pProductos.Tipo_producto = Id_tipo_producto;

            switch (enviarAccion)
            {
                case "Agregar":
                    return insertarPro_ENT(pProductos);
                case "Modificar":
                    return modificarPro_ENT(pProductos);
                case "Eliminar":
                    return eliminarPro_ENT(pProductos);
                default:
                    return RedirectToAction("listarProductos_ENT");
            }
        }

        public ActionResult insertarPro_ENT(Productos pProductos)
        {
            List<Productos> lobjRespuesta = new List<Productos>();
            List<modeloProductos> lobjRespuestaModelo = new List<modeloProductos>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insProductos_ENT(pProductos))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recProductos_ENT();
                    if (lobjRespuesta.Count > 0) 
                    {
                        modeloProductos objModeloProductos;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloProductos = new modeloProductos();
                            objModeloProductos.Id_producto = lcr.Id_producto;
                            objModeloProductos.Nombre = lcr.Nombre;
                            objModeloProductos.Tipo_producto = lcr.Tipo_producto;
                            objModeloProductos.Precio = lcr.Precio;
                            objModeloProductos.Descripcion = lcr.Descripcion;
                            lobjRespuestaModelo.Add(objModeloProductos);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return View("listarProductos_ENT", lobjRespuestaModelo);
        }

        public ActionResult modificarPro_ENT(Productos pProductos)
        {
            List<Productos> lobjRespuesta = new List<Productos>();
            List<modeloProductos> lobjRespuestaModelo = new List<modeloProductos>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modProductos_ENT(pProductos))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recProductos_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloProductos objModeloProductos;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloProductos = new modeloProductos();
                            objModeloProductos.Id_producto = lcr.Id_producto;
                            objModeloProductos.Nombre = lcr.Nombre;
                            objModeloProductos.Tipo_producto = lcr.Tipo_producto;
                            objModeloProductos.Precio = lcr.Precio;
                            objModeloProductos.Descripcion = lcr.Descripcion;
                            lobjRespuestaModelo.Add(objModeloProductos);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return View("listarProductos_ENT", lobjRespuestaModelo);
        }

        public ActionResult eliminarPro_ENT(Productos pProductos)
        {
            List<Productos> lobjRespuesta = new List<Productos>();
            List<modeloProductos> lobjRespuestaModelo = new List<modeloProductos>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delProductos_ENT(pProductos))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recProductos_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloProductos objModeloProductos;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloProductos = new modeloProductos();
                            objModeloProductos.Id_producto = lcr.Id_producto;
                            objModeloProductos.Nombre = lcr.Nombre;
                            objModeloProductos.Tipo_producto = lcr.Tipo_producto;
                            objModeloProductos.Precio = lcr.Precio;
                            objModeloProductos.Descripcion = lcr.Descripcion;
                            lobjRespuestaModelo.Add(objModeloProductos);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return View("listarProductos_ENT", lobjRespuestaModelo);
        }


        //*********Procedimientos almacenados*********//
        //public ActionResult listarProductos_PA()
        //{
        //    List<recProductos_Result> lobjRespuesta = new List<recProductos_Result>();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            lobjRespuesta = srvWCF_CR.recProductos_PA();
        //        }
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return View(lobjRespuesta);
        //}

        //public ActionResult agregarProductos_PA()
        //{
        //    return View();
        //}

        //public ActionResult modificarProductos_PA(int pId)
        //{
        //    recProductosxId_Result lobjRespuesta_PA = new recProductosxId_Result();
        //    modeloProductos lobjRespuesta = new modeloProductos();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            lobjRespuesta_PA = srvWCF_CR.recProductosXId_PA(pId);
        //        }
        //        if (lobjRespuesta_PA != null)
        //        {
        //            lobjRespuesta.Id_producto = lobjRespuesta_PA.Id_producto;
        //            lobjRespuesta.Nombre = lobjRespuesta_PA.Nombre;
        //            lobjRespuesta.Precio = lobjRespuesta_PA.Precio;
        //            lobjRespuesta.Descripcion = lobjRespuesta_PA.Descripcion;

        //        }
        //    }
        //    catch (Exception lEx)
        //    {

        //        throw lEx;
        //    }
        //    return View(lobjRespuesta);
        //}

        //public ActionResult eliminarProductos_PA(int pId)
        //{
        //    recProductosxId_Result lobjRespuesta_PA = new recProductosxId_Result();
        //    modeloProductos lobjRespuesta = new modeloProductos();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            lobjRespuesta_PA = srvWCF_CR.recProductosXId_PA(pId);
        //        }
        //        if (lobjRespuesta_PA != null)
        //        {
        //            lobjRespuesta.Id_producto = lobjRespuesta_PA.Id_producto;
        //            lobjRespuesta.Nombre = lobjRespuesta_PA.Nombre;
        //            lobjRespuesta.Precio = lobjRespuesta_PA.Precio;
        //            lobjRespuesta.Descripcion = lobjRespuesta_PA.Descripcion;

        //        }
        //    }
        //    catch (Exception lEx)
        //    {

        //        throw lEx;
        //    }
        //    return View(lobjRespuesta);
        //}

        //public ActionResult detalleProductos_PA(int pId)
        //{
        //    recProductosxId_Result lobjRespuesta_PA = new recProductosxId_Result();
        //    modeloProductos lobjRespuesta = new modeloProductos();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            lobjRespuesta_PA = srvWCF_CR.recProductosXId_PA(pId);
        //        }
        //        if (lobjRespuesta_PA != null)
        //        {
        //            lobjRespuesta.Id_producto = lobjRespuesta_PA.Id_producto;
        //            lobjRespuesta.Nombre = lobjRespuesta_PA.Nombre;
        //            lobjRespuesta.Precio = lobjRespuesta_PA.Precio;
        //            lobjRespuesta.Descripcion = lobjRespuesta_PA.Descripcion;

        //        }
        //    }
        //    catch (Exception lEx)
        //    {

        //        throw lEx;
        //    }
        //    return View(lobjRespuesta);
        //}
    }
}