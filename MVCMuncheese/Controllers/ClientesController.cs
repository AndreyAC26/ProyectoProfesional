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
    public class ClientesController : Controller
    {
        // GET: Clientes

        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();


        //*********ENTIDADES*********//
        public ActionResult listarClientes_ENT()
        {
            List<Clientes> lobjRespuesta = new List<Clientes>();
            List<modeloClientes> lobjRespuestaModelo = new List<modeloClientes>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recClientes_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloClientes objModeloClientes;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloClientes = new modeloClientes(); 
                            objModeloClientes.Nombre = lcr.Nombre;
                            objModeloClientes.Apellido_1 = lcr.Apellido_1;
                            objModeloClientes.Apellido_2 = lcr.Apellido_2;
                            objModeloClientes.Telefono = lcr.Telefono;
                            objModeloClientes.Direccion = lcr.Direccion;
                            lobjRespuestaModelo.Add(objModeloClientes);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return View(lobjRespuestaModelo);
        }

        public ActionResult agregarClientes_ENT()
        {
            return View();
        }

        public ActionResult modificarClientes_ENT(string pId)
        {
            Clientes lobjRespuesta = new Clientes();
            modeloClientes lobjModeloClientes;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recClientesXId_ENT(pId);
                    lobjModeloClientes = new modeloClientes();
                    lobjModeloClientes.Nombre = lobjRespuesta.Nombre;
                    lobjModeloClientes.Apellido_1 = lobjRespuesta.Apellido_1;
                    lobjModeloClientes.Apellido_2 = lobjRespuesta.Apellido_2;
                    lobjModeloClientes.Telefono = lobjRespuesta.Telefono;
                    lobjModeloClientes.Direccion = lobjRespuesta.Direccion;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloClientes);
        }

        public ActionResult eliminarClientes_ENT(string pId)
        {
            Clientes lobjRespuesta = new Clientes();
            modeloClientes lobjModeloClientes;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recClientesXId_ENT(pId);
                    lobjModeloClientes = new modeloClientes();
                    lobjModeloClientes.Nombre = lobjRespuesta.Nombre;
                    lobjModeloClientes.Apellido_1 = lobjRespuesta.Apellido_1;
                    lobjModeloClientes.Apellido_2 = lobjRespuesta.Apellido_2;
                    lobjModeloClientes.Telefono = lobjRespuesta.Telefono;
                    lobjModeloClientes.Direccion = lobjRespuesta.Direccion;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloClientes);
        }

        public ActionResult detalleClientes_ENT(string pId)
        {
            Clientes lobjRespuesta = new Clientes();
            modeloClientes lobjModeloClientes;
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recClientesXId_ENT(pId);
                    lobjModeloClientes = new modeloClientes();
                    lobjModeloClientes.Nombre = lobjRespuesta.Nombre;
                    lobjModeloClientes.Apellido_1 = lobjRespuesta.Apellido_1;
                    lobjModeloClientes.Apellido_2 = lobjRespuesta.Apellido_2;
                    lobjModeloClientes.Telefono = lobjRespuesta.Telefono;
                    lobjModeloClientes.Direccion = lobjRespuesta.Direccion;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjModeloClientes);
        }


        /*****Acciones entidades Clientes******/
        public ActionResult accionesEntidades(string enviarAccion, modeloClientes pModeloClientes)
        {
            Clientes pClientes = new Clientes();
            pClientes.Nombre = pModeloClientes.Nombre;
            pClientes.Apellido_1 = pModeloClientes.Apellido_1;
            pClientes.Apellido_2 = pModeloClientes.Apellido_2;
            pClientes.Telefono = pModeloClientes.Telefono;
            pClientes.Direccion = pModeloClientes.Direccion;



            switch (enviarAccion)
            {
                case "Agregar":
                    return insertarCli_ENT(pClientes);
                case "Modificar":
                    return modificarCli_ENT(pClientes);
                case "Eliminar":
                    return eliminarCli_ENT(pClientes);
                default:
                    return RedirectToAction("listarClientes_ENT");
            }
        }

        public ActionResult insertarCli_ENT(Clientes pClientes)
        {
            List<Clientes> lobjRespuesta = new List<Clientes>();
            List<modeloClientes> lobjRespuestaModelo = new List<modeloClientes>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insClientes_ENT(pClientes))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recClientes_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloClientes objModeloClientes;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloClientes = new modeloClientes();
                            objModeloClientes.Nombre = lcr.Nombre;
                            objModeloClientes.Apellido_1 = lcr.Apellido_1;
                            objModeloClientes.Apellido_2 = lcr.Apellido_2;
                            objModeloClientes.Telefono = lcr.Telefono;
                            objModeloClientes.Direccion = lcr.Direccion;
                            lobjRespuestaModelo.Add(objModeloClientes);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return View("listarClientes_ENT", lobjRespuestaModelo);
        }

        public ActionResult modificarCli_ENT(Clientes pClientes)
        {
            List<Clientes> lobjRespuesta = new List<Clientes>();
            List<modeloClientes> lobjRespuestaModelo = new List<modeloClientes>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modClientes_ENT(pClientes))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recClientes_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloClientes objModeloClientes;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloClientes = new modeloClientes();
                            objModeloClientes.Nombre = lcr.Nombre;
                            objModeloClientes.Apellido_1 = lcr.Apellido_1;
                            objModeloClientes.Apellido_2 = lcr.Apellido_2;
                            objModeloClientes.Telefono = lcr.Telefono;
                            objModeloClientes.Direccion = lcr.Direccion;
                            lobjRespuestaModelo.Add(objModeloClientes);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return View("listarClientes_ENT", lobjRespuestaModelo);
        }

        public ActionResult eliminarCli_ENT(Clientes pClientes)
        {
            List<Clientes> lobjRespuesta = new List<Clientes>();
            List<modeloClientes> lobjRespuestaModelo = new List<modeloClientes>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delClientes_ENT(pClientes))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recClientes_ENT();
                    if (lobjRespuesta.Count > 0)
                    {
                        modeloClientes objModeloClientes;
                        foreach (var lcr in lobjRespuesta)
                        {
                            objModeloClientes = new modeloClientes();
                            objModeloClientes.Nombre = lcr.Nombre;
                            objModeloClientes.Apellido_1 = lcr.Apellido_1;
                            objModeloClientes.Apellido_2 = lcr.Apellido_2;
                            objModeloClientes.Telefono = lcr.Telefono;
                            objModeloClientes.Direccion = lcr.Direccion;
                            lobjRespuestaModelo.Add(objModeloClientes);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            return View("listarClientes_ENT", lobjRespuestaModelo);
        }
    }
}