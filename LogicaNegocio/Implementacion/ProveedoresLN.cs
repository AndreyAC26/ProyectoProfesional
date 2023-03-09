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
    public class ProveedoresLN : IProveedoresLN
    {
        //Conexion a accesoDatos
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();
        //Conexion a acceso datos

        private readonly IProveedoresAD gobjProveedoresAD = new ProveedoresAD(_objContextoAW);

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recProveedor_Result> recProveedores_PA()
        {
            List<recProveedor_Result> lobjRespuesta = new List<recProveedor_Result>();
            try
            {
                lobjRespuesta = gobjProveedoresAD.recProveedores_PA();
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
                lobjRespuesta = gobjProveedoresAD.recProveedoresXId_PA(pId);
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
                lobjRespuesta = gobjProveedoresAD.insProveedores_PA(pProveedores);
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
                lobjRespuesta = gobjProveedoresAD.modProveedores_PA(pProveedores);
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
                lobjRespuesta = gobjProveedoresAD.delProveedores_PA(pProveedores);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
