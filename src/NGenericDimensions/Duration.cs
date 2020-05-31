using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NGenericDimensions
{
    public interface IDuration : IDimension
    {
        Durations.DurationUnitOfMeasure UnitOfMeasure { get; }
    }

    public readonly struct DurationDouble
    {
        internal readonly double ValueAsDouble;
        internal readonly Durations.DurationUnitOfMeasure UnitOfMeasure;

        internal DurationDouble(double valueAsDouble, Durations.DurationUnitOfMeasure unitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            UnitOfMeasure = unitOfMeasure;
        }

        public override bool Equals(object obj) => obj != null && obj is DurationDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.UnitOfMeasure.Equals(UnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        public static bool operator ==(DurationDouble left, DurationDouble right) => left.Equals(right);
        public static bool operator !=(DurationDouble left, DurationDouble right) => !(left == right);
    }

    public readonly struct DurationDouble<TUnitOfMeasure>
        where TUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal DurationDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object obj) => obj != null && obj is DurationDouble<TUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        public static bool operator ==(DurationDouble<TUnitOfMeasure> left, DurationDouble<TUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(DurationDouble<TUnitOfMeasure> left, DurationDouble<TUnitOfMeasure> right) => !(left == right);
    }

    public readonly struct Duration<TUnitOfMeasure, TDataType> : IDuration, IEquatable<Duration<TUnitOfMeasure, TDataType>>
        where TUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Duration(TDataType duration) => DurationValue = duration;

        public Duration(TimeSpan duration)
        {
            if (ReferenceEquals(typeof(TUnitOfMeasure), typeof(Durations.Ticks)))
            {
                DurationValue = (TDataType)(Convert.ChangeType(duration.Ticks, typeof(TDataType)));
            }
            else
            {
                DurationValue = (TDataType)(Convert.ChangeType(duration.Ticks * UnitOfMeasureGlobals<Durations.Ticks>.GlobalInstance.GetCompleteMultiplier<TUnitOfMeasure>(1), typeof(TDataType)));
            }
        }

        public Duration(Duration<TUnitOfMeasure, TDataType> duration) => DurationValue = duration.DurationValue;

        public Duration(DurationDouble durationToConvertFrom) => DurationValue = (TDataType)(Convert.ChangeType(durationToConvertFrom.ValueAsDouble * durationToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1), typeof(TDataType)));
        #endregion

        #region Value

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDataType DurationValue { get; }

        private double ValueAsDouble => Convert.ToDouble((object)DurationValue);
        double IDimension.Value => ValueAsDouble;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public TimeSpan TimeSpan => new TimeSpan(Convert.ToInt64(ValueAsDouble * UnitOfMeasure.GetCompleteMultiplier<Durations.Ticks>(1)));
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TUnitOfMeasure UnitOfMeasure => UnitOfMeasureGlobals<TUnitOfMeasure>.GlobalInstance;

        Durations.DurationUnitOfMeasure IDuration.UnitOfMeasure => UnitOfMeasure;
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Duration<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Duration<TNewUnitOfMeasure, TNewDataType>(this);

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Duration<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Duration<TUnitOfMeasure, TNewDataType>(this);
        #endregion

        #region Casting Operators
        public static implicit operator Duration<TUnitOfMeasure, TDataType>(TDataType duration) => new Duration<TUnitOfMeasure, TDataType>(duration);

        public static explicit operator TimeSpan(Duration<TUnitOfMeasure, TDataType> duration) => new TimeSpan(Convert.ToInt64(duration.ValueAsDouble * duration.UnitOfMeasure.GetCompleteMultiplier<Durations.Ticks>(1)));

        public static explicit operator TDataType(Duration<TUnitOfMeasure, TDataType> duration) => duration.DurationValue;

        public static explicit operator Duration<TUnitOfMeasure, TDataType>(TimeSpan durationSpan) => new Duration<TUnitOfMeasure, TDataType>(durationSpan);

        public static implicit operator DurationDouble(Duration<TUnitOfMeasure, TDataType> duration) => new DurationDouble(duration.ValueAsDouble, duration.UnitOfMeasure);

        public static implicit operator DurationDouble<TUnitOfMeasure>(Duration<TUnitOfMeasure, TDataType> duration) => new DurationDouble<TUnitOfMeasure>(duration.ValueAsDouble);
        #endregion

        #region + Operators
        public static Duration<TUnitOfMeasure, TDataType> operator +(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2) => new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(duration1.DurationValue, duration2.DurationValue));

        public static Duration<TUnitOfMeasure, double> operator +(Duration<TUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble + (duration2.ValueAsDouble * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        #endregion

        #region - Operators
        public static Duration<TUnitOfMeasure, TDataType> operator -(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2) => new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(duration1.DurationValue, duration2.DurationValue));

        public static Duration<TUnitOfMeasure, double> operator -(Duration<TUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble - (duration2.ValueAsDouble * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        #endregion

        #region * Operators
        public static Duration<TUnitOfMeasure, TDataType> operator *(TDataType duration1, Duration<TUnitOfMeasure, TDataType> duration2) => new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(duration1, duration2.DurationValue));

        public static Duration<TUnitOfMeasure, TDataType> operator *(Duration<TUnitOfMeasure, TDataType> duration1, TDataType duration2) => new Duration<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(duration1.DurationValue, duration2));
        #endregion

        #region / Operators
        public static Duration<TUnitOfMeasure, double> operator /(Duration<TUnitOfMeasure, TDataType> duration1, double duration2) => new Duration<TUnitOfMeasure, double>(Convert.ToDouble((object)duration1.DurationValue) / duration2);

        public static Duration<TUnitOfMeasure, double> operator /(Duration<TUnitOfMeasure, TDataType> duration1, decimal duration2) => new Duration<TUnitOfMeasure, double>(Convert.ToDouble((object)duration1.DurationValue) / Convert.ToDouble(duration2));

        public static Duration<TUnitOfMeasure, double> operator /(Duration<TUnitOfMeasure, TDataType> duration1, long duration2) => new Duration<TUnitOfMeasure, double>(Convert.ToDouble((object)duration1.DurationValue) / duration2);

        public static double operator /(Duration<TUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble / (new Duration<TUnitOfMeasure, double>(duration2.ValueAsDouble).DurationValue);
        #endregion

        #region == Operators
        public static bool operator ==(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2) => duration1.DurationValue.CompareTo(duration2.DurationValue) == 0;

        public static bool operator ==(Duration<TUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2) => duration1.DurationValue.CompareTo(duration2.DurationValue) != 0;

        public static bool operator !=(Duration<TUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2) => duration1.DurationValue.CompareTo(duration2.DurationValue) > 0;

        public static bool operator >(Duration<TUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2) => duration1.DurationValue.CompareTo(duration2.DurationValue) < 0;

        public static bool operator <(Duration<TUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2) => duration1.DurationValue.CompareTo(duration2.DurationValue) >= 0;

        public static bool operator >=(Duration<TUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Duration<TUnitOfMeasure, TDataType> duration1, Duration<TUnitOfMeasure, TDataType> duration2) => duration1.DurationValue.CompareTo(duration2.DurationValue) <= 0;

        public static bool operator <=(Duration<TUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) <= 0;
        #endregion

        #region ToString
        public override string ToString() => UnitOfMeasure.ToString(DurationValue, null, null);

        public string ToString(string format, IFormatProvider formatProvider) => UnitOfMeasure.ToString(DurationValue, format, formatProvider);
        #endregion

        #region Equals
        public override bool Equals(object obj) => obj != null && obj is Duration<TUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(DurationValue, o.DurationValue);

        bool IEquatable<Duration<TUnitOfMeasure, TDataType>>.Equals(Duration<TUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(DurationValue, other.DurationValue);
        #endregion

        #region GetHashCode
        public override int GetHashCode() => HashCode.Combine(DurationValue);
        #endregion
    }
}

namespace NGenericDimensions.Extensions
{

    public static class DurationExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? DurationValue<TUnitOfMeasure, TDataType>(this Duration<TUnitOfMeasure, TDataType>? duration)
            where TUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => duration.HasValue ? duration.Value.DurationValue : (TDataType?)null;
    }
}