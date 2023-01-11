USE [master]
GO
/****** Object:  Database [RiskManagementScratch]    Script Date: 2023-01-12 오전 12:28:30 ******/
CREATE DATABASE [RiskManagementScratch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RiskManagementScratch', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\RiskManagementScratch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RiskManagementScratch_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\RiskManagementScratch_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RiskManagementScratch] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RiskManagementScratch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RiskManagementScratch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET ARITHABORT OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RiskManagementScratch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RiskManagementScratch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RiskManagementScratch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RiskManagementScratch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET RECOVERY FULL 
GO
ALTER DATABASE [RiskManagementScratch] SET  MULTI_USER 
GO
ALTER DATABASE [RiskManagementScratch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RiskManagementScratch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RiskManagementScratch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RiskManagementScratch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RiskManagementScratch] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RiskManagementScratch', N'ON'
GO
ALTER DATABASE [RiskManagementScratch] SET QUERY_STORE = OFF
GO
USE [RiskManagementScratch]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2023-01-12 오전 12:28:32 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AksiKuncis]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AksiKuncis](
	[Id_Aksi_Kunci] [int] IDENTITY(1,1) NOT NULL,
	[Nama_Aksi_Kunci] [nvarchar](max) NOT NULL,
	[Id_Aksi_Utama] [int] NOT NULL,
 CONSTRAINT [PK_AksiKuncis] PRIMARY KEY CLUSTERED 
(
	[Id_Aksi_Kunci] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AksiUtamas]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AksiUtamas](
	[Id_Aksi_Utama] [int] IDENTITY(1,1) NOT NULL,
	[Nama_Aksi_Utama] [nvarchar](max) NOT NULL,
	[Id_Strategi_Kunci] [int] NOT NULL,
 CONSTRAINT [PK_AksiUtamas] PRIMARY KEY CLUSTERED 
(
	[Id_Aksi_Utama] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aktors]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aktors](
	[id_aktor] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role] [varchar](50) NOT NULL,
	[id_divisi] [int] NULL,
 CONSTRAINT [PK_Aktor] PRIMARY KEY CLUSTERED 
(
	[id_aktor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DampakRisikos]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DampakRisikos](
	[Id_Dampak_Risiko] [int] IDENTITY(1,1) NOT NULL,
	[Nama_Dampak_Risiko] [nvarchar](max) NOT NULL,
	[Nilai_Dampak_Risiko] [real] NOT NULL,
 CONSTRAINT [PK_DampakRisikos] PRIMARY KEY CLUSTERED 
(
	[Id_Dampak_Risiko] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailPenyebabRisikos]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailPenyebabRisikos](
	[Id_Risk_Regist] [uniqueidentifier] NOT NULL,
	[Id_Kategori_Detail_Risiko] [int] NOT NULL,
	[Deskripsi] [text] NOT NULL,
	[Probabilitas] [int] NOT NULL,
	[Control] [text] NOT NULL,
	[Id_Divisi] [int] NOT NULL,
 CONSTRAINT [PK_DetailPenyebabRisikos] PRIMARY KEY CLUSTERED 
(
	[Id_Risk_Regist] ASC,
	[Id_Kategori_Detail_Risiko] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Divisis]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Divisis](
	[Id_Divisi] [int] IDENTITY(1,1) NOT NULL,
	[Nama_Divisi] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Divisis] PRIMARY KEY CLUSTERED 
(
	[Id_Divisi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FrekuensiRisikos]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FrekuensiRisikos](
	[Id_Frekuensi_Risiko] [int] IDENTITY(1,1) NOT NULL,
	[Nama_Frekuensi_Risiko] [nvarchar](max) NOT NULL,
	[Nilai_Frekuensi_Risiko] [real] NOT NULL,
 CONSTRAINT [PK_FrekuensiRisikos] PRIMARY KEY CLUSTERED 
(
	[Id_Frekuensi_Risiko] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KategoriDetailRisikos]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KategoriDetailRisikos](
	[Id_Kategori_Detail_Risiko] [int] IDENTITY(1,1) NOT NULL,
	[Nama_Kategori_Detail_Risiko] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_KategoriDetailRisikos] PRIMARY KEY CLUSTERED 
(
	[Id_Kategori_Detail_Risiko] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KategoriRisikos]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KategoriRisikos](
	[Id_Kategori_Risiko] [int] IDENTITY(1,1) NOT NULL,
	[Nama_Kategori_Risiko] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_KategoriRisikos] PRIMARY KEY CLUSTERED 
