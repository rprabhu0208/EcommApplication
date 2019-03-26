USE [master]
GO
/****** Object:  Database [ECommApplication]    Script Date: 03/26/2019 22:50:35 ******/
CREATE DATABASE [ECommApplication] ON  PRIMARY 
( NAME = N'ECommApplication', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ECommApplication.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ECommApplication_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ECommApplication_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ECommApplication] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ECommApplication].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ECommApplication] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ECommApplication] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ECommApplication] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ECommApplication] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ECommApplication] SET ARITHABORT OFF
GO
ALTER DATABASE [ECommApplication] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ECommApplication] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ECommApplication] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ECommApplication] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ECommApplication] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ECommApplication] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ECommApplication] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ECommApplication] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ECommApplication] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ECommApplication] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ECommApplication] SET  DISABLE_BROKER
GO
ALTER DATABASE [ECommApplication] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ECommApplication] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ECommApplication] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ECommApplication] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ECommApplication] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ECommApplication] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ECommApplication] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ECommApplication] SET  READ_WRITE
GO
ALTER DATABASE [ECommApplication] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ECommApplication] SET  MULTI_USER
GO
ALTER DATABASE [ECommApplication] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ECommApplication] SET DB_CHAINING OFF
GO
USE [ECommApplication]
GO
/****** Object:  Table [dbo].[SubCategoryMaster]    Script Date: 03/26/2019 22:50:37 ******/
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
INSERT [dbo].[SubCategoryMaster] ([SubCategoryID], [CategoryID], [SubCategoryName], [IsActive]) VALUES (4, 3, N'Long', 0)
SET IDENTITY_INSERT [dbo].[SubCategoryMaster] OFF
/****** Object:  Table [dbo].[CategoryMaster]    Script Date: 03/26/2019 22:50:37 ******/
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
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName], [IsActive]) VALUES (3, N'Shorts', 0)
SET IDENTITY_INSERT [dbo].[CategoryMaster] OFF
/****** Object:  Table [dbo].[AdminMaster]    Script Date: 03/26/2019 22:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminMaster](
	[AdminUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[eMail] [nvarchar](50) NULL,
	[UserPassword] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AdminMaster] ON
INSERT [dbo].[AdminMaster] ([AdminUserID], [UserName], [eMail], [UserPassword]) VALUES (1, N'Admin', N'admin123@gmail.com', N'admin')
SET IDENTITY_INSERT [dbo].[AdminMaster] OFF
/****** Object:  Table [dbo].[ProductImage]    Script Date: 03/26/2019 22:50:37 ******/
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
SET IDENTITY_INSERT [dbo].[ProductImage] ON
INSERT [dbo].[ProductImage] ([ProductImageID], [ProductID], [ImagePath], [Caption], [IsActive], [Priority], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, 1, N'/TempFiles/ShirtImage3.jpg', N'TEst', 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[ProductImage] ([ProductImageID], [ProductID], [ImagePath], [Caption], [IsActive], [Priority], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, 1, N'/TempFiles/ShirtImage2updated.jpg', N'TEst', 0, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProductImage] OFF
/****** Object:  Table [dbo].[Product]    Script Date: 03/26/2019 22:50:37 ******/
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
INSERT [dbo].[Product] ([ProductID], [SubCategoryID], [ProductName], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ProductDescription], [ProductSize], [ProductWeight], [Thumbnail], [SupplierID], [BasePrice], [ShippingCharges], [GST], [ServiceTax], [FinalPrice], [DisplayAtHomePage]) VALUES (2, 1, N'Puma', 0, NULL, NULL, NULL, NULL, N'Puma', N'L', N'100grm', NULL, NULL, CAST(1000.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), 5, 0, CAST(1100.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Product] ([ProductID], [SubCategoryID], [ProductName], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ProductDescription], [ProductSize], [ProductWeight], [Thumbnail], [SupplierID], [BasePrice], [ShippingCharges], [GST], [ServiceTax], [FinalPrice], [DisplayAtHomePage]) VALUES (3, 2, N'TEst 1', 1, NULL, NULL, NULL, NULL, N'Test', N'L', N'120grm', NULL, NULL, CAST(100.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), 5, 4, CAST(1100.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([ProductID], [SubCategoryID], [ProductName], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ProductDescription], [ProductSize], [ProductWeight], [Thumbnail], [SupplierID], [BasePrice], [ShippingCharges], [GST], [ServiceTax], [FinalPrice], [DisplayAtHomePage]) VALUES (4, 1, N'Test 2603', 1, NULL, NULL, NULL, NULL, N'Test 2603', N'L', N'120grm', NULL, NULL, CAST(100.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, 1, CAST(105.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  StoredProcedure [dbo].[INSERT_ProductImages]    Script Date: 03/26/2019 22:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ROHAN
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[INSERT_ProductImages] 
	-- Add the parameters for the stored procedure here
	 @ProductID int, 
	 @xmlProducts XML = null
AS
BEGIN
	 SET NOCOUNT ON;

  IF ((@xmlProducts IS NOT NULL)
    AND (@xmlProducts.exist('//ArrayOfProductImage') <> 0))
  BEGIN
    IF OBJECT_ID('tempdb..#tTemp1') IS NOT NULL
      DROP TABLE #tTemp1;
	   
	  
    CREATE TABLE #tTemp1 (
		ImageID int,
      IsActive		bit,
      [Priority]		bit,
      Caption           VARCHAR(100),
      ProductImagePath             VARCHAR(100),
        ProductID       int,
    ) 
    INSERT INTO #tTemp1
   
   SELECT 
   
		prd.value('(ImageID)[1]', 'int'),
        prd.value('(IsActive)[1]', 'bit'),
        prd.value('(Priority)[1]', 'int'),
        prd.value('(Caption)[1]', 'nvarchar(100)'), 
         prd.value('(productImagePath)[1]', 'nvarchar(100)'),
         @ProductID
        FROM @xmlProducts.nodes('//ArrayOfProductImage//ProductImage') AS xmlProducts (prd)
	;
		


	 -- SELECT * FROM #tTemp1    
	  
	  begin
		merge ProductImage as p
		using #tTemp1 as t
		on (p.ProductImageID = t.ImageID and p.ProductID = t.ProductID)
		when not matched by target 
		then insert (Caption,IsActive, [Priority], ImagePath,ProductID) 
		values (t.Caption,t.IsActive, t.[Priority], t.ProductImagePath,ProductID) 
		when matched 
		then update set 
		p.Caption = t.Caption ,
		p.IsActive = t.IsActive, 
		p.[Priority]= t.[Priority], 
		p.ImagePath = t.ProductImagePath,
		p.ProductID  = t.ProductID
		WHEN NOT MATCHED  BY SOURCE THEN 
		DELETE   ;
		
		-- AND EXISTS(SELECT 1 FROM dbo.Vals iVals WHERE target.LeftId = iVals.LeftId) THEN
	  end
	       
    IF OBJECT_ID('tempdb..#tTemp1') IS NOT NULL
      DROP TABLE #tTemp1;
	  --select * from ProductImage
  END

END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertUpdateCategory]    Script Date: 03/26/2019 22:50:51 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GetSubCategory]    Script Date: 03/26/2019 22:50:51 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GetProducts]    Script Date: 03/26/2019 22:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- select * from subcategory
--[SP_GetProducts] 1
CREATE PROCEDURE [dbo].[SP_GetProducts]
( 
	@ProductID	INT =null
) 
AS
BEGIN 
		SELECT   
		ProductID
		,CM.CategoryID
		,CM.CategoryName
