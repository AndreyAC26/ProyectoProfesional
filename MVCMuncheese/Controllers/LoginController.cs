using Entidades;
using MVCMuncheese.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMuncheese.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session["blnRegionesEnt"] = false;
            Session["blnRegionesPA"] = false;
            Session["Logueado"] = false;
            Session["LogueadoAdmin"] = false;
            Session["LogueadoMesero"] = false;
            Session["LogueadoCocina"] = false;
            return View();
        }

        public ActionResult errorUsuario()
        {
            return View();
        }

        public ActionResult errorPass()
        {
            return View();
        }

        //public ActionResult validaAccesoUsuario(Models.modeloLogin pLogin)
        //{
        //    string lRuta = string.Empty;
        //    Usuarios lObjRespuesta = new Usuarios();

        //    using (srvMuncheese.IsrvMuncheeseClient srvSEG = new srvMuncheese.IsrvMuncheeseClient())
        //    {
        //        lObjRespuesta = srvSEG.recUsuario(pLogin.Usuario);
        //    }
        //    if (lObjRespuesta != null)
        //    {
        //        if (lObjRespuesta.Usuario == pLogin.Usuario)
        //        {
        //            if (lObjRespuesta.Contraseña == pLogin.Contraseña)
        //            {
        //                lRuta = "../Home/Index";
        //                Session["blnMantenimiento"] = true;
        //                Session["Logueado"] = true;
        //                Session["LogueadoAdmin"] = true;
        //                Session["LogueadoMesero"] = true;
        //                Session["LogueadoCocina"] = true;
        //            }
        //            else
        //            {
        //                lRuta = "../Login/errorPass";
        //            }
        //        }
        //        else
        //        {
        //            lRuta = "../Login/errorUsuario";
        //        }
        //    }
        //    else
        //    {
        //        lRuta = "../Login/errorUsuario";
        //    }
        //    return RedirectToAction(lRuta);
        //}

        public ActionResult validaAccesoUsuario(Models.modeloLogin pLogin)
        {
            string lRuta = string.Empty;
            Usuarios lObjRespuesta = new Usuarios();
            List<modeloPerfilUsuario> lPerfilUsuario;

            using (srvMuncheese.IsrvMuncheeseClient srvSEG = new srvMuncheese.IsrvMuncheeseClient())
            {
                lObjRespuesta = srvSEG.recUsuario(pLogin.Usuario);
                lPerfilUsuario = srvSEG.recPerfilUsuario_PA().Select(pu => new modeloPerfilUsuario
                {
                    Perfil_Id = pu.Perfil_Id,
                    Usuario = pu.Usuario
                }).ToList();
            }

            modeloPerfilUsuario perfilUsuario = lPerfilUsuario.FirstOrDefault(pu => pu.Usuario == pLogin.Usuario);

            if (lObjRespuesta != null)
            {
                if (lObjRespuesta.Usuario == pLogin.Usuario)
                {
                    if (lObjRespuesta.Contraseña == pLogin.Contraseña)
                    {
                        lRuta = "../Home/Index";
                        Session["Logueado"] = true;

                        if (perfilUsuario != null)
                        {
                            if (perfilUsuario.Perfil_Id == 1)
                            {
                                Session["LogueadoAdmin"] = true;
                            }
                            else if (perfilUsuario.Perfil_Id == 2)
                            {
                                Session["LogueadoMesero"] = true;
                            }
                            else if (perfilUsuario.Perfil_Id == 3)
                            {
                                Session["LogueadoCocina"] = true;
                            }
                        }
                        else
                        {
                            // El usuario no tiene un perfil asociado, manejar el caso aquí
                        }
                    }
                    else
                    {
                        lRuta = "../Login/errorPass";
                    }
                }
                else
                {
                    lRuta = "../Login/errorUsuario";
                }
            }
            else
            {
                lRuta = "../Login/errorUsuario";
            }
            return RedirectToAction(lRuta);
        }


        public ActionResult retornarLogin()
        {
            return RedirectToAction("../Login/Index");
        }
    }
}