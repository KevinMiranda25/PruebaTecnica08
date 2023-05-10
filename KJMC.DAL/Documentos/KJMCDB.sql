USE [master]
GO
CREATE DATABASE [KJMCDB]
GO
USE [KJMCDB]
GO

CREATE TABLE [dbo].[Servicios](
[Id] [int] PRIMARY KEY IDENTITY(1,1)NOT NULL,
[TipoServicio] [varchar](12)NOT NULL,
[DescripcionServicio] [varchar](100)NOT NULL,
[Precio] [decimal] (3,2)NOT NULL
)