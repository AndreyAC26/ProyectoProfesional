using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IProductosAD
    {
        //**************ENTIDADES**************//
        List<Productos> recProductos_ENT();
        Productos recProductosXId_ENT(int pId);
        bool insProductos_ENT(Productos pProductos);
        bool modProductos_ENT(Productos pProductos);
        bool delProductos_ENT(Productos pProductos);


        //**************PROCEDIMIENTOS ALMACENADOS**************//
        //List<recProductos_Result> recProductos_PA();
        //recProductosxId_Result recProductosXId_PA(int pId);
        //bool insProductos_PA(Productos pProductos);
        //bool insertProductos_PA(Productos pProductos);
        //bool modProductos_PA(Productos pProductos);
        //bool delProductos_PA(Productos pProductos);

    }
}
