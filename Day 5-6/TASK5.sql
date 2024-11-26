--Using user_management database
use user_management

--Create table department
CREATE TABLE department (
	dept_id INT IDENTITY(1,1) PRIMARY KEY,
	dept_name VARCHAR(100) NOT NULL
);

--Create table employees
CREATE TABLE employees (
	emp_id INT IDENTITY(1,1) PRIMARY KEY,
	emp_name VARCHAR(100) NOT NULL,
	salary DECIMAL(10, 2) NOT NULL,
	dept_id INT,
	FOREIGN KEY (dept_id) REFERENCES department(dept_id)
);

--Insert data to department table
INSERT INTO department (dept_name)
VALUES	('HR'),
		('IT'),
		('Finance'),
		('Management');

SELECT * FROM department;

--Insert data to employees table
INSERT INTO employees (emp_name, salary, dept_id)
VALUES	('Sabiq', 75000.0, 1),
		('Hashil', 60000.00, 2),
		('Mahir', 65000.00, NULL),
		('Asir', 90000.00, 4),
		('Shahan', 55000.0, 2);

SELECT * FROM employees;

--INNER JOIN
SELECT e.emp_name, e.salary, d.dept_name
FROM employees e
INNER JOIN department d
ON e.dept_id = d.dept_id;

--LEFT JOIN
SELECT e.emp_name, e.salary, d.dept_name
FROM employees e
LEFT JOIN department d
ON e.dept_id = d.dept_id;

--FULL OUTER JOIN
SELECT e.emp_name, e.salary, d.dept_name
FROM employees e
FULL OUTER JOIN department d
ON e.dept_id = d.dept_id;

--SELF JOIN
SELECT e1.emp_name AS employee, e2.emp_name AS compared_to
FROM employees e1
INNER JOIN employees e2
ON e1.salary > e2.salary;