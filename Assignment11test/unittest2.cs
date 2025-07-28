using Assignment11;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class StringTests
    {
        private StringFunctions sf;

        [SetUp]
        public void Setup()
        {
            sf = new StringFunctions();
        }

        [Test]
        public void TestCountCharacters() => Assert.AreEqual(11, sf.CountCharacters("Hello World"));

        [Test]
        public void TestIsPalindrome_True() => Assert.IsTrue(sf.IsPalindrome("Madam"));

        [Test]
        public void TestIsPalindrome_False() => Assert.IsFalse(sf.IsPalindrome("Hello"));

        [Test]
        public void TestReverseSentence() => Assert.AreEqual("dlroW olleH", sf.ReverseSentence("Hello World"));

        [Test]
        public void TestAnalyzeCharacters()
        {
            var (vowels, consonants, digits, special) = sf.AnalyzeCharacters("A1b@e");
            Assert.AreEqual(2, vowels);
            Assert.AreEqual(1, consonants);
            Assert.AreEqual(1, digits);
            Assert.AreEqual(1, special);
        }

        [Test]
        public void TestToUpperCase() => Assert.AreEqual("HELLO", sf.ToUpperCase("hello"));

        [Test]
        public void TestToProperCase() => Assert.AreEqual("Hello World", sf.ToProperCase("hello world"));

        [Test]
        public void TestCombineSentences() => Assert.AreEqual("Hello World", sf.CombineSentences("Hello", "World"));

        [Test]
        public void TestRemoveExtraSpaces() => Assert.AreEqual("Hello World", sf.RemoveExtraSpaces("  Hello   World  "));

        [Test]
        public void TestCountWords() => Assert.AreEqual(2, sf.CountWords("Hello World"));

        [Test]
        public void TestContainsSubstring_True() => Assert.IsTrue(sf.ContainsSubstring("Hello World", "World"));

        [Test]
        public void TestContainsSubstring_False() => Assert.IsFalse(sf.ContainsSubstring("Hello World", "Earth"));

        [Test]
        public void TestCountSubstringOccurrences() => Assert.AreEqual(2, sf.CountSubstringOccurrences("test this test string", "test"));
    }
}
