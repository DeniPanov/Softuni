namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public const double CoffeeMilliliters = 50;
        public const decimal CoffeePrice = 3.50m;

        public Coffee(string name, double caffeine)
            : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
