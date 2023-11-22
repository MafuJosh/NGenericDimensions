using NGenericDimensions.Lengths;
using NGenericDimensions.Math;
using NGenericDimensions.MetricPrefix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions
{
    public interface IVolume : IDimension
    {
        LengthUnitOfMeasure VolumeUnitOfMeasure { get; }
    }

    public readonly struct VolumeDouble : IEquatable<VolumeDouble>
    {
        internal readonly double ValueAsDouble;
        internal readonly LengthUnitOfMeasure VolumeUnitOfMeasure;

        internal VolumeDouble(double valueAsDouble, LengthUnitOfMeasure volumeUnitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            VolumeUnitOfMeasure = volumeUnitOfMeasure;
        }

        public override bool Equals(object? obj) => obj != null && obj is VolumeDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.VolumeUnitOfMeasure.Equals(VolumeUnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<VolumeDouble>.Equals(VolumeDouble other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble) && EqualityComparer<LengthUnitOfMeasure>.Default.Equals(VolumeUnitOfMeasure, other.VolumeUnitOfMeasure);
        public static bool operator ==(VolumeDouble left, VolumeDouble right) => left.Equals(right);
        public static bool operator !=(VolumeDouble left, VolumeDouble right) => !left.Equals(right);
    }

    public readonly struct VolumeDouble<TVolumeUnitOfMeasure> : IEquatable<VolumeDouble<TVolumeUnitOfMeasure>>
        where TVolumeUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal VolumeDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object? obj) => obj != null && obj is VolumeDouble<TVolumeUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<VolumeDouble<TVolumeUnitOfMeasure>>.Equals(VolumeDouble<TVolumeUnitOfMeasure> other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble);
        public static bool operator ==(VolumeDouble<TVolumeUnitOfMeasure> left, VolumeDouble<TVolumeUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(VolumeDouble<TVolumeUnitOfMeasure> left, VolumeDouble<TVolumeUnitOfMeasure> right) => !left.Equals(right);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TVolumeUnitOfMeasure VolumeUnitOfMeasure => UnitOfMeasureGlobals<TVolumeUnitOfMeasure>.GlobalInstance;
    }

    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "This is not needed yet.")]
    public readonly struct Volume<TVolumeUnitOfMeasure, TDataType> : IVolume, IEquatable<Volume<TVolumeUnitOfMeasure, TDataType>>
        where TVolumeUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Volume(TDataType volume) => VolumeValue = volume;

        public Volume(Volume<TVolumeUnitOfMeasure, TDataType> volume) => VolumeValue = volume.VolumeValue;
        
        public Volume(VolumeDouble volumeToConvertFrom)
            => VolumeValue = GenericOperatorMath<TDataType>.ConvertFromDouble(
            volumeToConvertFrom.ValueAsDouble
            * volumeToConvertFrom.VolumeUnitOfMeasure.GetCompleteMultiplier<TVolumeUnitOfMeasure>(3)
            );
        
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType VolumeValue { get; }
        
        private double ValueAsDouble => GenericOperatorMath<TDataType>.ConvertToDouble(VolumeValue);
        double IDimension.Value => ValueAsDouble;
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TVolumeUnitOfMeasure VolumeUnitOfMeasure => UnitOfMeasureGlobals<TVolumeUnitOfMeasure>.GlobalInstance;
        
        LengthUnitOfMeasure IVolume.VolumeUnitOfMeasure => VolumeUnitOfMeasure;
        
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Volume<TNewVolumeUnitOfMeasure, TNewDataType> ConvertTo<TNewVolumeUnitOfMeasure, TNewDataType>()
            where TNewVolumeUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Volume<TNewVolumeUnitOfMeasure, TNewDataType>(this);

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Volume<TVolumeUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Volume<TVolumeUnitOfMeasure, TNewDataType>(this);
        #endregion

        #region Casting Operators
        public static implicit operator Volume<TVolumeUnitOfMeasure, TDataType>(TDataType volume) => new Volume<TVolumeUnitOfMeasure, TDataType>(volume);

        public static explicit operator TDataType(Volume<TVolumeUnitOfMeasure, TDataType> volume) => volume.VolumeValue;

        public static implicit operator VolumeDouble(Volume<TVolumeUnitOfMeasure, TDataType> volume) => new VolumeDouble(volume.ValueAsDouble, volume.VolumeUnitOfMeasure);

        public static implicit operator VolumeDouble<TVolumeUnitOfMeasure>(Volume<TVolumeUnitOfMeasure, TDataType> volume) => new VolumeDouble<TVolumeUnitOfMeasure>(volume.ValueAsDouble);
        #endregion

        #region + Operators
        public static Volume<TVolumeUnitOfMeasure, TDataType> operator +(Volume<TVolumeUnitOfMeasure, TDataType> volume1, Volume<TVolumeUnitOfMeasure, TDataType> volume2) => new Volume<TVolumeUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Add(volume1.VolumeValue, volume2.VolumeValue));

        public static Volume<TVolumeUnitOfMeasure, double> operator +(Volume<TVolumeUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble + (volume2.ValueAsDouble * volume2.VolumeUnitOfMeasure.GetCompleteMultiplier<TVolumeUnitOfMeasure>(3));
        #endregion

        #region - Operators
        public static Volume<TVolumeUnitOfMeasure, TDataType> operator -(Volume<TVolumeUnitOfMeasure, TDataType> volume1, Volume<TVolumeUnitOfMeasure, TDataType> volume2) => new Volume<TVolumeUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Subtract(volume1.VolumeValue, volume2.VolumeValue));

        public static Volume<TVolumeUnitOfMeasure, double> operator -(Volume<TVolumeUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble - (volume2.ValueAsDouble * volume2.VolumeUnitOfMeasure.GetCompleteMultiplier<TVolumeUnitOfMeasure>(3));
        #endregion

        #region * Operators
        public static Volume<TVolumeUnitOfMeasure, TDataType> operator *(TDataType volume1, Volume<TVolumeUnitOfMeasure, TDataType> volume2) => new Volume<TVolumeUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(volume1, volume2.VolumeValue));

        public static Volume<TVolumeUnitOfMeasure, TDataType> operator *(Volume<TVolumeUnitOfMeasure, TDataType> volume1, TDataType volume2) => new Volume<TVolumeUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(volume1.VolumeValue, volume2));
        #endregion

        #region / Operators
        public static Volume<TVolumeUnitOfMeasure, double> operator /(Volume<TVolumeUnitOfMeasure, TDataType> volume1, double volume2) => new Volume<TVolumeUnitOfMeasure, double>(volume1.ValueAsDouble / volume2);

        public static Volume<TVolumeUnitOfMeasure, double> operator /(Volume<TVolumeUnitOfMeasure, TDataType> volume1, decimal volume2) => new Volume<TVolumeUnitOfMeasure, double>(volume1.ValueAsDouble / Convert.ToDouble(volume2));

        public static Volume<TVolumeUnitOfMeasure, double> operator /(Volume<TVolumeUnitOfMeasure, TDataType> volume1, long volume2) => new Volume<TVolumeUnitOfMeasure, double>(volume1.ValueAsDouble / volume2);

        public static double operator /(Volume<TVolumeUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble / (new Volume<TVolumeUnitOfMeasure, double>(volume2).VolumeValue);
        #endregion

        #region == Operators
        public static bool operator ==(Volume<TVolumeUnitOfMeasure, TDataType> volume1, Volume<TVolumeUnitOfMeasure, TDataType> volume2) => EqualityComparer<TDataType>.Default.Equals(volume1.VolumeValue, volume2.VolumeValue);

        public static bool operator ==(Volume<TVolumeUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * volume2.VolumeUnitOfMeasure.GetCompleteMultiplier<TVolumeUnitOfMeasure>(3)) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Volume<TVolumeUnitOfMeasure, TDataType> volume1, Volume<TVolumeUnitOfMeasure, TDataType> volume2) => !EqualityComparer<TDataType>.Default.Equals(volume1.VolumeValue, volume2.VolumeValue);

        public static bool operator !=(Volume<TVolumeUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * volume2.VolumeUnitOfMeasure.GetCompleteMultiplier<TVolumeUnitOfMeasure>(3)) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Volume<TVolumeUnitOfMeasure, TDataType> volume1, Volume<TVolumeUnitOfMeasure, TDataType> volume2) => GenericOperatorMath<TDataType>.GreaterThan(volume1.VolumeValue, volume2.VolumeValue);

        public static bool operator >(Volume<TVolumeUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * volume2.VolumeUnitOfMeasure.GetCompleteMultiplier<TVolumeUnitOfMeasure>(3)) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Volume<TVolumeUnitOfMeasure, TDataType> volume1, Volume<TVolumeUnitOfMeasure, TDataType> volume2) => GenericOperatorMath<TDataType>.LessThan(volume1.VolumeValue, volume2.VolumeValue);

        public static bool operator <(Volume<TVolumeUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * volume2.VolumeUnitOfMeasure.GetCompleteMultiplier<TVolumeUnitOfMeasure>(3)) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Volume<TVolumeUnitOfMeasure, TDataType> volume1, Volume<TVolumeUnitOfMeasure, TDataType> volume2) => GenericOperatorMath<TDataType>.GreaterThanOrEqualTo(volume1.VolumeValue, volume2.VolumeValue);

        public static bool operator >=(Volume<TVolumeUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * volume2.VolumeUnitOfMeasure.GetCompleteMultiplier<TVolumeUnitOfMeasure>(3)) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Volume<TVolumeUnitOfMeasure, TDataType> volume1, Volume<TVolumeUnitOfMeasure, TDataType> volume2) => GenericOperatorMath<TDataType>.LessThanOrEqualTo(volume1.VolumeValue, volume2.VolumeValue);

        public static bool operator <=(Volume<TVolumeUnitOfMeasure, TDataType> volume1, VolumeDouble volume2) => volume1.ValueAsDouble.CompareTo(volume2.ValueAsDouble * volume2.VolumeUnitOfMeasure.GetCompleteMultiplier<TVolumeUnitOfMeasure>(3)) <= 0;
        #endregion

        #region ToString
        public override string ToString() => ToString(null, null);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format == null)
            { }
            else if (format.Contains("NU", StringComparison.Ordinal))
            {
                return VolumeUnitOfMeasure.ToString(VolumeValue, format, formatProvider);
            }
            else if (format.Contains("SU", StringComparison.Ordinal))
            {
                if (VolumeUnitOfMeasure is Length1DUnitOfMeasure length1DUom)
                {
                    return VolumeUnitOfMeasure.ToString(VolumeValue, format.Replace("SU", "NU", StringComparison.Ordinal), formatProvider) + @" " + length1DUom.VolumeUnitSymbol;
                }
                else
                {
                    return VolumeUnitOfMeasure.ToString(VolumeValue, format, formatProvider);
                }
            }
            return VolumeValue.ToString((format ?? "").Replace("LU", "", StringComparison.Ordinal), formatProvider) + @" Cubic " + VolumeUnitOfMeasure.ToString(format, formatProvider);
        }
        #endregion

        #region Equals
        public override bool Equals(object? obj) => obj != null && obj is Volume<TVolumeUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(VolumeValue, o.VolumeValue);

        bool IEquatable<Volume<TVolumeUnitOfMeasure, TDataType>>.Equals(Volume<TVolumeUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(VolumeValue, other.VolumeValue);
        #endregion

        #region GetHashCode
        public override int GetHashCode() => HashCode.Combine(VolumeValue);
        #endregion

        #region IConvertible
        TypeCode IConvertible.GetTypeCode() => GenericOperatorMath<TDataType>.GetTypeCode();
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
        {
            if (typeof(IVolume).IsAssignableFrom(conversionType))
            {
                var convertedInstance = Activator.CreateInstance(conversionType, (VolumeDouble)this);
                if (convertedInstance != null) return convertedInstance;
            }
            throw new NotImplementedException();
        }
        byte IConvertible.ToByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToByte(VolumeValue);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDecimal(VolumeValue);
        double IConvertible.ToDouble(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDouble(VolumeValue);
        short IConvertible.ToInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt16(VolumeValue);
        int IConvertible.ToInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt32(VolumeValue);
        long IConvertible.ToInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt64(VolumeValue);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSByte(VolumeValue);
        float IConvertible.ToSingle(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSingle(VolumeValue);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt16(VolumeValue);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt32(VolumeValue);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt64(VolumeValue);
        #endregion
    }
}

namespace NGenericDimensions.Extensions
{
    public static class VolumeExtensionMethods
    {
        #region Nullable VolumeValue
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? VolumeValue<TVolumeUnitOfMeasure, TDataType>(this Volume<TVolumeUnitOfMeasure, TDataType>? volume)
            where TVolumeUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or3, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => volume?.VolumeValue;
        #endregion
    }
}