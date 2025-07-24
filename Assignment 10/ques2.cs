
using System;
using System.Linq;

public static class StringExtensions
{
    public static int CharacterCount(this string str) => (str ?? "***").Length;

    public static bool IsPalindrome(this string str)
    {
        str = str?.Replace(" ", "").ToLower() ?? "***";
        return str == new string(str.Reverse().ToArray());
    }

    public static string ReverseSentence(this string str)
        => new string((str ?? "***").Reverse().ToArray());

    public static void CountDetails(this string str, out int vowels, out int consonants, out int digits, out int specials)
    {
        vowels = consonants = digits = specials = 0;
        str = str ?? "***";
        foreach (char c in str.ToLower())
        {
            if ("aeiou".Contains(c)) vowels++;
            else if (char.IsLetter(c)) consonants++;
            else if (char.IsDigit(c)) digits++;
            else if (!char.IsWhiteSpace(c)) specials++;
        }
    }

    public static string ToProperCase(this string str)
    {
        return string.Join(" ", (str ?? "***").Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(w => char.ToUpper(w[0]) + w.Substring(1).ToLower()));
    }

    public static string CombineWith(this string str1, string str2)
        => (str1 ?? "***") + " " + (str2 ?? "***");

    public static string RemoveExtraSpaces(this string str)
        => string.Join(" ", (str ?? "***").Split(' ', StringSplitOptions.RemoveEmptyEntries));

    public static int WordCount(this string str)
        => (str ?? "***").Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

    public static bool ContainsSubstring(this string str, string substr)
        => (str ?? "***").Contains(substr ?? "***");

    public static int SubstringOccurrences(this string str, string substr)
    {
        if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(substr)) return 0;
        int count = 0, index = 0;
        while ((index = str.IndexOf(substr, index)) != -1)
        {
            count++;
            index += substr.Length;
        }
        return count;
    }
}

class ques2
{
    static void Main()
    {
        try
        {
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();

            Console.WriteLine($"Character Count: {sentence.CharacterCount()}");
            Console.WriteLine($"Is Palindrome: {sentence.IsPalindrome()}");
            Console.WriteLine($"Reversed Sentence: {sentence.ReverseSentence()}");

            sentence.CountDetails(out int vowels, out int consonants, out int digits, out int specials);
            Console.WriteLine($"Vowels: {vowels}, Consonants: {consonants}, Digits: {digits}, Specials: {specials}");

            Console.WriteLine($"Upper Case: {sentence.ToUpper()}");
            Console.WriteLine($"Proper Case: {sentence.ToProperCase()}");

            Console.Write("Enter another sentence to combine: ");
            string sentence2 = Console.ReadLine();
            Console.WriteLine($"Combined: {sentence.CombineWith(sentence2)}");

            Console.WriteLine($"Removed Extra Spaces: {sentence.RemoveExtraSpaces()}");
            Console.WriteLine($"Word Count: {sentence.WordCount()}");

            Console.Write("Enter a substring to search: ");
            string substr = Console.ReadLine();
            Console.WriteLine($"Contains '{substr}': {sentence.ContainsSubstring(substr)}");
            Console.WriteLine($"Occurrences of '{substr}': {sentence.SubstringOccurrences(substr)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
