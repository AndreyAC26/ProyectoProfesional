using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloLogin
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        [Display(Name = "Codigo")]
        public int Id_PerfilUsuario { get; set; }
    }
}
