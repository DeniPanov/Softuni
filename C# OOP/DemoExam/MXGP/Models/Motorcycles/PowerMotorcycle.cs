namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double CURRENT_CUBICCENTIMETERS = 450; 
        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, CURRENT_CUBICCENTIMETERS)
        {
        }

        public override double CubicCentimeters => CURRENT_CUBICCENTIMETERS;
    }
}
