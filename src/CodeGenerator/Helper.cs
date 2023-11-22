using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGenericDimensions.CodeGenerator
{
    internal static class Helper
    {
        internal static string GetAssemblyLocation()
        {
            return new Uri(
                Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
                ).LocalPath;
        }

        internal static string MakeFirstCharUppercase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;
            return $@"{char.ToUpperInvariant(text[0])}{text.Substring(1)}";
        }

        internal static string MakeFirstCharLowercase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;
            return $@"{char.ToLowerInvariant(text[0])}{text.Substring(1)}";
        }

        internal static string NullIfEmpty(this string text)
        {
            return string.IsNullOrWhiteSpace(text) ? null : text;
        }

        internal static IEnumerable<string[]> SplitCsvTextValues(this IEnumerable<string> lines)
        {
            return lines.Select(l => l.Split(',').Select(v => v.Trim()).ToArray());
        }

        private static IEnumerable<string[]> PullOutHeader(this IEnumerable<string[]> lines, ref string[] header)
        {
            var allLines = lines.ToArray();
            header = allLines[0];
            return allLines.Skip(1);
        }

        internal static Dictionary<string, string>[] ToArrayOfKeyedValues(this IEnumerable<string> lines)
        {
            string[] header = null;

            var dimensionRowsOfKeyedValues =
                lines
                .SplitCsvTextValues()
                .PullOutHeader(ref header)
                .Select(values => Enumerable.Range(0, header.Length).ToDictionary(i => header[i], i => values[i]))
                .ToArray();

            return dimensionRowsOfKeyedValues;
        }

        internal static bool EndsWithAny(this string value, StringComparison comparisonType, params string[] endings)
        {
            return endings.Any(e => value.EndsWith(e, comparisonType));
        }

        internal static string RemoveOccurancesOfText(this string value, params string[] parts)
        {
            foreach (var part in parts)
                value = value.Replace(part, string.Empty);

            return value;
        }

        internal static string FormatCSharpNumericConstant(string number)
        {
            if (!string.IsNullOrWhiteSpace(number))
            {
                if (!number.Contains('.'))
                {
                    var asLong = long.Parse(number);
                    if (asLong >= 0)
                    {
                        if (asLong > int.MaxValue)
                        {
                            return $"{number}L";
                        }
                    }
                }
            }
            return number;
        }
    }
}
