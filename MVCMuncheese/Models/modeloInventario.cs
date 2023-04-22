using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloInventario
    {
        [Display(Name = "Codigo")]
        public int Id_inventario { get; set; }

        [Display(Name = "Producto")]
        public string Nombre_Producto { get; set; }

        [Display(Name = "Cantidad")]
        public Nullable<int> Cantidad { get; set; }

        [Display(Name = "Codigo Producto")]
        public Nullable<int> Id_Producto { get; set; }

        [Display(Name = "Agregar a la cantidad")]
        public Nullable<int> CantidadExtra { get; set; }
    }
}