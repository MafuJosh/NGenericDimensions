using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NGenericDimensions.Durations
{

    public class Days : StandardDurationUnitOfMeasure, IDefinedUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return 864000000000L;
        }

        public override string UnitSymbol
        {
            get
            {
                return "d";
            }
        }
    }

}

namespace NGenericDimensions.Extensions
{

    public static class DaysExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T DaysValue<T>(this Duration<Durations.Days, T> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return duration.DurationValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> DaysValue<T>(this Nullable<Duration<Durations.Days, T>> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static Speed<TUnitOfMeasure, Durations.Days, TDataType> day<TUnitOfMeasure, TDataType>(this DimensionPerExtension<Length<TUnitOfMeasure, TDataType>> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return length.PerValue.LengthValue;
        }

    }

}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class DaysNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Days, T> days<T>(this T duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return duration;
        }

    }

}