,SC.SubCategoryID
,SC.SubCategoryName
,ProductName
,P.IsActive
,CreatedBy
,CreatedDate
,ModifiedBy
,ModifiedDate
,ProductDescription
,ProductSize
,ProductWeight
,Thumbnail
,SupplierID
,BasePrice
,ShippingCharges
,GST
,ServiceTax
,FinalPrice
,DisplayAtHomePage

		FROM 
			dbo.Product P with (nolock) 
			INNER JOIN dbo.SubCategoryMaster SC with (nolock) 
			ON SC.SubCategoryID = p.SubCategoryID
			INNER JOIN dbo.CategoryMaster CM with (nolock) 
			ON SC.CategoryID = CM.CategoryID
		WHERE
		  (@ProductID IS NULL OR	P.ProductID= @ProductID) 
		  
		 IF @ProductID IS NOT NULL 
		 BEGIN
		SELECT * FROM  dbo.ProductImage  WHERE
			   ProductID = @ProductID  
		END
			
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCategory]    Script Date: 03/26/2019 22:50:51 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeleteCategory]    Script Date: 03/26/2019 22:50:51 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ValidateAdmin]    Script Date: 03/26/2019 22:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [SP_GetCategory] 1,1,0,null,BOOKS  
CREATE PROCEDURE [dbo].[SP_ValidateAdmin]  
(  
    
 @username varchar(50)   
 ,@password varchar(50)  
)  
----------------------------------------------------------------------  
-- Author:  Rohan
-- Create date: <03/23/2019>  
-- Description: <Get Category Details>  
-----------------------------------------------------------------------  
AS  
BEGIN     
  SELECT   
    AdminUserID,
UserName,
eMail 
  FROM dbo.[AdminMaster] with (nolock)  
  WHERE   
    ( UserName = @username and [UserPassword] = @password)  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertUpdateSubCategory]    Script Date: 03/26/2019 22:50:51 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_InsertUpdateProduct]    Script Date: 03/26/2019 22:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_InsertUpdateProduct] 
 
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
	,@xmlProducts xml = null
AS
BEGIN
DECLARE @intErrorCode	INT
			,@intProducId	INT
	SET NOCOUNT ON; 
	BEGIN TRAN Product
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
		
		 SELECT @intProducId = @ProductID 
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
			
		SELECT @intProducId = @@IDENTITY
		
		 EXEC INSERT_ProductImages @intProducId
                                                ,@xmlProducts
                                               
	END
	
	SELECT @intErrorCode = @@ERROR
		IF (@intErrorCode <> 0) GOTO PROBLEM
		COMMIT TRAN
		PROBLEM:
		IF (@intErrorCode <> 0) 
		BEGIN
				PRINT 'Unexpected error occurred!'
		ROLLBACK TRAN
		END	
		
		return @intProducId 
		--IF(@intProducId >0)
		--BEGIN
		--		return @intProducId  
		--END
		--ELSE
		--BEGIN
		--		return @intProducId 
		--END
	
	
END
GO
