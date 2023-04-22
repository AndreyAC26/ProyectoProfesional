using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IOrdenesAD
    {
        List<recOrdenes_Result> recOrdenes_PA();
        recOrdenxId_Result recIOrdenesXId_PA(int pId);
        bool insOrden_PA(Ordenes pOrden);
        ObtenerProductosPorCategoria_Result recObtenerProductosPorCategoria_ResultsXId_PA(int pId);
        ObtenerOrdenesDeMesa_Result recObtenerOrdenesDeMesaXId_PA(int pId);
        List<Ordenes> recOrdenes_ENT();
        Ordenes recOrdenesXId_ENT(int pId);
        bool insOrdenes_ENT(Ordenes pOrdenes);
        bool modOrdenes_ENT(Ordenes pOrdenes);
        bool delOrdenes_ENT(Ordenes pOrdenes);



    }
}
