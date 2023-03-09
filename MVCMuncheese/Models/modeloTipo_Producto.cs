using NLog.Layouts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCMuncheese.Models
{
    public class modeloTipo_Producto
    {
        [Display(Name = "Codigo")]
        public int Id_tipo_Producto { get; set; }

        [Display(Name = "Tipo de Producto")]
        public string Nombre_tipo_pro { get; set; }
    }
}