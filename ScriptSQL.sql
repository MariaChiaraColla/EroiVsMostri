USE [master]
GO
/****** Object:  Database [EroiVsMostri]    Script Date: 19/03/2021 15:49:59 ******/
CREATE DATABASE [EroiVsMostri]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EroiVsMostri', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EroiVsMostri.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EroiVsMostri_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EroiVsMostri_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EroiVsMostri] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EroiVsMostri].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EroiVsMostri] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EroiVsMostri] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EroiVsMostri] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EroiVsMostri] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EroiVsMostri] SET ARITHABORT OFF 
GO
ALTER DATABASE [EroiVsMostri] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EroiVsMostri] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EroiVsMostri] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EroiVsMostri] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EroiVsMostri] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EroiVsMostri] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EroiVsMostri] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EroiVsMostri] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EroiVsMostri] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EroiVsMostri] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EroiVsMostri] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EroiVsMostri] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EroiVsMostri] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EroiVsMostri] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EroiVsMostri] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EroiVsMostri] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EroiVsMostri] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EroiVsMostri] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EroiVsMostri] SET  MULTI_USER 
GO
ALTER DATABASE [EroiVsMostri] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EroiVsMostri] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EroiVsMostri] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EroiVsMostri] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EroiVsMostri] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EroiVsMostri] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EroiVsMostri] SET QUERY_STORE = OFF
GO
USE [EroiVsMostri]
GO
/****** Object:  Table [dbo].[Arma]    Script Date: 19/03/2021 15:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arma](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[PuntiDanno] [int] NULL,
	[ClasseID] [int] NOT NULL,
 CONSTRAINT [PK_Arma] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classe]    Script Date: 19/03/2021 15:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[IsEroe] [bit] NOT NULL,
 CONSTRAINT [PK_Classe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eroe]    Script Date: 19/03/2021 15:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eroe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[ClasseID] [int] NOT NULL,
	[ArmaID] [int] NOT NULL,
	[IsEroe] [bit] NOT NULL,
	[PuntiVita] [int] NOT NULL,
	[Livello] [int] NOT NULL,
	[PuntiAccumulati] [int] NOT NULL,
	[GiocatoreID] [int] NOT NULL,
	[TempoTotale] [int] NOT NULL,
 CONSTRAINT [PK_Eroe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Giocatore]    Script Date: 19/03/2021 15:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giocatore](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Ruolo] [bit] NOT NULL,
 CONSTRAINT [PK_Giocatore] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livello]    Script Date: 19/03/2021 15:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livello](
	[Livello] [int] NOT NULL,
	[PuntiVita] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Livello] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mostro]    Script Date: 19/03/2021 15:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mostro](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[ClasseID] [int] NOT NULL,
	[ArmaID] [int] NOT NULL,
	[IsEroe] [bit] NOT NULL,
	[PuntiVita] [int] NOT NULL,
	[Livello] [int] NOT NULL,
 CONSTRAINT [PK_Mostro] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PassaggioLivello]    Script Date: 19/03/2021 15:49:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PassaggioLivello](
	[Livello] [int] NOT NULL,
	[PuntiAccumulati] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Livello] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arma] ON 

INSERT [dbo].[Arma] ([ID], [Nome], [PuntiDanno], [ClasseID]) VALUES (1, N'Spada', 5, 2)
INSERT [dbo].[Arma] ([ID], [Nome], [PuntiDanno], [ClasseID]) VALUES (2, N'Arco', 3, 2)
INSERT [dbo].[Arma] ([ID], [Nome], [PuntiDanno], [ClasseID]) VALUES (3, N'Magia del Fuoco', 5, 1)
INSERT [dbo].[Arma] ([ID], [Nome], [PuntiDanno], [ClasseID]) VALUES (4, N'Magia del Ghiaccio', 4, 1)
INSERT [dbo].[Arma] ([ID], [Nome], [PuntiDanno], [ClasseID]) VALUES (5, N'Ascia', 2, 3)
INSERT [dbo].[Arma] ([ID], [Nome], [PuntiDanno], [ClasseID]) VALUES (6, N'Bastone', 1, 3)
INSERT [dbo].[Arma] ([ID], [Nome], [PuntiDanno], [ClasseID]) VALUES (7, N'Magia del Fuoco', 5, 4)
INSERT [dbo].[Arma] ([ID], [Nome], [PuntiDanno], [ClasseID]) VALUES (8, N'Mazza Chiodata', 4, 5)
INSERT [dbo].[Arma] ([ID], [Nome], [PuntiDanno], [ClasseID]) VALUES (9, N'Sfera Magica', 8, 6)
INSERT [dbo].[Arma] ([ID], [Nome], [PuntiDanno], [ClasseID]) VALUES (10, N'pugnale', 2, 7)
SET IDENTITY_INSERT [dbo].[Arma] OFF
GO
SET IDENTITY_INSERT [dbo].[Classe] ON 

INSERT [dbo].[Classe] ([ID], [Nome], [IsEroe]) VALUES (1, N'Mago', 1)
INSERT [dbo].[Classe] ([ID], [Nome], [IsEroe]) VALUES (2, N'Guerriero', 1)
INSERT [dbo].[Classe] ([ID], [Nome], [IsEroe]) VALUES (3, N'Troll', 0)
INSERT [dbo].[Classe] ([ID], [Nome], [IsEroe]) VALUES (4, N'Demone', 0)
INSERT [dbo].[Classe] ([ID], [Nome], [IsEroe]) VALUES (5, N'Orco', 0)
INSERT [dbo].[Classe] ([ID], [Nome], [IsEroe]) VALUES (6, N'Signore del Male', 0)
INSERT [dbo].[Classe] ([ID], [Nome], [IsEroe]) VALUES (7, N'Cultista', 0)
SET IDENTITY_INSERT [dbo].[Classe] OFF
GO
SET IDENTITY_INSERT [dbo].[Eroe] ON 

INSERT [dbo].[Eroe] ([ID], [Nome], [ClasseID], [ArmaID], [IsEroe], [PuntiVita], [Livello], [PuntiAccumulati], [GiocatoreID], [TempoTotale]) VALUES (16, N'Vittorioso', 1, 3, 1, 100, 5, 190, 9, 0)
INSERT [dbo].[Eroe] ([ID], [Nome], [ClasseID], [ArmaID], [IsEroe], [PuntiVita], [Livello], [PuntiAccumulati], [GiocatoreID], [TempoTotale]) VALUES (18, N'Paladino', 2, 1, 1, 20, 1, 0, 1, 0)
INSERT [dbo].[Eroe] ([ID], [Nome], [ClasseID], [ArmaID], [IsEroe], [PuntiVita], [Livello], [PuntiAccumulati], [GiocatoreID], [TempoTotale]) VALUES (19, N'Steve', 2, 2, 1, 14, 1, 10, 1, 17829)
INSERT [dbo].[Eroe] ([ID], [Nome], [ClasseID], [ArmaID], [IsEroe], [PuntiVita], [Livello], [PuntiAccumulati], [GiocatoreID], [TempoTotale]) VALUES (23, N'Merlino', 1, 1, 1, 20, 1, 0, 1, 0)
SET IDENTITY_INSERT [dbo].[Eroe] OFF
GO
SET IDENTITY_INSERT [dbo].[Giocatore] ON 

INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (1, N'Mery', 0)
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (8, N'MariaChiara', 0)
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (9, N'Admin', 1)
SET IDENTITY_INSERT [dbo].[Giocatore] OFF
GO
INSERT [dbo].[Livello] ([Livello], [PuntiVita]) VALUES (1, 20)
INSERT [dbo].[Livello] ([Livello], [PuntiVita]) VALUES (2, 40)
INSERT [dbo].[Livello] ([Livello], [PuntiVita]) VALUES (3, 60)
INSERT [dbo].[Livello] ([Livello], [PuntiVita]) VALUES (4, 80)
INSERT [dbo].[Livello] ([Livello], [PuntiVita]) VALUES (5, 100)
GO
SET IDENTITY_INSERT [dbo].[Mostro] ON 

INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [ArmaID], [IsEroe], [PuntiVita], [Livello]) VALUES (1, N'Sbob', 3, 6, 0, 20, 1)
INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [ArmaID], [IsEroe], [PuntiVita], [Livello]) VALUES (2, N'Iras', 4, 7, 0, 60, 3)
INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [ArmaID], [IsEroe], [PuntiVita], [Livello]) VALUES (3, N'Orcrucs', 5, 8, 0, 20, 1)
INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [ArmaID], [IsEroe], [PuntiVita], [Livello]) VALUES (5, N'Ade', 6, 9, 0, 100, 5)
INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [ArmaID], [IsEroe], [PuntiVita], [Livello]) VALUES (6, N'Storm', 6, 9, 0, 80, 4)
INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [ArmaID], [IsEroe], [PuntiVita], [Livello]) VALUES (7, N'Cosmo', 4, 7, 0, 80, 4)
SET IDENTITY_INSERT [dbo].[Mostro] OFF
GO
INSERT [dbo].[PassaggioLivello] ([Livello], [PuntiAccumulati]) VALUES (1, 0)
INSERT [dbo].[PassaggioLivello] ([Livello], [PuntiAccumulati]) VALUES (2, 30)
INSERT [dbo].[PassaggioLivello] ([Livello], [PuntiAccumulati]) VALUES (3, 60)
INSERT [dbo].[PassaggioLivello] ([Livello], [PuntiAccumulati]) VALUES (4, 90)
INSERT [dbo].[PassaggioLivello] ([Livello], [PuntiAccumulati]) VALUES (5, 120)
GO
/****** Object:  Index [UQ__Arma__3214EC2698709562]    Script Date: 19/03/2021 15:49:59 ******/
ALTER TABLE [dbo].[Arma] ADD UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Classe__3214EC2696B4511C]    Script Date: 19/03/2021 15:49:59 ******/
ALTER TABLE [dbo].[Classe] ADD UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Eroe__3214EC26C2C83934]    Script Date: 19/03/2021 15:49:59 ******/
ALTER TABLE [dbo].[Eroe] ADD UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Eroe__7D8FE3B2EC3050ED]    Script Date: 19/03/2021 15:49:59 ******/
ALTER TABLE [dbo].[Eroe] ADD UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Giocator__3214EC266F9D07E0]    Script Date: 19/03/2021 15:49:59 ******/
ALTER TABLE [dbo].[Giocatore] ADD UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Giocator__7D8FE3B2F06E4D44]    Script Date: 19/03/2021 15:49:59 ******/
ALTER TABLE [dbo].[Giocatore] ADD UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Mostro__3214EC265B2793C3]    Script Date: 19/03/2021 15:49:59 ******/
ALTER TABLE [dbo].[Mostro] ADD UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Mostro__7D8FE3B236D93FD0]    Script Date: 19/03/2021 15:49:59 ******/
ALTER TABLE [dbo].[Mostro] ADD UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Arma]  WITH CHECK ADD FOREIGN KEY([ClasseID])
REFERENCES [dbo].[Classe] ([ID])
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD FOREIGN KEY([ArmaID])
REFERENCES [dbo].[Arma] ([ID])
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD FOREIGN KEY([ClasseID])
REFERENCES [dbo].[Classe] ([ID])
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD FOREIGN KEY([GiocatoreID])
REFERENCES [dbo].[Giocatore] ([ID])
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD FOREIGN KEY([ArmaID])
REFERENCES [dbo].[Arma] ([ID])
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD FOREIGN KEY([ClasseID])
REFERENCES [dbo].[Classe] ([ID])
GO
USE [master]
GO
ALTER DATABASE [EroiVsMostri] SET  READ_WRITE 
GO
