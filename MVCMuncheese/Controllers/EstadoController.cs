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
    public class EstadoController : Controller
    {
        // GET: Estado
        
          private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        //*********Procedimientos almacenados*********//
        public ActionResult listarEstado_PA()
        {
            List<recEstados_Result> lobjRespuesta = new List<recEstados_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recEstado_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult agregarEstado_PA()
        {
            return View();
        }

        public ActionResult modificarEstado_PA(int pId)
        {
            recEstadoxId_Result lobjRespuesta_PA = new recEstadoxId_Result();
            modeloEstado lobjRespuesta = new modeloEstado();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recEstadoXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Estado = lobjRespuesta_PA.Id_Estado;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult eliminarEstado_PA(int pId)
        {
            recEstadoxId_Result lobjRespuesta_PA = new recEstadoxId_Result();
            modeloEstado lobjRespuesta = new modeloEstado();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recEstadoXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Estado = lobjRespuesta_PA.Id_Estado;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detalleEstado_PA(int pId)
        {
            recEstadoxId_Result lobjRespuesta_PA = new recEstadoxId_Result();
            modeloEstado lobjRespuesta = new modeloEstado();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recEstadoXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Estado = lobjRespuesta_PA.Id_Estado;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }


        /*****Acciones procedimientos almacenados Estado******/
        public ActionResult accionesPA(string enviarAccion, modeloEstado pModeloEstado)
        {
            try
            {
                Estado pEstado = new Estado();
                pEstado.Id_Estado = pModeloEstado.Id_Estado;
                pEstado.Estado1 = pModeloEstado.Estado;

                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarEstados_PA(pEstado);
                    case "Modificar":
                        return modificarEstados_PA(pEstado);
                    case "Eliminar":
                        return eliminarEstados_PA(pEstado);
                    default:
                        return RedirectToAction("listarEstado_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarEstados_PA(Estado pEstado)
        {
            List<recEstados_Result> lobjRespuesta = new List<recEstados_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insEstado_PA(pEstado))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recEstado_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarEstado_PA", lobjRespuesta);
        }

        public ActionResult modificarEstados_PA(Estado pEstado)
        {
            List<recEstados_Result> lobjRespuesta = new List<recEstados_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modEstado_PA(pEstado))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recEstado_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarEstado_PA", lobjRespuesta);
        }

        public ActionResult eliminarEstados_PA(Estado pEstado)
        {
            List<recEstados_Result> lobjRespuesta = new List<recEstados_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delEstado_PA(pEstado))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recEstado_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarEstado_PA", lobjRespuesta);
        }
    }
}