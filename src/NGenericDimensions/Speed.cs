using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NGenericDimensions
{
    public interface ISpeed : IDimension
    {
        Lengths.Length1DUnitOfMeasure LengthUnitOfMeasure { get; }
        Durations.DurationUnitOfMeasure DurationUnitOfMeasure { get; }
    }

    public readonly struct SpeedDouble
    {
        internal readonly double ValueAsDouble;
        internal readonly Lengths.Length1DUnitOfMeasure LengthUnitOfMeasure;
        internal readonly Durations.DurationUnitOfMeasure DurationUnitOfMeasure;

        internal SpeedDouble(double valueAsDouble, Lengths.Length1DUnitOfMeasure lengthUnitOfMeasure, Durations.DurationUnitOfMeasure durationUnitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            LengthUnitOfMeasure = lengthUnitOfMeasure;
            DurationUnitOfMeasure = durationUnitOfMeasure;
        }

        public override bool Equals(object obj) => obj != null && obj is SpeedDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.LengthUnitOfMeasure.Equals(LengthUnitOfMeasure) && o.DurationUnitOfMeasure.Equals(DurationUnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        public static bool operator ==(SpeedDouble left, SpeedDouble right) => left.Equals(right);
        public static bool operator !=(SpeedDouble left, SpeedDouble right) => !(left == right);
    }

    public readonly struct SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure>
        where TLengthUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
        where TDurationUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal SpeedDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object obj) => obj != null && obj is SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        public static bool operator ==(SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> left, SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> left, SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure> right) => !(left == right);
    }

    public readonly struct Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> : ISpeed, IEquatable<Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>>
        where TLengthUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
        where TDurationUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Speed(TDataType speed) => SpeedValue = speed;

        public Speed(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => SpeedValue = speed.SpeedValue;

        public Speed(SpeedDouble speedToConvertFrom) => SpeedValue = (TDataType)Convert.ChangeType(speedToConvertFrom.ValueAsDouble * speedToConvertFrom.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1) / speedToConvertFrom.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1), typeof(TDataType));

        public Speed(LengthDouble<TLengthUnitOfMeasure> length, DurationDouble<TDurationUnitOfMeasure> duration) => SpeedValue = (TDataType)Convert.ChangeType((new Length<TLengthUnitOfMeasure, double>(length.ValueAsDouble)).LengthValue / (new Duration<TDurationUnitOfMeasure, double>(duration.ValueAsDouble)).DurationValue, typeof(TDataType));

        public Speed(LengthDouble<TLengthUnitOfMeasure> length, TimeSpan duration) => SpeedValue = (TDataType)(Convert.ChangeType((new Length<TLengthUnitOfMeasure, double>(length.ValueAsDouble)).LengthValue / (new Duration<TDurationUnitOfMeasure, double>(duration)).DurationValue, typeof(TDataType)));
        #endregion

        #region Value

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDataType SpeedValue { get; }

        private double ValueAsDouble => Convert.ToDouble((object)SpeedValue);
        double IDimension.Value => ValueAsDouble;
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TLengthUnitOfMeasure LengthUnitOfMeasure => UnitOfMeasureGlobals<TLengthUnitOfMeasure>.GlobalInstance;

        private Lengths.Length1DUnitOfMeasure LengthUnitOfMeasure1 => LengthUnitOfMeasure;
        Lengths.Length1DUnitOfMeasure ISpeed.LengthUnitOfMeasure => LengthUnitOfMeasure1;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDurationUnitOfMeasure DurationUnitOfMeasure => UnitOfMeasureGlobals<TDurationUnitOfMeasure>.GlobalInstance;

        private Durations.DurationUnitOfMeasure DurationUnitOfMeasure1 => DurationUnitOfMeasure;
        Durations.DurationUnitOfMeasure ISpeed.DurationUnitOfMeasure => DurationUnitOfMeasure1;
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Speed<TNewLengthUnitOfMeasure, TNewDurationUnitOfMeasure, TNewDataType> ConvertTo<TNewLengthUnitOfMeasure, TNewDurationUnitOfMeasure, TNewDataType>()
            where TNewLengthUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDurationUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => (TNewDataType)Convert.ChangeType(ValueAsDouble * LengthUnitOfMeasure.GetCompleteMultiplier<TNewLengthUnitOfMeasure>(1) / DurationUnitOfMeasure.GetCompleteMultiplier<TNewDurationUnitOfMeasure>(1), typeof(TNewDataType));

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => (TNewDataType)(Convert.ChangeType(SpeedValue, typeof(TNewDataType)));
        #endregion

        #region Casting Operators
        public static implicit operator Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(TDataType speed) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed);

        public static explicit operator TDataType(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => speed.SpeedValue;

        public static implicit operator SpeedDouble(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => new SpeedDouble(speed.ValueAsDouble, speed.LengthUnitOfMeasure, speed.DurationUnitOfMeasure);

        public static implicit operator SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure>(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed) => new SpeedDouble<TLengthUnitOfMeasure, TDurationUnitOfMeasure>(speed.ValueAsDouble);
        #endregion

        #region + Operators
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator +(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(speed1.SpeedValue, speed2.SpeedValue));

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator +(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble + (new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble;
        #endregion

        #region - Operators
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator -(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(speed1.SpeedValue, speed2.SpeedValue));

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator -(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble - (new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble;
        #endregion

        #region * Operators
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator *(TDataType speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(speed1, speed2.SpeedValue));

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, TDataType speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(speed1.SpeedValue, speed2));

        public static Length<TLengthUnitOfMeasure, TDataType> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Duration<TDurationUnitOfMeasure, TDataType> duration2)
        {
            return new Length<TLengthUnitOfMeasure, TDataType>(speed1.SpeedValue) * duration2.DurationValue;
        }

        public static Length<TLengthUnitOfMeasure, TDataType> operator *(Duration<TDurationUnitOfMeasure, TDataType> duration2, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1)
        {
            return new Length<TLengthUnitOfMeasure, TDataType>(speed1.SpeedValue) * duration2.DurationValue;
        }

        public static Length<TLengthUnitOfMeasure, double> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, DurationDouble<TDurationUnitOfMeasure> duration2)
        {
            return new Length<TLengthUnitOfMeasure, double>(speed1.ValueAsDouble * duration2.ValueAsDouble);
        }

        public static Length<TLengthUnitOfMeasure, double> operator *(DurationDouble<TDurationUnitOfMeasure> duration2, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1)
        {
            return new Length<TLengthUnitOfMeasure, double>(speed1.ValueAsDouble * duration2.ValueAsDouble);
        }

        public static Length<TLengthUnitOfMeasure, double> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, DurationDouble duration2)
        {
            return new Length<TLengthUnitOfMeasure, double>(speed1.ValueAsDouble * (new Duration<TDurationUnitOfMeasure, double>(duration2)).DurationValue);
        }

        public static Length<TLengthUnitOfMeasure, double> operator *(DurationDouble duration2, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1)
        {
            return new Length<TLengthUnitOfMeasure, double>(speed1.ValueAsDouble * (new Duration<TDurationUnitOfMeasure, double>(duration2)).DurationValue);
        }

        public static Length<TLengthUnitOfMeasure, double> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, TimeSpan duration2)
        {
            return new Length<TLengthUnitOfMeasure, double>(speed1.ValueAsDouble * (new Duration<TDurationUnitOfMeasure, double>(duration2)).DurationValue);
        }

        public static Length<TLengthUnitOfMeasure, double> operator *(TimeSpan duration2, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1)
        {
            return new Length<TLengthUnitOfMeasure, double>(speed1.ValueAsDouble * (new Duration<TDurationUnitOfMeasure, double>(duration2)).DurationValue);
        }
        #endregion

        #region / Operators
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, double speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(Convert.ToDouble((object)speed1.SpeedValue) / speed2);

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, decimal speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(Convert.ToDouble((object)speed1.SpeedValue) / Convert.ToDouble(speed2));

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, long speed2) => new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(Convert.ToDouble((object)speed1.SpeedValue) / speed2);

        public static double operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble / speed2.ValueAsDouble;
        #endregion

        #region == Operators
        public static bool operator ==(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => speed1.SpeedValue.CompareTo(speed2.SpeedValue) == 0;

        public static bool operator ==(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => speed1.SpeedValue.CompareTo(speed2.SpeedValue) != 0;

        public static bool operator !=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => speed1.SpeedValue.CompareTo(speed2.SpeedValue) > 0;

        public static bool operator >(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => speed1.SpeedValue.CompareTo(speed2.SpeedValue) < 0;

        public static bool operator <(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => speed1.SpeedValue.CompareTo(speed2.SpeedValue) >= 0;

        public static bool operator >=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2) => speed1.SpeedValue.CompareTo(speed2.SpeedValue) <= 0;

        public static bool operator <=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, SpeedDouble speed2) => speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) <= 0;
        #endregion

        #region ToString
        public override string ToString() => ToString(null, null);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            { }
            else if (format.Contains("NU"))
            {
                return LengthUnitOfMeasure.ToString(SpeedValue, format, formatProvider);
            }
            else if (format.Contains("SU"))
            {
                return LengthUnitOfMeasure.ToString(SpeedValue, "NU", formatProvider) + " " + (LengthUnitOfMeasure.GetDimensionalUnitSymbol(this) ?? DurationUnitOfMeasure.GetDimensionalUnitSymbol(this) ?? (LengthUnitOfMeasure.ToString(format, formatProvider).TrimEnd(".".ToCharArray()) + @"/" + DurationUnitOfMeasure.ToString(format, formatProvider)));
            }
            return LengthUnitOfMeasure.ToString(SpeedValue, "NU", formatProvider) + " " + LengthUnitOfMeasure.ToString(format, formatProvider) + @" per " + DurationUnitOfMeasure.ToSingularString();
        }
        #endregion

        #region Equals
        public override bool Equals(object obj) => obj != null && obj is Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(SpeedValue, o.SpeedValue);

        bool IEquatable<Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>>.Equals(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(SpeedValue, other.SpeedValue);
        #endregion

        #region GetHashCode
        public override int GetHashCode() => HashCode.Combine(SpeedValue);
        #endregion
    }
}

namespace NGenericDimensions.Extensions
{
    public static class SpeedExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? SpeedValue<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(this Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>? speed)
            where TLengthUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDurationUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => speed.HasValue ? speed.Value.SpeedValue : (TDataType?)null;
    }
}