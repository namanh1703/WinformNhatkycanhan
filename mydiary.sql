
USE [MyDiary]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 14/12/2022 8:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Sex] [bit] NULL,
	[FullName] [nvarchar](50) NULL,
	[Dob] [date] NULL,
	[Email] [varchar](50) NULL,
	[Status] [nvarchar](500) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiaryDetail]    Script Date: 14/12/2022 8:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiaryDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Description] [ntext] NULL,
	[DateCreate] [date] NULL,
	[CreateBy] [int] NULL,
	[Favourite] [bit] NULL,
 CONSTRAINT [PK_DiaryDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Username], [Password], [Sex], [FullName], [Dob], [Email], [Status]) VALUES (1, N'admin', N'123', 1, N'Đàm Huy Nam Anh', CAST(N'2001-03-17' AS Date), N'abc@gmail.com', N'tâm trạng thoải mái')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[DiaryDetail] ON 

INSERT [dbo].[DiaryDetail] ([ID], [Title], [Description], [DateCreate], [CreateBy], [Favourite]) VALUES (2, N'Nhat ki ngay 11-12', N'Day la nhat ki ngày 11/12', CAST(N'2022-12-11' AS Date), 1, 0)
INSERT [dbo].[DiaryDetail] ([ID], [Title], [Description], [DateCreate], [CreateBy], [Favourite]) VALUES (4, N'Nhat ki ngày 15/12/2000', N'Hôm nay là ngày 15-12 thật là vui vẻ hiuhiu :0', CAST(N'2022-12-15' AS Date), 1, 1)
INSERT [dbo].[DiaryDetail] ([ID], [Title], [Description], [DateCreate], [CreateBy], [Favourite]) VALUES (6, N'Nhật kí ngày 20-12', N'hôm nay  là 1 ngày thật là vui :) do tôi viết', CAST(N'2022-12-20' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[DiaryDetail] OFF
GO
ALTER TABLE [dbo].[DiaryDetail]  WITH CHECK ADD  CONSTRAINT [FK_DiaryDetail_Account] FOREIGN KEY([CreateBy])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[DiaryDetail] CHECK CONSTRAINT [FK_DiaryDetail_Account]
GO
