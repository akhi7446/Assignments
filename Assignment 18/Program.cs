using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static string connectionString = @"server=.\\SQLSERVER;database=assignment_19;integrated security=true";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nEmployee Management System");
            Console.WriteLine("1. Add Payroll Employee");
            Console.WriteLine("2. Add Contract Employee");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddPayrollEmployee();
                    break;
                case 2:
                    AddContractEmployee();
                    break;
                case 3:
                    Console.WriteLine("Exiting application.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void AddPayrollEmployee()
    {
        Console.WriteLine("\nAdd Payroll Employee");
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Reporting Manager: ");
        string manager = Console.ReadLine();
        Console.Write("Enter Joining Date (yyyy-mm-dd): ");
        DateTime joiningDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter Experience (in years): ");
        double experience = double.Parse(Console.ReadLine());
        Console.Write("Enter Basic Salary: ");
        decimal basic = decimal.Parse(Console.ReadLine());

        // Calculate salary components
        decimal da, hra, pf, net;

        if (experience > 10)
        {
            da = 0.10m * basic;
            hra = 0.085m * basic;
            pf = 6200;
        }
        else if (experience > 7)
        {
            da = 0.07m * basic;
            hra = 0.065m * basic;
            pf = 4100;
        }
        else if (experience > 5)
        {
            da = 0.041m * basic;
            hra = 0.038m * basic;
            pf = 1800;
        }
        else
        {
            da = 0.019m * basic;
            hra = 0.02m * basic;
            pf = 1200;
        }

        net = basic + da + hra - pf;

        int employeeId;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("InsertEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@ReportingManager", manager);
            cmd.Parameters.AddWithValue("@Type", "Payroll");

            SqlParameter outputIdParam = new SqlParameter("@NewID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputIdParam);

            cmd.ExecuteNonQuery();
            employeeId = (int)outputIdParam.Value;
        }

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertPayrollEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
            cmd.Parameters.AddWithValue("@JoiningDate", joiningDate);
            cmd.Parameters.AddWithValue("@Experience", experience);
            cmd.Parameters.AddWithValue("@BasicSalary", basic);
            cmd.Parameters.AddWithValue("@DA", da);
            cmd.Parameters.AddWithValue("@HRA", hra);
            cmd.Parameters.AddWithValue("@PF", pf);
            cmd.Parameters.AddWithValue("@NetSalary", net);

            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Payroll employee added successfully!");
    }

    static void AddContractEmployee()
    {
        Console.WriteLine("\nAdd Contract Employee");
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Reporting Manager: ");
        string manager = Console.ReadLine();
        Console.Write("Enter Contract Date (yyyy-mm-dd): ");
        DateTime contractDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter Duration (in months): ");
        int duration = int.Parse(Console.ReadLine());
        Console.Write("Enter Charges: ");
        decimal charges = decimal.Parse(Console.ReadLine());

        int employeeId;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("InsertEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@ReportingManager", manager);
            cmd.Parameters.AddWithValue("@Type", "Contract");

            SqlParameter outputIdParam = new SqlParameter("@NewID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputIdParam);

            cmd.ExecuteNonQuery();
            employeeId = (int)outputIdParam.Value;
        }

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertContractEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
            cmd.Parameters.AddWithValue("@ContractDate", contractDate);
            cmd.Parameters.AddWithValue("@DurationInMonths", duration);
            cmd.Parameters.AddWithValue("@Charges", charges);

            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Contract employee added successfully!");
    }
}
