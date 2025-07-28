namespace Assignment11;

public class StringFunctions
{
    public int CountCharacters(string sentence) => sentence.Length;

    public bool IsPalindrome(string sentence)
    {
        var cleaned = new string(sentence.Where(char.IsLetterOrDigit).ToArray()).ToLower();
        return cleaned.SequenceEqual(cleaned.Reverse());
    }

    public string ReverseSentence(string sentence) => new string(sentence.Reverse().ToArray());

    public (int vowels, int consonants, int digits, int specialChars) AnalyzeCharacters(string sentence)
    {
        int vowels = 0, consonants = 0, digits = 0, special = 0;
        foreach (char c in sentence.ToLower())
        {
            if ("aeiou".Contains(c)) vowels++;
            else if (char.IsLetter(c)) consonants++;
            else if (char.IsDigit(c)) digits++;
            else if (!char.IsWhiteSpace(c)) special++;
        }
        return (vowels, consonants, digits, special);
    }

    public string ToUpperCase(string sentence) => sentence.ToUpper();

    public string ToProperCase(string sentence)
    {
        var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return string.Join(" ", words.Select(w => char.ToUpper(w[0]) + w.Substring(1).ToLower()));
    }

    public string CombineSentences(string s1, string s2) => s1 + " " + s2;

    public string RemoveExtraSpaces(string sentence)
    {
        return string.Join(" ", sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

    public int CountWords(string sentence)
    {
        return sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public bool ContainsSubstring(string sentence, string substring)
    {
        return sentence.Contains(substring);
    }

    public int CountSubstringOccurrences(string sentence, string substring)
    {
        int count = 0, index = 0;
        while ((index = sentence.IndexOf(substring, index)) != -1)
        {
            count++;
            index += substring.Length;
        }
        return count;
    }
}
