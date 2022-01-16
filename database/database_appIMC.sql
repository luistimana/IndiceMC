USE [database_appIMC]
GO
/****** Object:  Table [dbo].[Imc]    Script Date: 15/01/2022 20:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imc](
	[Id_Imc] [int] IDENTITY(1,1) NOT NULL,
	[Altura] [numeric](18, 2) NULL,
	[Peso] [numeric](18, 2) NULL,
	[Resultado] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Imc] PRIMARY KEY CLUSTERED 
(
	[Id_Imc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Insertar_imc]    Script Date: 15/01/2022 20:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Insertar_imc]
@Altura numeric(18,2),
@Peso numeric(18,2),
@Resultado numeric(18,2)
as
insert into Imc values(@Altura,@Peso,@Resultado)
GO
/****** Object:  StoredProcedure [dbo].[mostrar_peso_mas_alto]    Script Date: 15/01/2022 20:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_peso_mas_alto]

as
Select Max(Peso ) from Imc
GO
