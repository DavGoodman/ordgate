using System.Text;

namespace GET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = GetWords();
            var wordCount = 10;
            while (wordCount > 0)
            {
                var matchFound = FindWordPuzzle(words);
                if (matchFound) wordCount--;
            }
        }

        private static bool FindWordPuzzle(string[] words)
        {
            var randomWordIndex = new Random().Next(words.Length);
            var selectedWord = words[randomWordIndex];
            Console.Write(selectedWord + " - ");

            foreach (string word in words)
            {
                if (isLastPartOFWordEqualToFirstPartOfSecond(selectedWord, word))
                {
                    Console.WriteLine(word);
                    return true;
                }
            }
            Console.WriteLine("Fant ikke match");
            return false;
        }

        private static bool isLastPartOFWordEqualToFirstPartOfSecond(string word1, string word2)
        {
            return isLastPartOFWordEqualToFirstPartOfSecond(4, word1, word2)
                || isLastPartOFWordEqualToFirstPartOfSecond(5, word1, word2)
                || isLastPartOFWordEqualToFirstPartOfSecond(6, word1, word2);
        }
        
        private static bool isLastPartOFWordEqualToFirstPartOfSecond(int commonlength, string word1, string word2)
        {
            var lastPartOfFirstWord = word1.Substring(word1.Length - commonlength, commonlength);

            var lastPartOfSecondWord = word2.Substring(0, commonlength);
            return lastPartOfFirstWord == lastPartOfSecondWord;
        }


        static string[] GetWords()
        {
            var lastWord = "";
            var wordList = new List<string>();
            foreach (var line in File.ReadLines("ordliste.txt", Encoding.UTF8))
            {
                var parts = line.Split('\t');
                var word = parts[1];
                if (word != lastWord && word.Length > 7 && !word.Contains("-") && !word.Contains(" "))
                {
                    wordList.Add(word);
                    // yield return word
                }
                lastWord = word;
            }
            return wordList.ToArray();
        }
    }
}