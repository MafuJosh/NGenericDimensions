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
    public interface IVolume : IDimension
    {
        Lengths.LengthUnitOfMeasure UnitOfMeasure { get; }
    }

    public interface IVolume<out TUnitOfMeasure> : IVolume where TUnitOfMeasure : Lengths.LengthUnitOfMeasure
    {
    }

    public readonly struct Volume<TUnitOfMeasure, TDataType> : IVolume<TUnitOfMeasure>
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

        public Volume(IVolume volumeToConvertFrom)
        {
            VolumeValue = (TDataType)(Convert.ChangeType(volumeToConvertFrom.Value * (volumeToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)), typeof(TDataType)));
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
        #endregion

        #region + Operators
        public static Volume<TUnitOfMeasure, TDataType> operator +(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(volume1.VolumeValue, volume2.VolumeValue));
        }

        public static Volume<TUnitOfMeasure, double> operator +(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble + (volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)));
        }
        #endregion

        #region - Operators
        public static Volume<TUnitOfMeasure, TDataType> operator -(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(volume1.VolumeValue, volume2.VolumeValue));
        }

        public static Volume<TUnitOfMeasure, double> operator -(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble - (volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)));
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

        public static double operator /(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble / (new Volume<TUnitOfMeasure, double>(volume2).VolumeValue);
        }
        #endregion

        #region == Operators
        public static bool operator ==(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) == 0;
        }

        public static bool operator ==(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) == 0;
        }
        #endregion

        #region != Operators
        public static bool operator !=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) != 0;
        }

        public static bool operator !=(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) != 0;
        }
        #endregion

        #region > Operators
        public static bool operator >(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) > 0;
        }

        public static bool operator >(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) > 0;
        }
        #endregion

        #region < Operators
        public static bool operator <(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) < 0;
        }

        public static bool operator <(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) < 0;
        }
        #endregion

        #region >= Operators
        public static bool operator >=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) >= 0;
        }

        public static bool operator >=(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) >= 0;
        }
        #endregion

        #region <= Operators
        public static bool operator <=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.VolumeValue.CompareTo(volume2.VolumeValue) <= 0;
        }

        public static bool operator <=(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) <= 0;
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
                var length1DUom = UnitOfMeasure as Length1DUnitOfMeasure;
                if (length1DUom != null)
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