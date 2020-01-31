USE [master]
GO

/****** Object:  Database [n3276931staffSkills]    Script Date: 23/01/2016 15:20:24 ******/
CREATE DATABASE [n3276931staffSkills]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'n3276931staffSkills', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\n3276931staffSkills.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'n3276931staffSkills_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\n3276931staffSkills_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [n3276931staffSkills] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [n3276931staffSkills].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [n3276931staffSkills] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET ARITHABORT OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [n3276931staffSkills] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [n3276931staffSkills] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET  DISABLE_BROKER 
GO

ALTER DATABASE [n3276931staffSkills] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [n3276931staffSkills] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [n3276931staffSkills] SET  MULTI_USER 
GO

ALTER DATABASE [n3276931staffSkills] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [n3276931staffSkills] SET DB_CHAINING OFF 
GO

ALTER DATABASE [n3276931staffSkills] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [n3276931staffSkills] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [n3276931staffSkills] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [n3276931staffSkills] SET  READ_WRITE 
GO
