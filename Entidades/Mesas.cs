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
    
    public partial class Mesas
    {
        public int Id_Mesa { get; set; }
        public string NombreMesa { get; set; }
        public Nullable<int> Estado { get; set; }
    
        public virtual Estado Estado1 { get; set; }
    }
}
