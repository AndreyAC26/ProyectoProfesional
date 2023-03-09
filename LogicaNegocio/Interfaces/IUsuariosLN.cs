using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IUsuariosLN
    {
        List<recUsuarios_Result> recUsuarios_PA();
        recUsuarioxId_Result recUsuariosXId_PA(string pId);
        bool insUsuarios_PA(Usuarios pUsuarios);
        bool modUsuarios_PA(Usuarios pUsuarios);
        bool delUsuarios_PA(Usuarios pUsuarios);

    }
}
