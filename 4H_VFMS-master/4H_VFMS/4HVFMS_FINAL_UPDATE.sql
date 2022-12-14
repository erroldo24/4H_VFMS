USE [master]

CREATE DATABASE [VFMS_DB]
 CONTAINMENT = NONE

GO
ALTER DATABASE [VFMS_DB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VFMS_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VFMS_DB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [VFMS_DB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [VFMS_DB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [VFMS_DB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [VFMS_DB] SET ARITHABORT ON 
GO
ALTER DATABASE [VFMS_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VFMS_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VFMS_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VFMS_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VFMS_DB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [VFMS_DB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [VFMS_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VFMS_DB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [VFMS_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VFMS_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VFMS_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VFMS_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VFMS_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VFMS_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VFMS_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VFMS_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VFMS_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VFMS_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [VFMS_DB] SET  MULTI_USER 
GO
ALTER DATABASE [VFMS_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VFMS_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VFMS_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VFMS_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VFMS_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VFMS_DB] SET QUERY_STORE = OFF
GO
USE [VFMS_DB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [VFMS_DB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gender]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[gender] [varchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[position]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[position](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[position] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDriverList]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDriverList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[dTitle] [int] NOT NULL,
	[dFirstName] [varchar](30) NOT NULL,
	[dLastName] [varchar](30) NOT NULL,
	[dGender] [int] NOT NULL,
	[dPosition] [int] NOT NULL,
	[dLicense] [varchar](30) NOT NULL,
	[dLicenseExpiry] [varchar](30) NOT NULL,
	[dStatus] [varchar](3) NULL,
	[createdBy] [varchar](50) NULL,
	[dateCreated] [datetime] NULL,
	[updatedBy] [varchar](50) NULL,
	[dateUpdated] [datetime] NULL,
	[deletedBy] [varchar](50) NULL,
	[deleteFlag] [varchar](3) NULL,
	[dateDeleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[dLicense] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserList]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[uTitle] [int] NOT NULL,
	[uFirstName] [varchar](30) NOT NULL,
	[uLastName] [varchar](30) NOT NULL,
	[uGender] [int] NOT NULL,
	[uPosition] [int] NOT NULL,
	[uTrn] [varchar](9) NOT NULL,
	[uLogin] [varchar](30) NOT NULL,
	[uPassword] [varchar](30) NOT NULL,
	[createdBy] [varchar](50) NULL,
	[dateCreated] [datetime] NULL,
	[updatedBy] [varchar](50) NULL,
	[dateUpdated] [datetime] NULL,
	[deletedBy] [varchar](50) NULL,
	[deleteFlag] [varchar](3) NULL,
	[dateDeleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[uTrn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVehicleAssignment]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVehicleAssignment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[dId] [int] NOT NULL,
	[vId] [int] NOT NULL,
	[vAssignOutDate] [datetime] NULL,
	[vAssignDuration] [int] NOT NULL,
	[vAssignInDate] [datetime] NULL,
	[vAssignUsed] [int] NULL,
	[vMileageOut] [int] NOT NULL,
	[vMileageIn] [int] NULL,
	[vMileageTravelled] [int] NULL,
	[createdBy] [varchar](50) NULL,
	[dateCreated] [datetime] NULL,
	[updatedBy] [varchar](50) NULL,
	[dateUpdated] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVehicleList]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVehicleList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[vType] [int] NOT NULL,
	[vYear] [int] NOT NULL,
	[vColour] [int] NOT NULL,
	[vTransType] [int] NOT NULL,
	[vLicPlate] [varchar](6) NOT NULL,
	[vStatus] [int] NOT NULL,
	[createdBy] [varchar](50) NULL,
	[dateCreated] [datetime] NULL,
	[updatedBy] [varchar](50) NULL,
	[dateUpdated] [datetime] NULL,
	[deletedBy] [varchar](50) NULL,
	[deleteFlag] [varchar](3) NULL,
	[dateDeleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[title]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[title](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vColour]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vColour](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[vColour] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vStatus]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[vStatus] [varchar](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vTransType]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vTransType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[vTransType] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vType]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[vType] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vYear]    Script Date: 8/16/2022 9:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vYear](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[vYear] [varchar](4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 8/16/2022 9:53:40 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 8/16/2022 9:53:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 8/16/2022 9:53:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 8/16/2022 9:53:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 8/16/2022 9:53:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 8/16/2022 9:53:40 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[tblDriverList]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_dGender] FOREIGN KEY([dGender])
REFERENCES [dbo].[gender] ([Id])
GO
ALTER TABLE [dbo].[tblDriverList] CHECK CONSTRAINT [FK_tblUserList_dGender]
GO
ALTER TABLE [dbo].[tblDriverList]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_dPosition] FOREIGN KEY([dPosition])
REFERENCES [dbo].[position] ([Id])
GO
ALTER TABLE [dbo].[tblDriverList] CHECK CONSTRAINT [FK_tblUserList_dPosition]
GO
ALTER TABLE [dbo].[tblDriverList]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_dTitle] FOREIGN KEY([dTitle])
REFERENCES [dbo].[title] ([Id])
GO
ALTER TABLE [dbo].[tblDriverList] CHECK CONSTRAINT [FK_tblUserList_dTitle]
GO
ALTER TABLE [dbo].[tblUserList]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_gender] FOREIGN KEY([uGender])
REFERENCES [dbo].[gender] ([Id])
GO
ALTER TABLE [dbo].[tblUserList] CHECK CONSTRAINT [FK_tblUserList_gender]
GO
ALTER TABLE [dbo].[tblUserList]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_position] FOREIGN KEY([uPosition])
REFERENCES [dbo].[position] ([Id])
GO
ALTER TABLE [dbo].[tblUserList] CHECK CONSTRAINT [FK_tblUserList_position]
GO
ALTER TABLE [dbo].[tblUserList]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_title] FOREIGN KEY([uTitle])
REFERENCES [dbo].[title] ([Id])
GO
ALTER TABLE [dbo].[tblUserList] CHECK CONSTRAINT [FK_tblUserList_title]
GO
ALTER TABLE [dbo].[tblVehicleAssignment]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_dId] FOREIGN KEY([dId])
REFERENCES [dbo].[tblDriverList] ([Id])
GO
ALTER TABLE [dbo].[tblVehicleAssignment] CHECK CONSTRAINT [FK_tblUserList_dId]
GO
ALTER TABLE [dbo].[tblVehicleList]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_vColour] FOREIGN KEY([vColour])
REFERENCES [dbo].[vColour] ([Id])
GO
ALTER TABLE [dbo].[tblVehicleList] CHECK CONSTRAINT [FK_tblUserList_vColour]
GO
ALTER TABLE [dbo].[tblVehicleList]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_vStatus] FOREIGN KEY([vStatus])
REFERENCES [dbo].[vStatus] ([Id])
GO
ALTER TABLE [dbo].[tblVehicleList] CHECK CONSTRAINT [FK_tblUserList_vStatus]
GO
ALTER TABLE [dbo].[tblVehicleList]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_vTransType] FOREIGN KEY([vTransType])
REFERENCES [dbo].[vTransType] ([Id])
GO
ALTER TABLE [dbo].[tblVehicleList] CHECK CONSTRAINT [FK_tblUserList_vTransType]
GO
ALTER TABLE [dbo].[tblVehicleList]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_vType] FOREIGN KEY([vType])
REFERENCES [dbo].[vType] ([Id])
GO
ALTER TABLE [dbo].[tblVehicleList] CHECK CONSTRAINT [FK_tblUserList_vType]
GO
ALTER TABLE [dbo].[tblVehicleList]  WITH CHECK ADD  CONSTRAINT [FK_tblUserList_vYear] FOREIGN KEY([vYear])
REFERENCES [dbo].[vYear] ([Id])
GO
ALTER TABLE [dbo].[tblVehicleList] CHECK CONSTRAINT [FK_tblUserList_vYear]
GO
USE [master]
GO
ALTER DATABASE [VFMS_DB] SET  READ_WRITE 
GO

