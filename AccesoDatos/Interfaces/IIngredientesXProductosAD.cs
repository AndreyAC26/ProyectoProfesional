using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IIngredientesXProductosAD
    {
        List<recIngredientesXProducto_Result> recIngredientes_X_Producto_PA();
        recIngredienteXProductoxId_Result recIngredienteXProductoXId_PA(int pId);
        bool insIngredienteXProducto_PA(Ingredientes_X_Producto pIngredientes_X_Producto);
        bool modIngredienteXProducto_PA(Ingredientes_X_Producto pIngredientes_X_Producto);
        bool delIngredienteXProducto_PA(Ingredientes_X_Producto pIngredientes_X_Producto);
    }
}
