USE [fn-test]
GO

/****** Object:  Table [dbo].[MortgageAgent]    Script Date: 12/29/2024 1:49:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MortgageAgent](
	[HubAgent] [uniqueidentifier] NULL,
	[DirectAgent] [uniqueidentifier] NULL,
	[Active] [int] NULL,
	[Number] [int] NOT NULL,
	[RecordedDate] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MortgageAgent] ADD  DEFAULT (round(rand()*(1000),(0))+(1000000)) FOR [Number]
GO

ALTER TABLE [dbo].[MortgageAgent] ADD  DEFAULT (getdate()) FOR [RecordedDate]
GO


