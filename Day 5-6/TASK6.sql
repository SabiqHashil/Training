--INSERT SignUp procedure
/*
CREATE PROCEDURE CreateSignup
    @first_name VARCHAR(50),
    @last_name VARCHAR(50),
    @date_of_birth DATE,
    @age INT,
    @gender VARCHAR(10),
    @phone_number VARCHAR(15),
    @email VARCHAR(100),
    @address TEXT,
    @state VARCHAR(50),
    @city VARCHAR(50),
    @username VARCHAR(50),
    @password VARCHAR(255)
AS
BEGIN
	INSERT INTO signup (
		first_name, last_name, date_of_birth, age, gender, phone_number, email, address, state, city, username, password
	) VALUES (
		@first_name, @last_name, @date_of_birth, @age, @gender, @phone_number, @email, @address, @state, @city, @username, @password
	);
END;
*/

--Execution of INSERT procedure
/*
EXEC CreateSignup
    @first_name = 'Sabiq',
    @last_name = 'Hashil',
    @date_of_birth = '2002-02-13',
    @age = 22,
    @gender = 'Male',
    @phone_number = '1234567895',
    @email = 'sbq@gmail.com',
    @address = 'Valanjeri City',
    @state = 'Kerala',
    @city = 'Valanjeri',
    @username = 'sbq',
    @password = 'password123'
*/

--READ procedure
/*
CREATE PROCEDURE ReadSignup
AS
BEGIN
	SELECT * FROM signup;
END;
*/

--Execution of READ procedure
--EXEC ReadSignup;

--UPDATE procedure
/*
CREATE PROCEDURE UpdateSignup
	@id INT,
	@first_name VARCHAR(50),
	@last_name VARCHAR(50),
	@email VARCHAR(100)
AS
BEGIN
	UPDATE signup
	SET
		first_name = @first_name,
		last_name = @last_name,
		email = @email
	WHERE id = @id;
END;
*/

--Execution of UPDATE procedure
/*
EXEC UpdateSignup
	@id = 162,
	@first_name = 'Shahan',
	@last_name = 'P',
	@email = 'shahan@gmail.com';
*/

--SELECT * FROM signup

--DELETE Procedure
/*
CREATE PROCEDURE DeleteSignup
	@id INT
AS
BEGIN
	DELETE FROM signup WHERE id = @id;
END;
*/

--Execution of DELETE procedure
--EXEC DeleteSignup @id = 162;