namespace ProductBilling
{
    public class OrderItem
    {
        public Product Product;
        public int Quantity;

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public double GetFinalPrice()
        {
            double pricePerUnit = 100; // fixed price
            double total = Quantity * pricePerUnit;
            double discount = 0.5 * total; // 50% off for 26 Jan
            return total - discount;
        }
    }
}
