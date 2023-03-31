using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
            public class modeloDetalleOrden
            {
                [Display(Name = "Num. Detalle")]
                public int Id_Detalle { get; set; }

                [Display(Name = "Num. Orden")]
                public int Id_Orden { get; set; }

                [Display(Name = "Producto")]
                public Nullable<int> Id_producto { get; set; }

                [Display(Name = "Producto")]
                public List<Productos> Productos { get; set; }

                [Display(Name = "Producto")]
                public string Nombre_producto { get; set; }        // nueva propiedad

                [Display(Name = "Cantidad")]
                public Nullable<int> Cantidad { get; set; }

                [Display(Name = "Mesa")]
                public Nullable<int> Mesa { get; set; }

                [Display(Name = "Precio")]
                public Nullable<int> Precio { get; set; }

                [Display(Name = "Orden")]
                public string Tipo_orden { get; set; }

                [Display(Name = "Descripcion")]
                public string Descripcion { get; set; }

                [Display(Name = "Categoria")]
                public int Tipo_Producto { get; set; }

                public int UltimoIdOrden { get; set; }


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