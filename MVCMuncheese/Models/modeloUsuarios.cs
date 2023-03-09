using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMuncheese.Models
{
    public class modeloUsuarios
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public Nullable<int> Estado { get; set; }

    }
}