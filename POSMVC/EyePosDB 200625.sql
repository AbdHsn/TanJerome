USE [EyePosDB]
GO
/****** Object:  Table [dbo].[Authorizations]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[AuthorizeType]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Balance]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[BalanceSourceType]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Brand]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Company]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[ContactLensDetail]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[ContactLenseRX]    Script Date: 7/26/2020 8:27:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactLenseRX](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[NPRSPH] [nvarchar](11) NULL,
	[NPRCYL] [nvarchar](11) NULL,
	[NPRAXIS] [nvarchar](11) NULL,
	[NPRVA] [nvarchar](11) NULL,
	[NPRADD] [nvarchar](11) NULL,
	[NPLSPH] [nvarchar](11) NULL,
	[NPLCYL] [nvarchar](11) NULL,
	[NPLAXIS] [nvarchar](11) NULL,
	[NPLVA] [nvarchar](11) NULL,
	[NPLADD] [nvarchar](11) NULL,
	[NearRSPH] [nvarchar](11) NULL,
	[NearRCYL] [nvarchar](11) NULL,
	[NearRAXIS] [nvarchar](11) NULL,
	[NearRVA] [nvarchar](11) NULL,
	[NearRADD] [nvarchar](11) NULL,
	[NearLSPH] [nvarchar](11) NULL,
	[NearLCYL] [nvarchar](11) NULL,
	[NearLAXIS] [nvarchar](11) NULL,
	[NearLVA] [nvarchar](11) NULL,
	[NearLADD] [nvarchar](11) NULL,
	[OPRSPH] [nvarchar](11) NULL,
	[OPRCYL] [nvarchar](11) NULL,
	[OPRAXIS] [nvarchar](11) NULL,
	[OPRVA] [nvarchar](11) NULL,
	[OPLSPH] [nvarchar](11) NULL,
	[OPLCYL] [nvarchar](11) NULL,
	[OPLAXIS] [nvarchar](11) NULL,
	[OPLVA] [nvarchar](11) NULL,
	[RBC] [nvarchar](11) NULL,
	[LBC] [nvarchar](11) NULL,
	[RDiameter] [nvarchar](11) NULL,
	[LDiameter] [nvarchar](11) NULL,
	[KRReading] [nvarchar](11) NULL,
	[KLReading] [nvarchar](11) NULL,
	[RFittingBC] [nvarchar](11) NULL,
	[LFittingBC] [nvarchar](11) NULL,
	[Remark] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[CheckedBy] [bigint] NULL,
	[CheckedDate] [datetime] NULL,
 CONSTRAINT [PK__ContactL__3214EC075D71458F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Damage]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Designation]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[DesignationTypes]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Discounts]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[FrameDetail]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Health]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[HealthDocument]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 7/26/2020 8:27:21 AM ******/
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
	[Total] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/26/2020 8:27:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](20) NULL,
	[UserId] [bigint] NULL,
	[VatId] [int] NULL,
	[VatRate] [decimal](18, 2) NULL,
	[VatAmount] [decimal](18, 2) NULL,
	[DiscountId] [int] NULL,
	[DiscountRate] [decimal](18, 2) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[BillingAddress] [nvarchar](250) NULL,
	[CollectionDate] [datetime] NULL,
	[OrderPlaceDate] [datetime] NULL,
	[UpdateBy] [bigint] NULL,
	[LastUpdate] [datetime] NULL,
	[OrderStatus] [nvarchar](15) NULL,
	[Note] [nvarchar](100) NULL,
 CONSTRAINT [PK__Orders__3214EC075E37C4E7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 7/26/2020 8:27:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TransactionNo] [nvarchar](20) NULL,
	[TransactionDate] [datetime] NULL,
	[UserId] [bigint] NULL,
	[InstrumentNo] [nvarchar](25) NULL,
	[TableReference] [nvarchar](30) NULL,
	[PaidAmount] [decimal](18, 2) NULL,
	[PaymentMethodId] [int] NULL,
 CONSTRAINT [PK__Payment__3214EC0757C1D835] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[PersonalDetail]    Script Date: 7/26/2020 8:27:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[ICNo] [nvarchar](20) NULL,
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
/****** Object:  Table [dbo].[Products]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[ProductType]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Purchase]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[PurchaseReturn]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Refunds]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[SalesReturn]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[SalesTransaction]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[Scheduler]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[SpectacleRX]    Script Date: 7/26/2020 8:27:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpectacleRX](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[NPRSPH] [nvarchar](11) NULL,
	[NPRCYL] [nvarchar](11) NULL,
	[NPRAXIS] [nvarchar](11) NULL,
	[NPRVA] [nvarchar](11) NULL,
	[NPRADD] [nvarchar](11) NULL,
	[NPLSPH] [nvarchar](11) NULL,
	[NPLCYL] [nvarchar](11) NULL,
	[NPLAXIS] [nvarchar](11) NULL,
	[NPLVA] [nvarchar](11) NULL,
	[NPLADD] [nvarchar](11) NULL,
	[NearRSPH] [nvarchar](11) NULL,
	[NearRCYL] [nvarchar](11) NULL,
	[NearRAXIS] [nvarchar](11) NULL,
	[NearRVA] [nvarchar](11) NULL,
	[NearRADD] [nvarchar](11) NULL,
	[NearLSPH] [nvarchar](11) NULL,
	[NearLCYL] [nvarchar](11) NULL,
	[NearLAXIS] [nvarchar](11) NULL,
	[NearLVA] [nvarchar](11) NULL,
	[NearLADD] [nvarchar](11) NULL,
	[OPRSPH] [nvarchar](11) NULL,
	[OPRCYL] [nvarchar](11) NULL,
	[OPRAXIS] [nvarchar](11) NULL,
	[OPRVA] [nvarchar](11) NULL,
	[OPLSPH] [nvarchar](11) NULL,
	[OPLCYL] [nvarchar](11) NULL,
	[OPLAXIS] [nvarchar](11) NULL,
	[OPLVA] [nvarchar](11) NULL,
	[RBC] [nvarchar](11) NULL,
	[LBC] [nvarchar](11) NULL,
	[PupilHeight] [nvarchar](11) NULL,
	[FrameSize] [nvarchar](11) NULL,
	[ED] [nvarchar](11) NULL,
	[ADimension] [nvarchar](11) NULL,
	[BDimension] [nvarchar](11) NULL,
	[RPD] [nvarchar](11) NULL,
	[LPD] [nvarchar](100) NULL,
	[NearFarPD] [nvarchar](100) NULL,
	[Remark] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[CheckedBy] [bigint] NULL,
	[CheckedDate] [datetime] NULL,
 CONSTRAINT [PK__Spectacl__3214EC074DD8255F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[StockAdjustment]    Script Date: 7/26/2020 8:27:21 AM ******/
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
/****** Object:  Table [dbo].[StockReserved]    Script Date: 7/26/2020 8:27:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockReserved](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[UserId] [bigint] NULL,
	[ReservedQuantity] [int] NULL,
	[ReserveStatus] [nvarchar](15) NULL,
	[Note] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockTrace]    Script Date: 7/26/2020 8:27:22 AM ******/
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
/****** Object:  Table [dbo].[SunglassDetail]    Script Date: 7/26/2020 8:27:22 AM ******/
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
/****** Object:  Table [dbo].[Supplier]    Script Date: 7/26/2020 8:27:22 AM ******/
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
/****** Object:  Table [dbo].[UnitMeasurement]    Script Date: 7/26/2020 8:27:22 AM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 7/26/2020 8:27:22 AM ******/
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
/****** Object:  Table [dbo].[UserType]    Script Date: 7/26/2020 8:27:22 AM ******/
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
/****** Object:  Table [dbo].[Vat]    Script Date: 7/26/2020 8:27:22 AM ******/
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
SET IDENTITY_INSERT [dbo].[AuthorizeType] ON 

