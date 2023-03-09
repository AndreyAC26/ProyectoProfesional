using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloFacturas
    {
        [Display(Name = "Codigo")]
        public int Id_Factura { get; set; }

        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> fecha { get; set; }

        [Display(Name = "Orden")]
        public Nullable<int> Id_Orden { get; set; }

        [Display(Name = "Telefono")]
        public string Tel_Cliente { get; set; }

    }
}