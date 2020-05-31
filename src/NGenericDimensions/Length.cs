using System;
using System.Collections.Generic;
using System.ComponentModel;
using NGenericDimensions.MetricPrefix;
using NGenericDimensions.Math;
using NGenericDimensions.Lengths;

namespace NGenericDimensions
{
    // TODO: can we get rid of ILength now?  LengthDouble replaced it fully I think, without boxing.  We might still be using IDimension, etc., so maybe could get rid of ILength and implement IDimension directly

    public interface ILength : IDimension, IDimensionSupportsPerExtension
    {
        Length1DUnitOfMeasure UnitOfMeasure { get; }
    }

    public interface ILength<out TUnitOfMeasure> : ILength where TUnitOfMeasure : Lengths.Length1DUnitOfMeasure
    {
    }

    public readonly struct LengthDouble
    {
        internal readonly double ValueAsDouble;
        internal readonly Length1DUnitOfMeasure UnitOfMeasure;

        internal LengthDouble(double valueAsDouble, Length1DUnitOfMeasure unitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            UnitOfMeasure = unitOfMeasure;
        }

        public override bool Equals(object obj) => obj != null && obj is LengthDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.UnitOfMeasure.Equals(UnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        public static bool operator ==(LengthDouble left, LengthDouble right) => left.Equals(right);
        public static bool operator !=(LengthDouble left, LengthDouble right) => !(left == right);
    }

    public readonly struct LengthDouble<TUnitOfMeasure>
        where TUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;

        internal LengthDouble(double valueAsDouble)
        {
            ValueAsDouble = valueAsDouble;
        }

        public override bool Equals(object obj) => obj != null && obj is LengthDouble<TUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        public static bool operator ==(LengthDouble<TUnitOfMeasure> left, LengthDouble<TUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(LengthDouble<TUnitOfMeasure> left, LengthDouble<TUnitOfMeasure> right) => !(left == right);
    }

    public readonly struct Length<TUnitOfMeasure, TDataType> : ILength<TUnitOfMeasure>, IEquatable<Length<TUnitOfMeasure, TDataType>>
        where TUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Length(TDataType length)
        {
            LengthValue = length;
        }

        public Length(Length<TUnitOfMeasure, TDataType> length)
        {
            LengthValue = length.LengthValue;
        }

        public Length(LengthDouble lengthToConvertFrom)
        {
            LengthValue = GenericOperatorMath<TDataType>.ConvertFromDouble(lengthToConvertFrom.ValueAsDouble * lengthToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType LengthValue { get; }

        private double ValueAsDouble
        {
            get { return GenericOperatorMath<TDataType>.ConvertToDouble(LengthValue); }
        }
        double IDimension.Value
        {
            get { return ValueAsDouble; }
        }
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TUnitOfMeasure UnitOfMeasure
        {
            get { return UnitOfMeasureGlobals<TUnitOfMeasure>.GlobalInstance; }
        }

        Length1DUnitOfMeasure ILength.UnitOfMeasure
        {
            get { return UnitOfMeasure; }
        }
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Length<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return new Length<TNewUnitOfMeasure, TNewDataType>(this);
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Length<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return new Length<TUnitOfMeasure, TNewDataType>(this);
        }
        #endregion

        #region Casting Operators
        public static implicit operator Length<TUnitOfMeasure, TDataType>(TDataType length)
        {
            return new Length<TUnitOfMeasure, TDataType>(length);
        }

        public static explicit operator TDataType(Length<TUnitOfMeasure, TDataType> length)
        {
            return length.LengthValue;
        }

        public static implicit operator LengthDouble(Length<TUnitOfMeasure, TDataType> length)
        {
            return new LengthDouble(length.ValueAsDouble, length.UnitOfMeasure);
        }

        public static implicit operator LengthDouble<TUnitOfMeasure>(Length<TUnitOfMeasure, TDataType> length)
        {
            return new LengthDouble<TUnitOfMeasure>(length.ValueAsDouble);
        }
        #endregion

        #region + Operators
        public static Length<TUnitOfMeasure, TDataType> operator +(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return new Length<TUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Add(length1.LengthValue, length2.LengthValue));
        }

        public static Length<TUnitOfMeasure, double> operator +(Length<TUnitOfMeasure, TDataType> length1, LengthDouble length2)
        {
            return length1.ValueAsDouble + (length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }
        #endregion

        #region - Operators
        public static Length<TUnitOfMeasure, TDataType> operator -(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return new Length<TUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Subtract(length1.LengthValue, length2.LengthValue));
        }

        public static Length<TUnitOfMeasure, double> operator -(Length<TUnitOfMeasure, TDataType> length1, LengthDouble length2)
        {
            return length1.ValueAsDouble - (length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }
        #endregion

        #region * Operators
        public static Length<TUnitOfMeasure, TDataType> operator *(TDataType length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return new Length<TUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(length1, length2.LengthValue));
        }

        public static Length<TUnitOfMeasure, TDataType> operator *(Length<TUnitOfMeasure, TDataType> length1, TDataType length2)
        {
            return new Length<TUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(length1.LengthValue, length2));
        }

