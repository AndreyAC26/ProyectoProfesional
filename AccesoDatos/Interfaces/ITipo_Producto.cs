using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface ITipo_Producto
    {
        //**************ENTIDADES**************//
        List<Tipo_Producto> recTipo_Producto_ENT();
        Tipo_Producto recTipo_ProductoXId_ENT(int pId);
        bool insTipo_Producto_ENT(Tipo_Producto pTipo_Producto);
        bool modTipo_Producto_ENT(Tipo_Producto pTipo_Producto);
        bool delTipo_Producto_ENT(Tipo_Producto pTipo_Producto);


        //**************PROCEDIMIENTOS ALMACENADOS**************//
        List<recTipo_Producto_Result> recTipo_Producto_PA();
        recTipo_ProductoxId_Result recTipo_ProductoXId_PA(int pId);
        bool insTipo_Producto_PA(Tipo_Producto pTipo_Producto);
        bool modTipo_Producto_PA(Tipo_Producto pTipo_Producto);
        bool delTipo_Producto_PA(Tipo_Producto pTipo_Producto);
    }
}
