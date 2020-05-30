using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NGenericDimensions.Lengths;

namespace NGenericDimensions
{

    public interface IArea : IDimension
    {
        Lengths.LengthUnitOfMeasure UnitOfMeasure { get; }
    }

    public interface IArea<out TUnitOfMeasure> : IArea where TUnitOfMeasure : Lengths.LengthUnitOfMeasure
    {
    }

    public struct Area<TUnitOfMeasure, TDataType> : IArea<TUnitOfMeasure>
        where TUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {

        private TDataType mArea;

        #region Constructors
        public Area(TDataType area)
        {
            mArea = area;
        }

        public Area(Area<TUnitOfMeasure, TDataType> area)
        {
            mArea = area.mArea;
        }

        public Area(IArea areaToConvertFrom)
        {
            mArea = (TDataType)(Convert.ChangeType(areaToConvertFrom.Value * (areaToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2)), typeof(TDataType)));
        }
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType AreaValue
        {
            get { return mArea; }
        }

        private double ValueAsDouble
        {
            get { return Convert.ToDouble((object)mArea); }
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

        private Lengths.LengthUnitOfMeasure UnitOfMeasure1
        {
            get { return UnitOfMeasure; }
        }
        Lengths.LengthUnitOfMeasure IArea.UnitOfMeasure
        {
            get { return UnitOfMeasure1; }
        }
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Area<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return (TNewDataType)Convert.ChangeType(ValueAsDouble * (UnitOfMeasure1.GetCompleteMultiplier<TNewUnitOfMeasure>(2)), typeof(TNewDataType));
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Area<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return (TNewDataType)Convert.ChangeType(mArea, typeof(TNewDataType));
        }
        #endregion

        #region Casting Operators
        public static implicit operator Area<TUnitOfMeasure, TDataType>(TDataType area)
        {
            return new Area<TUnitOfMeasure, TDataType>(area);
        }

        public static explicit operator TDataType(Area<TUnitOfMeasure, TDataType> area)
        {
            return area.mArea;
        }
        #endregion

        #region + Operators
        public static Area<TUnitOfMeasure, TDataType> operator +(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2)
        {
            return new Area<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(area1.mArea, area2.mArea));
        }

        public static Area<TUnitOfMeasure, double> operator +(Area<TUnitOfMeasure, TDataType> area1, IArea area2)
        {
            return area1.ValueAsDouble + (area2.Value * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2)));
        }
        #endregion

        #region - Operators
        public static Area<TUnitOfMeasure, TDataType> operator -(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2)
        {
            return new Area<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(area1.mArea, area2.mArea));
        }

        public static Area<TUnitOfMeasure, double> operator -(Area<TUnitOfMeasure, TDataType> area1, IArea area2)
        {
            return area1.ValueAsDouble - (area2.Value * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2)));
        }
        #endregion

        #region * Operators
        public static Area<TUnitOfMeasure, TDataType> operator *(TDataType area1, Area<TUnitOfMeasure, TDataType> area2)
        {
            return new Area<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(area1, area2.mArea));
        }

        public static Area<TUnitOfMeasure, TDataType> operator *(Area<TUnitOfMeasure, TDataType> area1, TDataType area2)
        {
            return new Area<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(area1.mArea, area2));
        }
        #endregion

        #region / Operators
        public static Area<TUnitOfMeasure, double> operator /(Area<TUnitOfMeasure, TDataType> area1, double area2)
        {
            return new Area<TUnitOfMeasure, double>(Convert.ToDouble((object)area1.mArea) / area2);
        }

        public static Area<TUnitOfMeasure, double> operator /(Area<TUnitOfMeasure, TDataType> area1, decimal area2)
        {
            return new Area<TUnitOfMeasure, double>(Convert.ToDouble((object)area1.mArea) / Convert.ToDouble(area2));
        }
        
        public static Area<TUnitOfMeasure, double> operator /(Area<TUnitOfMeasure, TDataType> area1, Int64 area2)
        {
            return new Area<TUnitOfMeasure, double>(Convert.ToDouble((object)area1.mArea) / area2);
        }

        public static double operator /(Area<TUnitOfMeasure, TDataType> area1, IArea area2)
        {
            return area1.ValueAsDouble / (new Area<TUnitOfMeasure, double>(area2).AreaValue);
        }
        #endregion

        #region == Operators
        public static bool operator ==(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2)
        {
            return area1.mArea.CompareTo(area2.mArea) == 0;
        }

        public static bool operator ==(Area<TUnitOfMeasure, TDataType> area1, IArea area2)
        {
            return area1.ValueAsDouble.CompareTo(area2.Value * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) == 0;
        }
        #endregion

        #region != Operators
        public static bool operator !=(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2)
        {
            return area1.mArea.CompareTo(area2.mArea) != 0;
        }

        public static bool operator !=(Area<TUnitOfMeasure, TDataType> area1, IArea area2)
        {
            return area1.ValueAsDouble.CompareTo(area2.Value * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) != 0;
        }
        #endregion

        #region > Operators
        public static bool operator >(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2)
        {
            return area1.mArea.CompareTo(area2.mArea) > 0;
        }

        public static bool operator >(Area<TUnitOfMeasure, TDataType> area1, IArea area2)
        {
            return area1.ValueAsDouble.CompareTo(area2.Value * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) > 0;
        }
        #endregion

        #region < Operators
        public static bool operator <(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2)
        {
            return area1.mArea.CompareTo(area2.mArea) < 0;
        }

        public static bool operator <(Area<TUnitOfMeasure, TDataType> area1, IArea area2)
        {
            return area1.ValueAsDouble.CompareTo(area2.Value * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) < 0;
        }
        #endregion

        #region >= Operators
        public static bool operator >=(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2)
        {
            return area1.mArea.CompareTo(area2.mArea) >= 0;
        }

        public static bool operator >=(Area<TUnitOfMeasure, TDataType> area1, IArea area2)
        {
            return area1.ValueAsDouble.CompareTo(area2.Value * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) >= 0;
        }
        #endregion

        #region <= Operators
        public static bool operator <=(Area<TUnitOfMeasure, TDataType> area1, Area<TUnitOfMeasure, TDataType> area2)
        {
            return area1.mArea.CompareTo(area2.mArea) <= 0;
        }

        public static bool operator <=(Area<TUnitOfMeasure, TDataType> area1, IArea area2)
        {
            return area1.ValueAsDouble.CompareTo(area2.Value * (area2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(2))) <= 0;
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
                return UnitOfMeasure.ToString(mArea, format, formatProvider);
            }
            else if (format.Contains("SU"))
            {
                var length1DUom = UnitOfMeasure as Length1DUnitOfMeasure;
                if (length1DUom != null)
                {
                    return UnitOfMeasure.ToString(mArea, format.Replace("SU", "NU"), formatProvider) + @" " + length1DUom.AreaUnitSymbol;
                }
                else
                {
                    return UnitOfMeasure.ToString(mArea, format, formatProvider);
                }
            }
            return mArea.ToString((format ?? "").Replace("LU", ""), formatProvider) + @" Square " + UnitOfMeasure.ToString(format, formatProvider);
        }
        #endregion

    }
}

namespace NGenericDimensions.Extensions
{

    public static class AreaExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<TDataType> AreaValue<TUnitOfMeasure, TDataType>(this Nullable<Area<TUnitOfMeasure, TDataType>> area)
            where TUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or2, IDefinedUnitOfMeasure, new()
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return area.HasValue ? area.Value.AreaValue : (TDataType?)null;
        }

    }

}