USE [master]
GO
/****** Object:  Database [herbStore_dev_db]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE DATABASE [herbStore_dev_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'herbStore_dev_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\herbStore_dev_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'herbStore_dev_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\herbStore_dev_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [herbStore_dev_db] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [herbStore_dev_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [herbStore_dev_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [herbStore_dev_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [herbStore_dev_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [herbStore_dev_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET TRUSTWORTHY ON 
GO
ALTER DATABASE [herbStore_dev_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [herbStore_dev_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [herbStore_dev_db] SET  MULTI_USER 
GO
ALTER DATABASE [herbStore_dev_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [herbStore_dev_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [herbStore_dev_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [herbStore_dev_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [herbStore_dev_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [herbStore_dev_db] SET QUERY_STORE = OFF
GO
USE [herbStore_dev_db]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Access] [nvarchar](max) NULL,
	[IsSystemRole] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[GenderId] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[City] [nvarchar](max) NULL,
	[CountryId] [int] NOT NULL,
	[StudentNumber] [nvarchar](max) NULL,
	[ParmanentAddress] [nvarchar](max) NULL,
	[AffiliateId] [bigint] NOT NULL,
	[UserImageUrl] [nvarchar](max) NULL,
	[DormitoryId] [bigint] NOT NULL,
	[AdminComment] [nvarchar](max) NULL,
	[NewsletterSubscription] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[LastIpAddress] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL,
	[LastLoginDateUtc] [datetime2](7) NULL,
	[LastActivityDateUtc] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartProducts]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartProducts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CartId] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ProductId] [bigint] NOT NULL,
 CONSTRAINT [PK_CartProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[Quantity] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diseases]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diseases](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DiseaseName] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[DiseaseDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_Diseases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Telephone] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HospitalDisease]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HospitalDisease](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HospitalId] [bigint] NOT NULL,
	[DiseaseId] [bigint] NOT NULL,
 CONSTRAINT [PK_HospitalDisease] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hospitals]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hospitals](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HospitalName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DieseaseName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Hospitals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProducts]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProducts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[Address] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[OrderStatus] [bit] NOT NULL,
	[Cvv] [nvarchar](max) NULL,
	[ExpiryDate] [nvarchar](max) NULL,
	[NameOnCard] [nvarchar](max) NULL,
	[PaymentType] [bit] NOT NULL,
	[TotalAmount] [float] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDisease]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDisease](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[DiseaseId] [bigint] NOT NULL,
 CONSTRAINT [PK_ProductDisease] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 31-Dec-19 9:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[ProductType] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[OldPrice] [float] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Feature] [nvarchar](max) NULL,
	[PrimaryCare] [nvarchar](max) NULL,
	[SecondaryCare] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191229022920_initial-migration', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191229071131_addedOurEntities', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191229071638_updatedRelationships', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191229185837_addedMorePropertiesInHospital', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191229193949_addedCreatedONINFeedback', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191230153816_updatedDataTypeOrderStatus', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191230155657_resolvedarelationship', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191230164904_addedQuantityandOtherProperties', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191230184205_updatedCartRelationship', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191231153155_addedDisease', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191231160614_addedDiseaseDescription', N'2.2.6-servicing-10079')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Access], [IsSystemRole], [IsActive], [CreatedOnUtc]) VALUES (N'0f2b84db-52c5-47e3-a00f-5bbd5311ff1e', N'Administrator', N'ADMINISTRATOR', N'8eaaba97-6002-488f-98c5-dbcc8b781fc0', NULL, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Access], [IsSystemRole], [IsActive], [CreatedOnUtc]) VALUES (N'37455409-eab1-4c77-99b3-f263fe25dbaf', N'Registered', N'REGISTERED', N'2c6de3ad-d73b-4464-8ae2-584a813c6df0', NULL, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5fad00c3-5b7b-45b1-96ea-f2e47ca1cbb3', N'0f2b84db-52c5-47e3-a00f-5bbd5311ff1e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a5f33d08-648f-4980-a926-0d30bacc7f4b', N'0f2b84db-52c5-47e3-a00f-5bbd5311ff1e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bcd27789-cc92-4444-aa30-9f8c50d1b91e', N'37455409-eab1-4c77-99b3-f263fe25dbaf')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fede52d1-d581-47f2-9044-0241b29d53d3', N'37455409-eab1-4c77-99b3-f263fe25dbaf')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [GenderId], [FirstName], [LastName], [DateOfBirth], [City], [CountryId], [StudentNumber], [ParmanentAddress], [AffiliateId], [UserImageUrl], [DormitoryId], [AdminComment], [NewsletterSubscription], [Active], [Deleted], [LastIpAddress], [CreatedOnUtc], [LastLoginDateUtc], [LastActivityDateUtc]) VALUES (N'16a12a50-1f52-480f-a13d-8015b53f50a1', N'mjahun@gmail.com', N'MJAHUN@GMAIL.COM', N'mjahun@gmail.com', N'MJAHUN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGZuqgxqwayvA86ftcEyAr0EKI3WQlmDTjbGjsh/pCQLi78t+/wqUaCVXls2YZETYg==', N'MSTQDNSNOMPH6EKEUDQ7CE3OFUTQ7CC4', N'2822ea98-758d-465a-bee7-48f758141b0c', NULL, 0, 0, NULL, 1, 0, 0, N'Musa', N'Jahun', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, NULL, 0, NULL, 0, NULL, 0, 1, 0, NULL, CAST(N'2019-12-29T05:26:26.4448656' AS DateTime2), NULL, CAST(N'2019-12-29T05:26:26.4448685' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [GenderId], [FirstName], [LastName], [DateOfBirth], [City], [CountryId], [StudentNumber], [ParmanentAddress], [AffiliateId], [UserImageUrl], [DormitoryId], [AdminComment], [NewsletterSubscription], [Active], [Deleted], [LastIpAddress], [CreatedOnUtc], [LastLoginDateUtc], [LastActivityDateUtc]) VALUES (N'5fad00c3-5b7b-45b1-96ea-f2e47ca1cbb3', N'Customer@gmail.com', N'CUSTOMER@GMAIL.COM', N'Customer@gmail.com', N'CUSTOMER@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAOUykhASZuQYEZW6WMAMQhX4Hj+YXwiwWi3nenXbvbfuLksEmEI55KjoJYVOH1jHA==', N'IGFTERIKLGHI25M6GQO23S5O3AWSSSGU', N'573583b5-3858-4951-b640-e245fa51b6b2', NULL, 0, 0, NULL, 1, 0, 0, N'Customer', N'_', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, NULL, 0, NULL, 0, NULL, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-12-29T04:06:07.4360990' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [GenderId], [FirstName], [LastName], [DateOfBirth], [City], [CountryId], [StudentNumber], [ParmanentAddress], [AffiliateId], [UserImageUrl], [DormitoryId], [AdminComment], [NewsletterSubscription], [Active], [Deleted], [LastIpAddress], [CreatedOnUtc], [LastLoginDateUtc], [LastActivityDateUtc]) VALUES (N'6811255d-851a-426b-90ee-529175a654ab', N'msjahuuun@live.com', N'MSJAHUUUN@LIVE.COM', N'msjahuuun@live.com', N'MSJAHUUUN@LIVE.COM', 0, N'AQAAAAEAACcQAAAAEEzBgaLMmrjFFVKomxoLKiBQmlAxNC70acDArp5BOs3cwCYN4U6yUJSEihaG4oeItg==', N'WJ6HEO3LQJSSUBXIQY6AKV4G3V2C3JTJ', N'fd9c86ef-3ec4-4295-ac0d-1c0456f86ea4', NULL, 0, 0, NULL, 1, 0, 0, N'Musa', N'Jahun', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, NULL, 0, NULL, 0, NULL, 0, 1, 0, NULL, CAST(N'2019-12-29T05:41:04.8560000' AS DateTime2), NULL, CAST(N'2019-12-29T05:41:04.8560189' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [GenderId], [FirstName], [LastName], [DateOfBirth], [City], [CountryId], [StudentNumber], [ParmanentAddress], [AffiliateId], [UserImageUrl], [DormitoryId], [AdminComment], [NewsletterSubscription], [Active], [Deleted], [LastIpAddress], [CreatedOnUtc], [LastLoginDateUtc], [LastActivityDateUtc]) VALUES (N'a5f33d08-648f-4980-a926-0d30bacc7f4b', N'Administrator@live.com', N'ADMINISTRATOR@LIVE.COM', N'Administrator@live.com', N'ADMINISTRATOR@LIVE.COM', 0, N'AQAAAAEAACcQAAAAENJZnwlkaUFVGEe03AggVj3gjSnfTbwbDXQQqWdas/LT+cc8VjzuVdJqd0jmIT6klQ==', N'O44XGWJTLXCF7SMSWACGDZQSI3SYV7LK', N'c5c1a69d-b5fc-4868-ad13-cf76036380b5', NULL, 0, 0, NULL, 1, 0, 0, N'Admin', N'Admin', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, NULL, 0, NULL, 0, NULL, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-12-31T16:45:11.1099535' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [GenderId], [FirstName], [LastName], [DateOfBirth], [City], [CountryId], [StudentNumber], [ParmanentAddress], [AffiliateId], [UserImageUrl], [DormitoryId], [AdminComment], [NewsletterSubscription], [Active], [Deleted], [LastIpAddress], [CreatedOnUtc], [LastLoginDateUtc], [LastActivityDateUtc]) VALUES (N'bcd27789-cc92-4444-aa30-9f8c50d1b91e', N'msjahunJ@live.com', N'MSJAHUNJ@LIVE.COM', N'msjahunJ@live.com', N'MSJAHUNJ@LIVE.COM', 0, N'AQAAAAEAACcQAAAAEAdQKjbo8WNhcOCGhDy1Ok71f3IlvwHOVyVEd+EeNidMtYT7uuncx2jXUXp0VgDJiA==', N'24MEJ7JCZBYO4NJEFO6OGXUDFOX5U2D5', N'227f1d9b-4fa7-4328-b812-5dec3219ce9f', NULL, 0, 0, NULL, 1, 0, 0, N'Musa', N'Jahun', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, NULL, 0, NULL, 0, NULL, 0, 1, 0, NULL, CAST(N'2019-12-31T21:35:40.1732771' AS DateTime2), CAST(N'2019-12-31T19:35:47.2560225' AS DateTime2), CAST(N'2019-12-31T21:35:40.1734184' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [GenderId], [FirstName], [LastName], [DateOfBirth], [City], [CountryId], [StudentNumber], [ParmanentAddress], [AffiliateId], [UserImageUrl], [DormitoryId], [AdminComment], [NewsletterSubscription], [Active], [Deleted], [LastIpAddress], [CreatedOnUtc], [LastLoginDateUtc], [LastActivityDateUtc]) VALUES (N'e27d6d63-fa58-4aa7-a0fc-0f5bcc7bf1db', N'msjahun@live.com', N'MSJAHUN@LIVE.COM', N'msjahun@live.com', N'MSJAHUN@LIVE.COM', 0, N'AQAAAAEAACcQAAAAEFg89Yz7PXGNoYBjBEMW60V5QsAXIkhlVMhBgBy6aESphvdRovTtSeYrNvRBxHAkuQ==', N'LFNTNUZWSEP32C3EQLUD2Z5L4O2PGE5O', N'91d84db2-70e0-42c7-8a8c-47fb3faee191', NULL, 0, 0, NULL, 1, 0, 0, N'Musa', N'Jahun', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, NULL, 0, NULL, 0, NULL, 0, 1, 0, NULL, CAST(N'2019-12-29T05:37:56.8188726' AS DateTime2), CAST(N'2019-12-31T19:30:26.4567705' AS DateTime2), CAST(N'2019-12-29T05:37:56.8188748' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [GenderId], [FirstName], [LastName], [DateOfBirth], [City], [CountryId], [StudentNumber], [ParmanentAddress], [AffiliateId], [UserImageUrl], [DormitoryId], [AdminComment], [NewsletterSubscription], [Active], [Deleted], [LastIpAddress], [CreatedOnUtc], [LastLoginDateUtc], [LastActivityDateUtc]) VALUES (N'fede52d1-d581-47f2-9044-0241b29d53d3', N'msjahuf3d@live.com', N'MSJAHUF3D@LIVE.COM', N'msjahuf3d@live.com', N'MSJAHUF3D@LIVE.COM', 0, N'AQAAAAEAACcQAAAAEO0phBifXVHVuw6bcrUWWHx8VDggYxvhrHrrCeFyp3dlJkOICXPew0p2D3EJ3xLrPw==', N'FULDTCE74B7DBPZ53QSSEAJXPZ45BK3U', N'c6e87c94-c7e1-4f27-bdb9-b3b8fddf1126', NULL, 0, 0, NULL, 1, 0, 0, N'Musa', N'Jahun', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, NULL, 0, NULL, 0, NULL, 0, 1, 0, NULL, CAST(N'2019-12-29T06:04:14.5954523' AS DateTime2), NULL, CAST(N'2019-12-29T06:04:14.5955851' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Carts] ON 

INSERT [dbo].[Carts] ([Id], [UserId], [Quantity], [CreatedOn]) VALUES (9, N'e27d6d63-fa58-4aa7-a0fc-0f5bcc7bf1db', 1, CAST(N'2019-12-31T16:58:22.9398860' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Carts] OFF
SET IDENTITY_INSERT [dbo].[Diseases] ON 

INSERT [dbo].[Diseases] ([Id], [DiseaseName], [CreatedOn], [DiseaseDescription]) VALUES (1, N'Tuberculosis ', CAST(N'2019-12-31T18:07:18.3193152' AS DateTime2), N'This has to do with lungs')
INSERT [dbo].[Diseases] ([Id], [DiseaseName], [CreatedOn], [DiseaseDescription]) VALUES (2, N'Sickness', CAST(N'2019-12-31T18:07:40.4162124' AS DateTime2), N'Has to do with health')
INSERT [dbo].[Diseases] ([Id], [DiseaseName], [CreatedOn], [DiseaseDescription]) VALUES (4, N'cold', CAST(N'2019-12-31T21:30:04.8601933' AS DateTime2), N'severe')
SET IDENTITY_INSERT [dbo].[Diseases] OFF
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([Id], [Name], [Email], [Telephone], [Subject], [Message], [CreatedOn]) VALUES (2, N'Musa Suleiman Jahun', N'mjahun@gmail.com', NULL, N'mjahun@gmail.com', N'Hello, I''ll like to ask a question', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Feedback] ([Id], [Name], [Email], [Telephone], [Subject], [Message], [CreatedOn]) VALUES (3, N'Musa Jahun', N'mjahun@gmail.com', NULL, N'mjahun@gmail.com', N'Sample Feedback message', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Feedback] ([Id], [Name], [Email], [Telephone], [Subject], [Message], [CreatedOn]) VALUES (4, N'Musa Suleiman Jahun', N'mjahun@gmail.com', NULL, N'mjahun@gmail.com', N'Testing 401 redirect', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Feedback] OFF
SET IDENTITY_INSERT [dbo].[HospitalDisease] ON 

INSERT [dbo].[HospitalDisease] ([Id], [HospitalId], [DiseaseId]) VALUES (35, 4, 1)
INSERT [dbo].[HospitalDisease] ([Id], [HospitalId], [DiseaseId]) VALUES (36, 4, 2)
INSERT [dbo].[HospitalDisease] ([Id], [HospitalId], [DiseaseId]) VALUES (37, 1, 2)
SET IDENTITY_INSERT [dbo].[HospitalDisease] OFF
SET IDENTITY_INSERT [dbo].[Hospitals] ON 

INSERT [dbo].[Hospitals] ([Id], [HospitalName], [Description], [DieseaseName], [Address], [ImageUrl]) VALUES (1, N'Hospital Name updated', N'Hospital Description', N'Diesease Name', N'Hospital Address', N'/Files/Images/Hospitals/77cee9b9-cba2-4969-9722-076c65c34e36.png')
INSERT [dbo].[Hospitals] ([Id], [HospitalName], [Description], [DieseaseName], [Address], [ImageUrl]) VALUES (4, N'Hospital Name3', N'Hospital Description', N'Diesease Name33', N'Seattle, WA 98102, USA', N'/Files/Images/Hospitals/89c9e53a-3452-4890-a408-1271bc9234b6.png')
SET IDENTITY_INSERT [dbo].[Hospitals] OFF
SET IDENTITY_INSERT [dbo].[OrderProducts] ON 

INSERT [dbo].[OrderProducts] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (6, 3, 8, 4)
INSERT [dbo].[OrderProducts] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (7, 3, 10, 2)
INSERT [dbo].[OrderProducts] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (8, 3, 9, 6)
INSERT [dbo].[OrderProducts] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (9, 3, 13, 2)
INSERT [dbo].[OrderProducts] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (11, 5, 8, 1)
INSERT [dbo].[OrderProducts] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (12, 6, 9, 0)
INSERT [dbo].[OrderProducts] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (13, 6, 10, 1)
INSERT [dbo].[OrderProducts] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (14, 6, 8, 11)
INSERT [dbo].[OrderProducts] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (15, 6, 13, 1)
INSERT [dbo].[OrderProducts] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (16, 7, 9, 1)
SET IDENTITY_INSERT [dbo].[OrderProducts] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [UserId], [Address], [CreatedOn], [OrderStatus], [Cvv], [ExpiryDate], [NameOnCard], [PaymentType], [TotalAmount]) VALUES (3, N'a5f33d08-648f-4980-a926-0d30bacc7f4b', NULL, CAST(N'2019-12-30T23:54:15.2808750' AS DateTime2), 1, N'0', NULL, NULL, 0, 6216)
INSERT [dbo].[Orders] ([Id], [UserId], [Address], [CreatedOn], [OrderStatus], [Cvv], [ExpiryDate], [NameOnCard], [PaymentType], [TotalAmount]) VALUES (5, N'e27d6d63-fa58-4aa7-a0fc-0f5bcc7bf1db', NULL, CAST(N'2019-12-31T00:06:28.5123928' AS DateTime2), 1, N'0', NULL, NULL, 0, 444)
INSERT [dbo].[Orders] ([Id], [UserId], [Address], [CreatedOn], [OrderStatus], [Cvv], [ExpiryDate], [NameOnCard], [PaymentType], [TotalAmount]) VALUES (6, N'e27d6d63-fa58-4aa7-a0fc-0f5bcc7bf1db', NULL, CAST(N'2019-12-31T05:24:52.9110573' AS DateTime2), 0, N'0', NULL, NULL, 0, 5772)
INSERT [dbo].[Orders] ([Id], [UserId], [Address], [CreatedOn], [OrderStatus], [Cvv], [ExpiryDate], [NameOnCard], [PaymentType], [TotalAmount]) VALUES (7, N'e27d6d63-fa58-4aa7-a0fc-0f5bcc7bf1db', NULL, CAST(N'2019-12-31T16:58:16.1278456' AS DateTime2), 0, N'0', NULL, NULL, 0, 444)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[ProductDisease] ON 

INSERT [dbo].[ProductDisease] ([Id], [ProductId], [DiseaseId]) VALUES (2, 8, 2)
INSERT [dbo].[ProductDisease] ([Id], [ProductId], [DiseaseId]) VALUES (3, 9, 1)
INSERT [dbo].[ProductDisease] ([Id], [ProductId], [DiseaseId]) VALUES (4, 9, 2)
INSERT [dbo].[ProductDisease] ([Id], [ProductId], [DiseaseId]) VALUES (5, 10, 1)
INSERT [dbo].[ProductDisease] ([Id], [ProductId], [DiseaseId]) VALUES (7, 13, 1)
SET IDENTITY_INSERT [dbo].[ProductDisease] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductName], [ProductType], [Price], [OldPrice], [Description], [Feature], [PrimaryCare], [SecondaryCare], [ImageUrl], [CreatedOn]) VALUES (8, N'New fruit 3443', 2, 444, 500, N'dfgdfgsdfggsdg', N'sdfgdsfgsdfg', N'sdfgdsfggsd', N'sdfgdfsg', N'/Files/Images/Products/c3c7c501-eb4d-4cb8-ac11-d5528c948018.png', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [ProductName], [ProductType], [Price], [OldPrice], [Description], [Feature], [PrimaryCare], [SecondaryCare], [ImageUrl], [CreatedOn]) VALUES (9, N'New Fruit after update 4', 2, 444, 500, N'Yo have been updated', N'sdfgdsfgsdfg', N'sdfgdsfggsd', N'sdfgdfsg', N'/Files/Images/Products/45a109b5-f4ef-4dd4-907b-ca91df0d9dc1.png', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [ProductName], [ProductType], [Price], [OldPrice], [Description], [Feature], [PrimaryCare], [SecondaryCare], [ImageUrl], [CreatedOn]) VALUES (10, N'New Fruit after update', 2, 444, 500, N'Yo have been updated', N'sdfgdsfgsdfg', N'sdfgdsfggsd', N'sdfgdfsg', N'/Files/Images/Products/668d8368-dc53-4543-b3a4-fb03b3ecc5d3.png', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [ProductName], [ProductType], [Price], [OldPrice], [Description], [Feature], [PrimaryCare], [SecondaryCare], [ImageUrl], [CreatedOn]) VALUES (13, N'New fruit', 1, 444, 500, N'dfgdfgsdfggsdg', N'sdfgdsfgsdfg', N'sdfgdsfggsd', N'sdfgdfsg', N'/Files/Images/Products/78ed0151-ba6e-4439-b08d-f5be9daba6f6.png', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Products] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartProducts_CartId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartProducts_CartId] ON [dbo].[CartProducts]
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartProducts_ProductId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartProducts_ProductId] ON [dbo].[CartProducts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Carts_UserId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_Carts_UserId] ON [dbo].[Carts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HospitalDisease_DiseaseId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_HospitalDisease_DiseaseId] ON [dbo].[HospitalDisease]
(
	[DiseaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HospitalDisease_HospitalId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_HospitalDisease_HospitalId] ON [dbo].[HospitalDisease]
(
	[HospitalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderProducts_OrderId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderProducts_OrderId] ON [dbo].[OrderProducts]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderProducts_ProductId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderProducts_ProductId] ON [dbo].[OrderProducts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDisease_DiseaseId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDisease_DiseaseId] ON [dbo].[ProductDisease]
(
	[DiseaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDisease_ProductId]    Script Date: 31-Dec-19 9:37:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDisease_ProductId] ON [dbo].[ProductDisease]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Feedback] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedOn]
GO
ALTER TABLE [dbo].[OrderProducts] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [PaymentType]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CartProducts]  WITH CHECK ADD  CONSTRAINT [FK_CartProducts_Carts_CartId] FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartProducts] CHECK CONSTRAINT [FK_CartProducts_Carts_CartId]
GO
ALTER TABLE [dbo].[CartProducts]  WITH CHECK ADD  CONSTRAINT [FK_CartProducts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartProducts] CHECK CONSTRAINT [FK_CartProducts_Products_ProductId]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[HospitalDisease]  WITH CHECK ADD  CONSTRAINT [FK_HospitalDisease_Diseases_DiseaseId] FOREIGN KEY([DiseaseId])
REFERENCES [dbo].[Diseases] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HospitalDisease] CHECK CONSTRAINT [FK_HospitalDisease_Diseases_DiseaseId]
GO
ALTER TABLE [dbo].[HospitalDisease]  WITH CHECK ADD  CONSTRAINT [FK_HospitalDisease_Hospitals_HospitalId] FOREIGN KEY([HospitalId])
REFERENCES [dbo].[Hospitals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HospitalDisease] CHECK CONSTRAINT [FK_HospitalDisease_Hospitals_HospitalId]
GO
ALTER TABLE [dbo].[OrderProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrderProducts_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProducts] CHECK CONSTRAINT [FK_OrderProducts_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrderProducts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProducts] CHECK CONSTRAINT [FK_OrderProducts_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ProductDisease]  WITH CHECK ADD  CONSTRAINT [FK_ProductDisease_Diseases_DiseaseId] FOREIGN KEY([DiseaseId])
REFERENCES [dbo].[Diseases] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductDisease] CHECK CONSTRAINT [FK_ProductDisease_Diseases_DiseaseId]
GO
ALTER TABLE [dbo].[ProductDisease]  WITH CHECK ADD  CONSTRAINT [FK_ProductDisease_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductDisease] CHECK CONSTRAINT [FK_ProductDisease_Products_ProductId]
GO
USE [master]
GO
ALTER DATABASE [herbStore_dev_db] SET  READ_WRITE 
GO
