-- creating the trigger,
-- it will be taking a copy of updated UserMessage before updated,
-- and then it will update the UserMessage! 
USE SocialNetworkDB;

GO
CREATE TRIGGER TR_UserMessages_InsteadOfUpdate
ON UserMessages
INSTEAD OF UPDATE
-- trigger will work instead of Update
AS
BEGIN
	-- declaring the values from the inserted table to make changes before update!
	DECLARE @messageId int, @messageBody nvarchar(max), @messageTypeId int, @updatedAt datetime2
	SELECT @messageId=i.Id, @messageBody=i.MessageBody, @messageTypeId=i.MessageTypeId, @updatedAt=GETDATE()
	FROM inserted i

	-- checking if the UserMessage is really exist
	IF EXISTS (SELECT 1 FROM UserMessages WHERE Id = @messageId)
	BEGIN
		-- if the message is exist insert it values to Archive table.
		INSERT INTO UserMessagesArchive (MessageId, MessageBody, MessageTypeId, UpdatedAt)
		VALUES (@messageId, @messageBody, @messageTypeId, @updatedAt)

		-- updating the real record finally!
		UPDATE UserMessages 
		SET MessageBody=@messageBody, UpdatedAt = GETDATE()
		WHERE Id=@messageId
	END
	-- if the record doesnt exit we generate an error!
	ELSE
	BEGIN
		RAISERROR('The record does not exist!',1,1)
		ROLLBACK TRANSACTION
	END
END
