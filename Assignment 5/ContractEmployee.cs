using System;

public class ContractEmployee : Employee
{
    public DateTime ContractDate { get; set; }
    public int DurationInMonths { get; set; }
    public double Charges { get; set; }

    public ContractEmployee(int id, string name, string manager, DateTime date, int duration, double charges)
        : base(id, name, manager)
    {
        ContractDate = date;
        DurationInMonths = duration;
        Charges = charges;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Type      : Contract Employee");
        Console.WriteLine($"Contract  : {ContractDate.ToShortDateString()} for {DurationInMonths} months");
        Console.WriteLine($"Charges   : ₹{Charges}");
    }
}
