USE [master]
GO
/****** Object:  Database [QuaintSAMSDB]    Script Date: 4/13/2018 4:02:17 AM ******/
CREATE DATABASE [QuaintSAMSDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuaintSAMSDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.JESHADKHAN\MSSQL\DATA\QuaintSAMSDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuaintSAMSDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.JESHADKHAN\MSSQL\DATA\QuaintSAMSDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuaintSAMSDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuaintSAMSDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuaintSAMSDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuaintSAMSDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuaintSAMSDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuaintSAMSDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuaintSAMSDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuaintSAMSDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuaintSAMSDB] SET  MULTI_USER 
GO
ALTER DATABASE [QuaintSAMSDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuaintSAMSDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuaintSAMSDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuaintSAMSDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuaintSAMSDB]
GO
/****** Object:  User [sas]    Script Date: 4/13/2018 4:02:17 AM ******/
CREATE USER [sas] FOR LOGIN [sas] WITH DEFAULT_SCHEMA=[sas]
GO
/****** Object:  Schema [sas]    Script Date: 4/13/2018 4:02:18 AM ******/
CREATE SCHEMA [sas]
GO
/****** Object:  StoredProcedure [dbo].[Delete_BlogPost]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_BlogPost]
	@BlogPostId int
As
Begin
	Delete
		dbo.BlogPosts
	Where
		[BlogPostId] = @BlogPostId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_BlogPostCategory]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_BlogPostCategory]
	@BlogPostCategoryId int
As
Begin
	Delete
		dbo.BlogPostCategories
	Where
		[BlogPostCategoryId] = @BlogPostCategoryId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Country]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Country]
	@CountryId int
As
Begin
	Delete
		dbo.Countries
	Where
		[CountryId] = @CountryId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Course]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Course]
	@CourseId int
As
Begin
	Delete
		dbo.Courses
	Where
		[CourseId] = @CourseId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Institute]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Institute]
	@InstituteId int
As
Begin
	Delete
		dbo.Institutes
	Where
		[InstituteId] = @InstituteId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_LenderBank]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_LenderBank]
	@LenderBankId int
As
Begin
	Delete
		dbo.LenderBanks
	Where
		[LenderBankId] = @LenderBankId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Ranking]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Ranking]
	@RankingId int
As
Begin
	Delete
		dbo.Rankings
	Where
		[RankingId] = @RankingId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Tutorial]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Tutorial]
	@TutorialId int
As
Begin
	Delete
		dbo.Tutorials
	Where
		[TutorialId] = @TutorialId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_User]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_User]
	@UserId int
As
Begin
	Delete
		dbo.Users
	Where
		[UserId] = @UserId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_BlogPost]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_BlogPost]
As
Begin
	Select
		bp.*
		,bpc.Name as BlogPostCategoryName
		,bpc.Slag as BlogPostCategorySlag
	From
		dbo.BlogPosts bp
	Left Join
		dbo.BlogPostCategories bpc
	ON
		bp.BlogPostCategoryId = bpc.BlogPostCategoryId
	Order By
		bp.BlogPostCode desc
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_BlogPostCategory]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_BlogPostCategory]
As
Begin
	Select
		*
	From
		dbo.BlogPostCategories
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Country]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_Country]
As
Begin
	Select
		*
	From
		dbo.Countries
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Course]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_Course]
As
Begin
	Select
		*
	From
		dbo.Courses
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Institute]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_Institute]
As
Begin
	Select
		i.*
		,c.Name as CourseName
		,c.IsActive as IsCourseActive
		,c.CourseCode
	From
		dbo.Institutes i
	Left Join
		dbo.Courses c
	On
		i.CourseId = c.CourseId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_LenderBank]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_LenderBank]
As
Begin
	Select
		lb.*
		,c.Name as CountryName
		,c.IsActive as IsCountryActive
	From
		dbo.LenderBanks lb
	Left Join
		dbo.Countries c
	On
		lb.CountryId = c.CountryId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Ranking]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_Ranking]
As
Begin
	Select
		r.*
		,c.Name as CountryName
		,c.IsActive as IsCountryActive
	From
		dbo.Rankings r
	Left Join
		dbo.Countries c
	On
		r.CountryId = c.CountryId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Tutorial]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_Tutorial]
As
Begin
	Select
		*
	From
		dbo.Tutorials
End

GO
/****** Object:  StoredProcedure [dbo].[Get_All_User]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_User]
As
Begin
	Select
		*
	From
		dbo.Users
End
GO
/****** Object:  StoredProcedure [dbo].[Get_BlogPost_By_Id]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_BlogPost_By_Id]
	@BlogPostId int
As
Begin
	Select
		*
	From
		dbo.BlogPosts
	Where
		[BlogPostId] = @BlogPostId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_BlogPostCategory_By_Id]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_BlogPostCategory_By_Id]
	@BlogPostCategoryId int
As
Begin
	Select
		*
	From
		dbo.BlogPostCategories
	Where
		[BlogPostCategoryId] = @BlogPostCategoryId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_Country_By_Id]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_Country_By_Id]
	@CountryId int
As
Begin
	Select
		*
	From
		dbo.Countries
	Where
		[CountryId] = @CountryId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_Course_By_Id]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_Course_By_Id]
	@CourseId int
As
Begin
	Select
		*
	From
		dbo.Courses
	Where
		[CourseId] = @CourseId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_Institute_By_Id]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_Institute_By_Id]
	@InstituteId int
As
Begin
	Select
		*
	From
		dbo.Institutes
	Where
		[InstituteId] = @InstituteId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_LenderBank_By_Id]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_LenderBank_By_Id]
	@LenderBankId int
As
Begin
	Select
		*
	From
		dbo.LenderBanks
	Where
		[LenderBankId] = @LenderBankId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_Ranking_By_Id]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_Ranking_By_Id]
	@RankingId int
As
Begin
	Select
		*
	From
		dbo.Rankings
	Where
		[RankingId] = @RankingId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_Tutorial_By_Id]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_Tutorial_By_Id]
	@TutorialId int
As
Begin
	Select
		*
	From
		dbo.Tutorials
	Where
		[TutorialId] = @TutorialId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_User_By_Id]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_User_By_Id]
	@UserId int
As
Begin
	Select
		*
	From
		dbo.Users
	Where
		[UserId] = @UserId
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_BlogPost]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_BlogPost]
	@BlogPostCode nvarchar(50),
	@Title nvarchar(50),
	@Slag nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@PublishedDate datetime,
	@Attachment nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@BlogPostCategoryId int
As
Begin
	Insert Into dbo.BlogPosts
		(BlogPostCode, Title, Slag, Description, PublishedDate, Attachment, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, BlogPostCategoryId)
	Values
		(@BlogPostCode, @Title, @Slag, @Description, @PublishedDate, @Attachment, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @BlogPostCategoryId)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_BlogPostCategory]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_BlogPostCategory]
	@BlogPostCategoryCode nvarchar(50),
	@Name nvarchar(50),
	@Slag nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Insert Into dbo.BlogPostCategories
		(BlogPostCategoryCode, Name, Slag, Description, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom)
	Values
		(@BlogPostCategoryCode, @Name, @Slag, @Description, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_Country]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_Country]
	@CountryCode nvarchar(50),
	@Name nvarchar(50),
	@CountryCodeAlpha2 nvarchar(5) = null,
	@CountryCodeAlpha3 nvarchar(5) = null,
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Insert Into dbo.Countries
		(CountryCode, Name,	CountryCodeAlpha2, CountryCodeAlpha3, Description, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom)
	Values
		(@CountryCode, @Name, @CountryCodeAlpha2, @CountryCodeAlpha3, @Description, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_Course]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_Course]
	@CourseCode nvarchar(50),
	@Name nvarchar(50),
	@Description nvarchar(MAX) = null,
	@Attachment nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Insert Into dbo.Courses
		(CourseCode, Name, Description, Attachment, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom)
	Values
		(@CourseCode, @Name, @Description, @Attachment, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_Institute]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--===========================================================================
CREATE Procedure [dbo].[Insert_Institute]
	@InstituteCode nvarchar(50),
	@Name nvarchar(50),
	@Logo nvarchar(MAX) = null,
	@Url nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@SerialNumber int,
	@Attachment nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@CourseId int
As
Begin
	Insert Into dbo.Institutes
		(InstituteCode, Name, Logo, Url, Description, SerialNumber, Attachment, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, CourseId)
	Values
		(@InstituteCode, @Name, @Logo, @Url, @Description, @SerialNumber, @Attachment, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @CourseId)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_LenderBank]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_LenderBank]
	@LenderBankCode nvarchar(50),
	@BankName nvarchar(50),
	@Url nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@CountryId int
As
Begin
	Insert Into dbo.LenderBanks
		(LenderBankCode, BankName, Url, Description, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, CountryId)
	Values
		(@LenderBankCode, @BankName, @Url, @Description, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @CountryId)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_Ranking]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_Ranking]
	@RankingCode nvarchar(50),
	@UniversityName nvarchar(50),
	@Rank int,
	@Url nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@CountryId int
As
Begin
	Insert Into dbo.Rankings
		(RankingCode, UniversityName, Rank, Url, Description, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, CountryId)
	Values
		(@RankingCode, @UniversityName, @Rank, @Url, @Description, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @CountryId)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_Tutorial]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_Tutorial]
	@TutorialCode nvarchar(50),
	@Title nvarchar(100),
	@Slug nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@Attachment nvarchar(MAX) = null,
	@ExternalUrl nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@PlayListId int
As
Begin
	Insert Into dbo.Tutorials
		(TutorialCode, Title, Slug, Description, Attachment, ExternalUrl, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, PlayListId)
	Values
		(@TutorialCode, @Title, @Slug, @Description, @Attachment, @ExternalUrl, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @PlayListId)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_User]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_User]
	@UserCode nvarchar(50),
	@FullName nvarchar(50),
	@Email nvarchar(50) = null,
	@UserName nvarchar(50),
	@Password nvarchar(MAX),
	@PasswordStamp nvarchar(MAX) = null,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@UserType nvarchar(50),
	@IsActive bit
As
Begin
	Insert Into dbo.Users
		(UserCode, FullName, Email, UserName, Password, PasswordStamp, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, UserType, IsActive)
	Values
		(@UserCode, @FullName, @Email, @UserName, @Password, @PasswordStamp, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @UserType, @IsActive)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Update_BlogPost]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_BlogPost]
	@BlogPostId int,
	@BlogPostCode nvarchar(50),
	@Title nvarchar(50),
	@Slag nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@PublishedDate datetime,
	@Attachment nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@BlogPostCategoryId int
As
Begin
	Update
		dbo.BlogPosts
	Set
		[BlogPostCode] = @BlogPostCode
		,[Title] = @Title
		,[Slag] = @Slag
		,[Description] = @Description
		,[PublishedDate] = @PublishedDate
		,[Attachment] = @Attachment
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[BlogPostCategoryId] = @BlogPostCategoryId
	Where		
		[BlogPostId] = @BlogPostId
End
GO
/****** Object:  StoredProcedure [dbo].[Update_BlogPostCategory]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_BlogPostCategory]
	@BlogPostCategoryId int,
	@BlogPostCategoryCode nvarchar(50),
	@Name nvarchar(50),
	@Slag nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Update
		dbo.BlogPostCategories
	Set
		[BlogPostCategoryCode] = @BlogPostCategoryCode
		,[Name] = @Name
		,[Slag] = @Slag
		,[Description] = @Description
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
	Where		
		[BlogPostCategoryId] = @BlogPostCategoryId
End
GO
/****** Object:  StoredProcedure [dbo].[Update_Country]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_Country]
	@CountryId int,
	@CountryCode nvarchar(50),
	@Name nvarchar(50),
	@CountryCodeAlpha2 nvarchar(5) = null,
	@CountryCodeAlpha3 nvarchar(5) = null,
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Update
		dbo.Countries
	Set
		[CountryCode] = @CountryCode
		,[Name] = @Name
		,[CountryCodeAlpha2] = @CountryCodeAlpha2
		,[CountryCodeAlpha3] = @CountryCodeAlpha3
		,[Description] = @Description
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
	Where		
		[CountryId] = @CountryId
End
GO
/****** Object:  StoredProcedure [dbo].[Update_Course]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_Course]
	@CourseId int,
	@CourseCode nvarchar(50),
	@Name nvarchar(50),
	@Description nvarchar(MAX) = null,
	@Attachment nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Update
		dbo.Courses
	Set
		[CourseCode] = @CourseCode
		,[Name] = @Name
		,[Description] = @Description
		,[Attachment] = @Attachment
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
	Where		
		[CourseId] = @CourseId
End
GO
/****** Object:  StoredProcedure [dbo].[Update_Institute]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--============================================================================
CREATE Procedure [dbo].[Update_Institute]
	@InstituteId int,
	@InstituteCode nvarchar(50),
	@Name nvarchar(50),
	@Logo nvarchar(MAX) = null,
	@Url nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@SerialNumber int,
	@Attachment nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@CourseId int
As
Begin
	Update
		dbo.Institutes
	Set
		[InstituteCode] = @InstituteCode
		,[Name] = @Name
		,[Logo] = @Logo
		,[Url] = @Url
		,[Description] = @Description
		,[SerialNumber] = @SerialNumber
		,[Attachment] = @Attachment
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[CourseId] = @CourseId
	Where		
		[InstituteId] = @InstituteId
End
GO
/****** Object:  StoredProcedure [dbo].[Update_LenderBank]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_LenderBank]
	@LenderBankId int,
	@LenderBankCode nvarchar(50),
	@BankName nvarchar(50),
	@Url nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@CountryId int
As
Begin
	Update
		dbo.LenderBanks
	Set
		[LenderBankCode] = @LenderBankCode
		,[BankName] = @BankName
		,[Url] = @Url
		,[Description] = @Description
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[CountryId] = @CountryId
	Where		
		[LenderBankId] = @LenderBankId
End
GO
/****** Object:  StoredProcedure [dbo].[Update_Ranking]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_Ranking]
	@RankingId int,
	@RankingCode nvarchar(50),
	@UniversityName nvarchar(50),
	@Rank int,
	@Url nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@CountryId int
As
Begin
	Update
		dbo.Rankings
	Set
		[RankingCode] = @RankingCode
		,[UniversityName] = @UniversityName
		,[Rank] = @Rank
		,[Url] = @Url
		,[Description] = @Description
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[CountryId] = @CountryId
	Where		
		[RankingId] = @RankingId
End
GO
/****** Object:  StoredProcedure [dbo].[Update_Tutorial]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_Tutorial]
	@TutorialId int,
	@TutorialCode nvarchar(50),
	@Title nvarchar(100),
	@Slug nvarchar(MAX) = null,
	@Description nvarchar(MAX) = null,
	@Attachment nvarchar(MAX) = null,
	@ExternalUrl nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@PlayListId int
As
Begin
	Update
		dbo.Tutorials
	Set
		 [TutorialCode] = @TutorialCode
		,[Title] = @Title
		,[Slug] = @Slug
		,[Description] = @Description
		,[Attachment] = @Attachment
		,[ExternalUrl] = @ExternalUrl
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[PlayListId] = @PlayListId
	Where		
		[TutorialId] = @TutorialId
End

GO
/****** Object:  StoredProcedure [dbo].[Update_User]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Study Abroad Management System (QSAMS)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_User]
	@UserId int,
	@UserCode nvarchar(50),
	@FullName nvarchar(50),
	@Email nvarchar(50) = null,
	@UserName nvarchar(50),
	@Password nvarchar(MAX),
	@PasswordStamp nvarchar(MAX) = null,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@UserType nvarchar(50),
	@IsActive bit
As
Begin
	Update
		dbo.Users
	Set
		[UserCode] = @UserCode
		,[FullName] = @FullName
		,[Email] = @Email
		,[UserName] = @UserName
		,[Password] = @Password
		,[PasswordStamp] = @PasswordStamp
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[UserType] = @UserType
		,[IsActive] = @IsActive
	Where		
		[UserId] = @UserId
End
GO
/****** Object:  Table [dbo].[BlogPostCategories]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPostCategories](
	[BlogPostCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[BlogPostCategoryCode] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Slag] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_BlogPostCategories] PRIMARY KEY CLUSTERED 
(
	[BlogPostCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogPosts]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPosts](
	[BlogPostId] [int] IDENTITY(1,1) NOT NULL,
	[BlogPostCode] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Slag] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[PublishedDate] [datetime] NOT NULL,
	[Attachment] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [date] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[BlogPostCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_BlogPost] PRIMARY KEY CLUSTERED 
(
	[BlogPostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryCodeAlpha2] [nvarchar](5) NULL,
	[CountryCodeAlpha3] [nvarchar](5) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Attachment] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_CourseTypes] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Institutes]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institutes](
	[InstituteId] [int] IDENTITY(1,1) NOT NULL,
	[InstituteCode] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Logo] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[SerialNumber] [int] NOT NULL,
	[Attachment] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedFrom] [nvarchar](50) NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[InstituteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LenderBanks]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LenderBanks](
	[LenderBankId] [int] IDENTITY(1,1) NOT NULL,
	[LenderBankCode] [nvarchar](50) NOT NULL,
	[BankName] [nvarchar](50) NOT NULL,
	[Url] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_BanksLoanInformation] PRIMARY KEY CLUSTERED 
(
	[LenderBankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rankings]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rankings](
	[RankingId] [int] IDENTITY(1,1) NOT NULL,
	[RankingCode] [nvarchar](50) NOT NULL,
	[UniversityName] [nvarchar](50) NOT NULL,
	[Rank] [int] NOT NULL,
	[Url] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Rankings] PRIMARY KEY CLUSTERED 
(
	[RankingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tutorials]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tutorials](
	[TutorialId] [int] IDENTITY(1,1) NOT NULL,
	[TutorialCode] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Attachment] [nvarchar](max) NULL,
	[ExternalUrl] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [nvarchar](500) NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[PlayListId] [int] NOT NULL,
 CONSTRAINT [PK_Trainings] PRIMARY KEY CLUSTERED 
(
	[TutorialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/13/2018 4:02:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PasswordStamp] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[UserType] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BlogPostCategories] ON 

INSERT [dbo].[BlogPostCategories] ([BlogPostCategoryId], [BlogPostCategoryCode], [Name], [Slag], [Description], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom]) VALUES (1, N'BPC-000001', N'Current News', N'current-news', N'news', 1, CAST(0x0000A8A2013B0596 AS DateTime), N'', N'', NULL, NULL, NULL)
INSERT [dbo].[BlogPostCategories] ([BlogPostCategoryId], [BlogPostCategoryCode], [Name], [Slag], [Description], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom]) VALUES (3, N'BPC-000002', N'Technology', N'technology', N'tech', 1, CAST(0x0000A8A2013BC747 AS DateTime), N'', N'', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[BlogPostCategories] OFF
SET IDENTITY_INSERT [dbo].[BlogPosts] ON 

INSERT [dbo].[BlogPosts] ([BlogPostId], [BlogPostCode], [Title], [Slag], [Description], [PublishedDate], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [BlogPostCategoryId]) VALUES (1, N'PST-000001', N'this is A test post ', N'this-is-a-test-post', N'sssvsvsa scvsavsa scvsa', CAST(0x0000A89A00000000 AS DateTime), N'', 1, CAST(0x0000A8AD00365F9E AS DateTime), N'', N'', NULL, NULL, NULL, 1)
INSERT [dbo].[BlogPosts] ([BlogPostId], [BlogPostCode], [Title], [Slag], [Description], [PublishedDate], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [BlogPostCategoryId]) VALUES (2, N'PST-000002', N'Tiswr  werewr wer', N'tiswr-werewr-wer', N'5564564564', CAST(0x0000A89F00000000 AS DateTime), N'', 1, CAST(0x0000A8AD0037B48C AS DateTime), N'', N'', CAST(0x0D3E0B00 AS Date), N'', N'', 1)
INSERT [dbo].[BlogPosts] ([BlogPostId], [BlogPostCode], [Title], [Slag], [Description], [PublishedDate], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [BlogPostCategoryId]) VALUES (5, N'PST-000003', N'test with attachment', N'test-with-attachment', N'', CAST(0x0000A89400000000 AS DateTime), N'PST-000003_20180324033700906.png', 1, CAST(0x0000A8AD003B99D0 AS DateTime), N'', N'', CAST(0x0F3E0B00 AS Date), N'0, , 0, admin', N', , , , , , , , , ', 3)
INSERT [dbo].[BlogPosts] ([BlogPostId], [BlogPostCode], [Title], [Slag], [Description], [PublishedDate], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [BlogPostCategoryId]) VALUES (6, N'PST-000004', N'Lorem Ipsum', N'lorem-ipsum', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.

Why do we use it?
It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ''Content here, content here'', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for ''lorem ipsum'' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).', CAST(0x0000A8A800000000 AS DateTime), N'', 1, CAST(0x0000A8B200295B10 AS DateTime), N'', N'', NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[BlogPosts] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [CountryCode], [Name], [CountryCodeAlpha2], [CountryCodeAlpha3], [Description], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom]) VALUES (3, N'CNT-000002', N'Bangladesh', N'BD', N'BGD', N'land', 1, CAST(0x0000A89E00278850 AS DateTime), N'', N'', CAST(0x0000A89E012AEBCA AS DateTime), N'', N'')
INSERT [dbo].[Countries] ([CountryId], [CountryCode], [Name], [CountryCodeAlpha2], [CountryCodeAlpha3], [Description], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom]) VALUES (4, N'CNT-000003', N'Turkey', N'TU', N'TUY', N'', 1, CAST(0x0000A89E0028BB58 AS DateTime), N'', N'', CAST(0x0000A89E012AD380 AS DateTime), N'', N'')
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseId], [CourseCode], [Name], [Description], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom]) VALUES (1, N'CRS-000001', N'IELTS', N'IELTS', N'', 1, CAST(0x0000A8AA0092A3D8 AS DateTime), N'', N'', CAST(0x0000A8AA0092CEB6 AS DateTime), N'', N'')
INSERT [dbo].[Courses] ([CourseId], [CourseCode], [Name], [Description], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom]) VALUES (3, N'CRS-000002', N'GRE', N'GRE', N'', 1, CAST(0x0000A8AA009328AC AS DateTime), N'', N'', NULL, NULL, NULL)
INSERT [dbo].[Courses] ([CourseId], [CourseCode], [Name], [Description], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom]) VALUES (4, N'CRS-000003', N'TOFEL', N'TOFEL', N'', 1, CAST(0x0000A8AA00933066 AS DateTime), N'', N'', NULL, NULL, NULL)
INSERT [dbo].[Courses] ([CourseId], [CourseCode], [Name], [Description], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom]) VALUES (5, N'CRS-000004', N'GMAT', N'GMAT', N'', 1, CAST(0x0000A8AA009337A9 AS DateTime), N'', N'', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Institutes] ON 

INSERT [dbo].[Institutes] ([InstituteId], [InstituteCode], [Name], [Logo], [Url], [Description], [SerialNumber], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CourseId]) VALUES (1, N'INS-000001', N'DIL', N'INS-000001_20180329045806314.png', N'dil.edu', N'chgvhgvhgv', 5, N'', 1, CAST(0x0000A8B20051E028 AS DateTime), N'', N'', CAST(0x0000A8B20056FECF AS DateTime), N'0, , 0, admin', N', , , , , , , , , ', 1)
INSERT [dbo].[Institutes] ([InstituteId], [InstituteCode], [Name], [Logo], [Url], [Description], [SerialNumber], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CourseId]) VALUES (3, N'INS-000002', N'Mentors', N'INS-000002_20180413030041878.png', N'mentor.com', N'', 4, N'', 1, CAST(0x0000A8B200571494 AS DateTime), N'', N'', CAST(0x0000A8C10031A158 AS DateTime), N'', N'', 4)
INSERT [dbo].[Institutes] ([InstituteId], [InstituteCode], [Name], [Logo], [Url], [Description], [SerialNumber], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CourseId]) VALUES (4, N'INS-000003', N'american center', N'INS-000003_20180413025909355.jpg', N'ac.edu.bd', N'dabdhbahbd', 6, N'', 1, CAST(0x0000A8C10026BEC0 AS DateTime), N'', N'', CAST(0x0000A8C1003134F1 AS DateTime), N'', N'', 1)
INSERT [dbo].[Institutes] ([InstituteId], [InstituteCode], [Name], [Logo], [Url], [Description], [SerialNumber], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CourseId]) VALUES (5, N'INS-000004', N'GRE Center', N'INS-000004_20180413025937217.png', N'greccenter.com', N'dasbdhbsahdbhabs', 7, N'', 1, CAST(0x0000A8C1002732C4 AS DateTime), N'', N'', CAST(0x0000A8C100315590 AS DateTime), N'', N'', 3)
INSERT [dbo].[Institutes] ([InstituteId], [InstituteCode], [Name], [Logo], [Url], [Description], [SerialNumber], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CourseId]) VALUES (6, N'INS-000005', N'Pi Center', N'INS-000005_20180413025953292.png', N'picenter.com', N'dhbsabdsh', 8, N'', 1, CAST(0x0000A8C1002769D8 AS DateTime), N'', N'', CAST(0x0000A8C100316868 AS DateTime), N'', N'', 4)
INSERT [dbo].[Institutes] ([InstituteId], [InstituteCode], [Name], [Logo], [Url], [Description], [SerialNumber], [Attachment], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CourseId]) VALUES (7, N'INS-000006', N'Saifurs', N'INS-000006_20180413030011298.jpg', N'saifurs.com.bd', N'dasdasda', 9, N'', 1, CAST(0x0000A8C100279660 AS DateTime), N'', N'', CAST(0x0000A8C100317D86 AS DateTime), N'', N'', 5)
SET IDENTITY_INSERT [dbo].[Institutes] OFF
SET IDENTITY_INSERT [dbo].[LenderBanks] ON 

INSERT [dbo].[LenderBanks] ([LenderBankId], [LenderBankCode], [BankName], [Url], [Description], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CountryId]) VALUES (1, N'BNK-000001', N'dutch bangla bank ltd', N'dbbl.com', N'bd bank', 1, CAST(0x0000A89E0125C640 AS DateTime), N'', N'', CAST(0x0000A89E0126FC91 AS DateTime), N'', N'', 3)
INSERT [dbo].[LenderBanks] ([LenderBankId], [LenderBankCode], [BankName], [Url], [Description], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CountryId]) VALUES (3, N'BNK-000002', N'islami bank bangladesh ltd', N'ibbl.com', N'ibbl', 1, CAST(0x0000A89E01277D56 AS DateTime), N'', N'', NULL, NULL, NULL, 3)
INSERT [dbo].[LenderBanks] ([LenderBankId], [LenderBankCode], [BankName], [Url], [Description], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CountryId]) VALUES (4, N'BNK-000003', N'turkey bank', N'tb.com', N'tb', 1, CAST(0x0000A89E0127987B AS DateTime), N'', N'', NULL, NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[LenderBanks] OFF
SET IDENTITY_INSERT [dbo].[Rankings] ON 

INSERT [dbo].[Rankings] ([RankingId], [RankingCode], [UniversityName], [Rank], [Url], [Description], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CountryId]) VALUES (8, N'RNK-000001', N'DIU', 1, N'http://diu.edu.bd/', N'', 1, CAST(0x0000A89E00485D00 AS DateTime), N'', N'', CAST(0x0000A89E0059CF56 AS DateTime), N'', N'', 3)
INSERT [dbo].[Rankings] ([RankingId], [RankingCode], [UniversityName], [Rank], [Url], [Description], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CountryId]) VALUES (9, N'RNK-000002', N'AIUB', 5, N'', N'', 1, CAST(0x0000A89E00486FF5 AS DateTime), N'', N'', NULL, NULL, NULL, 3)
INSERT [dbo].[Rankings] ([RankingId], [RankingCode], [UniversityName], [Rank], [Url], [Description], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CountryId]) VALUES (10, N'RNK-000003', N'MIT', 1, N'', N'', 1, CAST(0x0000A89E00487F67 AS DateTime), N'', N'', NULL, NULL, NULL, 4)
INSERT [dbo].[Rankings] ([RankingId], [RankingCode], [UniversityName], [Rank], [Url], [Description], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [CountryId]) VALUES (11, N'RNK-000004', N'TU', 3, N'', N'', 1, CAST(0x0000A89E00489DB9 AS DateTime), N'', N'', NULL, NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[Rankings] OFF
SET IDENTITY_INSERT [dbo].[Tutorials] ON 

INSERT [dbo].[Tutorials] ([TutorialId], [TutorialCode], [Title], [Slug], [Description], [Attachment], [ExternalUrl], [IsActive], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [PlayListId]) VALUES (1, N'TUT-000001', N'Test Tutorial', N'test-tutorial', N'123', NULL, N'https://www.youtube.com/watch?v=LMbQsI1PKVw', 1, CAST(0x0000A8B800AEA434 AS DateTime), N'0, , 0, admin', N', , , , , , , , , ', N'Apr  4 2018 10:47AM', N'0, , 0, admin', N', , , , , , , , , ', 0)
SET IDENTITY_INSERT [dbo].[Tutorials] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserCode], [FullName], [Email], [UserName], [Password], [PasswordStamp], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [UserType], [IsActive]) VALUES (1, N'USR-000001', N'System Administrator', N'admin@system.com', N'admin', N'admin', N'', CAST(0x0000A89B0042F9B4 AS DateTime), N'', N'', CAST(0x0000A8C10041B402 AS DateTime), N'0, ADMIN, 1, System Administrator', N', , , , , , , , , ', N'ADMIN', 1)
INSERT [dbo].[Users] ([UserId], [UserCode], [FullName], [Email], [UserName], [Password], [PasswordStamp], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [UserType], [IsActive]) VALUES (2, N'USR-000002', N'test', N'test@gmail.com', N'test@gmail.com', N'123', NULL, CAST(0x0000A8B400245F68 AS DateTime), N'', N'', NULL, NULL, NULL, N'MEMBER', 1)
INSERT [dbo].[Users] ([UserId], [UserCode], [FullName], [Email], [UserName], [Password], [PasswordStamp], [CreatedDate], [CreatedBy], [CreatedFrom], [UpdatedDate], [UpdatedBy], [UpdatedFrom], [UserType], [IsActive]) VALUES (3, N'USR-000003', N'sstest@gmail.com', N'test2@gmail.com', N'test2@gmail.com', N'123', NULL, CAST(0x0000A8B400266925 AS DateTime), N'', N'', NULL, NULL, NULL, N'MEMBER', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [QuaintSAMSDB] SET  READ_WRITE 
GO
