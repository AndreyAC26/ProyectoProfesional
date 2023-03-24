using AccesoDatos.Interfaces;
using Entidades;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class IngredientesAD : IIngredientesAD
    {
        //Conexion a la base de datos
        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public IngredientesAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recIngredientes_Result> recIngredientes_PA()
        {
            List<recIngredientes_Result> lobjRespuesta = new List<recIngredientes_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recIngredientes().ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recIngredientexId_Result recIngredientesXId_PA(int pId)
        {
            recIngredientexId_Result lobjRespuesta = new recIngredientexId_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.recIngredientexId(pId).FirstOrDefault();
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
                if (gObjConexionAW.insIngrediente(pIngredientes.Id_Ingrediente, pIngredientes.Nombre_Ingrediente) == 1)
                {
                    lobjRespuesta = true;
                }
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
                if (gObjConexionAW.modIngrediente(pIngredientes.Id_Ingrediente, pIngredientes.Nombre_Ingrediente) == 1)
                {
                    lobjRespuesta = true;
                }
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
                if (gObjConexionAW.delIngrediente(pIngredientes.Id_Ingrediente) == 1)
                {
                    lobjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
