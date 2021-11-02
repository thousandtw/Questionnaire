USE [Questionnaire]
GO
/****** Object:  Table [dbo].[Userinfo]    Script Date: 2021/11/2 下午 04:26:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Userinfo]') AND type in (N'U'))
DROP TABLE [dbo].[Userinfo]
GO
/****** Object:  Table [dbo].[Theme]    Script Date: 2021/11/2 下午 04:26:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Theme]') AND type in (N'U'))
DROP TABLE [dbo].[Theme]
GO
/****** Object:  Table [dbo].[Question_Common]    Script Date: 2021/11/2 下午 04:26:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Question_Common]') AND type in (N'U'))
DROP TABLE [dbo].[Question_Common]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 2021/11/2 下午 04:26:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Question]') AND type in (N'U'))
DROP TABLE [dbo].[Question]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 2021/11/2 下午 04:26:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Answer]') AND type in (N'U'))
DROP TABLE [dbo].[Answer]
GO
USE [master]
GO
/****** Object:  Database [Questionnaire]    Script Date: 2021/11/2 下午 04:26:49 ******/
DROP DATABASE [Questionnaire]
GO
/****** Object:  Database [Questionnaire]    Script Date: 2021/11/2 下午 04:26:49 ******/
CREATE DATABASE [Questionnaire]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Questionnaire', FILENAME = N'D:\SQL2\MSSQL15.SQLEXPRESS\MSSQL\DATA\Questionnaire.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Questionnaire_log', FILENAME = N'D:\SQL2\MSSQL15.SQLEXPRESS\MSSQL\DATA\Questionnaire_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Questionnaire] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Questionnaire].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Questionnaire] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Questionnaire] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Questionnaire] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Questionnaire] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Questionnaire] SET ARITHABORT OFF 
GO
ALTER DATABASE [Questionnaire] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Questionnaire] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Questionnaire] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Questionnaire] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Questionnaire] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Questionnaire] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Questionnaire] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Questionnaire] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Questionnaire] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Questionnaire] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Questionnaire] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Questionnaire] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Questionnaire] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Questionnaire] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Questionnaire] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Questionnaire] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Questionnaire] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Questionnaire] SET RECOVERY FULL 
GO
ALTER DATABASE [Questionnaire] SET  MULTI_USER 
GO
ALTER DATABASE [Questionnaire] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Questionnaire] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Questionnaire] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Questionnaire] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Questionnaire] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Questionnaire] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Questionnaire', N'ON'
GO
ALTER DATABASE [Questionnaire] SET QUERY_STORE = OFF
GO
USE [Questionnaire]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 2021/11/2 下午 04:26:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[A_id] [int] NOT NULL,
	[T_id] [int] NOT NULL,
	[A_name] [nvarchar](50) NOT NULL,
	[A_phone] [varchar](10) NOT NULL,
	[A_email] [nvarchar](50) NOT NULL,
	[A_age] [varchar](3) NOT NULL,
	[QC_ansrd1] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[A_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 2021/11/2 下午 04:26:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Q_id] [int] NOT NULL,
	[T_id] [int] NOT NULL,
	[QT] [nvarchar](100) NULL,
	[ANSR] [nvarchar](1000) NOT NULL,
	[ANSR_sum] [int] NOT NULL,
	[Q_type] [nvarchar](10) NULL,
	[Q_mustKeyin] [nvarchar](10) NULL,
 CONSTRAINT [PK_Qusetion_Child] PRIMARY KEY CLUSTERED 
