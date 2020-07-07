using System;
using System.ComponentModel;

namespace NGenericDimensions.Durations
{
    public class Ticks : StandardDurationUnitOfMeasure, IDefinedUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => 1;

        public override string UnitSymbol => "ticks";
    }
}

namespace NGenericDimensions.Extensions
{
    public static class TicksExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T TicksValue<T>(this Duration<Durations.Ticks, T> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration.DurationValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? TicksValue<T>(this Duration<Durations.Ticks, T>? duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => duration?.DurationValue;
    }
}