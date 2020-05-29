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

    public interface ISpeed : IDimension
    {
        Lengths.Length1DUnitOfMeasure LengthUnitOfMeasure { get; }
        Durations.DurationUnitOfMeasure DurationUnitOfMeasure { get; }
    }

    public struct Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> : ISpeed
        where TLengthUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
        where TDurationUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {

        #region Constructors
        public Speed(TDataType speed)
        {
            mSpeed = speed;
        }

        public Speed(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed)
        {
            mSpeed = speed.SpeedValue;
        }

        public Speed(ISpeed speedToConvertFrom)
        {
            mSpeed = (TDataType)Convert.ChangeType(speedToConvertFrom.Value * speedToConvertFrom.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1) / speedToConvertFrom.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1), typeof(TDataType));
        }

        public Speed(LengthDouble<TLengthUnitOfMeasure> length, IDuration<TDurationUnitOfMeasure> duration)
        {
            mSpeed = (TDataType)Convert.ChangeType((new Length<TLengthUnitOfMeasure, double>(length.ValueAsDouble)).LengthValue / (new Duration<TDurationUnitOfMeasure, double>(duration)).DurationValue, typeof(TDataType));
        }

        public Speed(LengthDouble<TLengthUnitOfMeasure> length, TimeSpan duration)
        {
            mSpeed = (TDataType)(Convert.ChangeType((new Length<TLengthUnitOfMeasure, double>(length.ValueAsDouble)).LengthValue / (new Duration<TDurationUnitOfMeasure, double>(duration)).DurationValue, typeof(TDataType)));
        }
        #endregion

        #region Value
        private TDataType mSpeed;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDataType SpeedValue
        {
            get { return mSpeed; }
        }

        private double ValueAsDouble
        {
            get { return Convert.ToDouble((object)mSpeed); }
        }
        double IDimension.Value
        {
            get { return ValueAsDouble; }
        }
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TLengthUnitOfMeasure LengthUnitOfMeasure
        {
            get { return UnitOfMeasureGlobals<TLengthUnitOfMeasure>.GlobalInstance; }
        }

        private Lengths.Length1DUnitOfMeasure LengthUnitOfMeasure1
        {
            get { return LengthUnitOfMeasure; }
        }
        Lengths.Length1DUnitOfMeasure ISpeed.LengthUnitOfMeasure
        {
            get { return LengthUnitOfMeasure1; }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDurationUnitOfMeasure DurationUnitOfMeasure
        {
            get { return UnitOfMeasureGlobals<TDurationUnitOfMeasure>.GlobalInstance; }
        }

        private Durations.DurationUnitOfMeasure DurationUnitOfMeasure1
        {
            get { return DurationUnitOfMeasure; }
        }
        Durations.DurationUnitOfMeasure ISpeed.DurationUnitOfMeasure
        {
            get { return DurationUnitOfMeasure1; }
        }
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Speed<TNewLengthUnitOfMeasure, TNewDurationUnitOfMeasure, TNewDataType> ConvertTo<TNewLengthUnitOfMeasure, TNewDurationUnitOfMeasure, TNewDataType>()
            where TNewLengthUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDurationUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return (TNewDataType)Convert.ChangeType(ValueAsDouble * LengthUnitOfMeasure.GetCompleteMultiplier<TNewLengthUnitOfMeasure>(1) / DurationUnitOfMeasure.GetCompleteMultiplier<TNewDurationUnitOfMeasure>(1), typeof(TNewDataType));
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return (TNewDataType)(Convert.ChangeType(mSpeed, typeof(TNewDataType)));
        }
        #endregion

        #region Casting Operators
        public static implicit operator Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(TDataType speed)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed);
        }

        public static explicit operator TDataType(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed)
        {
            return speed.mSpeed;
        }
        #endregion

        #region + Operators
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator +(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(speed1.mSpeed, speed2.mSpeed));
        }

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator +(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble + (new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble;
        }
        #endregion

        #region - Operators
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator -(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(speed1.mSpeed, speed2.mSpeed));
        }

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator -(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble - (new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble;
        }
        #endregion

        #region * Operators
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator *(TDataType speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(speed1, speed2.mSpeed));
        }

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, TDataType speed2)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(speed1.mSpeed, speed2));
        }

        public static Length<TLengthUnitOfMeasure, TDataType> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Duration<TDurationUnitOfMeasure, TDataType> duration2)
        {
            return new Length<TLengthUnitOfMeasure, TDataType>(speed1.mSpeed) * duration2.DurationValue;
        }

        public static Length<TLengthUnitOfMeasure, TDataType> operator *(Duration<TDurationUnitOfMeasure, TDataType> duration2, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1)
        {
            return new Length<TLengthUnitOfMeasure, TDataType>(speed1.mSpeed) * duration2.DurationValue;
        }

        public static Length<TLengthUnitOfMeasure, double> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, IDuration<TDurationUnitOfMeasure> duration2)
        {
            return new Length<TLengthUnitOfMeasure, double>(speed1.ValueAsDouble * duration2.Value);
        }

        public static Length<TLengthUnitOfMeasure, double> operator *(IDuration<TDurationUnitOfMeasure> duration2, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1)
        {
            return new Length<TLengthUnitOfMeasure, double>(speed1.ValueAsDouble * duration2.Value);
        }

        public static Length<TLengthUnitOfMeasure, double> operator *(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, IDuration duration2)
        {
            return new Length<TLengthUnitOfMeasure, double>(speed1.ValueAsDouble * (new Duration<TDurationUnitOfMeasure, double>(duration2)).DurationValue);
        }

        public static Length<TLengthUnitOfMeasure, double> operator *(IDuration duration2, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1)
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
        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, double speed2)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(Convert.ToDouble((object)speed1.mSpeed) / speed2);
        }

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, decimal speed2)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(Convert.ToDouble((object)speed1.mSpeed) / Convert.ToDouble(speed2));
        }

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Int64 speed2)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(Convert.ToDouble((object)speed1.mSpeed) / speed2);
        }

        public static double operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble / speed2.Value;
        }
        #endregion

        #region == Operators
        public static bool operator ==(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) == 0;
        }

        public static bool operator ==(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) == 0;
        }
        #endregion

        #region != Operators
        public static bool operator !=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) != 0;
        }

        public static bool operator !=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) != 0;
        }
        #endregion

        #region > Operators
        public static bool operator >(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) > 0;
        }

        public static bool operator >(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) > 0;
        }
        #endregion

        #region < Operators
        public static bool operator <(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) < 0;
        }

        public static bool operator <(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) < 0;
        }
        #endregion

        #region >= Operators
        public static bool operator >=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) >= 0;
        }

        public static bool operator >=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) >= 0;
        }
        #endregion

        #region <= Operators
        public static bool operator <=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) <= 0;
        }

        public static bool operator <=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) <= 0;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return ToString(null, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            { }
            else if (format.Contains("NU"))
            {
                return LengthUnitOfMeasure.ToString(mSpeed, format, formatProvider);
            }
            else if (format.Contains("SU"))
            {
                return LengthUnitOfMeasure.ToString(mSpeed, "NU", formatProvider) + " " + (LengthUnitOfMeasure.GetDimensionalUnitSymbol(this) ?? DurationUnitOfMeasure.GetDimensionalUnitSymbol(this) ?? (LengthUnitOfMeasure.ToString(format, formatProvider).TrimEnd(".".ToCharArray()) + @"/" + DurationUnitOfMeasure.ToString(format, formatProvider)));
            }
            return LengthUnitOfMeasure.ToString(mSpeed, "NU", formatProvider) + " " + LengthUnitOfMeasure.ToString(format, formatProvider) + @" per " + DurationUnitOfMeasure.ToSingularString();
        }
        #endregion
    }
}

namespace NGenericDimensions.Extensions
{

    public static class SpeedExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<TDataType> SpeedValue<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(this Nullable<Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>> speed)
            where TLengthUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDurationUnitOfMeasure : Durations.DurationUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return speed.HasValue ? speed.Value.SpeedValue : (TDataType?)null;
        }

    }

}