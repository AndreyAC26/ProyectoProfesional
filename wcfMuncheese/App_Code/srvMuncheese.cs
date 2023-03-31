using AccesoDatos.Implementacion;
using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


public class srvMuncheese : IsrvMuncheese
{
    private readonly IClientesLN gobjClientesLN = new ClientesLN();
    private readonly IProveedoresLN gobjProveedoresLN = new ProveedoresLN();
    private readonly IIngredienteLN gobjIngredientesLN = new IngredientesLN();
    private readonly IProductosLN gobjProductosLN = new ProductosLN();
    private readonly ITipo_ProductoLN gobjTipo_ProductoLN = new Tipo_ProductoLN();
    private readonly IIngredienteXProductoLN gobjIngredientesXProductoLN = new IngredienteXProductoLN();
    private readonly IEstadoLN gobjEstadoLN = new EstadoLN();
    private readonly IMesasLN gobjMesasLN = new MesasLN();
    private readonly IOrdenesLN gobjOrdenesLN = new OrdenesLN();
    private readonly IDetalleOrdenLN gobjDetalleOrdenLN = new DetalleOrdenLN();
    private readonly IPerfilesLN gobjPerfilesLN = new PerfilesLN();
    private readonly IUsuariosLN gobjUsuariosLN = new UsuariosLN();
    private readonly IPerfilUsuarioLN gobjPerfilUsuarioLN = new PerfilUsuarioLN();
    private readonly IInventarioLN gobjInventarioLN = new InventarioLN();
    private readonly IFacturasLN gobjFacturasLN = new FacturasLN();
    private readonly ISeguridadLN gobjSeguridadLN = new SeguridadLN();




