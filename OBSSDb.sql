USE [OnlineBooksStoreSystem]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 2/13/2020 4:49:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](50) NULL,
	[BookTitle] [nvarchar](50) NULL,
	[Author] [nvarchar](50) NULL,
	[PublishDate] [date] NULL,
	[PublishingHouse] [nvarchar](50) NULL,
	[QuantityInStore] [int] NULL,
	[CoverImagePath] [nvarchar](250) NULL,
	[Description] [nvarchar](50) NULL,
	[Price] [int] NULL,
	[CategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 2/13/2020 4:49:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 2/13/2020 4:49:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[GenderId] [int] IDENTITY(1,1) NOT NULL,
	[GenderDesc] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rates]    Script Date: 2/13/2020 4:49:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rates](
	[BookId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Rate] [int] NULL,
 CONSTRAINT [PK_Rate] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/13/2020 4:49:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[PhoneNumber] [int] NULL,
	[BirthDate] [date] NULL,
	[GenderId] [int] NULL,
	[UserType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 2/13/2020 4:49:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeDesc] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [Subject], [BookTitle], [Author], [PublishDate], [PublishingHouse], [QuantityInStore], [CoverImagePath], [Description], [Price], [CategoryId]) VALUES (1, N'programming', N'key of java', N'jhon', CAST(N'1999-02-16' AS Date), N'sares', 10, N'~/Images/BooksImage/b1.jpg', N'rtynbvbnvbn', 23, 2)
INSERT [dbo].[Books] ([BookId], [Subject], [BookTitle], [Author], [PublishDate], [PublishingHouse], [QuantityInStore], [CoverImagePath], [Description], [Price], [CategoryId]) VALUES (2, N'artificial inteligance', N'key of ai', N'rami', CAST(N'2007-10-09' AS Date), N'sares2', 44, N'~/Images/BooksImage/b2.jpg', N'tysdfnbmb', 65, 4)
INSERT [dbo].[Books] ([BookId], [Subject], [BookTitle], [Author], [PublishDate], [PublishingHouse], [QuantityInStore], [CoverImagePath], [Description], [Price], [CategoryId]) VALUES (3, N'quality assurance', N'key of qa', N'fathi', CAST(N'2002-10-08' AS Date), N'sares3', 2, N'~/Images/BooksImage/b3.jpg', N'sdfertervccvbcjkl', 76, 1)
INSERT [dbo].[Books] ([BookId], [Subject], [BookTitle], [Author], [PublishDate], [PublishingHouse], [QuantityInStore], [CoverImagePath], [Description], [Price], [CategoryId]) VALUES (4, N'physics', N'key of physics', N'felex', CAST(N'2013-11-29' AS Date), N'sares4', 6, N'~/Images/BooksImage/b4.jpg', N'ryvcbcvb', 71, 4)
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([Category_Id], [CategoryName]) VALUES (1, N'qa')
INSERT [dbo].[categories] ([Category_Id], [CategoryName]) VALUES (2, N'codeing')
INSERT [dbo].[categories] ([Category_Id], [CategoryName]) VALUES (3, N'math')
INSERT [dbo].[categories] ([Category_Id], [CategoryName]) VALUES (4, N'Sciences')
SET IDENTITY_INSERT [dbo].[categories] OFF
SET IDENTITY_INSERT [dbo].[Genders] ON 

INSERT [dbo].[Genders] ([GenderId], [GenderDesc]) VALUES (1, N'Male')
INSERT [dbo].[Genders] ([GenderId], [GenderDesc]) VALUES (2, N'Female')
SET IDENTITY_INSERT [dbo].[Genders] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Password], [Email], [PhoneNumber], [BirthDate], [GenderId], [UserType]) VALUES (1, N'malek', N'shaltouf', N'malek2020', N'123', N'm@m.com', 785435372, CAST(N'2005-02-03' AS Date), 1, 1)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Password], [Email], [PhoneNumber], [BirthDate], [GenderId], [UserType]) VALUES (2, N'yaser', N'othman', N'yaser2020', N'123', N'y@y.com', 797592537, CAST(N'1997-06-16' AS Date), 1, 2)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [UserName], [Password], [Email], [PhoneNumber], [BirthDate], [GenderId], [UserType]) VALUES (3, N'roza', N'ahmad', N'roza2020', N'123', N'r@r.com', 775487721, CAST(N'1996-05-19' AS Date), 1, 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[UserTypes] ON 

INSERT [dbo].[UserTypes] ([TypeId], [TypeDesc]) VALUES (1, N'admin')
INSERT [dbo].[UserTypes] ([TypeId], [TypeDesc]) VALUES (2, N'user')
SET IDENTITY_INSERT [dbo].[UserTypes] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__UserType__62DA9947A93562F6]    Script Date: 2/13/2020 4:49:12 PM ******/
ALTER TABLE [dbo].[UserTypes] ADD UNIQUE NONCLUSTERED 
(
	[TypeDesc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[categories] ([Category_Id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([GenderId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([UserType])
REFERENCES [dbo].[UserTypes] ([TypeId])
GO
