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
        where TLengthUnitOfMeasure : Lengths.Length1DUnitOfMeasure
        where TDurationUnitOfMeasure : Durations.DurationUnitOfMeasure
        where TDataType : struct, IComparable, IConvertible
    {


        private TDataType mSpeed;
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
            mSpeed = (TDataType)(object)(speedToConvertFrom.Value * speedToConvertFrom.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1) / speedToConvertFrom.DurationUnitOfMeasure.GetCompleteMultiplier<TDurationUnitOfMeasure>(1));
        }

        public Speed(ILength<TLengthUnitOfMeasure> length, IDuration<TDurationUnitOfMeasure> duration)
        {
            mSpeed = (TDataType)(object)((new Length<TLengthUnitOfMeasure, double>(length)).LengthValue / (new Duration<TDurationUnitOfMeasure, double>(duration)).DurationValue);
        }

        public Speed(ILength<TLengthUnitOfMeasure> length, TimeSpan duration)
        {
            mSpeed = (TDataType)(object)((new Length<TLengthUnitOfMeasure, double>(length)).LengthValue / (new Duration<TDurationUnitOfMeasure, double>(duration)).DurationValue);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TDataType SpeedValue
        {
            get { return mSpeed; }
        }

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

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Speed<TNewLengthUnitOfMeasure, TNewDurationUnitOfMeasure, TNewDataType> ConvertTo<TNewLengthUnitOfMeasure, TNewDurationUnitOfMeasure, TNewDataType>()
            where TNewLengthUnitOfMeasure : Lengths.Length1DUnitOfMeasure
            where TNewDurationUnitOfMeasure : Durations.DurationUnitOfMeasure
            where TNewDataType : struct, IComparable, IConvertible
        {
            return (TNewDataType)(object)(ValueAsDouble * (new Speed<TNewLengthUnitOfMeasure, TNewDurationUnitOfMeasure, double>(1)).ValueAsDouble);
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IConvertible
        {
            return (TNewDataType)(object)mSpeed;
        }

        public static implicit operator Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(TDataType speed)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed);
        }

        public static explicit operator TDataType(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed)
        {
            return speed.mSpeed;
        }

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator +(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(speed1.mSpeed, speed2.mSpeed));
        }

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator +(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble + (new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble;
        }

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> operator -(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(speed1.mSpeed, speed2.mSpeed));
        }

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator -(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble - (new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(speed2)).ValueAsDouble;
        }

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

        public static Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double> operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, double speed2)
        {
            return new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, double>(Convert.ToDouble((object)speed1.mSpeed) / speed2);
        }

        public static double operator /(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.ValueAsDouble / speed2.ValueAsDouble;
        }

        public static bool operator ==(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) == 0;
        }

        public static bool operator ==(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) == 0;
        }

        public static bool operator !=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) != 0;
        }

        public static bool operator !=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) != 0;
        }

        public static bool operator >(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) > 0;
        }

        public static bool operator >(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) > 0;
        }

        public static bool operator <(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) < 0;
        }

        public static bool operator <(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) < 0;
        }

        public static bool operator >=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) >= 0;
        }

        public static bool operator >=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) >= 0;
        }

        public static bool operator <=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed2)
        {
            return speed1.mSpeed.CompareTo(speed2.mSpeed) <= 0;
        }

        public static bool operator <=(Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType> speed1, ISpeed speed2)
        {
            return speed1.ValueAsDouble.CompareTo((new Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(speed2)).ValueAsDouble) <= 0;
        }

        private double ValueAsDouble
        {
            get { return Convert.ToDouble((object)mSpeed); }
        }
        double IDimension.Value
        {
            get { return ValueAsDouble; }
        }

    }
}

namespace NGenericDimensions.Extensions
{

    public static class SpeedExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType SpeedValue<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>(this Nullable<Speed<TLengthUnitOfMeasure, TDurationUnitOfMeasure, TDataType>> speed)
            where TLengthUnitOfMeasure : Lengths.Length1DUnitOfMeasure
            where TDurationUnitOfMeasure : Durations.DurationUnitOfMeasure
            where TDataType : struct, IComparable, IConvertible
        {
            return speed.Value.SpeedValue;
        }

    }

}