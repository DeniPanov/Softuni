using System.Linq;
using System.Reflection;

using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj
                .GetType()
                .GetProperties();

            foreach (var property in propertyInfos)
            {
                MyValidationAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in attributes)
                {
                    if (attribute.IsValid(property.GetValue(obj)) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
