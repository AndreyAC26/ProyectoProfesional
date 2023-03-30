using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IDetalleOrdenLN
    {
        //**************PROCEDIMIENTOS ALMACENADOS**************//
        List<recDetalleOrden_Result> recDetalleOrden_PA();
        recDetalleOrdenxId_Result recDetalleOrdenXId_PA(int pId);
        bool insDetalleOrden_PA(DetalleOrden pDetalleOrden);
        bool modDetalleOrden_PA(DetalleOrden pDetalleOrden);
        bool delDetalleOrden_PA(DetalleOrden pDetalleOrden);

        //**************ENTIDADES**************//

        List<DetalleOrden> recDetalleOrden_ENT();
        DetalleOrden recDetalleOrdenXId_ENT(int pId);
        bool insDetalleOrden_ENT(DetalleOrden pDetalleOrden);
        bool modDetalleOrden_ENT(DetalleOrden pDetalleOrden);
        bool delDetalleOrden_ENT(DetalleOrden pDetalleOrden);
    }
}
