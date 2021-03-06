USE [ECommApplication]
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 03/25/2019 02:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ProductImageID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[ImagePath] [nvarchar](100) NULL,
	[Caption] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[Priority] [int] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductImageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 03/25/2019 02:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryID] [int] NULL,
	[ProductName] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ProductDescription] [nvarchar](2000) NULL,
	[ProductSize] [nvarchar](50) NULL,
	[ProductWeight] [nvarchar](20) NULL,
	[Thumbnail] [nvarchar](300) NULL,
	[SupplierID] [int] NULL,
	[BasePrice] [decimal](18, 2) NULL,
	[ShippingCharges] [decimal](18, 2) NULL,
	[GST] [int] NULL,
	[ServiceTax] [int] NULL,
	[FinalPrice] [decimal](18, 2) NULL,
	[DisplayAtHomePage] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT [dbo].[Product] ([ProductID], [SubCategoryID], [ProductName], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ProductDescription], [ProductSize], [ProductWeight], [Thumbnail], [SupplierID], [BasePrice], [ShippingCharges], [GST], [ServiceTax], [FinalPrice], [DisplayAtHomePage]) VALUES (1, 1, N'Addidas', 1, NULL, NULL, NULL, NULL, N'addidas', N'L', N'100grm', NULL, NULL, CAST(1000.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), 5, 0, CAST(1100.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  Table [dbo].[CategoryMaster]    Script Date: 03/25/2019 02:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryMaster](
	[CategoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoryMaster] ON
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName], [IsActive]) VALUES (1, N'Shirt', 0)
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName], [IsActive]) VALUES (2, N'Tshirt', 0)
SET IDENTITY_INSERT [dbo].[CategoryMaster] OFF
/****** Object:  Table [dbo].[SubCategoryMaster]    Script Date: 03/25/2019 02:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategoryMaster](
	[SubCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[SubCategoryName] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SubCategoryMaster] ON
INSERT [dbo].[SubCategoryMaster] ([SubCategoryID], [CategoryID], [SubCategoryName], [IsActive]) VALUES (1, 1, N'Full Sleeves', 0)
INSERT [dbo].[SubCategoryMaster] ([SubCategoryID], [CategoryID], [SubCategoryName], [IsActive]) VALUES (2, 1, N'Half Sleeves', 0)
INSERT [dbo].[SubCategoryMaster] ([SubCategoryID], [CategoryID], [SubCategoryName], [IsActive]) VALUES (3, 2, N'Full Sleeves', 0)
SET IDENTITY_INSERT [dbo].[SubCategoryMaster] OFF
/****** Object:  StoredProcedure [dbo].[SP_InsertUpdateSubCategory]    Script Date: 03/25/2019 02:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertUpdateSubCategory] 

     @CategoryID INT
	,@SubCategoryID INT
	,@SubCategoryName NVARCHAR(100)  
	,@IsActive BIT 
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS (
			SELECT *
			FROM SubCategoryMaster with (nolock)
			WHERE SubCategoryID = @SubCategoryID
			)
	BEGIN 
		UPDATE [dbo].[SubCategoryMaster]
		SET CategoryID = @CategoryID
			,SubCategoryName = @SubCategoryName 
			,IsActive = @IsActive
		WHERE SubCategoryID = @SubCategoryID 
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[SubCategoryMaster] (
			[CategoryID]
			,[SubCategoryName]  
			,[IsActive]
			)
		VALUES (
			@CategoryID
			,@SubCategoryName  
			,@IsActive
			)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertUpdateProduct]    Script Date: 03/25/2019 02:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertUpdateProduct] 
 
	@SubCategoryID INT
	,@ProductID int
	,@ProductName NVARCHAR(100)  
	,@IsActive BIT 
	,@DisplayAtHomePage bit
	,@ProductDescription nvarchar(500)
	,@ProductSize nvarchar(50)
	,@ProductWeight nvarchar(50)
	,@BasePrice decimal(18,2)
	,@GST decimal(18,2)
	,@ShippingCharges decimal(18,2)
	,@ServiceTax decimal(18,2)
	,@FinalPrice decimal (18,2)
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS (
			SELECT *
			FROM Product with (nolock)
			WHERE ProductID = @ProductID
			)
	BEGIN 
		UPDATE [dbo].Product
		SET
		SubCategoryID= @SubCategoryID 
		 ,ProductName =@ProductName 
		,IsActive = @IsActive
		,ProductDescription =@ProductDescription
		,ProductSize = @ProductSize
		,ProductWeight = @ProductWeight
		,BasePrice =@BasePrice
		,ShippingCharges = @ShippingCharges
		,GST =@GST
		,ServiceTax =@ServiceTax
		,FinalPrice =@FinalPrice
		,DisplayAtHomePage =@DisplayAtHomePage
		WHERE ProductID = @ProductID 
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].Product (
			 SubCategoryID
			 ,ProductName 
		,IsActive 
		,ProductDescription 
		,ProductSize 
		,ProductWeight 
		,BasePrice 
		,ShippingCharges 
		,GST 
		,ServiceTax 
		,FinalPrice 
		,DisplayAtHomePage 
			)
		VALUES (
		@SubCategoryID
			 ,@ProductName 
		,@IsActive 
		,@ProductDescription 
		,@ProductSize 
		,@ProductWeight 
		,@BasePrice 
		,@ShippingCharges 
		,@GST 
		,@ServiceTax 
		,@FinalPrice 
		,@DisplayAtHomePage 
			)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertUpdateCategory]    Script Date: 03/25/2019 02:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertUpdateCategory] 
@CategoryID bigint,
@CategoryName  nvarchar(200),
@IsActive Bit

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	if Exists(select CategoryID from CategoryMaster where CategoryID=@CategoryID or CategoryName=@CategoryName)
	Begin
	print 'update' 
		Update [dbo].[CategoryMaster] set CategoryName=@CategoryName,
		IsActive=@IsActive 
		where CategoryID=@CategoryID 	

	end
	else
	Begin	
	print 'insert'		
		INSERT INTO [dbo].[CategoryMaster]([CategoryName],[IsActive])
		values
        (@CategoryName,@IsActive)
	End
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetSubCategory]    Script Date: 03/25/2019 02:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- select * from subcategory
--[SP_GetSubCategory] null,3
CREATE PROCEDURE [dbo].[SP_GetSubCategory]
(

	@SubCategoryId	INT =null,
	@CategoryId	INT =null, 
	@IsActive bit=null,
	@SubCategoryName Nvarchar(50)=null,
	@CategoryName Nvarchar(50)=null
) 
AS
BEGIN
		
		SELECT  
			s.SubCategoryID 
			, s.SubCategoryName  
			,C.CategoryID 
			,C.CategoryName
				 

			,s.IsActive 

		FROM

			dbo.SubCategoryMaster S with (nolock) INNER JOIN dbo.CategoryMaster C with (nolock) 
			ON S.CategoryID=C.CategoryID 
		WHERE
			(@SubCategoryId IS NULL OR @SubCategoryId=0 OR S.SubCategoryID = @SubCategoryId)
			AND (@CategoryId IS NULL OR	S.CategoryID = @CategoryId) and
			 (@SubCategoryName IS NULL OR S.SubCategoryName like '%'+ @SubCategoryName+'%')
			AND  (@CategoryName IS NULL OR	C.CategoryName like '%'+ @CategoryName+'%')
			AND (@IsActive is null or s.IsActive=@IsActive)

			
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCategory]    Script Date: 03/25/2019 02:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [SP_GetCategory] 1,1,0,null,BOOKS  
CREATE PROCEDURE [dbo].[SP_GetCategory]  
(  
    
 @CategoryID INT = NULL  
 ,@IsActive Bit = null  
 ,@CategoryName nvarchar(50)=null  
)  
----------------------------------------------------------------------  
-- Author:  Rohan
-- Create date: <03/23/2019>  
-- Description: <Get Category Details>  
-----------------------------------------------------------------------  
AS  
BEGIN     
  SELECT   
    CategoryID   
    ,CategoryName  
       
   ,IsActive  
  FROM dbo.CategoryMaster with (nolock)  
  WHERE  
  (@IsActive is null or IsActive =  @IsActive)  
  AND  (@CategoryID IS NULL OR @CategoryID = 0 OR CategoryID=@CategoryID)  
  AND  (@CategoryName IS NULL OR CategoryName like '%'+@CategoryName+'%')  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCategory]    Script Date: 03/25/2019 02:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteCategory] 
@CategoryID int 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	if Exists(select CategoryID from CategoryMaster where CategoryID=@CategoryID)
	Begin
	 Delete from [CategoryMaster]  where CategoryID=@CategoryID

	end
END
GO
