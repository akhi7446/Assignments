namespace Assignment11;

public class NumericFunctions
{
    public int Add(params int[] numbers) => numbers.Sum();
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;
    public float Divide(float a, float b) => b != 0 ? a / b : float.NaN;
    public int FindMax(params int[] numbers) => numbers.Max();
    public int FindMin(params int[] numbers) => numbers.Min();
    public bool IsEven(int number) => number % 2 == 0;
    public bool IsOdd(int number) => number % 2 != 0;
    public bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
            if (number % i == 0) return false;
        return true;
    }
    public List<int> GetEvenNumbersInRange(int start, int end) => Enumerable.Range(start, end - start + 1).Where(IsEven).ToList();
    public List<int> GetOddNumbersInRange(int start, int end) => Enumerable.Range(start, end - start + 1).Where(IsOdd).ToList();
    public List<int> GetPrimeNumbersInRange(int start, int end) => Enumerable.Range(start, end - start + 1).Where(IsPrime).ToList();
    public List<string> GetTable(int number)
    {
        var list = new List<string>();
        for (int i = 1; i <= 10; i++)
            list.Add($"{number} x {i} = {number * i}");
        return list;
    }
    public List<string> GetTablesFrom1To10(int start, int end)
    {
        var result = new List<string>();
        for (int n = start; n <= end; n++)
            result.AddRange(GetTable(n));
        return result;
    }
    public List<string> GetTablesFromRange(int numStart, int numEnd, int rangeStart, int rangeEnd)
    {
        var result = new List<string>();
        for (int n = numStart; n <= numEnd; n++)
            for (int i = rangeStart; i <= rangeEnd; i++)
                result.Add($"{n} x {i} = {n * i}");
        return result;
    }
    public int ReverseNumber(int number)
    {
        int rev = 0;
        while (number != 0)
        {
            rev = rev * 10 + number % 10;
            number /= 10;
        }
        return rev;
    }
}
