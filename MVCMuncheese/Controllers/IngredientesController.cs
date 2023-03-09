using Entidades;
using Microsoft.Ajax.Utilities;
using MVCMuncheese.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMuncheese.Controllers
{
    public class IngredientesController : Controller
    {
        // GET: Ingredientes
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        //*********Procedimientos almacenados*********//
        public ActionResult listarIngredientes_PA()
        {
            List<recIngredientes_Result> lobjRespuesta = new List<recIngredientes_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recIngredientes_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult agregarIngrediente_PA()
        {
            return View();
        }

        public ActionResult modificarIngredientes_PA(int pId)
        {
            recIngredientexId_Result lobjRespuesta_PA = new recIngredientexId_Result();
            modeloIngredientes lobjRespuesta = new modeloIngredientes();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recIngredientesXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Ingrediente = lobjRespuesta_PA.Id_Ingrediente;
                    lobjRespuesta.Nombre_Ingrediente = lobjRespuesta_PA.Nombre_Ingrediente;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult eliminarIngredientes_PA(int pId)
        {
            recIngredientexId_Result lobjRespuesta_PA = new recIngredientexId_Result();
            modeloIngredientes lobjRespuesta = new modeloIngredientes();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recIngredientesXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Ingrediente = lobjRespuesta_PA.Id_Ingrediente;
                    lobjRespuesta.Nombre_Ingrediente = lobjRespuesta_PA.Nombre_Ingrediente;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detalleIngrediente_PA(int pId)
        {
            recIngredientexId_Result lobjRespuesta_PA = new recIngredientexId_Result();
            modeloIngredientes lobjRespuesta = new modeloIngredientes();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recIngredientesXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Ingrediente = lobjRespuesta_PA.Id_Ingrediente;
                    lobjRespuesta.Nombre_Ingrediente = lobjRespuesta_PA.Nombre_Ingrediente;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        /*****Acciones procedimientos almacenados Ingredientes******/
        public ActionResult accionesPA(string enviarAccion, modeloIngredientes pModeloIngredientes)
        {
            try
            {
                Ingredientes pIngredientes = new Ingredientes();
                pIngredientes.Id_Ingrediente = pModeloIngredientes.Id_Ingrediente;
                pIngredientes.Nombre_Ingrediente = pModeloIngredientes.Nombre_Ingrediente;

                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarIngrediente_PA(pIngredientes);
                    case "Modificar":
                        return modificarIngrediente_PA(pIngredientes);
                    case "Eliminar":
                        return eliminarIngrediente_PA(pIngredientes);
                    default:
                        return RedirectToAction("listarIngredientes_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarIngrediente_PA(Ingredientes pIngredientes)
        {
            List<recIngredientes_Result> lobjRespuesta = new List<recIngredientes_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insIngredientes_PA(pIngredientes))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recIngredientes_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarIngredientes_PA", lobjRespuesta);
        }

        public ActionResult modificarIngrediente_PA(Ingredientes pIngredientes)
        {
            List<recIngredientes_Result> lobjRespuesta = new List<recIngredientes_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.modIngredientes_PA(pIngredientes))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recIngredientes_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarIngredientes_PA", lobjRespuesta);
        }

        public ActionResult eliminarIngrediente_PA(Ingredientes pIngredientes)
        {
            List<recIngredientes_Result> lobjRespuesta = new List<recIngredientes_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delIngredientes_PA(pIngredientes))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recIngredientes_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("listarIngredientes_PA", lobjRespuesta);
        }
    }
}