-- creating a store procedure
-- to get max message sender users!
USE SocialNetworkDB;
GO

CREATE PROCEDURE GetMaxNumberOfMessageSenders
AS
BEGIN
	-- declaring a variable to get the count of the messages
	DECLARE @maxCount int
	SELECT @maxCount = (
						SELECT  TOP(1) Count(SenderId) AS MessageCount
						FROM UserMessages um
						JOIN Users u ON u.Id = um.SenderId
						GROUP BY SenderId
						ORDER BY MessageCount DESC
					)

	-- selecting the max count users
	SELECT CONCAT (u.FirstName ,' ',u.LastName) AS UserName, COUNT(u.FirstName) AS MessageCount
	FROM UserMessages um
	JOIN Users u ON u.Id = um.SenderId
	GROUP BY u.FirstName, u.LastName
	HAVING Count(u.FirstName) = @maxCount
	Order By u.FirstName 
END
