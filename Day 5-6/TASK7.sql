--use user_management

--Create table StudentAdmission
/*
CREATE TABLE StudentAdmission (
	id INT IDENTITY(1,1) PRIMARY KEY,
	first_name VARCHAR(50),
	last_name VARCHAR(50),
	date_of_birth DATE,
	age INT,
	gender VARCHAR(10) CHECK(gender IN('Male', 'Female', 'Other')),
	course VARCHAR(50),
	email VARCHAR(100) UNIQUE,
	phone_number VARCHAR(15),
	address TEXT
);
*/

--INSERT CreateStudent procedure
/*
CREATE PROCEDURE CreateStudent
	@first_name VARCHAR(50),
	@last_name VARCHAR(50),
	@date_of_birth DATE,
	@age INT,
	@gender VARCHAR(10),
	@course VARCHAR(50),
	@email VARCHAR(100),
	@phone_number VARCHAR(15),
	@address TEXT
AS
BEGIN
	INSERT INTO StudentAdmission (
		first_name, last_name, date_of_birth, age, gender, course, email, phone_number, address
	) VALUES (
		@first_name, @last_name, @date_of_birth, @age, @gender, @course, @email, @phone_number, @address
	);
END;
*/

--Execution of INSERT procedure
/*
EXEC CreateStudent
	@first_name = 'Shahan',
	@last_name = 'P',
	@date_of_birth = '2003-06-22',
	@age = 21,
	@gender = 'Male',
	@course = 'BCA',
	@email = 'shahan@gmail.com',
	@phone_number = '7894561234',
	@address = 'Puthanathani House';
*/

--SELECT * FROM StudentAdmission;

--READ procedure
/*
CREATE PROCEDURE ReadStudent
	@id INT = NULL
AS
BEGIN
	IF @id IS NOT NULL
	BEGIN
		SELECT * FROM StudentAdmission WHERE id = @id;
	END
	ELSE
	BEGIN
		SELECT * FROM StudentAdmission;
	END
END;
*/

--Execution of READ procedure by ID
--EXEC ReadStudent @id = 1;


--UPDATE procedure
/*
CREATE PROCEDURE UpdateStudent
    @id INT,
    @first_name VARCHAR(50) = NULL,
    @last_name VARCHAR(50) = NULL,
    @date_of_birth DATE = NULL,
    @age INT = NULL,
    @gender VARCHAR(10) = NULL,
    @course VARCHAR(50) = NULL,
    @email VARCHAR(100) = NULL,
    @phone_number VARCHAR(15) = NULL,
    @address TEXT = NULL
AS
BEGIN
    UPDATE StudentAdmission
    SET
        first_name = ISNULL(@first_name, first_name),
        last_name = ISNULL(@last_name, last_name),
        date_of_birth = ISNULL(@date_of_birth, date_of_birth),
        age = ISNULL(@age, age),
        gender = ISNULL(@gender, gender),
        course = ISNULL(@course, course),
        email = ISNULL(@email, email),
        phone_number = ISNULL(@phone_number, phone_number),
        address = ISNULL(@address, address)
    WHERE id = @id;
END;
*/

--Execution of UPDATE procedure
/*
EXEC UpdateStudent
	@id = 1,
	@first_name = 'Hashil',
	@last_name = NULL,
	@email = 'hashil@gmail.com';
*/

--SELECT * FROM StudentAdmission;

--DELETE procedure
/*
CREATE PROCEDURE DeleteStudent
	@id INT
AS
BEGIN
	DELETE FROM StudentAdmission WHERE id = @id;
END;
*/

--Execution of DELETE procedure by ID
--EXEC DeleteStudent @id = 1;

--SELECT * FROM StudentAdmission;
