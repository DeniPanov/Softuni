namespace P02_LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        public static void Main()
        {
            string textPath = "text.txt";

            var textLines = File.ReadAllLines(textPath);

            int counter = 1;

            string outputPath = "output-P02.txt";

            foreach (var line  in textLines)
            {
                var lettersCount = line.Count(char.IsLetter);
                var punctuationsCount = line.Count(char.IsPunctuation);

                File.AppendAllText(outputPath, $"Line {counter}: {line} ({lettersCount})({punctuationsCount})" +
                    $"{Environment.NewLine}");
                counter++;
            }
        }
    }
}