INSERT [dbo].[AuthorizeType] ([Id], [TypeName], [Description]) VALUES (1, N'SuperAdmin', N'Having All Access')
INSERT [dbo].[AuthorizeType] ([Id], [TypeName], [Description]) VALUES (2, N'Admin', N'Having Modarator Access')
INSERT [dbo].[AuthorizeType] ([Id], [TypeName], [Description]) VALUES (3, N'SalesMan', N'Sales Features')
SET IDENTITY_INSERT [dbo].[AuthorizeType] OFF
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
SET IDENTITY_INSERT [dbo].[ContactLenseRX] ON 

INSERT [dbo].[ContactLenseRX] ([Id], [UserId], [NPRSPH], [NPRCYL], [NPRAXIS], [NPRVA], [NPRADD], [NPLSPH], [NPLCYL], [NPLAXIS], [NPLVA], [NPLADD], [NearRSPH], [NearRCYL], [NearRAXIS], [NearRVA], [NearRADD], [NearLSPH], [NearLCYL], [NearLAXIS], [NearLVA], [NearLADD], [OPRSPH], [OPRCYL], [OPRAXIS], [OPRVA], [OPLSPH], [OPLCYL], [OPLAXIS], [OPLVA], [RBC], [LBC], [RDiameter], [LDiameter], [KRReading], [KLReading], [RFittingBC], [LFittingBC], [Remark], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [CheckedBy], [CheckedDate]) VALUES (1, 38, N'1', N'2', N'3', N'4', N'1', N'2', N'2', N'2', N'2', N'1', N'2', N'2', N'3', N'4', NULL, N'3', N'2', N'2', N'2', NULL, N'1', N'1', N'1', N'1', N'2', N'1', N'1', N'1', N'2', N'1', N'2', N'1', N'1', N'2', N'1', N'2', N'1st Test Full', CAST(N'2020-07-09 10:41:10.633' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ContactLenseRX] ([Id], [UserId], [NPRSPH], [NPRCYL], [NPRAXIS], [NPRVA], [NPRADD], [NPLSPH], [NPLCYL], [NPLAXIS], [NPLVA], [NPLADD], [NearRSPH], [NearRCYL], [NearRAXIS], [NearRVA], [NearRADD], [NearLSPH], [NearLCYL], [NearLAXIS], [NearLVA], [NearLADD], [OPRSPH], [OPRCYL], [OPRAXIS], [OPRVA], [OPLSPH], [OPLCYL], [OPLAXIS], [OPLVA], [RBC], [LBC], [RDiameter], [LDiameter], [KRReading], [KLReading], [RFittingBC], [LFittingBC], [Remark], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [CheckedBy], [CheckedDate]) VALUES (3, 39, N'1', N'3', N'3', N'2', N'2', N'2', N'2', N'1', N'1', N'1.5', N'3', N'3', N'3', N'2', NULL, N'3.5', N'2', N'1', N'1', NULL, N'2', N'2', N'1', N'1', N'2', N'1', N'1', N'1', N'22', N'23', N'6', N'5', N'4', N'5', N'5', N'4', N'Dear Shumi, please visit every month to check your progress.', CAST(N'2020-07-09 11:34:06.900' AS DateTime), NULL, CAST(N'2020-07-21 08:35:32.517' AS DateTime), NULL, 0, NULL)
INSERT [dbo].[ContactLenseRX] ([Id], [UserId], [NPRSPH], [NPRCYL], [NPRAXIS], [NPRVA], [NPRADD], [NPLSPH], [NPLCYL], [NPLAXIS], [NPLVA], [NPLADD], [NearRSPH], [NearRCYL], [NearRAXIS], [NearRVA], [NearRADD], [NearLSPH], [NearLCYL], [NearLAXIS], [NearLVA], [NearLADD], [OPRSPH], [OPRCYL], [OPRAXIS], [OPRVA], [OPLSPH], [OPLCYL], [OPLAXIS], [OPLVA], [RBC], [LBC], [RDiameter], [LDiameter], [KRReading], [KLReading], [RFittingBC], [LFittingBC], [Remark], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [CheckedBy], [CheckedDate]) VALUES (10002, 29, N'1', N'1', N'2', N'1', N'1', N'2', N'1', N'2', N'1', N'2', N'2', N'1', N'2', N'1', NULL, N'4', N'1', N'2', N'1', NULL, N'2', N'2', N'1', N'1', N'2', N'1', N'1', N'1', N'1', N'2', N'2', N'3', N'1', N'1', N'1', N'2', N'Please come on Saturday again.', CAST(N'2020-07-22 11:02:18.280' AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ContactLenseRX] OFF
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 

INSERT [dbo].[Manufacturer] ([Id], [ManufacturerName], [ContactInfo], [SmallImage], [BigImage]) VALUES (1, N'None', N'sdkfas', NULL, NULL)
INSERT [dbo].[Manufacturer] ([Id], [ManufacturerName], [ContactInfo], [SmallImage], [BigImage]) VALUES (2, N'EyeCare', N'dfasd', NULL, NULL)
INSERT [dbo].[Manufacturer] ([Id], [ManufacturerName], [ContactInfo], [SmallImage], [BigImage]) VALUES (4, N'X-Devine', N'sdkfas', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10011, 10008, 40008, 2, CAST(500.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10012, 10008, 40007, 1, CAST(350.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10043, 10009, 40007, 1, CAST(350.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10044, 10009, 40008, 2, CAST(500.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10045, 10010, 40007, 1, CAST(350.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10046, 10010, 40008, 2, CAST(500.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10047, 10011, 40007, 2, CAST(350.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(700.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10048, 10012, 40007, 2, CAST(350.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(700.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10049, 10012, 40008, 1, CAST(500.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10050, 10012, 40008, 1, CAST(500.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10051, 10013, 40007, 2, CAST(350.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(700.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10052, 10013, 40008, 3, CAST(500.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1500.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10053, 10014, 40007, 1, CAST(350.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (10054, 10015, 40007, 3, CAST(350.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1050.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [CollectionDate], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [Total]) VALUES (20051, 20013, 40007, 3, CAST(350.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1050.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderNo], [UserId], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [GrandTotal], [BillingAddress], [CollectionDate], [OrderPlaceDate], [UpdateBy], [LastUpdate], [OrderStatus], [Note]) VALUES (10008, N'ORD-2020070000000008', 39, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1350.00 AS Decimal(18, 2)), NULL, CAST(N'2020-07-20 02:12:59.413' AS DateTime), CAST(N'2020-07-20 08:12:59.413' AS DateTime), NULL, NULL, N'Process', NULL)
INSERT [dbo].[Orders] ([Id], [OrderNo], [UserId], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [GrandTotal], [BillingAddress], [CollectionDate], [OrderPlaceDate], [UpdateBy], [LastUpdate], [OrderStatus], [Note]) VALUES (10009, N'ORD-2020070000000009', 35, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1350.00 AS Decimal(18, 2)), NULL, CAST(N'2020-07-21 07:44:35.687' AS DateTime), CAST(N'2020-07-21 13:44:35.687' AS DateTime), NULL, CAST(N'2020-07-25 18:31:25.490' AS DateTime), N'Approved', NULL)
INSERT [dbo].[Orders] ([Id], [OrderNo], [UserId], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [GrandTotal], [BillingAddress], [CollectionDate], [OrderPlaceDate], [UpdateBy], [LastUpdate], [OrderStatus], [Note]) VALUES (10010, N'ORD-2020070000000010', 35, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1350.00 AS Decimal(18, 2)), NULL, CAST(N'2020-07-21 07:45:27.240' AS DateTime), CAST(N'2020-07-21 13:45:27.240' AS DateTime), NULL, NULL, N'Process', NULL)
INSERT [dbo].[Orders] ([Id], [OrderNo], [UserId], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [GrandTotal], [BillingAddress], [CollectionDate], [OrderPlaceDate], [UpdateBy], [LastUpdate], [OrderStatus], [Note]) VALUES (10011, N'ORD-2020070000000011', 7, NULL, NULL, NULL, NULL, NULL, NULL, CAST(700.00 AS Decimal(18, 2)), NULL, CAST(N'2020-07-21 08:02:50.820' AS DateTime), CAST(N'2020-07-21 14:02:50.820' AS DateTime), NULL, NULL, N'Process', NULL)
INSERT [dbo].[Orders] ([Id], [OrderNo], [UserId], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [GrandTotal], [BillingAddress], [CollectionDate], [OrderPlaceDate], [UpdateBy], [LastUpdate], [OrderStatus], [Note]) VALUES (10012, N'ORD-2020070000000012', 35, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1700.00 AS Decimal(18, 2)), NULL, CAST(N'2020-07-25 00:00:00.000' AS DateTime), CAST(N'2020-07-21 14:08:57.053' AS DateTime), NULL, NULL, N'Process', NULL)
INSERT [dbo].[Orders] ([Id], [OrderNo], [UserId], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [GrandTotal], [BillingAddress], [CollectionDate], [OrderPlaceDate], [UpdateBy], [LastUpdate], [OrderStatus], [Note]) VALUES (10013, N'ORD-2020070000000013', 39, NULL, NULL, NULL, NULL, NULL, NULL, CAST(2200.00 AS Decimal(18, 2)), NULL, CAST(N'2020-07-30 00:00:00.000' AS DateTime), CAST(N'2020-07-21 14:35:32.550' AS DateTime), NULL, CAST(N'2020-07-26 02:09:50.987' AS DateTime), N'Rejected', NULL)
INSERT [dbo].[Orders] ([Id], [OrderNo], [UserId], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [GrandTotal], [BillingAddress], [CollectionDate], [OrderPlaceDate], [UpdateBy], [LastUpdate], [OrderStatus], [Note]) VALUES (10014, N'ORD-2020070000000014', 29, NULL, NULL, NULL, NULL, NULL, NULL, CAST(350.00 AS Decimal(18, 2)), NULL, CAST(N'2020-07-22 05:18:44.167' AS DateTime), CAST(N'2020-07-22 11:18:44.167' AS DateTime), NULL, NULL, N'Process', NULL)
INSERT [dbo].[Orders] ([Id], [OrderNo], [UserId], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [GrandTotal], [BillingAddress], [CollectionDate], [OrderPlaceDate], [UpdateBy], [LastUpdate], [OrderStatus], [Note]) VALUES (10015, N'ORD-2020070000000015', 29, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1050.00 AS Decimal(18, 2)), NULL, CAST(N'2020-07-28 00:00:00.000' AS DateTime), CAST(N'2020-07-22 17:02:18.407' AS DateTime), NULL, CAST(N'2020-07-25 18:59:42.677' AS DateTime), N'Refunded', NULL)
INSERT [dbo].[Orders] ([Id], [OrderNo], [UserId], [VatId], [VatRate], [VatAmount], [DiscountId], [DiscountRate], [DiscountAmount], [GrandTotal], [BillingAddress], [CollectionDate], [OrderPlaceDate], [UpdateBy], [LastUpdate], [OrderStatus], [Note]) VALUES (20013, N'ORD-2020070000000016', 2, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1050.00 AS Decimal(18, 2)), NULL, CAST(N'2020-07-25 03:38:21.883' AS DateTime), CAST(N'2020-07-25 09:38:21.883' AS DateTime), NULL, CAST(N'2020-07-25 18:58:00.720' AS DateTime), N'Delivered', NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([Id], [TransactionNo], [TransactionDate], [UserId], [InstrumentNo], [TableReference], [PaidAmount], [PaymentMethodId]) VALUES (1, N'TRN-2020070000000001', CAST(N'2020-07-22 10:22:46.827' AS DateTime), 39, N'ORD-2020070000000008', N'Orders', CAST(20.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Payment] ([Id], [TransactionNo], [TransactionDate], [UserId], [InstrumentNo], [TableReference], [PaidAmount], [PaymentMethodId]) VALUES (2, N'TRN-2020070000000002', CAST(N'2020-07-22 10:31:42.190' AS DateTime), 39, N'ORD-2020070000000008', N'Orders', CAST(20.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Payment] ([Id], [TransactionNo], [TransactionDate], [UserId], [InstrumentNo], [TableReference], [PaidAmount], [PaymentMethodId]) VALUES (3, N'TRN-2020070000000003', CAST(N'2020-07-22 10:32:31.383' AS DateTime), 39, N'ORD-2020070000000008', N'Orders', CAST(1310.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Payment] ([Id], [TransactionNo], [TransactionDate], [UserId], [InstrumentNo], [TableReference], [PaidAmount], [PaymentMethodId]) VALUES (4, N'TRN-2020070000000004', CAST(N'2020-07-22 10:51:02.890' AS DateTime), 35, N'ORD-2020070000000009', N'Orders', CAST(50.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Payment] ([Id], [TransactionNo], [TransactionDate], [UserId], [InstrumentNo], [TableReference], [PaidAmount], [PaymentMethodId]) VALUES (5, N'TRN-2020070000000005', CAST(N'2020-07-22 10:58:32.777' AS DateTime), 35, N'ORD-2020070000000009', N'Orders', CAST(300.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Payment] ([Id], [TransactionNo], [TransactionDate], [UserId], [InstrumentNo], [TableReference], [PaidAmount], [PaymentMethodId]) VALUES (6, N'TRN-2020070000000006', CAST(N'2020-07-22 10:58:52.667' AS DateTime), 35, N'ORD-2020070000000009', N'Orders', CAST(1000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Payment] ([Id], [TransactionNo], [TransactionDate], [UserId], [InstrumentNo], [TableReference], [PaidAmount], [PaymentMethodId]) VALUES (7, N'TRN-2020070000000007', CAST(N'2020-07-22 11:02:43.740' AS DateTime), 29, N'ORD-2020070000000015', N'Orders', CAST(50.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Payment] ([Id], [TransactionNo], [TransactionDate], [UserId], [InstrumentNo], [TableReference], [PaidAmount], [PaymentMethodId]) VALUES (8, N'TRN-2020070000000008', CAST(N'2020-07-22 11:03:15.443' AS DateTime), 29, N'ORD-2020070000000015', N'Orders', CAST(1000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Payment] ([Id], [TransactionNo], [TransactionDate], [UserId], [InstrumentNo], [TableReference], [PaidAmount], [PaymentMethodId]) VALUES (10002, N'TRN-2020070000000009', CAST(N'2020-07-25 03:54:57.813' AS DateTime), 2, N'ORD-2020070000000016', N'Orders', CAST(10.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Payment] OFF
SET IDENTITY_INSERT [dbo].[PaymentMethods] ON 

INSERT [dbo].[PaymentMethods] ([Id], [Name], [LogoPath], [Description], [Url]) VALUES (1, N'Hand Cash', NULL, NULL, NULL)
INSERT [dbo].[PaymentMethods] ([Id], [Name], [LogoPath], [Description], [Url]) VALUES (2, N'PayPal', NULL, NULL, NULL)
INSERT [dbo].[PaymentMethods] ([Id], [Name], [LogoPath], [Description], [Url]) VALUES (3, N'Credit Card', NULL, NULL, NULL)
INSERT [dbo].[PaymentMethods] ([Id], [Name], [LogoPath], [Description], [Url]) VALUES (4, N'Bank', NULL, NULL, NULL)
INSERT [dbo].[PaymentMethods] ([Id], [Name], [LogoPath], [Description], [Url]) VALUES (5, N'Visa Card', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PaymentMethods] OFF
SET IDENTITY_INSERT [dbo].[PersonalDetail] ON 

INSERT [dbo].[PersonalDetail] ([Id], [UserId], [ICNo], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (1, 2, NULL, N'fagd', N'Common', N'33333333', N'44444444444', CAST(N'1900-01-01' AS Date), N'Mirput444444444', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [ICNo], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (4, 7, NULL, N'Abdullah', N'Male', N'22113342', N'223322', CAST(N'1900-01-01' AS Date), N'Mirpur 4/13/Cha, West Vasantak Cantonment Dhaka', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [ICNo], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (8, NULL, NULL, N'ad', N'Male', N'22343452', N'43534', CAST(N'1900-01-01' AS Date), N'Mirput', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [ICNo], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (13, 29, NULL, N'Jerome', N'Male', N'22223425', N'234222', CAST(N'2020-06-16' AS Date), N'Lorem ipsum dolor sit ', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [ICNo], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (20, 1, N'34534', N'Jerome2', N'Male', N'22223424', N'234222', CAST(N'2020-06-16' AS Date), N'Lorem ipsum dolor sit ', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [ICNo], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (21, 35, NULL, N'AbdHsn', N'Male', N'01767439', NULL, CAST(N'1991-08-03' AS Date), N'Granuva, Street-554, NewYork. USA.', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [ICNo], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (22, 36, NULL, N'Riaz', N'Male', N'22323243', NULL, CAST(N'2020-07-22' AS Date), N'dddd', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [ICNo], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (23, 37, NULL, N'Tamim', N'Male', N'23234234', NULL, CAST(N'2020-07-22' AS Date), N'dd', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [ICNo], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (24, 38, NULL, N'Shajeeb Mahmud', N'Male', N'22222222', NULL, CAST(N'2020-07-06' AS Date), N'ssssssssssssssssssssssssssssssss', NULL, NULL)
INSERT [dbo].[PersonalDetail] ([Id], [UserId], [ICNo], [Name], [Gender], [MobileNo], [OtherPhone], [DOB], [Address], [Language], [MaritalStatus]) VALUES (25, 39, N'345435', N'Shumi ', N'Female', N'01767435', NULL, CAST(N'2020-07-13' AS Date), N'Vasantak, Cantonment 1206, Dhaka, Bangladesh', NULL, NULL)
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

INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (10017, N'PUR-2020070000000001', 2, 40007, 1200, CAST(N'2020-07-20 02:06:52.147' AS DateTime), NULL, NULL, NULL, NULL, CAST(250.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseNo], [SupplierId], [ProductId], [Quantity], [EntryDate], [PurchaseDate], [VatId], [VatRate], [VatAmount], [PriceRate], [FinalTotal], [Note]) VALUES (10018, N'PUR-2020070000000002', 4, 40008, 980, CAST(N'2020-07-20 02:07:18.277' AS DateTime), NULL, NULL, NULL, NULL, CAST(180.00 AS Decimal(18, 2)), CAST(176400.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[Purchase] OFF
SET IDENTITY_INSERT [dbo].[SpectacleRX] ON 

INSERT [dbo].[SpectacleRX] ([Id], [UserId], [NPRSPH], [NPRCYL], [NPRAXIS], [NPRVA], [NPRADD], [NPLSPH], [NPLCYL], [NPLAXIS], [NPLVA], [NPLADD], [NearRSPH], [NearRCYL], [NearRAXIS], [NearRVA], [NearRADD], [NearLSPH], [NearLCYL], [NearLAXIS], [NearLVA], [NearLADD], [OPRSPH], [OPRCYL], [OPRAXIS], [OPRVA], [OPLSPH], [OPLCYL], [OPLAXIS], [OPLVA], [RBC], [LBC], [PupilHeight], [FrameSize], [ED], [ADimension], [BDimension], [RPD], [LPD], [NearFarPD], [Remark], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [CheckedBy], [CheckedDate]) VALUES (1, 38, N'1', N'33', N'33', N'22', N'11', N'22', N'222', N'33', N'31', N'12', N'12', N'33', N'33', N'22', NULL, N'34', N'222', N'33', N'31', NULL, N'22', N'22', N'11', N'11', N'21', N'1', N'1', N'1', N'', N'', N'2', N'5', N'0', N'5', N'5', N'4', N'Update  test....', N'2', N'test', CAST(N'2020-07-13 16:04:07.380' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SpectacleRX] ([Id], [UserId], [NPRSPH], [NPRCYL], [NPRAXIS], [NPRVA], [NPRADD], [NPLSPH], [NPLCYL], [NPLAXIS], [NPLVA], [NPLADD], [NearRSPH], [NearRCYL], [NearRAXIS], [NearRVA], [NearRADD], [NearLSPH], [NearLCYL], [NearLAXIS], [NearLVA], [NearLADD], [OPRSPH], [OPRCYL], [OPRAXIS], [OPRVA], [OPLSPH], [OPLCYL], [OPLAXIS], [OPLVA], [RBC], [LBC], [PupilHeight], [FrameSize], [ED], [ADimension], [BDimension], [RPD], [LPD], [NearFarPD], [Remark], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [CheckedBy], [CheckedDate]) VALUES (2, 39, N'1', N'2', N'3', N'4', N'5', N'2', N'2', N'1', N'1', N'1', N'6', N'2', N'3', N'4', NULL, N'3', N'2', N'1', N'1', NULL, N'1', N'2', N'1', N'1', N'2', N'2', N'1', N'1', NULL, NULL, N'1', N'1', NULL, N'2', N'2', N'3', N'1', N'11', N'Dear Shumi, use your spectacle regularly. ', CAST(N'2020-07-14 05:38:55.590' AS DateTime), NULL, CAST(N'2020-07-19 16:02:57.207' AS DateTime), NULL, 0, NULL)
INSERT [dbo].[SpectacleRX] ([Id], [UserId], [NPRSPH], [NPRCYL], [NPRAXIS], [NPRVA], [NPRADD], [NPLSPH], [NPLCYL], [NPLAXIS], [NPLVA], [NPLADD], [NearRSPH], [NearRCYL], [NearRAXIS], [NearRVA], [NearRADD], [NearLSPH], [NearLCYL], [NearLAXIS], [NearLVA], [NearLADD], [OPRSPH], [OPRCYL], [OPRAXIS], [OPRVA], [OPLSPH], [OPLCYL], [OPLAXIS], [OPLVA], [RBC], [LBC], [PupilHeight], [FrameSize], [ED], [ADimension], [BDimension], [RPD], [LPD], [NearFarPD], [Remark], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [CheckedBy], [CheckedDate]) VALUES (3, 35, N'2', N'2', N'1', N'2', N'2', N'2', N'2', N'1', N'3', N'1.5', N'4', N'2', N'1', N'2', NULL, N'3.5', N'2', N'1', N'3', NULL, N'2', N'2', N'1', N'1', N'2', N'1', N'2', N'3', NULL, NULL, N'2', N'20', NULL, N'5', N'6', N'2', N'3', N'5', N'Please recheck every end of month for getting better treatment. Thank you!', CAST(N'2020-07-21 08:08:56.913' AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SpectacleRX] OFF
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([Id], [ProductId], [AvailableQuantity], [LastQuantity], [CreatedDate], [LastUpdate]) VALUES (4, 40007, 1184, 1187, CAST(N'2020-07-20 02:06:51.887' AS DateTime), CAST(N'2020-07-25 03:38:22.043' AS DateTime))
INSERT [dbo].[Stock] ([Id], [ProductId], [AvailableQuantity], [LastQuantity], [CreatedDate], [LastUpdate]) VALUES (5, 40008, 989, 992, CAST(N'2020-07-20 02:07:18.223' AS DateTime), CAST(N'2020-07-21 08:35:32.587' AS DateTime))
SET IDENTITY_INSERT [dbo].[Stock] OFF
SET IDENTITY_INSERT [dbo].[StockAdjustment] ON 

INSERT [dbo].[StockAdjustment] ([Id], [AdjustmentNo], [ProductId], [Quantity], [Note], [CreatedBy], [EntryDate]) VALUES (6, N'ADJ-2020070000000001', 40008, 80, N'New Add test', NULL, CAST(N'2020-07-20 02:09:32.003' AS DateTime))
INSERT [dbo].[StockAdjustment] ([Id], [AdjustmentNo], [ProductId], [Quantity], [Note], [CreatedBy], [EntryDate]) VALUES (7, N'ADJ-2020070000000002', 40008, -60, N'Mistak solve', NULL, CAST(N'2020-07-20 02:10:28.853' AS DateTime))
INSERT [dbo].[StockAdjustment] ([Id], [AdjustmentNo], [ProductId], [Quantity], [Note], [CreatedBy], [EntryDate]) VALUES (8, N'ADJ-2020070000000003', 40008, 2, N'test add', NULL, CAST(N'2020-07-20 02:11:21.677' AS DateTime))
INSERT [dbo].[StockAdjustment] ([Id], [AdjustmentNo], [ProductId], [Quantity], [Note], [CreatedBy], [EntryDate]) VALUES (9, N'ADJ-2020070000000004', 40008, -2, N'mistak test', NULL, CAST(N'2020-07-20 02:11:35.823' AS DateTime))
SET IDENTITY_INSERT [dbo].[StockAdjustment] OFF
SET IDENTITY_INSERT [dbo].[StockTrace] ON 

INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10026, 40007, 1200, 0, 1200, N'PUR-2020070000000001', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-07-20 02:06:52.080' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10027, 40008, 980, 0, 980, N'PUR-2020070000000002', N'Purchase', N'Generated From Items/CreatePurchaseItem', CAST(N'2020-07-20 02:07:18.273' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10028, 40008, 1060, 980, 1060, N'ADJ-2020070000000001', N'Stock Adjustment', N'Generated From Stock/CreateStockAdjustment', CAST(N'2020-07-20 02:09:32.000' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10029, 40008, 1000, 1060, 1000, N'ADJ-2020070000000002', N'Stock Adjustment', N'Generated From Stock/CreateStockAdjustment', CAST(N'2020-07-20 02:10:28.847' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10030, 40008, 1002, 1000, 1002, N'ADJ-2020070000000003', N'Stock Adjustment', N'Generated From Stock/CreateStockAdjustment', CAST(N'2020-07-20 02:11:21.670' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10031, 40008, 1000, 1002, 1000, N'ADJ-2020070000000004', N'Stock Adjustment', N'Generated From Stock/CreateStockAdjustment', CAST(N'2020-07-20 02:11:35.820' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10032, 40008, 998, 1000, 998, N'ORD-2020070000000008', N'Sales Order', N'Generated From Orders/CreateCCOrder', CAST(N'2020-07-20 02:12:59.510' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10033, 40007, 1199, 1200, 1199, N'ORD-2020070000000008', N'Sales Order', N'Generated From Orders/CreateCCOrder', CAST(N'2020-07-20 02:12:59.530' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10034, 40007, 1198, 1199, 1198, N'ORD-2020070000000009', N'Sales Order', N'Generated From Orders/CreateCCOrder', CAST(N'2020-07-21 07:44:35.920' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10035, 40008, 996, 998, 996, N'ORD-2020070000000009', N'Sales Order', N'Generated From Orders/CreateCCOrder', CAST(N'2020-07-21 07:44:35.950' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10036, 40007, 1197, 1198, 1197, N'ORD-2020070000000010', N'Sales Order', N'Generated From Orders/CreateCCOrder', CAST(N'2020-07-21 07:45:27.280' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10037, 40008, 994, 996, 994, N'ORD-2020070000000010', N'Sales Order', N'Generated From Orders/CreateCCOrder', CAST(N'2020-07-21 07:45:27.300' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10038, 40007, 1195, 1197, 1195, N'ORD-2020070000000011', N'Sales Order', N'Generated From Orders/CreateCCOrder', CAST(N'2020-07-21 08:02:51.037' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10039, 40007, 1193, 1195, 1193, N'ORD-2020070000000012', N'Sales Order', N'Generated From Orders/CreateCLOrder', CAST(N'2020-07-21 08:08:57.203' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10040, 40008, 993, 994, 993, N'ORD-2020070000000012', N'Sales Order', N'Generated From Orders/CreateCLOrder', CAST(N'2020-07-21 08:08:57.230' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10041, 40008, 992, 993, 992, N'ORD-2020070000000012', N'Sales Order', N'Generated From Orders/CreateCLOrder', CAST(N'2020-07-21 08:08:57.243' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10042, 40007, 1191, 1193, 1191, N'ORD-2020070000000013', N'Sales Order', N'Generated From Orders/CreateCLOrder', CAST(N'2020-07-21 08:35:32.570' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10043, 40008, 989, 992, 989, N'ORD-2020070000000013', N'Sales Order', N'Generated From Orders/CreateCLOrder', CAST(N'2020-07-21 08:35:32.600' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10044, 40007, 1190, 1191, 1190, N'ORD-2020070000000014', N'Sales Order', N'Generated From Orders/CreateCCOrder', CAST(N'2020-07-22 05:18:44.550' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (10045, 40007, 1187, 1190, 1187, N'ORD-2020070000000015', N'Sales Order', N'Generated From Orders/CreateCLOrder', CAST(N'2020-07-22 11:02:18.713' AS DateTime))
INSERT [dbo].[StockTrace] ([Id], [ProductId], [CurrentQuantity], [OpeningQuantity], [ClosingQuantity], [ReferenceId], [TableReference], [Note], [CreatedDate]) VALUES (20042, 40007, 1184, 1187, 1184, N'ORD-2020070000000016', N'Sales Order', N'Generated From Orders/CreateCCOrder', CAST(N'2020-07-25 03:38:22.073' AS DateTime))
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
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (19, N'Jerome@gmail.com', 6, N'Jerome@gmail.com', NULL, NULL, NULL, NULL, CAST(N'2020-06-20 12:52:51.933' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (20, N'Jerome@gmai.com', 7, N'Jerome@gmai.com', NULL, NULL, NULL, NULL, CAST(N'2020-06-20 12:54:20.560' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (24, N'Jrome.gds.@gdas.cc', 4, N'Jrome.gds.@gdas.cc', NULL, NULL, NULL, NULL, CAST(N'2020-06-20 12:56:15.980' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (29, N'Jrome.gds.@gdas.ccccc', 6, N'Jrome.gds.@gdas.ccccc', NULL, NULL, NULL, NULL, CAST(N'2020-06-20 13:21:11.593' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (35, N'AbdHsnn@gmail.com', 6, N'AbdHsnn@gmail.com', NULL, NULL, NULL, NULL, CAST(N'2020-07-04 10:58:16.187' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (36, N'Riaz@gamil.com', 5, N'Riaz@gamil.com', NULL, NULL, NULL, NULL, CAST(N'2020-07-04 11:12:13.443' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (37, N'Tamim@gmail.com', 4, N'Tamim@gmail.com', NULL, NULL, NULL, NULL, CAST(N'2020-07-04 11:13:26.293' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (38, N'Shajeeb@gmail.com', 7, N'Shajeeb@gmail.com', NULL, NULL, NULL, NULL, CAST(N'2020-07-04 16:24:52.457' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [UserTypeId], [Email], [Password], [TempField], [SmallImage], [BigImage], [CreateDate]) VALUES (39, N'Shumi@gmail.com', 5, N'Shumi@gmail.com', NULL, NULL, NULL, NULL, CAST(N'2020-07-04 16:29:41.307' AS DateTime))
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
/****** Object:  Index [UQ__Authoriz__1788CC4D637E3E3C]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Authorizations] ADD UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Authoriz__D4E7DFA8FF8BEC50]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[AuthorizeType] ADD UNIQUE NONCLUSTERED 
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__BalanceS__3C28DC1757DEE2E0]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[BalanceSourceType] ADD UNIQUE NONCLUSTERED 
(
	[SourceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Brand__737584F6616BEA47]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Brand] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Customer__5C7E359E1A832AA5]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Customers] ADD UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Customer__A9D10534A2069543]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Customers] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Damage__8A0F294842C6BD9D]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Damage] ADD UNIQUE NONCLUSTERED 
(
	[DamageNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Designat__D4E7DFA8C228D24F]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[DesignationTypes] ADD UNIQUE NONCLUSTERED 
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Manufact__3B9CDE2EE0CEF4E2]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Manufacturer] ADD UNIQUE NONCLUSTERED 
(
	[ManufacturerName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Orders__C3907C75D1585BAD]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [UQ__Orders__C3907C75D1585BAD] UNIQUE NONCLUSTERED 
(
	[OrderNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Payment__554342D9B731789B]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Payment] ADD  CONSTRAINT [UQ__Payment__554342D9B731789B] UNIQUE NONCLUSTERED 
(
	[TransactionNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__PaymentM__737584F66248325C]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[PaymentMethods] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Personal__1788CC4D4B2A1430]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[PersonalDetail] ADD  CONSTRAINT [UQ__Personal__1788CC4D4B2A1430] UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Products__2F4E024FA30573CB]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [UQ__Products__2F4E024FA30573CB] UNIQUE NONCLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Purchase__6B0A9314353F90ED]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Purchase] ADD  CONSTRAINT [UQ__Purchase__6B0A9314353F90ED] UNIQUE NONCLUSTERED 
(
	[PurchaseNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Purchase__2C2936398048BAC2]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[PurchaseReturn] ADD UNIQUE NONCLUSTERED 
(
	[PurchaseReturnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Refunds__725A61B258C99BF1]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Refunds] ADD UNIQUE NONCLUSTERED 
(
	[RefundNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__SalesRet__E09004660ED3F87E]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[SalesReturn] ADD UNIQUE NONCLUSTERED 
(
	[SalesReturnNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__StockAdj__E60D0EF175548E97]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[StockAdjustment] ADD UNIQUE NONCLUSTERED 
(
	[AdjustmentNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__ProductG__2F4E024F572B4401]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[SunglassDetail] ADD  CONSTRAINT [UQ__ProductG__2F4E024F572B4401] UNIQUE NONCLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Supplier__5C7E359E7BECE177]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Supplier] ADD UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Supplier__A9D10534FFA32ADD]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Supplier] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Users__A9D10534D36E8D6C]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__A9D10534D36E8D6C] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Users__C9F284566E18A7D7]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__UserType__D4E7DFA807F3DAE4]    Script Date: 7/26/2020 8:27:22 AM ******/
ALTER TABLE [dbo].[UserType] ADD  CONSTRAINT [UQ__UserType__D4E7DFA807F3DAE4] UNIQUE NONCLUSTERED 
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Authorizations]  WITH CHECK ADD FOREIGN KEY([AuthorizeTypeId])
REFERENCES [dbo].[AuthorizeType] ([Id])
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
ALTER TABLE [dbo].[SalesTransaction]  WITH CHECK ADD FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethods] ([Id])
GO
