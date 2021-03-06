USE [hebbraco]
GO
/****** Object:  Table [dbo].[BusinessUnit]    Script Date: 05/11/2015 20:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessUnit](
	[businessUnitId] [int] IDENTITY(1,1) NOT NULL,
	[businessUnitCode] [nchar](10) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[officeAddress1] [nvarchar](max) NOT NULL,
	[officeAdresss2] [nvarchar](max) NOT NULL,
	[officeAddress3] [nvarchar](max) NOT NULL,
	[officePostCode] [nchar](10) NOT NULL,
	[officeContact] [nvarchar](max) NOT NULL,
	[officePhone] [nvarchar](50) NOT NULL,
	[officeEmail] [nvarchar](50) NOT NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_BusinessUnit] PRIMARY KEY CLUSTERED 
(
	[businessUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staff]    Script Date: 05/11/2015 20:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[staffId] [int] IDENTITY(1,1) NOT NULL,
	[businessUnitId] [int] NOT NULL,
	[staffCode] [nvarchar](50) NOT NULL,
	[firstName] [nvarchar](max) NOT NULL,
	[middleName] [nvarchar](max) NOT NULL,
	[lastName] [nvarchar](max) NOT NULL,
	[dob] [date] NOT NULL,
	[startDate] [date] NOT NULL,
	[profile] [nvarchar](max) NULL,
	[emailAddress] [nvarchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[staffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_BusinessUnit] FOREIGN KEY([businessUnitId])
REFERENCES [dbo].[BusinessUnit] ([businessUnitId])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_BusinessUnit]
GO
