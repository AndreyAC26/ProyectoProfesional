using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IClientesAD
    {
        List<Clientes> recClientes_ENT();
        Clientes recClientesXId_ENT(string pId);
        bool insClientes_ENT(Clientes pClientes);
        bool modClientes_ENT(Clientes pClientes);
        bool delClientes_ENT(Clientes pClientes);


        List<recCliente_Result> recCliente();
        recClientexId_Result recClientexId(string pId);
        bool insCliente(Clientes pClientes);
        bool modCliente(Clientes pClientes);
        bool delCliente(Clientes pClientes);
    }
}
