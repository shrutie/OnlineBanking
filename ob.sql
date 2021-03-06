USE [master]
GO
/****** Object:  Database [OnlineBank]    Script Date: 05/15/2014 23:42:27 ******/
CREATE DATABASE [OnlineBank] ON  PRIMARY 
( NAME = N'OnlineBank', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\OnlineBank.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OnlineBank_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\OnlineBank_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OnlineBank] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineBank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineBank] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [OnlineBank] SET ANSI_NULLS OFF
GO
ALTER DATABASE [OnlineBank] SET ANSI_PADDING OFF
GO
ALTER DATABASE [OnlineBank] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [OnlineBank] SET ARITHABORT OFF
GO
ALTER DATABASE [OnlineBank] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [OnlineBank] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [OnlineBank] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [OnlineBank] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [OnlineBank] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [OnlineBank] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [OnlineBank] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [OnlineBank] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [OnlineBank] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [OnlineBank] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [OnlineBank] SET  DISABLE_BROKER
GO
ALTER DATABASE [OnlineBank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [OnlineBank] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [OnlineBank] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [OnlineBank] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [OnlineBank] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [OnlineBank] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [OnlineBank] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [OnlineBank] SET  READ_WRITE
GO
ALTER DATABASE [OnlineBank] SET RECOVERY SIMPLE
GO
ALTER DATABASE [OnlineBank] SET  MULTI_USER
GO
ALTER DATABASE [OnlineBank] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [OnlineBank] SET DB_CHAINING OFF
GO
USE [OnlineBank]
GO
/****** Object:  Table [dbo].[transactions]    Script Date: 05/15/2014 23:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[transactions](
	[Transaction_ID] [varchar](50) NOT NULL,
	[Transfer_to] [varchar](50) NOT NULL,
	[Transfer_from] [varchar](50) NOT NULL,
	[Amount] [varchar](50) NOT NULL,
	[Date] [varchar](50) NOT NULL,
	[Available_Balance] [varchar](50) NOT NULL,
	[Status] [varchar](10) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[registration]    Script Date: 05/15/2014 23:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[registration](
	[username] [varchar](50) NOT NULL,
	[dateofbirth] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[mobile] [varchar](50) NOT NULL,
	[accounttype] [varchar](50) NOT NULL,
	[image] [varchar](50) NULL,
	[accountid] [varchar](50) NOT NULL,
 CONSTRAINT [PK_registration] PRIMARY KEY CLUSTERED 
(
	[accountid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[login]    Script Date: 05/15/2014 23:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[firsttimelog] [nvarchar](50) NOT NULL,
	[usertype] [nvarchar](50) NOT NULL,
	[accountid] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_login] PRIMARY KEY CLUSTERED 
(
	[accountid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contact]    Script Date: 05/15/2014 23:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[contact](
	[id] [varchar](50) NOT NULL,
	[img] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[complain]    Script Date: 05/15/2014 23:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[complain](
	[accountid] [varchar](50) NOT NULL,
	[cmessage] [varchar](800) NOT NULL,
	[date] [varchar](50) NOT NULL,
	[time] [varchar](50) NOT NULL,
	[status] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[checkbook]    Script Date: 05/15/2014 23:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[checkbook](
	[accountid] [varchar](50) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[contact] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[address] [varchar](50) NOT NULL,
	[pincode] [varchar](50) NOT NULL,
	[acctype] [varchar](50) NOT NULL,
 CONSTRAINT [PK_checkbook] PRIMARY KEY CLUSTERED 
(
	[accountid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[balance]    Script Date: 05/15/2014 23:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[balance](
	[accountid] [varchar](50) NOT NULL,
	[balance] [varchar](50) NOT NULL,
	[accounttype] [varchar](50) NOT NULL,
 CONSTRAINT [PK_balance] PRIMARY KEY CLUSTERED 
(
	[accountid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
