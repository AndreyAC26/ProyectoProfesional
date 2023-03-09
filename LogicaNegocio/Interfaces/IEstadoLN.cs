using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IEstadoLN
    {
        List<recEstados_Result> recEstados_PA();
        recEstadoxId_Result recEstadoXId_PA(int pId);
        bool insEstado_PA(Estado pEstado);
        bool modEstado_PA(Estado pEstado);
        bool delEstado_PA(Estado pEstado);

    }
}
