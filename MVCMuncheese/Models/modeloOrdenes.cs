using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloOrdenes
    {
        [Display(Name = "Num. Orden")]
        public int Id_Orden { get; set; }

        [Display(Name = "Estado")]
        public Nullable<int> Estado { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Cantidad")]
        public Nullable<int> Cantidad { get; set; }

        [Display(Name = "Descripcion")]
        public string Descipcion { get; set; }

        [Display(Name = "Mesa")]
        public Nullable<int> Mesa { get; set; }

        [Display(Name = "Precio")]
        public Nullable<int> Precio { get; set; }


        [Display(Name = "Producto")]
        public Nullable<int> Id_producto { get; set; }

        [Display(Name = "Producto")]
        public string Nombre_producto { get; set; } // nueva propiedad

        [Display(Name = "Orden")]
        public string Tipo_orden { get; set; }

        [Display(Name = "Categoria")]
        public int Tipo_Producto { get; set; }

        public List<Orden> Ordenes { get; set; }
    }

    public class Orden
    {
        public int Tipo_Producto { get; set; }
        public int Id_producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}