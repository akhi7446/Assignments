create database assignment_16;
use assignment_16;

CREATE TABLE employe (
    employee_id INT PRIMARY KEY IDENTITY(100, 1),
    name CHAR(20) NOT NULL,
    exp INT CHECK (exp >= 2),
    salary INT CHECK (salary BETWEEN 12000 AND 30000),
    department_name VARCHAR(20) CHECK (department_name IN ('HR', 'Sales', 'Accts', 'IT')),
    manager_name CHAR(20)
);

INSERT INTO employe (name, exp, salary, department_name, manager_name) VALUES
('Aman', 3, 15000, 'HR', 'Meera'),
('Rohit', 5, 25000, 'Sales', 'Karan'),
('Deepa', 2, 12000, 'Accts', 'Neha'),
('Ramesh', 7, 30000, 'IT', 'Sameer'),
('Neha', 4, 14000, 'Sales', 'Karan');

select * from employe;

-- 1. Display employee id , name , salary.
select employee_id,name,salary from employe;
-- 2.Display employee id , where Employee ID  , name where Name of Employee ,   salary Salary of Employee shud be displayed
SELECT 
    employee_id AS [Employee ID],
    name AS [Name of Employee],
    salary AS [Salary of Employee]
FROM employe;
--3.Display  name  salary and also incremented salary for all the employees
SELECT 
    name, 
    salary, 
    salary * 1.10 AS [Increased Salary]
FROM employe;
--4. Display Total salary dispursed for all the departments
SELECT 
    department_name, 
    SUM(salary) AS total_salary
FROM employe
GROUP BY department_name;
--5. Display total salary, maximum salary, Average salary given in all the deprtments
SELECT 
    department_name,
    SUM(salary) AS total_salary,
    MAX(salary) AS max_salary,
    AVG(salary) AS avg_salary
FROM employe
GROUP BY department_name;
--6. Depending uopn salary, arrange the records 
SELECT * FROM employe
ORDER BY salary DESC;
--7. Give a unique sequence to all the employees
SELECT 
    ROW_NUMBER() OVER (ORDER BY employee_id) AS sequence_number,
    *
FROM employe;
--8. Depending uopn salary, giv ranking tp all the employees
SELECT 
    RANK() OVER (ORDER BY salary DESC) AS salary_rank,
    *
FROM employe;
--9. Add one more column age in employees table
ALTER TABLE employe
ADD age INT;
--10. By default its value shud be 26
ALTER TABLE employe
ADD CONSTRAINT DF_Age DEFAULT 26 FOR age;
--11. Its range is 26 - 60
-- What value will be there for the records for this column now.
-- How can u put value 26 for all the records
ALTER TABLE employe
ADD CONSTRAINT CHK_Age CHECK (age BETWEEN 26 AND 60);

UPDATE employe
SET age = 26
WHERE age IS NULL;

--12. how many departments are there in the department
SELECT COUNT(DISTINCT department_name) AS department_count
FROM employe;
--13. Display all the names of the employees in upper case
SELECT UPPER(name) AS name_upper FROM employe;
--14. DIpslay only the first four alphbets from all the names
SELECT SUBSTRING(name, 1, 4) AS short_name FROM employe;
--15. DIsplay the position of a in all the names
SELECT name, CHARINDEX('a', name) AS position_of_a
FROM employe;
--16.Display total number of employees working in every department
SELECT department_name, COUNT(*) AS employee_count
FROM employe
GROUP BY department_name;
--17.Display total number of employees working for every Manager
SELECT manager_name, COUNT(*) AS employee_count
FROM employe
GROUP BY manager_name;
--18. DIsplay all the recirds where employee ID is 101, 102 or 110
SELECT * FROM employe
WHERE employee_id IN (101, 102, 110);
--19. GIve all records where empl id is in between 101 and 100
SELECT * FROM employe
WHERE employee_id BETWEEN 100 AND 101;
--20. Give all records where department is HR
SELECT * FROM employe
WHERE department_name = 'HR';
--21. Give all records where department is HR or Accts
SELECT * FROM employe
WHERE department_name IN ('HR', 'Accts');
--22. Give all records where name starts with A
SELECT * FROM employe
WHERE name LIKE 'A%';
--23. GIve all records where name contains a
SELECT * FROM employe
WHERE name LIKE '%a%';
--24. Give all records where average sales is less than 12000 department wise
SELECT department_name, AVG(salary) AS avg_salary
FROM employe
GROUP BY department_name
HAVING AVG(salary) < 12000;
--25. Give records where department is not Accts and sales is not in between 10000 and 20000
SELECT * FROM employe
WHERE department_name != 'Accts'
AND salary NOT BETWEEN 10000 AND 20000;
