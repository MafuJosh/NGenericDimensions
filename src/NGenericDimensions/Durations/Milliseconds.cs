using NGenericDimensions.MetricPrefix;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Durations
{
    public class Milliseconds : Seconds<Milli>
    {
    }
}

namespace NGenericDimensions.Extensions
{
    public static class MillisecondsExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MillisecondsValue<T>(this Duration<Durations.Milliseconds, T> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration.DurationValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? MillisecondsValue<T>(this Duration<Durations.Milliseconds, T>? duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration?.DurationValue;

        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Speed<TUnitOfMeasure, Durations.Milliseconds, TDataType> millisecond<TUnitOfMeasure, TDataType>(this DimensionPerExtension<Length<TUnitOfMeasure, TDataType>> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => length.PerValue.LengthValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class MillisecondsNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Milliseconds, T> milliseconds<T>(this T duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration;
    }
}