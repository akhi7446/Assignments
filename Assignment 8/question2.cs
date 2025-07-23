using System;
using System.Text;

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