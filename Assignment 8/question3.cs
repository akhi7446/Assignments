using System;

class Solution2
{
    public int CalculateSumBeforeZero(int[] A)
    {
        int sum = 0;
        foreach (int num in A)
        {
            if (num == 0)
                break;

            if (num > 0)
                sum += num;
        }
        return sum;
    }
}

class Program1
{
    static void Main()
    {
        Console.WriteLine("Enter the number of elements in the array:");
        int n = int.Parse(Console.ReadLine());

        int[] A = new int[n];

        Console.WriteLine($"Enter {n} integers:");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Element {i + 1}: ");
            A[i] = int.Parse(Console.ReadLine());
        }

        Solution2 sol = new Solution2();
        int result = sol.CalculateSumBeforeZero(A);

        Console.WriteLine("\nSum of positive integers before zero: " + result);
    }
}
