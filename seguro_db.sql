USE [Seguro]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/7/2023 7:51:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Segurado]    Script Date: 11/7/2023 7:51:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Segurado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[CPF] [nvarchar](max) NOT NULL,
	[DataNascimento] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Segurado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguro]    Script Date: 11/7/2023 7:51:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SeguradoId] [int] NOT NULL,
	[VeiculoId] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Seguro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Veiculo]    Script Date: 11/7/2023 7:51:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Veiculo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [nvarchar](max) NULL,
	[Modelo] [nvarchar](max) NULL,
	[Placa] [nvarchar](max) NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Veiculo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Segurado] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreateDate]
GO
ALTER TABLE [dbo].[Segurado] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Seguro] ADD  DEFAULT ((0.0)) FOR [Valor]
GO
ALTER TABLE [dbo].[Seguro] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreateDate]
GO
ALTER TABLE [dbo].[Seguro] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Veiculo] ADD  DEFAULT ((0.0)) FOR [Valor]
GO
ALTER TABLE [dbo].[Veiculo] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreateDate]
GO
ALTER TABLE [dbo].[Veiculo] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Seguro]  WITH CHECK ADD  CONSTRAINT [FK_Seguro_Segurado_SeguradoId] FOREIGN KEY([SeguradoId])
REFERENCES [dbo].[Segurado] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Seguro] CHECK CONSTRAINT [FK_Seguro_Segurado_SeguradoId]
GO
ALTER TABLE [dbo].[Seguro]  WITH CHECK ADD  CONSTRAINT [FK_Seguro_Veiculo_VeiculoId] FOREIGN KEY([VeiculoId])
REFERENCES [dbo].[Veiculo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Seguro] CHECK CONSTRAINT [FK_Seguro_Veiculo_VeiculoId]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data/Hora da criação.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Segurado', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data/Hora da última atualização.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Segurado', @level2type=N'COLUMN',@level2name=N'UpdateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data/Hora da criação.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Seguro', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data/Hora da última atualização.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Seguro', @level2type=N'COLUMN',@level2name=N'UpdateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data/Hora da criação.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Veiculo', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data/Hora da última atualização.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Veiculo', @level2type=N'COLUMN',@level2name=N'UpdateDate'
GO
