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

    public interface ILength : IDimension
    {
        Lengths.Length1DUnitOfMeasure UnitOfMeasure { get; }
    }

    public interface ILength<out TUnitOfMeasure> : ILength where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure
    {
    }

    public struct Length<TUnitOfMeasure, TDataType> : ILength<TUnitOfMeasure>
        where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure
        where TDataType : struct, IComparable, IConvertible
    {


        private TDataType mLength;
        public Length(TDataType length)
        {
            mLength = length;
        }

        public Length(Length<TUnitOfMeasure, TDataType> length)
        {
            mLength = length.mLength;
        }

        public Length(ILength lengthToConvertFrom)
        {
            mLength = (TDataType)(object)(lengthToConvertFrom.Value * lengthToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType LengthValue
        {
            get { return mLength; }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TUnitOfMeasure UnitOfMeasure
        {
            get { return UnitOfMeasureGlobals<TUnitOfMeasure>.GlobalInstance; }
        }

        private Lengths.Length1DUnitOfMeasure UnitOfMeasure1
        {
            get { return UnitOfMeasure; }
        }
        Lengths.Length1DUnitOfMeasure ILength.UnitOfMeasure
        {
            get { return UnitOfMeasure1; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Length<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Lengths.Length1DUnitOfMeasure
            where TNewDataType : struct, IComparable, IConvertible
        {
            return (TNewDataType)(object)(ValueAsDouble * UnitOfMeasure1.GetCompleteMultiplier<TNewUnitOfMeasure>(1));
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Length<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IConvertible
        {
            return (TNewDataType)(object)mLength;
        }

        public static implicit operator Length<TUnitOfMeasure, TDataType>(TDataType length)
        {
            return new Length<TUnitOfMeasure, TDataType>(length);
        }

        public static explicit operator TDataType(Length<TUnitOfMeasure, TDataType> length)
        {
            return length.mLength;
        }

        public static Length<TUnitOfMeasure, TDataType> operator +(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return new Length<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(length1.mLength, length2.mLength));
        }

        public static Length<TUnitOfMeasure, double> operator +(Length<TUnitOfMeasure, TDataType> length1, ILength length2)
        {
            return length1.ValueAsDouble + (length2.Value * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        public static Length<TUnitOfMeasure, TDataType> operator -(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return new Length<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(length1.mLength, length2.mLength));
        }

        public static Length<TUnitOfMeasure, double> operator -(Length<TUnitOfMeasure, TDataType> length1, ILength length2)
        {
            return length1.ValueAsDouble - (length2.Value * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        public static Length<TUnitOfMeasure, TDataType> operator *(TDataType length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return new Length<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(length1, length2.mLength));
        }

        public static Length<TUnitOfMeasure, TDataType> operator *(Length<TUnitOfMeasure, TDataType> length1, TDataType length2)
        {
            return new Length<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(length1.mLength, length2));
        }

        public static Area<TUnitOfMeasure, TDataType> operator *(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return Math.GenericOperatorMath<TDataType>.Multiply(length1.mLength, length2.mLength);
        }

        public static Area<TUnitOfMeasure, double> operator *(Length<TUnitOfMeasure, TDataType> length1, ILength length2)
        {
            return length1.ValueAsDouble * (length2.Value * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        public static Volume<TUnitOfMeasure, TDataType> operator *(Length<TUnitOfMeasure, TDataType> length1, Area<TUnitOfMeasure, TDataType> area2)
        {
            return Math.GenericOperatorMath<TDataType>.Multiply(length1.mLength, area2.AreaValue);
        }

        public static Volume<TUnitOfMeasure, TDataType> operator *(Area<TUnitOfMeasure, TDataType> area1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return Math.GenericOperatorMath<TDataType>.Multiply(area1.AreaValue, length2.mLength);
        }

        public static Volume<TUnitOfMeasure, double> operator *(Length<TUnitOfMeasure, TDataType> length1, IArea area2)
        {
            return length1.ValueAsDouble * (area2.Value * area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2));
        }

        public static Volume<TUnitOfMeasure, double> operator *(IArea area1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return length2.ValueAsDouble * (area1.Value * area1.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2));
        }

        public static Length<TUnitOfMeasure, double> operator /(Length<TUnitOfMeasure, TDataType> length1, double length2)
        {
            return new Length<TUnitOfMeasure, double>(Convert.ToDouble((object)length1.mLength) / length2);
        }

        public static double operator /(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return length1.ValueAsDouble / length2.ValueAsDouble;
        }

        public static Speed<TUnitOfMeasure, Durations.Days, double> operator /(Length<TUnitOfMeasure, TDataType> length1, IDuration<Durations.Days> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Days, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Hours, double> operator /(Length<TUnitOfMeasure, TDataType> length1, IDuration<Durations.Hours> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Hours, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Microseconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, IDuration<Durations.Microseconds> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Microseconds, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Milliseconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, IDuration<Durations.Milliseconds> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Milliseconds, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, IDuration<Durations.Seconds> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Minutes, double> operator /(Length<TUnitOfMeasure, TDataType> length1, IDuration<Durations.Minutes> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Minutes, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, TimeSpan duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds, double>(length1, duration2);
        }

        public static bool operator ==(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return length1.mLength.CompareTo(length2.mLength) == 0;
        }

        public static bool operator ==(Length<TUnitOfMeasure, TDataType> length1, ILength length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.Value * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) == 0;
        }

        public static bool operator !=(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return length1.mLength.CompareTo(length2.mLength) != 0;
        }

        public static bool operator !=(Length<TUnitOfMeasure, TDataType> length1, ILength length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.Value * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) != 0;
        }

        public static bool operator >(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return length1.mLength.CompareTo(length2.mLength) > 0;
        }

        public static bool operator >(Length<TUnitOfMeasure, TDataType> length1, ILength length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.Value * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) > 0;
        }

        public static bool operator <(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return length1.mLength.CompareTo(length2.mLength) < 0;
        }

        public static bool operator <(Length<TUnitOfMeasure, TDataType> length1, ILength length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.Value * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) < 0;
        }

        public static bool operator >=(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return length1.mLength.CompareTo(length2.mLength) >= 0;
        }

        public static bool operator >=(Length<TUnitOfMeasure, TDataType> length1, ILength length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.Value * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) >= 0;
        }

        public static bool operator <=(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return length1.mLength.CompareTo(length2.mLength) <= 0;
        }

        public static bool operator <=(Length<TUnitOfMeasure, TDataType> length1, ILength length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.Value * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) <= 0;
        }

        private double ValueAsDouble
        {
            get { return Convert.ToDouble((object)mLength); }
        }
        double IDimension.Value
        {
            get { return ValueAsDouble; }
        }

        public Area<TUnitOfMeasure, TDataType> squared
        {
            get { return Math.GenericOperatorMath<TDataType>.Multiply(mLength, mLength); }
        }

        public Volume<TUnitOfMeasure, TDataType> cubed
        {
            get { return Math.GenericOperatorMath<TDataType>.Multiply(Math.GenericOperatorMath<TDataType>.Multiply(mLength, mLength), mLength); }
        }

    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct LengthSquareExtension<T> where T : struct, IComparable, IConvertible
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Area;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct LengthPerExtension<TUnitOfMeasure, TDataType>
        where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure
        where TDataType : struct, IComparable, IConvertible
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Length<TUnitOfMeasure, TDataType> Length;
    }
}

namespace NGenericDimensions.Extensions
{

    public static class LengthExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType LengthValue<TUnitOfMeasure, TDataType>(this Nullable<Length<TUnitOfMeasure, TDataType>> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure
            where TDataType : struct, IComparable, IConvertible
        {
            return length.Value.LengthValue;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static LengthPerExtension<TUnitOfMeasure, TDataType> per<TUnitOfMeasure, TDataType>(this Length<TUnitOfMeasure, TDataType> length)
            where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure
            where TDataType : struct, IComparable, IConvertible
        {
            return new LengthPerExtension<TUnitOfMeasure, TDataType> { Length = length };
        }

    }
}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class LengthNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static LengthSquareExtension<T> square<T>(this T area) where T : struct, IComparable, IConvertible
        {
            return new LengthSquareExtension<T> { Area = area };
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static LengthVolumeExtension<T> cube<T>(this T volume) where T : struct, IComparable, IConvertible
        {
            return new LengthVolumeExtension<T> { Volume = volume };
        }

    }

}