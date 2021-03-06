USE [master]
GO
/****** Object:  Database [pruebaDigitalWare]    Script Date: 8/06/2022 4:48:46 p. m. ******/
CREATE DATABASE [pruebaDigitalWare]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pruebaDigitalWare', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.DEVELOP\MSSQL\DATA\pruebaDigitalWare.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'pruebaDigitalWare_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.DEVELOP\MSSQL\DATA\pruebaDigitalWare_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [pruebaDigitalWare] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pruebaDigitalWare].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pruebaDigitalWare] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET ARITHABORT OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pruebaDigitalWare] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pruebaDigitalWare] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET  DISABLE_BROKER 
GO
ALTER DATABASE [pruebaDigitalWare] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pruebaDigitalWare] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET RECOVERY FULL 
GO
ALTER DATABASE [pruebaDigitalWare] SET  MULTI_USER 
GO
ALTER DATABASE [pruebaDigitalWare] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pruebaDigitalWare] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pruebaDigitalWare] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pruebaDigitalWare] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [pruebaDigitalWare] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'pruebaDigitalWare', N'ON'
GO
ALTER DATABASE [pruebaDigitalWare] SET QUERY_STORE = OFF
GO
USE [pruebaDigitalWare]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 8/06/2022 4:48:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [varchar](150) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Identificacion] [varchar](80) NOT NULL,
	[Direccion] [varchar](80) NULL,
	[Telefono] [varchar](30) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 8/06/2022 4:48:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[FechaCompra] [date] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Total] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCompra]    Script Date: 8/06/2022 4:48:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCompra](
	[IdDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NULL,
	[CompraId] [int] NULL,
	[CantidadComprada] [int] NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[Iva] [varchar](10) NULL,
 CONSTRAINT [PK_DetalleCompra] PRIMARY KEY CLUSTERED 
(
	[IdDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 8/06/2022 4:48:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[Precio] [decimal](18, 2) NULL,
	[Cantidad] [int] NULL,
	[Iva] [varchar](10) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([IdCliente], [NombreCompleto], [FechaNacimiento], [Identificacion], [Direccion], [Telefono]) VALUES (1, N'JOSE JOAQUIN CARDENAS PEREZ', CAST(N'2000-06-06' AS Date), N'1057602509', N'CALL 52 # 12-21', N'7725152')
INSERT [dbo].[Clientes] ([IdCliente], [NombreCompleto], [FechaNacimiento], [Identificacion], [Direccion], [Telefono]) VALUES (2, N'LUIS ANTONIO CARDENAS', CAST(N'1997-05-12' AS Date), N'3234782', N'CLL 323', N'786783')
INSERT [dbo].[Clientes] ([IdCliente], [NombreCompleto], [FechaNacimiento], [Identificacion], [Direccion], [Telefono]) VALUES (3, N'JOSE DURAN', CAST(N'1952-06-06' AS Date), N'1057602509', N'CALL 52 # 12-21', N'7725152')
INSERT [dbo].[Clientes] ([IdCliente], [NombreCompleto], [FechaNacimiento], [Identificacion], [Direccion], [Telefono]) VALUES (4, N'ANTONIO RIQUELME', CAST(N'1998-06-06' AS Date), N'1057602509', N'CALL 52 # 12-21', N'7725152')
INSERT [dbo].[Clientes] ([IdCliente], [NombreCompleto], [FechaNacimiento], [Identificacion], [Direccion], [Telefono]) VALUES (5, N'ANDRES ESCOBAR', CAST(N'1960-06-06' AS Date), N'1057602509', N'CALL 52 # 12-21', N'7725152')
INSERT [dbo].[Clientes] ([IdCliente], [NombreCompleto], [FechaNacimiento], [Identificacion], [Direccion], [Telefono]) VALUES (6, N'FELIPE RESTREPO', CAST(N'1980-06-06' AS Date), N'1057602509', N'CALL 52 # 12-21', N'7725152')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Compras] ON 

INSERT [dbo].[Compras] ([IdCompra], [FechaCompra], [ClienteId], [Total]) VALUES (1, CAST(N'2022-06-06' AS Date), 1, CAST(1025120.21 AS Decimal(18, 2)))
INSERT [dbo].[Compras] ([IdCompra], [FechaCompra], [ClienteId], [Total]) VALUES (2, CAST(N'2022-06-08' AS Date), 1, CAST(1024510.00 AS Decimal(18, 2)))
INSERT [dbo].[Compras] ([IdCompra], [FechaCompra], [ClienteId], [Total]) VALUES (3, CAST(N'2022-06-08' AS Date), 1, CAST(676176.60 AS Decimal(18, 2)))
INSERT [dbo].[Compras] ([IdCompra], [FechaCompra], [ClienteId], [Total]) VALUES (4, CAST(N'2000-06-08' AS Date), 2, CAST(314513.74 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Compras] OFF
SET IDENTITY_INSERT [dbo].[DetalleCompra] ON 

INSERT [dbo].[DetalleCompra] ([IdDetalleCompra], [ProductoId], [CompraId], [CantidadComprada], [SubTotal], [Iva]) VALUES (1, 1, 2, 100, CAST(1024510.00 AS Decimal(18, 2)), N'10%')
INSERT [dbo].[DetalleCompra] ([IdDetalleCompra], [ProductoId], [CompraId], [CantidadComprada], [SubTotal], [Iva]) VALUES (2, 1, 3, 54, CAST(553235.40 AS Decimal(18, 2)), N'10%')
INSERT [dbo].[DetalleCompra] ([IdDetalleCompra], [ProductoId], [CompraId], [CantidadComprada], [SubTotal], [Iva]) VALUES (3, 1, 3, 12, CAST(122941.20 AS Decimal(18, 2)), N'10%')
INSERT [dbo].[DetalleCompra] ([IdDetalleCompra], [ProductoId], [CompraId], [CantidadComprada], [SubTotal], [Iva]) VALUES (4, 1, 4, 23, CAST(235637.30 AS Decimal(18, 2)), N'10%')
INSERT [dbo].[DetalleCompra] ([IdDetalleCompra], [ProductoId], [CompraId], [CantidadComprada], [SubTotal], [Iva]) VALUES (5, 3, 4, 32, CAST(3875.84 AS Decimal(18, 2)), N'19%')
INSERT [dbo].[DetalleCompra] ([IdDetalleCompra], [ProductoId], [CompraId], [CantidadComprada], [SubTotal], [Iva]) VALUES (6, 4, 4, 323, CAST(75000.60 AS Decimal(18, 2)), N'19%')
SET IDENTITY_INSERT [dbo].[DetalleCompra] OFF
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [Cantidad], [Iva]) VALUES (1, N'ARROZ CASANARE', CAST(10245.10 AS Decimal(18, 2)), 1000, N'10%')
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [Cantidad], [Iva]) VALUES (2, N'LENTEJA CASANARE', CAST(2022.10 AS Decimal(18, 2)), 1000, N'10%')
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [Cantidad], [Iva]) VALUES (3, N'AEROSOL', CAST(121.12 AS Decimal(18, 2)), 5, N'19%')
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [Cantidad], [Iva]) VALUES (4, N'BARNIZ', CAST(232.20 AS Decimal(18, 2)), 5, N'19%')
SET IDENTITY_INSERT [dbo].[Productos] OFF
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_CLI_COM] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_CLI_COM]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_DETC_COMP] FOREIGN KEY([CompraId])
REFERENCES [dbo].[Compras] ([IdCompra])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DETC_COMP]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_DETC_PROD] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DETC_PROD]
GO
USE [master]
GO
ALTER DATABASE [pruebaDigitalWare] SET  READ_WRITE 
GO
