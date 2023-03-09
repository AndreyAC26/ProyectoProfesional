using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloClientes
    {
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        public string Apellido_1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string Apellido_2 { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

    }
}