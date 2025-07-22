namespace ProductBilling
{
    public class Product
    {
        public string PCode;
        public string PName;
        public int QtyInStock;
        public double DiscountAllowed;
        public static string Brand;

        public Product(string pcode, string pname, int qty, double discount)
        {
            PCode = pcode;
            PName = pname;
            QtyInStock = qty;
            DiscountAllowed = discount;
        }

        public void Display()
        {
            Console.WriteLine("Product Code     : " + PCode);
            Console.WriteLine("Product Name     : " + PName);
            Console.WriteLine("Quantity in Stock: " + QtyInStock);
            Console.WriteLine("Discount Allowed : " + DiscountAllowed + "%");
            Console.WriteLine("Brand            : " + Brand);
            Console.WriteLine("----------------------------------");
        }
    }
}
