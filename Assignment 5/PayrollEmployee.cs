using System;

public class PayrollEmployee : Employee
{
    public DateTime JoiningDate { get; set; }
    public double Experience { get; set; } // in years
    public double BasicSalary { get; set; }

    public PayrollEmployee(int id, string name, string manager, DateTime joining, double exp, double basic)
        : base(id, name, manager)
    {
        JoiningDate = joining;
        Experience = exp;
        BasicSalary = basic;
    }

    public double CalculateDA()
    {
        if (Experience > 10)
            return 0.12 * BasicSalary;
        else if (Experience > 7)
            return 0.07 * BasicSalary;
        else if (Experience > 5)
            return 0.041 * BasicSalary;
        else
            return 0.019 * BasicSalary;
    }

    public double CalculateHRA()
    {
        if (Experience > 10)
            return 0.085 * BasicSalary;
        else if (Experience > 7)
            return 0.065 * BasicSalary;
        else if (Experience > 5)
            return 0.038 * BasicSalary;
        else
            return 0.02 * BasicSalary;
    }

    public double CalculatePF()
    {
        if (Experience > 10)
            return 6200;
        else if (Experience > 7)
            return 4100;
        else if (Experience > 5)
            return 1800;
        else
            return 1200;
    }

    public double GetNetSalary()
    {
        double da = CalculateDA();
        double hra = CalculateHRA();
        double pf = CalculatePF();
        return BasicSalary + da + hra - pf;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Type      : Payroll Employee");
        Console.WriteLine($"Joined    : {JoiningDate.ToShortDateString()}");
        Console.WriteLine($"Experience: {Experience} years");
        Console.WriteLine($"Basic     : ₹{BasicSalary}");
        Console.WriteLine($"DA        : ₹{CalculateDA()}");
        Console.WriteLine($"HRA       : ₹{CalculateHRA()}");
        Console.WriteLine($"PF        : ₹{CalculatePF()}");
        Console.WriteLine($"Net Salary: ₹{GetNetSalary()}");
    }
}
