namespace LINQFundamentals
{
    public static class StringExtensions
    {
        public static double ToDouble(this string value)
        {
            return double.Parse(value);
        }

        public static bool IsValidPostalCode(this string value)
        {
            return (value.Length == 5 || value.Length == 9);
        }
    }
}
