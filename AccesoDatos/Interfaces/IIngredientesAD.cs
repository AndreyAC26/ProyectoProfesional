using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IIngredientesAD
    {
        List<recIngredientes_Result> recIngredientes_PA();
        recIngredientexId_Result recIngredientesXId_PA(int pId);
        bool insIngredientes_PA(Ingredientes pIngredientes);
        bool modIngredientes_PA(Ingredientes pIngredientes);
        bool delIngredientes_PA(Ingredientes pIngredientes);

    }
}
