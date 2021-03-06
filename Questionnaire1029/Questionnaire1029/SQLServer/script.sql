USE [Questionnaire]
GO
/****** Object:  Table [dbo].[Userinfo]    Script Date: 2021/11/17 下午 04:40:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Userinfo]') AND type in (N'U'))
DROP TABLE [dbo].[Userinfo]
GO
/****** Object:  Table [dbo].[Theme]    Script Date: 2021/11/17 下午 04:40:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Theme]') AND type in (N'U'))
DROP TABLE [dbo].[Theme]
GO
/****** Object:  Table [dbo].[Question_Common]    Script Date: 2021/11/17 下午 04:40:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Question_Common]') AND type in (N'U'))
DROP TABLE [dbo].[Question_Common]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 2021/11/17 下午 04:40:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Question]') AND type in (N'U'))
DROP TABLE [dbo].[Question]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 2021/11/17 下午 04:40:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Answer]') AND type in (N'U'))
DROP TABLE [dbo].[Answer]
GO
USE [master]
GO
/****** Object:  Database [Questionnaire]    Script Date: 2021/11/17 下午 04:40:01 ******/
DROP DATABASE [Questionnaire]
GO
/****** Object:  Database [Questionnaire]    Script Date: 2021/11/17 下午 04:40:01 ******/
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
/****** Object:  Table [dbo].[Answer]    Script Date: 2021/11/17 下午 04:40:02 ******/
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
	[QC_ansrd2] [nvarchar](50) NULL,
	[QC_ansrd3] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[A_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 2021/11/17 下午 04:40:02 ******/
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
/****** Object:  Table [dbo].[Question_Common]    Script Date: 2021/11/17 下午 04:40:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_Common](
	[QC_id] [int] IDENTITY(1,1) NOT NULL,
	[QC_title] [nvarchar](150) NOT NULL,
	[ANSR_1] [nvarchar](50) NOT NULL,
	[QC_type] [nvarchar](10) NOT NULL,
	[QC_mustKeyin] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Question_Common] PRIMARY KEY CLUSTERED 
(
	[QC_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Theme]    Script Date: 2021/11/17 下午 04:40:02 ******/
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
/****** Object:  Table [dbo].[Userinfo]    Script Date: 2021/11/17 下午 04:40:02 ******/
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
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (201, 6, N'王大衛', N'0912341122', N'H0912341122@gmail.com', N'35', N'籃網', N'金塊', N'馬刺', CAST(N'2021-11-17T15:02:01.863' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (1028, 1, N'張大千', N'0916619154', N'h0619619196@gmail.com', N'26', N'永野芽郁;石原里美', NULL, NULL, CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (1136, 2, N'王大衛', N'0912341122', N'H0912341122@gmail.com', N'42', N'法國;義大利', NULL, NULL, CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (1146, 1, N'超級棒', N'0912341123', N'H0912341123@gmail.com', N'30', N'永野芽郁;北川景子', NULL, NULL, CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (1348, 2, N'羅小佑', N'0916619199', N'h916619199@gmail.com', N'35', N'台灣;德國;義大利;西班牙', NULL, NULL, CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (1412, 2, N'張小千', N'0916619164', N'h916619164@gmail.com', N'12', N'台灣', NULL, NULL, CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (1505, 2, N'張小千', N'0916619164', N'h916619164@gmail.com', N'18', N'日本;德國', NULL, NULL, CAST(N'2021-10-29T16:15:05.363' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (1557, 2, N'蕭強', N'0921619164', N'h921619164@gmail.com', N'46', N'英國;法國;土耳其', NULL, NULL, CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (1757, 6, N'王大衛', N'0912341122', N'H0912341122@gmail.com', N'30', N'籃網', N'小牛', N'太陽', CAST(N'2021-11-15T18:17:57.203' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (2036, 1, N'順順存', N'0933619164', N'h933619164@gmail.com', N'30', N'石原里美;新垣結衣', NULL, NULL, CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (2156, 2, N'周順發', N'0916619133', N'h916619133@gmail.com', N'28', N'韓國;美國', NULL, NULL, CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (2354, 1, N'黃飛鴻', N'0933619164', N'h933619164@gmail.com', N'20', N'橋本環奈;濱邊美波', NULL, NULL, CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (2404, 6, N'黃飛鴻', N'0933619164', N'h933619164@gmail.com', N'30', N'公牛', N'勇士', N'湖人', CAST(N'2021-11-17T16:24:04.030' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (2414, 1, N'超棒', N'0912341133', N'H0912341133@gmail.com', N'18', N'永野芽郁', NULL, NULL, CAST(N'2021-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (2945, 4, N'陳大美', N'0916619155', N'h0916619155@gmail.com', N'35', N'50萬', N'樂觀', N'嫖妓', CAST(N'2021-11-08T20:29:45.107' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (3112, 4, N'林風', N'0916619154', N'h0916916145@gmail.com', N'18', N'30萬', N'積極', N'喝酒', CAST(N'2021-11-08T20:31:12.090' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (3155, 4, N'黃飛鴻', N'0916619154', N'h0916916145@gmail.com', N'30', N'70萬', N'善良', N'賭博', CAST(N'2021-11-08T20:31:55.563' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (3239, 4, N'王大衛', N'0912341122', N'H0912341122@gmail.com', N'42', N'100萬', N'溫柔', N'賭博', CAST(N'2021-11-08T20:32:39.843' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (3401, 4, N'蔡國文', N'0933619164', N'h933619164@gmail.com', N'30', N'30萬', N'積極', N'賭博', CAST(N'2021-11-08T20:34:01.667' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (3527, 4, N'張大千', N'0916619154', N'h0916916145@gmail.com', N'30', N'50萬', N'樂觀', N'抽菸', CAST(N'2021-11-07T20:35:27.040' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (3810, 2, N'周順發', N'0916619133', N'h916619133@gmail.com', N'18', N'台灣;英國;土耳其', NULL, NULL, CAST(N'2021-10-28T21:38:10.633' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (5223, 5, N'張大千', N'0916619154', N'h0916916145@gmail.com', N'18', N'臭豆腐;拉麵', N'', N'雞排', CAST(N'2021-11-08T16:52:23.077' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (5404, 3, N'王大衛', N'0912341122', N'H0912341122@gmail.com', N'35', N'30萬', N'工程師', N'', CAST(N'2021-11-17T15:54:04.453' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (5421, 3, N'張小千', N'0916619164', N'h916619164@gmail.com', N'35', N'50萬', N'醫生', N'', CAST(N'2021-11-17T15:54:21.480' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (5433, 3, N'超棒', N'0912341133', N'H0912341133@gmail.com', N'18', N'10萬', N'律師', N'', CAST(N'2021-11-17T15:54:33.090' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (5441, 6, N'黃飛鴻', N'0933619164', N'h933619164@gmail.com', N'30', N'熱火', N'金塊', N'湖人', CAST(N'2021-11-15T17:54:41.677' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (5526, 6, N'超級棒', N'0912341123', N'H0912341123@gmail.com', N'42', N'公牛', N'勇士', N'爵士', CAST(N'2021-11-15T17:55:26.780' AS DateTime))
INSERT [dbo].[Answer] ([A_id], [T_id], [A_name], [A_phone], [A_email], [A_age], [QC_ansrd1], [QC_ansrd2], [QC_ansrd3], [CreateDate]) VALUES (5927, 6, N'陳大美', N'0916619155', N'h0916619155@gmail.com', N'35', N'籃網', N'金塊', N'馬刺', CAST(N'2021-11-16T15:59:27.690' AS DateTime))
GO
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (1019, 1, N'1.請投票', N'永野芽郁;有村架純;今田美櫻;橋本環奈;北川景子;濱邊美波;石原里美;新垣結衣;長澤雅美;綾瀨遙', 10, N'複選方塊', N'是')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (1020, 2, N'1.請投票', N'台灣;日本;韓國;美國;英國;法國;德國;義大利;西班牙;土耳其', 10, N'複選方塊', N'是')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (39697, 5, N'台灣料理', N'臭豆腐;滷肉飯;鹽酥雞', 3, N'複選方塊', N'是')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (39777, 5, N'日本料理', N'拉麵;壽司;章魚燒', 3, N'複選方塊', N'是')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (39807, 5, N'其他料理', N'無', 1, N'文字方塊', N'否')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (74416, 6, N'東區', N'公牛;籃網;熱火', 3, N'複選方塊', N'是')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (74556, 6, N'西區', N'勇士;金塊;小牛', 3, N'單選方塊', N'是')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (74595, 6, N'其他 : ', N'無', 1, N'文字方塊', N'否')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (1103203057, 3, N'存款 :', N'10萬;30萬;50萬', 3, N'複選方塊', N'是')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (1103203058, 3, N'工作 :', N'律師;醫生;工程師', 3, N'單選方塊', N'是')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (1107203003, 4, N'存款', N'30萬;50萬;70萬;100萬', 4, N'複選方塊', N'是')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (1107203125, 4, N'個性', N'溫柔;善良;積極;樂觀', 4, N'單選方塊', N'是')
INSERT [dbo].[Question] ([Q_id], [T_id], [QT], [ANSR], [ANSR_sum], [Q_type], [Q_mustKeyin]) VALUES (1107203212, 4, N'不能有的缺點', N'無', 1, N'文字方塊', N'是')
GO
SET IDENTITY_INSERT [dbo].[Question_Common] ON 

INSERT [dbo].[Question_Common] ([QC_id], [QC_title], [ANSR_1], [QC_type], [QC_mustKeyin]) VALUES (1, N'帥氣男藝人投票戰 : ', N'彭于晏;金城武;竇智孔;王力宏', N'單選方塊', N'否')
INSERT [dbo].[Question_Common] ([QC_id], [QC_title], [ANSR_1], [QC_type], [QC_mustKeyin]) VALUES (2, N'存款 :', N'30萬;50萬;70萬;100萬', N'複選方塊', N'是')
INSERT [dbo].[Question_Common] ([QC_id], [QC_title], [ANSR_1], [QC_type], [QC_mustKeyin]) VALUES (3, N'個性 :', N'溫柔;善良;積極;樂觀', N'單選方塊', N'是')
INSERT [dbo].[Question_Common] ([QC_id], [QC_title], [ANSR_1], [QC_type], [QC_mustKeyin]) VALUES (6, N'工作 :', N'律師;醫生;工程師', N'複選方塊', N'否')
INSERT [dbo].[Question_Common] ([QC_id], [QC_title], [ANSR_1], [QC_type], [QC_mustKeyin]) VALUES (7, N'台灣料理 :', N'臭豆腐;滷肉飯;鹽酥雞', N'單選方塊', N'是')
INSERT [dbo].[Question_Common] ([QC_id], [QC_title], [ANSR_1], [QC_type], [QC_mustKeyin]) VALUES (8, N'其他 : ', N'無', N'文字方塊', N'否')
SET IDENTITY_INSERT [dbo].[Question_Common] OFF
GO
INSERT [dbo].[Theme] ([T_id], [T_title], [T_state], [T_start], [T_end], [T_memo]) VALUES (1, N'日本人氣女星投票戰', 1, CAST(N'2021-11-03T00:00:00.000' AS DateTime), CAST(N'2021-11-16T00:00:00.000' AS DateTime), N'投給你最欣賞的藝人,為她加油打氣,請留真實資料投票,請勿洗票!!!')
INSERT [dbo].[Theme] ([T_id], [T_title], [T_state], [T_start], [T_end], [T_memo]) VALUES (2, N'旅遊人氣地投票戰', 2, CAST(N'2021-03-19T00:00:00.000' AS DateTime), CAST(N'2021-03-29T00:00:00.000' AS DateTime), N'投給你最喜愛的旅遊景,請留真實資料投票,請勿洗票!!!')
INSERT [dbo].[Theme] ([T_id], [T_title], [T_state], [T_start], [T_end], [T_memo]) VALUES (4, N'結婚的理想對象', 1, CAST(N'2021-11-05T00:00:00.000' AS DateTime), CAST(N'2021-11-15T00:00:00.000' AS DateTime), N'應該具備什麼特質?')
INSERT [dbo].[Theme] ([T_id], [T_title], [T_state], [T_start], [T_end], [T_memo]) VALUES (5, N'最愛的食物', 1, CAST(N'2021-11-10T00:00:00.000' AS DateTime), CAST(N'2021-11-25T00:00:00.000' AS DateTime), N'第一時間會想到什麼呢?')
INSERT [dbo].[Theme] ([T_id], [T_title], [T_state], [T_start], [T_end], [T_memo]) VALUES (6, N'NBA總冠軍', 1, CAST(N'2021-11-17T00:00:00.000' AS DateTime), CAST(N'2021-11-27T00:00:00.000' AS DateTime), N'熱愛籃球的你,最支持哪支隊伍呢?')
INSERT [dbo].[Theme] ([T_id], [T_title], [T_state], [T_start], [T_end], [T_memo]) VALUES (3, N'26歲應該有什麼樣的成就?', 1, CAST(N'2021-11-05T00:00:00.000' AS DateTime), CAST(N'2021-11-15T00:00:00.000' AS DateTime), N'你覺得呢?')
GO
INSERT [dbo].[Userinfo] ([User_id], [User_name], [User_phone], [User_email], [User_account], [User_password], [User_level]) VALUES (N'8f6d51f4-a40b-461d-b144-3f6df2530d15', N'admin', N'0912345678', N'h0916916169@gmail.com', N'admin', N'SG123456', 0)
INSERT [dbo].[Userinfo] ([User_id], [User_name], [User_phone], [User_email], [User_account], [User_password], [User_level]) VALUES (N'bfb5f489-e3ad-4648-9494-fbf38e200219', N'張大千', N'0916619154', N'h0619619196@gmail.com', N'thousand', N'88888888', 1)
GO
USE [master]
GO
ALTER DATABASE [Questionnaire] SET  READ_WRITE 
GO
