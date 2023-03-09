using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloProveedores
    {
        [Display(Name = "Codigo")]
        public int Id_Proveedor { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        public string Apellido_1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string Apellido_2 { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "producto")]
        public string Producto { get; set; }

    }
}