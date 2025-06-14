USE [master]
GO
/****** Object:  Database [EmployeeDb]    Script Date: 02-06-2025 13:22:03 ******/
CREATE DATABASE [EmployeeDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\EmployeeDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\EmployeeDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EmployeeDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EmployeeDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EmployeeDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeDb] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeDb] SET QUERY_STORE = OFF
GO
USE [EmployeeDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [EmployeeDb]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 02-06-2025 13:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DateOfJoining] [date] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Designation] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeSkills]    Script Date: 02-06-2025 13:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSkills](
	[EmployeeId] [int] NOT NULL,
	[SkillId] [int] NOT NULL,
	[YearsOfExperience] [int] NOT NULL,
	[ExpertLevel] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC,
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Skills]    Script Date: 02-06-2025 13:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 02-06-2025 13:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [Name], [DateOfJoining], [Email], [Designation]) VALUES (1, N'John Doe', CAST(N'2021-04-15' AS Date), N'john.doe@example.com', N'Software Engineer')
INSERT [dbo].[Employees] ([Id], [Name], [DateOfJoining], [Email], [Designation]) VALUES (2, N'Jane Smith', CAST(N'2020-09-23' AS Date), N'jane.smith@example.com', N'Project Manager')
INSERT [dbo].[Employees] ([Id], [Name], [DateOfJoining], [Email], [Designation]) VALUES (3, N'Robert Brown', CAST(N'2022-01-10' AS Date), N'robert.brown@example.com', N'QA Analyst')
INSERT [dbo].[Employees] ([Id], [Name], [DateOfJoining], [Email], [Designation]) VALUES (4, N'Emily Johnson', CAST(N'2019-11-30' AS Date), N'emily.johnson@example.com', N'Business Analyst')
INSERT [dbo].[Employees] ([Id], [Name], [DateOfJoining], [Email], [Designation]) VALUES (1022, N'sagar v varsolkar', CAST(N'2025-05-16' AS Date), N'sagarvarsolkar@gmail.com', N'Consultant')
SET IDENTITY_INSERT [dbo].[Employees] OFF
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (1, 28, 6, N'Beginner')
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (1, 29, 7, N'Proficient')
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (1, 30, 7, N'Beginner')
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (2, 30, 6, N'Intermediate')
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (3, 28, 10, N'Beginner')
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (3, 29, 6, N'Beginner')
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (3, 33, 7, N'Intermediate')
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (4, 28, 9, N'Beginner')
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (1022, 28, 8, N'Intermediate')
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (1022, 29, 10, N'Beginner')
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (1022, 32, 10, N'Intermediate')
INSERT [dbo].[EmployeeSkills] ([EmployeeId], [SkillId], [YearsOfExperience], [ExpertLevel]) VALUES (1022, 33, 9, N'Beginner')
SET IDENTITY_INSERT [dbo].[Skills] ON 

INSERT [dbo].[Skills] ([Id], [Name]) VALUES (33, N'.Net Core')
INSERT [dbo].[Skills] ([Id], [Name]) VALUES (28, N'Angular')
INSERT [dbo].[Skills] ([Id], [Name]) VALUES (29, N'C#')
INSERT [dbo].[Skills] ([Id], [Name]) VALUES (32, N'MVC')
INSERT [dbo].[Skills] ([Id], [Name]) VALUES (30, N'React')
INSERT [dbo].[Skills] ([Id], [Name]) VALUES (31, N'SQL')
SET IDENTITY_INSERT [dbo].[Skills] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [DisplayName]) VALUES (1, N'admin', N'admin123', N'System Admin')
INSERT [dbo].[Users] ([Id], [Username], [Password], [DisplayName]) VALUES (2, N'johndoe', N'pass123', N'John Doe')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Employee__A9D10534E59EB9FA]    Script Date: 02-06-2025 13:22:04 ******/
ALTER TABLE [dbo].[Employees] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Skills__737584F627955AA7]    Script Date: 02-06-2025 13:22:04 ******/
ALTER TABLE [dbo].[Skills] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Users__536C85E49A5444C9]    Script Date: 02-06-2025 13:22:04 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeSkills]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeeSkills]  WITH CHECK ADD FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skills] ([Id])
GO
USE [master]
GO
ALTER DATABASE [EmployeeDb] SET  READ_WRITE 
GO
