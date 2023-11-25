#if !NET
using System;
using System.Reflection;

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

#if NET46
        internal static bool IsAssignableFrom(this Type source, Type c) => source.GetTypeInfo().IsAssignableFrom(c.GetTypeInfo());
#endif
    }

#if NET46
    internal class HashCode
    {
        internal static int Combine<T1>(T1 value1) => value1?.GetHashCode() ?? 0;
    }
#endif
}
#endif
