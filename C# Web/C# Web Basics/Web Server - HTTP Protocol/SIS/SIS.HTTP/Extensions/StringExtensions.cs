namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string text)
        {
            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }
    }
}
