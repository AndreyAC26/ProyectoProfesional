using AccesoDatos.Interfaces;
using Entidades;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class ClientesAD : IClientesAD
    {
        //Conexion a la base de datos

        private MuncheeseEntidades gObjConexion;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public ClientesAD(MuncheeseEntidades lObjConexion)
        {
            gObjConexion = lObjConexion;
        }

        //**************ENTIDADES**************//

        //Lista de todos los clientes
        public List<Clientes> recClientes_ENT()
        {
            List<Clientes> lobjRespuesta = new List<Clientes>();
            try
            {
                gObjConexion.Configuration.ProxyCreationEnabled = false;
                lobjRespuesta = gObjConexion.Clientes.ToList();
            }
            catch (Exception lEx)
            {
                //throw lEx;
                gObjError.Error("Se produjo un error. Detalle: " + lEx.Message + " " + lEx.InnerException.Message +
                    " . Ubicación: " + System.Reflection.MethodInfo.GetCurrentMethod().ToString());
            }
            finally
            {
                gObjConexion.Configuration.ProxyCreationEnabled = true;
            }
            return lobjRespuesta;
        }

        //Lista de los clientes por el ID
        public Clientes recClientesXId_ENT(string pId)
        {
            Clientes lobjRespuesta = new Clientes();
            try
            {
                gObjConexion.Configuration.ProxyCreationEnabled = false;
                lobjRespuesta = gObjConexion.Clientes.ToList().Find(cr => cr.Telefono == pId.ToString());
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjConexion.Configuration.ProxyCreationEnabled = true;
            }
            return lobjRespuesta;
        }

        //Insertar clientes
        public bool insClientes_ENT(Clientes pClientes)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexion.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexion.Clientes.Find(pClientes.Telefono);
                if (regEncontrado == null)
                {
                    gObjConexion.Clientes.Add(pClientes);
                    gObjConexion.SaveChanges();
                    lobjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjConexion.Configuration.ProxyCreationEnabled = true;
            }
            return lobjRespuesta;
        }

        //Modificar clientes
        public bool modClientes_ENT(Clientes pClientes)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexion.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexion.Clientes.Find(pClientes.Telefono);
                if (regEncontrado != null)
                {
                    gObjConexion.Entry(regEncontrado).CurrentValues.SetValues(pClientes);
                    gObjConexion.Entry(regEncontrado).State = System.Data.Entity.EntityState.Modified;
                    gObjConexion.SaveChanges();
                    lobjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjConexion.Configuration.ProxyCreationEnabled = true;
            }
            return lobjRespuesta;
        }

        //Borrar clientes
        public bool delClientes_ENT(Clientes pClientes)
        {
            bool lobjRespuesta = false;
            try
            {
                gObjConexion.Configuration.ProxyCreationEnabled = false;
                var regEncontrado = gObjConexion.Clientes.Find(pClientes.Telefono);
                if (regEncontrado != null)
                {
                    gObjConexion.Entry(regEncontrado).CurrentValues.SetValues(pClientes);
                    gObjConexion.Entry(regEncontrado).State = System.Data.Entity.EntityState.Deleted;
                    gObjConexion.SaveChanges();
                    lobjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjConexion.Configuration.ProxyCreationEnabled = true;
            }
            return lobjRespuesta;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recCliente_Result> recCliente()
        {
            List<recCliente_Result> lobjRespuesta = new List<recCliente_Result>();
            try
            {
                lobjRespuesta = gObjConexion.recCliente().ToList();
            }
            catch (Exception lEX)
            {

                throw lEX;
            }
            return lobjRespuesta;
        }


        public recClientexId_Result recClientexId(string pId) 
        {
        recClientexId_Result lobjRespuesta = new recClientexId_Result();
            try
            {
                lobjRespuesta = gObjConexion.recClientexId(pId).FirstOrDefault();
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool insCliente(Clientes pClientes)
        {
            bool lobjRespuesta = false;
            try
            {
                if(gObjConexion.insCliente(pClientes.Telefono, pClientes.Nombre, pClientes.Apellido_1, pClientes.Apellido_2,pClientes.Direccion) == 1)
                {
                    lobjRespuesta= true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool modCliente(Clientes pClientes)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexion.modCliente(pClientes.Telefono, pClientes.Nombre, pClientes.Apellido_1, pClientes.Apellido_2, pClientes.Direccion) == 1)
                {
                    lobjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool delCliente(Clientes pClientes)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexion.DELCliente(pClientes.Telefono) == 1)
                {
                    lobjRespuesta= true;
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lobjRespuesta;
        }

    }
}
