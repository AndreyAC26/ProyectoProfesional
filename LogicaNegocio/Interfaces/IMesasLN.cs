using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IMesasLN
    {
        List<recDetalleOrden_Result> recOrdenActivaXMesa_PA(int pId);
        List<recMesas_Result> recMesas_PA();
        recMesaxId_Result recMesasXId_PA(int pId);
        bool insMesas_PA(Mesas pMesas);
        bool modMesas_PA(Mesas pMesas);
        bool delMesas_PA(Mesas pMesas);

    }
}
