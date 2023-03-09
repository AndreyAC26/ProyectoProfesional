using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloPerfiles
    {
        [Display(Name = "Codigo")]
        public int Perfil_Id { get; set; }

        [Display(Name = "Perfil")]
        public string nombre_perfil { get; set; }

    }
}