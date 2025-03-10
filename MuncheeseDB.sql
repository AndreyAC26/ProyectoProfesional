USE [master]
GO
/****** Object:  Database [MuncheeseDB]    Script Date: 29/04/2023 15:32:03 ******/
CREATE DATABASE [MuncheeseDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MuncheeseDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MuncheeseDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MuncheeseDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MuncheeseDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MuncheeseDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MuncheeseDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MuncheeseDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MuncheeseDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MuncheeseDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MuncheeseDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MuncheeseDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MuncheeseDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MuncheeseDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MuncheeseDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MuncheeseDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MuncheeseDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MuncheeseDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MuncheeseDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MuncheeseDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MuncheeseDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MuncheeseDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MuncheeseDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MuncheeseDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MuncheeseDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MuncheeseDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MuncheeseDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MuncheeseDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MuncheeseDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MuncheeseDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MuncheeseDB] SET  MULTI_USER 
GO
ALTER DATABASE [MuncheeseDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MuncheeseDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MuncheeseDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MuncheeseDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MuncheeseDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MuncheeseDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MuncheeseDB] SET QUERY_STORE = OFF
GO
USE [MuncheeseDB]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Nombre] [varchar](20) NULL,
	[Apellido_1] [varchar](15) NULL,
	[Apellido_2] [varchar](15) NULL,
	[Telefono] [varchar](15) NOT NULL,
	[Direccion] [varchar](500) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleOrden]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleOrden](
	[Id_Detalle] [int] IDENTITY(1,1) NOT NULL,
	[Id_Orden] [int] NOT NULL,
	[Id_producto] [int] NULL,
	[Cantidad] [int] NULL,
	[Mesa] [int] NULL,
	[Precio] [int] NULL,
	[Tipo_orden] [varchar](15) NULL,
	[Descripcion] [varchar](200) NULL,
 CONSTRAINT [PK_DetalleOrden] PRIMARY KEY CLUSTERED 
(
	[Id_Detalle] ASC,
	[Id_Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id_Estado] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](10) NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[Id_Factura] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[Id_Orden] [int] NULL,
	[Tel_Cliente] [varchar](15) NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[Id_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredientes]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredientes](
	[Id_Ingrediente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Ingrediente] [varchar](15) NULL,
 CONSTRAINT [PK_Ingredientes] PRIMARY KEY CLUSTERED 
(
	[Id_Ingrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredientes_X_Producto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredientes_X_Producto](
	[Id_ingredienteXproducto] [int] IDENTITY(1,1) NOT NULL,
	[Id_producto] [int] NOT NULL,
	[Id_Ingrediente] [int] NULL,
 CONSTRAINT [PK_Ingredientes_X_Producto] PRIMARY KEY CLUSTERED 
(
	[Id_ingredienteXproducto] ASC,
	[Id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[Id_inventario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Producto] [varchar](25) NULL,
	[Cantidad] [int] NULL,
	[Id_Producto] [int] NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[Id_inventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesas]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesas](
	[Id_Mesa] [int] IDENTITY(1,1) NOT NULL,
	[NombreMesa] [varchar](12) NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_Mesas] PRIMARY KEY CLUSTERED 
(
	[Id_Mesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordenes]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordenes](
	[Id_Orden] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [int] NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_Ordenes] PRIMARY KEY CLUSTERED 
(
	[Id_Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfiles](
	[Perfil_Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre_perfil] [varchar](20) NULL,
 CONSTRAINT [PK_Perfiles] PRIMARY KEY CLUSTERED 
(
	[Perfil_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilUsuario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilUsuario](
	[Perfil_Id] [int] NULL,
	[Usuario] [varchar](20) NULL,
	[Id_PerfilUsuario] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_PerfilUsuario] PRIMARY KEY CLUSTERED 
(
	[Id_PerfilUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id_producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NULL,
	[Tipo_producto] [int] NULL,
	[Precio] [int] NULL,
	[Descripcion] [varchar](200) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Id_Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NULL,
	[Apellido_1] [varchar](15) NULL,
	[Apellido_2] [varchar](15) NULL,
	[Telefono] [varchar](15) NULL,
	[Producto] [varchar](15) NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Id_Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Producto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Producto](
	[Id_tipo_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_tipo_pro] [varchar](15) NULL,
 CONSTRAINT [PK_Tipo_Producto] PRIMARY KEY CLUSTERED 
(
	[Id_tipo_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Usuario] [varchar](20) NOT NULL,
	[Contraseña] [varchar](20) NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleOrden]  WITH CHECK ADD  CONSTRAINT [FK_DetalleOrden_Ordenes] FOREIGN KEY([Id_Orden])
REFERENCES [dbo].[Ordenes] ([Id_Orden])
GO
ALTER TABLE [dbo].[DetalleOrden] CHECK CONSTRAINT [FK_DetalleOrden_Ordenes]
GO
ALTER TABLE [dbo].[DetalleOrden]  WITH CHECK ADD  CONSTRAINT [FK_DetalleOrden_Productos] FOREIGN KEY([Id_producto])
REFERENCES [dbo].[Productos] ([Id_producto])
GO
ALTER TABLE [dbo].[DetalleOrden] CHECK CONSTRAINT [FK_DetalleOrden_Productos]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Clientes] FOREIGN KEY([Tel_Cliente])
REFERENCES [dbo].[Clientes] ([Telefono])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Clientes]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Ordenes] FOREIGN KEY([Id_Orden])
REFERENCES [dbo].[Ordenes] ([Id_Orden])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Ordenes]
GO
ALTER TABLE [dbo].[Ingredientes_X_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Ingredientes_X_Producto_Ingredientes] FOREIGN KEY([Id_Ingrediente])
REFERENCES [dbo].[Ingredientes] ([Id_Ingrediente])
GO
ALTER TABLE [dbo].[Ingredientes_X_Producto] CHECK CONSTRAINT [FK_Ingredientes_X_Producto_Ingredientes]
GO
ALTER TABLE [dbo].[Ingredientes_X_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Ingredientes_X_Producto_Productos] FOREIGN KEY([Id_producto])
REFERENCES [dbo].[Productos] ([Id_producto])
GO
ALTER TABLE [dbo].[Ingredientes_X_Producto] CHECK CONSTRAINT [FK_Ingredientes_X_Producto_Productos]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Productos] FOREIGN KEY([Id_Producto])
REFERENCES [dbo].[Productos] ([Id_producto])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Productos]
GO
ALTER TABLE [dbo].[Mesas]  WITH CHECK ADD  CONSTRAINT [FK_Mesas_Estado] FOREIGN KEY([Estado])
REFERENCES [dbo].[Estado] ([Id_Estado])
GO
ALTER TABLE [dbo].[Mesas] CHECK CONSTRAINT [FK_Mesas_Estado]
GO
ALTER TABLE [dbo].[Ordenes]  WITH CHECK ADD  CONSTRAINT [FK_Ordenes_Estado] FOREIGN KEY([Estado])
REFERENCES [dbo].[Estado] ([Id_Estado])
GO
ALTER TABLE [dbo].[Ordenes] CHECK CONSTRAINT [FK_Ordenes_Estado]
GO
ALTER TABLE [dbo].[PerfilUsuario]  WITH CHECK ADD  CONSTRAINT [FK_PerfilUsuario_Perfiles] FOREIGN KEY([Perfil_Id])
REFERENCES [dbo].[Perfiles] ([Perfil_Id])
GO
ALTER TABLE [dbo].[PerfilUsuario] CHECK CONSTRAINT [FK_PerfilUsuario_Perfiles]
GO
ALTER TABLE [dbo].[PerfilUsuario]  WITH CHECK ADD  CONSTRAINT [FK_PerfilUsuario_Usuarios] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuarios] ([Usuario])
GO
ALTER TABLE [dbo].[PerfilUsuario] CHECK CONSTRAINT [FK_PerfilUsuario_Usuarios]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Tipo_Producto] FOREIGN KEY([Tipo_producto])
REFERENCES [dbo].[Tipo_Producto] ([Id_tipo_Producto])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Tipo_Producto]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Estado] FOREIGN KEY([Estado])
REFERENCES [dbo].[Estado] ([Id_Estado])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Estado]
GO
/****** Object:  StoredProcedure [dbo].[DELCliente]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELCliente]
@Telefono varchar
AS
BEGIN
	DELETE dbo.Clientes
		
	WHERE Telefono = @Telefono
END
GO
/****** Object:  StoredProcedure [dbo].[delCombo]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delCombo]
@Id_combo int
AS
BEGIN
	DELETE dbo.Combos
		
	WHERE Id_combo = @Id_combo
END
GO
/****** Object:  StoredProcedure [dbo].[delDetalleOrden]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delDetalleOrden]
@Id_Detalle int
AS
BEGIN
	DELETE dbo.DetalleOrden
		
	WHERE Id_Detalle = @Id_Detalle
END
GO
/****** Object:  StoredProcedure [dbo].[delEstado]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delEstado]
@Id_Estado int
AS
BEGIN
	DELETE dbo.Estado
		
	WHERE Id_Estado = @Id_Estado
END
GO
/****** Object:  StoredProcedure [dbo].[delFactura]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delFactura]
@Id_Factura int
AS
BEGIN
	DELETE dbo.Facturas
		
	WHERE Id_Factura = @Id_Factura
END
GO
/****** Object:  StoredProcedure [dbo].[delIngrediente]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[delIngrediente]
@Id_Ingrediente int
AS
BEGIN
	DELETE dbo.Ingredientes
		
	WHERE Id_Ingrediente = @Id_Ingrediente
END
GO
/****** Object:  StoredProcedure [dbo].[delIngredienteXproducto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delIngredienteXproducto]
@Id_IngredienteXproducto int
AS
BEGIN
	DELETE dbo.Ingredientes_X_Producto
		
	WHERE Id_IngredienteXproducto = @Id_IngredienteXproducto
END
GO
/****** Object:  StoredProcedure [dbo].[delInventario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delInventario]
@Id_inventario int
AS
BEGIN
	DELETE dbo.Inventario
		
	WHERE Id_inventario = @Id_inventario
END
GO
/****** Object:  StoredProcedure [dbo].[delMesa]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delMesa]
@Id_Mesa int
AS
BEGIN
	DELETE dbo.Mesas
		
	WHERE Id_Mesa = @Id_Mesa
END
GO
/****** Object:  StoredProcedure [dbo].[delOrden]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[delOrden]
@Id_Orden int
AS
BEGIN
	DELETE dbo.Ordenes
		
	WHERE Id_Orden = @Id_Orden
END
GO
/****** Object:  StoredProcedure [dbo].[delPerfil]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delPerfil]
@Perfil_Id int
AS
BEGIN
	DELETE dbo.Perfiles
		
	WHERE Perfil_Id= @Perfil_Id
END
GO
/****** Object:  StoredProcedure [dbo].[delPerfilUsuario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delPerfilUsuario]
@Id_PerfilUsuario int
AS
BEGIN
	DELETE dbo.PerfilUsuario
		
	WHERE Id_PerfilUsuario = @Id_PerfilUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[delproducto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delproducto]
@Id_producto int
AS
BEGIN
	DELETE dbo.Productos
		
	WHERE Id_producto = @Id_producto
END
GO
/****** Object:  StoredProcedure [dbo].[delProductosXcombo]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delProductosXcombo]
@Id_ProducXcombo int
AS
BEGIN
	DELETE dbo.ProductosXcombo
		
	WHERE Id_ProducXcombo = @Id_ProducXcombo
END
GO
/****** Object:  StoredProcedure [dbo].[DELProveedor]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DELProveedor]
@IdProveedor int
AS
BEGIN
	DELETE dbo.Proveedor
		
	WHERE Id_Proveedor = @IdProveedor
END
GO
/****** Object:  StoredProcedure [dbo].[delTipo_Combo]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delTipo_Combo]
@Id_tipo_combo int
AS
BEGIN
	DELETE dbo.Tipo_Combo
		
	WHERE Id_tipo_combo = @Id_tipo_combo
END
GO
/****** Object:  StoredProcedure [dbo].[delTipo_Producto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delTipo_Producto]
@Id_tipo_Producto int
AS
BEGIN
	DELETE dbo.Tipo_Producto
		
	WHERE Id_tipo_Producto = @Id_tipo_Producto
END
GO
/****** Object:  StoredProcedure [dbo].[delUsuario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delUsuario]
@Usuario varchar(20)
AS
BEGIN
	DELETE dbo.Usuarios
		
	WHERE Usuario = @Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[insCliente]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insCliente]
@Telefono varchar(15),
@Nombre varchar(20),
@Apellido_1 varchar(15),
@Apellido_2 varchar(15),
@Direccion varchar(500)

AS
BEGIN
	INSERT INTO dbo.Clientes
		(
	 Telefono,
         [Nombre],
         [Apellido_1],
		 [Apellido_2],
		 [Direccion]
		 )
	VALUES(
           @Telefono,@Nombre,@Apellido_1,@Apellido_2,
		   @Direccion
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insCombo]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insCombo]
@Id_combo int,
@Nombre varchar(15),
@Tipo_combo int,
@Precio int,
@Descripcion varchar(200)

AS
BEGIN
	INSERT INTO dbo.Combos
		(
		Id_combo,
         [Nombre],
	 [Tipo_combo],
	 [Precio],
	 [Descripcion]
		 )
	VALUES(
           @Id_combo, @Nombre, @Tipo_combo,
	   @Precio, @Descripcion
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insDetalleOrden]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insDetalleOrden]
@Id_Orden int,
@Id_producto int,
@Cantidad int,
@Mesa int,
@Precio int,
@Tipo_orden varchar(15),
@Descripcion varchar(200)

AS
BEGIN
	INSERT INTO dbo.DetalleOrden
		(
        [Id_Orden], 
	[Id_producto], [Cantidad], [Mesa],
	[Precio], [Tipo_orden], [Descripcion]
		 )
	VALUES(
           @Id_Orden, @Id_producto, @Cantidad,
	@Mesa, @Precio, @Tipo_orden,@Descripcion
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarTipoProducto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarTipoProducto]
    @Nombre_tipo_pro VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO dbo.Tipo_Producto (Nombre_tipo_pro)
    VALUES (@Nombre_tipo_pro)
    
    DECLARE @Id_tipo_Producto INT;
    SET @Id_tipo_Producto = SCOPE_IDENTITY()
    
    SELECT @Id_tipo_Producto, @Nombre_tipo_pro
    FROM Tipo_Producto
    WHERE Id_tipo_Producto = @Id_tipo_Producto;
END


GO
/****** Object:  StoredProcedure [dbo].[insertProducto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertProducto]
@Nombre varchar(15),
@Tipo_producto int,
@Precio int,
@Descripcion varchar(200)

AS
BEGIN
	INSERT INTO dbo.Productos
		(
		
         [Nombre],
	 [Tipo_producto],
	 [Precio],
	 [Descripcion]
		 )
	VALUES(
            @Nombre, @Tipo_producto,
	   @Precio, @Descripcion
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insEstado]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insEstado]

@Estado varchar(10)

AS
BEGIN
	INSERT INTO dbo.Estado
		(
		
         [Estado]		 )
	VALUES(
            @Estado
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insFactura]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insFactura]
@fecha datetime,
@Id_Orden int,
@Tel_Cliente varchar(15)

AS
BEGIN
	INSERT INTO dbo.Facturas
		(
	         fecha, Id_Orden,
		Tel_Cliente		
		)
	VALUES(
           @fecha, @Id_Orden,
	@Tel_Cliente
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insIngrediente]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insIngrediente]
@Id_Ingrediente int,
@Nombre_Ingrediente varchar(15)

AS
BEGIN
	INSERT INTO dbo.Ingredientes
		(
         [Nombre_Ingrediente]
		 )
	VALUES(
           @Nombre_Ingrediente
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insIngredienteXProducto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insIngredienteXProducto]
@Id_IngredienteXproducto int,
@Id_producto int,
@Id_Ingrediente int

AS
BEGIN
	INSERT INTO dbo.Ingredientes_X_Producto
		(
         [Id_producto],
	 [Id_Ingrediente]
		 )
	VALUES(
           @Id_producto, @Id_Ingrediente
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insInventario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insInventario]
@Nombre_Producto varchar(15),
@Cantidad int,
@Id_Producto int

AS
BEGIN
	INSERT INTO dbo.Inventario
		(
		
         [Nombre_Producto], [Cantidad], [Id_Producto]	)
	VALUES(
            @Nombre_Producto, @Cantidad, @Id_Producto
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insMesa]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insMesa]

@NombreMesa varchar(12),
@Estado int

AS
BEGIN
	INSERT INTO dbo.Mesas
		(
		
         [NombreMesa], [Estado]		 )
	VALUES(
           @NombreMesa, @Estado
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insOrden]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insOrden]
AS
BEGIN
    DECLARE @Fecha datetime,
            @Estado int
    
    SET @Fecha = GETDATE()
    SET @Estado = (SELECT Id_Estado FROM dbo.Estado WHERE Estado = 'Activo')
    
    -- Inserta la nueva fila en la tabla de Ordenes con el valor de @Estado actualizado
    INSERT INTO dbo.Ordenes ([Estado], [Fecha])
    VALUES (@Estado, @Fecha)
END
GO
/****** Object:  StoredProcedure [dbo].[insPerfil]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[insPerfil]
@nombre_perfil varchar(20)

AS
BEGIN
	INSERT INTO dbo.Perfiles
		(
		
         [nombre_perfil]		 )
	VALUES(
            @nombre_perfil
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insPerfilUsuario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insPerfilUsuario]
@Perfil_id int,
@Usuario varchar(20)

AS
BEGIN
	INSERT INTO dbo.PerfilUsuario
		(
		[Perfil_id],
         [Usuario]		 )
	VALUES(
           @Perfil_id, @Usuario
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insProducto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insProducto]
@Id_producto int,
@Nombre varchar(15),
@Tipo_producto int,
@Precio int,
@Descripcion varchar(200)

AS
BEGIN
	INSERT INTO dbo.Productos
		(
		Id_producto,
         [Nombre],
	 [Tipo_producto],
	 [Precio],
	 [Descripcion]
		 )
	VALUES(
           @Id_producto, @Nombre, @Tipo_producto,
	   @Precio, @Descripcion
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insProductosXcombo]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insProductosXcombo]

@Id_combo int,
@Id_producto int

AS
BEGIN
	INSERT INTO dbo.ProductosXcombo
		(
		
         [Id_combo], [Id_producto]		 )
	VALUES(
            @Id_combo, @Id_producto
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insProveedor]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[insProveedor]
@IdProveedor int,
@Nombre varchar(20),
@Apellido_1 varchar(15),
@Apellido_2 varchar(15),
@Telefono varchar(15),
@Producto varchar(15)

AS
BEGIN
	INSERT INTO dbo.Proveedor
		(
         [Nombre],
         [Apellido_1],
		 [Apellido_2],
		 [Telefono],
		 [Producto])
	VALUES(
           @Nombre,@Apellido_1,@Apellido_2,
		   @Telefono,@Producto
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insTipo_Combo]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insTipo_Combo]
@Id_tipo_combo int,
@Nombre_tipo_com varchar(15)

AS
BEGIN
	INSERT INTO dbo.Tipo_Combo
		(
		Id_tipo_combo,
         [Nombre_tipo_com]		 )
	VALUES(
           @Id_tipo_combo, @Nombre_tipo_com
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[insTipo_Producto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insTipo_Producto]
@Id_tipo_Producto int,
@Nombre_tipo_pro varchar(15)

AS
BEGIN
	INSERT INTO dbo.Tipo_Producto
		(
		Id_tipo_Producto,
         [Nombre_tipo_pro]		 )
	VALUES(
           @Id_tipo_Producto, @Nombre_tipo_pro
		   )
		   SET @Id_tipo_Producto = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[insUsuario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insUsuario]
@Usuario varchar(20),
@Contraseña varchar(20),
@Estado int

AS
BEGIN
	INSERT INTO dbo.Usuarios
		(
		Usuario,
         [Contraseña], [Estado]		 )
	VALUES(
           @Usuario, @Contraseña, @Estado
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[modCliente]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modCliente]
@Telefono varchar(15),
@Nombre varchar(20),
@Apellido_1 varchar(15),
@Apellido_2 varchar(15),
@Direccion varchar(500)

AS
BEGIN
	UPDATE dbo.Clientes
		SET 
         [Nombre] = @Nombre,
         [Apellido_1] = @Apellido_1,
		 [Apellido_2] = @Apellido_2,
		 [Direccion] = @Direccion
	WHERE Telefono = @Telefono
END
GO
/****** Object:  StoredProcedure [dbo].[modCombos]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modCombos]
@Id_combo int,
@Nombre varchar(15),
@Tipo_combo int,
@Precio int,
@Descripcion varchar(200)

AS
BEGIN
	UPDATE dbo.Combos
		SET 
         [Nombre] = @Nombre,
	 [Tipo_combo] = @Tipo_combo,
	 [Precio] = @Precio,
	 [Descripcion] = @Descripcion
	WHERE Id_combo = @Id_combo
END
GO
/****** Object:  StoredProcedure [dbo].[modDetalleOrden]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modDetalleOrden]
@Id_Detalle int,
@Id_Orden int,
@Id_producto int,
@Cantidad int,
@Mesa int,
@Precio int,
@Tipo_orden varchar(15),
@Descripcion varchar(200)

AS
BEGIN
	UPDATE dbo.DetalleOrden
		SET 
         [Id_Orden] = @Id_Orden, 
	[Id_producto] = @Id_producto, [Cantidad] = @Cantidad, [Mesa] = @Mesa,
	[Precio] = @Precio, [Tipo_orden] = @Tipo_orden, [Descripcion] = @Descripcion
	WHERE Id_Detalle = @Id_Detalle
END
GO
/****** Object:  StoredProcedure [dbo].[modEstado]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modEstado]
@Id_Estado int,
@Estado varchar(10)

AS
BEGIN
	UPDATE dbo.Estado
		SET 
         [Estado] = @Estado

	WHERE Id_Estado = @Id_Estado
END
GO
/****** Object:  StoredProcedure [dbo].[modFactura]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modFactura]
@Id_Factura int,
@fecha datetime,
@Id_Orden int,
@Tel_Cliente varchar(15)

AS
BEGIN
	UPDATE dbo.Facturas
		SET 
         fecha = @fecha, Id_Orden = @Id_Orden,
	Tel_Cliente = @Tel_Cliente

	WHERE Id_Factura = @Id_Factura
END
GO
/****** Object:  StoredProcedure [dbo].[modIngrediente]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modIngrediente]
@Id_Ingrediente int,
@Nombre_Ingrediente varchar(15)

AS
BEGIN
	UPDATE dbo.Ingredientes
		SET 
         [Nombre_Ingrediente] = @Nombre_Ingrediente

	WHERE Id_Ingrediente = @Id_Ingrediente
END
GO
/****** Object:  StoredProcedure [dbo].[modIngredientesXProducto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modIngredientesXProducto]
@Id_IngredienteXproducto int,
@Id_producto int,
@Id_Ingrediente	int

AS
BEGIN
	UPDATE dbo.Ingredientes_X_Producto
		SET 
         [Id_producto] = @Id_producto,
	 [Id_Ingrediente] = @Id_Ingrediente
	WHERE Id_IngredienteXproducto = @Id_IngredienteXproducto
END
GO
/****** Object:  StoredProcedure [dbo].[modInventario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modInventario]
@Id_inventario int,
@Nombre_Producto varchar(15),
@Cantidad int,
@Id_Producto int


AS
BEGIN
	UPDATE dbo.Inventario
		SET 
         [Nombre_Producto] = @Nombre_Producto,
	 [Cantidad] = @Cantidad, [Id_Producto] = @Id_Producto

	WHERE Id_inventario = @Id_inventario
END
GO
/****** Object:  StoredProcedure [dbo].[modMesa]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modMesa]
@Id_Mesa int,
@NombreMesa varchar(12),
@Estado int

AS
BEGIN
	UPDATE dbo.Mesas
		SET 
         [NombreMesa] = @NombreMesa,
	 [Estado] = @Estado

	WHERE Id_Mesa = @Id_Mesa
END
GO
/****** Object:  StoredProcedure [dbo].[modOrdenes]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modOrdenes]
@Id_Orden int,
@Fecha datetime,
@Estado int


AS
BEGIN
	UPDATE dbo.Ordenes
		SET 
	[Fecha] = @Fecha,
	[Estado] = @Estado
	WHERE Id_Orden = @Id_Orden
END
GO
/****** Object:  StoredProcedure [dbo].[modPerfil]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modPerfil]
@Perfil_Id int,
@nombre_perfil varchar(20)

AS
BEGIN
	UPDATE dbo.Perfiles
		SET 
         [nombre_perfil] = @nombre_perfil

	WHERE Perfil_Id= @Perfil_Id
END
GO
/****** Object:  StoredProcedure [dbo].[modPerfilUsuario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modPerfilUsuario]
@Perfil_Id int,
@Usuario varchar(20),
@Id_PerfilUsuario int

AS
BEGIN
	UPDATE dbo.PerfilUsuario
		SET 
         [Perfil_Id] = @Perfil_Id,
	 [Usuario] = @Usuario

	WHERE Id_PerfilUsuario = @Id_PerfilUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[modProductos]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[modProductos]
@Id_producto int,
@Nombre varchar(15),
@Tipo_producto int,
@Precio int,
@Descripcion varchar(200)

AS
BEGIN
	UPDATE dbo.Productos
		SET 
         [Nombre] = @Nombre,
	 [Tipo_producto] = @Tipo_producto,
	 [Precio] = @Precio,
	 [Descripcion] = @Descripcion
	WHERE Id_producto = @Id_producto
END
GO
/****** Object:  StoredProcedure [dbo].[modProductosXcombo]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[modProductosXcombo]
@Id_ProducXcombo int,
@Id_combo int,
@Id_producto int

AS
BEGIN
	UPDATE dbo.ProductosXcombo
		SET 
         [Id_combo] = @Id_combo,
	 [Id_producto] = @Id_producto

	WHERE Id_ProducXcombo = @Id_ProducXcombo
END
GO
/****** Object:  StoredProcedure [dbo].[modProveedor]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[modProveedor]
@IdProveedor int,
@Nombre varchar(20),
@Apellido_1 varchar(15),
@Apellido_2 varchar(15),
@Telefono varchar(15),
@Producto varchar(15)

AS
BEGIN
	UPDATE dbo.Proveedor
		SET 
         [Nombre] = @Nombre,
         [Apellido_1] = @Apellido_1,
		 [Apellido_2] = @Apellido_2,
		 [Telefono] = @Telefono,
		 [Producto] = @Producto
	WHERE Id_Proveedor = @IdProveedor
END
GO
/****** Object:  StoredProcedure [dbo].[modTipo_Combo]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modTipo_Combo]
@Id_tipo_combo int,
@Nombre_tipo_com varchar(15)

AS
BEGIN
	UPDATE dbo.Tipo_Combo
		SET 
         [Nombre_tipo_com] = @Nombre_tipo_com

	WHERE Id_tipo_combo = @Id_tipo_combo
END
GO
/****** Object:  StoredProcedure [dbo].[modTipo_Producto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[modTipo_Producto]
@Id_tipo_Producto int,
@Nombre_tipo_pro varchar(15)

AS
BEGIN
	UPDATE dbo.Tipo_Producto
		SET 
         [Nombre_tipo_pro] = @Nombre_tipo_pro

	WHERE Id_tipo_Producto = @Id_tipo_Producto
END
GO
/****** Object:  StoredProcedure [dbo].[modUsuario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[modUsuario]
@Usuario varchar(20),
@Contraseña varchar(20),
@Estado int

AS
BEGIN
	UPDATE dbo.Usuarios
		SET 
         [Contraseña] = @Contraseña,
		 [Estado] = @Estado

	WHERE Usuario = @Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerMesasActivas]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerMesasActivas]
AS
BEGIN
    SELECT DISTINCT DO.Mesa
    FROM DetalleOrden DO
    INNER JOIN Ordenes O ON DO.Id_Orden = O.Id_Orden
    WHERE O.Estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerOrdenesDeMesa]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerOrdenesDeMesa]
    @mesa INT
AS
BEGIN
    SELECT DO.Id_Orden, O.Estado, O.Fecha
    FROM DetalleOrden DO
    INNER JOIN Ordenes O ON DO.Id_Orden = O.Id_Orden
    WHERE O.Estado = 1 AND DO.Mesa = @mesa
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerProductosPorCategoria]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerProductosPorCategoria]
    @Tipo_producto INT
AS
BEGIN
    SELECT Id_producto, Nombre, Precio FROM Productos WHERE Tipo_producto = @Tipo_producto
END
GO
/****** Object:  StoredProcedure [dbo].[recCliente]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recCliente]
AS
BEGIN
	SELECT Telefono, [Nombre], [Apellido_1],
	[Apellido_2],  [Direccion]
	FROM dbo.Clientes
END
GO
/****** Object:  StoredProcedure [dbo].[recClientexId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recClientexId]
@Telefono varchar
AS
BEGIN
	SELECT Telefono, [Nombre], [Apellido_1],
	[Apellido_2], [Direccion]
	FROM dbo.Clientes
	WHERE Telefono = @Telefono
END
GO
/****** Object:  StoredProcedure [dbo].[recCombos]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recCombos]
AS
BEGIN
	SELECT Id_Combo, [Nombre]
	[Tipo_combo], [Precio],
	[Descripcion]
	FROM dbo.Combos
END
GO
/****** Object:  StoredProcedure [dbo].[recCombosxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recCombosxId]
@Id_combo int
AS
BEGIN
	SELECT Id_combo, [Nombre], [Tipo_combo]
	[Precio], [Descripcion]
	FROM dbo.Combos
	WHERE Id_combo = @Id_combo
END
GO
/****** Object:  StoredProcedure [dbo].[recDetalleOrden]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recDetalleOrden]
AS
BEGIN
	SELECT Id_Detalle, [Id_Orden], 
	[Id_producto], [Cantidad], [Mesa],
	[Precio], [Tipo_orden], [Descripcion]
	FROM dbo.DetalleOrden
END
GO
/****** Object:  StoredProcedure [dbo].[recDetalleOrdenConOrdenEstado1]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recDetalleOrdenConOrdenEstado1]
AS
BEGIN
    SELECT  d.Id_Orden, d.Id_producto, d.Cantidad, d.Tipo_orden, d.Descripcion 
    FROM DetalleOrden d
    INNER JOIN Ordenes o ON d.Id_Orden = o.Id_Orden
    WHERE o.Estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[recDetalleOrdenxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recDetalleOrdenxId]
@Id_Detalle int
AS
BEGIN
	SELECT Id_Detalle, [Id_Orden], 
	[Id_producto], [Cantidad], [Mesa],
	[Precio], [Tipo_orden], [Descripcion]
	FROM dbo.DetalleOrden
	WHERE Id_Detalle = @Id_Detalle
END
GO
/****** Object:  StoredProcedure [dbo].[recEstados]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recEstados]
AS
BEGIN
	SELECT Id_Estado, [Estado]
	FROM dbo.Estado
END
GO
/****** Object:  StoredProcedure [dbo].[recEstadoxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recEstadoxId]
@Id_Estado int
AS
BEGIN
	SELECT Id_Estado, [Estado]
	FROM dbo.Estado
	WHERE Id_Estado = @Id_Estado
END
GO
/****** Object:  StoredProcedure [dbo].[recFacturas]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recFacturas]
AS
BEGIN
	SELECT Id_Factura, [fecha],
	[Id_Orden], [Tel_Cliente]
	FROM dbo.Facturas
END
GO
/****** Object:  StoredProcedure [dbo].[recFacturaxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recFacturaxId]
@Id_Factura int
AS
BEGIN
	SELECT Id_Factura, [fecha],
	[Id_Orden], [Tel_Cliente]
	FROM dbo.Facturas
	WHERE Id_Factura = @Id_Factura
END
GO
/****** Object:  StoredProcedure [dbo].[recIngredientes]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recIngredientes]
AS
BEGIN
	SELECT Id_Ingrediente, [Nombre_Ingrediente]
	FROM dbo.Ingredientes
END
GO
/****** Object:  StoredProcedure [dbo].[recIngredientesXProducto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recIngredientesXProducto]
AS
BEGIN
	SELECT Id_ingredienteXproducto, [Id_producto], 
	[Id_Ingrediente]
	FROM dbo.Ingredientes_X_Producto
END
GO
/****** Object:  StoredProcedure [dbo].[recIngredientexId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[recIngredientexId]
@Id_Ingrediente int
AS
BEGIN
	SELECT Id_Ingrediente, [Nombre_Ingrediente]
	FROM dbo.Ingredientes
	WHERE Id_Ingrediente = @Id_Ingrediente
END
GO
/****** Object:  StoredProcedure [dbo].[recIngredienteXProductoxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recIngredienteXProductoxId]
@Id_ingredienteXproducto int
AS
BEGIN
	SELECT Id_ingredienteXproducto, [Id_producto], [Id_Ingrediente]
	FROM dbo.Ingredientes_X_Producto
	WHERE Id_IngredienteXproducto = @Id_IngredienteXproducto
END
GO
/****** Object:  StoredProcedure [dbo].[recInventario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recInventario]
AS
BEGIN
	SELECT Id_inventario, [Nombre_Producto],
	[Cantidad], [Id_Producto]
	FROM dbo.Inventario
END
GO
/****** Object:  StoredProcedure [dbo].[recInventarioxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recInventarioxId]
@Id_inventario int
AS
BEGIN
	SELECT Id_inventario, [Nombre_Producto],
	[Cantidad], [Id_Producto]
	FROM dbo.Inventario
	WHERE Id_inventario = @Id_inventario
END
GO
/****** Object:  StoredProcedure [dbo].[recMesaPerfilxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recMesaPerfilxId]
@Perfil_Id int
AS
BEGIN
	SELECT Perfil_Id, [nombre_perfil]
	FROM dbo.Perfiles
	WHERE Perfil_Id = @Perfil_Id
END
GO
/****** Object:  StoredProcedure [dbo].[recMesas]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recMesas]
AS
BEGIN
	SELECT Id_Mesa, [NombreMesa],
	[Estado]
	FROM dbo.Mesas
END
GO
/****** Object:  StoredProcedure [dbo].[recMesasActivasDO]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[recMesasActivasDO]
AS
BEGIN
    SELECT DISTINCT DO.Mesa
    FROM DetalleOrden DO
    INNER JOIN Ordenes O ON DO.Id_Orden = O.Id_Orden
    WHERE O.Estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[recMesaxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recMesaxId]
@Id_Mesa int
AS
BEGIN
	SELECT Id_Mesa, [NombreMesa], [Estado]
	FROM dbo.Mesas
	WHERE Id_Mesa = @Id_Mesa
END
GO
/****** Object:  StoredProcedure [dbo].[recOrdenActivaXMesa]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recOrdenActivaXMesa]
    @Id_Mesa INT
AS
BEGIN
    SELECT DISTINCT O.Id_Orden
    FROM Ordenes O
    INNER JOIN DetalleOrden DO ON O.Id_Orden = DO.Id_Orden
    WHERE DO.Mesa = @Id_Mesa AND O.Estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[recOrdenes]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recOrdenes]
AS
BEGIN
	SELECT Id_Orden, [Fecha],
	[Estado]
	FROM dbo.Ordenes
END
GO
/****** Object:  StoredProcedure [dbo].[recOrdenxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recOrdenxId]
@Id_Orden int
AS
BEGIN
	SELECT Id_Orden, Estado, Fecha 
	FROM dbo.Ordenes
	WHERE Id_Orden = @Id_Orden
END
GO
/****** Object:  StoredProcedure [dbo].[recPerfiles]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recPerfiles]
AS
BEGIN
	SELECT Perfil_Id, [nombre_perfil]
	FROM dbo.Perfiles
END
GO
/****** Object:  StoredProcedure [dbo].[recPerfilUsuario]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recPerfilUsuario]
AS
BEGIN
	SELECT [Perfil_Id], [Usuario],
	Id_PerfilUsuario
	FROM dbo.PerfilUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[recPerfilUsuarioxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recPerfilUsuarioxId]
@Id_PerfilUsuario int
AS
BEGIN
	SELECT [Perfil_Id], [Usuario], Id_PerfilUsuario
	FROM dbo.PerfilUsuario
	WHERE Id_PerfilUsuario = @Id_PerfilUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[recProductos]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recProductos]
AS
BEGIN
	SELECT Id_producto, [Nombre]
	[Tipo_producto], [Precio],
	[Descripcion]
	FROM dbo.Productos
END
GO
/****** Object:  StoredProcedure [dbo].[recProductosXcombo]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recProductosXcombo]
AS
BEGIN
	SELECT Id_ProducXcombo, [Id_combo],
	[Id_producto]
	FROM dbo.ProductosXcombo
END
GO
/****** Object:  StoredProcedure [dbo].[recProductosXcomboxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recProductosXcomboxId]
@Id_ProducXcombo int
AS
BEGIN
	SELECT Id_ProducXcombo, [Id_combo], [Id_producto]
	FROM dbo.ProductosXcombo
	WHERE Id_ProducXcombo = @Id_ProducXcombo
END
GO
/****** Object:  StoredProcedure [dbo].[recProductosxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recProductosxId]
@Id_producto int
AS
BEGIN
	SELECT Id_producto, [Nombre], [Tipo_producto]
	[Precio], [Descripcion]
	FROM dbo.Productos
	WHERE Id_producto = @Id_producto
END
GO
/****** Object:  StoredProcedure [dbo].[recProveedor]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recProveedor]
AS
BEGIN
	SELECT Id_Proveedor, [Nombre], [Apellido_1],
	[Apellido_2], [Telefono], [Producto]
	FROM dbo.Proveedor
END
GO
/****** Object:  StoredProcedure [dbo].[recProveedorxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[recProveedorxId]
@IdProveedor int
AS
BEGIN
	SELECT Id_Proveedor, [Nombre], [Apellido_1],
	[Apellido_2], [Telefono], [Producto]
	FROM dbo.Proveedor
	WHERE Id_Proveedor = @IdProveedor
END
GO
/****** Object:  StoredProcedure [dbo].[recTipo_Combo]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recTipo_Combo]
AS
BEGIN
	SELECT Id_tipo_combo, [Nombre_tipo_com]
	FROM dbo.Tipo_Combo
END
GO
/****** Object:  StoredProcedure [dbo].[recTipo_ComboxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recTipo_ComboxId]
@Id_tipo_combo int
AS
BEGIN
	SELECT Id_tipo_combo, [Nombre_tipo_com]
	FROM dbo.Tipo_Combo
	WHERE Id_tipo_combo = @Id_tipo_combo
END
GO
/****** Object:  StoredProcedure [dbo].[recTipo_Producto]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recTipo_Producto]
AS
BEGIN
	SELECT Id_tipo_Producto, [Nombre_tipo_pro]
	FROM dbo.Tipo_Producto
END
GO
/****** Object:  StoredProcedure [dbo].[recTipo_ProductoxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recTipo_ProductoxId]
@Id_tipo_Producto int
AS
BEGIN
	SELECT Id_tipo_Producto, [Nombre_tipo_pro]
	FROM dbo.Tipo_Producto
	WHERE Id_tipo_Producto = @Id_tipo_Producto
END
GO
/****** Object:  StoredProcedure [dbo].[recUsuarios]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recUsuarios]
AS
BEGIN
	SELECT Usuario, [Contraseña],
	[Estado]
	FROM dbo.Usuarios
END
GO
/****** Object:  StoredProcedure [dbo].[recUsuarioxId]    Script Date: 29/04/2023 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[recUsuarioxId]
@Usuario varchar(20)
AS
BEGIN
	SELECT Usuario, [Contraseña], [Estado]
	FROM dbo.Usuarios
	WHERE Usuario = @Usuario
END
GO
USE [master]
GO
ALTER DATABASE [MuncheeseDB] SET  READ_WRITE 
GO
