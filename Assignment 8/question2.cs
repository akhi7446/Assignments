using System;
using System.Text;


        /*
         Question 2 : 

        Write a function:

        class Solution { public string solution(int N1, int N2, int Start,  int End); }

        that, given four integers, returns the table of the Numbers N1 upto N2 and that too From Start to End. In case any parameter is negative or 0, shall return 0

        For example, given A = [2, 4, 2,6], the function should return 
        2 * 2 = 2 
        2 * 3 = 6
        2 * 4 = 8
        2 * 5 = 10
        2 * 6 = 12
        3 * 2 = 6
        3 * 3 = 9
        3 * 4 = 12
        3 * 5 = 15
        3 * 6 = 18
        4 * 2 = 8
        4 * 3 = 12
        4 * 4 = 16
        4 * 5 = 20
        4 * 6 = 24
        .

        Given A = [1, 2, 1,2], the function should return 
        1 *1 = 1
        1 *2 = 2
        2 * 1 = 2
        2 * 2 = 4

        Given A = [−1, 3 ,  1, 2], the function should return 0.

        Write an efficient algorithm for the following assumptions:

        N1, N2, Start , End is an integer within the range [1..100,000];

        using System;
        // you can also use other imports, for example:
        // using System.Collections.Generic;

        // you can write to stdout for debugging purposes, e.g.
        // Console.WriteLine("this is a debug message");

        class Solution {
            public int solution(int N1, int N2, int Start, int End) {
                // Implement your solution here
            }
        }


         */

class Solution
{
    public string solution(int N1,int N2, int start,int end)
    {
        if (N1<=0 || N2<=0 || start <= 0 || end <=0)
        {
            return "0";
        }
        StringBuilder result = new StringBuilder();
        for (int i = N1; i <= N2; i++)
        {
            for (int j = start; j <= end; j++)
            {
                result.AppendLine($"{i} * {j} = {i*j}");
            }
        }
        return result.ToString();
    }
}
class question2
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter Starting Number : ");
            int N1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Ending Number : ");
            int N2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Starting Multiplier : ");
            int start = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Ending Multiplier : ");
            int end = int.Parse(Console.ReadLine());

            Solution sol = new Solution();
            string result = sol.solution(N1, N2, start, end);

            Console.WriteLine("\n Multiplication Table : ");

            Console.WriteLine(result);
        }
        catch
        {
            Console.WriteLine("Invalid Input");
        }
    }
}