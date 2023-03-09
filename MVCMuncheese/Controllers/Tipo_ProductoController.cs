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
    public class Tipo_ProductoController : Controller
    {
        // GET: Tipo_Producto

        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        //*********ENTIDADES*********//
        public ActionResult listarTipo_Producto_ENT()
        {
            List<Entidades.Tipo_Producto> lobjRespuesta = new List<Entidades.Tipo_Producto>();
            List<modeloTipo_Producto> lobjRespuestaModelo = new List<modeloTipo_Producto>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recTipo_Producto_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloTipo_Producto objModeloTipo_Producto;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloTipo_Producto = new modeloTipo_Producto();
                            objModeloTipo_Producto.Id_tipo_Producto = lcr.Id_tipo_Producto;
                            objModeloTipo_Producto.Nombre_tipo_pro = lcr.Nombre_tipo_pro;
                            lobjRespuestaModelo.Add(objModeloTipo_Producto);
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

        public ActionResult agregarTipo_Producto_ENT()
        {
            return View();
        }

        public ActionResult modificarTipo_Producto_ENT(int pId)
        {
            Entidades.Tipo_Producto lobjRespuesta = new Entidades.Tipo_Producto();
            modeloTipo_Producto lobjModeloTipo_Producto;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recTipo_ProductoXId_ENT(pId);
                    lobjModeloTipo_Producto = new modeloTipo_Producto();
                    lobjModeloTipo_Producto.Id_tipo_Producto = lobjRespuesta.Id_tipo_Producto;
                    lobjModeloTipo_Producto.Nombre_tipo_pro = lobjRespuesta.Nombre_tipo_pro;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloTipo_Producto);
        }

        public ActionResult eliminarTipo_Producto_ENT(int pId)
        {
            Entidades.Tipo_Producto lobjRespuesta = new Entidades.Tipo_Producto();
            modeloTipo_Producto lobjModeloTipo_Producto;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recTipo_ProductoXId_ENT(pId);
                    lobjModeloTipo_Producto = new modeloTipo_Producto();
                    lobjModeloTipo_Producto.Id_tipo_Producto = lobjRespuesta.Id_tipo_Producto;
                    lobjModeloTipo_Producto.Nombre_tipo_pro = lobjRespuesta.Nombre_tipo_pro;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloTipo_Producto);
        }

        public ActionResult detalleTipo_Producto_ENT(int pId)
        {
            Entidades.Tipo_Producto lobjRespuesta = new Entidades.Tipo_Producto();
            modeloTipo_Producto lobjModeloTipo_Producto;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recTipo_ProductoXId_ENT(pId);
                    lobjModeloTipo_Producto = new modeloTipo_Producto();
                    lobjModeloTipo_Producto.Id_tipo_Producto = lobjRespuesta.Id_tipo_Producto;
                    lobjModeloTipo_Producto.Nombre_tipo_pro = lobjRespuesta.Nombre_tipo_pro;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloTipo_Producto);
        }

        /*****Acciones entidades******/
        public ActionResult accionesEntidades(string enviarAccion, modeloTipo_Producto pModeloTipo_Producto)
        {
            Entidades.Tipo_Producto pTipo_Producto = new Entidades.Tipo_Producto();
            pTipo_Producto.Id_tipo_Producto = pModeloTipo_Producto.Id_tipo_Producto;
            pTipo_Producto.Nombre_tipo_pro = pModeloTipo_Producto.Nombre_tipo_pro;

            switch (enviarAccion)
            {
                case "Agregar":
                    return insertarTipo_Producto_ENT(pTipo_Producto);
                case "Modificar":
                    return modificarTipo_Producto_ENTIDAD(pTipo_Producto);
                case "Eliminar":
                    return eliminarTipo_Producto_ENTIDAD(pTipo_Producto);
                default:
                    return RedirectToAction("listarTipo_Producto_ENT");
            }
        }

        public ActionResult insertarTipo_Producto_ENT(Entidades.Tipo_Producto pTipo_Producto)
        {
            List<Entidades.Tipo_Producto> lobjRespuesta = new List<Entidades.Tipo_Producto>();
            List<modeloTipo_Producto> lobjRespuestaModelo = new List<modeloTipo_Producto>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insTipo_Producto_ENT(pTipo_Producto))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recTipo_Producto_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloTipo_Producto objModeloTipo_Producto;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloTipo_Producto = new modeloTipo_Producto();
                            objModeloTipo_Producto.Id_tipo_Producto = lcr.Id_tipo_Producto;
                            objModeloTipo_Producto.Nombre_tipo_pro = lcr.Nombre_tipo_pro;
                            lobjRespuestaModelo.Add(objModeloTipo_Producto);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return View("listarTipo_Producto_ENT", lobjRespuestaModelo);
        }

        public ActionResult modificarTipo_Producto_ENTIDAD(Entidades.Tipo_Producto pTipo_Producto)
        {
            List<Entidades.Tipo_Producto> lobjRespuesta = new List<Entidades.Tipo_Producto>();
            List<modeloTipo_Producto> lobjRespuestaModelo = new List<modeloTipo_Producto>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modTipo_Producto_ENT(pTipo_Producto))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recTipo_Producto_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloTipo_Producto objModeloTipo_Producto;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloTipo_Producto = new modeloTipo_Producto();
                            objModeloTipo_Producto.Id_tipo_Producto = lcr.Id_tipo_Producto;
                            objModeloTipo_Producto.Nombre_tipo_pro = lcr.Nombre_tipo_pro;
                            lobjRespuestaModelo.Add(objModeloTipo_Producto);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return View("listarTipo_Producto_ENT", lobjRespuestaModelo);
        }

        public ActionResult eliminarTipo_Producto_ENTIDAD(Entidades.Tipo_Producto pTipo_Producto)
        {
            List<Entidades.Tipo_Producto> lobjRespuesta = new List<Entidades.Tipo_Producto>();
            List<modeloTipo_Producto> lobjRespuestaModelo = new List<modeloTipo_Producto>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delTipo_Producto_ENT(pTipo_Producto))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recTipo_Producto_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloTipo_Producto objModeloTipo_Producto;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloTipo_Producto = new modeloTipo_Producto();
                            objModeloTipo_Producto.Id_tipo_Producto = lcr.Id_tipo_Producto;
                            objModeloTipo_Producto.Nombre_tipo_pro = lcr.Nombre_tipo_pro;
                            lobjRespuestaModelo.Add(objModeloTipo_Producto);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return View("listarTipo_Producto_ENT", lobjRespuestaModelo);
        }

        //*********Procedimientos almacenados*********//
        //public ActionResult listarTipo_Producto_PA()
        //{
        //    List<recTipo_Producto_Result> lobjRespuesta = new List<recTipo_Producto_Result>();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            lobjRespuesta = srvWCF_CR.recTipo_Producto_PA();
        //        }
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return View(lobjRespuesta);
        //}

        //public ActionResult agregarTipo_Producto_PA()
        //{
        //    return View();
        //}

        //public ActionResult modificarTipo_Producto_PA(int pId)
        //{
        //    recTipo_ProductoxId_Result lobjRespuesta_PA = new recTipo_ProductoxId_Result();
        //    modeloTipo_Producto lobjRespuesta = new modeloTipo_Producto();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            lobjRespuesta_PA = srvWCF_CR.recTipo_ProductoXId_PA(pId);
        //        }
        //        if (lobjRespuesta_PA != null)
        //        {
        //            lobjRespuesta.Id_tipo_Producto = lobjRespuesta_PA.Id_tipo_Producto;
        //            lobjRespuesta.Nombre_tipo_pro = lobjRespuesta_PA.Nombre_tipo_pro;
        //        }
        //    }
        //    catch (Exception lEx)
        //    {

        //        throw lEx;
        //    }
        //    return View(lobjRespuesta);
        //}

        //public ActionResult eliminarTipo_Producto_PA(int pId)
        //{
        //    recTipo_ProductoxId_Result lobjRespuesta_PA = new recTipo_ProductoxId_Result();
        //    modeloTipo_Producto lobjRespuesta = new modeloTipo_Producto();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            lobjRespuesta_PA = srvWCF_CR.recTipo_ProductoXId_PA(pId);
        //        }
        //        if (lobjRespuesta_PA != null)
        //        {
        //            lobjRespuesta.Id_tipo_Producto = lobjRespuesta_PA.Id_tipo_Producto;
        //            lobjRespuesta.Nombre_tipo_pro = lobjRespuesta_PA.Nombre_tipo_pro;
        //        }
        //    }
        //    catch (Exception lEx)
        //    {

        //        throw lEx;
        //    }
        //    return View(lobjRespuesta);
        //}

        //public ActionResult detalleTipo_Producto_PA(int pId)
        //{
        //    recTipo_ProductoxId_Result lobjRespuesta_PA = new recTipo_ProductoxId_Result();
        //    modeloTipo_Producto lobjRespuesta = new modeloTipo_Producto();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            lobjRespuesta_PA = srvWCF_CR.recTipo_ProductoXId_PA(pId);
        //        }
        //        if (lobjRespuesta_PA != null)
        //        {
        //            lobjRespuesta.Id_tipo_Producto = lobjRespuesta_PA.Id_tipo_Producto;
        //            lobjRespuesta.Nombre_tipo_pro = lobjRespuesta_PA.Nombre_tipo_pro;
        //        }
        //    }
        //    catch (Exception lEx)
        //    {

        //        throw lEx;
        //    }
        //    return View(lobjRespuesta);
        //}

        ///*****Acciones procedimientos almacenados Tipo Producto******/

        //public ActionResult accionesPA(string enviarAccionPA, modeloTipo_Producto pModeloTipo_Producto)
        //{
        //    try
        //    {
        //        Tipo_Producto pTipo_Producto = new Tipo_Producto();
        //        pTipo_Producto.Id_tipo_Producto = pModeloTipo_Producto.Id_tipo_Producto;
        //        pTipo_Producto.Nombre_tipo_pro = pModeloTipo_Producto.Nombre_tipo_pro;

        //        switch (enviarAccionPA)
        //        {
        //            case "Agregar":
        //                return insertarTipo_Producto_PA(pTipo_Producto);
        //            case "Modificar":
        //                return modificarTipo_Producto_PA(pTipo_Producto);
        //            case "Eliminar":
        //                return eliminarTipo_Producto_PA(pTipo_Producto);
        //            default:
        //                return RedirectToAction("listarTipo_Producto_PA");
        //        }
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //}

        //public ActionResult insertarTipo_Producto_PA(Tipo_Producto pTipo_Producto)
        //{
        //    List<recTipo_Producto_Result> lobjRespuesta = new List<recTipo_Producto_Result>();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            if (srvWCF_CR.insTipo_Producto_PA(pTipo_Producto))
        //            {
        //                //enviar mensaje positivo
        //            }
        //            else
        //            {
        //                //enviar mensaje negativo
        //            }
        //            lobjRespuesta = srvWCF_CR.recTipo_Producto_PA();
        //        }
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return View("listarTipo_Productos_PA", lobjRespuesta);
        //}

        //public ActionResult modificarTipo_Producto_PA(Tipo_Producto pTipo_Producto)
        //{
        //    List<recTipo_Producto_Result> lobjRespuesta = new List<recTipo_Producto_Result>();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            if (srvWCF_CR.insTipo_Producto_PA(pTipo_Producto))
        //            {
        //                //enviar mensaje positivo
        //            }
        //            else
        //            {
        //                //enviar mensaje negativo
        //            }
        //            lobjRespuesta = srvWCF_CR.recTipo_Producto_PA();
        //        }
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return View("listarTipo_Producto_ENT", lobjRespuesta);
        //}

        //public ActionResult eliminarTipo_Producto_PA(Tipo_Producto pTipo_Producto)
        //{
        //    List<recTipo_Producto_Result> lobjRespuesta = new List<recTipo_Producto_Result>();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            if (srvWCF_CR.insTipo_Producto_PA(pTipo_Producto))
        //            {
        //                //enviar mensaje positivo
        //            }
        //            else
        //            {
        //                //enviar mensaje negativo
        //            }
        //            lobjRespuesta = srvWCF_CR.recTipo_Producto_PA();
        //        }
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return View("listarTipo_Producto_ENT", lobjRespuesta);
        //}
    }
}