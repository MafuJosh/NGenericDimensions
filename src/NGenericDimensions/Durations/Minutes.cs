using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Durations
{
    public class Minutes : StandardDurationUnitOfMeasure, IDefinedUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => 600000000;

        public override string UnitSymbol => "min";
    }
}

namespace NGenericDimensions.Extensions
{
    public static class MinutesExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MinutesValue<T>(this Duration<Durations.Minutes, T> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration.DurationValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? MinutesValue<T>(this Duration<Durations.Minutes, T>? duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration?.DurationValue;

        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Speed<TUnitOfMeasure, Durations.Minutes, TDataType> minute<TUnitOfMeasure, TDataType>(this DimensionPerExtension<Length<TUnitOfMeasure, TDataType>> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => length.PerValue.LengthValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class MinutesNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Minutes, T> minutes<T>(this T duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration;
    }
}