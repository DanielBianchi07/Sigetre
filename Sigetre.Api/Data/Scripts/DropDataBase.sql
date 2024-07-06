-- DROP DO BANCO
----------------------------------------------------------------------
--
USE [master];
GO

ALTER DATABASE [Sigetre-dev] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE [Sigetre-dev];
GO
--
----------------------------------------------------------------------
--