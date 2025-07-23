using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

class AdmissionEligibility
{

    /*
    1. WAP to find the eligibility of admission for a professional course based on the following criteria:
    Marks in Maths >=65
    Marks in Phy >=55
    Marks in Chem>=50
    Total in all three subject >=180
    or
    Total in Math and Phy>=140

    Test Data :
    Input the marks obtained in Physics :65
    Input the marks obtained in Chemistry :51
    Input the marks obtained in Mathematics :72
    Expected Output :
    The candidate is eligible for admission. */

    static void Main()
    {
        Console.Write("Input the marks obtained in Physics: ");
        int phy = int.Parse(Console.ReadLine());

        Console.Write("Input the marks obtained in Chemistry: ");
        int chem = int.Parse(Console.ReadLine());

        Console.Write("Input the marks obtained in Mathematics: ");
        int math = int.Parse(Console.ReadLine());

        int total = math + phy + chem;
        int mathPhyTotal = math + phy;

        if ((math >= 65 && phy >= 55 && chem >= 50 && total >= 180) || (mathPhyTotal >= 140))
        {
            Console.WriteLine("The candidate is eligible for admission.");
        }
        else
        {
            Console.WriteLine("The candidate is not eligible for admission.");
        }
    }
    /*
    2. Write a program in C# Sharp to calculate and print the Electricity bill of a given customer. The customer id., name and unit consumed by the user should be taken from the keyboard and display the total amount to pay to the customer. The charge are as follow : 

        Unit                                   Charge/unit
        upto 199	                        @1.20
        200 and above but less than 400	        @1.50
        400 and above but less than 600	        @1.80
        600 and above	                        @2.00

        If bill exceeds Rs. 400 then a surcharge of 15% will be charged and the minimum bill should be of Rs. 100/-

        Test Data :
        1001
        James
        800
        Expected Output :
        Customer IDNO :1001
        Customer Name :James
        unit Consumed :800
        Amount Charges @Rs. 2.00 per unit : 1600.00
        Surchage Amount : 240.00
        Net Amount Paid By the Customer : 1840.00*/


    class ElectricityBill
    {
        static void Main()
        {
            Console.Write("Input Customer ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Input Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Input unit consumed: ");
            int units = int.Parse(Console.ReadLine());

            double rate;
            if (units < 200)
                rate = 1.20;
            else if (units < 400)
                rate = 1.50;
            else if (units < 600)
                rate = 1.80;
            else
                rate = 2.00;

            double amount = units * rate;
            double surcharge = 0;

            if (amount > 400)
                surcharge = amount * 0.15;

            double netAmount = amount + surcharge;

            if (netAmount < 100)
                netAmount = 100;

        
            Console.WriteLine("Customer IDNO      : " + id);
            Console.WriteLine("Customer Name      : " + name);
            Console.WriteLine("Unit Consumed      : " + units);
            Console.WriteLine("Amount Charges @Rs. {0} per unit : {1:F2}", rate, amount);
            Console.WriteLine("Surchage Amount    : {0:F2}", surcharge);
            Console.WriteLine("Net Amount Paid By the Customer : {0:F2}", netAmount);
        }
    }

}
