using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementacion
{
    public class IngredientesLN : IIngredienteLN
    {
        //Conexion a Entidades
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();

        //Conexion a acceso datos

        private readonly IIngredientesAD gobjIngredientesAD = new IngredientesAD(_objContextoAW);

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recIngredientes_Result> recIngredientes_PA()
        {
            List<recIngredientes_Result> lobjRespuesta = new List<recIngredientes_Result>();
            try
            {
                lobjRespuesta = gobjIngredientesAD.recIngredientes_PA();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recIngredientexId_Result recIngredienteXId_PA(int pId)
        {
            recIngredientexId_Result lobjRespuesta = new recIngredientexId_Result();
            try
            {
                lobjRespuesta = gobjIngredientesAD.recIngredientesXId_PA(pId);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insIngredientes_PA(Ingredientes pIngredientes)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjIngredientesAD.insIngredientes_PA(pIngredientes);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool modIngredientes_PA(Ingredientes pIngredientes)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjIngredientesAD.modIngredientes_PA(pIngredientes);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool delIngredientes_PA(Ingredientes pIngredientes)
        {
            bool lobjRespuesta = false;
            try
            {
                lobjRespuesta = gobjIngredientesAD.delIngredientes_PA(pIngredientes);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
