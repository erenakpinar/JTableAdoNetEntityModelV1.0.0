USE [JTable]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 27.5.2015 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 27.5.2015 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (1, N'Sesli')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (2, N'Sessiz')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (1, N'a', 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (2, N'b', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (3, N'c', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (4, N'ç', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (5, N'd', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (6, N'e', 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (7, N'f', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (8, N'g', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (9, N'ğ', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (10, N'h', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (11, N'ı', 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (12, N'i', 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (13, N'j', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (14, N'k', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (15, N'l', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (16, N'm', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (17, N'n', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (18, N'o', 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (19, N'ö', 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (20, N'p', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (21, N'r', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (22, N's', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (23, N'ş', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (24, N't', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (25, N'u', 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (26, N'ü', 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (27, N'v', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (28, N'y', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId]) VALUES (29, N'z', 2)
SET IDENTITY_INSERT [dbo].[Products] OFF
