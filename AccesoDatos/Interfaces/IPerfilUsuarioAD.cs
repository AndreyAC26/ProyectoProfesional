using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IPerfilUsuarioAD
    {
        //**************PROCEDIMIENTOS ALMACENADOS**************//

        List<recPerfilUsuario_Result> recPerfilUsuario_PA();
        recPerfilUsuarioxId_Result recIPerfilUsuarioXId_PA(int pId);
        bool insPerfilUsuario_PA(PerfilUsuario pPerfilUsuario);
        bool modPerfilUsuario_PA(PerfilUsuario pPerfilUsuario);
        bool delPerfilUsuario_PA(PerfilUsuario pPerfilUsuario);

    }
}
