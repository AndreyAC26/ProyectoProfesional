using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using AccesoDatos;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion
{
    public class FacturasLN : IFacturasLN
    {
        //Conexion a Entidades
        public static MuncheeseEntidades _objContextoAW = new MuncheeseEntidades();

        //Conexion a acceso datos

        private readonly IFacturasAD gobjFacturasAD = new FacturasAD(_objContextoAW);

        //**************PROCEDIMIENTOS ALMACENADOS**************//
        public List<recFacturas_Result> recFacturas_PA()
        {
            List<recFacturas_Result> lobjRespuesta = new List<recFacturas_Result>();
            try
            {
                lobjRespuesta = gobjFacturasAD.recFacturas_PA();
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
                lobjRespuesta = gobjFacturasAD.recFacturasXId_PA(pId);
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
                lobjRespuesta = gobjFacturasAD.insFacturas_PA(pFacturas);
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
                lobjRespuesta = gobjFacturasAD.modFacturas_PA(pFacturas);
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
                lobjRespuesta = gobjFacturasAD.delFacturas_PA(pFacturas);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lobjRespuesta;
        }
    }
}
