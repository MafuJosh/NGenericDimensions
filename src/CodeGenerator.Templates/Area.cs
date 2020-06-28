/*
using NGenericDimensions.Lengths;
using NGenericDimensions.Math;
using NGenericDimensions.MetricPrefix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions
{
    public interface IArea : IDimension, IDimensionSupportsPerExtension
    {
        Length1DUnitOfMeasure UnitOfMeasure { get; }
    }

    public readonly struct AreaDouble : IEquatable<AreaDouble>
    {
        internal readonly double ValueAsDouble;
        internal readonly Length1DUnitOfMeasure UnitOfMeasure;

        internal AreaDouble(double valueAsDouble, Length1DUnitOfMeasure unitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            UnitOfMeasure = unitOfMeasure;
        }

        public override bool Equals(object? obj) => obj != null && obj is AreaDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.UnitOfMeasure.Equals(UnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<AreaDouble>.Equals(AreaDouble other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble) && EqualityComparer<Length1DUnitOfMeasure>.Default.Equals(UnitOfMeasure, other.UnitOfMeasure);
        public static bool operator ==(AreaDouble left, AreaDouble right) => left.Equals(right);
        public static bool operator !=(AreaDouble left, AreaDouble right) => !(left == right);
    }

    public readonly struct AreaDouble<TUnitOfMeasure> : IEquatable<AreaDouble<TUnitOfMeasure>>
        where TUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal AreaDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object? obj) => obj != null && obj is AreaDouble<TUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<AreaDouble<TUnitOfMeasure>>.Equals(AreaDouble<TUnitOfMeasure> other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble);
        public static bool operator ==(AreaDouble<TUnitOfMeasure> left, AreaDouble<TUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(AreaDouble<TUnitOfMeasure> left, AreaDouble<TUnitOfMeasure> right) => !(left == right);
    }

    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "This is not needed yet.")]
    public readonly struct Area<TUnitOfMeasure, TDataType> : IArea, IEquatable<Area<TUnitOfMeasure, TDataType>>
        where TUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Area(TDataType length) => AreaValue = length;

        public Area(Area<TUnitOfMeasure, TDataType> length) => AreaValue = length.AreaValue;
        
        public Area(AreaDouble lengthToConvertFrom) => AreaValue = GenericOperatorMath<TDataType>.ConvertFromDouble(lengthToConvertFrom.ValueAsDouble * lengthToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType AreaValue { get; }

        private double ValueAsDouble => GenericOperatorMath<TDataType>.ConvertToDouble(AreaValue);
        double IDimension.Value => ValueAsDouble;
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TUnitOfMeasure UnitOfMeasure => UnitOfMeasureGlobals<TUnitOfMeasure>.GlobalInstance;

        Length1DUnitOfMeasure IArea.UnitOfMeasure => UnitOfMeasure;
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Length<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Lengths.Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Length<TNewUnitOfMeasure, TNewDataType>(this);

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Length<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Length<TUnitOfMeasure, TNewDataType>(this);
        #endregion

        #region Casting Operators
        public static implicit operator Length<TUnitOfMeasure, TDataType>(TDataType length) => new Length<TUnitOfMeasure, TDataType>(length);

        public static explicit operator TDataType(Length<TUnitOfMeasure, TDataType> length) => length.AreaValue;

        public static implicit operator AreaDouble(Length<TUnitOfMeasure, TDataType> length) => new AreaDouble(length.ValueAsDouble, length.UnitOfMeasure);

        public static implicit operator AreaDouble<TUnitOfMeasure>(Length<TUnitOfMeasure, TDataType> length) => new AreaDouble<TUnitOfMeasure>(length.ValueAsDouble);
        #endregion

        #region + Operators
        public static Length<TUnitOfMeasure, TDataType> operator +(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2) => new Length<TUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Add(length1.AreaValue, length2.AreaValue));

        public static Length<TUnitOfMeasure, double> operator +(Length<TUnitOfMeasure, TDataType> length1, AreaDouble length2) => length1.ValueAsDouble + (length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        #endregion

        #region - Operators
        public static Length<TUnitOfMeasure, TDataType> operator -(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2) => new Length<TUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Subtract(length1.AreaValue, length2.AreaValue));

        public static Length<TUnitOfMeasure, double> operator -(Length<TUnitOfMeasure, TDataType> length1, AreaDouble length2) => length1.ValueAsDouble - (length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        #endregion

        #region * Operators
        public static Length<TUnitOfMeasure, TDataType> operator *(TDataType length1, Length<TUnitOfMeasure, TDataType> length2) => new Length<TUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(length1, length2.AreaValue));

        public static Length<TUnitOfMeasure, TDataType> operator *(Length<TUnitOfMeasure, TDataType> length1, TDataType length2) => new Length<TUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(length1.AreaValue, length2));

        public static Area<TUnitOfMeasure, TDataType> operator *(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.Multiply(length1.AreaValue, length2.AreaValue);

        public static Area<TUnitOfMeasure, double> operator *(Length<TUnitOfMeasure, TDataType> length1, AreaDouble length2) => length1.ValueAsDouble * (length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));

        public static Volume<TUnitOfMeasure, TDataType> operator *(Length<TUnitOfMeasure, TDataType> length1, Area<TUnitOfMeasure, TDataType> area2) => GenericOperatorMath<TDataType>.Multiply(length1.AreaValue, area2.AreaValue);

        public static Volume<TUnitOfMeasure, TDataType> operator *(Area<TUnitOfMeasure, TDataType> area1, Length<TUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.Multiply(area1.AreaValue, length2.AreaValue);

        public static Volume<TUnitOfMeasure, double> operator *(Length<TUnitOfMeasure, TDataType> length1, AreaDouble area2) => length1.ValueAsDouble * (area2.ValueAsDouble * area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2));

        public static Volume<TUnitOfMeasure, double> operator *(AreaDouble area1, Length<TUnitOfMeasure, TDataType> length2) => length2.ValueAsDouble * (area1.ValueAsDouble * area1.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2));
        #endregion

        #region / Operators
        public static Length<TUnitOfMeasure, double> operator /(Length<TUnitOfMeasure, TDataType> length1, double length2) => new Length<TUnitOfMeasure, double>(length1.ValueAsDouble / length2);

        public static Length<TUnitOfMeasure, double> operator /(Length<TUnitOfMeasure, TDataType> length1, decimal length2) => new Length<TUnitOfMeasure, double>(length1.ValueAsDouble / Convert.ToDouble(length2));

        public static Length<TUnitOfMeasure, double> operator /(Length<TUnitOfMeasure, TDataType> length1, long length2) => new Length<TUnitOfMeasure, double>(length1.ValueAsDouble / length2);

        public static double operator /(Length<TUnitOfMeasure, TDataType> length1, AreaDouble length2) => length1.ValueAsDouble / length2.ValueAsDouble;

        public static Length<TUnitOfMeasure, double> operator /(AreaDouble area1, Length<TUnitOfMeasure, TDataType> length2) => new Length<TUnitOfMeasure, double>((new Area<TUnitOfMeasure, double>(area1)).AreaValue / length2.ValueAsDouble);

        public static Speed<TUnitOfMeasure, Durations.Days, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Days> duration2) => new Speed<TUnitOfMeasure, Durations.Days, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Hours, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Hours> duration2) => new Speed<TUnitOfMeasure, Durations.Hours, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Microseconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Microseconds> duration2) => new Speed<TUnitOfMeasure, Durations.Microseconds, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Milliseconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Milliseconds> duration2) => new Speed<TUnitOfMeasure, Durations.Milliseconds, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Deca>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Deca>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Deca>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Hecto>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Hecto>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Hecto>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Kilo>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Kilo>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Kilo>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Mega>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Mega>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Mega>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Giga>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Giga>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Giga>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Tera>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Tera>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Tera>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Peta>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Peta>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Peta>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Exa>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Exa>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Exa>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Zetta>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Zetta>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Zetta>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Yotta>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Yotta>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Yotta>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Deci>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Deci>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Deci>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Centi>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Centi>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Centi>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Milli>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Milli>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Milli>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Micro>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Micro>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Micro>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Nano>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Nano>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Nano>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Pico>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Pico>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Pico>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Femto>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Femto>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Femto>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Atto>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Atto>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Atto>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Zepto>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Zepto>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Zepto>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds<Yocto>, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Seconds<Yocto>> duration2) => new Speed<TUnitOfMeasure, Durations.Seconds<Yocto>, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Minutes, double> operator /(Length<TUnitOfMeasure, TDataType> length1, DurationDouble<Durations.Minutes> duration2) => new Speed<TUnitOfMeasure, Durations.Minutes, double>(length1, duration2);

        public static Speed<TUnitOfMeasure, Durations.Seconds, double> operator /(Length<TUnitOfMeasure, TDataType> length1, TimeSpan duration2) => new Speed<TUnitOfMeasure, Durations.Seconds, double>(length1, duration2);
        #endregion

        #region == Operators
        public static bool operator ==(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2) => EqualityComparer<TDataType>.Default.Equals(length1.AreaValue, length2.AreaValue);

        public static bool operator ==(Length<TUnitOfMeasure, TDataType> length1, AreaDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2) => !EqualityComparer<TDataType>.Default.Equals(length1.AreaValue, length2.AreaValue);

        public static bool operator !=(Length<TUnitOfMeasure, TDataType> length1, AreaDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.GreaterThan(length1.AreaValue, length2.AreaValue);

        public static bool operator >(Length<TUnitOfMeasure, TDataType> length1, AreaDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.LessThan(length1.AreaValue, length2.AreaValue);

        public static bool operator <(Length<TUnitOfMeasure, TDataType> length1, AreaDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.GreaterThanOrEqualTo(length1.AreaValue, length2.AreaValue);

        public static bool operator >=(Length<TUnitOfMeasure, TDataType> length1, AreaDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Length<TUnitOfMeasure, TDataType> length1, Length<TUnitOfMeasure, TDataType> length2) => GenericOperatorMath<TDataType>.LessThanOrEqualTo(length1.AreaValue, length2.AreaValue);

        public static bool operator <=(Length<TUnitOfMeasure, TDataType> length1, AreaDouble length2) => length1.ValueAsDouble.CompareTo(length2.ValueAsDouble * length2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) <= 0;
        #endregion

        #region squared, cubed
        public Area<TUnitOfMeasure, TDataType> Squared => GenericOperatorMath<TDataType>.Multiply(AreaValue, AreaValue);

        public Volume<TUnitOfMeasure, TDataType> Cubed => GenericOperatorMath<TDataType>.Multiply(GenericOperatorMath<TDataType>.Multiply(AreaValue, AreaValue), AreaValue);
        #endregion

        #region ToString
        public override string ToString() => UnitOfMeasure.ToString(AreaValue, null, null);

        public string ToString(string? format, IFormatProvider? formatProvider) => UnitOfMeasure.ToString(AreaValue, format, formatProvider);
        #endregion

        #region Equals
        public override bool Equals(object? obj) => obj != null && obj is Length<TUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(AreaValue, o.AreaValue);

        bool IEquatable<Length<TUnitOfMeasure, TDataType>>.Equals(Length<TUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(AreaValue, other.AreaValue);
        #endregion

        #region GetHashCode
        public override int GetHashCode() => HashCode.Combine(AreaValue);
        #endregion

        #region IConvertible
        TypeCode IConvertible.GetTypeCode() => GenericOperatorMath<TDataType>.GetTypeCode();
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
        {
            if (typeof(IArea).IsAssignableFrom(conversionType))
            {
                var convertedInstance = Activator.CreateInstance(conversionType, (AreaDouble)this);
                if (convertedInstance != null) return convertedInstance;
            }
            throw new NotImplementedException();
        }
        byte IConvertible.ToByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToByte(AreaValue);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDecimal(AreaValue);
        double IConvertible.ToDouble(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDouble(AreaValue);
        short IConvertible.ToInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt16(AreaValue);
        int IConvertible.ToInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt32(AreaValue);
        long IConvertible.ToInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt64(AreaValue);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSByte(AreaValue);
        float IConvertible.ToSingle(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSingle(AreaValue);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt16(AreaValue);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt32(AreaValue);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt64(AreaValue);
        #endregion
    }
}

namespace NGenericDimensions.Extensions
{
    public static class LengthExtensionMethods
    {
        #region Nullable AreaValue
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? AreaValue<TUnitOfMeasure, TDataType>(this Length<TUnitOfMeasure, TDataType>? length)
            where TUnitOfMeasure : Length1DUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => length?.AreaValue;
        #endregion
    }
}
*/
