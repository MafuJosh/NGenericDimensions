using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NGenericDimensions.Durations
{

    public class Minutes : StandardDurationUnitOfMeasure, IDefinedUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return 600000000;
        }

        public override string UnitSymbol
        {
            get
            {
                return "min";
            }
        }
    }

}

namespace NGenericDimensions.Extensions
{

    public static class MinutesExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MinutesValue<T>(this Duration<Durations.Minutes, T> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return duration.DurationValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> MinutesValue<T>(this Nullable<Duration<Durations.Minutes, T>> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static Speed<TUnitOfMeasure, Durations.Minutes, TDataType> minute<TUnitOfMeasure, TDataType>(this DimensionPerExtension<Length<TUnitOfMeasure, TDataType>> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return length.PerValue.LengthValue;
        }

    }

}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class MinutesNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Minutes, T> minutes<T>(this T duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return duration;
        }

    }

}