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

    public struct Duration<TUnitOfMeasure, TDataType> : IDuration<TUnitOfMeasure>
        where TUnitOfMeasure : Durations.DurationUnitOfMeasure
        where TDataType : struct, IComparable, IConvertible
    {


        private TDataType mDuration;
        public Duration(TDataType duration)
        {
            mDuration = duration;
        }

        public Duration(TimeSpan duration)
        {
            if (object.ReferenceEquals(typeof(TUnitOfMeasure), typeof(Durations.Ticks)))
            {
                mDuration = (TDataType)(object)duration.Ticks;
            }
            else
            {
                mDuration = (TDataType)(object)(duration.Ticks * UnitOfMeasureGlobals<Durations.Ticks>.GlobalInstance.GetCompleteMultiplier<TUnitOfMeasure>(1));
            }
        }

        public Duration(Duration<TUnitOfMeasure, TDataType> duration)
        {
            mDuration = duration.mDuration;
        }

        public Duration(IDuration durationToConvertFrom)
        {
            mDuration = (TDataType)(object)(durationToConvertFrom.Value * durationToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDataType DurationValue
        {
            get { return mDuration; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public TimeSpan TimeSpan
        {
            get { return new TimeSpan(Convert.ToInt64(ValueAsDouble * UnitOfMeasure.GetCompleteMultiplier<Durations.Ticks>(1))); }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TUnitOfMeasure UnitOfMeasure
        {
            get { return UnitOfMeasureGlobals<TUnitOfMeasure>.GlobalInstance; }
        }

        private Durations.DurationUnitOfMeasure UnitOfMeasure1
        {
            get { return UnitOfMeasure; }
        }
        Durations.DurationUnitOfMeasure IDuration.UnitOfMeasure
        {
            get { return UnitOfMeasure1; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Duration<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Durations.DurationUnitOfMeasure
            where TNewDataType : struct, IComparable, IConvertible
        {
            return (TNewDataType)(object)(ValueAsDouble * UnitOfMeasure1.GetCompleteMultiplier<TNewUnitOfMeasure>(1));
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Duration<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IConvertible
        {
            return (TNewDataType)(object)mDuration;
        }

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
            return duration.mDuration;
        }

        public static explicit operator Duration<TUnitOfMeasure, TDataType>(TimeSpan durationSpan)
        {
            return new Duration<TUnitOfMeasure, TDataType>(durationSpan);
        }

        public static Duration<TUnitOfMeasure, TDataType> operator +(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(duration1.mDuration, duration2.mDuration));
        }

        public static Duration<TUnitOfMeasure, double> operator +(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble + (duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        public static Duration<TUnitOfMeasure, TDataType> operator -(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(duration1.mDuration, duration2.mDuration));
        }

        public static Duration<TUnitOfMeasure, double> operator -(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble - (duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        public static Duration<TUnitOfMeasure, TDataType> operator *(TDataType duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(duration1, duration2.mDuration));
        }

        public static Duration<TUnitOfMeasure, TDataType> operator *(Duration<TUnitOfMeasure, TDataType> duration1, TDataType duration2)
        {
            return new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(duration1.mDuration, duration2));
        }

        public static Duration<TUnitOfMeasure, double> operator /(Duration<TUnitOfMeasure, TDataType> duration1, double duration2)
        {
            return new Duration<TUnitOfMeasure, double>(Convert.ToDouble((object)duration1.mDuration) / duration2);
        }

        public static double operator /(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.ValueAsDouble / duration2.ValueAsDouble;
        }

        public static bool operator ==(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.mDuration.CompareTo(duration2.mDuration) == 0;
        }

        public static bool operator ==(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) == 0;
        }

        public static bool operator !=(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.mDuration.CompareTo(duration2.mDuration) != 0;
        }

        public static bool operator !=(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) != 0;
        }

        public static bool operator >(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.mDuration.CompareTo(duration2.mDuration) > 0;
        }

        public static bool operator >(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) > 0;
        }

        public static bool operator <(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.mDuration.CompareTo(duration2.mDuration) < 0;
        }

        public static bool operator <(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) < 0;
        }

        public static bool operator >=(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.mDuration.CompareTo(duration2.mDuration) >= 0;
        }

        public static bool operator >=(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) >= 0;
        }

        public static bool operator <=(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2)
        {
            return duration1.mDuration.CompareTo(duration2.mDuration) <= 0;
        }

        public static bool operator <=(Duration<TUnitOfMeasure, TDataType> duration1, IDuration duration2)
        {
            return duration1.ValueAsDouble.CompareTo(duration2.Value * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) <= 0;
        }

        private double ValueAsDouble
        {
            get { return Convert.ToDouble((object)mDuration); }
        }
        double IDimension.Value
        {
            get { return ValueAsDouble; }
        }

    }
}

namespace NGenericDimensions.Extensions
{

    public static class DurationExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType DurationValue<TUnitOfMeasure, TDataType>(this Nullable<Duration<TUnitOfMeasure, TDataType>> duration)
            where TUnitOfMeasure : Durations.DurationUnitOfMeasure
            where TDataType : struct, IComparable, IConvertible
        {
            return duration.Value.DurationValue;
        }

    }

}