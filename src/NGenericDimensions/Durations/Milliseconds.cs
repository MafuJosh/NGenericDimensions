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

    public class Milliseconds : Seconds<Milli>
    {

    }

}

namespace NGenericDimensions.Extensions
{

    public static class MillisecondsExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MillisecondsValue<T>(this Duration<Durations.Milliseconds, T> duration) where T : struct, IComparable, IConvertible
        {
            return duration.DurationValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> MillisecondsValue<T>(this Nullable<Duration<Durations.Milliseconds, T>> duration) where T : struct, IComparable, IConvertible
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
        public static Speed<TUnitOfMeasure, Durations.Milliseconds, TDataType> millisecond<TUnitOfMeasure, TDataType>(this LengthPerExtension<TUnitOfMeasure, TDataType> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure
            where TDataType : struct, IComparable, IConvertible
        {
            return length.Length.LengthValue;
        }

    }

}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class MillisecondsNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Milliseconds, T> milliseconds<T>(this T duration) where T : struct, IComparable, IConvertible
        {
            return duration;
        }

    }

}