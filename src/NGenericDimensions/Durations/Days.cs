using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Durations
{
    public class Days : StandardDurationUnitOfMeasure, IDefinedUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => 864000000000L;
        
        public override string UnitSymbol => "d";
    }
}

namespace NGenericDimensions.Extensions
{
    public static class DaysExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T DaysValue<T>(this Duration<Durations.Days, T> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration.DurationValue;
        
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? DaysValue<T>(this Duration<Durations.Days, T>? duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration?.DurationValue;
        
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Speed<TUnitOfMeasure, Durations.Days, TDataType> day<TUnitOfMeasure, TDataType>(this DimensionPerExtension<Length<TUnitOfMeasure, TDataType>> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => length.PerValue.LengthValue;
        
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class DaysNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Days, T> days<T>(this T duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration;
        
    }
}