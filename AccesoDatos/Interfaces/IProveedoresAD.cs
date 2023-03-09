using AccesoDatos.Implementacion;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IProveedoresAD
    {
        //**************PROCEDIMIENTOS ALMACENADOS**************//
        List<recProveedor_Result> recProveedores_PA();
        recProveedorxId_Result recProveedoresXId_PA(int pId);
        bool insProveedores_PA(Proveedor pProveedores);
        bool modProveedores_PA(Proveedor pProveedores);
        bool delProveedores_PA(Proveedor pProveedores);
    }
}
