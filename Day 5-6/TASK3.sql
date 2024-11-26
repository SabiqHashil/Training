--Using user_management database
USE user_management;

--Create table employee
CREATE TABLE employee (
	id INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
	position VARCHAR(100) NOT NULL,
	salary DECIMAL(10, 2) NOT NULL,
	department VARCHAR(100) NOT NULL,
	hire_date DATE NOT NULL
);

--Insert data to employee table
INSERT INTO employee (name, position, salary, department, hire_date)
VALUES	('Sabiq', 'Manager', 75000.00, 'HR', '2020-01-15'),
		('Hashil', 'Engineer', 60000.00, 'IT', '2021-03-20'),
		('Mahir', 'Analyst', 65000.00, 'Finance', '2019-11-10'),
		('Shahan', 'Director', 90000.00, 'Management', '2018-05-25'),
		('Basith', 'Engineer', 60000.00, 'IT', '2022-07-01');

--Retrieve data from employee
SELECT * FROM employee;

--Retrieve maximum salary of employee in second_highest_salary
SELECT MAX(salary) AS second_highest_salary
FROM employee
WHERE salary < (SELECT MAX(salary) FROM employee);

