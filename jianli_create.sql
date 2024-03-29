USE [master]
GO
/****** Object:  Database [JianLi]    Script Date: 2019-07-12 23:50:05 ******/
CREATE DATABASE [JianLi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JianLi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\JianLi.mdf' , SIZE = 32768KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JianLi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\JianLi_log.LDF' , SIZE = 12352KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
GO
ALTER DATABASE [JianLi] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JianLi].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [JianLi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JianLi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JianLi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JianLi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JianLi] SET ARITHABORT OFF 
GO
ALTER DATABASE [JianLi] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [JianLi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JianLi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JianLi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JianLi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JianLi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JianLi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JianLi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JianLi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JianLi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JianLi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JianLi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JianLi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JianLi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JianLi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JianLi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JianLi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JianLi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JianLi] SET  MULTI_USER 
GO
ALTER DATABASE [JianLi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JianLi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JianLi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JianLi] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [JianLi] SET DELAYED_DURABILITY = DISABLED 
GO
USE [JianLi]
GO
/****** Object:  Table [dbo].[BookComments]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookComments](
	[CommentID] [uniqueidentifier] NOT NULL,
	[BookID] [int] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[UserID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Support] [int] NOT NULL,
	[Against] [int] NOT NULL,
 CONSTRAINT [PK_BookComments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookKeywords]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookKeywords](
	[BookId] [int] NOT NULL,
	[KeywordId] [int] NOT NULL,
 CONSTRAINT [PK_BookKeyword] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[KeywordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](max) NOT NULL,
	[BookRate] [tinyint] NOT NULL,
	[BookDesc] [nvarchar](max) NULL,
	[BookCover] [image] NULL,
	[BookDefaultFile] [int] NULL,
	[BookDefaultKeyword] [int] NULL,
	[BookPublishHouse] [nvarchar](50) NULL,
	[BookSubTitle] [nvarchar](max) NULL,
	[BookType] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookWriters]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookWriters](
	[BookId] [int] NOT NULL,
	[WriterId] [int] NOT NULL,
 CONSTRAINT [PK_BookWriter] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[WriterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
	[CategoryDesc] [nvarchar](max) NOT NULL,
	[CategoryParent] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Files]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[FileID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[FileDesc] [nvarchar](max) NULL,
	[FileVersion] [nvarchar](max) NOT NULL,
	[BookResource] [bit] NULL,
	[UserID] [int] NULL,
	[UploadDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Help]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Help](
	[HelpSubmitUser] [int] NOT NULL,
	[HelpTitle] [nvarchar](max) NOT NULL,
	[HelpContext] [nvarchar](max) NULL,
	[HelpAnswer] [nvarchar](max) NULL,
	[HelpAnswered] [bit] NOT NULL,
	[HelpID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Help] PRIMARY KEY CLUSTERED 
(
	[HelpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Keywords]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Keywords](
	[KeywordID] [int] IDENTITY(1,1) NOT NULL,
	[KeywordName] [nvarchar](max) NOT NULL,
	[KeywordDesc] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[KeywordRate] [int] NOT NULL,
	[KeywordSubPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Keyword] PRIMARY KEY CLUSTERED 
(
	[KeywordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectIterations]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectIterations](
	[ID] [uniqueidentifier] NOT NULL,
	[ProjectID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Order] [tinyint] NOT NULL,
 CONSTRAINT [PK_ProjectIterations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectModules]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectModules](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Parent] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ProjectModules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Desc] [nvarchar](max) NOT NULL,
	[RootModule] [uniqueidentifier] NOT NULL,
	[CurIteration] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectUsers]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUsers](
	[Project] [uniqueidentifier] NOT NULL,
	[User] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ProjectUsers] PRIMARY KEY CLUSTERED 
(
	[Project] ASC,
	[User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportExceptions]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportExceptions](
	[ReportID] [uniqueidentifier] NOT NULL,
	[UserID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[StackTrace] [nvarchar](max) NOT NULL,
	[UserWords] [nvarchar](max) NULL,
	[State] [int] NOT NULL,
	[SoftwareVersion] [nvarchar](50) NOT NULL,
	[SoftwareName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ReportException] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolusionToKeywords]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolusionToKeywords](
	[SolutionID] [uniqueidentifier] NOT NULL,
	[SolutionKeywordID] [uniqueidentifier] NOT NULL,
	[Rate] [tinyint] NOT NULL,
 CONSTRAINT [PK_SolusionKeywordKeywords] PRIMARY KEY CLUSTERED 
(
	[SolutionID] ASC,
	[SolutionKeywordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolutionKeywords]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolutionKeywords](
	[SolusionKeywordID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[SolutionKeywordName] [nvarchar](max) NOT NULL,
	[SolutionKeywordDesc] [nvarchar](max) NULL,
 CONSTRAINT [PK_SolutionKeywords] PRIMARY KEY CLUSTERED 
(
	[SolusionKeywordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Solutions]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solutions](
	[SolusionID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[SolutionPath] [nvarchar](max) NOT NULL,
	[SolutionDesc] [nvarchar](max) NULL,
	[RecentOpenTime] [datetime] NOT NULL,
	[MachineName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Solutions] PRIMARY KEY CLUSTERED 
(
	[SolusionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[ID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Parent] [uniqueidentifier] NOT NULL,
	[Priority] [tinyint] NOT NULL,
	[ProjectIterationID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ToolCategorys]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToolCategorys](
	[CategoryID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
	[CategoryDesc] [nvarchar](max) NULL,
	[CategoryParent] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ToolCategorys] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ToolDepends]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToolDepends](
	[ToolVersionID] [uniqueidentifier] NOT NULL,
	[DependToolVersionID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ToolDepends] PRIMARY KEY CLUSTERED 
(
	[ToolVersionID] ASC,
	[DependToolVersionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ToolFiles]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToolFiles](
	[FileID] [uniqueidentifier] NOT NULL,
	[ToolVersionID] [uniqueidentifier] NOT NULL,
	[FileTitle] [nvarchar](max) NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[FileRate] [int] NOT NULL,
 CONSTRAINT [PK_ToolFiles] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ToolPlugins]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToolPlugins](
	[ToolVersionID] [uniqueidentifier] NOT NULL,
	[PluginToolVersionID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ToolPlugins] PRIMARY KEY CLUSTERED 
(
	[ToolVersionID] ASC,
	[PluginToolVersionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tools]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tools](
	[ToolID] [uniqueidentifier] NOT NULL,
	[ToolName] [nvarchar](max) NOT NULL,
	[ToolSubPath] [nvarchar](max) NOT NULL,
	[ToolRate] [int] NOT NULL,
	[ToolDesc] [nvarchar](max) NULL,
	[ToolCompany] [nvarchar](max) NULL,
	[CategoryID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Tools] PRIMARY KEY CLUSTERED 
(
	[ToolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ToolVersions]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToolVersions](
	[VersionID] [uniqueidentifier] NOT NULL,
	[ToolID] [uniqueidentifier] NOT NULL,
	[SubPath] [nvarchar](max) NOT NULL,
	[VersionName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ToolVersions] PRIMARY KEY CLUSTERED 
(
	[VersionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User2]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User2](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DefaultProject] [uniqueidentifier] NULL,
 CONSTRAINT [PK_User2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserBooks]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserBooks](
	[UserID] [int] NOT NULL,
	[BookID] [int] NOT NULL,
	[BookRate] [int] NOT NULL,
	[BookReadCounts] [int] NOT NULL,
	[BookReadTime] [int] NOT NULL,
	[BookReadTick] [int] NOT NULL,
 CONSTRAINT [PK_UserBooks_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserKeywords]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserKeywords](
	[UserID] [int] NOT NULL,
	[KeywordID] [int] NOT NULL,
	[KeywordRate] [int] NOT NULL,
 CONSTRAINT [PK_UserKeywords] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[KeywordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[UserPassword] [nvarchar](20) NOT NULL,
	[UserLastBookTick] [int] NOT NULL,
	[UserLastLoginDate] [datetime] NOT NULL,
	[UserLoginCount] [int] NOT NULL,
	[UserLastCheckBookDate] [date] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkSpaceKeywords]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkSpaceKeywords](
	[WorkSpaceID] [int] NOT NULL,
	[KeywordID] [int] NOT NULL,
	[KeywordRate] [tinyint] NOT NULL,
 CONSTRAINT [PK_WorkSpaceKeywords] PRIMARY KEY CLUSTERED 
(
	[WorkSpaceID] ASC,
	[KeywordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkSpaces]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkSpaces](
	[WorkSpaceID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[WorkSpaceName] [nvarchar](50) NOT NULL,
	[WorkSpaceDesc] [nvarchar](max) NULL,
 CONSTRAINT [PK_WorkSpaces] PRIMARY KEY CLUSTERED 
(
	[WorkSpaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Writers]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Writers](
	[WriterID] [int] IDENTITY(1,1) NOT NULL,
	[WriterFullName] [nvarchar](max) NOT NULL,
	[WriterDesc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Writer] PRIMARY KEY CLUSTERED 
(
	[WriterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[ViewBook]    Script Date: 2019-07-12 23:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewBook]
AS
SELECT     dbo.Books.BookName, dbo.Books.BookRate, dbo.Books.BookDesc, dbo.Writers.WriterFullName, dbo.Writers.WriterDesc, dbo.Files.FileName, 
                      dbo.Files.FileDesc, dbo.Files.FilePath, dbo.Keyword.KeywordName, dbo.Keyword.KeywordDesc, dbo.Categorys.CategoryName, 
                      dbo.Categorys.CategoryDesc, dbo.Categorys.CategoryParent
FROM         dbo.BookFile INNER JOIN
                      dbo.Files ON dbo.BookFile.FileId = dbo.Files.ID INNER JOIN
                      dbo.BookKeyword INNER JOIN
                      dbo.Books ON dbo.BookKeyword.BookId = dbo.Books.ID INNER JOIN
                      dbo.BookWriter ON dbo.Books.ID = dbo.BookWriter.BookId ON dbo.BookFile.BookId = dbo.Books.ID INNER JOIN
                      dbo.Writers ON dbo.BookWriter.WriterId = dbo.Writers.ID INNER JOIN
                      dbo.Categorys INNER JOIN
                      dbo.Keyword ON dbo.Categorys.ID = dbo.Keyword.CategoryId ON dbo.BookKeyword.KeywordId = dbo.Keyword.ID

GO
ALTER TABLE [dbo].[SolutionKeywords] ADD  CONSTRAINT [DF_SolutionKeywords_SolusionKeywordID]  DEFAULT (newid()) FOR [SolusionKeywordID]
GO
ALTER TABLE [dbo].[Solutions] ADD  CONSTRAINT [DF_Solutions_SolusionID]  DEFAULT (newid()) FOR [SolusionID]
GO
ALTER TABLE [dbo].[ToolCategorys] ADD  CONSTRAINT [DF_ToolCategorys_CategoryID]  DEFAULT (newid()) FOR [CategoryID]
GO
ALTER TABLE [dbo].[BookComments]  WITH CHECK ADD  CONSTRAINT [FK_BookComments_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[BookComments] CHECK CONSTRAINT [FK_BookComments_Books]
GO
ALTER TABLE [dbo].[BookComments]  WITH CHECK ADD  CONSTRAINT [FK_BookComments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[BookComments] CHECK CONSTRAINT [FK_BookComments_Users]
GO
ALTER TABLE [dbo].[BookKeywords]  WITH CHECK ADD  CONSTRAINT [FK_BookKeyword_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookKeywords] CHECK CONSTRAINT [FK_BookKeyword_Books]
GO
ALTER TABLE [dbo].[BookKeywords]  WITH CHECK ADD  CONSTRAINT [FK_BookKeyword_Keyword] FOREIGN KEY([KeywordId])
REFERENCES [dbo].[Keywords] ([KeywordID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookKeywords] CHECK CONSTRAINT [FK_BookKeyword_Keyword]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Files] FOREIGN KEY([BookDefaultFile])
REFERENCES [dbo].[Files] ([FileID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Files]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Keywords] FOREIGN KEY([BookDefaultKeyword])
REFERENCES [dbo].[Keywords] ([KeywordID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Keywords]
GO
ALTER TABLE [dbo].[BookWriters]  WITH CHECK ADD  CONSTRAINT [FK_BookWriter_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookWriters] CHECK CONSTRAINT [FK_BookWriter_Books]
GO
ALTER TABLE [dbo].[BookWriters]  WITH CHECK ADD  CONSTRAINT [FK_BookWriter_Writers] FOREIGN KEY([WriterId])
REFERENCES [dbo].[Writers] ([WriterID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookWriters] CHECK CONSTRAINT [FK_BookWriter_Writers]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Books]
GO
ALTER TABLE [dbo].[Keywords]  WITH CHECK ADD  CONSTRAINT [FK_Keyword_Categorys] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Keywords] CHECK CONSTRAINT [FK_Keyword_Categorys]
GO
ALTER TABLE [dbo].[ProjectIterations]  WITH CHECK ADD  CONSTRAINT [FK_ProjectIterations_Projects] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ID])
GO
ALTER TABLE [dbo].[ProjectIterations] CHECK CONSTRAINT [FK_ProjectIterations_Projects]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ProjectIterations] FOREIGN KEY([CurIteration])
REFERENCES [dbo].[ProjectIterations] ([ID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectIterations]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ProjectModules] FOREIGN KEY([RootModule])
REFERENCES [dbo].[ProjectModules] ([ID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectModules]
GO
ALTER TABLE [dbo].[ProjectUsers]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUsers_Projects] FOREIGN KEY([Project])
REFERENCES [dbo].[Projects] ([ID])
GO
ALTER TABLE [dbo].[ProjectUsers] CHECK CONSTRAINT [FK_ProjectUsers_Projects]
GO
ALTER TABLE [dbo].[ProjectUsers]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUsers_User2] FOREIGN KEY([User])
REFERENCES [dbo].[User2] ([ID])
GO
ALTER TABLE [dbo].[ProjectUsers] CHECK CONSTRAINT [FK_ProjectUsers_User2]
GO
ALTER TABLE [dbo].[ReportExceptions]  WITH CHECK ADD  CONSTRAINT [FK_ReportExceptions_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ReportExceptions] CHECK CONSTRAINT [FK_ReportExceptions_Users]
GO
ALTER TABLE [dbo].[SolusionToKeywords]  WITH CHECK ADD  CONSTRAINT [FK_SolusionToKeywords_SolutionKeywords] FOREIGN KEY([SolutionKeywordID])
REFERENCES [dbo].[SolutionKeywords] ([SolusionKeywordID])
GO
ALTER TABLE [dbo].[SolusionToKeywords] CHECK CONSTRAINT [FK_SolusionToKeywords_SolutionKeywords]
GO
ALTER TABLE [dbo].[SolusionToKeywords]  WITH CHECK ADD  CONSTRAINT [FK_SolusionToKeywords_Solutions] FOREIGN KEY([SolutionID])
REFERENCES [dbo].[Solutions] ([SolusionID])
GO
ALTER TABLE [dbo].[SolusionToKeywords] CHECK CONSTRAINT [FK_SolusionToKeywords_Solutions]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_ProjectIterations] FOREIGN KEY([ProjectIterationID])
REFERENCES [dbo].[ProjectIterations] ([ID])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_ProjectIterations]
GO
ALTER TABLE [dbo].[ToolDepends]  WITH CHECK ADD  CONSTRAINT [FK_ToolDepends_ToolVersions] FOREIGN KEY([ToolVersionID])
REFERENCES [dbo].[ToolVersions] ([VersionID])
GO
ALTER TABLE [dbo].[ToolDepends] CHECK CONSTRAINT [FK_ToolDepends_ToolVersions]
GO
ALTER TABLE [dbo].[ToolDepends]  WITH CHECK ADD  CONSTRAINT [FK_ToolDepends_ToolVersions1] FOREIGN KEY([DependToolVersionID])
REFERENCES [dbo].[ToolVersions] ([VersionID])
GO
ALTER TABLE [dbo].[ToolDepends] CHECK CONSTRAINT [FK_ToolDepends_ToolVersions1]
GO
ALTER TABLE [dbo].[ToolFiles]  WITH CHECK ADD  CONSTRAINT [FK_ToolFiles_ToolVersions] FOREIGN KEY([ToolVersionID])
REFERENCES [dbo].[ToolVersions] ([VersionID])
GO
ALTER TABLE [dbo].[ToolFiles] CHECK CONSTRAINT [FK_ToolFiles_ToolVersions]
GO
ALTER TABLE [dbo].[ToolPlugins]  WITH CHECK ADD  CONSTRAINT [FK_ToolPlugins_ToolVersions] FOREIGN KEY([ToolVersionID])
REFERENCES [dbo].[ToolVersions] ([VersionID])
GO
ALTER TABLE [dbo].[ToolPlugins] CHECK CONSTRAINT [FK_ToolPlugins_ToolVersions]
GO
ALTER TABLE [dbo].[ToolPlugins]  WITH CHECK ADD  CONSTRAINT [FK_ToolPlugins_ToolVersions1] FOREIGN KEY([PluginToolVersionID])
REFERENCES [dbo].[ToolVersions] ([VersionID])
GO
ALTER TABLE [dbo].[ToolPlugins] CHECK CONSTRAINT [FK_ToolPlugins_ToolVersions1]
GO
ALTER TABLE [dbo].[Tools]  WITH CHECK ADD  CONSTRAINT [FK_Tools_ToolCategorys] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ToolCategorys] ([CategoryID])
GO
ALTER TABLE [dbo].[Tools] CHECK CONSTRAINT [FK_Tools_ToolCategorys]
GO
ALTER TABLE [dbo].[ToolVersions]  WITH CHECK ADD  CONSTRAINT [FK_ToolVersions_Tools] FOREIGN KEY([ToolID])
REFERENCES [dbo].[Tools] ([ToolID])
GO
ALTER TABLE [dbo].[ToolVersions] CHECK CONSTRAINT [FK_ToolVersions_Tools]
GO
ALTER TABLE [dbo].[User2]  WITH CHECK ADD  CONSTRAINT [FK_User2_Projects] FOREIGN KEY([DefaultProject])
REFERENCES [dbo].[Projects] ([ID])
GO
ALTER TABLE [dbo].[User2] CHECK CONSTRAINT [FK_User2_Projects]
GO
ALTER TABLE [dbo].[UserBooks]  WITH CHECK ADD  CONSTRAINT [FK_UserBooks_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[UserBooks] CHECK CONSTRAINT [FK_UserBooks_Books]
GO
ALTER TABLE [dbo].[UserBooks]  WITH CHECK ADD  CONSTRAINT [FK_UserBooks_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserBooks] CHECK CONSTRAINT [FK_UserBooks_Users]
GO
ALTER TABLE [dbo].[UserKeywords]  WITH CHECK ADD  CONSTRAINT [FK_UserKeywords_Keywords] FOREIGN KEY([KeywordID])
REFERENCES [dbo].[Keywords] ([KeywordID])
GO
ALTER TABLE [dbo].[UserKeywords] CHECK CONSTRAINT [FK_UserKeywords_Keywords]
GO
ALTER TABLE [dbo].[UserKeywords]  WITH CHECK ADD  CONSTRAINT [FK_UserKeywords_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserKeywords] CHECK CONSTRAINT [FK_UserKeywords_Users]
GO
ALTER TABLE [dbo].[WorkSpaceKeywords]  WITH CHECK ADD  CONSTRAINT [FK_WorkSpaceKeywords_Keywords] FOREIGN KEY([KeywordID])
REFERENCES [dbo].[Keywords] ([KeywordID])
GO
ALTER TABLE [dbo].[WorkSpaceKeywords] CHECK CONSTRAINT [FK_WorkSpaceKeywords_Keywords]
GO
ALTER TABLE [dbo].[WorkSpaceKeywords]  WITH CHECK ADD  CONSTRAINT [FK_WorkSpaceKeywords_WorkSpaces] FOREIGN KEY([WorkSpaceID])
REFERENCES [dbo].[WorkSpaces] ([WorkSpaceID])
GO
ALTER TABLE [dbo].[WorkSpaceKeywords] CHECK CONSTRAINT [FK_WorkSpaceKeywords_WorkSpaces]
GO
ALTER TABLE [dbo].[WorkSpaces]  WITH CHECK ADD  CONSTRAINT [FK_WorkSpaces_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[WorkSpaces] CHECK CONSTRAINT [FK_WorkSpaces_Users]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[61] 4[11] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BookFile"
            Begin Extent = 
               Top = 249
               Left = 264
               Bottom = 342
               Right = 415
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BookKeyword"
            Begin Extent = 
               Top = 1
               Left = 264
               Bottom = 94
               Right = 415
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Books"
            Begin Extent = 
               Top = 141
               Left = 25
               Bottom = 249
               Right = 176
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BookWriter"
            Begin Extent = 
               Top = 127
               Left = 266
               Bottom = 220
               Right = 417
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Categorys"
            Begin Extent = 
               Top = 77
               Left = 648
               Bottom = 185
               Right = 805
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Files"
            Begin Extent = 
               Top = 280
               Left = 452
               Bottom = 388
               Right = 603
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Keyword"
            Begin Extent = 
               Top = 32
               Left = 457
               Bottom = 140
               Right = 608
            End
            DisplayFlags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewBook'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 280
            TopColumn = 0
         End
         Begin Table = "Writers"
            Begin Extent = 
               Top = 156
               Left = 454
               Bottom = 249
               Right = 607
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewBook'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewBook'
GO
USE [master]
GO
ALTER DATABASE [JianLi] SET  READ_WRITE 
GO
