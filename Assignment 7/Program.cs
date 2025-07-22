using System;

class Program
{
    //static void Main()
    //{
    //    List<Pizza> pizzas = new List<Pizza>();

    //    pizzas.Add(new Pizza("small",1,1,0));
    //    pizzas.Add(new Pizza("medium", 2, 1, 1));
    //    pizzas.Add(new Pizza("large", 3, 2, 2));

    //    Console.WriteLine("Pizza Orders:\n");

    //    foreach (Pizza p in pizzas)
    //    {
    //        Console.WriteLine(p.GetDescription());
    //    }
    //}

    static void Main()
    {
        List<Pizza> pizzas = new List<Pizza>();
        string more = "yes";

        while (more.ToLower() == "yes") 
        {
            Console.WriteLine("Enter the Pizza Size(Small/Medium/Large)");
            string size = Console.ReadLine();

            Console.WriteLine("Enter the no.of CheeseToppings");
            int cheese = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the no.of PepperoniToppings");
            int pepperoni = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the no.of HamToppings");
            int ham = Convert.ToInt32(Console.ReadLine());

            Pizza newPizza = new Pizza(size, cheese, pepperoni, ham);
            pizzas.Add(newPizza);

            Console.WriteLine("Want to add more Pizzas (Y/N)? ");
            more = Console.ReadLine();

            Console.WriteLine("Pizza Summary");
            foreach(Pizza p in pizzas)
            {
                Console.WriteLine(p.GetDescription());
            }
        }
    }
}