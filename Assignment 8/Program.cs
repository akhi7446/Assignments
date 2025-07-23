using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of elements in the array:");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];

        Console.WriteLine($"Enter {n} integers :");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Element {i + 1}: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        // Call function to calculate the result
        int result = FindSmallestPositiveSquare(numbers);

        Console.WriteLine("Result: " + result);
    }

    static int FindSmallestPositiveSquare(int[] A)
    {
        int smallestPositive = int.MaxValue;
        bool found = false;

        foreach (int num in A)
        {
            if (num > 0 && num < smallestPositive)
            {
                smallestPositive = num;
                found = true;
            }
        }

        if (found)
        {
            return smallestPositive * smallestPositive;
        }
        else
        {
            return 0;
        }
    }
}
