using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloIngredienteXProducto
    {
        [Display(Name = "Codigo")]
        public int Id_ingredienteXproducto { get; set; }

        [Display(Name = "Producto")]
        public int Id_producto { get; set; }

        [Display(Name = "Ingrediente")]
        public Nullable<int> Id_Ingrediente { get; set; }
    }
}