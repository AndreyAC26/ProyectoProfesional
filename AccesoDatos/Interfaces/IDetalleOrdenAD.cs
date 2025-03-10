﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IDetalleOrdenAD
    {
        //**************PROCEDIMIENTOS ALMACENADOS**************//
        List<recDetalleOrden_Result> recDetalleOrden_PA();
        recDetalleOrdenxId_Result recDetalleOrdenXId_PA(int pId);
        bool insDetalleOrden_PA(DetalleOrden pDetalleOrden);
        bool modDetalleOrden_PA(DetalleOrden pDetalleOrden);
        bool delDetalleOrden_PA(DetalleOrden pDetalleOrden);
        List<recDetalleOrdenConOrdenEstado1_Result> recDetalleOrdenEstado1_PA();
        //Entidades

        List<DetalleOrden> recDetalleOrden_ENT();
        DetalleOrden recDetalleOrdenXId_ENT(int pId);
        bool insDetalleOrden_ENT(DetalleOrden pDetalleOrden);
        bool modDetalleOrden_ENT(DetalleOrden pDetalleOrden);
        bool delDetalleOrden_ENT(DetalleOrden pDetalleOrden);

    }
}
