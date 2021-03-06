USE [sampledb]
GO
/****** Object:  StoredProcedure [dbo].[SaveUser]    Script Date: 2/28/2020 10:15:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SaveUser]
	-- Add the parameters for the stored procedure here
	@id BIGINT,
	@userName nVARCHAR(MAX),
	@password nVARCHAR(MAX),
	@firstName nVARCHAR(MAX),
	@lastName nVARCHAR(MAX),
	@isActive BIT


AS
BEGIN
	IF(@ID = 0)
		BEGIN
			-- INSERT USER

			INSERT INTO [dbo].[User]
           ([UserName]
           ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[IsActive])
		  

     VALUES
           (@userName
           ,@password
           ,@firstName
           ,@lastName
           ,@isActive)

		    -- SELECT USER AFTER INSERT
		 DECLARE @newId BIGINT = 0;
		 SET @newId = @@IDENTITY;
		 SELECT * FROM [dbo].[User] WHERE [Id] = @newId;

		END
	ELSE
		BEGIN
			-- UPDATE USER

			
			UPDATE [dbo].[User]
			SET [UserName] = @userName
			,[Password] = @password
			,[FirstName] = @firstName
			,[LastName] = @lastName
			,[IsActive] = @isActive
			WHERE [Id] = @id

			 -- SELECT USER AFTER UPDATE
			 SELECT * FROM [dbo].[User] WHERE [Id] = @id;

		END
END
