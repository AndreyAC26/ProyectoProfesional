using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IOrdenesLN
    {
        ObtenerProductosPorCategoria_Result recObtenerProductosPorCategoria_ResultXId_PA(int pId);
        List<Ordenes> recOrdenes_ENT();
        Ordenes recOrdenesXId_ENT(int pId);
        bool insOrdenes_ENT(Ordenes pOrdenes);
        bool modOrdenes_ENT(Ordenes pOrdenes);
        bool delOrdenes_ENT(Ordenes pOrdenes);

    }
}
