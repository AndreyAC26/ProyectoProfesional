using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface ISeguridadAD
    {
        Usuarios recUsuario(string pUsrLogin);
    }
}
