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
    public class PerfilUsuarioController : Controller
    {
        // GET: PerfilUsuario

        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        //*********Procedimientos almacenados*********//
        //public ActionResult listarPerfilUsuario_PA()
        //{
        //    List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            lobjRespuesta = srvWCF_CR.recPerfilUsuario_PA();
        //        }
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return View(lobjRespuesta);
        //}

        public ActionResult listarPerfilUsuario_PA()
        {
            List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
            List<modeloPerfilUsuario> lobjModeloPerfilUsuario = new List<modeloPerfilUsuario>();

            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recPerfilUsuario_PA();

                    foreach (var item in lobjRespuesta)
                    {
                        var perfil = srvWCF_CR.recPerfilesXId_PA(item.Perfil_Id.Value);
                        string nombrePerfil = perfil.nombre_perfil;

                        lobjModeloPerfilUsuario.Add(new modeloPerfilUsuario
                        {
                            Perfil_Id = item.Perfil_Id,
                            Usuario = item.Usuario,
                            Id_PerfilUsuario = item.Id_PerfilUsuario,
                            NombrePerfil = nombrePerfil
                        });
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return View(lobjModeloPerfilUsuario);
        }



        public ActionResult agregarPerfilUsuario_PA()
        {
            return View();
        }

        public ActionResult modificarPerfilUsuario_PA(int pId)
        {
            recPerfilUsuarioxId_Result lobjRespuesta_PA = new recPerfilUsuarioxId_Result();
            modeloPerfilUsuario lobjRespuesta = new modeloPerfilUsuario();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recPerfilUsuarioXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Perfil_Id = lobjRespuesta_PA.Perfil_Id;
                    lobjRespuesta.Usuario = lobjRespuesta_PA.Usuario;
                    lobjRespuesta.Id_PerfilUsuario = lobjRespuesta_PA.Id_PerfilUsuario;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult eliminarPerfilUsuario_PA(int pId)
        {
            recPerfilUsuarioxId_Result lobjRespuesta_PA = new recPerfilUsuarioxId_Result();
            modeloPerfilUsuario lobjRespuesta = new modeloPerfilUsuario();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recPerfilUsuarioXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Perfil_Id = lobjRespuesta_PA.Perfil_Id;
                    lobjRespuesta.Usuario = lobjRespuesta_PA.Usuario;
                    lobjRespuesta.Id_PerfilUsuario = lobjRespuesta_PA.Id_PerfilUsuario;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detallePerfilUsuario_PA(int pId)
        {
            recPerfilUsuarioxId_Result lobjRespuesta_PA = new recPerfilUsuarioxId_Result();
            modeloPerfilUsuario lobjRespuesta = new modeloPerfilUsuario();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recPerfilUsuarioXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Perfil_Id = lobjRespuesta_PA.Perfil_Id;
                    lobjRespuesta.Usuario = lobjRespuesta_PA.Usuario;
                    lobjRespuesta.Id_PerfilUsuario = lobjRespuesta_PA.Id_PerfilUsuario;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        /*****Acciones procedimientos almacenados PerfilUsuario******/
        public ActionResult accionesPA(string enviarAccion, modeloPerfilUsuario pModeloPerfilUsuario)
        {
            try
            {
                PerfilUsuario pPerfilUsuario = new PerfilUsuario();
                pPerfilUsuario.Perfil_Id = pModeloPerfilUsuario.Perfil_Id;
                pPerfilUsuario.Usuario = pModeloPerfilUsuario.Usuario;
                pPerfilUsuario.Id_PerfilUsuario = pModeloPerfilUsuario.Id_PerfilUsuario;

                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarUserPerfil_PA(pPerfilUsuario);
                    case "Modificar":
                        return modificarUserPerfil_PA(pPerfilUsuario);
                    case "Eliminar":
                        return eliminarUserPerfil_PA(pPerfilUsuario);
                    default:
                        return RedirectToAction("listarPerfilUsuario_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarUserPerfil_PA(PerfilUsuario pPerfilUsuario)
        {
            List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insPerfilUsuario_PA(pPerfilUsuario))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recPerfilUsuario_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarPerfilUsuario_PA", lobjRespuesta);
        }

        public ActionResult modificarUserPerfil_PA(PerfilUsuario pPerfilUsuario)
        {
            List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modPerfilUsuario_PA(pPerfilUsuario))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recPerfilUsuario_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarPerfilUsuario_PA", lobjRespuesta);
        }

        public ActionResult eliminarUserPerfil_PA(PerfilUsuario pPerfilUsuario)
        {
            List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delPerfilUsuario_PA(pPerfilUsuario))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recPerfilUsuario_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarPerfilUsuario_PA", lobjRespuesta);
        }

    }
}