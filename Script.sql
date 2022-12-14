USE [AngularDB]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 11/26/2022 21:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LOGIN_NAME] [varchar](50) NULL,
	[PASSWORD] [varchar](50) NULL,
	[MOBILE] [varchar](50) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Login] ON
INSERT [dbo].[Login] ([Id], [LOGIN_NAME], [PASSWORD], [MOBILE]) VALUES (1, N'admin', N'admin', N'9911335566')
SET IDENTITY_INSERT [dbo].[Login] OFF
/****** Object:  StoredProcedure [dbo].[GetLoginDetails]    Script Date: 11/26/2022 21:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLoginDetails]
	@loginName VARCHAR(50), 
	@password  VARCHAR(50)
AS
BEGIN
SELECT * FROM dbo.Login WHERE LOGIN_NAME=@loginName and PASSWORD=@password
END
GO
