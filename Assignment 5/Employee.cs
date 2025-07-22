public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Manager { get; set; }

    public static int Count = 0;

    public Employee(int id, string name, string manager)
    {
        ID = id;
        Name = name;
        Manager = manager;
        Count++;
    }

    public virtual void Display()
    {
        Console.WriteLine($"\nID        : {ID}");
        Console.WriteLine($"Name      : {Name}");
        Console.WriteLine($"Manager   : {Manager}");
    }
}
