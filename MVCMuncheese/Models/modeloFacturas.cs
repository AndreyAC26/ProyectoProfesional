using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
        public class modeloFacturas
        {
            [Display(Name = "Num. Factura")]
            public int Id_Factura { get; set; }

            [Display(Name = "Fecha")]
            public Nullable<System.DateTime> fecha { get; set; }

            [Display(Name = "Orden")]
            public Nullable<int> Id_Orden { get; set; }

            [Display(Name = "Telefono")]
            public string Tel_Cliente { get; set; }

            [Display(Name = "Cliente")]
            public string Cliente { get; set; }

            [Display(Name = "Mesa")]
            public int mesa { get; set; }

        public SelectList MesasOcupadas { get; set; }
        public SelectList OrdenesActivas { get; set; }
            public List<SelectListItem> Clientes { get; set; }
    }

}