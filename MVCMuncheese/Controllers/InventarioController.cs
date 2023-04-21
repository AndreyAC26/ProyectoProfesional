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
    public class InventarioController : Controller
    {
        // GET: Inventario

        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();



        //*********Procedimientos almacenados*********//
        public ActionResult listarInventario_PA()
        {
            List<recInventario_Result> lobjRespuesta = new List<recInventario_Result>();
            List<modeloInventario> inventarioList = new List<modeloInventario>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recInventario_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            foreach (var item in lobjRespuesta)
            {
                inventarioList.Add(new modeloInventario
                {
                    Id_inventario = item.Id_inventario,
                    Nombre_Producto = item.Nombre_Producto,
                    Cantidad = item.Cantidad,
                    Id_Producto = item.Id_Producto
                });
            }

            return View(inventarioList);
        }

        public ActionResult agregarInventarioPA()
        {
            List<Entidades.Productos> productos;
            List<MVCMuncheese.Models.modeloProductos> productosViewModel;

            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    productos = srvWCF_CR.recProductos_ENT();
                }

                productosViewModel = productos.Select(p => new MVCMuncheese.Models.modeloProductos
                {
                    Id_producto = p.Id_producto,
                    Nombre = p.Nombre,
                           }).ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            ViewBag.Productos = productosViewModel;

            return View();
        }

        public ActionResult modificarInventario_PA(int pId)
        {
            recInventarioxId_Result lobjRespuesta_PA = new recInventarioxId_Result();
            modeloInventario lobjRespuesta = new modeloInventario();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recInventarioXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_inventario = lobjRespuesta_PA.Id_inventario;
                    lobjRespuesta.Nombre_Producto = lobjRespuesta_PA.Nombre_Producto;
                    lobjRespuesta.Cantidad = lobjRespuesta_PA.Cantidad;
                    lobjRespuesta.Id_Producto = lobjRespuesta_PA.Id_Producto;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult eliminarInventario_PA(int pId)
        {
            recInventarioxId_Result lobjRespuesta_PA = new recInventarioxId_Result();
            modeloInventario lobjRespuesta = new modeloInventario();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recInventarioXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_inventario = lobjRespuesta_PA.Id_inventario;
                    lobjRespuesta.Nombre_Producto = lobjRespuesta_PA.Nombre_Producto;
                    lobjRespuesta.Cantidad = lobjRespuesta_PA.Cantidad;
                    lobjRespuesta.Id_Producto = lobjRespuesta_PA.Id_Producto;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detalleInventario_PA(int pId)
        {
            recInventarioxId_Result lobjRespuesta_PA = new recInventarioxId_Result();
            modeloInventario lobjRespuesta = new modeloInventario();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recInventarioXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_inventario = lobjRespuesta_PA.Id_inventario;
                    lobjRespuesta.Nombre_Producto = lobjRespuesta_PA.Nombre_Producto;
                    lobjRespuesta.Cantidad = lobjRespuesta_PA.Cantidad;
                    lobjRespuesta.Id_Producto = lobjRespuesta_PA.Id_Producto;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        /*****Acciones procedimientos almacenados Inventario******/
        public ActionResult accionesPA(string enviarAccion, modeloInventario pModeloInventario)
        {
            try
            {
                Inventario pInventario = new Inventario();
                pInventario.Id_inventario = pModeloInventario.Id_inventario;
                pInventario.Nombre_Producto = pModeloInventario.Nombre_Producto;
                pInventario.Cantidad = pModeloInventario.Cantidad;
                pInventario.Id_Producto = pModeloInventario.Id_Producto;


                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarInv_PA(pInventario);
                    case "Modificar":
                        return modificarInv_PA(pInventario);
                    case "Eliminar":
                        return eliminarInv_PA(pInventario);
                    default:
                        return RedirectToAction("listarInventario_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarInv_PA(Inventario pInventario)
        {
            List<recInventario_Result> lobjRespuesta = new List<recInventario_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insInventario_PA(pInventario))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recInventario_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarInventario_PA");
        }

        public ActionResult modificarInv_PA(Inventario pInventario)
        {
            List<recInventario_Result> lobjRespuesta = new List<recInventario_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modInventario_PA(pInventario))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recInventario_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarInventario_PA");
        }

        public ActionResult eliminarInv_PA(Inventario pInventario)
        {
            List<recInventario_Result> lobjRespuesta = new List<recInventario_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delInventario_PA(pInventario))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recInventario_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarInventario_PA");
        }
    }
}