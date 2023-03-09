using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion
{
    public class ClientesLN : IClientesLN
    {
        //Conexion a accesoDatos
        public static MuncheeseEntidades _objContexto = new MuncheeseEntidades();
        private readonly IClientesAD gobjClientesAD = new ClientesAD(_objContexto);

        //**************ENTIDADES**************//

        //Lista de clientes
        public List<Clientes> recClientes_ENT()
        {
            List<Clientes> lobjRespuesta = new List<Clientes>();
            try
            {
                lobjRespuesta = gobjClientesAD.recClientes_ENT();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Cliente por ID
        public Clientes recClientesXId_ENT(string pId)
        {
            Clientes lobjRespuesta = new Clientes();
            try
            {
                lobjRespuesta = gobjClientesAD.recClientesXId_ENT(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Insertar cliente
        public bool insClientes_ENT(Clientes pClientes)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjClientesAD.insClientes_ENT(pClientes);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Modificar cliente
        public bool modClientes_ENT(Clientes pClientes)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjClientesAD.modClientes_ENT(pClientes);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //Borrar Cliente
        public bool delClientes_ENT(Clientes pClientes)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjClientesAD.delClientes_ENT(pClientes);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }


        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recCliente_Result> recClientes()
        {
            List<recCliente_Result> lobjRespuesta = new List<recCliente_Result>();
            try
            {
                lobjRespuesta = gobjClientesAD.recCliente();
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lobjRespuesta;
        }

        public recClientexId_Result recClientexId(string pId) 
        {
            recClientexId_Result lobjRespuesta = new recClientexId_Result();
            try
            {
                lobjRespuesta = gobjClientesAD.recClientexId(pId);
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
                lobjRespuesta = gobjClientesAD.insCliente(pClientes);
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
                lobjRespuesta = gobjClientesAD.modCliente(pClientes);
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
                lobjRespuesta = gobjClientesAD.delCliente(pClientes);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lobjRespuesta;
        }

    }
}
