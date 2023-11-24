using NGenericDimensions.Lengths;
using NGenericDimensions.Math;
using NGenericDimensions.MetricPrefix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions
{
    public interface IArea : IDimension
    {
        LengthUnitOfMeasure AreaUnitOfMeasure { get; }
    }

    public readonly struct AreaDouble : IEquatable<AreaDouble>
    {
        internal readonly double ValueAsDouble;
        internal readonly LengthUnitOfMeasure AreaUnitOfMeasure;

        internal AreaDouble(double valueAsDouble, LengthUnitOfMeasure areaUnitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            AreaUnitOfMeasure = areaUnitOfMeasure;
        }

        public override bool Equals(object? obj) => obj != null && obj is AreaDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.AreaUnitOfMeasure.Equals(AreaUnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<AreaDouble>.Equals(AreaDouble other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble) && EqualityComparer<LengthUnitOfMeasure>.Default.Equals(AreaUnitOfMeasure, other.AreaUnitOfMeasure);
        public static bool operator ==(AreaDouble left, AreaDouble right) => left.Equals(right);
        public static bool operator !=(AreaDouble left, AreaDouble right) => !left.Equals(right);
    }

    public readonly struct AreaDouble<TAreaUnitOfMeasure> : IEquatable<AreaDouble<TAreaUnitOfMeasure>>
        where TAreaUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal AreaDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object? obj) => obj != null && obj is AreaDouble<TAreaUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<AreaDouble<TAreaUnitOfMeasure>>.Equals(AreaDouble<TAreaUnitOfMeasure> other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble);
        public static bool operator ==(AreaDouble<TAreaUnitOfMeasure> left, AreaDouble<TAreaUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(AreaDouble<TAreaUnitOfMeasure> left, AreaDouble<TAreaUnitOfMeasure> right) => !left.Equals(right);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TAreaUnitOfMeasure AreaUnitOfMeasure => UnitOfMeasureGlobals<TAreaUnitOfMeasure>.GlobalInstance;
    }

    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "This is not needed yet.")]
    public readonly struct Area<TAreaUnitOfMeasure, TDataType> : IArea, IEquatable<Area<TAreaUnitOfMeasure, TDataType>>
        where TAreaUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Area(TDataType area) => AreaValue = area;

        public Area(Area<TAreaUnitOfMeasure, TDataType> area) => AreaValue = area.AreaValue;
        
        public Area(AreaDouble areaToConvertFrom)
            => AreaValue = GenericOperatorMath<TDataType>.ConvertFromDouble(
            areaToConvertFrom.ValueAsDouble
            * areaToConvertFrom.AreaUnitOfMeasure.GetCompleteMultiplier<TAreaUnitOfMeasure>(2)
            );
        
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType AreaValue { get; }
        
        private double ValueAsDouble => GenericOperatorMath<TDataType>.ConvertToDouble(AreaValue);
        double IDimension.Value => ValueAsDouble;
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TAreaUnitOfMeasure AreaUnitOfMeasure => UnitOfMeasureGlobals<TAreaUnitOfMeasure>.GlobalInstance;
        
        LengthUnitOfMeasure IArea.AreaUnitOfMeasure => AreaUnitOfMeasure;
        
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Area<TNewAreaUnitOfMeasure, TNewDataType> ConvertTo<TNewAreaUnitOfMeasure, TNewDataType>()
            where TNewAreaUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Area<TNewAreaUnitOfMeasure, TNewDataType>(this);

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Area<TAreaUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Area<TAreaUnitOfMeasure, TNewDataType>(this);
        #endregion

        #region Casting Operators
        public static implicit operator Area<TAreaUnitOfMeasure, TDataType>(TDataType area) => new Area<TAreaUnitOfMeasure, TDataType>(area);

        public static explicit operator TDataType(Area<TAreaUnitOfMeasure, TDataType> area) => area.AreaValue;

        public static implicit operator AreaDouble(Area<TAreaUnitOfMeasure, TDataType> area) => new AreaDouble(area.ValueAsDouble, area.AreaUnitOfMeasure);

        public static implicit operator AreaDouble<TAreaUnitOfMeasure>(Area<TAreaUnitOfMeasure, TDataType> area) => new AreaDouble<TAreaUnitOfMeasure>(area.ValueAsDouble);
        #endregion

        #region + Operators
        public static Area<TAreaUnitOfMeasure, TDataType> operator +(Area<TAreaUnitOfMeasure, TDataType> area1, Area<TAreaUnitOfMeasure, TDataType> area2) => new Area<TAreaUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Add(area1.AreaValue, area2.AreaValue));

        public static Area<TAreaUnitOfMeasure, double> operator +(Area<TAreaUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble + (area2.ValueAsDouble * area2.AreaUnitOfMeasure.GetCompleteMultiplier<TAreaUnitOfMeasure>(2));
        #endregion

        #region - Operators
        public static Area<TAreaUnitOfMeasure, TDataType> operator -(Area<TAreaUnitOfMeasure, TDataType> area1, Area<TAreaUnitOfMeasure, TDataType> area2) => new Area<TAreaUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Subtract(area1.AreaValue, area2.AreaValue));

        public static Area<TAreaUnitOfMeasure, double> operator -(Area<TAreaUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble - (area2.ValueAsDouble * area2.AreaUnitOfMeasure.GetCompleteMultiplier<TAreaUnitOfMeasure>(2));
        #endregion

        #region * Operators
        public static Area<TAreaUnitOfMeasure, TDataType> operator *(TDataType area1, Area<TAreaUnitOfMeasure, TDataType> area2) => new Area<TAreaUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(area1, area2.AreaValue));

        public static Area<TAreaUnitOfMeasure, TDataType> operator *(Area<TAreaUnitOfMeasure, TDataType> area1, TDataType area2) => new Area<TAreaUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(area1.AreaValue, area2));
        #endregion

        #region / Operators
        public static Area<TAreaUnitOfMeasure, double> operator /(Area<TAreaUnitOfMeasure, TDataType> area1, double area2) => new Area<TAreaUnitOfMeasure, double>(area1.ValueAsDouble / area2);

        public static Area<TAreaUnitOfMeasure, double> operator /(Area<TAreaUnitOfMeasure, TDataType> area1, decimal area2) => new Area<TAreaUnitOfMeasure, double>(area1.ValueAsDouble / Convert.ToDouble(area2));

        public static Area<TAreaUnitOfMeasure, double> operator /(Area<TAreaUnitOfMeasure, TDataType> area1, long area2) => new Area<TAreaUnitOfMeasure, double>(area1.ValueAsDouble / area2);

        public static double operator /(Area<TAreaUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble / (new Area<TAreaUnitOfMeasure, double>(area2).AreaValue);
        #endregion

        #region == Operators
        public static bool operator ==(Area<TAreaUnitOfMeasure, TDataType> area1, Area<TAreaUnitOfMeasure, TDataType> area2) => EqualityComparer<TDataType>.Default.Equals(area1.AreaValue, area2.AreaValue);

        public static bool operator ==(Area<TAreaUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * area2.AreaUnitOfMeasure.GetCompleteMultiplier<TAreaUnitOfMeasure>(2)) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Area<TAreaUnitOfMeasure, TDataType> area1, Area<TAreaUnitOfMeasure, TDataType> area2) => !EqualityComparer<TDataType>.Default.Equals(area1.AreaValue, area2.AreaValue);

        public static bool operator !=(Area<TAreaUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * area2.AreaUnitOfMeasure.GetCompleteMultiplier<TAreaUnitOfMeasure>(2)) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Area<TAreaUnitOfMeasure, TDataType> area1, Area<TAreaUnitOfMeasure, TDataType> area2) => GenericOperatorMath<TDataType>.GreaterThan(area1.AreaValue, area2.AreaValue);

        public static bool operator >(Area<TAreaUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * area2.AreaUnitOfMeasure.GetCompleteMultiplier<TAreaUnitOfMeasure>(2)) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Area<TAreaUnitOfMeasure, TDataType> area1, Area<TAreaUnitOfMeasure, TDataType> area2) => GenericOperatorMath<TDataType>.LessThan(area1.AreaValue, area2.AreaValue);

        public static bool operator <(Area<TAreaUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * area2.AreaUnitOfMeasure.GetCompleteMultiplier<TAreaUnitOfMeasure>(2)) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Area<TAreaUnitOfMeasure, TDataType> area1, Area<TAreaUnitOfMeasure, TDataType> area2) => GenericOperatorMath<TDataType>.GreaterThanOrEqualTo(area1.AreaValue, area2.AreaValue);

        public static bool operator >=(Area<TAreaUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * area2.AreaUnitOfMeasure.GetCompleteMultiplier<TAreaUnitOfMeasure>(2)) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Area<TAreaUnitOfMeasure, TDataType> area1, Area<TAreaUnitOfMeasure, TDataType> area2) => GenericOperatorMath<TDataType>.LessThanOrEqualTo(area1.AreaValue, area2.AreaValue);

        public static bool operator <=(Area<TAreaUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * area2.AreaUnitOfMeasure.GetCompleteMultiplier<TAreaUnitOfMeasure>(2)) <= 0;
        #endregion

        #region ToString
        public override string ToString() => ToString(null, null);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format == null)
            { }
            else if (format.Contains("NU", StringComparison.Ordinal))
            {
                return AreaUnitOfMeasure.ToString(AreaValue, format, formatProvider);
            }
            else if (format.Contains("SU", StringComparison.Ordinal))
            {
                if (AreaUnitOfMeasure is Length1DUnitOfMeasure length1DUom)
                {
                    return AreaUnitOfMeasure.ToString(AreaValue, format.Replace("SU", "NU", StringComparison.Ordinal), formatProvider) + @" " + length1DUom.AreaUnitSymbol;
                }
                else
                {
                    return AreaUnitOfMeasure.ToString(AreaValue, format, formatProvider);
                }
            }
            return AreaValue.ToString((format ?? "").Replace("LU", "", StringComparison.Ordinal), formatProvider) + @" Square " + AreaUnitOfMeasure.ToString(format, formatProvider);
        }
        #endregion

        #region Equals
        public override bool Equals(object? obj) => obj != null && obj is Area<TAreaUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(AreaValue, o.AreaValue);

        bool IEquatable<Area<TAreaUnitOfMeasure, TDataType>>.Equals(Area<TAreaUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(AreaValue, other.AreaValue);
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
    public static class AreaExtensionMethods
    {
        #region Nullable AreaValue
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? AreaValue<TAreaUnitOfMeasure, TDataType>(this Area<TAreaUnitOfMeasure, TDataType>? area)
            where TAreaUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => area?.AreaValue;
        #endregion
    }
}