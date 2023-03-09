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
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        //*********Procedimientos almacenados*********//
        public ActionResult listarUsuarios_PA()
        {
            List<recUsuarios_Result> lobjRespuesta = new List<recUsuarios_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recUsuarios_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult agregarUsuarios_PA()
        {
            return View();
        }

        public ActionResult modificarUsuarios_PA(string pId)
        {
            recUsuarioxId_Result lobjRespuesta_PA = new recUsuarioxId_Result();
            modeloUsuarios lobjRespuesta = new modeloUsuarios();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recUsuariosXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Usuario = lobjRespuesta_PA.Usuario;
                    lobjRespuesta.Contraseña = lobjRespuesta_PA.Contraseña;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;

                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult eliminarUsuarios_PA(string pId)
        {
            recUsuarioxId_Result lobjRespuesta_PA = new recUsuarioxId_Result();
            modeloUsuarios lobjRespuesta = new modeloUsuarios();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recUsuariosXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Usuario = lobjRespuesta_PA.Usuario;
                    lobjRespuesta.Contraseña = lobjRespuesta_PA.Contraseña;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detalleUsuarios_PA(string pId)
        {
            recUsuarioxId_Result lobjRespuesta_PA = new recUsuarioxId_Result();
            modeloUsuarios lobjRespuesta = new modeloUsuarios();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recUsuariosXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Usuario = lobjRespuesta_PA.Usuario;
                    lobjRespuesta.Contraseña = lobjRespuesta_PA.Contraseña;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        /*****Acciones procedimientos almacenados Usuarios******/
        public ActionResult accionesPA(string enviarAccion, modeloUsuarios pModeloUsuarios)
        {
            try
            {
                Usuarios pUsuarios = new Usuarios();
                pUsuarios.Usuario = pModeloUsuarios.Usuario;
                pUsuarios.Contraseña = pModeloUsuarios.Contraseña;
                pUsuarios.Estado = pModeloUsuarios.Estado;

                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarUser_PA(pUsuarios);
                    case "Modificar":
                        return modificarUser_PA(pUsuarios);
                    case "Eliminar":
                        return eliminarUser_PA(pUsuarios);
                    default:
                        return RedirectToAction("listarUsuarios_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarUser_PA(Usuarios pUsuarios)
        {
            List<recUsuarios_Result> lobjRespuesta = new List<recUsuarios_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insUsuarios_PA(pUsuarios))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recUsuarios_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarUsuarios_PA", lobjRespuesta);
        }

        public ActionResult modificarUser_PA(Usuarios pUsuarios)
        {
            List<recUsuarios_Result> lobjRespuesta = new List<recUsuarios_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modUsuarios_PA(pUsuarios))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recUsuarios_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarUsuarios_PA", lobjRespuesta);
        }

        public ActionResult eliminarUser_PA(Usuarios pUsuarios)
        {
            List<recUsuarios_Result> lobjRespuesta = new List<recUsuarios_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delUsuarios_PA(pUsuarios))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recUsuarios_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarUsuarios_PA", lobjRespuesta);
        }
    }
}