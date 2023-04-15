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
using AccesoDatos.Implementacion;
using Newtonsoft.Json;

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

            //Obtener las ordenes activas
            var ordenesActivas = srvWCF_CR.recOrdenes_ENT().Where(o => o.Estado == 1)
                        .Join(srvWCF_CR.recDetalleOrden_PA(),
                              orden => orden.Id_Orden,
                              detalle => detalle.Id_Orden,
                              (orden, detalle) => new { orden, detalle })
                        .GroupBy(od => od.detalle.Mesa)
                        .ToDictionary(g => g.Key.Value, g => g.Select(od => new SelectListItem { Value = od.orden.Id_Orden.ToString(), Text = $"{od.orden.Id_Orden}" }).Distinct(new SelectListItemComparer()).ToList());

            // Obtener la lista de clientes y sus teléfonos
            var listaClientes = srvWCF_CR.recClientes_ENT();
            var clientes = listaClientes.Select(c => new SelectListItem { Value = c.Nombre, Text = $"{c.Nombre}" });       

            // Inicializar el modelo con los datos necesarios
            var modelo = new modeloFacturas
            {

                MesasOcupadas = new SelectList(mesasOcupadas, "Value", "Text"),
                //OrdenesActivas = new SelectList(ordenesActivas, "Value", "Text"),
                OrdenesPorMesaJson = JsonConvert.SerializeObject(ordenesActivas),
                Clientes = clientes.ToList(), // Agregar la lista de clientes al modelo
            };

            return View(modelo);
        }

        //Comparador 
        public class SelectListItemComparer : IEqualityComparer<SelectListItem>
        {
            public bool Equals(SelectListItem x, SelectListItem y)
            {
                return x.Value == y.Value && x.Text == y.Text;
            }

            public int GetHashCode(SelectListItem obj)
            {
                int valueHash = obj.Value != null ? obj.Value.GetHashCode() : 0;
                int textHash = obj.Text != null ? obj.Text.GetHashCode() : 0;
                return valueHash ^ textHash;
            }
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

        // Adquirir Id_Orden de las ordenes activas por la mesa seleccionada
        [HttpPost]
        public ActionResult ObtenerOrdenPorMesa(int mesaId)
        {
            srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient();
            int idOrden = srvWCF_CR.recOrdenes_ENT()
                                    .Join(srvWCF_CR.recDetalleOrden_PA(),
                                          Ordenes => Ordenes.Id_Orden,
                                  DetalleOrden => DetalleOrden.Id_Orden,
                                  (Ordenes, DetalleOrden) => new { Ordenes, DetalleOrden })
                            .Where(od => od.DetalleOrden.Mesa == mesaId && od.Ordenes.Estado == 1)
                            .Select(od => od.Ordenes.Id_Orden)
                            .FirstOrDefault();

            return Json(new
            {
                Id_Orden = idOrden
            });
        }

        //public JsonResult CargarDetalleOrdenes(int idOrden)
        //{
        //    srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient();

        //    var detallesOrden = srvWCF_CR.recDetalleOrden_PA().Where(d => d.Id_Orden == idOrden).ToList();

        //    return Json(detallesOrden, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult CargarDetalleOrdenes(int idOrden)
        {
            srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient();

            var detallesOrden = (from d in srvWCF_CR.recDetalleOrden_PA().Where(d => d.Id_Orden == idOrden)
                                 join p in srvWCF_CR.recProductos_ENT() on d.Id_producto equals p.Id_producto
                                 select new
                                 {
                                     d.Id_Detalle,
                                     d.Id_Orden,
                                     d.Id_producto,
                                     p.Nombre,
                                     d.Cantidad,
                                     d.Mesa,
                                     d.Precio,
                                     d.Tipo_orden,
                                     d.Descripcion
                                 }).ToList();

            return Json(detallesOrden, JsonRequestBehavior.AllowGet);
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