(
	[Id_Kategori_Risiko] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistrasiRisikos]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrasiRisikos](
	[Id_Risk_Regist] [uniqueidentifier] NOT NULL,
	[Kode_Risk_Regist] [varchar](200) NULL,
	[Id_Divisi] [int] NOT NULL,
	[Id_Aktor] [int] NOT NULL,
	[Id_Aksi_Kunci] [int] NOT NULL,
	[Dampak_Risiko] [text] NOT NULL,
	[Id_Kategori_Risiko] [int] NOT NULL,
	[Id_Dampak_Risiko_Awal] [int] NOT NULL,
	[Id_Frekuensi_Risiko_Awal] [int] NOT NULL,
	[Rata_Rata_Risiko_Awal] [float] NOT NULL,
	[Id_Dampak_Sisa_Risiko] [int] NOT NULL,
	[Id_Frekuensi_Sisa_Risiko] [int] NOT NULL,
	[Rata_Rata_Sisa_Risiko] [float] NOT NULL,
	[Rencana_Pemeliharaan] [text] NULL,
	[Id_Dampak_Harapan_Risiko] [int] NOT NULL,
	[Id_Frekuensi_Harapan_Risiko] [int] NOT NULL,
	[Rata_Rata_Harapan_Risiko] [float] NOT NULL,
	[Tanggal_Pembuatan] [date] NOT NULL,
 CONSTRAINT [PK_RegistrasiRisikos_1] PRIMARY KEY CLUSTERED 
(
	[Id_Risk_Regist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StrategiKuncis]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StrategiKuncis](
	[Id_Strategi_Kunci] [int] IDENTITY(1,1) NOT NULL,
	[Nama_Strategi_Kunci] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StrategiKuncis] PRIMARY KEY CLUSTERED 
(
	[Id_Strategi_Kunci] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_AksiKuncis_Id_Aksi_Utama]    Script Date: 2023-01-12 오전 12:28:32 ******/
CREATE NONCLUSTERED INDEX [IX_AksiKuncis_Id_Aksi_Utama] ON [dbo].[AksiKuncis]
(
	[Id_Aksi_Utama] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AksiUtamas_Id_Strategi_Kunci]    Script Date: 2023-01-12 오전 12:28:32 ******/
CREATE NONCLUSTERED INDEX [IX_AksiUtamas_Id_Strategi_Kunci] ON [dbo].[AksiUtamas]
(
	[Id_Strategi_Kunci] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AksiKuncis]  WITH CHECK ADD  CONSTRAINT [FK_AksiKuncis_AksiUtamas_Id_Aksi_Utama] FOREIGN KEY([Id_Aksi_Utama])
REFERENCES [dbo].[AksiUtamas] ([Id_Aksi_Utama])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AksiKuncis] CHECK CONSTRAINT [FK_AksiKuncis_AksiUtamas_Id_Aksi_Utama]
GO
ALTER TABLE [dbo].[AksiUtamas]  WITH CHECK ADD  CONSTRAINT [FK_AksiUtamas_StrategiKuncis_Id_Strategi_Kunci] FOREIGN KEY([Id_Strategi_Kunci])
REFERENCES [dbo].[StrategiKuncis] ([Id_Strategi_Kunci])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AksiUtamas] CHECK CONSTRAINT [FK_AksiUtamas_StrategiKuncis_Id_Strategi_Kunci]
GO
ALTER TABLE [dbo].[DetailPenyebabRisikos]  WITH CHECK ADD  CONSTRAINT [FK_DetailPenyebabRisikos_Divisis] FOREIGN KEY([Id_Divisi])
REFERENCES [dbo].[Divisis] ([Id_Divisi])
GO
ALTER TABLE [dbo].[DetailPenyebabRisikos] CHECK CONSTRAINT [FK_DetailPenyebabRisikos_Divisis]
GO
ALTER TABLE [dbo].[DetailPenyebabRisikos]  WITH CHECK ADD  CONSTRAINT [FK_DetailPenyebabRisikos_KategoriDetailRisikos] FOREIGN KEY([Id_Kategori_Detail_Risiko])
REFERENCES [dbo].[KategoriDetailRisikos] ([Id_Kategori_Detail_Risiko])
GO
ALTER TABLE [dbo].[DetailPenyebabRisikos] CHECK CONSTRAINT [FK_DetailPenyebabRisikos_KategoriDetailRisikos]
GO
ALTER TABLE [dbo].[DetailPenyebabRisikos]  WITH CHECK ADD  CONSTRAINT [FK_DetailPenyebabRisikos_RegistrasiRisikos] FOREIGN KEY([Id_Risk_Regist])
REFERENCES [dbo].[RegistrasiRisikos] ([Id_Risk_Regist])
GO
ALTER TABLE [dbo].[DetailPenyebabRisikos] CHECK CONSTRAINT [FK_DetailPenyebabRisikos_RegistrasiRisikos]
GO
ALTER TABLE [dbo].[RegistrasiRisikos]  WITH CHECK ADD  CONSTRAINT [FK_RegistrasiRisikos_AksiKuncis] FOREIGN KEY([Id_Aksi_Kunci])
REFERENCES [dbo].[AksiKuncis] ([Id_Aksi_Kunci])
GO
ALTER TABLE [dbo].[RegistrasiRisikos] CHECK CONSTRAINT [FK_RegistrasiRisikos_AksiKuncis]
GO
ALTER TABLE [dbo].[RegistrasiRisikos]  WITH CHECK ADD  CONSTRAINT [FK_RegistrasiRisikos_Aktors] FOREIGN KEY([Id_Aktor])
REFERENCES [dbo].[Aktors] ([id_aktor])
GO
ALTER TABLE [dbo].[RegistrasiRisikos] CHECK CONSTRAINT [FK_RegistrasiRisikos_Aktors]
GO
ALTER TABLE [dbo].[RegistrasiRisikos]  WITH CHECK ADD  CONSTRAINT [FK_RegistrasiRisikos_DampakRisikos] FOREIGN KEY([Id_Dampak_Harapan_Risiko])
REFERENCES [dbo].[DampakRisikos] ([Id_Dampak_Risiko])
GO
ALTER TABLE [dbo].[RegistrasiRisikos] CHECK CONSTRAINT [FK_RegistrasiRisikos_DampakRisikos]
GO
ALTER TABLE [dbo].[RegistrasiRisikos]  WITH CHECK ADD  CONSTRAINT [FK_RegistrasiRisikos_DampakRisikos1] FOREIGN KEY([Id_Dampak_Risiko_Awal])
REFERENCES [dbo].[DampakRisikos] ([Id_Dampak_Risiko])
GO
ALTER TABLE [dbo].[RegistrasiRisikos] CHECK CONSTRAINT [FK_RegistrasiRisikos_DampakRisikos1]
GO
ALTER TABLE [dbo].[RegistrasiRisikos]  WITH CHECK ADD  CONSTRAINT [FK_RegistrasiRisikos_DampakRisikos2] FOREIGN KEY([Id_Dampak_Sisa_Risiko])
REFERENCES [dbo].[DampakRisikos] ([Id_Dampak_Risiko])
GO
ALTER TABLE [dbo].[RegistrasiRisikos] CHECK CONSTRAINT [FK_RegistrasiRisikos_DampakRisikos2]
GO
ALTER TABLE [dbo].[RegistrasiRisikos]  WITH CHECK ADD  CONSTRAINT [FK_RegistrasiRisikos_Divisis] FOREIGN KEY([Id_Divisi])
REFERENCES [dbo].[Divisis] ([Id_Divisi])
GO
ALTER TABLE [dbo].[RegistrasiRisikos] CHECK CONSTRAINT [FK_RegistrasiRisikos_Divisis]
GO
ALTER TABLE [dbo].[RegistrasiRisikos]  WITH CHECK ADD  CONSTRAINT [FK_RegistrasiRisikos_FrekuensiRisikos] FOREIGN KEY([Id_Frekuensi_Harapan_Risiko])
REFERENCES [dbo].[FrekuensiRisikos] ([Id_Frekuensi_Risiko])
GO
ALTER TABLE [dbo].[RegistrasiRisikos] CHECK CONSTRAINT [FK_RegistrasiRisikos_FrekuensiRisikos]
GO
ALTER TABLE [dbo].[RegistrasiRisikos]  WITH CHECK ADD  CONSTRAINT [FK_RegistrasiRisikos_FrekuensiRisikos1] FOREIGN KEY([Id_Frekuensi_Risiko_Awal])
REFERENCES [dbo].[FrekuensiRisikos] ([Id_Frekuensi_Risiko])
GO
ALTER TABLE [dbo].[RegistrasiRisikos] CHECK CONSTRAINT [FK_RegistrasiRisikos_FrekuensiRisikos1]
GO
ALTER TABLE [dbo].[RegistrasiRisikos]  WITH CHECK ADD  CONSTRAINT [FK_RegistrasiRisikos_FrekuensiRisikos2] FOREIGN KEY([Id_Frekuensi_Sisa_Risiko])
REFERENCES [dbo].[FrekuensiRisikos] ([Id_Frekuensi_Risiko])
GO
ALTER TABLE [dbo].[RegistrasiRisikos] CHECK CONSTRAINT [FK_RegistrasiRisikos_FrekuensiRisikos2]
GO
ALTER TABLE [dbo].[RegistrasiRisikos]  WITH CHECK ADD  CONSTRAINT [FK_RegistrasiRisikos_KategoriRisikos] FOREIGN KEY([Id_Kategori_Risiko])
REFERENCES [dbo].[KategoriRisikos] ([Id_Kategori_Risiko])
GO
ALTER TABLE [dbo].[RegistrasiRisikos] CHECK CONSTRAINT [FK_RegistrasiRisikos_KategoriRisikos]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddDetailPenyebabRisiko]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_AddDetailPenyebabRisiko]
	@idRisk						uniqueidentifier,
	@idDivisi					int,
	@idKategoriDetailRisiko		int,
	@deskripsi					text,
	@probabilitas				int,
	@control					text
