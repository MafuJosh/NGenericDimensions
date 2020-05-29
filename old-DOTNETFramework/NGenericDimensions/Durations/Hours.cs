using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NGenericDimensions.Durations
{

    public class Hours : StandardDurationUnitOfMeasure, IDefinedUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return 36000000000L;
        }

        public override string UnitSymbol
        {
            get
            {
                return "hr";
            }
        }
    }

}

namespace NGenericDimensions.Extensions
{

    public static class HoursExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T HoursValue<T>(this Duration<Durations.Hours, T> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return duration.DurationValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> HoursValue<T>(this Nullable<Duration<Durations.Hours, T>> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static Speed<TUnitOfMeasure, Durations.Hours, TDataType> hour<TUnitOfMeasure, TDataType>(this DimensionPerExtension<Length<TUnitOfMeasure, TDataType>> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return length.PerValue.LengthValue;
        }

    }

}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class HoursNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Hours, T> hours<T>(this T duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return duration;
        }

    }

}