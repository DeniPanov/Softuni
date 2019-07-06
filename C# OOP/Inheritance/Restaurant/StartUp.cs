namespace Restaurant
{
    public class StartUp
    {
        public static void Main()
        {
            Cake cake = new Cake("FruitCake");
            Coffee coffee = new Coffee("Kimbo",5);

            System.Console.WriteLine(coffee.Caffeine);
        }
    }
}