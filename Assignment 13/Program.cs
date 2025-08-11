using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Run Task 1 (Directories and Files)");
            Console.WriteLine("2. Run Task 2 (File Menu with StreamWriter/Reader)");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Task1.Main1();
                    break;
                case 2:
                    Task2.Run();
                    break;
                case 0:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 0);
    }
}
