namespace P01_EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        public static void Main()
        {
            using (var reader = new StreamReader("./text.txt"))
            {
                var copyOfLine = new StringBuilder();
                var line = reader.ReadLine();

                copyOfLine.Append(line);

                int counter = 0;

                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        for (int i = 0; i < copyOfLine.Length; i++)
                        {
                            if (copyOfLine[i] == '-')
                            {
                                copyOfLine.Replace('-', '@');
                            }
                            else if (copyOfLine[i] == ',')
                            {
                                copyOfLine.Replace(',', '@');
                            }
                            else if (copyOfLine[i] == '.')
                            {
                                copyOfLine.Replace('.', '@');
                            }
                            else if (copyOfLine[i] == '!')
                            {
                                copyOfLine.Replace('!', '@');
                            }
                            else if (copyOfLine[i] == '?')
                            {
                                copyOfLine.Replace('?', '@');
                            }
                        }

                        line = copyOfLine.ToString();

                        var inputAsList = line
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray()
                                .Reverse()
                                .ToList();

                        Console.WriteLine(string.Join(" ", inputAsList));

                        inputAsList.Clear();
                    }

                    line = reader.ReadLine();
                    copyOfLine.Clear();
                    copyOfLine.Append(line);
                    counter++;
                }
            }
        }
    }
}
