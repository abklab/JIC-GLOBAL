USE [master]
GO
/****** Object:  Database [PROVISO-LMSDB]    Script Date: 9/14/2020 3:48:58 PM ******/
CREATE DATABASE [PROVISO-LMSDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PROVISO-LMSDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PROVISO-LMSDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PROVISO-LMSDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PROVISO-LMSDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PROVISO-LMSDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PROVISO-LMSDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PROVISO-LMSDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PROVISO-LMSDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PROVISO-LMSDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PROVISO-LMSDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PROVISO-LMSDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PROVISO-LMSDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PROVISO-LMSDB] SET  MULTI_USER 
GO
ALTER DATABASE [PROVISO-LMSDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PROVISO-LMSDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PROVISO-LMSDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PROVISO-LMSDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PROVISO-LMSDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PROVISO-LMSDB] SET QUERY_STORE = OFF
GO
USE [PROVISO-LMSDB]
GO
/****** Object:  Table [dbo].[Loan_Outstanding_3]    Script Date: 9/14/2020 3:48:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan_Outstanding_3](
	[EntryID] [int] IDENTITY(1,1) NOT NULL,
	[Account_Number] [varchar](50) NOT NULL,
	[Account_Name] [varchar](50) NOT NULL,
	[Balance] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Loan_Outstanding_3] PRIMARY KEY CLUSTERED 
(
	[Account_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwCustomersLoanOutstanding]    Script Date: 9/14/2020 3:48:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwCustomersLoanOutstanding]
AS
SELECT        EntryID, Account_Number, Account_Name, Balance
FROM            dbo.Loan_Outstanding_3
GO
/****** Object:  Table [dbo].[LoanApplication]    Script Date: 9/14/2020 3:48:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanApplication](
	[ApplicationID] [int] IDENTITY(2000000,1) NOT NULL,
	[FullName] [varchar](100) NOT NULL,
	[RequestAmount] [decimal](18, 0) NOT NULL,
	[SectorID] [varchar](50) NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[Location] [varchar](50) NULL,
	[NearestLandmark] [varchar](150) NULL,
	[DistributionMode] [varchar](50) NULL,
	[MNO] [varchar](50) NULL,
	[MomoNumber] [varchar](50) NULL,
	[BankAccountNumber] [varchar](50) NULL,
	[BankName] [varchar](50) NULL,
	[Comments] [varchar](250) NULL,
	[ApplicationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LoanApplication] PRIMARY KEY CLUSTERED 
(
	[ApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceProvider]    Script Date: 9/14/2020 3:48:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceProvider](
	[ProviderID] [int] IDENTITY(10000,1) NOT NULL,
	[ProviderType] [varchar](50) NULL,
	[Description] [nchar](10) NULL,
 CONSTRAINT [PK_ServiceProvider] PRIMARY KEY CLUSTERED 
(
	[ProviderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 9/14/2020 3:48:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[EntryID] [int] IDENTITY(1000000,1) NOT NULL,
	[RefNo] [varchar](50) NOT NULL,
	[ProviderType] [varchar](50) NULL,
	[ProviderName] [varchar](50) NULL,
	[AccountNumber] [varchar](50) NULL,
	[ContactNumber] [varchar](50) NULL,
	[EmailAddress] [varchar](50) NULL,
	[Amount] [decimal](18, 2) NULL,
	[TransactionID] [varchar](50) NULL,
	[TransactionType] [varchar](50) NULL,
	[EntryDate] [datetime] NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[EntryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions_Logs]    Script Date: 9/14/2020 3:48:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions_Logs](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[Descriptions] [varchar](max) NULL,
	[LogEntryDateTime] [datetime] NULL,
 CONSTRAINT [PK_Transactions_Logs] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[LoanApplication] ADD  CONSTRAINT [DF_LoanApplication_ApplicationDate]  DEFAULT (getdate()) FOR [ApplicationDate]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
/****** Object:  StoredProcedure [dbo].[usp_validateCustomerRefernceID]    Script Date: 9/14/2020 3:48:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/

	create proc [dbo].[usp_validateCustomerRefernceID]
	@RefNo VARCHAR(50)='12345678912'
	
	AS
	 declare @outputValue int;  
	     
	 SELECT @outputValue = COUNT(Account_Number)  
	 FROM [dbo].[vwCustomersLoanOutstanding] 
	 where Account_Number = @RefNo;

	return @outputValue


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Client TransactionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transactions', @level2type=N'COLUMN',@level2name=N'TransactionID'
GO
USE [master]
GO
ALTER DATABASE [PROVISO-LMSDB] SET  READ_WRITE 
GO
