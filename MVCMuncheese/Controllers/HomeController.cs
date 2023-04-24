using Entidades;
using MVCMuncheese.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCMuncheese.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult TotalDia()
        {

            DateTime fechaEspecifica = DateTime.Today;
            var modelo = new modeloDetalleOrden();

            return View(modelo);

        }

        public ActionResult VentasLlevar(DateTime fecha)
        {
            var ventasParaLlevar = CalcularVentasPorTipo(fecha, "Para llevar");
            return Json(ventasParaLlevar, JsonRequestBehavior.AllowGet);
        }

        public ActionResult VentasLocal(DateTime fecha)
        {
            var ventasLocal = CalcularVentasPorTipo(fecha, "Comer aquí");
            return Json(ventasLocal, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalVentas(DateTime fecha)
        {
            var ventasParaLlevar = CalcularVentasPorTipo(fecha, "Para llevar");
            var ventasLocal = CalcularVentasPorTipo(fecha, "Comer aquí");
            var totalVentas = ventasParaLlevar + ventasLocal;
            return Json(totalVentas, JsonRequestBehavior.AllowGet);
        }

        public decimal CalcularVentasPorTipo(DateTime fecha, string tipoOrden)
        {
            List<recDetalleOrden_Result> lobjRespuesta = new List<recDetalleOrden_Result>();
            List<Ordenes> ordenes;

            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recDetalleOrden_PA();
                    ordenes = srvWCF_CR.recOrdenes_ENT();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            var ordenesJoinDetalleOrden = ordenes.Join(lobjRespuesta, o => o.Id_Orden, d => d.Id_Orden, (o, d) => new { Orden = o, DetalleOrden = d }).ToList();

            var ventas = ordenesJoinDetalleOrden.Where(x => x.Orden.Fecha.HasValue && x.Orden.Fecha.Value.Date == fecha.Date && x.DetalleOrden.Tipo_orden == tipoOrden).ToList();

            return ventas.Sum(x => x.DetalleOrden.Cantidad.Value * x.DetalleOrden.Precio.Value);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult cerrarSesion()
        {
            Session["blnRegionesEnt"] = false;
            Session["blnRegionesPA"] = false;
            Session["Logueado"] = false;
            Session["LogueadoAdmin"] = false;
            Session["LogueadoMesero"] = false;
            Session["LogueadoCocina"] = false;
            return RedirectToAction("../Login/Index");
        }

        private int ObtenerPerfilUsuarioLogueado()
        {
            // Recupera el nombre de usuario logueado desde la sesión
            string nombreUsuarioLogueado = Convert.ToString(Session["NombreUsuario"]);

            // Obtiene el diccionario de perfiles de usuario
            var perfilesUsuario = CargarPerfilesUsuario();

            // Busca el perfil del usuario logueado en el diccionario
            int perfilUsuario = perfilesUsuario.ContainsKey(nombreUsuarioLogueado) ? perfilesUsuario[nombreUsuarioLogueado] : 0;

            return perfilUsuario;
        }


        private Dictionary<string, int> CargarPerfilesUsuario()
        {
            List<recPerfiles_Result> perfiles;
            List<recPerfilUsuario_Result> perfilUsuario;

            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    perfiles = srvWCF_CR.recPerfiles_PA();
                    perfilUsuario = srvWCF_CR.recPerfilUsuario_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            var perfilesUsuario = perfilUsuario.Join(perfiles, pu => pu.Perfil_Id, p => p.Perfil_Id, (pu, p) => new { pu.Usuario, p.Perfil_Id }).ToDictionary(x => x.Usuario, x => x.Perfil_Id);

            return perfilesUsuario;
        }

    }
}