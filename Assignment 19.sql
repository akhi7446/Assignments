create database assignment_19;
use assignment_19;

create table Employee
(employeeid int identity(1,1) primary key,
name varchar(40),
ReportingManager varchar(40),
Type varchar(30));

create table Payroll
(employeeid int primary key,
joiningdate Date,
Experience Decimal(4,1),
DA Decimal(10,2),
HRA Decimal(10,2),
PF Decimal(10,2),
NetSalary Decimal(10,2),
Foreign Key(EmployeeID) References Employee(EmployeeID));

Create table Contract
(EmployeeID int Primary Key,
ContractDate Date,
Durationinmonths int,
Charges Decimal(10,2),
Foreign key (EmployeeID) References Employee(EmployeeID));

CREATE PROCEDURE InsertEmployee
    @Name VARCHAR(40),
    @ReportingManager VARCHAR(40),
    @Type VARCHAR(30),
    @NewID INT OUTPUT
AS
BEGIN
    INSERT INTO Employee(Name, ReportingManager, Type)
    VALUES(@Name, @ReportingManager, @Type);

    SET @NewID = SCOPE_IDENTITY();
END;

CREATE PROCEDURE InsertContractEmployee
    @EmployeeID INT,
    @ContractDate DATE,
    @DurationInMonths INT,
    @Charges DECIMAL(10,2)
AS
BEGIN
    INSERT INTO ContractEmployee (EmployeeID, ContractDate, DurationInMonths, Charges)
    VALUES (@EmployeeID, @ContractDate, @DurationInMonths, @Charges);
END

