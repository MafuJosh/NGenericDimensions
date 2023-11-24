#if !NET
using System;

namespace NGenericDimensions
{
    internal static class Polyfill
    {
        internal static bool Contains(this string source, string value, StringComparison comparisonType) => source.IndexOf(value, comparisonType) >= 0;

        internal static string Replace(this string source, string oldValue, string? newValue, StringComparison comparisonType)
        {
            if (comparisonType == StringComparison.Ordinal)
            {
                return source.Replace(oldValue, newValue);
            }

            // not implemented since nothing seems to need this yet
            throw new NotImplementedException();
        }
    }
}
#endif
