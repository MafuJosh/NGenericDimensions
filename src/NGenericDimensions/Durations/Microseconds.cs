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

    public class Microseconds : Seconds<Micro>
    {

    }

}

namespace NGenericDimensions.Extensions
{

    public static class MicrosecondsExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MicrosecondsValue<T>(this Duration<Durations.Microseconds, T> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return duration.DurationValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> MicrosecondsValue<T>(this Nullable<Duration<Durations.Microseconds, T>> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static Speed<TUnitOfMeasure, Durations.Microseconds, TDataType> microsecond<TUnitOfMeasure, TDataType>(this DimensionPerExtension<Length<TUnitOfMeasure, TDataType>> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return length.PerValue.LengthValue;
        }

    }

}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class MicrosecondsNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Microseconds, T> microseconds<T>(this T duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return duration;
        }

    }

}