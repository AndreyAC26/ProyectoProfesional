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
    public class MesasController : Controller
    {
        // GET: Mesas
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public ActionResult Mesas()
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            List<MesaViewModel> mesas = new List<MesaViewModel>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recMesas_PA();
                    foreach (var mesa in lobjRespuesta)
                    {
                        mesas.Add(new MesaViewModel { NumeroMesa = mesa.Id_Mesa});
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(mesas);
        }

        //*********Procedimientos almacenados*********//
        public ActionResult listarMesas_PA()
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recMesas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult agregarMesas_PA()
        {
            return View();
        }

        public ActionResult modificarMesas_PA(int pId)
        {
            recMesaxId_Result lobjRespuesta_PA = new recMesaxId_Result();
            modeloMesas lobjRespuesta = new modeloMesas();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recMesaXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Mesa = lobjRespuesta_PA.Id_Mesa;
                    lobjRespuesta.NombreMesa = lobjRespuesta_PA.NombreMesa;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult eliminarMesas_PA(int pId)
        {
            recMesaxId_Result lobjRespuesta_PA = new recMesaxId_Result();
            modeloMesas lobjRespuesta = new modeloMesas();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recMesaXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Mesa = lobjRespuesta_PA.Id_Mesa;
                    lobjRespuesta.NombreMesa = lobjRespuesta_PA.NombreMesa;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detalleMesas_PA(int pId)
        {
            recMesaxId_Result lobjRespuesta_PA = new recMesaxId_Result();
            modeloMesas lobjRespuesta = new modeloMesas();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recMesaXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Mesa = lobjRespuesta_PA.Id_Mesa;
                    lobjRespuesta.NombreMesa = lobjRespuesta_PA.NombreMesa;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        /*****Acciones procedimientos almacenados Mesas******/
        public ActionResult accionesPA(string enviarAccion, modeloMesas pModeloMesas)
        {
            try
            {
                Mesas pMesas = new Mesas();
                pMesas.Id_Mesa = pModeloMesas.Id_Mesa;
                pMesas.NombreMesa = pModeloMesas.NombreMesa;
                pMesas.Estado = pModeloMesas.Estado;


                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarMesa_PA(pMesas);
                    case "Modificar":
                        return modificarMesa_PA(pMesas);
                    case "Eliminar":
                        return eliminarMesa_PA(pMesas);
                    default:
                        return RedirectToAction("listarMesas_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarMesa_PA(Mesas pMesas)
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insMesas_PA(pMesas))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recMesas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarMesas_PA", lobjRespuesta);
        }

        public ActionResult modificarMesa_PA(Mesas pMesas)
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modMesas_PA(pMesas))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recMesas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarMesas_PA", lobjRespuesta);
        }

        public ActionResult eliminarMesa_PA(Mesas pMesas)
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delMesas_PA(pMesas))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recMesas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarMesas_PA", lobjRespuesta);
        }

    }
}