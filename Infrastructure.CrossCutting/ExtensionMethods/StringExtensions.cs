namespace Infrastructure.CrossCutting.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string FormatString(this string str)
        {
            return str.Replace(".", "").Replace("-", "").Replace(",", "").Trim();
        }
    }
}
