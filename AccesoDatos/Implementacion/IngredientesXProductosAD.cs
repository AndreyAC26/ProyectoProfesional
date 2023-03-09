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
    public class IngredientesXProductosAD : IIngredientesXProductosAD
    {
        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public IngredientesXProductosAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recIngredientesXProducto_Result> recIngredientes_X_Producto_PA()
        {
            List<recIngredientesXProducto_Result> lobjRespuesta = new List<recIngredientesXProducto_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recIngredientesXProducto().ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recIngredienteXProductoxId_Result recIngredienteXProductoXId_PA(int pId)
        {
            recIngredienteXProductoxId_Result lobjRespuesta = new recIngredienteXProductoxId_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.recIngredienteXProductoxId(pId).FirstOrDefault();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insIngredienteXProducto_PA(Ingredientes_X_Producto pIngredientes_X_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.insIngredienteXProducto(pIngredientes_X_Producto.Id_ingredienteXproducto, pIngredientes_X_Producto.Id_producto, pIngredientes_X_Producto.Id_Ingrediente) == 1)
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

        public bool modIngredienteXProducto_PA(Ingredientes_X_Producto pIngredientes_X_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.modIngredientesXProducto(pIngredientes_X_Producto.Id_ingredienteXproducto, pIngredientes_X_Producto.Id_producto, pIngredientes_X_Producto.Id_Ingrediente) == 1)
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

        public bool delIngredienteXProducto_PA(Ingredientes_X_Producto pIngredientes_X_Producto)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.delIngredienteXproducto(pIngredientes_X_Producto.Id_ingredienteXproducto) == 1)
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