AS
BEGIN
	INSERT INTO 
		DetailPenyebabRisikos
		(Id_Risk_Regist, Id_Kategori_Detail_Risiko, Deskripsi, Probabilitas, [Control], Id_Divisi)
	VALUES
		(@idRisk, @idKategoriDetailRisiko, @deskripsi, @probabilitas, @control, @idDivisi)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AddRegistrasiRisiko]    Script Date: 2023-01-12 오전 12:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_AddRegistrasiRisiko]
	@idRisk						uniqueidentifier,
	@idDivisi					int,
	@idAktor					int,
	@idAksiKunci				int,
	@dampakRisiko				text,
	@idKategoriRisiko			int,
	@idDampakRisikoAwal			int,
	@idFrekuensiRisikoAwal		int,
	@rataRataRisikoAwal			float,
	@idDampakSisaRisiko			int,
	@idFrekuensiSisaRisiko		int,
	@rataRataSisaRisiko			float,
	@rencanaPemeliharaan		text,
	@idDampakHarapanRisiko		int,
	@idFrekuensiHarapanRisiko	int,
	@rataRataHarapanRisiko		float,
	@tanggalPembuatan			date
AS
BEGIN
	INSERT INTO 
		RegistrasiRisikos
		(Id_Risk_Regist, Id_Divisi, Id_Aktor, Id_Aksi_Kunci, Dampak_Risiko, Id_Kategori_Risiko, Id_Dampak_Risiko_Awal, Id_Frekuensi_Risiko_Awal,
		 Rata_Rata_Risiko_Awal, Id_Dampak_Sisa_Risiko, Id_Frekuensi_Sisa_Risiko, Rata_Rata_Sisa_Risiko, Rencana_Pemeliharaan, Id_Dampak_Harapan_Risiko,
		 Id_Frekuensi_Harapan_Risiko, Rata_Rata_Harapan_Risiko, Tanggal_Pembuatan, Kode_Risk_Regist)
	VALUES
		(@idRisk, @idDivisi, @idAktor, @idAksiKunci, @dampakRisiko, @idKategoriRisiko, @idDampakRisikoAwal, @idFrekuensiRisikoAwal, @rataRataRisikoAwal,
		 @idDampakSisaRisiko, @idFrekuensiSisaRisiko, @rataRataSisaRisiko, @rencanaPemeliharaan, @idDampakHarapanRisiko, @idFrekuensiHarapanRisiko,
		 @rataRataHarapanRisiko, @tanggalPembuatan, CONVERT(VARCHAR(MAX), YEAR(GETDATE())) + '-' + CONVERT(VARCHAR(MAX), MONTH(GETDATE())) + '-' + CONVERT(VARCHAR(MAX), DAY(GETDATE())) + '-' + CONVERT(VARCHAR(MAX), @idDivisi) + '-' + CONVERT(VARCHAR(MAX), @idAktor))
END
GO
USE [master]
GO
ALTER DATABASE [RiskManagementScratch] SET  READ_WRITE 
GO
