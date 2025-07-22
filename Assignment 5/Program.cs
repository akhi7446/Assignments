using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        Console.Write("Enter number of employees: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nEntering details for Employee {i + 1}:");
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Reporting Manager: ");
            string manager = Console.ReadLine();

            Console.Write("Is this employee (1) Contract or (2) Payroll? Enter 1 or 2: ");
            string type = Console.ReadLine();

            if (type == "1")
            {
                Console.Write("Enter Contract Start Date (yyyy-mm-dd): ");
                DateTime contractDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Duration in Months: ");
                int duration = int.Parse(Console.ReadLine());

                Console.Write("Enter Charges: ");
                double charges = double.Parse(Console.ReadLine());

                employees.Add(new ContractEmployee(id, name, manager, contractDate, duration, charges));
            }
            else if (type == "2")
            {
                Console.Write("Enter Joining Date (yyyy-mm-dd): ");
                DateTime joiningDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Experience (in years): ");
                double experience = double.Parse(Console.ReadLine());

                Console.Write("Enter Basic Salary: ");
                double basic = double.Parse(Console.ReadLine());

                employees.Add(new PayrollEmployee(id, name, manager, joiningDate, experience, basic));
            }
            else
            {
                Console.WriteLine(" Invalid choice. Skipping this employee.");
            }
        }

        foreach (var emp in employees)
        {
            emp.Display();
        }

        Console.WriteLine($"\nTotal number of employees: {Employee.Count}");
    }
}
