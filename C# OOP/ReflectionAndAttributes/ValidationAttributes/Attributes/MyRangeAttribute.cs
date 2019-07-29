namespace ValidationAttributes.Attributes
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int objAsInt = Convert.ToInt32(obj);

            if (objAsInt < this.minValue || objAsInt > this.maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
