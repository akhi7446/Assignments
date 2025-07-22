namespace ProductBilling
{
    public class Shop
    {
        private Dictionary<string, Product> products = new Dictionary<string, Product>();
        private List<OrderItem> cart = new List<OrderItem>();

        public void AdminMenu()
        {
            Console.WriteLine("\n--- Admin Menu ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Display Products");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
                AddProduct();
            else if (choice == "2")
                DisplayProducts();
            else
                Console.WriteLine("Invalid option.");
        }

        public void AddProduct()
        {
            Console.Write("Enter Product Code: ");
            string code = Console.ReadLine();

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine().ToLower();

            Console.Write("Enter Quantity in Stock: ");
            int qty = int.Parse(Console.ReadLine());

            Console.Write("Enter Discount Allowed (%): ");
            double discount = double.Parse(Console.ReadLine());

            Product newProduct = new Product(code, name, qty, discount);
            products[name] = newProduct;

            Console.WriteLine("Product added successfully!");
        }

        public void DisplayProducts()
        {
            Console.WriteLine("\n--- Product List ---");

            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (var item in products.Values)
                item.Display();
        }

        public void CustomerMenu()
        {
            cart.Clear();

            while (true)
            {
                Console.WriteLine("\n--- Customer Menu ---");
                Console.WriteLine("1. Order Product");
                Console.WriteLine("2. Get Bill");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                    OrderProduct();
                else if (choice == "2")
                {
                    GenerateBill();
                    break;
                }
                else if (choice == "3")
                    break;
                else
                    Console.WriteLine("Invalid option.");
            }
        }

        public void OrderProduct()
        {
            Console.Write("Enter Product Name to Purchase: ");
            string pname = Console.ReadLine().ToLower();

            if (!products.ContainsKey(pname))
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Product prod = products[pname];
            prod.Display();

            Console.Write("Enter quantity to purchase: ");
            int qty = int.Parse(Console.ReadLine());

            if (qty > prod.QtyInStock)
            {
                Console.WriteLine("Not enough stock available.");
                return;
            }

            cart.Add(new OrderItem(prod, qty));
            prod.QtyInStock -= qty;

            Console.WriteLine("Product added to cart.");
        }

        public void GenerateBill()
        {
            Console.WriteLine("\n--- FINAL BILL (26 Jan Offer Applied) ---");

            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            double total = 0;

            foreach (var item in cart)
            {
                double price = item.GetFinalPrice();
                Console.WriteLine($"{item.Product.PName} x {item.Quantity} = ₹{price}");
                total += price;
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Total Amount to Pay: ₹" + total);
            Console.WriteLine("Thank you for shopping! 🎉 Happy Republic Day!");
        }
    }
}
