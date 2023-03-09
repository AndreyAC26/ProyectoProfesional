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
    public class FacturasController : Controller
    {
        // GET: Facturas

        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public ActionResult Factura() 
        {
            return View(); 
        }

        //*********Procedimientos almacenados*********//
        public ActionResult listarFacturas_PA()
        {
            List<recFacturas_Result> lobjRespuesta = new List<recFacturas_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recFacturas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult agregarFacturas_PA()
        {
            return View();
        }

        public ActionResult modificarFacturas_PA(int pId)
        {
            recFacturaxId_Result lobjRespuesta_PA = new recFacturaxId_Result();
            modeloFacturas lobjRespuesta = new modeloFacturas();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recFacturasXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Factura = lobjRespuesta_PA.Id_Factura;
                    lobjRespuesta.fecha = lobjRespuesta_PA.fecha;
                    lobjRespuesta.Id_Orden = lobjRespuesta_PA.Id_Orden;
                    lobjRespuesta.Tel_Cliente = lobjRespuesta_PA.Tel_Cliente;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult eliminarFacturas_PA(int pId)
        {
            recFacturaxId_Result lobjRespuesta_PA = new recFacturaxId_Result();
            modeloFacturas lobjRespuesta = new modeloFacturas();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recFacturasXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Factura = lobjRespuesta_PA.Id_Factura;
                    lobjRespuesta.fecha = lobjRespuesta_PA.fecha;
                    lobjRespuesta.Id_Orden = lobjRespuesta_PA.Id_Orden;
                    lobjRespuesta.Tel_Cliente = lobjRespuesta_PA.Tel_Cliente;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detalleFacturas_PA(int pId)
        {
            recFacturaxId_Result lobjRespuesta_PA = new recFacturaxId_Result();
            modeloFacturas lobjRespuesta = new modeloFacturas();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recFacturasXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Factura = lobjRespuesta_PA.Id_Factura;
                    lobjRespuesta.fecha = lobjRespuesta_PA.fecha;
                    lobjRespuesta.Id_Orden = lobjRespuesta_PA.Id_Orden;
                    lobjRespuesta.Tel_Cliente = lobjRespuesta_PA.Tel_Cliente;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }


        /*****Acciones procedimientos almacenados Facturas******/
        public ActionResult accionesPA(string enviarAccion, modeloFacturas pModeloFacturas)
        {
            try
            {
                Facturas pFacturas = new Facturas();
                pFacturas.Id_Factura = pModeloFacturas.Id_Factura;
                pFacturas.fecha = pModeloFacturas.fecha;
                pFacturas.Id_Orden = pModeloFacturas.Id_Orden;
                pFacturas.Tel_Cliente = pModeloFacturas.Tel_Cliente;


                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarFac_PA(pFacturas);
                    case "Modificar":
                        return modificarFac_PA(pFacturas);
                    case "Eliminar":
                        return eliminarFac_PA(pFacturas);
                    default:
                        return RedirectToAction("listarFacturas_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarFac_PA(Facturas pFacturas)
        {
            List<recFacturas_Result> lobjRespuesta = new List<recFacturas_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insFacturas_PA(pFacturas))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recFacturas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarFacturas_PA", lobjRespuesta);
        }

        public ActionResult modificarFac_PA(Facturas pFacturas)
        {
            List<recFacturas_Result> lobjRespuesta = new List<recFacturas_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modFacturas_PA(pFacturas))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recFacturas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarFacturas_PA", lobjRespuesta);
        }

        public ActionResult eliminarFac_PA(Facturas pFacturas)
        {
            List<recFacturas_Result> lobjRespuesta = new List<recFacturas_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modFacturas_PA(pFacturas))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recFacturas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarFacturas_PA", lobjRespuesta);
        }
    }
}