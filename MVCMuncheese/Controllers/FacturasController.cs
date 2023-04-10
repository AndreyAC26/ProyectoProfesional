using Entidades;
using MVCMuncheese.Models;
using MVCMuncheese.Controllers;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MVCMuncheese.Models.modeloFacturas;
using System.Configuration.Provider;
using System.Xml.Linq;

namespace MVCMuncheese.Controllers
{
    public class FacturasController : Controller
    {
        // GET: Facturas

        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public ActionResult Factura() 
        {
            srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient();
            // Obtener las mesas ocupadas 
            var mesasOcupadas = srvWCF_CR.recMesas_PA().Where(m => m.Estado == 2)
            .Select(m => new SelectListItem { Value = m.Id_Mesa.ToString(), Text = $"Mesa {m.Id_Mesa}" });

            // Obtener las órdenes activas
            var ordenesActivas = srvWCF_CR.recOrdenes_ENT().Where(o => o.Estado == 1).Select(o => new SelectListItem { Value = o.Id_Orden.ToString(), Text = $"{o.Id_Orden}" });

            // Obtener la lista de clientes y sus teléfonos
            var listaClientes = srvWCF_CR.recClientes_ENT();
            var clientes = listaClientes.Select(c => new SelectListItem { Value = c.Nombre, Text = $"{c.Nombre}" });

            // Inicializar el modelo con los datos necesarios
            var modelo = new modeloFacturas
            {
                MesasOcupadas = new SelectList(mesasOcupadas, "Value", "Text"),
                OrdenesActivas = new SelectList(ordenesActivas, "Value", "Text"),
                Clientes = clientes.ToList(), // Agregar la lista de clientes al modelo
            };

            return View(modelo);
        }

        public ActionResult GetOrdenesPorMesa(int mesaId)
        {
            srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient();
            var ordenesActivas = srvWCF_CR.recDetalleOrden_ENT().Where(d => d.Mesa == mesaId && d.Ordenes.Estado == 1)
                                 .Select(d => new SelectListItem { Value = d.Id_Orden.ToString(), Text = $"Orden {d.Id_Orden}" });
            return Json(ordenesActivas, JsonRequestBehavior.AllowGet);
        }

        // Adquirir numero de telefono cliente
        public string ObtenerTelefonoCliente(string cliente)
        {
            // Obtener el número de teléfono del cliente desde tu servicio WCF
            srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient();

            var listaClientes = srvWCF_CR.recClientes_ENT(); // Obtener la lista de clientes
            var telefono = listaClientes.Where(c => c.Nombre == cliente).Select(c => c.Telefono).FirstOrDefault(); // Buscar el cliente seleccionado en la lista y obtener su número de teléfono

            return telefono; // Devolver el número de teléfono del cliente
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