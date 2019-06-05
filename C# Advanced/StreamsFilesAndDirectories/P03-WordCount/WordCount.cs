namespace P03_WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            string textPath = "text.txt";
            string wordsPath = "words.txt";

            var textLines = File.ReadAllLines(textPath);
            var words = File.ReadAllLines(wordsPath);

            var wordsAndTheirCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string wordToLowercase = word.ToLower();

                if (wordsAndTheirCount.ContainsKey(wordToLowercase) == false)
                {
                    wordsAndTheirCount[wordToLowercase] = 0;
                }
            }

            foreach (var line in textLines)
            {
                var splittedLineToWords = line
                    .ToLower()
                    .Split(new char[] { ' ', '-', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var word in splittedLineToWords)
                {
                    if (wordsAndTheirCount.ContainsKey(word))
                    {
                        wordsAndTheirCount[word]++;
                    }
                }
            }

            string actualResultPath = "actualResults.txt";

            foreach (var (word, wordCount) in wordsAndTheirCount)
            {
                File.AppendAllText(actualResultPath, $"{word} - {wordCount}{Environment.NewLine}");
            }

            string expectedResultPath = "expectedResults.txt";

            foreach (var (word, wordCount) in wordsAndTheirCount.OrderByDescending(x => x.Value))
            {
                File.AppendAllText(expectedResultPath, $"{word} - {wordCount}{Environment.NewLine}");
            }
        }
    }
}
