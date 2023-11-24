using NGenericDimensions.Lengths;
using NGenericDimensions.Math;
using NGenericDimensions.MetricPrefix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions
{
    public interface ILength : IDimension, IDimensionSupportsPerExtension
    {
        Length1DUnitOfMeasure LengthUnitOfMeasure { get; }
    }

    public readonly struct LengthDouble : IEquatable<LengthDouble>
    {
        internal readonly double ValueAsDouble;
        internal readonly Length1DUnitOfMeasure LengthUnitOfMeasure;

        internal LengthDouble(double valueAsDouble, Length1DUnitOfMeasure lengthUnitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            LengthUnitOfMeasure = lengthUnitOfMeasure;
        }

        public override bool Equals(object? obj) => obj != null && obj is LengthDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.LengthUnitOfMeasure.Equals(LengthUnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<LengthDouble>.Equals(LengthDouble other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble) && EqualityComparer<Length1DUnitOfMeasure>.Default.Equals(LengthUnitOfMeasure, other.LengthUnitOfMeasure);
        public static bool operator ==(LengthDouble left, LengthDouble right) => left.Equals(right);
        public static bool operator !=(LengthDouble left, LengthDouble right) => !left.Equals(right);
    }

    public readonly struct LengthDouble<TLengthUnitOfMeasure> : IEquatable<LengthDouble<TLengthUnitOfMeasure>>
        where TLengthUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal LengthDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object? obj) => obj != null && obj is LengthDouble<TLengthUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<LengthDouble<TLengthUnitOfMeasure>>.Equals(LengthDouble<TLengthUnitOfMeasure> other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble);
        public static bool operator ==(LengthDouble<TLengthUnitOfMeasure> left, LengthDouble<TLengthUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(LengthDouble<TLengthUnitOfMeasure> left, LengthDouble<TLengthUnitOfMeasure> right) => !left.Equals(right);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TLengthUnitOfMeasure LengthUnitOfMeasure => UnitOfMeasureGlobals<TLengthUnitOfMeasure>.GlobalInstance;
    }

    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "This is not needed yet.")]
    public readonly struct Length<TLengthUnitOfMeasure, TDataType> : ILength, IEquatable<Length<TLengthUnitOfMeasure, TDataType>>
        where TLengthUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Length(TDataType length) => LengthValue = length;

        public Length(Length<TLengthUnitOfMeasure, TDataType> length) => LengthValue = length.LengthValue;
        
        public Length(LengthDouble lengthToConvertFrom)
            => LengthValue = GenericOperatorMath<TDataType>.ConvertFromDouble(
            lengthToConvertFrom.ValueAsDouble
            * lengthToConvertFrom.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1)
            );
        
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType LengthValue { get; }
        
        private double ValueAsDouble => GenericOperatorMath<TDataType>.ConvertToDouble(LengthValue);
        double IDimension.Value => ValueAsDouble;
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TLengthUnitOfMeasure LengthUnitOfMeasure => UnitOfMeasureGlobals<TLengthUnitOfMeasure>.GlobalInstance;
        
        Length1DUnitOfMeasure ILength.LengthUnitOfMeasure => LengthUnitOfMeasure;
        
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Length<TNewLengthUnitOfMeasure, TNewDataType> ConvertTo<TNewLengthUnitOfMeasure, TNewDataType>()
            where TNewLengthUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Length<TNewLengthUnitOfMeasure, TNewDataType>(this);

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Length<TLengthUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Length<TLengthUnitOfMeasure, TNewDataType>(this);
        #endregion

        #region Casting Operators
        public static implicit operator Length<TLengthUnitOfMeasure, TDataType>(TDataType length) => new Length<TLengthUnitOfMeasure, TDataType>(length);

        public static explicit operator TDataType(Length<TLengthUnitOfMeasure, TDataType> length) => length.LengthValue;

        public static implicit operator LengthDouble(Length<TLengthUnitOfMeasure, TDataType> length) => new LengthDouble(length.ValueAsDouble, length.LengthUnitOfMeasure);

        public static implicit operator LengthDouble<TLengthUnitOfMeasure>(Length<TLengthUnitOfMeasure, TDataType> length) => new LengthDouble<TLengthUnitOfMeasure>(length.ValueAsDouble);
        #endregion

        #region + Operators
        public static Length<TLengthUnitOfMeasure, TDataType> operator +(Length<TLengthUnitOfMeasure, TDataType> length1, Length<TLengthUnitOfMeasure, TDataType> length2) => new Length<TLengthUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Add(length1.LengthValue, length2.LengthValue));

        public static Length<TLengthUnitOfMeasure, double> operator +(Length<TLengthUnitOfMeasure, TDataType> length1, LengthDouble length2) => length1.ValueAsDouble + (length2.ValueAsDouble * length2.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1));
        #endregion

        #region - Operators
        public static Length<TLengthUnitOfMeasure, TDataType> operator -(Length<TLengthUnitOfMeasure, TDataType> length1, Length<TLengthUnitOfMeasure, TDataType> length2) => new Length<TLengthUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Subtract(length1.LengthValue, length2.LengthValue));

        public static Length<TLengthUnitOfMeasure, double> operator -(Length<TLengthUnitOfMeasure, TDataType> length1, LengthDouble length2) => length1.ValueAsDouble - (length2.ValueAsDouble * length2.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1));
        #endregion

        #region * Operators
        public static Length<TLengthUnitOfMeasure, TDataType> operator *(TDataType length1, Length<TLengthUnitOfMeasure, TDataType> length2) => new Length<TLengthUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(length1, length2.LengthValue));

        public static Length<TLengthUnitOfMeasure, TDataType> operator *(Length<TLengthUnitOfMeasure, TDataType> length1, TDataType length2) => new Length<TLengthUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(length1.LengthValue, length2));

        public static Area<TLengthUnitOfMeasure, TDataType> operator *(Length<TLengthUnitOfMeasure, TDataType> length1, Length<TLengthUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.Multiply(length1.LengthValue, length2.LengthValue);

        public static Area<TLengthUnitOfMeasure, double> operator *(Length<TLengthUnitOfMeasure, TDataType> length1, LengthDouble length2) => length1.ValueAsDouble * (length2.ValueAsDouble * length2.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1));

        public static Volume<TLengthUnitOfMeasure, TDataType> operator *(Length<TLengthUnitOfMeasure, TDataType> length1, Area<TLengthUnitOfMeasure, TDataType> area2) => GenericOperatorMath<TDataType>.Multiply(length1.LengthValue, area2.AreaValue);

        public static Volume<TLengthUnitOfMeasure, TDataType> operator *(Area<TLengthUnitOfMeasure, TDataType> area1, Length<TLengthUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.Multiply(area1.AreaValue, length2.LengthValue);

        public static Volume<TLengthUnitOfMeasure, double> operator *(Length<TLengthUnitOfMeasure, TDataType> length1, AreaDouble area2) => length1.ValueAsDouble * (area2.ValueAsDouble * area2.AreaUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(2));

        public static Volume<TLengthUnitOfMeasure, double> operator *(AreaDouble area1, Length<TLengthUnitOfMeasure, TDataType> length2) => length2.ValueAsDouble * (area1.ValueAsDouble * area1.AreaUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(2));
        #endregion

        #region / Operators
        public static Length<TLengthUnitOfMeasure, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, double length2) => new Length<TLengthUnitOfMeasure, double>(length1.ValueAsDouble / length2);

        public static Length<TLengthUnitOfMeasure, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, decimal length2) => new Length<TLengthUnitOfMeasure, double>(length1.ValueAsDouble / Convert.ToDouble(length2));

        public static Length<TLengthUnitOfMeasure, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, long length2) => new Length<TLengthUnitOfMeasure, double>(length1.ValueAsDouble / length2);

        public static double operator /(Length<TLengthUnitOfMeasure, TDataType> length1, LengthDouble length2) => length1.ValueAsDouble / (new Length<TLengthUnitOfMeasure, double>(length2).LengthValue);

        public static Length<TLengthUnitOfMeasure, double> operator /(AreaDouble area1, Length<TLengthUnitOfMeasure, TDataType> length2) => new Length<TLengthUnitOfMeasure, double>((new Area<TLengthUnitOfMeasure, double>(area1)).AreaValue / length2.ValueAsDouble);

        public static Speed<TLengthUnitOfMeasure, Durations.Days, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Days> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Days, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Hours, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Hours> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Hours, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Microseconds, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Microseconds> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Microseconds, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Milliseconds, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Milliseconds> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Milliseconds, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Minutes, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Minutes> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Minutes, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Deca>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Deca>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Deca>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Hecto>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Hecto>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Hecto>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Kilo>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Kilo>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Kilo>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Mega>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Mega>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Mega>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Giga>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Giga>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Giga>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Tera>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Tera>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Tera>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Peta>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Peta>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Peta>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Exa>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Exa>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Exa>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Zetta>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Zetta>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Zetta>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Yotta>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Yotta>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Yotta>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Deci>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Deci>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Deci>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Centi>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Centi>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Centi>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Milli>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Milli>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Milli>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Micro>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Micro>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Micro>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Nano>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Nano>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Nano>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Pico>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Pico>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Pico>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Femto>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Femto>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Femto>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Atto>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Atto>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Atto>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Zepto>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Zepto>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Zepto>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds<Yocto>, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Yocto>> duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds<Yocto>, double>(length1, duration2);

        public static Speed<TLengthUnitOfMeasure, Durations.Seconds, double> operator /(Length<TLengthUnitOfMeasure, TDataType> length1, TimeSpan duration2) => new Speed<TLengthUnitOfMeasure, Durations.Seconds, double>(length1, duration2);
        #endregion

        #region == Operators
        public static bool operator ==(Length<TLengthUnitOfMeasure, TDataType> length1, Length<TLengthUnitOfMeasure, TDataType> length2) => EqualityComparer<TDataType>.Default.Equals(length1.LengthValue, length2.LengthValue);

        public static bool operator ==(Length<TLengthUnitOfMeasure, TDataType> length1, LengthDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1)) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Length<TLengthUnitOfMeasure, TDataType> length1, Length<TLengthUnitOfMeasure, TDataType> length2) => !EqualityComparer<TDataType>.Default.Equals(length1.LengthValue, length2.LengthValue);

        public static bool operator !=(Length<TLengthUnitOfMeasure, TDataType> length1, LengthDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1)) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Length<TLengthUnitOfMeasure, TDataType> length1, Length<TLengthUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.GreaterThan(length1.LengthValue, length2.LengthValue);

        public static bool operator >(Length<TLengthUnitOfMeasure, TDataType> length1, LengthDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1)) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Length<TLengthUnitOfMeasure, TDataType> length1, Length<TLengthUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.LessThan(length1.LengthValue, length2.LengthValue);

        public static bool operator <(Length<TLengthUnitOfMeasure, TDataType> length1, LengthDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1)) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Length<TLengthUnitOfMeasure, TDataType> length1, Length<TLengthUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.GreaterThanOrEqualTo(length1.LengthValue, length2.LengthValue);

        public static bool operator >=(Length<TLengthUnitOfMeasure, TDataType> length1, LengthDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1)) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Length<TLengthUnitOfMeasure, TDataType> length1, Length<TLengthUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.LessThanOrEqualTo(length1.LengthValue, length2.LengthValue);

        public static bool operator <=(Length<TLengthUnitOfMeasure, TDataType> length1, LengthDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.LengthUnitOfMeasure.GetCompleteMultiplier<TLengthUnitOfMeasure>(1)) <= 0;
        #endregion

        #region squared, cubed
        public Area<TLengthUnitOfMeasure, TDataType> Squared => GenericOperatorMath<TDataType>.Multiply(LengthValue, LengthValue);

        public Volume<TLengthUnitOfMeasure, TDataType> Cubed => GenericOperatorMath<TDataType>.Multiply(GenericOperatorMath<TDataType>.Multiply(LengthValue, LengthValue), LengthValue);
        #endregion

        #region ToString
        public override string ToString() => LengthUnitOfMeasure.ToString(LengthValue, null, null);

        public string ToString(string? format, IFormatProvider? formatProvider) => LengthUnitOfMeasure.ToString(LengthValue, format, formatProvider);
        #endregion

        #region Equals
        public override bool Equals(object? obj) => obj != null && obj is Length<TLengthUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(LengthValue, o.LengthValue);

        bool IEquatable<Length<TLengthUnitOfMeasure, TDataType>>.Equals(Length<TLengthUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(LengthValue, other.LengthValue);
        #endregion

        #region GetHashCode
        public override int GetHashCode() => HashCode.Combine(LengthValue);
        #endregion

        #region IConvertible
        TypeCode IConvertible.GetTypeCode() => GenericOperatorMath<TDataType>.GetTypeCode();
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
        {
            if (typeof(ILength).IsAssignableFrom(conversionType))
            {
                var convertedInstance = Activator.CreateInstance(conversionType, (LengthDouble)this);
                if (convertedInstance != null) return convertedInstance;
            }
            throw new NotImplementedException();
        }
        byte IConvertible.ToByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToByte(LengthValue);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDecimal(LengthValue);
        double IConvertible.ToDouble(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDouble(LengthValue);
        short IConvertible.ToInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt16(LengthValue);
        int IConvertible.ToInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt32(LengthValue);
        long IConvertible.ToInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt64(LengthValue);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSByte(LengthValue);
        float IConvertible.ToSingle(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSingle(LengthValue);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt16(LengthValue);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt32(LengthValue);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt64(LengthValue);
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
    public static class LengthExtensionMethods
    {
        #region Nullable LengthValue
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? LengthValue<TLengthUnitOfMeasure, TDataType>(this Length<TLengthUnitOfMeasure, TDataType>? length)
            where TLengthUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => length?.LengthValue;
        #endregion
    }
}