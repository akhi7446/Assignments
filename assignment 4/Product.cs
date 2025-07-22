public class Product
{
    public string PCode { get; }
    public string PName { get; }
    public int QtyInStock { get; set; }
    public double DiscountAllowed { get; }
    public static string Brand = "SmartTech";

    public Product(string code, string name, int stock, double discount)
    {
        PCode = code;
        PName = name.ToLower();
        QtyInStock = stock;
        DiscountAllowed = discount;
    }

    public void Display()
    {
        Console.WriteLine($"Code     : {PCode}");
        Console.WriteLine($"Name     : {PName}");
        Console.WriteLine($"Stock    : {QtyInStock}");
        Console.WriteLine($"Discount : {DiscountAllowed}%");
        Console.WriteLine($"Brand    : {Brand}");
    }
}
