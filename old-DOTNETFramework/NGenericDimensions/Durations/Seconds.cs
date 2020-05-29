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

    public class Seconds : StandardDurationUnitOfMeasure, IDefinedUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return 10000000;
        }

        public override string UnitSymbol
        {
            get
            {
                return "s";
            }
        }
    }

    public class Seconds<T> : StandardDurationUnitOfMeasure, IDefinedUnitOfMeasure where T : MetricPrefixBase
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return (double)(10000000 * UnitOfMeasureGlobals<T>.GlobalInstance.Multiplier);
        }

        public override string UnitSymbol
        {
            get
            {
                return MetricPrefix.UnitSymbol + "s";
            }
        }

        /// <summary>
        /// Returns the simple name of the derived class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MetricPrefix.ToString() + "seconds";
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public MetricPrefixBase MetricPrefix
        {
            get { return UnitOfMeasureGlobals<T>.GlobalInstance; }
        }
    }

}

namespace NGenericDimensions.Extensions
{

    public static class SecondsExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SecondsValue<T>(this Duration<Durations.Seconds, T> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return duration.DurationValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> SecondsValue<T>(this Nullable<Duration<Durations.Seconds, T>> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static Speed<TUnitOfMeasure, Durations.Seconds, TDataType> second<TUnitOfMeasure, TDataType>(this DimensionPerExtension<Length<TUnitOfMeasure, TDataType>> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return length.PerValue.LengthValue;
        }

    }

}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class SecondsNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Duration<Durations.Seconds, T> seconds<T>(this T duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return duration;
        }

    }

}