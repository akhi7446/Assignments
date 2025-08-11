CREATE DATABASE ASSIGNMENT_15;

USE ASSIGNMENT_15;


CREATE TABLE worker 
( worker_id int PRIMARY KEY,
first_name varchar(25) NOT NULL,
last_name varchar(25),
salary int CHECK(salary BETWEEN 10000 AND 25000),
joining_date DATETIME,
Department varchar(25) CHECK(Department IN('HR','Sales','Accts','IT')));

INSERT INTO Worker (WORKER_ID, FIRST_NAME, LAST_NAME, SALARY, JOINING_DATE, DEPARTMENT) VALUES
(1, 'Jai', 'Balu', 20000, '2016-06-11 00:00:00', 'HR'),
(2, 'Satish', 'Kalyan', 18000, '2016-06-11 00:00:00', 'Sales'),
(3, 'Viru', 'Manas', 15000, '2016-06-11 00:00:00', 'IT'),
(4, 'Radhika', 'Tillu', 22000, '2016-06-11 00:00:00', 'Accts'),
(5, 'John', 'Deer', 24000, '2016-06-11 00:00:00', 'HR'),
(6, 'Anita', 'Singh', 17000, '2016-06-11 00:00:00', 'Sales'),
(7, 'Tours', 'Verma', 12000, '2016-06-11 00:00:00', 'IT'),
(8, 'Neha', 'Yadav', 25000, '2016-06-11 00:00:00', 'Accts');

select * from worker;


--Q-1. Write an SQL query to fetch “FIRST_NAME” from Worker table using the alias name as <WORKER_NAME>.
SELECT first_name as worker_name from worker;
--Q-2. Write an SQL query to fetch “FIRST_NAME” from Worker table in upper case.
select upper(first_name ) from worker;
--Q-3. Write an SQL query to fetch unique values of DEPARTMENT from Worker table.
select distinct department from worker;
--Q-4. Write an SQL query to print the first three characters of  FIRST_NAME from Worker table.
select SUBSTRING(first_name,1,3) from worker; 
--Q-5. Write an SQL query to find the position of the alphabet (‘a’) in the first name column ‘Amitabh’ from Worker table.
select CHARINDEX('r','Tours');
--Q-6. Write an SQL query to print the FIRST_NAME from Worker table after removing white spaces from the right side.
select RTRIM(first_name)from worker;
--Q-7. Write an SQL query to print the DEPARTMENT from Worker table after removing white spaces from the left side.
select LTRIM(Department)from worker;
--Q-8. Write an SQL query that fetches the unique values of DEPARTMENT from Worker table and prints its length.
select distinct department,len(department)as length from worker;
--Q-9. Write an SQL query to print the FIRST_NAME from Worker table after replacing ‘a’ with ‘A’.
select replace(first_name,'a','A') from worker;
--Q-10. Write an SQL query to print the FIRST_NAME and LAST_NAME from Worker table into a single column COMPLETE_NAME. A space char should separate them.
select first_name+' '+ last_name as Full_name from worker;
--Q-11. Write an SQL query to print all Worker details from the Worker table order by FIRST_NAME Ascending.
select * from worker
order by first_name ASC;
--Q-12. Write an SQL query to print all Worker details from the Worker table order by FIRST_NAME Ascending and DEPARTMENT Descending.
select * from worker
order by first_name ASC,Department desc;
--Q-13. Write an SQL query to print details for Workers with the first name as “Vipul” and “Satish” from Worker table.
select * from worker
where first_name in('Anita','jai');
--Q-14. Write an SQL query to print details of workers excluding first names, “Vipul” and “Satish” from Worker table.
select * from worker
where first_name not in('Anita','jai');
--Q-15. Write an SQL query to print details of Workers with DEPARTMENT name as “Admin”.
select * from worker
where Department = 'Admin';
--Q-16. Write an SQL query to print details of the Workers whose FIRST_NAME contains ‘a’.
select * from worker
where first_name like '%a%';
--Q-17. Write an SQL query to print details of the Workers whose FIRST_NAME ends with ‘a’.
select * from worker
where first_name like '%a';
--Q-18. Write an SQL query to print details of the Workers whose FIRST_NAME ends with ‘h’ and contains six alphabets.
select * from worker
where first_name like '______a';
--Q-19. Write an SQL query to print details of the Workers whose SALARY lies between 100000 and 500000.
select * from worker
where salary between 20000 and 30000;
--Q-20. Write an SQL query to print details of the Workers who have joined in Feb’2014.
select * from worker
where month(joining_Date) = 2 and year(joining_Date)=2014;
--Q-21. Write an SQL query to fetch the count of employees working in the department ‘Admin’.
select count (*) from worker
where department = 'Admin';