using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using AccesoDatos;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion
{
    public class InventarioLN : IInventarioLN
    {
        //Conexion a Entidades
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();

        //Conexion a acceso datos

        private readonly IInventarioAD gobjInventarioAD = new InventarioAD(_objContextoAW);

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recInventario_Result> recInventario_PA()
        {
            List<recInventario_Result> lobjRespuesta = new List<recInventario_Result>();
            try
            {
                lobjRespuesta = gobjInventarioAD.recInventario_PA();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recInventarioxId_Result recInventarioXId_PA(int pId)
        {
            recInventarioxId_Result lobjRespuesta = new recInventarioxId_Result();
            try
            {
                lobjRespuesta = gobjInventarioAD.recInventarioXId_PA(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insInventario_PA(Inventario pInventario)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjInventarioAD.insInventario_PA(pInventario);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool modInventario_PA(Inventario pInventario)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjInventarioAD.modInventario_PA(pInventario);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool delInventario_PA(Inventario pInventario)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjInventarioAD.delInventario_PA(pInventario);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
