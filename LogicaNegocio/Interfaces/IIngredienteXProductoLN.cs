using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IIngredienteXProductoLN
    {
        List<recIngredientesXProducto_Result> recIngredientesXProductos_PA();
        recIngredienteXProductoxId_Result recIngredientesXProductoXId_PA(int pId);
        bool insIngredientes_X_Producto_PA(Ingredientes_X_Producto pIngredientes_X_Producto);
        bool modIngredientes_X_Producto_PA(Ingredientes_X_Producto pIngredientes_X_Producto);
        bool delIngredientes_X_Producto_PA(Ingredientes_X_Producto pIngredientes_X_Producto);
    }
}
