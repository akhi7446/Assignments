namespace assignment2
{
    internal class Program
    {
        static void Main()
        {
            //Console.Write("Enter the marks of Math: ");
            //int math = Convert.ToInt32 (Console.ReadLine());

            //Console.Write("Enter the marks of Phy: ");
            //int Phy = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Enter the marks of Chem: ");
            //int Chem = Convert.ToInt32(Console.ReadLine());

            //int total = math + Phy + chem;
            //int MP = math + Phy;

            //if(Math >= 65 && Phy >= 55 &&  Chem >=50 && total >= 180) || (MP >= 140)
            //        {
            //    Console.WriteLine("Eligible");
            //}
            //else
            //{
            //    Console.WriteLine(" Not Eligible");
            //}


            {
                Console.Write("Customer IDNO: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Customer Name: ");
                string name = Console.ReadLine();

                Console.Write("unit consumed by the customer: ");
                int units = Convert.ToInt32(Console.ReadLine());

                double chargePerUnit;
                double amount, surcharge = 0, netAmount;

                if (units < 200)
                    chargePerUnit = 1.20;
                else if (units < 400)
                    chargePerUnit = 1.50;
                else if (units < 600)
                    chargePerUnit = 1.80;
                else
                    chargePerUnit = 2.00;

                amount = units * chargePerUnit;


                if (amount > 400)
                {
                    surcharge = amount * 0.15;
                }

                netAmount = amount + surcharge;

                // Apply minimum bill
                if (netAmount < 100)
                {
                    netAmount = 100;
                }

                Console.WriteLine("Customer IDNO : " + id);
                Console.WriteLine("Customer Name : " + name);
                Console.WriteLine("Unit Consumed : " + units);
                Console.WriteLine($"Amount Charges @Rs. {chargePerUnit} per unit : {amount}");
                Console.WriteLine($"Surchage Amount : {surcharge}");
                Console.WriteLine($"Net Amount Paid By the Customer : {netAmount}");
            }
        }

    }
}
