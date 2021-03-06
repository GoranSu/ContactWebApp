USE [ContactsDB]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 25/08/2017 17:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[City] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NULL,
	[MobilePhone] [nvarchar](100) NULL,
	[WorkPhone] [nvarchar](100) NULL,
	[HomePhone] [nvarchar](100) NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