    //**************ENTIDADES Clientes**************//
    //Lista de clientes
    public List<Clientes> recClientes_ENT()
    {
        List<Clientes> lobjRespuesta = new List<Clientes>();
        try
        {
            lobjRespuesta = gobjClientesLN.recClientes_ENT();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Cliente por ID
    public Clientes recClientesXId_ENT(string pId)
    {
        Clientes lobjRespuesta = new Clientes();
        try
        {
            lobjRespuesta = gobjClientesLN.recClientesXId_ENT(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Insertar Cliente
    public bool insClientes_ENT(Clientes pClientes)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjClientesLN.insClientes_ENT(pClientes);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Modificar Cliente
    public bool modClientes_ENT(Clientes pClientes)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjClientesLN.modClientes_ENT(pClientes);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Borrar cliente
    public bool delClientes_ENT(Clientes pClientes)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjClientesLN.delClientes_ENT(pClientes);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************PROCEDIMIENTOS ALMACENADOS**************//


    public List<recCliente_Result> recCliente()
    {
        List<recCliente_Result> lobjRespuesta = new List<recCliente_Result>();
		try
		{
			lobjRespuesta = gobjClientesLN.recClientes();
		}
		catch (Exception lEx)
		{

			throw lEx;
		}
		return lobjRespuesta;
    }

	public recClientexId_Result recClientexId(string pId) 
	{
		recClientexId_Result lobjRespuesta = new recClientexId_Result();
		try
		{
			lobjRespuesta = gobjClientesLN.recClientexId(pId);
		}
		catch (Exception lEx)
		{

			throw lEx;
		}
		return lobjRespuesta;
	}
	public bool insCliente(Clientes pClientes)
	{
		bool lobjRespuesta = false;
		try
		{
			lobjRespuesta = gobjClientesLN.insCliente(pClientes);
		}
		catch (Exception lEx)
		{

			throw lEx;
		}
		return lobjRespuesta;
	}

    public bool modCliente(Clientes pClientes)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjClientesLN.modCliente(pClientes);
        }
        catch (Exception lEx)
        {

            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool delCliente(Clientes pClientes)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjClientesLN.delCliente(pClientes);
        }
        catch (Exception lEx)
        {

            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************PROCEDIMIENTOS ALMACENADOS Proveedores**************//
    public List<recProveedor_Result> recProveedores_PA()
    {
        List<recProveedor_Result> lobjRespuesta = new List<recProveedor_Result>();
        try
        {
            lobjRespuesta = gobjProveedoresLN.recProveedores_PA();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public recProveedorxId_Result recProveedoresXId_PA(int pId)
    {
        recProveedorxId_Result lobjRespuesta = new recProveedorxId_Result();
        try
        {
            lobjRespuesta = gobjProveedoresLN.recProveedoresXId_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool insProveedores_PA(Proveedor pProveedores)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjProveedoresLN.insProveedores_PA(pProveedores);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool modProveedores_PA(Proveedor pProveedores)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjProveedoresLN.modProveedores_PA(pProveedores);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool delProveedores_PA(Proveedor pProveedores)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjProveedoresLN.delProveedores_PA(pProveedores);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************PROCEDIMIENTOS ALMACENADOS Ingredientes**************//
    public List<recIngredientes_Result> recIngredientes_PA()
    {
        List<recIngredientes_Result> lobjRespuesta = new List<recIngredientes_Result>();
        try
        {
            lobjRespuesta = gobjIngredientesLN.recIngredientes_PA();
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
            lobjRespuesta = gobjIngredientesLN.recIngredienteXId_PA(pId);
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
            lobjRespuesta = gobjIngredientesLN.insIngredientes_PA(pIngredientes);
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
            lobjRespuesta = gobjIngredientesLN.modIngredientes_PA(pIngredientes);
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
            lobjRespuesta = gobjIngredientesLN.delIngredientes_PA(pIngredientes);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************ENTIDADES Productos**************//

    //Lista de Productos
    public List<Productos> recProductos_ENT()
    {
        List<Productos> lobjRespuesta = new List<Productos>();
        try
        {
            lobjRespuesta = gobjProductosLN.recProductos_ENT();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Productos por ID
    public Productos recProductosXId_ENT(int pId)
    {
        Productos lobjRespuesta = new Productos();
        try
        {
            lobjRespuesta = gobjProductosLN.recProductosXId_ENT(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Insertar Productos
    public bool insProductos_ENT(Productos pProductos)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjProductosLN.insProductos_ENT(pProductos);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Modificar Productos
    public bool modProductos_ENT(Productos pProductos)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjProductosLN.modProductos_ENT(pProductos);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Borrar Productos
    public bool delProductos_ENT(Productos pProductos)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjProductosLN.delProductos_ENT(pProductos);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }



    //**************ENTIDADES Tipo_Producto**************//
    //Lista de Tipo_Producto
    public List<Tipo_Producto> recTipo_Producto_ENT()
    {
        List<Tipo_Producto> lobjRespuesta = new List<Tipo_Producto>();
        try
        {
            lobjRespuesta = gobjTipo_ProductoLN.recTipo_Producto_ENT();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Tipo_Producto por ID
    public Tipo_Producto recTipo_ProductoXId_ENT(int pId)
    {
        Tipo_Producto lobjRespuesta = new Tipo_Producto();
        try
        {
            lobjRespuesta = gobjTipo_ProductoLN.recTipo_ProductoXId_ENT(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Insertar Tipo_Producto
    public bool insTipo_Producto_ENT(Tipo_Producto pTipo_Producto)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjTipo_ProductoLN.insTipo_Producto_ENT(pTipo_Producto);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Modificar Tipo_Producto
    public bool modTipo_Producto_ENT(Tipo_Producto pTipo_Producto)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjTipo_ProductoLN.modTipo_Producto_ENT(pTipo_Producto);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Borrar Tipo_Producto
    public bool delTipo_Producto_ENT(Tipo_Producto pTipo_Producto)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjTipo_ProductoLN.delTipo_Producto_ENT(pTipo_Producto);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************PROCEDIMIENTOS ALMACENADOS Tipo_Producto**************//
    public List<recTipo_Producto_Result> recTipo_Producto_PA()
    {
        List<recTipo_Producto_Result> lobjRespuesta = new List<recTipo_Producto_Result>();
        try
        {
            lobjRespuesta = gobjTipo_ProductoLN.recTipo_Producto_PA();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public recTipo_ProductoxId_Result recTipo_ProductoXId_PA(int pId)
    {
        recTipo_ProductoxId_Result lobjRespuesta = new recTipo_ProductoxId_Result();
        try
        {
            lobjRespuesta = gobjTipo_ProductoLN.recTipo_ProductoXId_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }
    public bool insTipo_Producto_PA(Tipo_Producto pTipo_Producto)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjTipo_ProductoLN.insTipo_Producto_PA(pTipo_Producto);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool modTipo_Producto_PA(Tipo_Producto pTipo_Producto)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjTipo_ProductoLN.modTipo_Producto_PA(pTipo_Producto);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool delTipo_Producto_PA(Tipo_Producto pTipo_Producto)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjTipo_ProductoLN.delTipo_Producto_PA(pTipo_Producto);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //**************PROCEDIMIENTOS ALMACENADOS IngredientesXProducto**************//
    public List<recIngredientesXProducto_Result> recIngredienteXProducto_PA()
    {
        List<recIngredientesXProducto_Result> lobjRespuesta = new List<recIngredientesXProducto_Result>();
        try
        {
            lobjRespuesta = gobjIngredientesXProductoLN.recIngredientesXProductos_PA();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public recIngredienteXProductoxId_Result recIngredienteXProductoXId_PA(int pId)
    {
        recIngredienteXProductoxId_Result lobjRespuesta = new recIngredienteXProductoxId_Result();
        try
        {
            lobjRespuesta = gobjIngredientesXProductoLN.recIngredientesXProductoXId_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }
    public bool insIngredienteXProducto_PA(Ingredientes_X_Producto pIngredienteXProducto)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjIngredientesXProductoLN.insIngredientes_X_Producto_PA(pIngredienteXProducto);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool modIngredienteXProducto_PA(Ingredientes_X_Producto pIngredienteXProducto)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjIngredientesXProductoLN.modIngredientes_X_Producto_PA(pIngredienteXProducto);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool delIngredienteXProducto_PA(Ingredientes_X_Producto pIngredienteXProducto)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjIngredientesXProductoLN.delIngredientes_X_Producto_PA(pIngredienteXProducto);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }



    //**************PROCEDIMIENTOS ALMACENADOS Estado**************//
    public List<recEstados_Result> recEstado_PA()
    {
        List<recEstados_Result> lobjRespuesta = new List<recEstados_Result>();
        try
        {
            lobjRespuesta = gobjEstadoLN.recEstados_PA();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public recEstadoxId_Result recEstadoXId_PA(int pId)
    {
        recEstadoxId_Result lobjRespuesta = new recEstadoxId_Result();
        try
        {
            lobjRespuesta = gobjEstadoLN.recEstadoXId_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }
    public bool insEstado_PA(Estado pEstado)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjEstadoLN.insEstado_PA(pEstado);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool modEstado_PA(Estado pEstado)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjEstadoLN.modEstado_PA(pEstado);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool delEstado_PA(Estado pEstado)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjEstadoLN.delEstado_PA(pEstado);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //**************PROCEDIMIENTOS ALMACENADOS Mesas**************//
    public List<recMesas_Result> recMesas_PA()
    {
        List<recMesas_Result> lobjRespuesta = new List<recMesas_Result>();
        try
        {
            lobjRespuesta = gobjMesasLN.recMesas_PA();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public recMesaxId_Result recMesaXId_PA(int pId)
    {
        recMesaxId_Result lobjRespuesta = new recMesaxId_Result();
        try
        {
            lobjRespuesta = gobjMesasLN.recMesasXId_PA(pId);
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
            lobjRespuesta = gobjMesasLN.insMesas_PA(pMesas);
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
            lobjRespuesta = gobjMesasLN.modMesas_PA(pMesas);
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
            lobjRespuesta = gobjMesasLN.delMesas_PA(pMesas);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************ENTIDADES Ordenes**************//

    public List<recOrdenes_Result> recOrdenes_PA()
    {
        List<recOrdenes_Result> lobjRespuesta = new List<recOrdenes_Result>();
        try
        {
            lobjRespuesta = gobjOrdenesLN.recOrdenes_PA();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public recOrdenxId_Result recOrdenesXId_PA(int pId)
    {
        recOrdenxId_Result lobjRespuesta = new recOrdenxId_Result();
        try
        {
            lobjRespuesta = gobjOrdenesLN.recOrdenesXId_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    public bool insOrdenes_PAa(Ordenes pOrdenes)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjOrdenesLN.insOrdenes_PA(pOrdenes);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //Productos por categoria
    public ObtenerProductosPorCategoria_Result recObtenerProductosPorCategoria_ResultXId_PA(int pId)
    {
        ObtenerProductosPorCategoria_Result lobjRespuesta = new ObtenerProductosPorCategoria_Result();
        try
        {
            lobjRespuesta = gobjOrdenesLN.recObtenerProductosPorCategoria_ResultXId_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public ObtenerOrdenesDeMesa_Result ObtenerOrdenesDeMesa_PA(int pId)
    {
        ObtenerOrdenesDeMesa_Result lobjRespuesta = new ObtenerOrdenesDeMesa_Result();
        try
        {
            lobjRespuesta = gobjOrdenesLN.recObtenerOrdenesDeMesa_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Lista de Ordenes
    public List<Ordenes> recOrdenes_ENT()
    {
        List<Ordenes> lobjRespuesta = new List<Ordenes>();
        try
        {
            lobjRespuesta = gobjOrdenesLN.recOrdenes_ENT();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Ordenes por ID
    public Ordenes recOrdenesXId_ENT(int pId)
    {
        Ordenes lobjRespuesta = new Ordenes();
        try
        {
            lobjRespuesta = gobjOrdenesLN.recOrdenesXId_ENT(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Insertar Ordenes
    public bool insOrdenes_ENT(Ordenes pOrdenes)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjOrdenesLN.insOrdenes_ENT(pOrdenes);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Modificar Ordenes
    public bool modOrdenes_ENT(Ordenes pOrdenes)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjOrdenesLN.modOrdenes_ENT(pOrdenes);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Borrar Ordenes
    public bool delOrdenes_ENT(Ordenes pOrdenes)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjOrdenesLN.delOrdenes_ENT(pOrdenes);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************PROCEDIMIENTOS ALMACENADOS DetalleOrden**************//
    public List<recDetalleOrden_Result> recDetalleOrden_PA()
    {
        List<recDetalleOrden_Result> lobjRespuesta = new List<recDetalleOrden_Result>();
        try
        {
            lobjRespuesta = gobjDetalleOrdenLN.recDetalleOrden_PA();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public recDetalleOrdenxId_Result recDetalleOrdenXId_PA(int pId)
    {
        recDetalleOrdenxId_Result lobjRespuesta = new recDetalleOrdenxId_Result();
        try
        {
            lobjRespuesta = gobjDetalleOrdenLN.recDetalleOrdenXId_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }
    public bool insDetalleOrden_PA(DetalleOrden pDetalleOrden)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjDetalleOrdenLN.insDetalleOrden_PA(pDetalleOrden);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool modDetalleOrden_PA(DetalleOrden pDetalleOrden)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjDetalleOrdenLN.modDetalleOrden_PA(pDetalleOrden);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool delDetalleOrden_PA(DetalleOrden pDetalleOrden)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjDetalleOrdenLN.delDetalleOrden_PA(pDetalleOrden);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************ENTIDADES DetalleOrden**************//



    //Lista de DetalleOrden
    public List<DetalleOrden> recDetalleOrden_ENT()
    {
        List<DetalleOrden> lobjRespuesta = new List<DetalleOrden>();
        try
        {
            lobjRespuesta = gobjDetalleOrdenLN.recDetalleOrden_ENT();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //DetalleOrden por ID
    public DetalleOrden recDetalleOrdenXId_ENT(int pId)
    {
        DetalleOrden lobjRespuesta = new DetalleOrden();
        try
        {
            lobjRespuesta = gobjDetalleOrdenLN.recDetalleOrdenXId_ENT(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Insertar DetalleOrden
    public bool insDetalleOrden_ENT(DetalleOrden pDetalleOrden)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjDetalleOrdenLN.insDetalleOrden_ENT(pDetalleOrden);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Modificar DetalleOrden
    public bool modDetalleOrden_ENT(DetalleOrden pDetalleOrden)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjDetalleOrdenLN.modDetalleOrden_ENT(pDetalleOrden);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //Borrar DetalleOrden
    public bool delDetalleOrden_ENT(DetalleOrden pDetalleOrden)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjDetalleOrdenLN.insDetalleOrden_ENT(pDetalleOrden);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************PROCEDIMIENTOS ALMACENADOS Perfiles**************//
    public List<recPerfiles_Result> recPerfiles_PA()
    {
        List<recPerfiles_Result> lobjRespuesta = new List<recPerfiles_Result>();
        try
        {
            lobjRespuesta = gobjPerfilesLN.recPerfiles_PA();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public recMesaPerfilxId_Result recPerfilesXId_PA(int pId)
    {
        recMesaPerfilxId_Result lobjRespuesta = new recMesaPerfilxId_Result();
        try
        {
            lobjRespuesta = gobjPerfilesLN.recPerfilesXId_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }
    public bool insPerfiles_PA(Perfiles pPerfiles)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjPerfilesLN.insPerfiles_PA(pPerfiles);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool modPerfiles_PA(Perfiles pPerfiles)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjPerfilesLN.modPerfiles_PA(pPerfiles);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool delPerfiles_PA(Perfiles pPerfiles)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjPerfilesLN.delPerfiles_PA(pPerfiles);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************PROCEDIMIENTOS ALMACENADOS Usuarios**************//
    public List<recUsuarios_Result> recUsuarios_PA()
    {
        List<recUsuarios_Result> lobjRespuesta = new List<recUsuarios_Result>();
        try
        {
            lobjRespuesta = gobjUsuariosLN.recUsuarios_PA();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public recUsuarioxId_Result recUsuariosXId_PA(string pId)
    {
        recUsuarioxId_Result lobjRespuesta = new recUsuarioxId_Result();
        try
        {
            lobjRespuesta = gobjUsuariosLN.recUsuariosXId_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }
    public bool insUsuarios_PA(Usuarios pUsuarios)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjUsuariosLN.insUsuarios_PA(pUsuarios);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool modUsuarios_PA(Usuarios pUsuarios)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjUsuariosLN.modUsuarios_PA(pUsuarios);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool delUsuarios_PA(Usuarios pUsuarios)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjUsuariosLN.delUsuarios_PA(pUsuarios);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************PROCEDIMIENTOS ALMACENADOS PerfilUsuario**************//
    public List<recPerfilUsuario_Result> recPerfilUsuario_PA()
    {
        List<recPerfilUsuario_Result> lobjRespuesta = new List<recPerfilUsuario_Result>();
        try
        {
            lobjRespuesta = gobjPerfilUsuarioLN.recPerfilUsuario_PA();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public recPerfilUsuarioxId_Result recPerfilUsuarioXId_PA(int pId)
    {
        recPerfilUsuarioxId_Result lobjRespuesta = new recPerfilUsuarioxId_Result();
        try
        {
            lobjRespuesta = gobjPerfilUsuarioLN.recPerfilUsuarioXId_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }
    public bool insPerfilUsuario_PA(PerfilUsuario pPerfilUsuario)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjPerfilUsuarioLN.insPerfilUsuario_PA(pPerfilUsuario);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool modPerfilUsuario_PA(PerfilUsuario pPerfilUsuario)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjPerfilUsuarioLN.modPerfilUsuario_PA(pPerfilUsuario);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool delPerfilUsuario_PA(PerfilUsuario pPerfilUsuario)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjPerfilUsuarioLN.delPerfilUsuario_PA(pPerfilUsuario);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************PROCEDIMIENTOS ALMACENADOS Inventario**************//
    public List<recInventario_Result> recInventario_PA()
    {
        List<recInventario_Result> lobjRespuesta = new List<recInventario_Result>();
        try
        {
            lobjRespuesta = gobjInventarioLN.recInventario_PA();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public recInventarioxId_Result recInventarioXId_PA(int pId)
    {
        recInventarioxId_Result lobjRespuesta = new recInventarioxId_Result();
        try
        {
            lobjRespuesta = gobjInventarioLN.recInventarioXId_PA(pId);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }
    public bool insInventario_PA(Inventario pInventario)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjInventarioLN.insInventario_PA(pInventario);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool modInventario_PA(Inventario pInventario)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjInventarioLN.modInventario_PA(pInventario);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    public bool delInventario_PA(Inventario pInventario)
    {
        bool lobjRespuesta = false;
        try
        {
            lobjRespuesta = gobjInventarioLN.delInventario_PA(pInventario);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }


    //**************PROCEDIMIENTOS ALMACENADOS Facturas**************//
    public List<recFacturas_Result> recFacturas_PA()
    {
        List<recFacturas_Result> lobjRespuesta = new List<recFacturas_Result>();
        try
        {
            lobjRespuesta = gobjFacturasLN.recFacturas_PA();
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
            lobjRespuesta = gobjFacturasLN.recFacturasXId_PA(pId);
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
            lobjRespuesta = gobjFacturasLN.insFacturas_PA(pFacturas);
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
            lobjRespuesta = gobjFacturasLN.modFacturas_PA(pFacturas);
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
            lobjRespuesta = gobjFacturasLN.delFacturas_PA(pFacturas);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

    //**************Entidades Seguridad**************//

    public Usuarios recUsuario(string pUsrLogin)
    {
        Usuarios lobjRespuesta = new Usuarios();
        try
        {
            lobjRespuesta = gobjSeguridadLN.recUsuario(pUsrLogin);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return lobjRespuesta;
    }

}
