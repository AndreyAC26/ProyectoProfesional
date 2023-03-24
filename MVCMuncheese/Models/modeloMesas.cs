using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloMesas
    {
        [Display(Name = "Codigo")]
        public int Id_Mesa { get; set; }

        [Display(Name = "Mesa")]
        public string NombreMesa { get; set; }

        [Display(Name = "Estado")]
        public Nullable<int> Estado { get; set; }
        public string Estados { get; set; }

    }
}