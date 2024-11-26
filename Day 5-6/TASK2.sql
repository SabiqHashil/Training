CREATE DATABASE user_management;

--Using user_management database
USE user_management;

--Create table signup
CREATE TABLE signup (
    id INT IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    date_of_birth DATE NOT NULL,
    age INT NOT NULL,
    gender VARCHAR(10) NOT NULL CHECK(gender IN ('Male', 'Female', 'Other')),
    phone_number VARCHAR(15) UNIQUE NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    address TEXT NOT NULL,
    state VARCHAR(50) NOT NULL,
    city VARCHAR(50) NOT NULL,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT GETDATE()
);

--Create table login
CREATE TABLE login(
	id INT IDENTITY(1,1) PRIMARY KEY,
	email VARCHAR(100) UNIQUE NOT NULL,
	password VARCHAR(255) NOT NULL,
	FOREIGN KEY (email) REFERENCES signup(email)
);

--Insert data to signup table
INSERT INTO signup (
	first_name, last_name, date_of_birth, age, gender, phone_number, email, address, state, city, username, password, confirm_password
	) VALUES (
	'Sabiq', 'Hashil', '2002-02-13', 22, 'Male', '1234567890', 'sabiq@gmail.com', 'Kanjippura House', 'Kerala', 'Valanjeri', 'sbq', 'password123'
	);

--Insert data to login table
INSERT INTO login (email, password)
VALUES ('sabiq@gmail.com', 'password123');

--Update signup data
UPDATE signup
SET phone_number = '0123456789', city = 'Kottakkal'
WHERE email = 'sabiq@gmail.com';

--Retrieve signup data
SELECT * FROM signup;

--Retrieve login data
SELECT * FROM login
WHERE email = 'sabiq@gmail.com';

--Delete data in signup
DELETE FROM login
WHERE email = 'sabiq@gmail.com';

--Delete data in signup
DELETE FROM signup
WHERE email = 'sabiq@gmail.com';

