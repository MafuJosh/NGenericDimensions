using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using NGenericDimensions.MetricPrefix;

namespace NGenericDimensions.Durations
{
    public class Seconds : StandardDurationUnitOfMeasure, IDefinedUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => 10000000;

        public override string UnitSymbol => "s";
    }

    public class Seconds<T> : StandardDurationUnitOfMeasure, IDefinedUnitOfMeasure where T : MetricPrefixBase
    {
        protected override double GetMultiplier(bool stayWithinFamily) => (double)(10000000 * UnitOfMeasureGlobals<T>.GlobalInstance.Multiplier);

        public override string UnitSymbol => MetricPrefix.UnitSymbol + "s";

        /// <summary>
        /// Returns the simple name of the derived class.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => MetricPrefix.ToString() + "seconds";

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public MetricPrefixBase MetricPrefix => UnitOfMeasureGlobals<T>.GlobalInstance;
    }
}

namespace NGenericDimensions.Extensions
{
    public static class SecondsExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SecondsValue<T>(this Duration<Durations.Seconds, T> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration.DurationValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? SecondsValue<T>(this Duration<Durations.Seconds, T>? duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration?.DurationValue;

        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Speed<TUnitOfMeasure, Durations.Seconds, TDataType> second<TUnitOfMeasure, TDataType>(this DimensionPerExtension<Length<TUnitOfMeasure, TDataType>> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => length.PerValue.LengthValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class SecondsNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Seconds, T> seconds<T>(this T duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration;
    }
}