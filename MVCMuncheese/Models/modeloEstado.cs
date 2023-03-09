using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloEstado
    {
        [Display(Name = "Codigo")]
        public int Id_Estado { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}