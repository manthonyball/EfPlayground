USE [fn-test]
GO

/****** Object:  Table [dbo].[HubAgent]    Script Date: 12/29/2024 1:49:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HubAgent](
	[Code] [uniqueidentifier] NOT NULL,
	[Active] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HubAgent] ADD  DEFAULT (newid()) FOR [Code]
GO


