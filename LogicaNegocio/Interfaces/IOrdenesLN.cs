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
        List<recOrdenes_Result> recOrdenes_PA();
        recOrdenxId_Result recOrdenesXId_PA(int pId);
        bool insOrdenes_PA(Ordenes pOrdenes);
        ObtenerProductosPorCategoria_Result recObtenerProductosPorCategoria_ResultXId_PA(int pId);
        ObtenerOrdenesDeMesa_Result recObtenerOrdenesDeMesa_PA(int pId);
        List<Ordenes> recOrdenes_ENT();
        Ordenes recOrdenesXId_ENT(int pId);
        bool insOrdenes_ENT(Ordenes pOrdenes);
        bool modOrdenes_ENT(Ordenes pOrdenes);
        bool delOrdenes_ENT(Ordenes pOrdenes);

    }
}
