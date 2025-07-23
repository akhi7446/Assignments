using System;
using System.Collections.Generic;


/*
 Assignment 3  
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
    private static string brand = "GenericBrand"; // common for all
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
        Console.WriteLine($"Code: {pcode}, Name: {pname}, Stock: {qty_in_stock}, Discount: {discount_allowed}%, Brand: {brand}, Price: {price}");
    }

    public double CalculateTotal(int qty)
    {
        if (qty > qty_in_stock)
        {
            Console.WriteLine("Not enough stock available.");
            return 0;
        }

        double total = price * qty;
        double totalAfterDiscount = total * 0.5; // 50% discount for 26th Jan
        return totalAfterDiscount;
    }

    public void ReduceStock(int qty)
    {
        qty_in_stock -= qty;
    }
}

class Program
{
    static List<Product> productList = new List<Product>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nWho are you?");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AdminMenu();
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

    static void AdminMenu()
    {
        Console.WriteLine("\nAdmin Menu:");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. Display Products");
        Console.Write("Enter choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddProduct();
                break;
            case "2":
                DisplayAllProducts();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void AddProduct()
    {
        Console.Write("Enter product code: ");
        string code = Console.ReadLine();

        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter quantity in stock: ");
        int qty = int.Parse(Console.ReadLine());

        Console.Write("Enter discount allowed (%): ");
        double discount = double.Parse(Console.ReadLine());

        Console.Write("Enter price per unit: ");
        double price = double.Parse(Console.ReadLine());

        Product newProduct = new Product(code, name, qty, discount, price);
        productList.Add(newProduct);
        Console.WriteLine("Product added successfully.");
    }

    static void DisplayAllProducts()
    {
        Console.WriteLine("\n Product List");
        foreach (Product p in productList)
        {
            p.Display();
        }
    }

    static void CustomerMenu()
    {
        Console.Write("\nEnter product name to search: ");
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
            Console.WriteLine($"Total (after 50% Republic Day discount): ₹{total}");
        }
    }
}
