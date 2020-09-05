USE [FSChalenge]
GO
/****** Object:  Table [dbo].[ORDERS]    Script Date: 5/9/2020 19:20:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDERS](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[OrderDescription] [nvarchar](255) NOT NULL,
	[CreatedOn] [datetime] NULL,
	[AuthDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDERS_ITEMS]    Script Date: 5/9/2020 19:20:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDERS_ITEMS](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ItemDescription] [nvarchar](255) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [numeric](32, 2) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vORDERS_INFO]    Script Date: 5/9/2020 19:20:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vORDERS_INFO] AS
SELECT o.OrderId, o.Status, o.OrderDescription, o.CreatedOn, o.AuthDate ,
	(SELECT sum(oi.Quantity * oi.UnitPrice) from ORDERS_ITEMS oi where oi.OrderId = o.OrderId) as Total,
	(SELECT sum(oi.Quantity) from ORDERS_ITEMS oi where oi.OrderId = o.OrderId) as QItems
FROM ORDERS o;
GO
ALTER TABLE [dbo].[ORDERS] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ORDERS_ITEMS]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[ORDERS] ([OrderId])
GO
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD  CONSTRAINT [CHK_Status] CHECK  (([Status]=(-1) OR [Status]=(1) OR [Status]=(0)))
GO
ALTER TABLE [dbo].[ORDERS] CHECK CONSTRAINT [CHK_Status]
GO
