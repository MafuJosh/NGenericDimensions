using NGenericDimensions.Masses.MetricSI;
using NGenericDimensions.MetricPrefix;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Masses.MetricSI
{
    public class Kilograms : Grams<Kilo>
    {
    }
}

namespace NGenericDimensions.Extensions
{
    public static class KilogramsExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T KilogramsValue<T>(this Mass<Kilograms, T> mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => mass.MassValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? KilogramsValue<T>(this Mass<Kilograms, T>? mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => mass?.MassValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class KilogramsNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Mass<Kilograms, T> kilograms<T>(this T mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => mass;
    }
}