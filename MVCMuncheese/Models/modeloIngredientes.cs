using Entidades;
using MVCMuncheese.srvMuncheese;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMuncheese.Models
{
    public class modeloIngredientes
    {

        [Display(Name ="Codigo")]
        public int Id_Ingrediente { get; set; }

        [Display(Name = "Ingrediente")]
        public string Nombre_Ingrediente { get; set; }


    }
}