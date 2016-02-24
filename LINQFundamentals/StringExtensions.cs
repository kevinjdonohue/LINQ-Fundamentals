namespace LINQFundamentals
{
    public static class StringExtensions
    {
        public static double ToDouble(this string data)
        {
            return double.Parse(data);
        }
    }
}
