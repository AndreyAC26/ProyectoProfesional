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

        private Dictionary<int, string> ObtenerEstados()
        {
            Dictionary<int, string> estados = new Dictionary<int, string>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    var listaEstados = srvWCF_CR.recEstado_PA();
                    foreach (var estado in listaEstados)
                    {
                        estados[estado.Id_Estado] = estado.Estado;
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return estados;
        }

        private List<SelectListItem> ObtenerEstadosSelectList()
        {
            List<SelectListItem> estados = new List<SelectListItem>();
            try
            {
                var diccionarioEstados = ObtenerEstados();
                foreach (var estado in diccionarioEstados)
                {
                    estados.Add(new SelectListItem
                    {
                        Value = estado.Key.ToString(),
                        Text = estado.Value
                    });
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return estados;
        }

        
        public ActionResult listarUsuarios_PA()
        {
            List<modeloUsuarios> lobjRespuesta = new List<modeloUsuarios>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    var listaUsuarios = srvWCF_CR.recUsuarios_PA();
                    var estados = ObtenerEstados();

                    foreach (var usuario in listaUsuarios)
                    {
                        lobjRespuesta.Add(new modeloUsuarios
                        {
                            Usuario = usuario.Usuario,
                            Contraseña = usuario.Contraseña,
                            Estado = usuario.Estado,
                            NombreEstado = usuario.Estado.HasValue ? estados[usuario.Estado.Value] : ""
                        });
                    }
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
            ViewBag.Estados = ObtenerEstadosSelectList();
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
            ViewBag.Estados = ObtenerEstadosSelectList(); // Añadir línea para cargar el dropdownlist
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
            string estadoNombre = string.Empty;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recUsuariosXId_PA(pId);
                    var estado = srvWCF_CR.recEstadoXId_PA((int)lobjRespuesta_PA.Estado);
                    estadoNombre = estado.Estado;
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Usuario = lobjRespuesta_PA.Usuario;
                    lobjRespuesta.Contraseña = lobjRespuesta_PA.Contraseña;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                    lobjRespuesta.NombreEstado = estadoNombre;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }


        private List<modeloUsuarios> ConvertirRecUsuariosAModeloUsuarios(List<recUsuarios_Result> recUsuarios)
        {
            List<modeloUsuarios> listaModeloUsuarios = new List<modeloUsuarios>();

            foreach (var recUsuario in recUsuarios)
            {
                listaModeloUsuarios.Add(new modeloUsuarios
                {
                    Usuario = recUsuario.Usuario,
                    Contraseña = recUsuario.Contraseña,
                    Estado = recUsuario.Estado
                });
            }

            return listaModeloUsuarios;
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
            return RedirectToAction("listarUsuarios_PA"); // Modifica esta línea
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
            return RedirectToAction("listarUsuarios_PA"); // Modifica esta línea
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
            return RedirectToAction("listarUsuarios_PA"); // Modifica esta línea
        }
    }
}