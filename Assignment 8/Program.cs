using System;

/*
 Question 1 : 

Write a function:

class Solution { public int solution(int[] A); }

that, given an array A of N integers, returns the sum sqaure of smallest positive integer (greater than 0) that occurs in A.

For example, given A = [5, 3, -6, -4, 10, 2], the function should return 4.

Given A = [1, 2, 3], the function should return 1.

Given A = [−1, −3], the function should return 0.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..100,000];
each element of array A is an integer within the range [−1,000,000..1,000,000].


using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        // Implement your solution here
    }
}


 */
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
