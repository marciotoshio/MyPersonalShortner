/****** Object:  Table [dbo].[EdmMetadata]    Script Date: 04/07/2011 15:43:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EdmMetadata](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelHash] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[LongUrls]    Script Date: 04/07/2011 15:46:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LongUrls](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[CustomUrls]    Script Date: 04/09/2011 04:15:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomUrls](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](128) NOT NULL,
	[CustomPart] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into [dbo].[LongUrls]([Url]) values('https://github.com/marciotoshio/MyPersonalShortner')
insert into [dbo].[CustomUrls]([Url], [CustomPart]) values('https://github.com/marciotoshio', 'github')

/*** RESET DATA ***/
-- DELETE FROM LongUrls WHERE Id > 1
-- DBCC CHECKIDENT('LongUrls', RESEED, 1)
-- DELETE FROM CustomUrls WHERE Id > 1
-- DBCC CHECKIDENT('CustomUrls', RESEED, 1)