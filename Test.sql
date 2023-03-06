USE [master]
GO
/****** Object:  Database [Test]    Script Date: 5/3/2023 21:44:36 ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test] SET RECOVERY FULL 
GO
ALTER DATABASE [Test] SET  MULTI_USER 
GO
ALTER DATABASE [Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Test] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Test', N'ON'
GO
ALTER DATABASE [Test] SET QUERY_STORE = OFF
GO
USE [Test]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[idRegion] [int] IDENTITY(1,1) NOT NULL,
	[RegionName] [varchar](250) NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[idRegion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegionType]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionType](
	[idRegion] [int] NOT NULL,
	[idCapacityType] [int] NOT NULL,
	[Cost] [float] NULL,
 CONSTRAINT [PK_RegionTipo] PRIMARY KEY CLUSTERED 
(
	[idRegion] ASC,
	[idCapacityType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCapacidad]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCapacidad](
	[idTipoCapacidad] [int] IDENTITY(1,1) NOT NULL,
	[CapacityName] [varchar](250) NULL,
	[QuantityUnits] [int] NULL,
 CONSTRAINT [PK_TipoCapacidad] PRIMARY KEY CLUSTERED 
(
	[idTipoCapacidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RegionType]  WITH CHECK ADD  CONSTRAINT [FK_Region_RegionTipo] FOREIGN KEY([idRegion])
REFERENCES [dbo].[Region] ([idRegion])
GO
ALTER TABLE [dbo].[RegionType] CHECK CONSTRAINT [FK_Region_RegionTipo]
GO
ALTER TABLE [dbo].[RegionType]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_RegionTipo] FOREIGN KEY([idCapacityType])
REFERENCES [dbo].[TipoCapacidad] ([idTipoCapacidad])
GO
ALTER TABLE [dbo].[RegionType] CHECK CONSTRAINT [FK_Tipo_RegionTipo]
GO
/****** Object:  StoredProcedure [dbo].[SP_create_region]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Ulate
-- Create date: 05/03/2023
-- Description:	Create a Region
-- =============================================
CREATE PROCEDURE [dbo].[SP_create_region]
	-- Add the parameters for the stored procedure here
	@RegionName varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	INSERT INTO [dbo].[Region]
			   ([RegionName])
		 VALUES
			   (@RegionName)


END
GO
/****** Object:  StoredProcedure [dbo].[SP_create_RegionType]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Ulate
-- Create date: 05/03/2023
-- Description:	Create a RegionType
-- =============================================
CREATE PROCEDURE [dbo].[SP_create_RegionType] 
	-- Add the parameters for the stored procedure here
	@idRegion int
    ,@idCapacityType int
    ,@Cost float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

INSERT INTO [dbo].[RegionType]
           ([idRegion]
           ,[idCapacityType]
           ,[Cost])
     VALUES
           (@idRegion
           ,@idCapacityType
           ,@Cost)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_create_TipoCapacidad]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Ulate
-- Create date: 05/03/2023
-- Description:	Create a TipoCapacidad
-- =============================================
CREATE PROCEDURE [dbo].[SP_create_TipoCapacidad]
	-- Add the parameters for the stored procedure here
	@CapacityName varchar(250)
    ,@QuantityUnits int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

INSERT INTO [dbo].[TipoCapacidad]
           ([CapacityName]
           ,[QuantityUnits])
     VALUES
           (@CapacityName
           ,@QuantityUnits)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_delete_region]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Ulate
-- Create date: 05/03/2023
-- Description:	Delete a Region
-- =============================================
CREATE PROCEDURE [dbo].[SP_delete_region] 
	-- Add the parameters for the stored procedure here
	@idRegion int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

		DELETE FROM [dbo].[Region]
			  WHERE [idRegion] = @IdRegion 

END
GO
/****** Object:  StoredProcedure [dbo].[SP_delete_RegionType]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Ulate
-- Create date: 05/03/2023
-- Description:	Delete a region type
-- =============================================
CREATE PROCEDURE [dbo].[SP_delete_RegionType]  
	-- Add the parameters for the stored procedure here
	@idRegion int
    ,@idCapacityType int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

		DELETE FROM [dbo].[RegionType]
			  WHERE [idRegion] = @idRegion and [idCapacityType] = @idCapacityType


END
GO
/****** Object:  StoredProcedure [dbo].[SP_delete_TipoCapacidad]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Ulate
-- Create date: 05/03/2023
-- Description:	Delete a TipoCapacidad
-- =============================================
CREATE PROCEDURE [dbo].[SP_delete_TipoCapacidad]  
	-- Add the parameters for the stored procedure here
	@idTipoCapacidad int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DELETE FROM [dbo].[TipoCapacidad]
      WHERE [idTipoCapacidad] = @idTipoCapacidad

END
GO
/****** Object:  StoredProcedure [dbo].[SP_update_region]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Ulate
-- Create date: 05/03/2023
-- Description:	Update a name of region
-- =============================================
CREATE PROCEDURE [dbo].[SP_update_region] 
	-- Add the parameters for the stored procedure here
	@IdRegion int, 
	@RegionName varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

		UPDATE [dbo].[Region]
		   SET [RegionName] = @RegionName
		 WHERE [idRegion] = @IdRegion 


END
GO
/****** Object:  StoredProcedure [dbo].[SP_update_RegionType]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Ulate
-- Create date: 05/03/2023
-- Description:	Update cost of RegionType
-- =============================================
CREATE PROCEDURE [dbo].[SP_update_RegionType] 
	-- Add the parameters for the stored procedure here
	@idRegion int
    ,@idCapacityType int
    ,@Cost float 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


UPDATE [dbo].[RegionType]
   SET [Cost] = @Cost
 WHERE [idRegion] = @idRegion and [idCapacityType] = @idCapacityType


END
GO
/****** Object:  StoredProcedure [dbo].[SP_update_TipoCapacidad]    Script Date: 5/3/2023 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CArlos Ulate
-- Create date: 05/03/2023
-- Description:	Update the name and the quantity of units
-- =============================================
CREATE PROCEDURE [dbo].[SP_update_TipoCapacidad] 
	-- Add the parameters for the stored procedure here
	@CapacityName varchar(250)
    ,@QuantityUnits int
	,@idTipoCapacidad int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

UPDATE [dbo].[TipoCapacidad]
   SET [CapacityName] = @CapacityName
      ,[QuantityUnits] = @QuantityUnits
 WHERE [idTipoCapacidad] = @idTipoCapacidad


END
GO
USE [master]
GO
ALTER DATABASE [Test] SET  READ_WRITE 
GO
