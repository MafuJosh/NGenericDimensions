using NGenericDimensions.Lengths;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions
{
    public interface IVolume : IDimension
    {
        LengthUnitOfMeasure UnitOfMeasure { get; }
    }

    public readonly struct VolumeDouble : IEquatable<VolumeDouble>
    {
        internal readonly double ValueAsDouble;
        internal readonly LengthUnitOfMeasure UnitOfMeasure;

        internal VolumeDouble(double valueAsDouble, Lengths.LengthUnitOfMeasure unitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            UnitOfMeasure = unitOfMeasure;
        }

        public override bool Equals(object? obj) => obj != null && obj is VolumeDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.UnitOfMeasure.Equals(UnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<VolumeDouble>.Equals(VolumeDouble other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble) && EqualityComparer<LengthUnitOfMeasure>.Default.Equals(UnitOfMeasure, other.UnitOfMeasure);
        public static bool operator ==(VolumeDouble left, VolumeDouble right) => left.Equals(right);
        public static bool operator !=(VolumeDouble left, VolumeDouble right) => !(left == right);
    }

    public readonly struct VolumeDouble<TUnitOfMeasure> : IEquatable<VolumeDouble<TUnitOfMeasure>>
        where TUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal VolumeDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object? obj) => obj != null && obj is VolumeDouble<TUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<VolumeDouble<TUnitOfMeasure>>.Equals(VolumeDouble<TUnitOfMeasure> other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble);
        public static bool operator ==(VolumeDouble<TUnitOfMeasure> left, VolumeDouble<TUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(VolumeDouble<TUnitOfMeasure> left, VolumeDouble<TUnitOfMeasure> right) => !(left == right);
    }

    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "This is not needed yet.")]
    public readonly struct Volume<TUnitOfMeasure, TDataType> : IVolume, IEquatable<Volume<TUnitOfMeasure, TDataType>>
        where TUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Volume(TDataType volume) => VolumeValue = volume;

        public Volume(Volume<TUnitOfMeasure, TDataType> volume) => VolumeValue = volume.VolumeValue;

        public Volume(VolumeDouble volumeToConvertFrom) => VolumeValue = (TDataType)(Convert.ChangeType(volumeToConvertFrom.ValueAsDouble * (volumeToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)), typeof(TDataType), null));
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType VolumeValue { get; }

        private double ValueAsDouble => Convert.ToDouble(VolumeValue, null);

        double IDimension.Value => ValueAsDouble;
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TUnitOfMeasure UnitOfMeasure => UnitOfMeasureGlobals<TUnitOfMeasure>.GlobalInstance;

        private LengthUnitOfMeasure UnitOfMeasure1 => UnitOfMeasure;
        LengthUnitOfMeasure IVolume.UnitOfMeasure => UnitOfMeasure1;
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Volume<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => (TNewDataType)(Convert.ChangeType(ValueAsDouble * (UnitOfMeasure1.GetCompleteMultiplier<TNewUnitOfMeasure>(3)), typeof(TNewDataType), null));

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Volume<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => (TNewDataType)(Convert.ChangeType(VolumeValue, typeof(TNewDataType), null));
        #endregion

        #region Casting Operators
        public static implicit operator Volume<TUnitOfMeasure, TDataType>(TDataType volume) => new Volume<TUnitOfMeasure, TDataType>(volume);

        public static explicit operator TDataType(Volume<TUnitOfMeasure, TDataType> volume) => volume.VolumeValue;

        public static implicit operator VolumeDouble(Volume<TUnitOfMeasure, TDataType> volume) => new VolumeDouble(volume.ValueAsDouble, volume.UnitOfMeasure);

        public static implicit operator VolumeDouble<TUnitOfMeasure>(Volume<TUnitOfMeasure, TDataType> volume) => new VolumeDouble<TUnitOfMeasure>(volume.ValueAsDouble);
        #endregion

        #region + Operators
        public static Volume<TUnitOfMeasure, TDataType> operator +(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2) => new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(volume1.VolumeValue, volume2.VolumeValue));

        public static Volume<TUnitOfMeasure, double> operator +(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble + (volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)));
        #endregion

        #region - Operators
        public static Volume<TUnitOfMeasure, TDataType> operator -(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2) => new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(volume1.VolumeValue, volume2.VolumeValue));

        public static Volume<TUnitOfMeasure, double> operator -(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble - (volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)));
        #endregion

        #region * Operators
        public static Volume<TUnitOfMeasure, TDataType> operator *(TDataType volume1, Volume<TUnitOfMeasure, TDataType> volume2) => new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(volume1, volume2.VolumeValue));

        public static Volume<TUnitOfMeasure, TDataType> operator *(Volume<TUnitOfMeasure, TDataType> volume1, TDataType volume2) => new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(volume1.VolumeValue, volume2));
        #endregion

        #region / Operators
        public static Volume<TUnitOfMeasure, double> operator /(Volume<TUnitOfMeasure, TDataType> volume1, double volume2) => new Volume<TUnitOfMeasure, double>(Convert.ToDouble(volume1.VolumeValue, null) / volume2);

        public static Volume<TUnitOfMeasure, double> operator /(Volume<TUnitOfMeasure, TDataType> volume1, decimal volume2) => new Volume<TUnitOfMeasure, double>(Convert.ToDouble(volume1.VolumeValue, null) / Convert.ToDouble(volume2));

        public static Volume<TUnitOfMeasure, double> operator /(Volume<TUnitOfMeasure, TDataType> volume1, long volume2) => new Volume<TUnitOfMeasure, double>(Convert.ToDouble(volume1.VolumeValue, null) / volume2);

        public static double operator /(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble / (new Volume<TUnitOfMeasure, double>(volume2).VolumeValue);
        #endregion

        #region == Operators
        public static bool operator ==(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2) => volume1.VolumeValue.CompareTo(volume2.VolumeValue) == 0;

        public static bool operator ==(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2) => volume1.VolumeValue.CompareTo(volume2.VolumeValue) != 0;

        public static bool operator !=(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2) => volume1.VolumeValue.CompareTo(volume2.VolumeValue) > 0;

        public static bool operator >(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2) => volume1.VolumeValue.CompareTo(volume2.VolumeValue) < 0;

        public static bool operator <(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2) => volume1.VolumeValue.CompareTo(volume2.VolumeValue) >= 0;

        public static bool operator >=(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2) => volume1.VolumeValue.CompareTo(volume2.VolumeValue) <= 0;

        public static bool operator <=(Volume<TUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) <= 0;
        #endregion

        #region ToString
        public override string ToString() => ToString(null, null);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format == null)
            { }
            else if (format.Contains("NU", StringComparison.Ordinal))
            {
                return UnitOfMeasure.ToString(VolumeValue, format, formatProvider);
            }
            else if (format.Contains("SU", StringComparison.Ordinal))
            {
                if (UnitOfMeasure is Length1DUnitOfMeasure length1DUom)
                {
                    return UnitOfMeasure.ToString(VolumeValue, format.Replace("SU", "NU", StringComparison.Ordinal), formatProvider) + @" " + length1DUom.VolumeUnitSymbol;
                }
                else
                {
                    return UnitOfMeasure.ToString(VolumeValue, format, formatProvider);
                }
            }
            return VolumeValue.ToString((format ?? "").Replace("LU", "", StringComparison.Ordinal), formatProvider) + @" Cubic " + UnitOfMeasure.ToString(format, formatProvider);
        }
        #endregion

        #region Equals
        public override bool Equals(object? obj) => obj != null && obj is Volume<TUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(VolumeValue, o.VolumeValue);

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
        public static TDataType? VolumeValue<TUnitOfMeasure, TDataType>(this Volume<TUnitOfMeasure, TDataType>? volume)
            where TUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure, new()
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => volume.HasValue ? volume.Value.VolumeValue : (TDataType?)null;
    }
}