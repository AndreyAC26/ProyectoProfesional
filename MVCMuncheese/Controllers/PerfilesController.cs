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
    public class PerfilesController : Controller
    {
        // GET: Perfiles
        

        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        //*********Procedimientos almacenados*********//
        public ActionResult listarPerfiles_PA()
        {
            List<recPerfiles_Result> lobjRespuesta = new List<recPerfiles_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recPerfiles_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult agregarPerfiles_PA()
        {
            return View();
        }

        public ActionResult modificarPerfiles_PA(int pId)
        {
            recMesaPerfilxId_Result lobjRespuesta_PA = new recMesaPerfilxId_Result();
            modeloPerfiles lobjRespuesta = new modeloPerfiles();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recPerfilesXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Perfil_Id = lobjRespuesta_PA.Perfil_Id;
                    lobjRespuesta.nombre_perfil = lobjRespuesta_PA.nombre_perfil;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult eliminarPerfiles_PA(int pId)
        {
            recMesaPerfilxId_Result lobjRespuesta_PA = new recMesaPerfilxId_Result();
            modeloPerfiles lobjRespuesta = new modeloPerfiles();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recPerfilesXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Perfil_Id = lobjRespuesta_PA.Perfil_Id;
                    lobjRespuesta.nombre_perfil = lobjRespuesta_PA.nombre_perfil;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detallePerfiles_PA(int pId)
        {
            recMesaPerfilxId_Result lobjRespuesta_PA = new recMesaPerfilxId_Result();
            modeloPerfiles lobjRespuesta = new modeloPerfiles();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recPerfilesXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Perfil_Id = lobjRespuesta_PA.Perfil_Id;
                    lobjRespuesta.nombre_perfil = lobjRespuesta_PA.nombre_perfil;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }


        /*****Acciones procedimientos almacenados Estado******/
        public ActionResult accionesPA(string enviarAccion, modeloPerfiles pModeloPerfiles)
        {
            try
            {
                Perfiles pPerfiles = new Perfiles();
                pPerfiles.Perfil_Id = pModeloPerfiles.Perfil_Id;
                pPerfiles.nombre_perfil = pModeloPerfiles.nombre_perfil;

                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarPer_PA(pPerfiles);
                    case "Modificar":
                        return modificarPer_PA(pPerfiles);
                    case "Eliminar":
                        return eliminarPer_PA(pPerfiles);
                    default:
                        return RedirectToAction("listarPerfiles_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarPer_PA(Perfiles pPerfiles)
        {
            List<recPerfiles_Result> lobjRespuesta = new List<recPerfiles_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insPerfiles_PA(pPerfiles))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recPerfiles_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarPerfiles_PA", lobjRespuesta);
        }

        public ActionResult modificarPer_PA(Perfiles pPerfiles)
        {
            List<recPerfiles_Result> lobjRespuesta = new List<recPerfiles_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modPerfiles_PA(pPerfiles))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recPerfiles_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarPerfiles_PA", lobjRespuesta);
        }

        public ActionResult eliminarPer_PA(Perfiles pPerfiles)
        {
            List<recPerfiles_Result> lobjRespuesta = new List<recPerfiles_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delPerfiles_PA(pPerfiles))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recPerfiles_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarPerfiles_PA", lobjRespuesta);
        }

    }
}