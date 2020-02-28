-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SaveUser
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

		END
END
GO
