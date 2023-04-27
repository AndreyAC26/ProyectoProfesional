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
    public class ProveedoresController : Controller
    {
        // GET: Proveedores

        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        //*********Procedimientos almacenados*********//
        //public ActionResult listarProveedores_PA()
        //{
        //    List<recProveedor_Result> lobjRespuesta = new List<recProveedor_Result>();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            lobjRespuesta = srvWCF_CR.recProveedores_PA();
        //        }
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return View(lobjRespuesta);
        //}

        public ActionResult listarProveedores_PA()
        {
            List<recProveedor_Result> lobjRespuesta = new List<recProveedor_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recProveedores_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            List<modeloProveedores> lobjModeloProveedores = new List<modeloProveedores>();

            foreach (var proveedor in lobjRespuesta)
            {
                modeloProveedores proveedorModelo = new modeloProveedores();
                proveedorModelo.Id_Proveedor = proveedor.Id_Proveedor;
                proveedorModelo.Nombre = proveedor.Nombre;
                proveedorModelo.Apellido_1 = proveedor.Apellido_1;
                proveedorModelo.Apellido_2 = proveedor.Apellido_2;
                proveedorModelo.Telefono = proveedor.Telefono;
                proveedorModelo.Producto = proveedor.Producto;

                lobjModeloProveedores.Add(proveedorModelo);
            }

            return View(lobjModeloProveedores);
        }



        public ActionResult agregarProveedores_PA()
        {
            return View();
        }

        public ActionResult modificarProveedores_PA(int pId)
        {
            recProveedorxId_Result lobjRespuesta_PA = new recProveedorxId_Result();
            modeloProveedores lobjRespuesta = new modeloProveedores();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recProveedoresXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Proveedor = lobjRespuesta_PA.Id_Proveedor;
                    lobjRespuesta.Nombre = lobjRespuesta_PA.Nombre;
                    lobjRespuesta.Apellido_1 = lobjRespuesta_PA.Apellido_1;
                    lobjRespuesta.Apellido_2 = lobjRespuesta_PA.Apellido_2;
                    lobjRespuesta.Telefono = lobjRespuesta_PA.Telefono;
                    lobjRespuesta.Producto = lobjRespuesta_PA.Producto;

                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult eliminarProveedores_PA(int pId)
        {
            recProveedorxId_Result lobjRespuesta_PA = new recProveedorxId_Result();
            modeloProveedores lobjRespuesta = new modeloProveedores();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recProveedoresXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Proveedor = lobjRespuesta_PA.Id_Proveedor;
                    lobjRespuesta.Nombre = lobjRespuesta_PA.Nombre;
                    lobjRespuesta.Apellido_1 = lobjRespuesta_PA.Apellido_1;
                    lobjRespuesta.Apellido_2 = lobjRespuesta_PA.Apellido_2;
                    lobjRespuesta.Telefono = lobjRespuesta_PA.Telefono;
                    lobjRespuesta.Producto = lobjRespuesta_PA.Producto;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detalleProveedores_PA(int pId)
        {
            recProveedorxId_Result lobjRespuesta_PA = new recProveedorxId_Result();
            modeloProveedores lobjRespuesta = new modeloProveedores();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recProveedoresXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Proveedor = lobjRespuesta_PA.Id_Proveedor;
                    lobjRespuesta.Nombre = lobjRespuesta_PA.Nombre;
                    lobjRespuesta.Apellido_1 = lobjRespuesta_PA.Apellido_1;
                    lobjRespuesta.Apellido_2 = lobjRespuesta_PA.Apellido_2;
                    lobjRespuesta.Telefono = lobjRespuesta_PA.Telefono;
                    lobjRespuesta.Producto = lobjRespuesta_PA.Producto;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }



        /*****Acciones procedimientos almacenados Proveedores******/
        public ActionResult accionesPA(string enviarAccion, modeloProveedores pModeloProveedores)
        {
            try
            {
                Proveedor pProveedores = new Proveedor();
                pProveedores.Id_Proveedor = pModeloProveedores.Id_Proveedor;
                pProveedores.Nombre = pModeloProveedores.Nombre;
                pProveedores.Apellido_1 = pModeloProveedores.Apellido_1;
                pProveedores.Apellido_2 = pModeloProveedores.Apellido_2;
                pProveedores.Telefono = pModeloProveedores.Telefono;
                pProveedores.Producto = pModeloProveedores.Producto;

                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarProv_PA(pProveedores);
                    case "Modificar":
                        return modificarProv_PA(pProveedores);
                    case "Eliminar":
                        return eliminarProv_PA(pProveedores);
                    default:
                        return RedirectToAction("listarProveedores_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarProv_PA(Proveedor pProveedores)
        {
            List<recProveedor_Result> lobjRespuesta = new List<recProveedor_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insProveedores_PA(pProveedores))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recProveedores_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarProveedores_PA", lobjRespuesta);
        }

        public ActionResult modificarProv_PA(Proveedor pProveedores)
        {
            List<recProveedor_Result> lobjRespuesta = new List<recProveedor_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modProveedores_PA(pProveedores))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recProveedores_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarProveedores_PA", lobjRespuesta);
        }

        public ActionResult eliminarProv_PA(Proveedor pProveedores)
        {
            List<recProveedor_Result> lobjRespuesta = new List<recProveedor_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delProveedores_PA(pProveedores))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recProveedores_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarProveedores_PA", lobjRespuesta);
        }



    }
}