using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NGenericDimensions.Durations
{

    public class Days : StandardDurationUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return 864000000000L;
        }

    }

}

namespace NGenericDimensions.Extensions
{

    public static class DaysExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T DaysValue<T>(this Duration<Durations.Days, T> duration) where T : struct, IComparable, IConvertible
        {
            return duration.DurationValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> DaysValue<T>(this Nullable<Duration<Durations.Days, T>> duration) where T : struct, IComparable, IConvertible
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
        public static Speed<TUnitOfMeasure, Durations.Days, TDataType> day<TUnitOfMeasure, TDataType>(this LengthPerExtension<TUnitOfMeasure, TDataType> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure
            where TDataType : struct, IComparable, IConvertible
        {
            return length.Length.LengthValue;
        }

    }

}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class DaysNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Days, T> days<T>(this T duration) where T : struct, IComparable, IConvertible
        {
            return duration;
        }

    }

}