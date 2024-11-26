use user_management

--a. Normalization Techniques - All the normal forms
--Table in 1NF
CREATE TABLE Employee1 (
	emp_id INT PRIMARY KEY,
	emp_name VARCHAR(100),
	phone_number VARCHAR(15)
);

INSERT INTO Employee1 VALUES	(1, 'Sabiq', '1234567895'),
								(2, 'Hashil', '7894561235'),
								(3, 'Shahan', '4567891235');

--Table in 2NF
CREATE TABLE Employee2 (
	emp_id INT PRIMARY KEY,
	emp_name VARCHAR(100),
);

CREATE TABLE EmployeePhone (
	emp_id INT,
	phone_number VARCHAR(15),
	FOREIGN KEY (emp_id) REFERENCES Employee2(emp_id)
);

--Table in 3NF
CREATE TABLE Department1 (
	dept_id INT PRIMARY KEY,
	dept_name VARCHAR(100)
);

CREATE TABLE Employee3 (
	emp_id INT PRIMARY KEY,
	emp_name VARCHAR(100),
	dept_id INT,
	FOREIGN KEY (dept_id) REFERENCES Department1(dept_id)
);

--Table in BCNF
CREATE TABLE Department2 (
	dept_id INT PRIMARY KEY,
	dept_name VARCHAR(100),
	manager_name VARCHAR(100)
);



--b. Indexing - Cluster and non-cluster indexing
CREATE TABLE EmployeeCluster (
    emp_id INT PRIMARY KEY,
    emp_name VARCHAR(100),
    emp_department VARCHAR(50),
    emp_salary DECIMAL(10, 2)
);

INSERT INTO EmployeeCluster(emp_id, emp_name, emp_department, emp_salary)
VALUES	(1, 'Sabiq', 'HR', 50000),
		(2, 'Hashil', 'IT', 60000),
		(3, 'Bob Johnson', 'Finance', 55000),
		(4, 'Alice Brown', 'Marketing', 65000),
		(5, 'Chris White', 'HR', 52000);

SELECT * FROM EmployeeCluster;

--CLUSTERED index
CREATE CLUSTERED INDEX idx_emp_id ON EmployeeCluster(emp_id);
--NONCLUSTERED index
CREATE NONCLUSTERED INDEX idx_emp_name ON EmployeeCluster(emp_name);

SELECT * FROM EmployeeCluster;



--c. Pivot and unpivot the values is SQL table
CREATE TABLE EmployeeSalary (
    emp_id INT,
    dept_name VARCHAR(100),
    year INT,
    salary DECIMAL(10, 2)
);


INSERT INTO EmployeeSalary (emp_id, dept_name, year, salary) 
VALUES	(1, 'HR', 2020, 50000),
		(2, 'IT', 2020, 60000),
		(3, 'HR', 2021, 52000),
		(4, 'IT', 2021, 62000),
		(5, 'HR', 2022, 53000),
		(6, 'IT', 2022, 63000);

SELECT * FROM EmployeeSalary;

--PIVOT query
SELECT dept_name, [2020] AS salary_2020, [2021] AS salary_2021, [2022] AS salary_2022
FROM (
    SELECT dept_name, year, salary
    FROM EmployeeSalary
) AS SourceTable
PIVOT (
    SUM(salary)
    FOR year IN ([2020], [2021], [2022])
) AS PivotTable;

--UNPIVOT query
SELECT dept_name, year, salary
FROM EmployeeSalary;



--d. Merge concepts in SQL table
--Create table merge1
CREATE TABLE merge1 (
	emp_id INT PRIMARY KEY,
	emp_name VARCHAR(50),
	salary DECIMAL(10, 2)
);

INSERT INTO merge1 (emp_id, emp_name, salary)
VALUES	(1, 'Sabiq', 50000),
		(2, 'Hashil', 60000),
		(3, 'Sbq', 55000);

--SELECT * FROM merge1;

--Create table merge2
CREATE TABLE merge2 (
	emp_id INT PRIMARY KEY,
	emp_name VARCHAR(50),
	salary DECIMAL(10, 2)
);

INSERT INTO merge2 (emp_id, emp_name, salary)
VALUES	(2, 'Hashil', 65000),
		(4, 'Shahan', 70000);

--SELECT * FROM merge2;

--MERGE operation
MERGE INTO merge1 AS Target USING merge2 AS Source
ON Target.emp_id = Source.emp_id
WHEN MATCHED THEN
	UPDATE SET Target.emp_name = Source.emp_name, Target.salary = Source.salary
WHEN NOT MATCHED BY TARGET THEN
	INSERT (emp_id, emp_name, salary)
	VALUES (Source.emp_id, Source.emp_name, Source.salary)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SELECT * FROM merge1;
