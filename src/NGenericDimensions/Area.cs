using NGenericDimensions.Lengths;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NGenericDimensions
{
    public interface IArea : IDimension
    {
        LengthUnitOfMeasure UnitOfMeasure { get; }
    }

    public readonly struct AreaDouble
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
        public static bool operator ==(AreaDouble left, AreaDouble right) => left.Equals(right);
        public static bool operator !=(AreaDouble left, AreaDouble right) => !(left == right);
    }

    public readonly struct AreaDouble<TUnitOfMeasure>
        where TUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal AreaDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object? obj) => obj != null && obj is AreaDouble<TUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        public static bool operator ==(AreaDouble<TUnitOfMeasure> left, AreaDouble<TUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(AreaDouble<TUnitOfMeasure> left, AreaDouble<TUnitOfMeasure> right) => !(left == right);
    }

    public readonly struct Area<TUnitOfMeasure, TDataType> : IArea, IEquatable<Area<TUnitOfMeasure, TDataType>>
        where TUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Area(TDataType area) => AreaValue = area;

        public Area(Area<TUnitOfMeasure, TDataType> area) => AreaValue = area.AreaValue;

        public Area(AreaDouble areaToConvertFrom) => AreaValue = (TDataType)(Convert.ChangeType(areaToConvertFrom.ValueAsDouble * (areaToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2)), typeof(TDataType)));
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType AreaValue { get; }

        private double ValueAsDouble => Convert.ToDouble((object)AreaValue);

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
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => (TNewDataType)Convert.ChangeType(ValueAsDouble * (UnitOfMeasure1.GetCompleteMultiplier<TNewUnitOfMeasure>(2)), typeof(TNewDataType));

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Area<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => (TNewDataType)Convert.ChangeType(AreaValue, typeof(TNewDataType));
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
        public static Area<TUnitOfMeasure, double> operator /(Area<TUnitOfMeasure, TDataType> area1, double area2) => new Area<TUnitOfMeasure, double>(Convert.ToDouble((object)area1.AreaValue) / area2);

        public static Area<TUnitOfMeasure, double> operator /(Area<TUnitOfMeasure, TDataType> area1, decimal area2) => new Area<TUnitOfMeasure, double>(Convert.ToDouble((object)area1.AreaValue) / Convert.ToDouble(area2));

        public static Area<TUnitOfMeasure, double> operator /(Area<TUnitOfMeasure, TDataType> area1, long area2) => new Area<TUnitOfMeasure, double>(Convert.ToDouble((object)area1.AreaValue) / area2);

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
            else if (format.Contains("NU"))
            {
                return UnitOfMeasure.ToString(AreaValue, format, formatProvider);
            }
            else if (format.Contains("SU"))
            {
                if (UnitOfMeasure is Length1DUnitOfMeasure length1DUom)
                {
                    return UnitOfMeasure.ToString(AreaValue, format.Replace("SU", "NU"), formatProvider) + @" " + length1DUom.AreaUnitSymbol;
                }
                else
                {
                    return UnitOfMeasure.ToString(AreaValue, format, formatProvider);
                }
            }
            return AreaValue.ToString((format ?? "").Replace("LU", ""), formatProvider) + @" Square " + UnitOfMeasure.ToString(format, formatProvider);
        }
        #endregion

        #region Equals
        public override bool Equals(object? obj) => obj != null && obj is Area<TUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(AreaValue, o.AreaValue);

        bool IEquatable<Area<TUnitOfMeasure, TDataType>>.Equals(Area<TUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(AreaValue, other.AreaValue);
        #endregion

        #region GetHashCode
        public override int GetHashCode() => HashCode.Combine(AreaValue);
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