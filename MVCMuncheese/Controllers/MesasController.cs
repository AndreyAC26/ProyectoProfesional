using Entidades;
using MVCMuncheese.Models;
using MVCMuncheese.Models.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMuncheese.Controllers
{
    public class MesasController : Controller
    {
        // GET: Mesas
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public ActionResult Mesas()
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            List<MesaViewModel> mesas = new List<MesaViewModel>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recMesas_PA();
                    foreach (var mesa in lobjRespuesta)
                    {
                        var estado = mesa.Estado == 1 ? "Activo" : "Ocupado"; // Nuevo código agregado
                        mesas.Add(new MesaViewModel { NumeroMesa = mesa.Id_Mesa, Estado = mesa.Estado, EstadoMesa = estado });
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(mesas);
        }

        private modeloMesas ConvertirAModeloMesas(recMesas_Result mesa, List<recEstados_Result> estados)
        {
            var estado = estados.FirstOrDefault(e => e.Id_Estado == mesa.Estado);
            return new modeloMesas
            {
                Id_Mesa = mesa.Id_Mesa,
                NombreMesa = mesa.NombreMesa,
                Estado = mesa.Estado,
                Estados = estado != null ? estado.Estado : ""
            };
        }


        //*********Procedimientos almacenados*********//
        public ActionResult listarMesas_PA()
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();

            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recMesas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            // Obtenemos la lista de estados
            List<recEstados_Result> lobjEstados = new List<recEstados_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjEstados = srvWCF_CR.recEstado_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            //// Unimos las dos listas mediante un join y seleccionamos los campos que nos interesan
            //var listaMesas = from mesa in lobjRespuesta
            //                 join estado in lobjEstados
            //                 on mesa.Estado equals estado.Id_Estado
            //                 select new modeloMesas
            //                 {
            //                     Id_Mesa = mesa.Id_Mesa,
            //                     NombreMesa = mesa.NombreMesa,
            //                     Estados = estado.Estado
            //                 };

            // Convertir cada objeto recMesas_Result a modeloMesas
            var listaMesas = new List<modeloMesas>();
            foreach (var mesa in lobjRespuesta)
            {
                listaMesas.Add(ConvertirAModeloMesas(mesa, lobjEstados));
            }

            ViewBag.Estados = lobjEstados;
            return View(listaMesas);
        }


        public ActionResult agregarMesas_PA()
        {
            srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient();
            ViewBag.Estado = new SelectList(db.recEstado_PA().ToList(), "Id_Estado", "Estado");
            return View();
        }


        public ActionResult modificarMesas_PA(int pId)
        {
            recMesaxId_Result lobjRespuesta_PA = new recMesaxId_Result();
            modeloMesas lobjRespuesta = new modeloMesas();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recMesaXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Mesa = lobjRespuesta_PA.Id_Mesa;
                    lobjRespuesta.NombreMesa = lobjRespuesta_PA.NombreMesa;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            srvMuncheese.IsrvMuncheeseClient db = new srvMuncheese.IsrvMuncheeseClient();
            ViewBag.Estados = new SelectList(db.recEstado_PA(), "Id_Estado", "Estado", lobjRespuesta.Estado);
            return View(lobjRespuesta);
        }

        public ActionResult eliminarMesas_PA(int pId)
        {
            recMesaxId_Result lobjRespuesta_PA = new recMesaxId_Result();
            modeloMesas lobjRespuesta = new modeloMesas();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recMesaXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Mesa = lobjRespuesta_PA.Id_Mesa;
                    lobjRespuesta.NombreMesa = lobjRespuesta_PA.NombreMesa;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detalleMesas_PA(int pId)
        {
            recMesaxId_Result lobjRespuesta_PA = new recMesaxId_Result();
            modeloMesas lobjRespuesta = new modeloMesas();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recMesaXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Id_Mesa = lobjRespuesta_PA.Id_Mesa;
                    lobjRespuesta.NombreMesa = lobjRespuesta_PA.NombreMesa;
                    lobjRespuesta.Estado = lobjRespuesta_PA.Estado;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        /*****Acciones procedimientos almacenados Mesas******/
        public ActionResult accionesPA(string enviarAccion, modeloMesas pModeloMesas)
        {
            try
            {
                Mesas pMesas = new Mesas();
                pMesas.Id_Mesa = pModeloMesas.Id_Mesa;
                pMesas.NombreMesa = pModeloMesas.NombreMesa;
                pMesas.Estado = pModeloMesas.Estado;


                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarMesa_PA(pMesas);
                    case "Modificar":
                        return modificarMesa_PA(pMesas);
                    case "Eliminar":
                        return eliminarMesa_PA(pMesas);
                    default:
                        return RedirectToAction("listarMesas_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarMesa_PA(Mesas pMesas)
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insMesas_PA(pMesas))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {

                    }
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recMesas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarMesas_PA");
        }

        public ActionResult modificarMesa_PA(Mesas pMesas)
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {

                    if (srvWCF_CR.modMesas_PA(pMesas))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recMesas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarMesas_PA");
        }

        public ActionResult eliminarMesa_PA(Mesas pMesas)
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delMesas_PA(pMesas))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recMesas_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarMesas_PA");
        }

    }
}