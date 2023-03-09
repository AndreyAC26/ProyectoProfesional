using Entidades;
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

        public ActionResult validaAccesoUsuario(Models.modeloLogin pLogin)
        {
            string lRuta = string.Empty;
            Usuarios lObjRespuesta = new Usuarios();

            using (srvMuncheese.IsrvMuncheeseClient srvSEG = new srvMuncheese.IsrvMuncheeseClient())
            {
                lObjRespuesta = srvSEG.recUsuario(pLogin.Usuario);
            }
            if (lObjRespuesta != null)
            {
                if (lObjRespuesta.Usuario == pLogin.Usuario)
                {
                    if (lObjRespuesta.Contraseña == pLogin.Contraseña)
                    {
                        lRuta = "../Home/Index";
                        Session["blnMantenimiento"] = true;
                        Session["Logueado"] = true;
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