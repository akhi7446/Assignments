using System;
using System.Collections.Generic;

public class Shop
{
    private Dictionary<string, Product> products = new Dictionary<string, Product>();
    private List<OrderItem> cart = new List<OrderItem>();

    public Shop()
    {
        // Hardcoded products using initializer
        var productList = new List<Product>
        {
            new Product("P001", "Mouse", 20, 10),
            new Product("P002", "Keyboard", 15, 5),
            new Product("P003", "Monitor", 10, 12),
            new Product("P004", "Printer", 8, 8),
            new Product("P005", "Speaker", 25, 15)
        };

        foreach (var product in productList)
        {
            products[product.PName] = product;
        }
    }

    public void DisplayProducts()
    {
        Console.WriteLine("\n--- Product List ---");
        foreach (var product in products.Values)
        {
            product.Display();
            Console.WriteLine("-----------------------");
        }
    }

    public void OrderProduct()
    {
        Console.Write("\nEnter product name to order: ");
        string name = Console.ReadLine().ToLower();

        if (!products.ContainsKey(name))
        {
            Console.WriteLine("❌ Product not found.");
            return;
        }

        Product selectedProduct = products[name];
        selectedProduct.Display();

        Console.Write("Enter quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
        {
            Console.WriteLine("❌ Invalid quantity.");
            return;
        }

        if (qty > selectedProduct.QtyInStock)
        {
            Console.WriteLine("❌ Not enough stock available.");
            return;
        }

        selectedProduct.QtyInStock -= qty;
        cart.Add(new OrderItem(selectedProduct, qty));
        Console.WriteLine("✅ Product added to cart.");
    }

    public void GenerateBill()
    {
        Console.WriteLine("\n===== BILL =====");
        double total = 0;

        foreach (var item in cart)
        {
            double price = item.GetFinalPrice();
            Console.WriteLine($"{item.Product.PName} x {item.Quantity} = ₹{price}");
            total += price;
        }

        Console.WriteLine("-----------------");
        Console.WriteLine($"Total Amount (50% Off): ₹{total}");
        Console.WriteLine("=================\n");
    }
}
