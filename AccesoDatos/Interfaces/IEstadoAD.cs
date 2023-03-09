using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IEstadoAD
    {
        List<recEstados_Result> recEstado_PA();
        recEstadoxId_Result recIEstadoXId_PA(int pId);
        bool insEstado_PA(Estado pEstado);
        bool modEstado_PA(Estado pEstado);
        bool delEstado_PA(Estado pEstado);

    }
}
