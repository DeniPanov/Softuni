namespace P05_DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        public static void Main()
        {
            var dirInfo = new DirectoryInfo(".");
            var fileInfo = new Dictionary<string, Dictionary<string, double>>();
            var allFiles = dirInfo.GetFiles();

            foreach (var file in allFiles)
            {
                double size = file.Length / 1024d;
                string fileName = file.Name;
                string extension = file.Extension;

                if (fileInfo.ContainsKey(extension) == false)
                {
                    fileInfo.Add(extension, new Dictionary<string, double>());
                }

                if (fileInfo[extension].ContainsKey(fileName) == false)
                {
                    fileInfo[extension].Add(fileName, size);
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";

            foreach (var (extension, value) in fileInfo.OrderByDescending(x =>x.Value.Count()).ThenBy(x => x.Key))
            {
                File.AppendAllText(path, $"{extension} {Environment.NewLine}");

                foreach (var (fileName, size) in value.OrderBy(x => x.Value))
                {
                    File.AppendAllText(path, $"--{fileName} - {Math.Round(size,3)}{Environment.NewLine}kb");
                }
            }
        }
    }
}