(
	[Q_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question_Common]    Script Date: 2021/11/2 下午 04:26:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_Common](
	[QC_id] [int] NOT NULL,
	[QC_title] [nvarchar](150) NOT NULL,
	[ANSR_1] [nvarchar](50) NOT NULL,
	[ANSR_2] [nvarchar](50) NOT NULL,
	[ANSR_3] [nvarchar](50) NULL,
	[ANSR_4] [nvarchar](50) NULL,
	[ANSR_5] [nvarchar](50) NULL,
	[ANSR_6] [nvarchar](50) NULL,
	[ANSR_7] [nvarchar](50) NULL,
	[ANSR_8] [nvarchar](50) NULL,
	[ANSR_9] [nvarchar](50) NULL,
	[ANSR_10] [nvarchar](50) NULL,
	[QC_memo] [nvarchar](250) NULL,
	[QC_type] [nvarchar](2) NOT NULL,
	[QC_mustKeyin] [char](1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Theme]    Script Date: 2021/11/2 下午 04:26:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Theme](
	[T_id] [int] NULL,
	[T_title] [nvarchar](150) NOT NULL,
	[T_state] [int] NOT NULL,
	[T_start] [datetime] NOT NULL,
	[T_end] [datetime] NOT NULL,
	[T_memo] [nvarchar](250) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Userinfo]    Script Date: 2021/11/2 下午 04:26:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userinfo](
	[User_id] [uniqueidentifier] NOT NULL,
	[User_name] [nvarchar](50) NOT NULL,
	[User_phone] [varchar](10) NULL,
	[User_email] [nvarchar](100) NULL,
	[User_account] [varchar](50) NOT NULL,
	[User_password] [varchar](50) NOT NULL,
	[User_level] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (1028, 1, N'張大千', N'0916619154', N'h0619619196@gmail.com', N'26', N'永野芽郁,石原里美', CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (1136, 2, N'王大衛', N'0912341122', N'H0912341122@gmail.com', N'42', N'法國, 義大利', CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (1146, 1, N'超級棒', N'0912341123', N'H0912341123@gmail.com', N'30', N'永野芽郁, 北川景子', CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (1348, 2, N'羅小佑', N'0916619199', N'h916619199@gmail.com', N'35', N'台灣, 德國, 義大利, 西班牙', CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (1412, 2, N'張小千', N'0916619164', N'h916619164@gmail.com', N'12', N'台灣', CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (1505, 2, N'張小千', N'0916619164', N'h916619164@gmail.com', N'18', N'日本, 德國', CAST(N'2021-10-29T16:15:05.363' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (1557, 2, N'蕭強', N'0921619164', N'h921619164@gmail.com', N'46', N'英國, 法國, 土耳其', CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (2036, 1, N'順順存', N'0933619164', N'h933619164@gmail.com', N'30', N'石原里美, 新垣結衣', CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (2156, 2, N'周順發', N'0916619133', N'h916619133@gmail.com', N'28', N'韓國, 美國', CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (2354, 1, N'黃飛鴻', N'0933619164', N'h933619164@gmail.com', N'20', N'橋本環奈, 濱邊美波', CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (2414, 1, N'超棒', N'0912341133', N'H0912341133@gmail.com', N'18', N'永野芽郁', CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [CreateDate]) VALUES (3810, 2, N'周順發', N'0916619133', N'h916619133@gmail.com', N'18', N'台灣, 英國, 土耳其', CAST(N'2021-10-28T21:38:10.633' AS DateTime))
GO
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (1019, 1, N'1.請投票', N'永野芽郁,有村架純,今田美櫻,橋本環奈,北川景子,濱邊美波,石原里美,新垣結衣,長澤雅美,綾瀨遙', 1, N'MS', N'Y')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (1020, 2, N'1.請投票', N'台灣,日本,韓國,美國,英國,法國,德國,義大利,西班牙,土耳其', 1, N'MS', N'Y')
GO
INSERT [dbo].[Question_Common] ([QC_id], [QC_title], [ANSR_1], [ANSR_2], [ANSR_3], [ANSR_4], [ANSR_5], [ANSR_6], [ANSR_7], [ANSR_8], [ANSR_9], [ANSR_10], [QC_memo], [QC_type], [QC_mustKeyin]) VALUES (1, N'帥氣男藝人投票戰', N'柯震東', N'吳慷仁', N'炎亞綸', N'汪大東', N'許光漢', N'劉以豪', N'朱軒洋', N'黃河', N'范少勳', N'孫楊', N'投給你最欣賞的美少男,為他加油打氣,請留真實資料投票,請勿洗票!!!', N'MS', N'Y')
GO
INSERT [dbo].[Theme] ([T_id], [T_title], [T_state], [T_start], [T_end], [T_memo]) VALUES (1, N'日本人氣女星投票戰', 1, CAST(N'2021-10-19T00:00:00.000' AS DateTime), CAST(N'2021-10-29T00:00:00.000' AS DateTime), N'投給你最欣賞的藝人,為她加油打氣,請留真實資料投票,請勿洗票!!!')
INSERT [dbo].[Theme] ([T_id], [T_title], [T_state], [T_start], [T_end], [T_memo]) VALUES (2, N'旅遊人氣地投票戰', 1, CAST(N'2021-03-19T00:00:00.000' AS DateTime), CAST(N'2021-03-29T00:00:00.000' AS DateTime), N'投給你最喜愛的旅遊景,請留真實資料投票,請勿洗票!!!')
GO
INSERT [dbo].[Userinfo] ([User_id], [User_name], [User_phone], [User_email], [User_account], [User_password], [User_level]) VALUES (N'8f6d51f4-a40b-461d-b144-3f6df2530d15', N'admin', N'0912345678', N'h0916916169@gmail.com', N'admin', N'SG123456', 0)
INSERT [dbo].[Userinfo] ([User_id], [User_name], [User_phone], [User_email], [User_account], [User_password], [User_level]) VALUES (N'bfb5f489-e3ad-4648-9494-fbf38e200219', N'張大千', N'0916619154', N'h0619619196@gmail.com', N'thousand', N'88888888', 1)
GO
USE [master]
GO
ALTER DATABASE [Questionnaire] SET  READ_WRITE 
GO
