USE [EyePosDB]
GO
/****** Object:  Table [dbo].[Authorizations]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authorizations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[AuthorizeTypeId] [int] NULL,
	[IsActive] [bit] NULL,
	[AuthorizedBy] [bigint] NULL,
	[AuthorizedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuthorizeType]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorizeType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](100) NULL,
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Balance]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Balance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourceTypeId] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BalanceSourceType]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BalanceSourceType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourceName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Brand]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[SmallImage] [nvarchar](100) NULL,
	[BigImage] [nvarchar](100) NULL,
	[CreateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentCategory] [nvarchar](15) NULL,
	[SubCategory] [nvarchar](15) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Branch] [nvarchar](20) NULL,
	[Description] [nvarchar](max) NULL,
	[Address] [nvarchar](250) NULL,
	[Telephone] [nvarchar](15) NULL,
	[Mobile] [nvarchar](20) NULL,
	[Fax] [nvarchar](20) NULL,
	[Website] [nvarchar](100) NULL,
	[SmallLogo] [nvarchar](100) NULL,
	[BigLogo] [nvarchar](100) NULL,
	[RegistrationNo] [nvarchar](20) NULL,
 CONSTRAINT [PK__Company__3214EC07BF66F468] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContactLensDetail]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactLensDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[Type] [nvarchar](50) NULL,
	[Color] [nvarchar](30) NULL,
	[Material] [nvarchar](30) NULL,
	[BC] [nvarchar](30) NULL,
	[Diameter] [nvarchar](30) NULL,
	[Features] [nvarchar](50) NULL,
 CONSTRAINT [PK__ProductC__3214EC0790618152] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContactLenseRX]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactLenseRX](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NULL,
	[RSPH] [nvarchar](10) NULL,
	[RCYL] [nvarchar](10) NULL,
	[RAXIS] [nvarchar](10) NULL,
	[RVA] [nvarchar](10) NULL,
	[RBC] [nvarchar](10) NULL,
	[RDIA] [nvarchar](10) NULL,
	[RADD] [nvarchar](10) NULL,
	[RIOP] [nvarchar](10) NULL,
	[RKeratometry] [nvarchar](10) NULL,
	[LSPH] [nvarchar](10) NULL,
	[LCYL] [nvarchar](10) NULL,
	[LAXIS] [nvarchar](10) NULL,
	[LVA] [nvarchar](10) NULL,
	[LBC] [nvarchar](10) NULL,
	[LDIA] [nvarchar](10) NULL,
	[LADD] [nvarchar](10) NULL,
	[LIOP] [nvarchar](10) NULL,
	[LKeratometry] [nvarchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[CheckedDate] [datetime] NULL,
	[CheckedBy] [bigint] NULL,
	[Note] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[ICNo] [nvarchar](20) NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[Telephone] [nvarchar](15) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[PostalCode] [int] NULL,
	[Address] [nvarchar](200) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Damage]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Damage](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DamageNo] [nvarchar](20) NULL,
	[ProductId] [bigint] NULL,
	[Quantity] [int] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[EntryDate] [datetime] NULL,
	[Note] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Designation]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[DesignationTypeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DesignationTypes]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DesignationTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](10) NULL,
	[DiscountRate] [decimal](18, 2) NULL,
	[Description] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FrameDetail]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FrameDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Type] [nvarchar](30) NULL,
	[ColorCode] [nvarchar](30) NULL,
	[Size] [nvarchar](30) NULL,
 CONSTRAINT [PK_FrameDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Health]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Health](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NULL,
	[ChiefComplain] [nvarchar](50) NULL,
	[CaseHistory] [nvarchar](50) NULL,
	[HealthMedication] [nvarchar](50) NULL,
	[ContactLenseWorn] [nvarchar](20) NULL,
	[PupilSize] [nvarchar](10) NULL,
	[RDim] [nvarchar](10) NULL,
	[LDim] [nvarchar](10) NULL,
	[RBright] [nvarchar](10) NULL,
	[LBright] [nvarchar](10) NULL,
	[HealthCondition] [nvarchar](10) NULL,
	[OralMedication] [nvarchar](10) NULL,
	[Eyelids] [nvarchar](10) NULL,
	[Lacrimation] [nvarchar](10) NULL,
	[Blink] [nvarchar](10) NULL,
	[EyeHealth] [nvarchar](10) NULL,
	[Aperture] [nvarchar](10) NULL,
	[HVID] [nvarchar](10) NULL,
	[ColorVision] [nvarchar](10) NULL,
	[RPalpAperture] [nvarchar](10) NULL,
	[LPalpAperture] [nvarchar](10) NULL,
	[RHVID] [nvarchar](10) NULL,
	[LHVID] [nvarchar](10) NULL,
	[REyeImagePath] [nvarchar](20) NULL,
	[LEyeImagePath] [nvarchar](20) NULL,
	[Remark] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HealthDocument]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthDocument](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NULL,
	[DocumentName] [nvarchar](20) NULL,
	[SavePath] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ManufacturerName] [nvarchar](200) NULL,
	[ContactInfo] [nvarchar](400) NULL,
	[SmallImage] [nvarchar](100) NULL,
	[BigImage] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NULL,
	[ProductId] [bigint] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[CollectionDate] [datetime] NULL,
	[VatId] [int] NULL,
	[VatRate] [decimal](18, 2) NULL,
	[VatAmount] [decimal](18, 2) NULL,
	[DiscountId] [int] NULL,
	[DiscountRate] [decimal](18, 2) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](20) NULL,
	[CustomerId] [bigint] NULL,
	[VatId] [int] NULL,
	[VatRate] [decimal](18, 2) NULL,
	[VatAmount] [decimal](18, 2) NULL,
	[DiscountId] [int] NULL,
	[DiscountRate] [decimal](18, 2) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[FinalTotal] [decimal](18, 2) NULL,
	[BillingAddress] [nvarchar](250) NULL,
	[OrderPlaceDate] [datetime] NULL,
	[CollectionDate] [datetime] NULL,
	[OrderStatus] [nvarchar](15) NULL,
	[Note] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[LogoPath] [nvarchar](20) NULL,
	[Description] [nvarchar](100) NULL,
	[Url] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonalDetail]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[Name] [nvarchar](100) NULL,
	[Gender] [nvarchar](10) NULL,
	[MobileNo] [nvarchar](30) NULL,
	[OtherPhone] [nvarchar](100) NULL,
	[DOB] [date] NULL,
	[Address] [nvarchar](200) NULL,
	[Language] [nvarchar](20) NULL,
	[MaritalStatus] [nvarchar](15) NULL,
 CONSTRAINT [PK__Personal__3214EC07BBEEA3FF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nvarchar](300) NULL,
	[Name] [nvarchar](100) NULL,
	[ProductTypeId] [int] NULL,
	[BrandId] [int] NULL,
	[ManufacturerId] [bigint] NULL,
	[Type] [nvarchar](50) NULL,
	[ColorCode] [nvarchar](30) NULL,
	[Size] [nvarchar](30) NULL,
	[BC] [nvarchar](30) NULL,
	[Diameter] [nvarchar](30) NULL,
	[Description] [nvarchar](max) NULL,
	[SmallImage] [nvarchar](100) NULL,
	[BigImage] [nvarchar](100) NULL,
	[CostPrice] [decimal](18, 2) NULL,
	[SellingPrice] [decimal](18, 2) NULL,
	[MetaTags] [nvarchar](150) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK__Products__3214EC0709B71212] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](100) NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseNo] [nvarchar](20) NULL,
	[SupplierId] [int] NULL,
	[ProductId] [bigint] NULL,
	[Quantity] [int] NULL,
	[EntryDate] [datetime] NOT NULL,
	[PurchaseDate] [datetime] NULL,
	[VatId] [int] NULL,
	[VatRate] [decimal](18, 2) NULL,
	[VatAmount] [decimal](18, 2) NULL,
	[PriceRate] [decimal](18, 2) NULL,
	[FinalTotal] [decimal](18, 2) NULL,
	[Note] [nvarchar](100) NULL,
 CONSTRAINT [PK__Purchase__3214EC0785FE94AC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseReturn]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseReturn](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseReturnNo] [nvarchar](20) NULL,
	[ProductId] [bigint] NULL,
	[Quantity] [int] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[EntryDate] [datetime] NULL,
	[Reason] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Refunds]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Refunds](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SalesReturnId] [bigint] NULL,
	[RefundNo] [nvarchar](20) NULL,
	[SalesReturnNo] [nvarchar](20) NULL,
	[RefundAmount] [decimal](18, 2) NULL,
	[RefundedDate] [datetime] NULL,
	[RefundedBy] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesReturn]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesReturn](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SalesReturnNo] [nvarchar](20) NULL,
	[OrderNo] [nvarchar](20) NULL,
	[ProductId] [bigint] NULL,
	[CustomerId] [bigint] NULL,
	[Quantity] [int] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[ReturnDate] [datetime] NULL,
	[Status] [nvarchar](15) NULL,
	[Reason] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesTransaction]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesTransaction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SaleTransactionNo] [nvarchar](20) NULL,
	[OrderId] [bigint] NULL,
	[CustomerId] [bigint] NULL,
	[PaymentMethodId] [int] NULL,
	[PaidAmount] [decimal](18, 2) NULL,
	[TransactionDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Scheduler]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scheduler](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NULL,
	[RecallDate] [datetime] NULL,
	[MsgContent] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SpectacleRX]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpectacleRX](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NULL,
	[RSph] [nvarchar](10) NULL,
	[RCyl] [nvarchar](10) NULL,
	[RAxis] [nvarchar](10) NULL,
	[RVa] [nvarchar](10) NULL,
	[RPd] [nvarchar](10) NULL,
	[RAdd] [nvarchar](10) NULL,
	[RPrism] [nvarchar](10) NULL,
	[LSph] [nvarchar](10) NULL,
	[LCyl] [nvarchar](10) NULL,
	[LAxis] [nvarchar](10) NULL,
	[LVa] [nvarchar](10) NULL,
	[LPd] [nvarchar](10) NULL,
	[LAdd] [nvarchar](10) NULL,
	[LPrism] [nvarchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[CheckedDate] [datetime] NULL,
	[CheckedBy] [bigint] NULL,
	[Note] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[AvailableQuantity] [int] NULL,
	[LastQuantity] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdate] [datetime] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockAdjustment]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockAdjustment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AdjustmentNo] [nvarchar](20) NULL,
	[ProductId] [bigint] NULL,
	[Quantity] [int] NULL,
	[Note] [nvarchar](100) NULL,
	[CreatedBy] [bigint] NULL,
	[EntryDate] [datetime] NULL,
 CONSTRAINT [PK_StockAdjustment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockReserved]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockReserved](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[CustomerId] [bigint] NULL,
	[ReservedQuantity] [int] NULL,
	[ReserveStatus] [nvarchar](15) NULL,
	[Note] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockTrace]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockTrace](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[CurrentQuantity] [int] NULL,
	[OpeningQuantity] [int] NULL,
	[ClosingQuantity] [int] NULL,
	[ReferenceId] [nvarchar](100) NULL,
	[TableReference] [nvarchar](30) NULL,
	[Note] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK__Stock__3214EC0753C75877] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SunglassDetail]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SunglassDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Gender] [nvarchar](20) NULL,
	[Type] [nvarchar](30) NULL,
	[FrameColor] [nvarchar](30) NULL,
	[LenseColor] [nvarchar](30) NULL,
	[Features] [nvarchar](200) NULL,
	[Size] [nvarchar](100) NULL,
	[Material] [nvarchar](30) NULL,
	[Style] [nvarchar](30) NULL,
	[FaceShap] [nvarchar](30) NULL,
 CONSTRAINT [PK__ProductG__3214EC079E352313] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](20) NULL,
	[SupplierName] [nvarchar](20) NULL,
	[Phone] [nvarchar](15) NULL,
	[Telephone] [nvarchar](15) NULL,
	[Fax] [nvarchar](15) NULL,
	[Email] [nvarchar](15) NULL,
	[Address] [nvarchar](150) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnitMeasurement]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitMeasurement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_UnitMeasurement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](200) NULL,
	[UserTypeId] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](100) NULL,
	[TempField] [nvarchar](50) NULL,
	[SmallImage] [nvarchar](100) NULL,
	[BigImage] [nvarchar](100) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK__Users__3214EC07D9707F2D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserType]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](30) NULL,
 CONSTRAINT [PK__UserType__3214EC0728DF2775] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vat]    Script Date: 6/26/2020 5:52:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](10) NULL,
	[VatRate] [decimal](18, 2) NULL,
	[Description] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [Name], [SmallImage], [BigImage], [CreateDate]) VALUES (1, N'None', N'StaticFiles/Brands/SmallImage/1.png', N'StaticFiles/Brands/BigImage/1.png', CAST(N'2020-02-02 00:00:00.000' AS DateTime))
INSERT [dbo].[Brand] ([Id], [Name], [SmallImage], [BigImage], [CreateDate]) VALUES (1003, N'AbdHsn Group', N'StaticFiles/Brands/SmallImage/1003.PNG', N'StaticFiles/Brands/BigImage/1003.PNG', CAST(N'2020-05-22 20:02:20.500' AS DateTime))
INSERT [dbo].[Brand] ([Id], [Name], [SmallImage], [BigImage], [CreateDate]) VALUES (1004, N'Jessy Optics', N'StaticFiles/Brands/SmallImage/1004.jpg', N'StaticFiles/Brands/BigImage/1004.jpg', CAST(N'2020-06-21 06:04:35.900' AS DateTime))
SET IDENTITY_INSERT [dbo].[Brand] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [ParentCategory], [SubCategory], [IsActive]) VALUES (1, N'Glass', NULL, 1)
INSERT [dbo].[Category] ([Id], [ParentCategory], [SubCategory], [IsActive]) VALUES (2, N'Contact Lense', NULL, 1)
INSERT [dbo].[Category] ([Id], [ParentCategory], [SubCategory], [IsActive]) VALUES (3, N'Glass', N'Sun Glass', 1)
INSERT [dbo].[Category] ([Id], [ParentCategory], [SubCategory], [IsActive]) VALUES (4, N'Glass', N'Eye Glass', 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([Id], [Name], [Branch], [Description], [Address], [Telephone], [Mobile], [Fax], [Website], [SmallLogo], [BigLogo], [RegistrationNo]) VALUES (7, N'XForce Company', N'Mirpur', N'sdfasd', N'sdfasd', N'+2342233', N'+23 3423422', N'24324', N'www.XforceComapny.com', N'StaticFiles/Company/SmallImage/7.bmp', N'StaticFiles/Company/BigImage/7.bmp', N'23443521243')
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[ContactLensDetail] ON 

INSERT [dbo].[ContactLensDetail] ([Id], [ProductId], [Type], [Color], [Material], [BC], [Diameter], [Features]) VALUES (1, NULL, N'8.00', N'Dark Blue', N'Crystal', N'1.1', N'1', NULL)
SET IDENTITY_INSERT [dbo].[ContactLensDetail] OFF
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 

INSERT [dbo].[Manufacturer] ([Id], [ManufacturerName], [ContactInfo], [SmallImage], [BigImage]) VALUES (1, N'None', N'sdkfas', NULL, NULL)
INSERT [dbo].[Manufacturer] ([Id], [ManufacturerName], [ContactInfo], [SmallImage], [BigImage]) VALUES (2, N'EyeCare', N'dfasd', NULL, NULL)
INSERT [dbo].[Manufacturer] ([Id], [ManufacturerName], [ContactInfo], [SmallImage], [BigImage]) VALUES (4, N'X-Devine', N'sdkfas', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
SET IDENTITY_INSERT [dbo].[PersonalDetail] ON 

INSERT [dbo].[PersonalDetail] ([Id], [UserId], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (1, 2, N'fagd', N'Common', N'33333333', N'44444444444', CAST(N'1900-01-01' AS Date), N'Mirput444444444', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (4, 7, N'Abdullah', N'Male', N'22113342', N'223322', CAST(N'1900-01-01' AS Date), N'Mirpur 4/13/Cha, West Vasantak Cantonment Dhaka', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (8, NULL, N'ad', N'Male', N'22343452', N'43534', CAST(N'1900-01-01' AS Date), N'Mirput', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (9, 18, N'jhjkh', N'Male', N'22234323', N'286876', CAST(N'2020-06-24' AS Date), N'jhgh', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (13, 29, N'Jerome', N'Male', N'22223423', N'234222', CAST(N'2020-06-16' AS Date), N'Lorem ipsum dolor sit ', NULL, NULL)
SET IDENTITY_INSERT [dbo].[PersonalDetail] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductCode], [Name], [ProductTypeId], [BrandId], [ManufacturerId], [Type], [ColorCode], [Size], [BC], [Diameter], [Description], [SmallImage], [BigImage], [CostPrice], [SellingPrice], [MetaTags], [IsActive], [CreatedDate], [UpdateDate]) VALUES (40007, N'FR-10001', NULL, 1, 1004, 2, N'Bigger', N'Black and Water', N'10 cm', NULL, NULL, NULL, NULL, NULL, CAST(200.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), NULL, 1, CAST(N'2020-06-24 10:22:33.267' AS DateTime), NULL)
INSERT [dbo].[Products] ([Id], [ProductCode], [Name], [ProductTypeId], [BrandId], [ManufacturerId], [Type], [ColorCode], [Size], [BC], [Diameter], [Description], [SmallImage], [BigImage], [CostPrice], [SellingPrice], [MetaTags], [IsActive], [CreatedDate], [UpdateDate]) VALUES (40008, N'CL-10001', NULL, 2, 1003, 2, N'Bright Eye', NULL, NULL, N'2.1', N'2.1', NULL, NULL, NULL, CAST(350.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), NULL, 1, CAST(N'2020-06-24 15:31:05.420' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([Id], [TypeName]) VALUES (1, N'Frame')
INSERT [dbo].[ProductType] ([Id], [TypeName]) VALUES (2, N'Contact Lens')
INSERT [dbo].[ProductType] ([Id], [TypeName]) VALUES (3, N'Sun Glass')
INSERT [dbo].[ProductType] ([Id], [TypeName]) VALUES (4, N'Ophthalmic Lens')
INSERT [dbo].[ProductType] ([Id], [TypeName]) VALUES (5, N'Solution')
INSERT [dbo].[ProductType] ([Id], [TypeName]) VALUES (6, N'Accessories')
INSERT [dbo].[ProductType] ([Id], [TypeName]) VALUES (7, N'Others')
SET IDENTITY_INSERT [dbo].[ProductType] OFF
SET IDENTITY_INSERT [dbo].[Purchase] ON 

INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (5, N'PUR-2020060000000001', 2, 40008, 50, CAST(N'2020-06-25 09:21:03.230' AS DateTime), NULL, NULL, NULL, NULL, CAST(100.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (6, N'PUR-2020060000000002', 1, 40008, 100, CAST(N'2020-06-25 09:22:24.533' AS DateTime), NULL, NULL, NULL, NULL, CAST(80.00 AS Decimal(18, 2)), CAST(8000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (7, N'PUR-2020060000000003', 4, 40007, 20, CAST(N'2020-06-25 09:26:14.877' AS DateTime), NULL, NULL, NULL, NULL, CAST(60.00 AS Decimal(18, 2)), CAST(1200.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (8, N'PUR-2020060000000004', 2, 40008, 20, CAST(N'2020-06-26 08:39:12.197' AS DateTime), NULL, NULL, NULL, NULL, CAST(85.00 AS Decimal(18, 2)), CAST(1700.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (9, N'PUR-2020060000000005', 2, 40007, 20, CAST(N'2020-06-26 08:40:18.723' AS DateTime), NULL, NULL, NULL, NULL, CAST(70.00 AS Decimal(18, 2)), CAST(1400.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (10, N'PUR-2020060000000006', 2, 40008, 10, CAST(N'2020-06-26 08:40:38.483' AS DateTime), NULL, NULL, NULL, NULL, CAST(85.00 AS Decimal(18, 2)), CAST(850.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (11, N'PUR-2020060000000007', 2, 40008, 30, CAST(N'2020-06-26 08:40:56.997' AS DateTime), NULL, NULL, NULL, NULL, CAST(80.00 AS Decimal(18, 2)), CAST(2400.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (12, N'PUR-2020060000000008', 2, 40008, 50, CAST(N'2020-06-26 08:41:12.433' AS DateTime), NULL, NULL, NULL, NULL, CAST(70.00 AS Decimal(18, 2)), CAST(3500.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (13, N'PUR-2020060000000009', 4, 40007, 20, CAST(N'2020-06-26 08:41:39.510' AS DateTime), NULL, NULL, NULL, NULL, CAST(65.00 AS Decimal(18, 2)), CAST(1300.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (14, N'PUR-2020060000000010', NULL, 40008, 5, CAST(N'2020-06-26 08:41:59.127' AS DateTime), NULL, NULL, NULL, NULL, CAST(90.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (15, N'PUR-2020060000000011', 2, 40008, 100, CAST(N'2020-06-26 08:42:46.353' AS DateTime), NULL, NULL, NULL, NULL, CAST(78.00 AS Decimal(18, 2)), CAST(7800.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (16, N'PUR-2020060000000012', 2, 40008, 5, CAST(N'2020-06-26 11:38:02.607' AS DateTime), NULL, NULL, NULL, NULL, CAST(70.00 AS Decimal(18, 2)), CAST(350.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[Purchase] OFF
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([Id], [ProductId], [AvailableQuantity], [LastQuantity], [CreatedDate], [LastUpdate]) VALUES (2, 40008, 370, 365, CAST(N'2020-06-25 09:21:02.993' AS DateTime), CAST(N'2020-06-26 11:38:02.537' AS DateTime))
INSERT [dbo].[Stock] ([Id], [ProductId], [AvailableQuantity], [LastQuantity], [CreatedDate], [LastUpdate]) VALUES (3, 40007, 50, 60, CAST(N'2020-06-25 09:26:14.850' AS DateTime), CAST(N'2020-06-26 11:39:26.093' AS DateTime))
SET IDENTITY_INSERT [dbo].[Stock] OFF
SET IDENTITY_INSERT [dbo].[StockAdjustment] ON 

INSERT [dbo].[StockAdjustment] ([Id], [AdjustmentNo], [ProductId], [Quantity], [Note], [CreatedBy], [EntryDate]) VALUES (3, N'ADJ-2020060000000001', 40008, -5, N'Test Adjustment', NULL, CAST(N'2020-06-26 11:35:01.977' AS DateTime))
INSERT [dbo].[StockAdjustment] ([Id], [AdjustmentNo], [ProductId], [Quantity], [Note], [CreatedBy], [EntryDate]) VALUES (4, N'ADJ-2020060000000002', 40008, 5, N'Test Adjustment 2', NULL, CAST(N'2020-06-26 11:37:12.387' AS DateTime))
INSERT [dbo].[StockAdjustment] ([Id], [AdjustmentNo], [ProductId], [Quantity], [Note], [CreatedBy], [EntryDate]) VALUES (5, N'ADJ-2020060000000003', 40007, -10, NULL, NULL, CAST(N'2020-06-26 11:39:26.117' AS DateTime))
SET IDENTITY_INSERT [dbo].[StockAdjustment] OFF
SET IDENTITY_INSERT [dbo].[StockTrace] ON 

INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (2, 40008, 50, 0, 50, N'PUR-2020060000000001', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-25 09:21:03.193' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (3, 40008, 150, 50, 150, N'PUR-2020060000000002', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-25 09:22:24.517' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (4, 40007, 20, 0, 20, N'PUR-2020060000000003', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-25 09:26:14.870' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (5, 40008, 170, 150, 170, N'PUR-2020060000000004', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-26 08:39:12.133' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (6, 40007, 40, 20, 40, N'PUR-2020060000000005', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-26 08:40:18.713' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (7, 40008, 180, 170, 180, N'PUR-2020060000000006', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-26 08:40:38.477' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (8, 40008, 210, 180, 210, N'PUR-2020060000000007', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-26 08:40:56.990' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (9, 40008, 260, 210, 260, N'PUR-2020060000000008', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-26 08:41:12.427' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10, 40007, 60, 40, 60, N'PUR-2020060000000009', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-26 08:41:39.507' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (11, 40008, 265, 260, 265, N'PUR-2020060000000010', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-26 08:41:59.120' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (12, 40008, 365, 265, 365, N'PUR-2020060000000011', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-26 08:42:46.350' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (13, 40008, 360, 365, 360, N'ADJ-2020060000000001', N'Stock Adjustment', N'Generated From Stock/CreateStockAdjustment', CAST(N'2020-06-26 11:35:01.863' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (14, 40008, 365, 360, 365, N'ADJ-2020060000000002', N'Stock Adjustment', N'Generated From Stock/CreateStockAdjustment', CAST(N'2020-06-26 11:37:12.380' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (15, 40008, 370, 365, 370, N'PUR-2020060000000012', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-06-26 11:38:02.600' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (16, 40007, 50, 60, 50, N'ADJ-2020060000000003', N'Stock Adjustment', N'Generated From Stock/CreateStockAdjustment', CAST(N'2020-06-26 11:39:26.107' AS DateTime))
SET IDENTITY_INSERT [dbo].[StockTrace] OFF
SET IDENTITY_INSERT [dbo].[UnitMeasurement] ON 

INSERT [dbo].[UnitMeasurement] ([Id], [UnitName], [Description]) VALUES (1, N'Pcs                                               ', N'Single Item')
INSERT [dbo].[UnitMeasurement] ([Id], [UnitName], [Description]) VALUES (2, N'Box                                               ', N'1 box contains 6 items')
INSERT [dbo].[UnitMeasurement] ([Id], [UnitName], [Description]) VALUES (3, N'Package                                           ', N'1 pack contains 10 items')
SET IDENTITY_INSERT [dbo].[UnitMeasurement] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (1, N'3', 3, N'abdhsn@gmail.com', N'123123', NULL, N'StaticFiles/ProductImage/BigImage/5.jpg', N'StaticFiles/ProductImage/BigImage/5.jpg', NULL)
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (2, N'2', 3, N'abdullah279279@gmail.com', NULL, NULL, N'StaticFiles/Users/SmallImage/2.jpeg', N'StaticFiles/Users/BigImage/2.jpeg', CAST(N'2020-04-30 17:19:36.287' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (7, N'4', 7, N'dsfads', NULL, NULL, N'StaticFiles/Users/SmallImage/7.bmp', N'StaticFiles/Users/BigImage/7.bmp', CAST(N'2020-05-01 03:54:48.030' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (17, N'5', 6, N'abdullah000@gmail.com', NULL, NULL, N'StaticFiles/Users/SmallImage/17.jpg', N'StaticFiles/Users/BigImage/17.jpg', CAST(N'2020-05-01 06:55:25.890' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (18, N'gfghf', 5, N'gfghf', NULL, NULL, NULL, NULL, CAST(N'2020-06-20 12:48:15.093' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (19, N'Jerome@gmail.com', 6, N'Jerome@gmail.com', NULL, NULL, NULL, NULL, CAST(N'2020-06-20 12:52:51.933' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (20, N'Jerome@gmai.com', 7, N'Jerome@gmai.com', NULL, NULL, NULL, NULL, CAST(N'2020-06-20 12:54:20.560' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (24, N'Jrome.gds.@gdas.cc', 4, N'Jrome.gds.@gdas.cc', NULL, NULL, NULL, NULL, CAST(N'2020-06-20 12:56:15.980' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (29, N'Jrome.gds.@gdas.ccccc', 6, N'Jrome.gds.@gdas.ccccc', NULL, NULL, NULL, NULL, CAST(N'2020-06-20 13:21:11.593' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[UserType] ON 

INSERT [dbo].[UserType] ([Id], [TypeName]) VALUES (3, N'Admin')
INSERT [dbo].[UserType] ([Id], [TypeName]) VALUES (7, N'Apollo')
INSERT [dbo].[UserType] ([Id], [TypeName]) VALUES (4, N'Customer')
INSERT [dbo].[UserType] ([Id], [TypeName]) VALUES (5, N'Regular Customer')
INSERT [dbo].[UserType] ([Id], [TypeName]) VALUES (6, N'Special Customer')
INSERT [dbo].[UserType] ([Id], [TypeName]) VALUES (1, N'Super Admin')
INSERT [dbo].[UserType] ([Id], [TypeName]) VALUES (2, N'System Admin')
SET IDENTITY_INSERT [dbo].[UserType] OFF
/****** Object:  Index [UQ__Authoriz__1788CC4D637E3E3C]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Authorizations] ADD UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Authoriz__D4E7DFA8FF8BEC50]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[AuthorizeType] ADD UNIQUE NONCLUSTERED 
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__BalanceS__3C28DC1757DEE2E0]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[BalanceSourceType] ADD UNIQUE NONCLUSTERED 
(
	[SourceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Brand__737584F6616BEA47]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Brand] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Customer__5C7E359E1A832AA5]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Customers] ADD UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Customer__A9D10534A2069543]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Customers] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Damage__8A0F294842C6BD9D]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Damage] ADD UNIQUE NONCLUSTERED 
(
	[DamageNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Designat__D4E7DFA8C228D24F]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[DesignationTypes] ADD UNIQUE NONCLUSTERED 
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Manufact__3B9CDE2EE0CEF4E2]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Manufacturer] ADD UNIQUE NONCLUSTERED 
(
	[ManufacturerName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Orders__C3907C75D1585BAD]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Orders] ADD UNIQUE NONCLUSTERED 
(
	[OrderNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__PaymentM__737584F66248325C]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[PaymentMethods] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Personal__1788CC4D4B2A1430]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[PersonalDetail] ADD  CONSTRAINT [UQ__Personal__1788CC4D4B2A1430] UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Products__2F4E024FA30573CB]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [UQ__Products__2F4E024FA30573CB] UNIQUE NONCLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Purchase__6B0A9314353F90ED]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Purchase] ADD  CONSTRAINT [UQ__Purchase__6B0A9314353F90ED] UNIQUE NONCLUSTERED 
(
	[PurchaseNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Purchase__2C2936398048BAC2]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[PurchaseReturn] ADD UNIQUE NONCLUSTERED 
(
	[PurchaseReturnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Refunds__725A61B258C99BF1]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Refunds] ADD UNIQUE NONCLUSTERED 
(
	[RefundNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__SalesRet__E09004660ED3F87E]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[SalesReturn] ADD UNIQUE NONCLUSTERED 
(
	[SalesReturnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__StockAdj__E60D0EF175548E97]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[StockAdjustment] ADD UNIQUE NONCLUSTERED 
(
	[AdjustmentNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__ProductG__2F4E024F572B4401]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[SunglassDetail] ADD  CONSTRAINT [UQ__ProductG__2F4E024F572B4401] UNIQUE NONCLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Supplier__5C7E359E7BECE177]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Supplier] ADD UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Supplier__A9D10534FFA32ADD]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Supplier] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Users__A9D10534D36E8D6C]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__A9D10534D36E8D6C] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Users__C9F284566E18A7D7]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__UserType__D4E7DFA807F3DAE4]    Script Date: 6/26/2020 5:52:43 PM ******/
