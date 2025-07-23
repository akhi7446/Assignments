using System;
using System.Collections.Generic;


/*
There are 2 type of Employees 
OnContract Basis and OnPayroll

Add the required classes and members
Every employee should have a unique ID, name, reporting manager

Contract basis employees will have contract date, duration and charges

payroll employees will have Joining date, exp, basic salary , da, hra, etc. 
 

 Depending upon Exp, calculate Net Salary
if exp > 10 years , DA = 10 % of basic, HRA = 8.5 % of basic , PF = 6200
if exp > 7 years and less than 10 years , DA = 7 % of basic, HRA = 6.5 % of basic , PF = 4100
if exp > 5 years and less than 7 years, DA = 4.1 % of basic, HRA = 3.8 % of basic , PF = 1800
if exp < 5 years , DA = 1.9 % of basic, HRA = 2.0 % of basic , PF = 1200

Display the details in proper way

 You are supposed to do it for some Employees, count is not known. Which loop you will use? 

  1. Understand how you will make this class and add data members
  2. Create Methods accordingly:
       We know all details about Employee
  3. Print total number of Employees */

class Employee
{
    public string ID;
    public string Name;
    public string ReportingManager;

    public Employee(string id, string name, string manager)
    {
        ID = id;
        Name = name;
        ReportingManager = manager;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"ID: {ID}, Name: {Name}, Manager: {ReportingManager}");
    }
}

class ContractEmployee : Employee
{
    public string ContractDate;
    public int Duration; // in months
    public double Charges;

    public ContractEmployee(string id, string name, string manager, string contractDate, int duration, double charges)
        : base(id, name, manager)
    {
        ContractDate = contractDate;
        Duration = duration;
        Charges = charges;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"[Contract] Date: {ContractDate}, Duration: {Duration} months, Charges: ₹{Charges}");
    }
}

class PayrollEmployee : Employee
{
    public string JoiningDate;
    public double Experience; // in years
    public double BasicSalary;
    public double DA, HRA, PF, NetSalary;

    public PayrollEmployee(string id, string name, string manager, string joiningDate, double exp, double basic)
        : base(id, name, manager)
    {
        JoiningDate = joiningDate;
        Experience = exp;
        BasicSalary = basic;
        CalculateSalary();
    }

    public void CalculateSalary()
    {
        if (Experience > 10)
        {
            DA = 0.10 * BasicSalary;
            HRA = 0.085 * BasicSalary;
            PF = 6200;
        }
        else if (Experience > 7)
        {
            DA = 0.07 * BasicSalary;
            HRA = 0.065 * BasicSalary;
            PF = 4100;
        }
        else if (Experience > 5)
        {
            DA = 0.041 * BasicSalary;
            HRA = 0.038 * BasicSalary;
            PF = 1800;
        }
        else
        {
            DA = 0.019 * BasicSalary;
            HRA = 0.020 * BasicSalary;
            PF = 1200;
        }

        NetSalary = BasicSalary + DA + HRA - PF;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"[Payroll] Joining: {JoiningDate}, Exp: {Experience} years");
        Console.WriteLine($"Basic: ₹{BasicSalary}, DA: ₹{DA}, HRA: ₹{HRA}, PF: ₹{PF}");
        Console.WriteLine($"Net Salary: ₹{NetSalary}");
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        while (true)
        {
            Console.WriteLine("\nAdd New Employee");
            Console.WriteLine("1. Contract Employee");
            Console.WriteLine("2. Payroll Employee");
            Console.WriteLine("3. Display All Employees");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string ch = Console.ReadLine();

            if (ch == "1")
            {
                Console.Write("Enter ID: ");
                string id = Console.ReadLine();
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Reporting Manager: ");
                string manager = Console.ReadLine();
                Console.Write("Enter Contract Date: ");
                string date = Console.ReadLine();
                Console.Write("Enter Duration (months): ");
                int duration = int.Parse(Console.ReadLine());
                Console.Write("Enter Charges: ");
                double charges = double.Parse(Console.ReadLine());

                ContractEmployee ce = new ContractEmployee(id, name, manager, date, duration, charges);
                employees.Add(ce);
            }
            else if (ch == "2")
            {
                Console.Write("Enter ID: ");
                string id = Console.ReadLine();
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Reporting Manager: ");
                string manager = Console.ReadLine();
                Console.Write("Enter Joining Date: ");
                string date = Console.ReadLine();
                Console.Write("Enter Experience (years): ");
                double exp = double.Parse(Console.ReadLine());
                Console.Write("Enter Basic Salary: ");
                double basic = double.Parse(Console.ReadLine());

                PayrollEmployee pe = new PayrollEmployee(id, name, manager, date, exp, basic);
                employees.Add(pe);
            }
            else if (ch == "3")
            {
                Console.WriteLine($"\nTotal Employees: {employees.Count}");
                foreach (Employee emp in employees)
                {
                    emp.DisplayDetails();
                }
            }
            else if (ch == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
