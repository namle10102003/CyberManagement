CREATE TRIGGER update_Computer_After_Insert_Error
AFTER INSERT ON ComputerErrors
FOR EACH ROW
BEGIN
    UPDATE Computers
	SET Status = 'Error'
	WHERE Id = NEW.ComputerId;
END