ALTER TABLE [dbo].[UserType] ADD  CONSTRAINT [UQ__UserType__D4E7DFA807F3DAE4] UNIQUE NONCLUSTERED 
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Authorizations]  WITH CHECK ADD FOREIGN KEY([AuthorizeTypeId])
REFERENCES [dbo].[AuthorizeType] ([Id])
GO
ALTER TABLE [dbo].[ContactLenseRX]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Designation]  WITH CHECK ADD FOREIGN KEY([DesignationTypeId])
REFERENCES [dbo].[DesignationTypes] ([Id])
GO
ALTER TABLE [dbo].[Health]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[HealthDocument]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discounts] ([Id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([VatId])
REFERENCES [dbo].[Vat] ([Id])
GO
ALTER TABLE [dbo].[PersonalDetail]  WITH CHECK ADD  CONSTRAINT [FK__PersonalD__UserI__403A8C7D] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PersonalDetail] CHECK CONSTRAINT [FK__PersonalD__UserI__403A8C7D]
GO
ALTER TABLE [dbo].[Refunds]  WITH CHECK ADD FOREIGN KEY([SalesReturnId])
REFERENCES [dbo].[SalesReturn] ([Id])
GO
ALTER TABLE [dbo].[SalesReturn]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[SalesTransaction]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[SalesTransaction]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[SalesTransaction]  WITH CHECK ADD FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethods] ([Id])
GO
ALTER TABLE [dbo].[SpectacleRX]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
