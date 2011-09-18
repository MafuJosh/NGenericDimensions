using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using NGenericDimensions.MetricPrefix;

namespace NGenericDimensions.Durations
{

    public class Seconds : StandardDurationUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return 10000000;
        }

    }

    public class Seconds<T> : StandardDurationUnitOfMeasure where T : MetricPrefixBase
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return (double)(10000000 * UnitOfMeasureGlobals<T>.GlobalInstance.Multiplier);
        }

    }

}

namespace NGenericDimensions.Extensions
{

    public static class SecondsExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SecondsValue<T>(this Duration<Durations.Seconds, T> duration) where T : struct, IComparable, IConvertible
        {
            return duration.DurationValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> SecondsValue<T>(this Nullable<Duration<Durations.Seconds, T>> duration) where T : struct, IComparable, IConvertible
        {
            if (duration.HasValue)
            {
                return duration.Value.DurationValue;
            }
            else
            {
                return null;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Speed<TUnitOfMeasure, Durations.Seconds, TDataType> second<TUnitOfMeasure, TDataType>(this LengthPerExtension<TUnitOfMeasure, TDataType> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure
            where TDataType : struct, IComparable, IConvertible
        {
            return length.Length.LengthValue;
        }

    }

}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class SecondsNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Seconds, T> seconds<T>(this T duration) where T : struct, IComparable, IConvertible
        {
            return duration;
        }

    }

}