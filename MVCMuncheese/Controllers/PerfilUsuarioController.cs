using AccesoDatos;
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
    public class PerfilUsuarioController : Controller
    {
        // GET: PerfilUsuario

        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        //*********Procedimientos almacenados*********//
        //public ActionResult listarPerfilUsuario_PA()
        //{
        //    List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
        //    try
        //    {
        //        using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
        //        {
        //            lobjRespuesta = srvWCF_CR.recPerfilUsuario_PA();
        //        }
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return View(lobjRespuesta);
        //}

        public ActionResult listarPerfilUsuario_PA()
        {
            List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
            List<modeloPerfilUsuario> lobjModeloPerfilUsuario = new List<modeloPerfilUsuario>();

            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta = srvWCF_CR.recPerfilUsuario_PA();

                    foreach (var item in lobjRespuesta)
                    {
                        var perfil = srvWCF_CR.recPerfilesXId_PA(item.Perfil_Id.Value);
                        string nombrePerfil = perfil.nombre_perfil;

                        lobjModeloPerfilUsuario.Add(new modeloPerfilUsuario
                        {
                            Perfil_Id = item.Perfil_Id,
                            Usuario = item.Usuario,
                            Id_PerfilUsuario = item.Id_PerfilUsuario,
                            NombrePerfil = nombrePerfil
                        });
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return View(lobjModeloPerfilUsuario);
        }



        public ActionResult agregarPerfilUsuario_PA()
        {
            // Obtenemos la lista de perfiles desde el servicio web
            srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient();
            var perfiles = srvWCF_CR.recPerfiles_PA();

            // Creamos la lista de objetos SelectListItem para los perfiles
            var listaPerfiles = perfiles.Select(p => new SelectListItem
            {
                Value = p.Perfil_Id.ToString(),
                Text = p.nombre_perfil
            });

            // Obtenemos la lista de usuarios desde el servicio web
            var usuarios = srvWCF_CR.recUsuarios_PA();

            // Creamos la lista de objetos SelectListItem para los usuarios
            var listaUsuarios = usuarios.Select(u => new SelectListItem
            {
                Value = u.Usuario,
                Text = u.Usuario
            });

            // Asignamos las listas de perfiles y usuarios al modelo
            var modelo = new MVCMuncheese.Models.modeloPerfilUsuario
            {
                Perfiles = listaPerfiles.ToList(),
                Usuarios = listaUsuarios.ToList()
            };

            return View(modelo);
        }

        public ActionResult modificarPerfilUsuario_PA(int pId)
        {
            recPerfilUsuarioxId_Result lobjRespuesta_PA = new recPerfilUsuarioxId_Result();
            modeloPerfilUsuario lobjRespuesta = new modeloPerfilUsuario();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recPerfilUsuarioXId_PA(pId);

                    // Obtener la lista de perfiles y crear los SelectListItem
                    var perfiles = srvWCF_CR.recPerfiles_PA();
                    var listaPerfiles = perfiles.Select(p => new SelectListItem
                    {
                        Value = p.Perfil_Id.ToString(),
                        Text = p.nombre_perfil
                    });

                    // Obtener la lista de usuarios y crear los SelectListItem
                    var usuarios = srvWCF_CR.recUsuarios_PA();
                    var listaUsuarios = usuarios.Select(u => new SelectListItem
                    {
                        Value = u.Usuario,
                        Text = u.Usuario
                    });

                    // Asignar las listas al modelo

                    // Asignar las listas al modelo
                    lobjRespuesta.Perfiles = listaPerfiles.ToList();
                    lobjRespuesta.ListaUsuarios = listaUsuarios.ToList();
                }

                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Perfil_Id = lobjRespuesta_PA.Perfil_Id;
                    lobjRespuesta.Usuario = lobjRespuesta_PA.Usuario;
                    lobjRespuesta.Id_PerfilUsuario = lobjRespuesta_PA.Id_PerfilUsuario;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return View(lobjRespuesta);
        }
 

        public ActionResult eliminarPerfilUsuario_PA(int pId)
        {
            recPerfilUsuarioxId_Result lobjRespuesta_PA = new recPerfilUsuarioxId_Result();
            modeloPerfilUsuario lobjRespuesta = new modeloPerfilUsuario();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recPerfilUsuarioXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Perfil_Id = lobjRespuesta_PA.Perfil_Id;
                    lobjRespuesta.Usuario = lobjRespuesta_PA.Usuario;
                    lobjRespuesta.Id_PerfilUsuario = lobjRespuesta_PA.Id_PerfilUsuario;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        public ActionResult detallePerfilUsuario_PA(int pId)
        {
            recPerfilUsuarioxId_Result lobjRespuesta_PA = new recPerfilUsuarioxId_Result();
            modeloPerfilUsuario lobjRespuesta = new modeloPerfilUsuario();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    lobjRespuesta_PA = srvWCF_CR.recPerfilUsuarioXId_PA(pId);
                }
                if (lobjRespuesta_PA != null)
                {
                    lobjRespuesta.Perfil_Id = lobjRespuesta_PA.Perfil_Id;
                    lobjRespuesta.Usuario = lobjRespuesta_PA.Usuario;
                    lobjRespuesta.Id_PerfilUsuario = lobjRespuesta_PA.Id_PerfilUsuario;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return View(lobjRespuesta);
        }

        /*****Acciones procedimientos almacenados PerfilUsuario******/
        public ActionResult accionesPA(string enviarAccion, modeloPerfilUsuario pModeloPerfilUsuario)
        {
            try
            {
                PerfilUsuario pPerfilUsuario = new PerfilUsuario();
                pPerfilUsuario.Perfil_Id = pModeloPerfilUsuario.Perfil_Id;
                pPerfilUsuario.Usuario = pModeloPerfilUsuario.Usuario;
                pPerfilUsuario.Id_PerfilUsuario = pModeloPerfilUsuario.Id_PerfilUsuario;

                switch (enviarAccion)
                {
                    case "Agregar":
                        return insertarUserPerfil_PA(pPerfilUsuario);
                    case "Modificar":
                        return modificarUserPerfil_PA(pPerfilUsuario);
                    case "Eliminar":
                        return eliminarUserPerfil_PA(pPerfilUsuario);
                    default:
                        return RedirectToAction("listarPerfilUsuario_PA");
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public ActionResult insertarUserPerfil_PA(PerfilUsuario pPerfilUsuario)
        {
            List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.insPerfilUsuario_PA(pPerfilUsuario))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recPerfilUsuario_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarPerfilUsuario_PA");
        }

        public ActionResult modificarUserPerfil_PA(PerfilUsuario pPerfilUsuario)
        {
            List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
            try
            {
                // Asignar el valor seleccionado en el dropdownlist a la propiedad Usuario del objeto PerfilUsuario
                pPerfilUsuario.Usuario = pPerfilUsuario.Usuario;
                // Asignar el valor seleccionado en el dropdownlist a la propiedad Perfil_Id del objeto PerfilUsuario
                pPerfilUsuario.Perfil_Id = pPerfilUsuario.Perfil_Id;

                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    // Llamar al método modPerfilUsuario_PA y pasarle el objeto actualizado
                    if (srvWCF_CR.modPerfilUsuario_PA(pPerfilUsuario))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recPerfilUsuario_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarPerfilUsuario_PA");
        }




        public ActionResult eliminarUserPerfil_PA(PerfilUsuario pPerfilUsuario)
        {
            List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
            try
            {
                using (srvMuncheese.IsrvMuncheeseClient srvWCF_CR = new srvMuncheese.IsrvMuncheeseClient())
                {
                    if (srvWCF_CR.delPerfilUsuario_PA(pPerfilUsuario))
                    {
                        //enviar mensaje positivo
                    }
                    else
                    {
                        //enviar mensaje negativo
                    }
                    lobjRespuesta = srvWCF_CR.recPerfilUsuario_PA();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("listarPerfilUsuario_PA");
        }

    }
}