        public static Area<TUnitOfMeasure, TDataType> operator *(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return GenericOperatorMath<TDataType>.Multiply(length1.LengthValue, length2.LengthValue);
        }

        public static Area<TUnitOfMeasure, double> operator *(Length<TUnitOfMeasure, TDataType> length1, LengthDouble length2)
        {
            return length1.ValueAsDouble * (length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        public static Volume<TUnitOfMeasure, TDataType> operator *(Length<TUnitOfMeasure, TDataType> length1, Area<TUnitOfMeasure, TDataType> area2)
        {
            return GenericOperatorMath<TDataType>.Multiply(length1.LengthValue, area2.AreaValue);
        }

        public static Volume<TUnitOfMeasure, TDataType> operator *(Area<TUnitOfMeasure, TDataType> area1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return GenericOperatorMath<TDataType>.Multiply(area1.AreaValue, length2.LengthValue);
        }

        public static Volume<TUnitOfMeasure, double> operator *(Length<TUnitOfMeasure, TDataType> length1, AreaDouble area2)
        {
            return length1.ValueAsDouble * (area2.ValueAsDouble * area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2));
        }

        public static Volume<TUnitOfMeasure, double> operator *(AreaDouble area1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return length2.ValueAsDouble * (area1.ValueAsDouble * area1.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2));
        }
        #endregion

        #region / Operators
        public static Length<TUnitOfMeasure, double> operator /(Length<TUnitOfMeasure, TDataType> length1, double length2)
        {
            return new Length<TUnitOfMeasure, double>(length1.ValueAsDouble / length2);
        }

        public static Length<TUnitOfMeasure, double> operator /(Length<TUnitOfMeasure, TDataType> length1, decimal length2)
        {
            return new Length<TUnitOfMeasure, double>(length1.ValueAsDouble / Convert.ToDouble(length2));
        }
        
        public static Length<TUnitOfMeasure, double> operator /(Length<TUnitOfMeasure, TDataType> length1, Int64 length2)
        {
            return new Length<TUnitOfMeasure, double>(length1.ValueAsDouble / length2);
        }

        public static double operator /(Length<TUnitOfMeasure, TDataType> length1, LengthDouble length2)
        {
            return length1.ValueAsDouble / length2.ValueAsDouble;
        }

        public static Length<TUnitOfMeasure, double> operator /(AreaDouble area1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return new Length<TUnitOfMeasure, double>((new Area<TUnitOfMeasure, double>(area1)).AreaValue / length2.ValueAsDouble);
        }

