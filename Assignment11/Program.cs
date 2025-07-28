using Assignment11;

class Program
{
    static void Main()
    {
        var numeric = new NumericFunctions();
        var strFuncs = new StringFunctions();


        // 1. Add
        Console.WriteLine("Enter numbers to add  by using , :");
        var addNumbers = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
        Console.WriteLine("Sum: " + numeric.Add(addNumbers));

        // 2. Subtract
        Console.WriteLine("Enter first number to subtract :");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Second number to subtract :");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Subtraction: " + numeric.Subtract(a, b));

        // 3. Multiply
        Console.WriteLine("Enter first number to multiply:");
        int m1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number to multiply:");
        int m2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Multiplication: " + numeric.Multiply(m1, m2));

        // 4. Divide
        Console.WriteLine("Enter first number to divide :");
        float d1 = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number to divide :");
        float d2 = float.Parse(Console.ReadLine());
        Console.WriteLine("Division: " + numeric.Divide(d1, d2));

        // 5. Max
        Console.WriteLine("Enter numbers to find Max :");
        var maxNums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
        Console.WriteLine("Max: " + numeric.FindMax(maxNums));

        // 6. Min
        Console.WriteLine("Enter numbers to find Min :");
        var minNums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
        Console.WriteLine("Min: " + numeric.FindMin(minNums));

        // 7. Even Check
        Console.WriteLine("Enter a number to check if Even:");
        int evenCheck = int.Parse(Console.ReadLine());
        Console.WriteLine("Is Even: " + numeric.IsEven(evenCheck));

        // 8. Odd Check
        Console.WriteLine("Enter a number to check if Odd:");
        int oddCheck = int.Parse(Console.ReadLine());
        Console.WriteLine("Is Odd: " + numeric.IsOdd(oddCheck));

        // 9. Prime Check
        Console.WriteLine("Enter a number to check if Prime:");
        int primeCheck = int.Parse(Console.ReadLine());
        Console.WriteLine("Is Prime: " + numeric.IsPrime(primeCheck));

        // 10. All Even in Range
        Console.WriteLine("Enter start and end for even numbers:");
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        Console.WriteLine("Even numbers: " + string.Join(", ", numeric.GetEvenNumbersInRange(start, end)));

        // 11. All Odd in Range
        Console.WriteLine("Odd numbers: " + string.Join(", ", numeric.GetOddNumbersInRange(start, end)));

        // 12. All Primes in Range
        Console.WriteLine("Prime numbers: " + string.Join(", ", numeric.GetPrimeNumbersInRange(start, end)));

        // 13. Table of a Number
        Console.WriteLine("Enter number for multiplication table:");
        int table = int.Parse(Console.ReadLine());
        numeric.GetTable(table).ForEach(Console.WriteLine);

        // 14. Tables 1–10 in range
        Console.WriteLine("Enter range (start, end) for tables 1-10:");
        int t1 = int.Parse(Console.ReadLine());
        int t2 = int.Parse(Console.ReadLine());
        numeric.GetTablesFrom1To10(t1, t2).ForEach(Console.WriteLine);

        // 15. Tables with custom range
        Console.WriteLine("Enter number range start and end:");
        int numStart = int.Parse(Console.ReadLine());
        int numEnd = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter multiplication range start and end :");
        int rangeStart = int.Parse(Console.ReadLine());
        int rangeEnd = int.Parse(Console.ReadLine());
        numeric.GetTablesFromRange(numStart, numEnd, rangeStart, rangeEnd).ForEach(Console.WriteLine);

        // 16. Reverse number
        Console.WriteLine("Enter number to reverse:");
        int revNum = int.Parse(Console.ReadLine());
        Console.WriteLine("Reversed: " + numeric.ReverseNumber(revNum));



        // 1. Count characters
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();
        Console.WriteLine("Character count: " + strFuncs.CountCharacters(sentence));

        // 2. Palindrome
        Console.WriteLine("Is Palindrome: " + strFuncs.IsPalindrome(sentence));

        // 3. Reverse sentence
        Console.WriteLine("Reversed: " + strFuncs.ReverseSentence(sentence));

        // 4. Count vowels, consonants, digits, special characters
        var result = strFuncs.AnalyzeCharacters(sentence);
        Console.WriteLine($"Vowels: {result.vowels}, Consonants: {result.consonants}, Digits: {result.digits}, Special: {result.specialChars}");

        // 5. Upper case
        Console.WriteLine("Uppercase: " + strFuncs.ToUpperCase(sentence));

        // 6. Proper case
        Console.WriteLine("Proper case: " + strFuncs.ToProperCase(sentence));

        // 7. Combine sentences
        Console.WriteLine("Enter another sentence:");
        string secondSentence = Console.ReadLine();
        Console.WriteLine("Combined: " + strFuncs.CombineSentences(sentence, secondSentence));

        // 8. Remove extra spaces
        Console.WriteLine("Without extra spaces: " + strFuncs.RemoveExtraSpaces(sentence));

        // 9. Word count
        Console.WriteLine("Word count: " + strFuncs.CountWords(sentence));

        // 10. Search substring
        Console.WriteLine("Enter substring to search:");
        string sub = Console.ReadLine();
        Console.WriteLine("Found: " + strFuncs.ContainsSubstring(sentence, sub));

        // 11. Count substring occurrences
        Console.WriteLine("Occurrences: " + strFuncs.CountSubstringOccurrences(sentence, sub));
    }
}
