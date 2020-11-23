namespace RecursiveDrawing
{
    using System;

    public class RecursiveDrawing
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            DrawFigure(n);
        }

        private static void DrawFigure(int number)
        {
            if (number <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', number));

            DrawFigure(number - 1);

            Console.WriteLine(new string('#', number));
        }
    }
}