USE [VFMS_DB]
GO

INSERT INTO dbo.gender(gender)
VALUES
    ('Male'), ('Female');

INSERT INTO dbo.position(position)
VALUES
    ('Admin'), ('Manager'), ('Supervior'), ('Clerk'), ('Driver');
	
INSERT INTO dbo.title(title)
VALUES
    ('Mr.'), ('Mrs.'), ('Ms.'), ('Dr.');
	
INSERT INTO dbo.vColour(vColour)
VALUES
    ('White'), ('Black'), ('Grey'), ('Blue'), ('Red');

INSERT INTO dbo.vStatus(vStatus)
VALUES
    ('Yes'), ('No');
	
INSERT INTO dbo.vTransType(vTransType)
VALUES
    ('Automatic'), ('Standard');
	
INSERT INTO dbo.vType(vType)
VALUES
    ('Car'), ('Van'), ('Truck'), ('Pickup'), ('Bus'),('Tractor'), ('Motor Cycle'), ('Backhoe');
INSERT INTO dbo.vYear(vYear)
VALUES
    (1980), (1981), (1982), (1983), (1984), (1985), (1986), (1987), (1988), (1989),
	(1990), (1991), (1992), (1993), (1994), (1995), (1996), (1997), (1998), (1999),
	(2000), (2001), (2002), (2003), (2004), (2005), (2006), (2007), (2008), (2009),
	(2010), (2011), (2012), (2013), (2014), (2015), (2016), (2017), (2018), (2019),
	(2020), (2021), (2022), (2023), (2024), (2025), (2026), (2027), (2028), (2029), (2030)
	
INSERT INTO [dbo].[tblUserList]
     ([uFirstName], [uLastName], [uGender], [uPosition], [uTrn], [uLogin], [uPassword], [uTitle])
VALUES
     ('John', 'Brown', 1, 1, '123456789', 'jbrown', 'admin1234', 1);  

INSERT INTO [dbo].[tblDriverList]
      ([dFirstName], [dLastName], [dGender], [dPosition], [dTitle], [dLicense], [dLicenseExpiry], [dStatus])
VALUES
      ('Micheal', 'Pryce', 1, 4, 1, '458569815', '2026-06-12', 'Yes');

INSERT INTO dbo.tblVehicleList
	(vType, vYear, vColour, vTransType, vLicPlate, vStatus)
VALUES
	(1,20,1,1,'KB1023', 1);