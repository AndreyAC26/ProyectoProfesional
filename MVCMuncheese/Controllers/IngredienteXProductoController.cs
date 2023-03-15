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
    public class IngredienteXProductoController : Controller
    {
        // GET: IngredienteXProducto

        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        //*********Procedimientos almacenados*********//
        public ActionResult listarIngredienteXProducto_PA()
        {
            List<modeloIngredienteXProducto> lobjRespuesta = new List<modeloIngredienteXProducto>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    var ingredientesXProducto = srvWCF_CR.recIngredienteXProducto_PA();
                    foreach (var item in ingredientesXProducto)
                    {
                        var producto = srvWCF_CR.recProductos_ENT().FirstOrDefault(p => p.Id_producto == item.Id_producto);
                        var ingrediente = srvWCF_CR.recIngredientes_PA().FirstOrDefault(i => i.Id_Ingrediente == item.Id_Ingrediente);

                        var modeloIngredienteXProducto = new modeloIngredienteXProducto
                        {
                            Id_ingredienteXproducto = item.Id_ingredienteXproducto,
                            Nombre_Producto = producto?.Nombre,
                            Nombre_Ingrediente = ingrediente?.Nombre_Ingrediente
                        };
                        lobjRespuesta.Add(modeloIngredienteXProducto);
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return View(lobjRespuesta);        
        }


        public ActionResult agregarIngredienteXProducto_PA()
        {
            srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient();
            ViewBag.Productos = new SelectList(db.recProductos_ENT().ToList(), "Id_producto", "Nombre");
            ViewBag.Ingredientes = new SelectList(db.recIngredientes_PA().ToList(), "Id_Ingrediente", "Nombre_Ingrediente");
            return View();
        }

        public ActionResult modificarIngredienteXProducto_PA(int pId)
        {
            recIngredienteXProductoxId_Result lobjRespuesta_PA = new recIngredienteXProductoxId_Result();
            modeloIngredienteXProducto lobjRespuesta = new modeloIngredienteXProducto();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recIngredienteXProductoXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_ingredienteXproducto = lobjRespuesta_PA.Id_ingredienteXproducto;
                    lobjRespuesta.Id_producto = lobjRespuesta_PA.Id_producto;
                    lobjRespuesta.Id_Ingrediente = lobjRespuesta_PA.Id_Ingrediente;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient();
            ViewBag.Productos = new SelectList(db.recProductos_ENT(), "Id_producto", "Nombre", lobjRespuesta.Id_producto);
            ViewBag.Ingredientes = new SelectList(db.recIngredientes_PA(), "Id_Ingrediente", "Nombre_Ingrediente", lobjRespuesta.Id_Ingrediente);

            return View(lobjRespuesta);
        }

        public ActionResult eliminarIngredienteXProducto_PA(int pId)
        {
            recIngredienteXProductoxId_Result lobjRespuesta_PA = new recIngredienteXProductoxId_Result();
            modeloIngredienteXProducto lobjRespuesta = new modeloIngredienteXProducto();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recIngredienteXProductoXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_ingredienteXproducto = lobjRespuesta_PA.Id_ingredienteXproducto;
                    lobjRespuesta.Id_producto = lobjRespuesta_PA.Id_producto;
                    lobjRespuesta.Id_Ingrediente = lobjRespuesta_PA.Id_Ingrediente;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detalleIngredienteXProducto_PA(int pId)
        {
            recIngredienteXProductoxId_Result lobjRespuesta_PA = new recIngredienteXProductoxId_Result();
            modeloIngredienteXProducto lobjRespuesta = new modeloIngredienteXProducto();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recIngredienteXProductoXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_ingredienteXproducto = lobjRespuesta_PA.Id_ingredienteXproducto;
                    lobjRespuesta.Id_producto = lobjRespuesta_PA.Id_producto;
                    lobjRespuesta.Id_Ingrediente = lobjRespuesta_PA.Id_Ingrediente;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        /*****Acciones procedimientos almacenados Ingrediente x Producto******/
        public ActionResult accionesPA(string enviarAccion, modeloIngredienteXProducto pModeloIngredienteXProducto)
        {
            try
            {
                Ingredientes_X_Producto pIngredienteXProducto = new Ingredientes_X_Producto();
                pIngredienteXProducto.Id_ingredienteXproducto = pModeloIngredienteXProducto.Id_ingredienteXproducto;
                pIngredienteXProducto.Id_producto = pModeloIngredienteXProducto.Id_producto;
                pIngredienteXProducto.Id_Ingrediente = pModeloIngredienteXProducto.Id_Ingrediente;


                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarIngredientxProducto_PA(pIngredienteXProducto);
                    case "Modificar":
                        return modificarIngredientxProducto_PA(pIngredienteXProducto);
                    case "Eliminar":
                        return eliminarIngredientxProducto_PA(pIngredienteXProducto);
                    default:
                        return RedirectToAction("listarIngredienteXProducto_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarIngredientxProducto_PA(Ingredientes_X_Producto pIngredienteXProducto)
        {
            List<recIngredientesXProducto_Result> lobjRespuesta = new List<recIngredientesXProducto_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insIngredienteXProducto_PA(pIngredienteXProducto))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recIngredienteXProducto_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarIngredienteXProducto_PA");

            //return View("listarIngredienteXProducto_PA", lobjRespuesta);
        }

        public ActionResult modificarIngredientxProducto_PA(Ingredientes_X_Producto pIngredienteXProducto)
        {
            List<recIngredientesXProducto_Result> lobjRespuesta = new List<recIngredientesXProducto_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modIngredienteXProducto_PA(pIngredienteXProducto))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recIngredienteXProducto_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarIngredienteXProducto_PA");

            //return View("listarIngredienteXProducto_PA", lobjRespuesta);
        }

        public ActionResult eliminarIngredientxProducto_PA(Ingredientes_X_Producto pIngredienteXProducto)
        {
            List<recIngredientesXProducto_Result> lobjRespuesta = new List<recIngredientesXProducto_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delIngredienteXProducto_PA(pIngredienteXProducto))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recIngredienteXProducto_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarIngredienteXProducto_PA");

            //return View("listarIngredienteXProducto_PA", lobjRespuesta);
        }
    }
}