using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NGenericDimensions
{

    public interface IDuration : IDimension
    {
        Durations.DurationUnitOfMeasure UnitOfMeasure { get; }
    }

    public interface IDuration<out TUnitOfMeasure> : IDuration where TUnitOfMeasure : Durations.DurationUnitOfMeasure
    {
    }

    public readonly struct Duration<TUnitOfMeasure, TDataType> : IDuration<TUnitOfMeasure>
        where TUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Duration(TDataType duration)
        {
            DurationValue = duration;
        }

        public Duration(TimeSpan duration)
        {
            if (object.ReferenceEquals(typeof(TUnitOfMeasure), typeof(Durations.Ticks)))
            {
                DurationValue = (TDataType)(Convert.ChangeType(duration.Ticks, typeof(TDataType)));
            }
            else
            {
                DurationValue = (TDataType)(Convert.ChangeType(duration.Ticks * UnitOfMeasureGlobals<Durations.Ticks>.GlobalInstance.GetCompleteMultiplier<TUnitOfMeasure>(1), typeof(TDataType)));
            }
        }

        public Duration(Duration<TUnitOfMeasure, TDataType> duration)
        {
            DurationValue = duration.DurationValue;
        }

        public Duration(IDuration durationToConvertFrom)
        {
            DurationValue = (TDataType)(Convert.ChangeType(durationToConvertFrom.Value * durationToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1), typeof(TDataType)));
        }
        #endregion

        #region Value

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDataType DurationValue { get; }

        private double ValueAsDouble
        {
            get { return Convert.ToDouble((object)DurationValue); }
        }
        double IDimension.Value
        {
            get { return ValueAsDouble; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public TimeSpan TimeSpan
        {
            get { return new TimeSpan(Convert.ToInt64(ValueAsDouble * UnitOfMeasure.GetCompleteMultiplier<Durations.Ticks>(1))); }
        }
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TUnitOfMeasure UnitOfMeasure
        {
            get { return UnitOfMeasureGlobals<TUnitOfMeasure>.GlobalInstance; }
        }

        Durations.DurationUnitOfMeasure IDuration.UnitOfMeasure
        {
            get { return UnitOfMeasure; }
        }
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Duration<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return new Duration<TNewUnitOfMeasure, TNewDataType>(this);
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Duration<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return new Duration<TUnitOfMeasure, TNewDataType>(this);
        }
        #endregion

        #region Casting Operators
        public static implicit operator Duration<TUnitOfMeasure, TDataType>(TDataType duration)
        {
            return new Duration<TUnitOfMeasure, TDataType>(duration);
        }

        public static explicit operator TimeSpan(Duration<TUnitOfMeasure, TDataType> duration)
        {
            return new TimeSpan(Convert.ToInt64(duration.ValueAsDouble * duration.UnitOfMeasure.GetCompleteMultiplier<Durations.Ticks>(1)));
        }

        public static explicit operator TDataType(Duration<TUnitOfMeasure, TDataType> duration)
        {
            return duration.DurationValue;
        }

        public static explicit operator Duration<TUnitOfMeasure, TDataType>(TimeSpan durationSpan)
        {
            return new Duration<TUnitOfMeasure, TDataType>(durationSpan);
        }
        #endregion

        #region + Operators
        public static Duration<TUnitOfMeasure, TDataType> operator +(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(duration1.DurationValue, duration2.DurationValue));
        }

        public static Duration<TUnitOfMeasure, double> operator +(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble + (duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }
        #endregion

        #region - Operators
        public static Duration<TUnitOfMeasure, TDataType> operator -(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(duration1.DurationValue, duration2.DurationValue));
        }

        public static Duration<TUnitOfMeasure, double> operator -(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble - (duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }
        #endregion

        #region * Operators
        public static Duration<TUnitOfMeasure, TDataType> operator *(TDataType duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(duration1, duration2.DurationValue));
        }

        public static Duration<TUnitOfMeasure, TDataType> operator *(Duration<TUnitOfMeasure, TDataType> duration1, TDataType duration2)
        {
            return new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(duration1.DurationValue, duration2));
        }
        #endregion

        #region / Operators
        public static Duration<TUnitOfMeasure, double> operator /(Duration<TUnitOfMeasure, TDataType> duration1, double duration2)
        {
            return new Duration<TUnitOfMeasure, double>(Convert.ToDouble((object)duration1.DurationValue) / duration2);
        }

        public static Duration<TUnitOfMeasure, double> operator /(Duration<TUnitOfMeasure, TDataType> duration1, decimal duration2)
        {
            return new Duration<TUnitOfMeasure, double>(Convert.ToDouble((object)duration1.DurationValue) / Convert.ToDouble(duration2));
        }
        
        public static Duration<TUnitOfMeasure, double> operator /(Duration<TUnitOfMeasure, TDataType> duration1, Int64 duration2)
        {
            return new Duration<TUnitOfMeasure, double>(Convert.ToDouble((object)duration1.DurationValue) / duration2);
        }

        public static double operator /(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble / (new Duration<TUnitOfMeasure, double>(duration2).DurationValue);
        }
        #endregion

        #region == Operators
        public static bool operator ==(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.DurationValue.CompareTo(duration2.DurationValue) == 0;
        }

        public static bool operator ==(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) == 0;
        }
        #endregion

        #region != Operators
        public static bool operator !=(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.DurationValue.CompareTo(duration2.DurationValue) != 0;
        }

        public static bool operator !=(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) != 0;
        }
        #endregion

        #region > Operators
        public static bool operator >(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.DurationValue.CompareTo(duration2.DurationValue) > 0;
        }

        public static bool operator >(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) > 0;
        }
        #endregion

        #region < Operators
        public static bool operator <(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.DurationValue.CompareTo(duration2.DurationValue) < 0;
        }

        public static bool operator <(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) < 0;
        }
        #endregion

        #region >= Operators
        public static bool operator >=(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.DurationValue.CompareTo(duration2.DurationValue) >= 0;
        }

        public static bool operator >=(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) >= 0;
        }
        #endregion

        #region <= Operators
        public static bool operator <=(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.DurationValue.CompareTo(duration2.DurationValue) <= 0;
        }

        public static bool operator <=(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) <= 0;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return UnitOfMeasure.ToString(DurationValue, null, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return UnitOfMeasure.ToString(DurationValue, format, formatProvider);
        }
        #endregion
        
    }
}

namespace NGenericDimensions.Extensions
{

    public static class DurationExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<TDataType> DurationValue<TUnitOfMeasure, TDataType>(this Nullable<Duration<TUnitOfMeasure, TDataType>> duration)
            where TUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return duration.HasValue ? duration.Value.DurationValue : (TDataType?)null;
        }
    }

}