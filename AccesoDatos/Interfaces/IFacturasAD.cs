using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IFacturasAD
    {
        List<recFacturas_Result> recFacturas_PA();
        recFacturaxId_Result recFacturasXId_PA(int pId);
        bool insFacturas_PA(Facturas pFacturas);
        bool modFacturas_PA(Facturas pFacturas);
        bool delFacturas_PA(Facturas pFacturas);

    }
}
