public class OrderItem
{
    public Product Product { get; }
    public int Quantity { get; }

    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public double GetFinalPrice()
    {
        double unitPrice = 100; // Fixed for all products
        double total = unitPrice * Quantity;
        double discount = 0.50 * total; // 50% for 26th Jan
        return total - discount;
    }
}
