using NGenericDimensions.Durations;
using NGenericDimensions.Math;
using NGenericDimensions.MetricPrefix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions
{
    public interface IDuration : IDimension
    {
        DurationUnitOfMeasure DurationUnitOfMeasure { get; }
    }

    public readonly struct DurationDouble : IEquatable<DurationDouble>
    {
        internal readonly double ValueAsDouble;
        internal readonly DurationUnitOfMeasure DurationUnitOfMeasure;

        internal DurationDouble(double valueAsDouble, DurationUnitOfMeasure durationUnitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            DurationUnitOfMeasure = durationUnitOfMeasure;
        }

        public override bool Equals(object? obj) => obj != null && obj is DurationDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.DurationUnitOfMeasure.Equals(DurationUnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<DurationDouble>.Equals(DurationDouble other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble) && EqualityComparer<DurationUnitOfMeasure>.Default.Equals(DurationUnitOfMeasure, other.DurationUnitOfMeasure);
        public static bool operator ==(DurationDouble left, DurationDouble right) => left.Equals(right);
        public static bool operator !=(DurationDouble left, DurationDouble right) => !left.Equals(right);
    }

    public readonly struct DurationDouble<TDurationUnitOfMeasure> : IEquatable<DurationDouble<TDurationUnitOfMeasure>>
        where TDurationUnitOfMeasure : DurationUnitOfMeasure, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal DurationDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object? obj) => obj != null && obj is DurationDouble<TDurationUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<DurationDouble<TDurationUnitOfMeasure>>.Equals(DurationDouble<TDurationUnitOfMeasure> other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble);
        public static bool operator ==(DurationDouble<TDurationUnitOfMeasure> left, DurationDouble<TDurationUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(DurationDouble<TDurationUnitOfMeasure> left, DurationDouble<TDurationUnitOfMeasure> right) => !left.Equals(right);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDurationUnitOfMeasure DurationUnitOfMeasure => UnitOfMeasureGlobals<TDurationUnitOfMeasure>.GlobalInstance;
    }

    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "This is not needed yet.")]
    public readonly struct Duration<TDurationUnitOfMeasure, TDataType> : IDuration, IEquatable<Duration<TDurationUnitOfMeasure, TDataType>>
        where TDurationUnitOfMeasure : DurationUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Duration(TDataType duration) => DurationValue = duration;

        public Duration(TimeSpan duration)
        {
            if (ReferenceEquals(typeof(TDurationUnitOfMeasure), typeof(Ticks)))
            {
                DurationValue = (TDataType)(Convert.ChangeType(duration.Ticks, typeof(TDataType), null));
            }
            else
            {
                DurationValue = GenericOperatorMath<TDataType>.ConvertFromDouble(duration.Ticks * UnitOfMeasureGlobals<Ticks>.GlobalInstance.GetCompleteMultiplier<TDurationUnitOfMeasure>(1));
            }
        }

        public Duration(Duration<TDurationUnitOfMeasure, TDataType> duration) => DurationValue = duration.DurationValue;
        
        public Duration(DurationDouble durationToConvertFrom)
            => DurationValue = GenericOperatorMath<TDataType>.ConvertFromDouble(
            durationToConvertFrom.ValueAsDouble
            * durationToConvertFrom.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1)
            );
        
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType DurationValue { get; }
        
        private double ValueAsDouble => GenericOperatorMath<TDataType>.ConvertToDouble(DurationValue);
        double IDimension.Value => ValueAsDouble;
        
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TimeSpan TimeSpan => new TimeSpan(Convert.ToInt64(ValueAsDouble * DurationUnitOfMeasure.GetCompleteMultiplier<Ticks>(1)));
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDurationUnitOfMeasure DurationUnitOfMeasure => UnitOfMeasureGlobals<TDurationUnitOfMeasure>.GlobalInstance;
        
        DurationUnitOfMeasure IDuration.DurationUnitOfMeasure => DurationUnitOfMeasure;
        
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Duration<TNewDurationUnitOfMeasure, TNewDataType> ConvertTo<TNewDurationUnitOfMeasure, TNewDataType>()
            where TNewDurationUnitOfMeasure : DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Duration<TNewDurationUnitOfMeasure, TNewDataType>(this);

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Duration<TDurationUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Duration<TDurationUnitOfMeasure, TNewDataType>(this);
        #endregion

        #region Casting Operators
        public static implicit operator Duration<TDurationUnitOfMeasure, TDataType>(TDataType duration) => new Duration<TDurationUnitOfMeasure, TDataType>(duration);

        public static explicit operator TDataType(Duration<TDurationUnitOfMeasure, TDataType> duration) => duration.DurationValue;

        public static implicit operator DurationDouble(Duration<TDurationUnitOfMeasure, TDataType> duration) => new DurationDouble(duration.ValueAsDouble, duration.DurationUnitOfMeasure);

        public static implicit operator DurationDouble<TDurationUnitOfMeasure>(Duration<TDurationUnitOfMeasure, TDataType> duration) => new DurationDouble<TDurationUnitOfMeasure>(duration.ValueAsDouble);

        public static explicit operator TimeSpan(Duration<TDurationUnitOfMeasure, TDataType> duration) => new TimeSpan(Convert.ToInt64(duration.ValueAsDouble * duration.DurationUnitOfMeasure.GetCompleteMultiplier<Ticks>(1)));

        public static explicit operator Duration<TDurationUnitOfMeasure, TDataType>(TimeSpan durationSpan) => new Duration<TDurationUnitOfMeasure, TDataType>(durationSpan);
        #endregion

        #region + Operators
        public static Duration<TDurationUnitOfMeasure, TDataType> operator +(Duration<TDurationUnitOfMeasure, TDataType> duration1, Duration<TDurationUnitOfMeasure, TDataType> duration2) => new Duration<TDurationUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Add(duration1.DurationValue, duration2.DurationValue));

        public static Duration<TDurationUnitOfMeasure, double> operator +(Duration<TDurationUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble + (duration2.ValueAsDouble * duration2.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1));
        #endregion

        #region - Operators
        public static Duration<TDurationUnitOfMeasure, TDataType> operator -(Duration<TDurationUnitOfMeasure, TDataType> duration1, Duration<TDurationUnitOfMeasure, TDataType> duration2) => new Duration<TDurationUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Subtract(duration1.DurationValue, duration2.DurationValue));

        public static Duration<TDurationUnitOfMeasure, double> operator -(Duration<TDurationUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble - (duration2.ValueAsDouble * duration2.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1));
        #endregion

        #region * Operators
        public static Duration<TDurationUnitOfMeasure, TDataType> operator *(TDataType duration1, Duration<TDurationUnitOfMeasure, TDataType> duration2) => new Duration<TDurationUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(duration1, duration2.DurationValue));

        public static Duration<TDurationUnitOfMeasure, TDataType> operator *(Duration<TDurationUnitOfMeasure, TDataType> duration1, TDataType duration2) => new Duration<TDurationUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(duration1.DurationValue, duration2));
        #endregion

        #region / Operators
        public static Duration<TDurationUnitOfMeasure, double> operator /(Duration<TDurationUnitOfMeasure, TDataType> duration1, double duration2) => new Duration<TDurationUnitOfMeasure, double>(duration1.ValueAsDouble / duration2);

        public static Duration<TDurationUnitOfMeasure, double> operator /(Duration<TDurationUnitOfMeasure, TDataType> duration1, decimal duration2) => new Duration<TDurationUnitOfMeasure, double>(duration1.ValueAsDouble / Convert.ToDouble(duration2));

        public static Duration<TDurationUnitOfMeasure, double> operator /(Duration<TDurationUnitOfMeasure, TDataType> duration1, long duration2) => new Duration<TDurationUnitOfMeasure, double>(duration1.ValueAsDouble / duration2);

        public static double operator /(Duration<TDurationUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble / (new Duration<TDurationUnitOfMeasure, double>(duration2).DurationValue);
        #endregion

        #region == Operators
        public static bool operator ==(Duration<TDurationUnitOfMeasure, TDataType> duration1, Duration<TDurationUnitOfMeasure, TDataType> duration2) => EqualityComparer<TDataType>.Default.Equals(duration1.DurationValue, duration2.DurationValue);

        public static bool operator ==(Duration<TDurationUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1)) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Duration<TDurationUnitOfMeasure, TDataType> duration1, Duration<TDurationUnitOfMeasure, TDataType> duration2) => !EqualityComparer<TDataType>.Default.Equals(duration1.DurationValue, duration2.DurationValue);

        public static bool operator !=(Duration<TDurationUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1)) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Duration<TDurationUnitOfMeasure, TDataType> duration1, Duration<TDurationUnitOfMeasure, TDataType> duration2) => GenericOperatorMath<TDataType>.GreaterThan(duration1.DurationValue, duration2.DurationValue);

        public static bool operator >(Duration<TDurationUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1)) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Duration<TDurationUnitOfMeasure, TDataType> duration1, Duration<TDurationUnitOfMeasure, TDataType> duration2) => GenericOperatorMath<TDataType>.LessThan(duration1.DurationValue, duration2.DurationValue);

        public static bool operator <(Duration<TDurationUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1)) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Duration<TDurationUnitOfMeasure, TDataType> duration1, Duration<TDurationUnitOfMeasure, TDataType> duration2) => GenericOperatorMath<TDataType>.GreaterThanOrEqualTo(duration1.DurationValue, duration2.DurationValue);

        public static bool operator >=(Duration<TDurationUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1)) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Duration<TDurationUnitOfMeasure, TDataType> duration1, Duration<TDurationUnitOfMeasure, TDataType> duration2) => GenericOperatorMath<TDataType>.LessThanOrEqualTo(duration1.DurationValue, duration2.DurationValue);

        public static bool operator <=(Duration<TDurationUnitOfMeasure, TDataType> duration1, DurationDouble duration2) => duration1.ValueAsDouble.CompareTo(duration2.ValueAsDouble * duration2.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1)) <= 0;
        #endregion

        #region ToString
        public override string ToString() => DurationUnitOfMeasure.ToString(DurationValue, null, null);

        public string ToString(string? format, IFormatProvider? formatProvider) => DurationUnitOfMeasure.ToString(DurationValue, format, formatProvider);
        #endregion

        #region Equals
        public override bool Equals(object? obj) => obj != null && obj is Duration<TDurationUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(DurationValue, o.DurationValue);

        bool IEquatable<Duration<TDurationUnitOfMeasure, TDataType>>.Equals(Duration<TDurationUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(DurationValue, other.DurationValue);
        #endregion

        #region GetHashCode
        public override int GetHashCode() => HashCode.Combine(DurationValue);
        #endregion

        #region IConvertible
        TypeCode IConvertible.GetTypeCode() => GenericOperatorMath<TDataType>.GetTypeCode();
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
        {
            if (conversionType == typeof(TimeSpan))
            {
                return (TimeSpan)this;
            }
            if (typeof(IDuration).IsAssignableFrom(conversionType))
            {
                var convertedInstance = Activator.CreateInstance(conversionType, (DurationDouble)this);
                if (convertedInstance != null) return convertedInstance;
            }
            throw new NotImplementedException();
        }
        byte IConvertible.ToByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToByte(DurationValue);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDecimal(DurationValue);
        double IConvertible.ToDouble(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDouble(DurationValue);
        short IConvertible.ToInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt16(DurationValue);
        int IConvertible.ToInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt32(DurationValue);
        long IConvertible.ToInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt64(DurationValue);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSByte(DurationValue);
        float IConvertible.ToSingle(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSingle(DurationValue);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt16(DurationValue);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt32(DurationValue);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt64(DurationValue);
#if !NET
        bool IConvertible.ToBoolean(IFormatProvider? provider) => throw new InvalidCastException("The conversion to a Boolean is not supported.");
        char IConvertible.ToChar(IFormatProvider? provider) => throw new InvalidCastException("The conversion to a Char is not supported.");
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => throw new InvalidCastException("The conversion to a DateTime is not supported.");
        string IConvertible.ToString(IFormatProvider? provider) => ToString(null, provider);
#endif
        #endregion
    }
}

namespace NGenericDimensions.Extensions
{
    public static class DurationExtensionMethods
    {
        #region Nullable DurationValue
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? DurationValue<TDurationUnitOfMeasure, TDataType>(this Duration<TDurationUnitOfMeasure, TDataType>? duration)
            where TDurationUnitOfMeasure : DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => duration?.DurationValue;
        #endregion
    }
}