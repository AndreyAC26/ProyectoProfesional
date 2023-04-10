using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMuncheese.Models.ViewModels
{
    public class MesaViewModel
    {
        public int NumeroMesa { get; set; }
        public string nombreMesa { get; set; }

        public Nullable<int> Estado { get; set; }
        public string EstadoMesa { get; set; } // Nueva propiedad agregada

    }
}