using NGenericDimensions.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions
{
    public interface IMass : IDimension, IDimensionSupportsPerExtension
    {
        Masses.MassUnitOfMeasure UnitOfMeasure { get; }
    }

    public readonly struct MassDouble : IEquatable<MassDouble>
    {
        internal readonly double ValueAsDouble;
        internal readonly Masses.MassUnitOfMeasure UnitOfMeasure;

        internal MassDouble(double valueAsDouble, Masses.MassUnitOfMeasure unitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            UnitOfMeasure = unitOfMeasure;
        }

        public override bool Equals(object? obj) => obj != null && obj is MassDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.UnitOfMeasure.Equals(UnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<MassDouble>.Equals(MassDouble other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble) && EqualityComparer<Masses.MassUnitOfMeasure>.Default.Equals(UnitOfMeasure, other.UnitOfMeasure);
        public static bool operator ==(MassDouble left, MassDouble right) => left.Equals(right);
        public static bool operator !=(MassDouble left, MassDouble right) => !(left == right);
    }

    public readonly struct MassDouble<TUnitOfMeasure> : IEquatable<MassDouble<TUnitOfMeasure>>
        where TUnitOfMeasure : Masses.MassUnitOfMeasure, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal MassDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object? obj) => obj != null && obj is MassDouble<TUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<MassDouble<TUnitOfMeasure>>.Equals(MassDouble<TUnitOfMeasure> other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble);
        public static bool operator ==(MassDouble<TUnitOfMeasure> left, MassDouble<TUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(MassDouble<TUnitOfMeasure> left, MassDouble<TUnitOfMeasure> right) => !(left == right);
    }

    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "This is not needed yet.")]
    public readonly struct Mass<TUnitOfMeasure, TDataType> : IMass, IEquatable<Mass<TUnitOfMeasure, TDataType>>
        where TUnitOfMeasure : Masses.MassUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Mass(TDataType mass) => MassValue = mass;

        public Mass(Mass<TUnitOfMeasure, TDataType> mass) => MassValue = mass.MassValue;

        public Mass(MassDouble massToConvertFrom) => MassValue = (TDataType)(Convert.ChangeType(massToConvertFrom.ValueAsDouble * massToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1), typeof(TDataType), null));
        #endregion

        #region Value

        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType MassValue { get; }
        private double ValueAsDouble => Convert.ToDouble(MassValue, null);
        double IDimension.Value => ValueAsDouble;
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TUnitOfMeasure UnitOfMeasure => UnitOfMeasureGlobals<TUnitOfMeasure>.GlobalInstance;
        Masses.MassUnitOfMeasure IMass.UnitOfMeasure => UnitOfMeasure;
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Mass<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Masses.MassUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Mass<TNewUnitOfMeasure, TNewDataType>(this);

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Mass<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Mass<TUnitOfMeasure, TNewDataType>(this);
        #endregion

        #region Casting Operators
        public static implicit operator Mass<TUnitOfMeasure, TDataType>(TDataType mass) => new Mass<TUnitOfMeasure, TDataType>(mass);

        public static explicit operator TDataType(Mass<TUnitOfMeasure, TDataType> mass) => mass.MassValue;

        public static implicit operator MassDouble(Mass<TUnitOfMeasure, TDataType> mass) => new MassDouble(mass.ValueAsDouble, mass.UnitOfMeasure);

        public static implicit operator MassDouble<TUnitOfMeasure>(Mass<TUnitOfMeasure, TDataType> mass) => new MassDouble<TUnitOfMeasure>(mass.ValueAsDouble);
        #endregion

        #region + Operators
        public static Mass<TUnitOfMeasure, TDataType> operator +(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2) => new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(mass1.MassValue, mass2.MassValue));

        public static Mass<TUnitOfMeasure, double> operator +(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble + (mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        #endregion

        #region - Operators
        public static Mass<TUnitOfMeasure, TDataType> operator -(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2) => new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(mass1.MassValue, mass2.MassValue));

        public static Mass<TUnitOfMeasure, double> operator -(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble - (mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        #endregion

        #region * Operators
        public static Mass<TUnitOfMeasure, TDataType> operator *(TDataType mass1, Mass<TUnitOfMeasure, TDataType> mass2) => new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(mass1, mass2.MassValue));

        public static Mass<TUnitOfMeasure, TDataType> operator *(Mass<TUnitOfMeasure, TDataType> mass1, TDataType mass2) => new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(mass1.MassValue, mass2));
        #endregion

        #region / Operators
        public static Mass<TUnitOfMeasure, double> operator /(Mass<TUnitOfMeasure, TDataType> mass1, double mass2) => new Mass<TUnitOfMeasure, double>(Convert.ToDouble(mass1.MassValue, null) / mass2);

        public static Mass<TUnitOfMeasure, double> operator /(Mass<TUnitOfMeasure, TDataType> mass1, decimal mass2) => new Mass<TUnitOfMeasure, double>(Convert.ToDouble(mass1.MassValue, null) / Convert.ToDouble(mass2));

        public static Mass<TUnitOfMeasure, double> operator /(Mass<TUnitOfMeasure, TDataType> mass1, long mass2) => new Mass<TUnitOfMeasure, double>(Convert.ToDouble(mass1.MassValue, null) / mass2);

        public static double operator /(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble / (new Mass<TUnitOfMeasure, double>(mass2).MassValue);
        #endregion

        #region == Operators
        public static bool operator ==(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2) => mass1.MassValue.CompareTo(mass2.MassValue) == 0;

        public static bool operator ==(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2) => mass1.MassValue.CompareTo(mass2.MassValue) != 0;

        public static bool operator !=(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2) => mass1.MassValue.CompareTo(mass2.MassValue) > 0;

        public static bool operator >(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2) => mass1.MassValue.CompareTo(mass2.MassValue) < 0;

        public static bool operator <(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2) => mass1.MassValue.CompareTo(mass2.MassValue) >= 0;

        public static bool operator >=(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2) => mass1.MassValue.CompareTo(mass2.MassValue) <= 0;

        public static bool operator <=(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) <= 0;
        #endregion

        #region ToString
        public override string ToString() => UnitOfMeasure.ToString(MassValue, null, null);

        public string ToString(string? format, IFormatProvider? formatProvider) => UnitOfMeasure.ToString(MassValue, format, formatProvider);
        #endregion

        #region Equals
        public override bool Equals(object? obj) => obj != null && obj is Mass<TUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(MassValue, o.MassValue);

        bool IEquatable<Mass<TUnitOfMeasure, TDataType>>.Equals(Mass<TUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(MassValue, other.MassValue);
        #endregion

        #region GetHashCode
        public override int GetHashCode() => HashCode.Combine(MassValue);
        #endregion

        #region IConvertible
        TypeCode IConvertible.GetTypeCode() => GenericOperatorMath<TDataType>.GetTypeCode();
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
        {
            if (typeof(IMass).IsAssignableFrom(conversionType))
            {
                var convertedInstance = Activator.CreateInstance(conversionType, (MassDouble)this);
                if (convertedInstance != null) return convertedInstance;
            }
            throw new NotImplementedException();
        }
        byte IConvertible.ToByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToByte(MassValue);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDecimal(MassValue);
        double IConvertible.ToDouble(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToDouble(MassValue);
        short IConvertible.ToInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt16(MassValue);
        int IConvertible.ToInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt32(MassValue);
        long IConvertible.ToInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToInt64(MassValue);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSByte(MassValue);
        float IConvertible.ToSingle(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToSingle(MassValue);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt16(MassValue);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt32(MassValue);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => GenericOperatorMath<TDataType>.ConvertToUInt64(MassValue);
        #endregion
    }
}

namespace NGenericDimensions.Extensions
{
    public static class MassExtensionMethods
    {
        #region Nullable LengthValue
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? MassValue<TUnitOfMeasure, TDataType>(this Mass<TUnitOfMeasure, TDataType>? mass)
            where TUnitOfMeasure : Masses.MassUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => mass.HasValue ? mass.Value.MassValue : (TDataType?)null;
        #endregion
    }
}
