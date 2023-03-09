using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IInventarioLN
    {
        List<recInventario_Result> recInventario_PA();
        recInventarioxId_Result recInventarioXId_PA(int pId);
        bool insInventario_PA(Inventario pInventario);
        bool modInventario_PA(Inventario pInventario);
        bool delInventario_PA(Inventario pInventario);

    }
}
