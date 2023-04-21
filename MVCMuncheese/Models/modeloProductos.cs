using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloProductos
    {
        [Display(Name = "Codigo")]
        public int Id_producto { get; set; }

        [Display(Name = "Producto")]
        public string Nombre { get; set; }

        [Display(Name = "Tipo de producto")]
        public Nullable<int> Tipo_producto { get; set; }
        public string Nombre_tipo_producto { get; set; } // propiedad para agregar el nombre del tipo producto

        [Display(Name = "Precio")]
        public Nullable<int> Precio { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

    }
}