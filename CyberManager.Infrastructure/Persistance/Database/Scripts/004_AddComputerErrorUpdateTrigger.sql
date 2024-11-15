CREATE TRIGGER update_Computer_After_Update_Error
AFTER UPDATE ON ComputerErrors
FOR EACH ROW
BEGIN
	UPDATE Computers
	SET Status = CASE
					WHEN (
							SELECT count(*) 
							FROM ComputerErrors
							WHERE ComputerId = OLD.ComputerId
							AND IsSolve = false
						) = 0 THEN 'Offline'
					ELSE 'Error'
				END
	WHERE Id = OLD.ComputerId;
END