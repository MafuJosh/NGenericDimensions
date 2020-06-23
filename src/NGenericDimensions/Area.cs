using NGenericDimensions.Lengths;
using NGenericDimensions.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions
{
    public interface IArea : IDimension
    {
        LengthUnitOfMeasure UnitOfMeasure { get; }
    }

    public readonly struct AreaDouble : IEquatable<AreaDouble>
    {
        internal readonly double ValueAsDouble;
        internal readonly LengthUnitOfMeasure UnitOfMeasure;

        internal AreaDouble(double valueAsDouble, LengthUnitOfMeasure unitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            UnitOfMeasure = unitOfMeasure;
        }

        public override bool Equals(object? obj) => obj != null && obj is AreaDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.UnitOfMeasure.Equals(UnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<AreaDouble>.Equals(AreaDouble other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble) && EqualityComparer<LengthUnitOfMeasure>.Default.Equals(UnitOfMeasure, other.UnitOfMeasure);
        public static bool operator ==(AreaDouble left, AreaDouble right) => left.Equals(right);
        public static bool operator !=(AreaDouble left, AreaDouble right) => !(left == right);
    }

    public readonly struct AreaDouble<TUnitOfMeasure> : IEquatable<AreaDouble<TUnitOfMeasure>>
        where TUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure
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
        where TUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Area(TDataType area) => AreaValue = area;

        public Area(Area<TUnitOfMeasure, TDataType> area) => AreaValue = area.AreaValue;

        public Area(AreaDouble areaToConvertFrom) => AreaValue = (TDataType)(Convert.ChangeType(areaToConvertFrom.ValueAsDouble * (areaToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2)), typeof(TDataType), null));
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType AreaValue { get; }

        private double ValueAsDouble => Convert.ToDouble(AreaValue, null);

        double IDimension.Value => ValueAsDouble;
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TUnitOfMeasure UnitOfMeasure => UnitOfMeasureGlobals<TUnitOfMeasure>.GlobalInstance;

        private LengthUnitOfMeasure UnitOfMeasure1 => UnitOfMeasure;
        LengthUnitOfMeasure IArea.UnitOfMeasure => UnitOfMeasure1;
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Area<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => (TNewDataType)Convert.ChangeType(ValueAsDouble * (UnitOfMeasure1.GetCompleteMultiplier<TNewUnitOfMeasure>(2)), typeof(TNewDataType), null);

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Area<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => (TNewDataType)Convert.ChangeType(AreaValue, typeof(TNewDataType), null);
        #endregion

        #region Casting Operators
        public static implicit operator Area<TUnitOfMeasure, TDataType>(TDataType area) => new Area<TUnitOfMeasure, TDataType>(area);

        public static explicit operator TDataType(Area<TUnitOfMeasure, TDataType> area) => area.AreaValue;

        public static implicit operator AreaDouble(Area<TUnitOfMeasure, TDataType> area) => new AreaDouble(area.ValueAsDouble, area.UnitOfMeasure);

        public static implicit operator AreaDouble<TUnitOfMeasure>(Area<TUnitOfMeasure, TDataType> area) => new AreaDouble<TUnitOfMeasure>(area.ValueAsDouble);
        #endregion

        #region + Operators
        public static Area<TUnitOfMeasure, TDataType> operator +(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2) => new Area<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(area1.AreaValue, area2.AreaValue));

        public static Area<TUnitOfMeasure, double> operator +(Area<TUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble + (area2.ValueAsDouble * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2)));
        #endregion

        #region - Operators
        public static Area<TUnitOfMeasure, TDataType> operator -(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2) => new Area<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(area1.AreaValue, area2.AreaValue));

        public static Area<TUnitOfMeasure, double> operator -(Area<TUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble - (area2.ValueAsDouble * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2)));
        #endregion

        #region * Operators
        public static Area<TUnitOfMeasure, TDataType> operator *(TDataType area1, Area<TUnitOfMeasure, TDataType> area2) => new Area<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(area1, area2.AreaValue));

        public static Area<TUnitOfMeasure, TDataType> operator *(Area<TUnitOfMeasure, TDataType> area1, TDataType area2) => new Area<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(area1.AreaValue, area2));
        #endregion

        #region / Operators
        public static Area<TUnitOfMeasure, double> operator /(Area<TUnitOfMeasure, TDataType> area1, double area2) => new Area<TUnitOfMeasure, double>(Convert.ToDouble(area1.AreaValue, null) / area2);

        public static Area<TUnitOfMeasure, double> operator /(Area<TUnitOfMeasure, TDataType> area1, decimal area2) => new Area<TUnitOfMeasure, double>(Convert.ToDouble(area1.AreaValue, null) / Convert.ToDouble(area2));

        public static Area<TUnitOfMeasure, double> operator /(Area<TUnitOfMeasure, TDataType> area1, long area2) => new Area<TUnitOfMeasure, double>(Convert.ToDouble(area1.AreaValue, null) / area2);

        public static double operator /(Area<TUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble / (new Area<TUnitOfMeasure, double>(area2).AreaValue);
        #endregion

        #region == Operators
        public static bool operator ==(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2) => area1.AreaValue.CompareTo(area2.AreaValue) == 0;

        public static bool operator ==(Area<TUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2) => area1.AreaValue.CompareTo(area2.AreaValue) != 0;

        public static bool operator !=(Area<TUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2) => area1.AreaValue.CompareTo(area2.AreaValue) > 0;

        public static bool operator >(Area<TUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2) => area1.AreaValue.CompareTo(area2.AreaValue) < 0;

        public static bool operator <(Area<TUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2) => area1.AreaValue.CompareTo(area2.AreaValue) >= 0;

        public static bool operator >=(Area<TUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2) => area1.AreaValue.CompareTo(area2.AreaValue) <= 0;

        public static bool operator <=(Area<TUnitOfMeasure, TDataType> area1, AreaDouble area2) => area1.ValueAsDouble.CompareTo(area2.ValueAsDouble * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) <= 0;
        #endregion

        #region ToString
        public override string ToString() => ToString(null, null);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format == null)
            { }
            else if (format.Contains("NU", StringComparison.Ordinal))
            {
                return UnitOfMeasure.ToString(AreaValue, format, formatProvider);
            }
            else if (format.Contains("SU", StringComparison.Ordinal))
            {
                if (UnitOfMeasure is Length1DUnitOfMeasure length1DUom)
                {
                    return UnitOfMeasure.ToString(AreaValue, format.Replace("SU", "NU", StringComparison.Ordinal), formatProvider) + @" " + length1DUom.AreaUnitSymbol;
                }
                else
                {
                    return UnitOfMeasure.ToString(AreaValue, format, formatProvider);
                }
            }
            return AreaValue.ToString((format ?? "").Replace("LU", "", StringComparison.Ordinal), formatProvider) + @" Square " + UnitOfMeasure.ToString(format, formatProvider);
        }
        #endregion

        #region Equals
        public override bool Equals(object? obj) => obj != null && obj is Area<TUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(AreaValue, o.AreaValue);

        bool IEquatable<Area<TUnitOfMeasure, TDataType>>.Equals(Area<TUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(AreaValue, other.AreaValue);
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

    public static class AreaExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? AreaValue<TUnitOfMeasure, TDataType>(this Area<TUnitOfMeasure, TDataType>? area)
            where TUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure, new()
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => area.HasValue ? area.Value.AreaValue : (TDataType?)null;

    }

}