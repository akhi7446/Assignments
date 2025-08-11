-- Assignment 3 Final Script

-- Step 1: Create the database
create DATABASE Assignment_17;


-- Step 2: Use the database
USE Assignment_17;


-- Step 3: Create Department table FIRST
CREATE TABLE Department (
    deptId INT IDENTITY(1,1) PRIMARY KEY,
    deptName VARCHAR(50) CHECK (deptName IN ('HR', 'Sales', 'Accts', 'IT')) UNIQUE
);


-- Step 4: Create Employee table
CREATE TABLE Employee (
    employee_id INT IDENTITY(1001,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    exp INT CHECK (exp >= 2),
    salary INT CHECK (salary BETWEEN 12000 AND 30000),
    departmentid INT FOREIGN KEY REFERENCES Department(deptId),
    managerid INT NULL REFERENCES Employee(employee_id),
    age INT DEFAULT 26 CHECK (age BETWEEN 26 AND 60)
);


-- Step 5: Insert Departments
INSERT INTO Department (deptName) VALUES
('HR'),
('Sales'),
('Accts'),
('IT');


-- Step 6: Insert employees (insert Amit first)
INSERT INTO Employee (name, exp, salary, departmentid, managerid)
VALUES ('Amit', 5, 25000, 1, NULL);  -- 1001

-- Then insert rest (using Amit as manager)
INSERT INTO Employee (name, exp, salary, departmentid, managerid)
VALUES 
('Ravi', 4, 18000, 2, 1001),
('Pooja', 3, 16000, 3, 1001),
('Neha', 5, 27000, 4, 1001),
('Sumit', 2, 20000, 1, 1001);


-- Step 7: Procedure to insert or update
CREATE PROCEDURE addoup
    @employee_id INT = NULL,
    @name VARCHAR(100),
    @exp INT,
    @salary INT,
    @departmentid INT,
    @managerid INT = NULL
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Employee WHERE employee_id = @employee_id)
    BEGIN
        UPDATE Employee
        SET name = @name, exp = @exp, salary = @salary,
            departmentid = @departmentid, managerid = @managerid
        WHERE employee_id = @employee_id;
        PRINT 'Record updated successfully.';
    END
    ELSE
    BEGIN
        INSERT INTO Employee (name, exp, salary, departmentid, managerid)
        VALUES (@name, @exp, @salary, @departmentid, @managerid);
        PRINT 'Record inserted successfully.';
    END
END;


-- Step 8: Procedure to delete employee
CREATE PROCEDURE DeleteEmp
    @employee_id INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Employee WHERE employee_id = @employee_id)
    BEGIN
        DELETE FROM Employee WHERE employee_id = @employee_id;
        PRINT 'Record deleted successfully.';
    END
    ELSE
    BEGIN
        PRINT 'Employee ID not found.';
    END
END;


-- Step 9: Queries

-- 1. Display employee id, name, salary, department, manager name
SELECT 
    E.employee_id AS [Employee ID],
    E.name AS [Name of Employee],
    E.salary AS [Salary of Employee],
    D.deptName AS [Department],
    M.name AS [Manager Name]
FROM Employee E
JOIN Department D ON E.departmentid = D.deptId
LEFT JOIN Employee M ON E.managerid = M.employee_id;


-- 2. Display name, salary, increased salary
SELECT 
    name,
    salary,
    salary + 2000 AS [Increased Salary]
FROM Employee;


-- 3. Total salary per department
SELECT 
    D.deptName,
    SUM(E.salary) AS [Total Salary]
FROM Employee E
JOIN Department D ON E.departmentid = D.deptId
GROUP BY D.deptName;


-- 4. Total, max, avg salary per department
SELECT 
    D.deptName,
    SUM(E.salary) AS TotalSalary,
    MAX(E.salary) AS MaxSalary,
    AVG(E.salary) AS AvgSalary
FROM Employee E
JOIN Department D ON E.departmentid = D.deptId
GROUP BY D.deptName;


-- 5. Unique sequence for employees
SELECT 
    ROW_NUMBER() OVER (ORDER BY employee_id) AS [Employee No],
    name, salary
FROM Employee;


-- 6. Rank employees by salary
SELECT 
    RANK() OVER (ORDER BY salary DESC) AS [Rank],
    name, salary
FROM Employee;


-- 7. Update age = 26 if NULL (safety)
UPDATE Employee SET age = 26 WHERE age IS NULL;


-- 8. Count total departments
SELECT COUNT(*) AS [Total Departments] FROM Department;


