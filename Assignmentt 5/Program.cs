using System;
using System.Collections.Generic;

class Employee
{
    int id;
    string name;
    string manager;

    public Employee(int id, string name, string manager)
    {
        this.id = id;
        this.name = name;
        this.manager = manager;
    }

    public virtual void Display()
    {
        Console.WriteLine($"ID: {id}, Name: {name}, Manager: {manager}");
    }
}

class ContractEmployee : Employee
{
    DateTime contractDate;
    int duration;
    double charges;

    public ContractEmployee(int id, string name, string manager, DateTime date, int duration, double charges)
        : base(id, name, manager)
    {
        this.contractDate = date;
        this.duration = duration;
        this.charges = charges;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Type       : Contract");
        Console.WriteLine($"Start Date : {contractDate.ToShortDateString()}");
        Console.WriteLine($"Duration   : {duration} months");
        Console.WriteLine($"Charges    : {charges} INR");
    }
}

class PayrollEmployee : Employee
{
    DateTime joiningDate;
    double exp;
    double basic;

    public PayrollEmployee(int id, string name, string manager, DateTime joinDate, double exp, double basic)
        : base(id, name, manager)
    {
        this.joiningDate = joinDate;
        this.exp = exp;
        this.basic = basic;
    }

    double GetDA()
    {
        if (exp > 10) return 0.12 * basic;
        if (exp > 7) return 0.07 * basic;
        if (exp > 5) return 0.041 * basic;
        return 0.019 * basic;
    }

    double GetHRA()
    {
        if (exp > 10) return 0.085 * basic;
        if (exp > 7) return 0.065 * basic;
        if (exp > 5) return 0.038 * basic;
        return 0.02 * basic;
    }

    double GetPF()
    {
        if (exp > 10) return 6200;
        if (exp > 7) return 4100;
        if (exp > 5) return 1800;
        return 1200;
    }

    double GetNetSalary()
    {
        return basic + GetDA() + GetHRA() - GetPF();
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Type        : Payroll");
        Console.WriteLine($"Joining Date: {joiningDate.ToShortDateString()}");
        Console.WriteLine($"Experience  : {exp} years");
        Console.WriteLine($"Basic       : {basic} INR");
        Console.WriteLine($"DA          : {GetDA()} INR");
        Console.WriteLine($"HRA         : {GetHRA()} INR");
        Console.WriteLine($"PF          : {GetPF()} INR");
        Console.WriteLine($"Net Salary  : {GetNetSalary()} INR");
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        Console.Write("Enter number of employees: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nEnter details for Employee {i + 1}");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Reporting Manager: ");
            string manager = Console.ReadLine();

            Console.Write("Type (1 = Contract, 2 = Payroll): ");
            int type = int.Parse(Console.ReadLine());

            if (type == 1)
            {
                Console.Write("Contract Start Date (yyyy-mm-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Contract Duration (months): ");
                int duration = int.Parse(Console.ReadLine());

                Console.Write("Charges: ");
                double charges = double.Parse(Console.ReadLine());

                employees.Add(new ContractEmployee(id, name, manager, date, duration, charges));
            }
            else if (type == 2)
            {
                Console.Write("Joining Date (yyyy-mm-dd): ");
                DateTime joining = DateTime.Parse(Console.ReadLine());

                Console.Write("Experience (in years): ");
                double exp = double.Parse(Console.ReadLine());

                Console.Write("Basic Salary: ");
                double basic = double.Parse(Console.ReadLine());

                employees.Add(new PayrollEmployee(id, name, manager, joining, exp, basic));
            }
            else
            {
                Console.WriteLine("Invalid type. Skipping this employee.");
            }
        }

        Console.WriteLine("\n--- Employee Details ---\n");

        foreach (var emp in employees)
        {
            emp.Display();
            Console.WriteLine("-----------------------------");
        }

        Console.WriteLine($"\nTotal Employees: {employees.Count}");
    }
}
