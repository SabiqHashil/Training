--Using user_management database
USE user_management;

--Retrieve list number of employees each department
SELECT department, COUNT(*) AS employee_count
FROM employee
GROUP BY department;


