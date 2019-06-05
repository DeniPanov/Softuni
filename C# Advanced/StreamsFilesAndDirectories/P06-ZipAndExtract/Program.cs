namespace P06_ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class Program
    {
        public static void Main()
        {
            string zipFile = @"..\..\..\CopyMe.zip";
            string file = "copyMe.png";

            using (var archive = ZipFile.Open(zipFile,ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(file, Path.GetFileName(file));
            }
        }
    }
}
