using System;

class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();

        while (true)
        {
            Console.WriteLine("\nWho are you?");
            Console.WriteLine("1. Admin - View Products");
            Console.WriteLine("2. Customer - Order & Get Bill");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    shop.DisplayProducts();
                    break;
                case "2":
                    shop.OrderProduct();
                    shop.GenerateBill();
                    break;
                case "3":
                    Console.WriteLine("Thank you! Goodbye.");
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
