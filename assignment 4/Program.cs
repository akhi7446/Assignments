using System;
using System.Collections.Generic;

/*
     Assignment 3  / Do Assignment 4, use List initializer, hard code 5 records for product
    Create a class for product :

     All the products have pcode (which is different for every product, and once it is set for one product,  it shall remain same), pname, qty_in_stock,discount_allowed brand (which is common for every one, and all the products are different for every brand.

     Add appropriate methods :
     1)For Taking Inputs from Admin
    2) Display the details of the products

    Customer comes and wants to purchase products
    Shall enter pname & display details of that product & qty 
     2)calculate total amount , also while calculating total amount, as today is 26th Jan, Company wants to give a discount of 50% on all the products..
    Take care of  that while calculating total amount to be paid...
     3)produce bill..

     Who are you > Admin 
    1. Add product
    2. Display products

    Customer
    Order Product
    Get Bill 
 */
class Product
{
    private string pcode;
    private string pname;
    private int qty_in_stock;
    private double discount_allowed;
    private static string brand = "GenericBrand";
    private double price;

    public Product(string code, string name, int stockQty, double discount, double price)
    {
        this.pcode = code;
        this.pname = name;
        this.qty_in_stock = stockQty;
        this.discount_allowed = discount;
        this.price = price;
    }

    public string Pname => pname;
    public double Price => price;
    public int Stock => qty_in_stock;

    public void Display()
    {
        Console.WriteLine($"Code: {pcode}, Name: {pname}, Stock: {qty_in_stock}, Discount: {discount_allowed}%, Brand: {brand}, Price: ₹{price}");
    }

    public double CalculateTotal(int qty)
    {
        if (qty > qty_in_stock)
        {
            Console.WriteLine("Not enough stock available.");
            return 0;
        }

        double total = price * qty;
        double totalAfterDiscount = total * 0.5; // 50% Republic Day discount
        return totalAfterDiscount;
    }

    public void ReduceStock(int qty)
    {
        qty_in_stock -= qty;
    }
}

class Program
{
    static List<Product> productList = new List<Product>
    {
        new Product("P001", "Chips", 50, 10, 20),
        new Product("P002", "Chocolate", 40, 5, 25),
        new Product("P003", "Biscuits", 60, 15, 15),
        new Product("P004", "Juice", 30, 12, 35),
        new Product("P005", "Noodles", 70, 8, 18)
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nWelcome! Who are you?");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Customer Order");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayAllProducts();
                    break;
                case "2":
                    CustomerMenu();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void DisplayAllProducts()
    {
        Console.WriteLine("\n--- Product List ---");
        foreach (Product p in productList)
        {
            p.Display();
        }
    }

    static void CustomerMenu()
    {
        Console.Write("\nEnter product name to purchase: ");
        string searchName = Console.ReadLine();
        Product found = null;

        foreach (Product p in productList)
        {
            if (p.Pname.Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                found = p;
                break;
            }
        }

        if (found == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        found.Display();

        Console.Write("Enter quantity to purchase: ");
        int qty = int.Parse(Console.ReadLine());

        double total = found.CalculateTotal(qty);

        if (total > 0)
        {
            found.ReduceStock(qty);
            Console.WriteLine("\n Bill ");
            Console.WriteLine($"Product: {found.Pname}");
            Console.WriteLine($"Quantity: {qty}");
            Console.WriteLine($"Total (after 50% discount): ₹{total}");
        }
    }
}
