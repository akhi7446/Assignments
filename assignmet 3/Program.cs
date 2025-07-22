using System;
using System.Collections.Generic;

namespace ProductBilling
{
    class Program
    {
        static void Main(string[] args)
        {
            Product.Brand = "SmartBrand"; // Common for all products
            Shop shop = new Shop();

            while (true)
            {
                Console.WriteLine("\nWho are you?");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Customer");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                if (input == "1")
                    shop.AdminMenu();
                else if (input == "2")
                    shop.CustomerMenu();
                else if (input == "3")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                    Console.WriteLine("Invalid input. Try again.");
            }
        }
    }
}