        public static Speed<TUnitOfMeasure, Durations.Days, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Days> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Days, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Hours, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Hours> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Hours, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Microseconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Microseconds> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Microseconds, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Milliseconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Milliseconds> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Milliseconds, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Deca>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Deca>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Deca>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Hecto>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Hecto>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Hecto>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Kilo>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Kilo>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Kilo>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Mega>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Mega>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Mega>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Giga>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Giga>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Giga>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Tera>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Tera>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Tera>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Peta>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Peta>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Peta>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Exa>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Exa>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Exa>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Zetta>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Zetta>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Zetta>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Yotta>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Yotta>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Yotta>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Deci>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Deci>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Deci>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Centi>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Centi>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Centi>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Milli>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Milli>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Milli>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Micro>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Micro>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Micro>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Nano>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Nano>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Nano>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Pico>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Pico>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Pico>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Femto>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Femto>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Femto>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Atto>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Atto>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Atto>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Zepto>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Zepto>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Zepto>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds<Yocto>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Yocto>> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds<Yocto>, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Minutes, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Minutes> duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Minutes, double>(length1, duration2);
        }

        public static Speed<TUnitOfMeasure, Durations.Seconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, TimeSpan duration2)
        {
            return new Speed<TUnitOfMeasure, Durations.Seconds, double>(length1, duration2);
        }
        #endregion

        #region == Operators
        public static bool operator ==(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return EqualityComparer<TDataType>.Default.Equals(length1.LengthValue, length2.LengthValue);
        }

        public static bool operator ==(Length<TUnitOfMeasure, TDataType> length1, LengthDouble length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) == 0;
        }
        #endregion

        #region != Operators
        public static bool operator !=(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return !EqualityComparer<TDataType>.Default.Equals(length1.LengthValue, length2.LengthValue);
        }

        public static bool operator !=(Length<TUnitOfMeasure, TDataType> length1, LengthDouble length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) != 0;
        }
        #endregion

        #region > Operators
        public static bool operator >(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return GenericOperatorMath<TDataType>.GreaterThan(length1.LengthValue, length2.LengthValue);
        }

        public static bool operator >(Length<TUnitOfMeasure, TDataType> length1, LengthDouble length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) > 0;
        }
        #endregion

        #region < Operators
        public static bool operator <(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return GenericOperatorMath<TDataType>.LessThan(length1.LengthValue, length2.LengthValue);
        }

        public static bool operator <(Length<TUnitOfMeasure, TDataType> length1, LengthDouble length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) < 0;
        }
        #endregion

        #region >= Operators
        public static bool operator >=(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return GenericOperatorMath<TDataType>.GreaterThanOrEqualTo(length1.LengthValue, length2.LengthValue);
        }

        public static bool operator >=(Length<TUnitOfMeasure, TDataType> length1, LengthDouble length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) >= 0;
        }
        #endregion

        #region <= Operators
        public static bool operator <=(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2)
        {
            return GenericOperatorMath<TDataType>.LessThanOrEqualTo(length1.LengthValue, length2.LengthValue);
        }

        public static bool operator <=(Length<TUnitOfMeasure, TDataType> length1, LengthDouble length2)
        {
            return length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) <= 0;
        }
        #endregion

        #region squared, cubed
        public Area<TUnitOfMeasure, TDataType> Squared
        {
            get { return GenericOperatorMath<TDataType>.Multiply(LengthValue, LengthValue); }
        }

        public Volume<TUnitOfMeasure, TDataType> Cubed
        {
            get { return GenericOperatorMath<TDataType>.Multiply(GenericOperatorMath<TDataType>.Multiply(LengthValue, LengthValue), LengthValue); }
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return UnitOfMeasure.ToString(LengthValue, null, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return UnitOfMeasure.ToString(LengthValue, format, formatProvider);
        }
        #endregion

        public override bool Equals(object obj)
        {
            return obj != null && obj is Length<TUnitOfMeasure, TDataType> && EqualityComparer<TDataType>.Default.Equals(LengthValue, ((Length<TUnitOfMeasure, TDataType>)obj).LengthValue);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TDataType>.Default.GetHashCode(LengthValue);
        }

        bool IEquatable<Length<TUnitOfMeasure, TDataType>>.Equals(Length<TUnitOfMeasure, TDataType> other)
        {
            return EqualityComparer<TDataType>.Default.Equals(LengthValue, other.LengthValue);
        }
    }
}

namespace NGenericDimensions.Extensions
{
    public static class LengthExtensionMethods
    {
        #region Nullable LengthValue
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? LengthValue<TUnitOfMeasure, TDataType>(this Length<TUnitOfMeasure, TDataType>? length)
            where TUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return length?.LengthValue;
        }
        #endregion
    }
}
