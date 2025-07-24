using System;
using System.Collections.Generic;
using System.Linq;


/*
 
1. Create a class Operations which should have methods 
Sum() which can take any number of parameters, 
Subtract, Product, 
Min() which can take any number of parameters, 
Max() which can take any number of parameters, 
Check a no. for even  bool
Check a no. for odd
Check a no. for prime

We need to call all these methods with class name

After this, functions are the extension methods
 Display all even no.s with in a given range
 Display all odd no.s with in a given range
 Display all prime no.s with in a given range
 Display table of an entered no.
 Display tables from 1 to 10 of all no.s with in a given range
 Display tables from a given range of all no.s with in a given range
 Reverse a no.

 */
static class Operations
{
    public static int Sum(params int?[] numbers)
    {
        int sum = 0;
        foreach (var num in numbers)
        {
            sum += num ?? 10;
        }
        return sum;
    }

    public static int Subtract(int a, int b) => a - b;

    public static int Product(int a, int b) => a * b;

    public static int Min(params int?[] numbers)
    {
        return (from n in numbers select n ?? 10).Min();
    }

    public static int Max(params int?[] numbers)
    {
        return (from n in numbers select n ?? 10).Max();
    }

    public static bool IsEven(int num) => num % 2 == 0;

    public static bool IsOdd(int num) => num % 2 != 0;

    public static bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}

static class ExtensionMethods
{
    public static void DisplayEven(this int end)
    {
        Console.WriteLine("Even numbers:");
        for (int i = 1; i <= end; i++)
        {
            if (i % 2 == 0) Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    public static void DisplayOdd(this int end)
    {
        Console.WriteLine("Odd numbers:");
        for (int i = 1; i <= end; i++)
        {
            if (i % 2 != 0) Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    public static void DisplayPrime(this int end)
    {
        Console.WriteLine("Prime numbers:");
        for (int i = 2; i <= end; i++)
        {
            if (Operations.IsPrime(i)) Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    public static void DisplayTable(this int num)
    {
        Console.WriteLine($"Table of {num}:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{num} * {i} = {num * i}");
        }
    }

    public static void DisplayTables(this int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            i.DisplayTable();
            Console.WriteLine();
        }
    }

    public static int Reverse(this int num)
    {
        int rev = 0;
        while (num > 0)
        {
            rev = rev * 10 + num % 10;
            num /= 10;
        }
        return rev;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter how many numbers you want to sum: ");
            int count = int.Parse(Console.ReadLine());
            int?[] numbers = new int?[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter number {i + 1} : ");
                string input = Console.ReadLine();
                numbers[i] = string.IsNullOrWhiteSpace(input) ? null : int.Parse(input);
            }

            Console.WriteLine($"Sum = {Operations.Sum(numbers)}");
            Console.WriteLine($"Min = {Operations.Min(numbers)}");
            Console.WriteLine($"Max = {Operations.Max(numbers)}");

            Console.Write("Enter number for even/odd/prime check: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"Is Even: {Operations.IsEven(num)}");
            Console.WriteLine($"Is Odd: {Operations.IsOdd(num)}");
            Console.WriteLine($"Is Prime: {Operations.IsPrime(num)}");

            Console.Write("Enter range to show even numbers : ");
            int range1 = int.Parse(Console.ReadLine());
            range1.DisplayEven();

            Console.Write("Enter range to show odd numbers: ");
            int range2 = int.Parse(Console.ReadLine());
            range2.DisplayOdd();

            Console.Write("Enter range to show prime numbers: ");
            int range3 = int.Parse(Console.ReadLine());
            range3.DisplayPrime();

            Console.Write("Enter a number to reverse: ");
            int revNum = int.Parse(Console.ReadLine());
            Console.WriteLine($"Reversed number = {revNum.Reverse()}");

            Console.Write("Enter a number to display its table: ");
            int tableNum = int.Parse(Console.ReadLine());
            tableNum.DisplayTable();

            Console.Write("Enter start number for tables: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Enter end number for tables: ");
            int end = int.Parse(Console.ReadLine());
            start.DisplayTables(end);
        }
        catch (Exception ex)
        {
            Console.WriteLine("{ex.Message}");
        }
    }
}
