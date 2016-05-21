using System;

namespace BTC.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceQuoteForHtml(this string value)
        {
            return value.Replace("\"", "&quot;");
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}