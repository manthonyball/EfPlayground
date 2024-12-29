USE [fn-test]
GO

/****** Object:  Table [dbo].[DirectAgent]    Script Date: 12/29/2024 1:48:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DirectAgent](
	[Code] [uniqueidentifier] NOT NULL,
	[Active] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DirectAgent] ADD  DEFAULT (newid()) FOR [Code]
GO


