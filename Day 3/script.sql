USE [master]
GO
/****** Object:  Database [inTimeDatabase]    Script Date: 02-04-2018 15:45:00 ******/
CREATE DATABASE [inTimeDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'inTimeDatabase', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\inTimeDatabase.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'inTimeDatabase_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\inTimeDatabase_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [inTimeDatabase] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [inTimeDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [inTimeDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [inTimeDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [inTimeDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [inTimeDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [inTimeDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [inTimeDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [inTimeDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [inTimeDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [inTimeDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [inTimeDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [inTimeDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [inTimeDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [inTimeDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [inTimeDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [inTimeDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [inTimeDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [inTimeDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [inTimeDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [inTimeDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [inTimeDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [inTimeDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [inTimeDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [inTimeDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [inTimeDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [inTimeDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [inTimeDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [inTimeDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [inTimeDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [inTimeDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'inTimeDatabase', N'ON'
GO
USE [inTimeDatabase]
GO
/****** Object:  Table [dbo].[MenuTable]    Script Date: 02-04-2018 15:45:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MenuTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](100) NOT NULL,
	[ItemPrice] [money] NOT NULL,
	[RestaurantID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RestaurantTable]    Script Date: 02-04-2018 15:45:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RestaurantTable](
	[RestaurantID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[ContactNo] [bigint] NOT NULL,
	[EmailID] [varchar](100) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_RestaurantTable] PRIMARY KEY CLUSTERED 
(
	[RestaurantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RestaurantTable]    Script Date: 02-04-2018 15:45:00 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_RestaurantTable] ON [dbo].[RestaurantTable]
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[registerUser]    Script Date: 02-04-2018 15:45:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[registerUser]
(
  @name varchar(50),
  @address varchar(200),
  @email varchar(100),
  @no bigint, 
  @username varchar(50),
  @pwd varchar(50),
  @regId int OUTPUT
)
AS
INSERT INTO RestaurantTable VALUES(@name, @address,@no,@email, @username, @pwd)
SET @regId = @@IDENTITY
 
GO
USE [master]
GO
ALTER DATABASE [inTimeDatabase] SET  READ_WRITE 
GO
