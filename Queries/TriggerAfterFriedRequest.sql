-- creating the trigger,
-- it will be taking action after a friend request has been made,
-- and then it will insert a row to approve table! 
USE SocialNetworkDB;

GO
CREATE TRIGGER TR_FriendShipRequests_AfterInsert
ON FriendShipRequests
AFTER INSERT
-- trigger will work After a new Request occured.
AS
BEGIN
	--creating variables to use in the query
	DECLARE @requestId int, @isAccepted bit
	SELECT @requestId=i.Id, @isAccepted=0
	FROM inserted i

	-- checking if there is a record after
	IF EXISTS (SELECT 1 FROM FriendshipRequests WHERE Id = @requestId)
	BEGIN
		INSERT INTO FriendshipApprovals (FriendshipRequestId, IsAccepted)
		VALUES (@requestId,@isAccepted)
	END
	-- if there is no record raise an error message
	ELSE
	BEGIN
		RAISERROR('The record does not exist!',1,1)
		ROLLBACK TRANSACTION
	END
END