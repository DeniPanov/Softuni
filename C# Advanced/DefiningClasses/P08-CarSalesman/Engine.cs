namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model, int power, int? displacement, string efficiency)
            : this(model,power,displacement)
        {
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int? displacement)
            : this(model,power)
        {
            Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            Efficiency = efficiency;
        }

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public Engine()
        {
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int? Displacement { get; set; }

        public string Efficiency { get; set; } = "n/a";
    }
}
