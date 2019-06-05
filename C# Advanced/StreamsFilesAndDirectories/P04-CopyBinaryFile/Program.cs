namespace P04_CopyBinaryFile
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            string picPath = "copyMe.png";
            string newPicPath = "newPic.png";

            using (var reader = new FileStream(picPath, FileMode.Open))
            {
                using (var writer = new FileStream(newPicPath, FileMode.Create))
                {
                    while (true)
                    {
                        var buffer = new byte[4096];
                        int size = reader.Read(buffer, 0, buffer.Length);

                        if (size == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, size);
                    }
                }
            }
        }
    }
}
