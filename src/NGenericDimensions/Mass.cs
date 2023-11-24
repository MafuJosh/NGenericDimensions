using NGenericDimensions.Masses;
using NGenericDimensions.Math;
using NGenericDimensions.MetricPrefix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions
{
    public interface IMass : IDimension
    {
        MassUnitOfMeasure MassUnitOfMeasure { get; }
    }

    public readonly struct MassDouble : IEquatable<MassDouble>
    {
        internal readonly double ValueAsDouble;
        internal readonly MassUnitOfMeasure MassUnitOfMeasure;

        internal MassDouble(double valueAsDouble, MassUnitOfMeasure massUnitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            MassUnitOfMeasure = massUnitOfMeasure;
        }

        public override bool Equals(object? obj) => obj != null && obj is MassDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.MassUnitOfMeasure.Equals(MassUnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<MassDouble>.Equals(MassDouble other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble) && EqualityComparer<MassUnitOfMeasure>.Default.Equals(MassUnitOfMeasure, other.MassUnitOfMeasure);
        public static bool operator ==(MassDouble left, MassDouble right) => left.Equals(right);
        public static bool operator !=(MassDouble left, MassDouble right) => !left.Equals(right);
    }

    public readonly struct MassDouble<TMassUnitOfMeasure> : IEquatable<MassDouble<TMassUnitOfMeasure>>
        where TMassUnitOfMeasure : MassUnitOfMeasure, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;
        internal MassDouble(double valueAsDouble) => ValueAsDouble = valueAsDouble;
        public override bool Equals(object? obj) => obj != null && obj is MassDouble<TMassUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        bool IEquatable<MassDouble<TMassUnitOfMeasure>>.Equals(MassDouble<TMassUnitOfMeasure> other) => EqualityComparer<double>.Default.Equals(ValueAsDouble, other.ValueAsDouble);
        public static bool operator ==(MassDouble<TMassUnitOfMeasure> left, MassDouble<TMassUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(MassDouble<TMassUnitOfMeasure> left, MassDouble<TMassUnitOfMeasure> right) => !left.Equals(right);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TMassUnitOfMeasure MassUnitOfMeasure => UnitOfMeasureGlobals<TMassUnitOfMeasure>.GlobalInstance;
    }

    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "This is not needed yet.")]
    public readonly struct Mass<TMassUnitOfMeasure, TDataType> : IMass, IEquatable<Mass<TMassUnitOfMeasure, TDataType>>
        where TMassUnitOfMeasure : MassUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Mass(TDataType mass) => MassValue = mass;

        public Mass(Mass<TMassUnitOfMeasure, TDataType> mass) => MassValue = mass.MassValue;
        
        public Mass(MassDouble massToConvertFrom)
            => MassValue = GenericOperatorMath<TDataType>.ConvertFromDouble(
            massToConvertFrom.ValueAsDouble
            * massToConvertFrom.MassUnitOfMeasure.GetCompleteMultiplier<TMassUnitOfMeasure>(1)
            );
        
        #endregion

        #region Value
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType MassValue { get; }
        
        private double ValueAsDouble => GenericOperatorMath<TDataType>.ConvertToDouble(MassValue);
        double IDimension.Value => ValueAsDouble;
        #endregion

        #region UnitOfMeasure
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TMassUnitOfMeasure MassUnitOfMeasure => UnitOfMeasureGlobals<TMassUnitOfMeasure>.GlobalInstance;
        
        MassUnitOfMeasure IMass.MassUnitOfMeasure => MassUnitOfMeasure;
        
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Mass<TNewMassUnitOfMeasure, TNewDataType> ConvertTo<TNewMassUnitOfMeasure, TNewDataType>()
            where TNewMassUnitOfMeasure : MassUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Mass<TNewMassUnitOfMeasure, TNewDataType>(this);

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Mass<TMassUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType> => new Mass<TMassUnitOfMeasure, TNewDataType>(this);
        #endregion

        #region Casting Operators
        public static implicit operator Mass<TMassUnitOfMeasure, TDataType>(TDataType mass) => new Mass<TMassUnitOfMeasure, TDataType>(mass);

        public static explicit operator TDataType(Mass<TMassUnitOfMeasure, TDataType> mass) => mass.MassValue;

        public static implicit operator MassDouble(Mass<TMassUnitOfMeasure, TDataType> mass) => new MassDouble(mass.ValueAsDouble, mass.MassUnitOfMeasure);

        public static implicit operator MassDouble<TMassUnitOfMeasure>(Mass<TMassUnitOfMeasure, TDataType> mass) => new MassDouble<TMassUnitOfMeasure>(mass.ValueAsDouble);
        #endregion

        #region + Operators
        public static Mass<TMassUnitOfMeasure, TDataType> operator +(Mass<TMassUnitOfMeasure, TDataType> mass1, Mass<TMassUnitOfMeasure, TDataType> mass2) => new Mass<TMassUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Add(mass1.MassValue, mass2.MassValue));

        public static Mass<TMassUnitOfMeasure, double> operator +(Mass<TMassUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble + (mass2.ValueAsDouble * mass2.MassUnitOfMeasure.GetCompleteMultiplier<TMassUnitOfMeasure>(1));
        #endregion

        #region - Operators
        public static Mass<TMassUnitOfMeasure, TDataType> operator -(Mass<TMassUnitOfMeasure, TDataType> mass1, Mass<TMassUnitOfMeasure, TDataType> mass2) => new Mass<TMassUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Subtract(mass1.MassValue, mass2.MassValue));

        public static Mass<TMassUnitOfMeasure, double> operator -(Mass<TMassUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble - (mass2.ValueAsDouble * mass2.MassUnitOfMeasure.GetCompleteMultiplier<TMassUnitOfMeasure>(1));
        #endregion

        #region * Operators
        public static Mass<TMassUnitOfMeasure, TDataType> operator *(TDataType mass1, Mass<TMassUnitOfMeasure, TDataType> mass2) => new Mass<TMassUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(mass1, mass2.MassValue));

        public static Mass<TMassUnitOfMeasure, TDataType> operator *(Mass<TMassUnitOfMeasure, TDataType> mass1, TDataType mass2) => new Mass<TMassUnitOfMeasure, TDataType>(GenericOperatorMath<TDataType>.Multiply(mass1.MassValue, mass2));
        #endregion

        #region / Operators
        public static Mass<TMassUnitOfMeasure, double> operator /(Mass<TMassUnitOfMeasure, TDataType> mass1, double mass2) => new Mass<TMassUnitOfMeasure, double>(mass1.ValueAsDouble / mass2);

        public static Mass<TMassUnitOfMeasure, double> operator /(Mass<TMassUnitOfMeasure, TDataType> mass1, decimal mass2) => new Mass<TMassUnitOfMeasure, double>(mass1.ValueAsDouble / Convert.ToDouble(mass2));

        public static Mass<TMassUnitOfMeasure, double> operator /(Mass<TMassUnitOfMeasure, TDataType> mass1, long mass2) => new Mass<TMassUnitOfMeasure, double>(mass1.ValueAsDouble / mass2);

        public static double operator /(Mass<TMassUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble / (new Mass<TMassUnitOfMeasure, double>(mass2).MassValue);
        #endregion

        #region == Operators
        public static bool operator ==(Mass<TMassUnitOfMeasure, TDataType> mass1, Mass<TMassUnitOfMeasure, TDataType> mass2) => EqualityComparer<TDataType>.Default.Equals(mass1.MassValue, mass2.MassValue);

        public static bool operator ==(Mass<TMassUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.MassUnitOfMeasure.GetCompleteMultiplier<TMassUnitOfMeasure>(1)) == 0;
        #endregion

        #region != Operators
        public static bool operator !=(Mass<TMassUnitOfMeasure, TDataType> mass1, Mass<TMassUnitOfMeasure, TDataType> mass2) => !EqualityComparer<TDataType>.Default.Equals(mass1.MassValue, mass2.MassValue);

        public static bool operator !=(Mass<TMassUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.MassUnitOfMeasure.GetCompleteMultiplier<TMassUnitOfMeasure>(1)) != 0;
        #endregion

        #region > Operators
        public static bool operator >(Mass<TMassUnitOfMeasure, TDataType> mass1, Mass<TMassUnitOfMeasure, TDataType> mass2) => GenericOperatorMath<TDataType>.GreaterThan(mass1.MassValue, mass2.MassValue);

        public static bool operator >(Mass<TMassUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.MassUnitOfMeasure.GetCompleteMultiplier<TMassUnitOfMeasure>(1)) > 0;
        #endregion

        #region < Operators
        public static bool operator <(Mass<TMassUnitOfMeasure, TDataType> mass1, Mass<TMassUnitOfMeasure, TDataType> mass2) => GenericOperatorMath<TDataType>.LessThan(mass1.MassValue, mass2.MassValue);

        public static bool operator <(Mass<TMassUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.MassUnitOfMeasure.GetCompleteMultiplier<TMassUnitOfMeasure>(1)) < 0;
        #endregion

        #region >= Operators
        public static bool operator >=(Mass<TMassUnitOfMeasure, TDataType> mass1, Mass<TMassUnitOfMeasure, TDataType> mass2) => GenericOperatorMath<TDataType>.GreaterThanOrEqualTo(mass1.MassValue, mass2.MassValue);

        public static bool operator >=(Mass<TMassUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.MassUnitOfMeasure.GetCompleteMultiplier<TMassUnitOfMeasure>(1)) >= 0;
        #endregion

        #region <= Operators
        public static bool operator <=(Mass<TMassUnitOfMeasure, TDataType> mass1, Mass<TMassUnitOfMeasure, TDataType> mass2) => GenericOperatorMath<TDataType>.LessThanOrEqualTo(mass1.MassValue, mass2.MassValue);

        public static bool operator <=(Mass<TMassUnitOfMeasure, TDataType> mass1, MassDouble mass2) => mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.MassUnitOfMeasure.GetCompleteMultiplier<TMassUnitOfMeasure>(1)) <= 0;
        #endregion

        #region ToString
        public override string ToString() => MassUnitOfMeasure.ToString(MassValue, null, null);

        public string ToString(string? format, IFormatProvider? formatProvider) => MassUnitOfMeasure.ToString(MassValue, format, formatProvider);
        #endregion

        #region Equals
        public override bool Equals(object? obj) => obj != null && obj is Mass<TMassUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(MassValue, o.MassValue);

        bool IEquatable<Mass<TMassUnitOfMeasure, TDataType>>.Equals(Mass<TMassUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(MassValue, other.MassValue);
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
    public static class MassExtensionMethods
    {
        #region Nullable MassValue
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType? MassValue<TMassUnitOfMeasure, TDataType>(this Mass<TMassUnitOfMeasure, TDataType>? mass)
            where TMassUnitOfMeasure : MassUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => mass?.MassValue;
        #endregion
    }
}