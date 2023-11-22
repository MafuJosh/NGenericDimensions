using NGenericDimensions.Lengths;
using NGenericDimensions.Durations;
using NGenericDimensions.Math;
using NGenericDimensions.MetricPrefix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions
{
    public interface ISpeed : IDimension
    {
        Length1DUnitOfMeasure LengthUnitOfMeasure { get; }
        DurationUnitOfMeasure DurationUnitOfMeasure { get; }
    }

    public readonly struct SpeedDouble : IEquatable<SpeedDouble>
    {
        internal readonly double ValueAsDouble;
        internal readonly Length1DUnitOfMeasure LengthUnitOfMeasure;
        internal readonly DurationUnitOfMeasure DurationUnitOfMeasure;

        internal SpeedDouble(double valueAsDouble, Length1DUnitOfMeasure lengthUnitOfMeasure, DurationUnitOfMeasure durationUnitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            LengthUnitOfMeasure = lengthUnitOfMeasure;
            DurationUnitOfMeasure = durationUnitOfMeasure;
        }

        public override bool Equals(object? obj) => obj != null && obj is SpeedDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.LengthUnitOfMeasure.Equals(LengthUnitOfMeasure) && o.DurationUnitOfMeasure.Equals(DurationUnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<SpeedDouble>.Equals(SpeedDouble other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble) && EqualityComparer<Length1DUnitOfMeasure>.Default.Equals(LengthUnitOfMeasure, other.LengthUnitOfMeasure) && EqualityComparer<DurationUnitOfMeasure>.Default.Equals(DurationUnitOfMeasure, other.DurationUnitOfMeasure);
        public static bool operator ==(SpeedDouble left, SpeedDouble right) => left.Equals(right);
        public static bool operator !=(SpeedDouble left, SpeedDouble right) => !left.Equals(right);
    }

    public readonly struct SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> : IEquatable<SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure>>
        where TLengthUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
        where TDurationUnitOfMeasure : DurationUnitOfMeasure, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal SpeedDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object? obj) => obj != null && obj is SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure>>.Equals(SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble);
        public static bool operator ==(SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> left, SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> left, SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> right) => !left.Equals(right);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TLengthUnitOfMeasure LengthUnitOfMeasure => UnitOfMeasureGlobals<TLengthUnitOfMeasure>.GlobalInstance;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDurationUnitOfMeasure DurationUnitOfMeasure => UnitOfMeasureGlobals<TDurationUnitOfMeasure>.GlobalInstance;
    }

    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "This is not needed yet.")]
    public readonly struct Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> : ISpeed, IEquatable<Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>>
        where TLengthUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
        where TDurationUnitOfMeasure : DurationUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Speed(TDataType speed) => SpeedValue = speed;

        public Speed(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => SpeedValue = speed.SpeedValue;
        
        public Speed(SpeedDouble speedToConvertFrom)
            => SpeedValue = GenericOperatorMath<TDataType>.ConvertFromDouble(
            speedToConvertFrom.ValueAsDouble
            * speedToConvertFrom.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1)
            / speedToConvertFrom.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1)
            );
        
        public Speed(LengthDouble<TLengthUnitOfMeasure> length, DurationDouble<TDurationUnitOfMeasure> duration)
        	=> SpeedValue = GenericOperatorMath<TDataType>.ConvertFromDouble(
        	(length.ValueAsDouble * length.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1))
        	/ (duration.ValueAsDouble * duration.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1))
        );
        
        public Speed(LengthDouble<TLengthUnitOfMeasure> length, TimeSpan duration)
            => SpeedValue = GenericOperatorMath<TDataType>.ConvertFromDouble(
            (length.ValueAsDouble * length.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1))
            / (new Duration<TDurationUnitOfMeasure, double>(duration)).DurationValue
        );
        
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType SpeedValue { get; }
        
        private double ValueAsDouble => GenericOperatorMath<TDataType>.ConvertToDouble(SpeedValue);
        double IDimension.Value => ValueAsDouble;
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TLengthUnitOfMeasure LengthUnitOfMeasure => UnitOfMeasureGlobals<TLengthUnitOfMeasure>.GlobalInstance;
        
        Length1DUnitOfMeasure ISpeed.LengthUnitOfMeasure => LengthUnitOfMeasure;
        
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDurationUnitOfMeasure DurationUnitOfMeasure => UnitOfMeasureGlobals<TDurationUnitOfMeasure>.GlobalInstance;
        
        DurationUnitOfMeasure ISpeed.DurationUnitOfMeasure => DurationUnitOfMeasure;
        
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Speed<TNewLengthUnitOfMeasure, TNewDurationUnitOfMeasure, TNewDataType> ConvertTo<TNewLengthUnitOfMeasure, TNewDurationUnitOfMeasure, TNewDataType>()
            where TNewLengthUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDurationUnitOfMeasure : DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Speed<TNewLengthUnitOfMeasure, TNewDurationUnitOfMeasure, TNewDataType>(this);

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TNewDataType>(this);
        #endregion

        #region Casting Operators
        public static implicit operator Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(TDataType speed) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed);

        public static explicit operator TDataType(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => speed.SpeedValue;

        public static implicit operator SpeedDouble(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => new SpeedDouble(speed.ValueAsDouble, speed.LengthUnitOfMeasure, speed.DurationUnitOfMeasure);

        public static implicit operator SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure>(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => new SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure>(speed.ValueAsDouble);
        #endregion

        #region + Operators
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator +(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Add(speed1.SpeedValue, speed2.SpeedValue));

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator +(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble + new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2);
        #endregion

        #region - Operators
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator -(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Subtract(speed1.SpeedValue, speed2.SpeedValue));

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator -(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble - new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2);
        #endregion

        #region * Operators
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator *(TDataType speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(speed1, speed2.SpeedValue));

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, TDataType speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(speed1.SpeedValue, speed2));

        public static Length<TLengthUnitOfMeasure, TDataType> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed, Duration<TDurationUnitOfMeasure, TDataType> duration) => new Length<TLengthUnitOfMeasure, TDataType>(speed.SpeedValue) * duration.DurationValue;

        public static Length<TLengthUnitOfMeasure, TDataType> operator *(Duration<TDurationUnitOfMeasure, TDataType> duration, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => new Length<TLengthUnitOfMeasure, TDataType>(speed.SpeedValue) * duration.DurationValue;

        public static Length<TLengthUnitOfMeasure, double> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed, DurationDouble<TDurationUnitOfMeasure> duration) => new Length<TLengthUnitOfMeasure, double>(speed.ValueAsDouble * duration.ValueAsDouble);

        public static Length<TLengthUnitOfMeasure, double> operator *(DurationDouble<TDurationUnitOfMeasure> duration, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => new Length<TLengthUnitOfMeasure, double>(speed.ValueAsDouble * duration.ValueAsDouble);

        public static Length<TLengthUnitOfMeasure, double> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed, DurationDouble duration) => new Length<TLengthUnitOfMeasure, double>(speed.ValueAsDouble * (new Duration<TDurationUnitOfMeasure, double>(duration)).DurationValue);

        public static Length<TLengthUnitOfMeasure, double> operator *(DurationDouble duration, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => new Length<TLengthUnitOfMeasure, double>(speed.ValueAsDouble * (new Duration<TDurationUnitOfMeasure, double>(duration)).DurationValue);

        public static Length<TLengthUnitOfMeasure, double> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed, TimeSpan duration) => new Length<TLengthUnitOfMeasure, double>(speed.ValueAsDouble * (new Duration<TDurationUnitOfMeasure, double>(duration)).DurationValue);

        public static Length<TLengthUnitOfMeasure, double> operator *(TimeSpan duration, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => new Length<TLengthUnitOfMeasure, double>(speed.ValueAsDouble * (new Duration<TDurationUnitOfMeasure, double>(duration)).DurationValue);
        #endregion

        #region / Operators
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, double speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed1.ValueAsDouble / speed2);

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, decimal speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed1.ValueAsDouble / Convert.ToDouble(speed2));

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, long speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed1.ValueAsDouble / speed2);

        public static double operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble / (new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2).SpeedValue);
        #endregion

        #region == Operators
        public static bool operator ==(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => EqualityComparer<TDataType>.Default.Equals(speed1.SpeedValue, speed2.SpeedValue);

        public static bool operator ==(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => !EqualityComparer<TDataType>.Default.Equals(speed1.SpeedValue, speed2.SpeedValue);

        public static bool operator !=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => GenericOperatorMath<TDataType>.GreaterThan(speed1.SpeedValue, speed2.SpeedValue);

        public static bool operator >(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => GenericOperatorMath<TDataType>.LessThan(speed1.SpeedValue, speed2.SpeedValue);

        public static bool operator <(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => GenericOperatorMath<TDataType>.GreaterThanOrEqualTo(speed1.SpeedValue, speed2.SpeedValue);

        public static bool operator >=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => GenericOperatorMath<TDataType>.LessThanOrEqualTo(speed1.SpeedValue, speed2.SpeedValue);

        public static bool operator <=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble) <= 0;
        #endregion

        #region ToString
        public override string ToString() => ToString(null, null);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format == null)
            { }
            else if (format.Contains("NU", StringComparison.Ordinal))
            {
                return LengthUnitOfMeasure.ToString(SpeedValue, format, formatProvider);
            }
            else if (format.Contains("SU", StringComparison.Ordinal))
            {
                return LengthUnitOfMeasure.ToString(SpeedValue, "NU", formatProvider) + " " + (LengthUnitOfMeasure.GetDimensionalUnitSymbol(this) ?? DurationUnitOfMeasure.GetDimensionalUnitSymbol(this) ?? (LengthUnitOfMeasure.ToString(format, formatProvider).TrimEnd(".".ToCharArray()) + @"/" + DurationUnitOfMeasure.ToString(format, formatProvider)));
            }
            return LengthUnitOfMeasure.ToString(SpeedValue, "NU", formatProvider) + " " + LengthUnitOfMeasure.ToString(format, formatProvider) + @" per " + DurationUnitOfMeasure.ToSingularString();
        }
        #endregion

        #region Equals
        public override bool Equals(object? obj) => obj != null && obj is Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(SpeedValue, o.SpeedValue);

        bool IEquatable<Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>>.Equals(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(SpeedValue, other.SpeedValue);
        #endregion

        #region GetHashCode
        public override int GetHashCode() => HashCode.Combine(SpeedValue);
        #endregion

        #region IConvertible
        TypeCode IConvertible.GetTypeCode() => GenericOperatorMath<TDataType>.GetTypeCode();
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
        {
            if (typeof(ISpeed).IsAssignableFrom(conversionType))
            {
                var convertedInstance = Activator.CreateInstance(conversionType, (SpeedDouble)this);
                if (convertedInstance != null) return convertedInstance;
            }
            throw new NotImplementedException();
        }
        byte IConvertible.ToByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToByte(SpeedValue);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDecimal(SpeedValue);
        double IConvertible.ToDouble(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDouble(SpeedValue);
        short IConvertible.ToInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt16(SpeedValue);
        int IConvertible.ToInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt32(SpeedValue);
        long IConvertible.ToInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt64(SpeedValue);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSByte(SpeedValue);
        float IConvertible.ToSingle(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSingle(SpeedValue);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt16(SpeedValue);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt32(SpeedValue);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt64(SpeedValue);
        #endregion
    }
}

namespace NGenericDimensions.Extensions
{
    public static class SpeedExtensionMethods
    {
        #region Nullable SpeedValue
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? SpeedValue<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(this Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>? speed)
            where TLengthUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDurationUnitOfMeasure : DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => speed?.SpeedValue;
        #endregion
    }
}