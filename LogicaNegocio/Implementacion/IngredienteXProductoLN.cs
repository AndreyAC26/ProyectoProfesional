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
    public class IngredienteXProductoLN : IIngredienteXProductoLN
    {
        //Conexion a Entidades
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();

        //Conexion a acceso datos

        private readonly IIngredientesXProductosAD gobjIngredienteXProductoAD = new IngredientesXProductosAD(_objContextoAW);

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recIngredientesXProducto_Result> recIngredientesXProductos_PA()
        {
            List<recIngredientesXProducto_Result> lobjRespuesta = new List<recIngredientesXProducto_Result>();
            try
            {
                lobjRespuesta = gobjIngredienteXProductoAD.recIngredientes_X_Producto_PA();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recIngredienteXProductoxId_Result recIngredientesXProductoXId_PA(int pId)
        {
            recIngredienteXProductoxId_Result lobjRespuesta = new recIngredienteXProductoxId_Result();
            try
            {
                lobjRespuesta = gobjIngredienteXProductoAD.recIngredienteXProductoXId_PA(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insIngredientes_X_Producto_PA(Ingredientes_X_Producto pIngredientes_X_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjIngredienteXProductoAD.insIngredienteXProducto_PA(pIngredientes_X_Producto);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool modIngredientes_X_Producto_PA(Ingredientes_X_Producto pIngredientes_X_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjIngredienteXProductoAD.modIngredienteXProducto_PA(pIngredientes_X_Producto);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool delIngredientes_X_Producto_PA(Ingredientes_X_Producto pIngredientes_X_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjIngredienteXProductoAD.insIngredienteXProducto_PA(pIngredientes_X_Producto);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
