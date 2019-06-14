namespace DefiningClasses
{
    public class Car
    {
        public Car()
        {
        }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, double? weight)
            : this(model,engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, double? weight, string color)
            :this(model, engine, weight)
        {
              Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public double? Weight { get; set; }
        public string Color { get; set; } = "n/a";
    }
}
