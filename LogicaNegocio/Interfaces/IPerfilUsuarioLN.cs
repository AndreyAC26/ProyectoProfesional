using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IPerfilUsuarioLN
    {
        //**************PROCEDIMIENTOS ALMACENADOS**************//

        List<recPerfilUsuario_Result> recPerfilUsuario_PA();
        recPerfilUsuarioxId_Result recPerfilUsuarioXId_PA(int pId);
        bool insPerfilUsuario_PA(PerfilUsuario pPerfilUsuario);
        bool modPerfilUsuario_PA(PerfilUsuario pPerfilUsuario);
        bool delPerfilUsuario_PA(PerfilUsuario pPerfilUsuario);

    }
}
