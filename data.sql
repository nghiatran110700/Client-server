USE [master]
GO
/****** Object:  Database [Client_server]    Script Date: 2/17/2022 3:44:32 PM ******/
CREATE DATABASE [Client_server]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Client_server', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Client_server.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Client_server_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Client_server_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Client_server] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Client_server].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Client_server] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Client_server] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Client_server] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Client_server] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Client_server] SET ARITHABORT OFF 
GO
ALTER DATABASE [Client_server] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Client_server] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Client_server] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Client_server] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Client_server] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Client_server] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Client_server] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Client_server] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Client_server] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Client_server] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Client_server] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Client_server] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Client_server] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Client_server] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Client_server] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Client_server] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Client_server] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Client_server] SET RECOVERY FULL 
GO
ALTER DATABASE [Client_server] SET  MULTI_USER 
GO
ALTER DATABASE [Client_server] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Client_server] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Client_server] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Client_server] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Client_server] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Client_server] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Client_server', N'ON'
GO
ALTER DATABASE [Client_server] SET QUERY_STORE = OFF
GO
USE [Client_server]
GO
/****** Object:  Table [dbo].[account]    Script Date: 2/17/2022 3:44:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[idAccount] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[NameCustomer] [nvarchar](100) NULL,
	[idRole] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bill]    Script Date: 2/17/2022 3:44:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bill](
	[idBill] [int] IDENTITY(1,1) NOT NULL,
	[idCustomer] [int] NULL,
	[billDate] [date] NULL,
	[phone] [nvarchar](10) NULL,
	[statusBill] [nvarchar](100) NULL,
	[addressCustomer] [nvarchar](100) NULL,
	[idDiscount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idBill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[brand]    Script Date: 2/17/2022 3:44:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[brand](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NameBrand] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 2/17/2022 3:44:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[idCategory] [int] IDENTITY(1,1) NOT NULL,
	[NameCate] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detailBill]    Script Date: 2/17/2022 3:44:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detailBill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NULL,
	[idProduct] [int] NULL,
	[amount] [int] NULL,
	[size] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[discout]    Script Date: 2/17/2022 3:44:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[discout](
	[idDiscount] [int] IDENTITY(1,1) NOT NULL,
	[NameDiscout] [nvarchar](100) NULL,
	[percents] [int] NULL,
	[StartDay] [date] NULL,
	[EndDay] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDiscount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 2/17/2022 3:44:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[idProduct] [int] IDENTITY(1,1) NOT NULL,
	[NameProduct] [nvarchar](100) NULL,
	[Price] [int] NULL,
	[img] [nvarchar](100) NULL,
	[descriptions] [nvarchar](max) NULL,
	[idBrand] [int] NULL,
	[idCate] [int] NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[slide]    Script Date: 2/17/2022 3:44:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[slide](
	[idSlide] [int] IDENTITY(1,1) NOT NULL,
	[Content_slide] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idSlide] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[brand] ON 

INSERT [dbo].[brand] ([id], [NameBrand]) VALUES (1, N'Nike')
INSERT [dbo].[brand] ([id], [NameBrand]) VALUES (2, N'Adidas')
INSERT [dbo].[brand] ([id], [NameBrand]) VALUES (3, N'Converse')
INSERT [dbo].[brand] ([id], [NameBrand]) VALUES (4, N'McQueen')
INSERT [dbo].[brand] ([id], [NameBrand]) VALUES (5, N'Locate')
INSERT [dbo].[brand] ([id], [NameBrand]) VALUES (6, N'Gucci')
SET IDENTITY_INSERT [dbo].[brand] OFF
GO
SET IDENTITY_INSERT [dbo].[category] ON 

INSERT [dbo].[category] ([idCategory], [NameCate]) VALUES (1, N'Giày Thể Thao Nam')
INSERT [dbo].[category] ([idCategory], [NameCate]) VALUES (2, N'Giày Thể Thao Nữ')
INSERT [dbo].[category] ([idCategory], [NameCate]) VALUES (3, N'Giày Da Nam')
INSERT [dbo].[category] ([idCategory], [NameCate]) VALUES (4, N'Giày Da nữ')
INSERT [dbo].[category] ([idCategory], [NameCate]) VALUES (5, N'Giày Đôi')
SET IDENTITY_INSERT [dbo].[category] OFF
GO
SET IDENTITY_INSERT [dbo].[product] ON 

INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (1, N'Adidas Alphabounce Instinct M Đen Viền Xám', 20, N'img2.jpg', N'giày nhập khẩu', 2, 1, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (2, N'Adidas 118 SF', 25, N'img1.jpg', N'Giày ngoại', 2, 1, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (3, N'Giày Thể Thao XSPORT Yeezy Boost', 23, N'img3.jpg', N'Giày ngoại', 2, 1, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (4, N'Adidas Super Star', 30, N'img4.jpg', N'Giày ngoại', 2, 2, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (5, N'Adidas Ultraboot 2.0', 18, N'img5.jpg', N'Giày ngoại', 2, 1, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (6, N'NIKE SB DUNK LOW ORANGE PEARL', 32, N'img6.jpg', N'Giày ngoại', 1, 2, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (7, N'NIKE SB DUNK LOW ORANGE GREEN', 34, N'img7.jpg', N'Giày ngoại', 1, 5, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (8, N'NIKE SB DUNK LOW X DIOR GREY SAIL', 35, N'img8.jpg', N'Giày ngoại', 1, 5, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (9, N'NIKE SB DUNK LOW ''TRAVIS SCOTT''', 33, N'img9.jpg', N'Giày ngoại', 1, 1, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (10, N'NIKE AIR JORDAN 1 MID ''DIGITAL PINK''', 37, N'img11.jpg', N'Giày ngoại', 1, 2, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (11, N'NIKE KWONDO1 X PEACEMINUSONE', 30, N'img12.jpg', N'Giày ngoại', 1, 2, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (12, N'VANS FEAR OF GOD', 18, N'img13.jpg', N'Giày ngoại', 3, 5, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (13, N'VANS CHECKERBOARD SLIP-ON', 29, N'img14.jpg', N'Giày ngoại', 3, 2, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (14, N'XVESSEL G.O.P SLIP ON BLACK WHITE', 22, N'img15.jpg', N'Giày ngoại', 3, 2, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (15, N'CONVERSE CHUCK 1970 ĐEN CỔ CAO', 25, N'img16.jpg', N'Giày ngoại', 3, 2, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (16, N'CONVERSE CHUCK 1970 CHINATOWN MARKET UV ĐỔI MÀU', 34, N'img18.jpg', N'Giày ngoại', 3, 5, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (17, N'GUCCI BEE ', 45, N'img17.jpg', N'Giày ngoại', 6, 5, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (18, N'GIÀY GUCCI RHYTON NEW YORK YANKEES', 42, N'img10.jpg', N'Giày ngoại', 6, 2, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (19, N'GIÀY GUCCI RHYTON MOUTH-PRINT', 37, N'img20.jpg', N'Giày ngoại', 6, 2, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (20, N'GIÀY GUCCI RHYTON', 46, N'img19.jpg', N'Giày ngoại', 6, 5, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (21, N'MCQUEEN TRẮNG GÓT ĐEN ''NHUNG''', 36, N'img21.jpg', N'Giày ngoại', 4, 5, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (22, N'MCQUEEN HỒNG TRẮNG', 38, N'img22.jpg', N'Giày ngoại', 4, 1, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (23, N'MCQUEEN PHẢN QUANG', 40, N'img23.jpg', N'Giày ngoại', 4, 5, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (24, N'Giày da nam màu nâu GNTA10062-N', 57, N'img24.jpg', N'Giày ngoại', 5, 3, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (25, N'Giày nam Chelsea Boot da bò trơn ', 52, N'img25.jpg', N'Giày ngoại', 5, 3, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (26, N'Giày nam đế cao 7cm mũi thuyền', 57, N'img26.jpg', N'Giày ngoại', 5, 3, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (27, N'Giày da nam dáng Derby', 54, N'img27.jpg', N'Giày ngoại', 5, 3, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (28, N'Giày tây nam da bò họa tiết', 58, N'img28.jpg', N'Giày ngoại', 5, 3, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (29, N'Giày tây nam buộc dây kiểu dáng Oxford ', 54, N'img29.jpg', N'Giày ngoại', 5, 3, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (30, N'Giày da nam kiểu dáng Apron Toe', 53, N'img30.jpg', N'Giày ngoại', 5, 3, 0)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (31, N'Giày da nam mũi nhọn', 50, N'img32.jpg', N'Giày ngoại', 5, 3, 0)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (32, N'Giày nữ thời trang cao cấp ELLY – EG22', 42, N'img33.jpg', N'Giày ngoại', 5, 4, 0)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (33, N'Giày nữ cao cấp ELLY – EGM87

', 47, N'img34.jpg', N'Giày ngoại', 5, 4, 0)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (34, N'Giày nữ cao cấp ELLY – EGM86

', 39, N'img35.jpg', N'Giày ngoại', 5, 4, 0)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (35, N'Giày nữ thời trang cao cấp ELLY – EG51

', 38, N'img36.jpg', N'Giày ngoại', 5, 4, 0)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (36, N'Giày nữ cao cấp ELLY – EGM93

', 45, N'img37.jpg', N'Giày ngoại', 5, 4, 0)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (46, N'giày thể thao', 2, N'img12.jpg', N'123', 1, 1, 1)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (47, N'giày thể thao', 15, N'img12.jpg', N'nó có rất nhiều tính năng nổi bật như là babbabababa', 1, 1, NULL)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (48, NULL, NULL, NULL, NULL, 1, 1, NULL)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (49, NULL, NULL, NULL, NULL, 1, 1, NULL)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (50, N'giày thể thao', 3, N'img13.jpg', N'ok', 1, 1, NULL)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (51, N'giày thể thao', 3, N'img13.jpg', N'ok', 1, 1, NULL)
INSERT [dbo].[product] ([idProduct], [NameProduct], [Price], [img], [descriptions], [idBrand], [idCate], [status]) VALUES (52, N'giày thể thao', 3, N'img1.jpg', N'ok', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[product] OFF
GO
ALTER TABLE [dbo].[bill]  WITH CHECK ADD  CONSTRAINT [FK_bill_account] FOREIGN KEY([idDiscount])
REFERENCES [dbo].[account] ([idAccount])
GO
ALTER TABLE [dbo].[bill] CHECK CONSTRAINT [FK_bill_account]
GO
ALTER TABLE [dbo].[bill]  WITH CHECK ADD  CONSTRAINT [FK_bill_discout] FOREIGN KEY([idDiscount])
REFERENCES [dbo].[discout] ([idDiscount])
GO
ALTER TABLE [dbo].[bill] CHECK CONSTRAINT [FK_bill_discout]
GO
ALTER TABLE [dbo].[detailBill]  WITH CHECK ADD  CONSTRAINT [FK_detailBill_bill] FOREIGN KEY([idBill])
REFERENCES [dbo].[bill] ([idBill])
GO
ALTER TABLE [dbo].[detailBill] CHECK CONSTRAINT [FK_detailBill_bill]
GO
ALTER TABLE [dbo].[detailBill]  WITH CHECK ADD  CONSTRAINT [FK_detailBill_product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[product] ([idProduct])
GO
ALTER TABLE [dbo].[detailBill] CHECK CONSTRAINT [FK_detailBill_product]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_brand] FOREIGN KEY([idBrand])
REFERENCES [dbo].[brand] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_brand]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_category] FOREIGN KEY([idCate])
REFERENCES [dbo].[category] ([idCategory])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_category]
GO
USE [master]
GO
ALTER DATABASE [Client_server] SET  READ_WRITE 
GO
