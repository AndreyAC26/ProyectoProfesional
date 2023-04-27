using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloPerfilUsuario
    {
        [Display(Name = "Perfil")]
        public Nullable<int> Perfil_Id { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Display(Name = "Codigo")]
        public int Id_PerfilUsuario { get; set; }

        [Display(Name = "Perfil")]
        public string NombrePerfil { get; set; }
    }
}