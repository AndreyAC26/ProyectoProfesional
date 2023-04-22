using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IsrvMuncheese" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IsrvMuncheese
{
    //Clientes Entidades
    [OperationContract]
    List<Clientes> recClientes_ENT();

    [OperationContract]
    Clientes recClientesXId_ENT(string pId);

    [OperationContract]
    bool insClientes_ENT(Clientes pClientes);

    [OperationContract]
    bool modClientes_ENT(Clientes pClientes);

    [OperationContract]
    bool delClientes_ENT(Clientes pClientes);

    //Clientes PROCEDIMIENTOS ALMACENADOS

    [OperationContract]
    List<recCliente_Result> recCliente();

    [OperationContract]
    recClientexId_Result recClientexId(string pId);

    [OperationContract]
    bool insCliente(Clientes pClientes);

    [OperationContract]
    bool modCliente(Clientes pClientes);

    [OperationContract]
    bool delCliente(Clientes pClientes);

    //**************PROCEDIMIENTOS ALMACENADOS Proveedores**************//
    [OperationContract]
    List<recProveedor_Result> recProveedores_PA();

    [OperationContract]
    recProveedorxId_Result recProveedoresXId_PA(int pId);

    [OperationContract]
    bool insProveedores_PA(Proveedor pProveedores);

    [OperationContract]
    bool modProveedores_PA(Proveedor pProveedores);

    [OperationContract]
    bool delProveedores_PA(Proveedor pProveedores);

    //**************PROCEDIMIENTOS ALMACENADOS Ingredientes**************//

    [OperationContract]
    List<recIngredientes_Result> recIngredientes_PA();

    [OperationContract]
    recIngredientexId_Result recIngredientesXId_PA(int pId);

    [OperationContract]
    bool insIngredientes_PA(Ingredientes pIngredientes);

    [OperationContract]
    bool modIngredientes_PA(Ingredientes pIngredientes);

    [OperationContract]
    bool delIngredientes_PA(Ingredientes pIngredientes);

    //**************ENTIDADES Productos**************//

    [OperationContract]
    List<Productos> recProductos_ENT();
    [OperationContract]
    Productos recProductosXId_ENT(int pId);
    [OperationContract]
    bool insProductos_ENT(Productos pProductos);
    [OperationContract]
    bool modProductos_ENT(Productos pProductos);
    [OperationContract]
    bool delProductos_ENT(Productos pProductos);

    //**************PROCEDIMIENTOS ALMACENADOS Productos**************//

    //[OperationContract]
    //List<recProductos_Result> recProductos_PA();

    //[OperationContract]
    //recProductosxId_Result recProductosXId_PA(int pId);

    //[OperationContract]
    //bool insProductos_PA(Productos pProductos);

    //[OperationContract]
    //bool insertProductos_PA(Productos pProductos);

    //[OperationContract]
    //bool modProductos_PA(Productos pProductos);

    //[OperationContract]
    //bool delProductos_PA(Productos pProductos);

    //**************ENTIDADES Tipo_Producto**************//
    [OperationContract]
    List<Tipo_Producto> recTipo_Producto_ENT();

    [OperationContract]
    Tipo_Producto recTipo_ProductoXId_ENT(int pId);

    [OperationContract]
    bool insTipo_Producto_ENT(Tipo_Producto pTipo_Producto);

    [OperationContract]
    bool modTipo_Producto_ENT(Tipo_Producto pTipo_Producto);

    [OperationContract]
    bool delTipo_Producto_ENT(Tipo_Producto pTipo_Producto);


    //**************PROCEDIMIENTOS ALMACENADOS Tipo Producto**************//

    [OperationContract]
    List<recTipo_Producto_Result> recTipo_Producto_PA();

    [OperationContract]
    recTipo_ProductoxId_Result recTipo_ProductoXId_PA(int pId);

    [OperationContract]
    bool insTipo_Producto_PA(Tipo_Producto pTipo_Producto);

    [OperationContract]
    bool modTipo_Producto_PA(Tipo_Producto pTipo_Producto);

    [OperationContract]
    bool delTipo_Producto_PA(Tipo_Producto pTipo_Producto);

    //**************PROCEDIMIENTOS ALMACENADOS IngredientesXProducto**************//
    [OperationContract]
    List<recIngredientesXProducto_Result> recIngredienteXProducto_PA();

    [OperationContract]
    recIngredienteXProductoxId_Result recIngredienteXProductoXId_PA(int pId);

    [OperationContract]
    bool insIngredienteXProducto_PA(Ingredientes_X_Producto pIngredienteXProducto);

    [OperationContract]
    bool modIngredienteXProducto_PA(Ingredientes_X_Producto pIngredienteXProducto);

    [OperationContract]
    bool delIngredienteXProducto_PA(Ingredientes_X_Producto pIngredienteXProducto);


    //**************PROCEDIMIENTOS ALMACENADOS Estado**************//

    [OperationContract]
    List<recEstados_Result> recEstado_PA();

    [OperationContract]
    recEstadoxId_Result recEstadoXId_PA(int pId);

    [OperationContract]
    bool insEstado_PA(Estado pEstado);

    [OperationContract]
    bool modEstado_PA(Estado pEstado);

    [OperationContract]
    bool delEstado_PA(Estado pEstado);


    //**************PROCEDIMIENTOS ALMACENADOS Mesas**************//
    [OperationContract]
    List<recDetalleOrden_Result> recOrdenActivaXMesa_PA(int pId);

    [OperationContract]
    List<recMesas_Result> recMesas_PA();

    [OperationContract]
    recMesaxId_Result recMesaXId_PA(int pId);

    [OperationContract]
    bool insMesas_PA(Mesas pMesas);

    [OperationContract]
    bool modMesas_PA(Mesas pMesas);

    [OperationContract]
    bool delMesas_PA(Mesas pMesas);


    //**************ENTIDADES Ordenes**************//
    [OperationContract]
    List<recOrdenes_Result> recOrdenes_PA();

    [OperationContract]
    recOrdenxId_Result recOrdenesXId_PA(int pId);

    [OperationContract]
    bool insOrdenes_PAa(Ordenes pOrdenes);

    [OperationContract]
    bool modOrdenes_PA(Ordenes pOrdenes);

    [OperationContract]
    bool delOrdenes_PA(Ordenes pOrdenes);

    [OperationContract]
    ObtenerProductosPorCategoria_Result recObtenerProductosPorCategoria_ResultXId_PA(int pId);

    [OperationContract]
    ObtenerOrdenesDeMesa_Result ObtenerOrdenesDeMesa_PA(int pId);

    [OperationContract]
    List<Ordenes> recOrdenes_ENT();

    [OperationContract]
    Ordenes recOrdenesXId_ENT(int pId);

    [OperationContract]
    bool insOrdenes_ENT(Ordenes pOrdenes);

    [OperationContract]
    bool modOrdenes_ENT(Ordenes pOrdenes);

    [OperationContract]
    bool delOrdenes_ENT(Ordenes pOrdenes);

    //**************PROCEDIMIENTOS ALMACENADOS DetalleOrden**************//

    [OperationContract]
    List<recDetalleOrden_Result> recDetalleOrden_PA();

    [OperationContract]
    recDetalleOrdenxId_Result recDetalleOrdenXId_PA(int pId);

    [OperationContract]
    bool insDetalleOrden_PA(DetalleOrden pDetalleOrden);

    [OperationContract]
    bool modDetalleOrden_PA(DetalleOrden pDetalleOrden);

    [OperationContract]
    bool delDetalleOrden_PA(DetalleOrden pDetalleOrden);


    //**************ENTIDADES DetalleOrden**************//
    [OperationContract]
    List<DetalleOrden> recDetalleOrden_ENT();

    [OperationContract]
    DetalleOrden recDetalleOrdenXId_ENT(int pId);

    [OperationContract]
    bool insDetalleOrden_ENT(DetalleOrden pDetalleOrden);

    [OperationContract]
    bool modDetalleOrden_ENT(DetalleOrden pDetalleOrden);

    [OperationContract]
    bool delDetalleOrden_ENT(DetalleOrden pDetalleOrden);




    //**************PROCEDIMIENTOS ALMACENADOS Perfiles**************//

    [OperationContract]
    List<recPerfiles_Result> recPerfiles_PA();

    [OperationContract]
    recMesaPerfilxId_Result recPerfilesXId_PA(int pId);

    [OperationContract]
    bool insPerfiles_PA(Perfiles pPerfiles);

    [OperationContract]
    bool modPerfiles_PA(Perfiles pPerfiles);

    [OperationContract]
    bool delPerfiles_PA(Perfiles pPerfiles);


    //**************PROCEDIMIENTOS ALMACENADOS Usuarios**************//

    [OperationContract]
    List<recUsuarios_Result> recUsuarios_PA();

    [OperationContract]
    recUsuarioxId_Result recUsuariosXId_PA(string pId);

    [OperationContract]
    bool insUsuarios_PA(Usuarios pUsuarios);

    [OperationContract]
    bool modUsuarios_PA(Usuarios pUsuarios);

    [OperationContract]
    bool delUsuarios_PA(Usuarios pUsuarios);

    //**************PROCEDIMIENTOS ALMACENADOS PerfilUsuario**************//

    [OperationContract]
    List<recPerfilUsuario_Result> recPerfilUsuario_PA();

    [OperationContract]
    recPerfilUsuarioxId_Result recPerfilUsuarioXId_PA(int pId);

    [OperationContract]
    bool insPerfilUsuario_PA(PerfilUsuario pPerfilUsuario);

    [OperationContract]
    bool modPerfilUsuario_PA(PerfilUsuario pPerfilUsuario);

    [OperationContract]
    bool delPerfilUsuario_PA(PerfilUsuario pPerfilUsuario);


    //**************PROCEDIMIENTOS ALMACENADOS Inventario**************//

    [OperationContract]
    List<recInventario_Result> recInventario_PA();

    [OperationContract]
    recInventarioxId_Result recInventarioXId_PA(int pId);

    [OperationContract]
    bool insInventario_PA(Inventario pInventario);

    [OperationContract]
    bool modInventario_PA(Inventario pInventario);

    [OperationContract]
    bool delInventario_PA(Inventario pInventario);


    //**************PROCEDIMIENTOS ALMACENADOS Facturas**************//

    [OperationContract]
    List<recFacturas_Result> recFacturas_PA();

    [OperationContract]
    recFacturaxId_Result recFacturasXId_PA(int pId);

    [OperationContract]
    bool insFacturas_PA(Facturas pFacturas);

    [OperationContract]
    bool modFacturas_PA(Facturas pFacturas);

    [OperationContract]
    bool delFacturas_PA(Facturas pFacturas);

    //**************Entidades Seguridad**************//
    [OperationContract]
    Usuarios recUsuario(string pUsrLogin);

}
