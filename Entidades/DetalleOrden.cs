//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleOrden
    {
        public int Id_Detalle { get; set; }
        public int Id_Orden { get; set; }
        public Nullable<int> Id_producto { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<int> Mesa { get; set; }
        public Nullable<int> Precio { get; set; }
        public string Tipo_orden { get; set; }
        public string Descripcion { get; set; }
    
        public virtual Ordenes Ordenes { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
