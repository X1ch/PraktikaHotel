USE [master]
GO

/****** Object:  Database [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF]    Script Date: 25.02.2025 10:33:21 ******/
CREATE DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Database1', FILENAME = N'C:\Users\student\Desktop\Hotel\Hotel\bin\Debug\Database1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Database1_log', FILENAME = N'C:\Users\student\Desktop\Hotel\Hotel\bin\Debug\Database1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET ARITHABORT OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET AUTO_SHRINK ON 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET  DISABLE_BROKER 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET  MULTI_USER 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET DB_CHAINING OFF 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET QUERY_STORE = OFF
GO

ALTER DATABASE [C:\USERS\STUDENT\DESKTOP\HOTEL\HOTEL\BIN\DEBUG\DATABASE1.MDF] SET  READ_WRITE 
GO


