using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IPerfilesAD
    {
        List<recPerfiles_Result> recPerfiles_PA();
        recMesaPerfilxId_Result recIPerfilesXId_PA(int pId);
        bool insPerfiles_PA(Perfiles pPerfiles);
        bool modPerfiles_PA(Perfiles pPerfiles);
        bool delPerfiles_PA(Perfiles pPerfiles);

    }
}
