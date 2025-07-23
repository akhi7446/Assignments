using System;


    /*
     Question 3 : 

    Write a function:

    class Solution { public int solution(int[] A); }

    that, given an array A of N integers, returns the sum of positive integers, if the array contains 0 , shall stop doing summation, skip all negative integers that occurs in A.

    For example, given A = [5, 3, -6, -4, 10, 2], the function should return 20.

    Given A = [1, 2, 3], the function should return 6.

    Given A = [−1, −3], the function should return 0.

    Given A = [1, 2, 0 ,−3, 8], the function should return 3

    Given A = [1, 2, 3 ,−3, 8], the function should return 14

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
