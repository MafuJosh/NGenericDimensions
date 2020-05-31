﻿using System;
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
    public interface IVolume : IDimension
    {
        Lengths.LengthUnitOfMeasure UnitOfMeasure { get; }
    }

    public readonly struct VolumeDouble
    {
        internal readonly double ValueAsDouble;
        internal readonly Lengths.LengthUnitOfMeasure UnitOfMeasure;

        internal VolumeDouble(double valueAsDouble, Lengths.LengthUnitOfMeasure unitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            UnitOfMeasure = unitOfMeasure;
        }

        public override bool Equals(object obj) => obj != null && obj is VolumeDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.UnitOfMeasure.Equals(UnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        public static bool operator ==(VolumeDouble left, VolumeDouble right) => left.Equals(right);
        public static bool operator !=(VolumeDouble left, VolumeDouble right) => !(left == right);
    }

    public readonly struct VolumeDouble<TUnitOfMeasure>
        where TUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;

        internal VolumeDouble(double valueAsDouble)
        {
            ValueAsDouble = valueAsDouble;
        }

        public override bool Equals(object obj) => obj != null && obj is VolumeDouble<TUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        public static bool operator ==(VolumeDouble<TUnitOfMeasure> left, VolumeDouble<TUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(VolumeDouble<TUnitOfMeasure> left, VolumeDouble<TUnitOfMeasure> right) => !(left == right);
    }

    public readonly struct Volume<TUnitOfMeasure, TDataType> : IVolume, IEquatable<Volume<TUnitOfMeasure, TDataType>>
        where TUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {

        #region Constructors
        public Volume(TDataType volume)
        {
            VolumeValue = volume;
        }

        public Volume(Volume<TUnitOfMeasure, TDataType> volume)
        {
            VolumeValue = volume.VolumeValue;
        }

        public Volume(VolumeDouble volumeToConvertFrom)
        {
            VolumeValue = (TDataType)(Convert.ChangeType(volumeToConvertFrom.ValueAsDouble * (volumeToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)), typeof(TDataType)));
        }
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType VolumeValue { get; }

        private double ValueAsDouble
        {
            get { return Convert.ToDouble((object)VolumeValue); }
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
        Lengths.LengthUnitOfMeasure IVolume.UnitOfMeasure
        {
            get { return UnitOfMeasure1; }
        }
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Volume<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return (TNewDataType)(Convert.ChangeType(ValueAsDouble * (UnitOfMeasure1.GetCompleteMultiplier<TNewUnitOfMeasure>(3)), typeof(TNewDataType)));
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Volume<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return (TNewDataType)(Convert.ChangeType(VolumeValue, typeof(TNewDataType)));
        }
        #endregion

        #region Casting Operators
        public static implicit operator Volume<TUnitOfMeasure, TDataType>(TDataType volume)
        {
            return new Volume<TUnitOfMeasure, TDataType>(volume);
        }

        public static explicit operator TDataType(Volume<TUnitOfMeasure, TDataType> volume)
        {
            return volume.VolumeValue;
        }

        public static implicit operator VolumeDouble(Volume<TUnitOfMeasure, TDataType> volume)
        {
            return new VolumeDouble(volume.ValueAsDouble, volume.UnitOfMeasure);
        }

        public static implicit operator VolumeDouble<TUnitOfMeasure>(Volume<TUnitOfMeasure, TDataType> volume)
        {
            return new VolumeDouble<TUnitOfMeasure>(volume.ValueAsDouble);
        }
        #endregion

        #region + Operators
        public static Volume<TUnitOfMeasure, TDataType> operator +(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(volume1.VolumeValue, volume2.VolumeValue));
        }

        public static Volume<TUnitOfMeasure, double> operator +(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2)
        {
            return volume1.ValueAsDouble + (volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)));
        }
        #endregion

        #region - Operators
        public static Volume<TUnitOfMeasure, TDataType> operator -(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(volume1.VolumeValue, volume2.VolumeValue));
        }

        public static Volume<TUnitOfMeasure, double> operator -(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2)
        {
            return volume1.ValueAsDouble - (volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)));
        }
        #endregion

        #region * Operators
        public static Volume<TUnitOfMeasure, TDataType> operator *(TDataType volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(volume1, volume2.VolumeValue));
        }

        public static Volume<TUnitOfMeasure, TDataType> operator *(Volume<TUnitOfMeasure, TDataType> volume1, TDataType volume2)
        {
            return new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(volume1.VolumeValue, volume2));
        }
        #endregion

        #region / Operators
        public static Volume<TUnitOfMeasure, double> operator /(Volume<TUnitOfMeasure, TDataType> volume1, double volume2)
        {
            return new Volume<TUnitOfMeasure, double>(Convert.ToDouble((object)volume1.VolumeValue) / volume2);
        }

        public static Volume<TUnitOfMeasure, double> operator /(Volume<TUnitOfMeasure, TDataType> volume1, decimal volume2)
        {
            return new Volume<TUnitOfMeasure, double>(Convert.ToDouble((object)volume1.VolumeValue) / Convert.ToDouble(volume2));
        }
        
        public static Volume<TUnitOfMeasure, double> operator /(Volume<TUnitOfMeasure, TDataType> volume1, Int64 volume2)
        {
            return new Volume<TUnitOfMeasure, double>(Convert.ToDouble((object)volume1.VolumeValue) / volume2);
        }

        public static double operator /(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2)
        {
            return volume1.ValueAsDouble / (new Volume<TUnitOfMeasure, double>(volume2).VolumeValue);
        }
        #endregion

        #region == Operators
        public static bool operator ==(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) == 0;
        }

        public static bool operator ==(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) == 0;
        }
        #endregion

        #region != Operators
        public static bool operator !=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) != 0;
        }

        public static bool operator !=(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) != 0;
        }
        #endregion

        #region > Operators
        public static bool operator >(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) > 0;
        }

        public static bool operator >(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) > 0;
        }
        #endregion

        #region < Operators
        public static bool operator <(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) < 0;
        }

        public static bool operator <(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) < 0;
        }
        #endregion

        #region >= Operators
        public static bool operator >=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) >= 0;
        }

        public static bool operator >=(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) >= 0;
        }
        #endregion

        #region <= Operators
        public static bool operator <=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) <= 0;
        }

        public static bool operator <=(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) <= 0;
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
                return UnitOfMeasure.ToString(VolumeValue, format, formatProvider);
            }
            else if (format.Contains("SU"))
            {
                if (UnitOfMeasure is Length1DUnitOfMeasure length1DUom)
                {
                    return UnitOfMeasure.ToString(VolumeValue, format.Replace("SU", "NU"), formatProvider) + @" " + length1DUom.VolumeUnitSymbol;
                }
                else
                {
                    return UnitOfMeasure.ToString(VolumeValue, format, formatProvider);
                }
            }
            return VolumeValue.ToString((format ?? "").Replace("LU", ""), formatProvider) + @" Cubic " + UnitOfMeasure.ToString(format, formatProvider);
        }
        #endregion

        #region Equals
        public override bool Equals(object obj) => obj != null && obj is Volume<TUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(VolumeValue, o.VolumeValue);

        bool IEquatable<Volume<TUnitOfMeasure, TDataType>>.Equals(Volume<TUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(VolumeValue, other.VolumeValue);
        #endregion

        #region GetHashCode
        public override int GetHashCode() => HashCode.Combine(VolumeValue);
        #endregion
    }
}

namespace NGenericDimensions.Extensions
{

    public static class VolumeExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<TDataType> VolumeValue<TUnitOfMeasure, TDataType>(this Nullable<Volume<TUnitOfMeasure, TDataType>> volume)
            where TUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure, new()
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return volume.HasValue ? volume.Value.VolumeValue : (TDataType?)null;
        }

    }

}