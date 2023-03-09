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
    public class ProveedoresAD : IProveedoresAD
    {
        //Conexion a la base de datos
        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public ProveedoresAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recProveedor_Result> recProveedores_PA()
        {
            List<recProveedor_Result> lobjRespuesta = new List<recProveedor_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recProveedor().ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recProveedorxId_Result recProveedoresXId_PA(int pId)
        {
            recProveedorxId_Result lobjRespuesta = new recProveedorxId_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.recProveedorxId(pId).FirstOrDefault();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insProveedores_PA(Proveedor pProveedores)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.insProveedor(pProveedores.Id_Proveedor, pProveedores.Nombre, pProveedores.Apellido_1, pProveedores.Apellido_2,
                    pProveedores.Telefono, pProveedores.Producto) == 1)
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

        public bool modProveedores_PA(Proveedor pProveedores)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.modProveedor(pProveedores.Id_Proveedor, pProveedores.Nombre, pProveedores.Apellido_1, pProveedores.Apellido_2,
                    pProveedores.Telefono, pProveedores.Producto) == 1)
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

        public bool delProveedores_PA(Proveedor pProveedores)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.DELProveedor(pProveedores.Id_Proveedor) == 1)
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
    }
}
