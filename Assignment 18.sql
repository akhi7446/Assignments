create database assignment_18;
use assignment_18;
--Make following tables:

-- Student
-- Rn , Name , Address, Marks , DOB
CREATE TABLE Student (
    Rn INT PRIMARY KEY,
    Name VARCHAR(100),
    Address VARCHAR(255),
    Marks INT,
    DOB DATE,
    Batch_Code VARCHAR(10), -- Foreign Key
    FOREIGN KEY (Batch_Code) REFERENCES Batch(Batch_Code)
);
INSERT INTO student VALUES 
(101, 'Ravi Kumar', 'Pune', 85, '2002-06-15', 'B101'),
(102, 'Sneha Joshi', 'Hyderabad', 90, '2001-12-10', 'B102'),
(103, 'Arjun Mehta', 'Chennai', 78, '2003-03-25', 'B103'),
(104, 'Priya Singh', 'Kolkata', 88, '2002-09-05', 'B101');

-- Batch
-- Batch Code, Name, Duration, Description
CREATE TABLE Batch (
    Batch_Code VARCHAR(10) PRIMARY KEY,
    Name VARCHAR(100),
    Duration VARCHAR(50),
    Description TEXT,
    Trainer_ID INT, -- Foreign Key
    FOREIGN KEY (Trainer_ID) REFERENCES Trainer(Trainer_ID)
);
INSERT INTO batch VALUES 
('B101', 'Data Science Bootcamp', '3 months', 'Intensive hands-on data science course', 1),
('B102', 'AI Fundamentals', '4 months', 'Basics and applications of AI and ML', 2),
('B103', 'Full Stack Web Dev', '6 months', 'Front-end + Back-end training', 3);

-- Fees
-- Fees_Paid, Date_Paid
CREATE TABLE Fees (
    Rn INT, -- Foreign Key to Student
    Fees_Paid DECIMAL(10, 2),
    Date_Paid DATE,
    FOREIGN KEY (Rn) REFERENCES Student(Rn)
);
INSERT INTO fees VALUES 
(101, 25000.00, '2025-07-01'),
(102, 30000.00, '2025-07-03'),
(103, 28000.00, '2025-07-05'),
(104, 25000.00, '2025-07-07');

-- Trainer
--Trainer ID, Trainer Name, Address,Qualification, Experience, Domain
CREATE TABLE Trainer (
    Trainer_ID INT PRIMARY KEY,
    Trainer_Name VARCHAR(100),
    Address VARCHAR(255),
    Qualification VARCHAR(100),
    Experience INT,
    Domain VARCHAR(100)
);
INSERT INTO trainer VALUES 
(1, 'Amit Sharma', 'Delhi', 'M.Tech', 5, 'Data Science'),
(2, 'Neha Verma', 'Mumbai', 'PhD', 8, 'AI & ML'),
(3, 'Raj Patel', 'Bangalore', 'MCA', 4, 'Web Development');

-- After these tables are there,

-- 1. Display STudent name, his address, Batch Code, Batch Name,Faculy Name, Duration of the batch
SELECT 
    s.Name AS Student_Name,
    s.Address AS Student_Address,
    b.Batch_Code,
    b.Name AS Batch_Name,
    t.Trainer_Name,
    b.Duration
FROM 
    Student s
JOIN 
    Batch b ON s.Batch_Code = b.Batch_Code
JOIN 
    Trainer t ON b.Trainer_ID = t.Trainer_ID;

-- 2. Student name and the fees paid by the student and the 
-- date on which the fees was paid
SELECT 
    s.name AS student_name,
    f.fees_paid,
    f.date_paid
FROM 
    student s
JOIN 
    fees f ON s.rn = f.rn;

-- 3. Batch Code, Batch Name and the Trainer details

SELECT 
    b.batch_code,
    b.name AS batch_name,
    t.trainer_id,
    t.trainer_name,
    t.address,
    t.qualification,
    t.experience,
    t.domain
FROM 
    batch b
JOIN 
    trainer t ON b.trainer_id = t.trainer_id;

