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
    public class InventarioAD : IInventarioAD
    {
        //Conexion a la base de datos
        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public InventarioAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recInventario_Result> recInventario_PA()
        {
            List<recInventario_Result> lobjRespuesta = new List<recInventario_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recInventario().ToList();
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
                lobjRespuesta = gObjConexionAW.recInventarioxId(pId).FirstOrDefault();
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
                if (gObjConexionAW.insInventario(pInventario.Nombre_Producto, pInventario.Cantidad, pInventario.Id_Producto) == 1)
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

        public bool modInventario_PA(Inventario pInventario)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.modInventario(pInventario.Id_inventario, pInventario.Nombre_Producto, pInventario.Cantidad, pInventario.Id_Producto) == 1)
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

        public bool delInventario_PA(Inventario pInventario)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.delInventario(pInventario.Id_inventario) == 1)
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
