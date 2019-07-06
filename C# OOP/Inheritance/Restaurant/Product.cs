namespace Restaurant
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public virtual decimal Price { get; set; }
    }
}
