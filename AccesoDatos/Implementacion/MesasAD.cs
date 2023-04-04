using AccesoDatos.Interfaces;
using Entidades;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class MesasAD : IMesasAD
    {
        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public MesasAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        public List<recMesas_Result> recMesasActivas()
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            try
            {
                using (var db = new MuncheeseEntidades()) // Reemplaza DbContext con el nombre de tu contexto de base de datos
                {
                    var result = db.Database.SqlQuery<int?>("recMesasActivasDO").ToList();
                    lobjRespuesta = result.Select(x => new recMesas_Result { Id_Mesa = (int)x }).ToList();
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recMesas_Result> recMesas_PA()
        {
            List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recMesas().ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

      

        public recMesaxId_Result recMesasXId_PA(int pId)
        {
            recMesaxId_Result lobjRespuesta = new recMesaxId_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.recMesaxId(pId).FirstOrDefault();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public bool insMesas_PA(Mesas pMesas)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.insMesa(pMesas.NombreMesa, pMesas.Estado) == 1)
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

        public bool modMesas_PA(Mesas pMesas)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.modMesa(pMesas.Id_Mesa, pMesas.NombreMesa, pMesas.Estado) == 1)
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

        public bool delMesas_PA(Mesas pMesas)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.delMesa(pMesas.Id_Mesa) == 1)
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
