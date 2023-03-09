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
    public class FacturasAD : IFacturasAD
    {
        //Conexion a la base de datos
        private MuncheeseEntidades gObjConexionAW;
        private readonly Logger gObjError = LogManager.GetCurrentClassLogger();

        public FacturasAD(MuncheeseEntidades lObjConexionAW)
        {
            gObjConexionAW = lObjConexionAW;
        }

        //**************PROCEDIMIENTOS ALMACENADOS**************//

        public List<recFacturas_Result> recFacturas_PA()
        {
            List<recFacturas_Result> lobjRespuesta = new List<recFacturas_Result>();
            try
            {
                lobjRespuesta = gObjConexionAW.recFacturas().ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }

        public recFacturaxId_Result recFacturasXId_PA(int pId)
        {
            recFacturaxId_Result lobjRespuesta = new recFacturaxId_Result();
            try
            {
                lobjRespuesta = gObjConexionAW.recFacturaxId(pId).FirstOrDefault();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
        public bool insFacturas_PA(Facturas pFacturas)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.insFactura(pFacturas.fecha,
                    pFacturas.Id_Orden, pFacturas.Tel_Cliente) == 1)
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

        public bool modFacturas_PA(Facturas pFacturas)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.modFactura(pFacturas.Id_Factura, pFacturas.fecha,
                    pFacturas.Id_Orden, pFacturas.Tel_Cliente) == 1)
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

        public bool delFacturas_PA(Facturas pFacturas)
        {
            bool lobjRespuesta = false;
            try
            {
                if (gObjConexionAW.delFactura(pFacturas.Id_Factura) == 1)
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
