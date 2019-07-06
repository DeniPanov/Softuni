namespace Restaurant
{
    public class Fish : MainDish
    {
        public const double FishGrams = 22;
        public Fish(string name, decimal price)
            : base(name, price, FishGrams)
        {
        }
    }
}
