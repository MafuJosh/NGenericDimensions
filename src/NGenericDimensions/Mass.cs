using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NGenericDimensions
{

    public interface IMass : IDimension, IDimensionSupportsPerExtension
    {
        Masses.MassUnitOfMeasure UnitOfMeasure { get; }
    }

    public interface IMass<out TUnitOfMeasure> : IMass where TUnitOfMeasure : Masses.MassUnitOfMeasure
    {
    }

    public readonly struct MassDouble
    {
        internal readonly double ValueAsDouble;
        internal readonly Masses.MassUnitOfMeasure UnitOfMeasure;

        internal MassDouble(double valueAsDouble, Masses.MassUnitOfMeasure unitOfMeasure)
        {
            ValueAsDouble = valueAsDouble;
            UnitOfMeasure = unitOfMeasure;
        }

        public override bool Equals(object obj) => obj != null && obj is MassDouble o && o.ValueAsDouble.Equals(ValueAsDouble) && o.UnitOfMeasure.Equals(UnitOfMeasure);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        public static bool operator ==(MassDouble left, MassDouble right) => left.Equals(right);
        public static bool operator !=(MassDouble left, MassDouble right) => !(left == right);
    }

    public readonly struct MassDouble<TUnitOfMeasure>
        where TUnitOfMeasure : Masses.MassUnitOfMeasure, IDefinedUnitOfMeasure
    {
        internal readonly double ValueAsDouble;

        internal MassDouble(double valueAsDouble)
        {
            ValueAsDouble = valueAsDouble;
        }

        public override bool Equals(object obj) => obj != null && obj is MassDouble<TUnitOfMeasure> o && o.ValueAsDouble.Equals(ValueAsDouble);
        public override int GetHashCode() => HashCode.Combine(ValueAsDouble);
        public static bool operator ==(MassDouble<TUnitOfMeasure> left, MassDouble<TUnitOfMeasure> right) => left.Equals(right);
        public static bool operator !=(MassDouble<TUnitOfMeasure> left, MassDouble<TUnitOfMeasure> right) => !(left == right);
    }

    public readonly struct Mass<TUnitOfMeasure, TDataType> : IMass<TUnitOfMeasure>, IEquatable<Mass<TUnitOfMeasure, TDataType>>
        where TUnitOfMeasure : Masses.MassUnitOfMeasure, IDefinedUnitOfMeasure
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        #region Constructors
        public Mass(TDataType mass)
        {
            MassValue = mass;
        }

        public Mass(Mass<TUnitOfMeasure, TDataType> mass)
        {
            MassValue = mass.MassValue;
        }

        public Mass(MassDouble massToConvertFrom)
        {
            MassValue = (TDataType)(Convert.ChangeType(massToConvertFrom.ValueAsDouble * massToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1), typeof(TDataType)));
        }
        #endregion

        #region Value

        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType MassValue { get; }

        private double ValueAsDouble
        {
            get { return Convert.ToDouble((object)MassValue); }
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

        Masses.MassUnitOfMeasure IMass.UnitOfMeasure
        {
            get { return UnitOfMeasure; }
        }
        #endregion

        #region ConvertTo
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Mass<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Masses.MassUnitOfMeasure, IDefinedUnitOfMeasure
            where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return new Mass<TNewUnitOfMeasure, TNewDataType>(this);
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Mass<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IFormattable, IComparable<TNewDataType>, IEquatable<TNewDataType>
        {
            return new Mass<TUnitOfMeasure, TNewDataType>(this);
        }
        #endregion

        #region Casting Operators
        public static implicit operator Mass<TUnitOfMeasure, TDataType>(TDataType mass)
        {
            return new Mass<TUnitOfMeasure, TDataType>(mass);
        }

        public static explicit operator TDataType(Mass<TUnitOfMeasure, TDataType> mass)
        {
            return mass.MassValue;
        }

        public static implicit operator MassDouble(Mass<TUnitOfMeasure, TDataType> mass)
        {
            return new MassDouble(mass.ValueAsDouble, mass.UnitOfMeasure);
        }

        public static implicit operator MassDouble<TUnitOfMeasure>(Mass<TUnitOfMeasure, TDataType> mass)
        {
            return new MassDouble<TUnitOfMeasure>(mass.ValueAsDouble);
        }
        #endregion

        #region + Operators
        public static Mass<TUnitOfMeasure, TDataType> operator +(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(mass1.MassValue, mass2.MassValue));
        }

        public static Mass<TUnitOfMeasure, double> operator +(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2)
        {
            return mass1.ValueAsDouble + (mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }
        #endregion

        #region - Operators
        public static Mass<TUnitOfMeasure, TDataType> operator -(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(mass1.MassValue, mass2.MassValue));
        }

        public static Mass<TUnitOfMeasure, double> operator -(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2)
        {
            return mass1.ValueAsDouble - (mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }
        #endregion

        #region * Operators
        public static Mass<TUnitOfMeasure, TDataType> operator *(TDataType mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(mass1, mass2.MassValue));
        }

        public static Mass<TUnitOfMeasure, TDataType> operator *(Mass<TUnitOfMeasure, TDataType> mass1, TDataType mass2)
        {
            return new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(mass1.MassValue, mass2));
        }
        #endregion

        #region / Operators
        public static Mass<TUnitOfMeasure, double> operator /(Mass<TUnitOfMeasure, TDataType> mass1, double mass2)
        {
            return new Mass<TUnitOfMeasure, double>(Convert.ToDouble((object)mass1.MassValue) / mass2);
        }

        public static Mass<TUnitOfMeasure, double> operator /(Mass<TUnitOfMeasure, TDataType> mass1, decimal mass2)
        {
            return new Mass<TUnitOfMeasure, double>(Convert.ToDouble((object)mass1.MassValue) / Convert.ToDouble(mass2));
        }
        
        public static Mass<TUnitOfMeasure, double> operator /(Mass<TUnitOfMeasure, TDataType> mass1, Int64 mass2)
        {
            return new Mass<TUnitOfMeasure, double>(Convert.ToDouble((object)mass1.MassValue) / mass2);
        }

        public static double operator /(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2)
        {
            return mass1.ValueAsDouble / (new Mass<TUnitOfMeasure, double>(mass2).MassValue);
        }
        #endregion

        #region == Operators
        public static bool operator ==(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.MassValue.CompareTo(mass2.MassValue) == 0;
        }

        public static bool operator ==(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) == 0;
        }
        #endregion

        #region != Operators
        public static bool operator !=(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.MassValue.CompareTo(mass2.MassValue) != 0;
        }

        public static bool operator !=(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) != 0;
        }
        #endregion

        #region > Operators
        public static bool operator >(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.MassValue.CompareTo(mass2.MassValue) > 0;
        }

        public static bool operator >(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) > 0;
        }
        #endregion

        #region < Operators
        public static bool operator <(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.MassValue.CompareTo(mass2.MassValue) < 0;
        }

        public static bool operator <(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) < 0;
        }
        #endregion

        #region >= Operators
        public static bool operator >=(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.MassValue.CompareTo(mass2.MassValue) >= 0;
        }

        public static bool operator >=(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) >= 0;
        }
        #endregion

        #region <= Operators
        public static bool operator <=(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.MassValue.CompareTo(mass2.MassValue) <= 0;
        }

        public static bool operator <=(Mass<TUnitOfMeasure, TDataType> mass1, MassDouble mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.ValueAsDouble * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) <= 0;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return UnitOfMeasure.ToString(MassValue, null, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return UnitOfMeasure.ToString(MassValue, format, formatProvider);
        }
        #endregion

        #region Equals
        public override bool Equals(object obj) => obj != null && obj is Mass<TUnitOfMeasure, TDataType> o && EqualityComparer<TDataType>.Default.Equals(MassValue, o.MassValue);

        bool IEquatable<Mass<TUnitOfMeasure, TDataType>>.Equals(Mass<TUnitOfMeasure, TDataType> other) => EqualityComparer<TDataType>.Default.Equals(MassValue, other.MassValue);
        #endregion

        #region GetHashCode
        public override int GetHashCode() => HashCode.Combine(MassValue);
        #endregion
    }
}

namespace NGenericDimensions.Extensions
{
    public static class MassExtensionMethods
    {
        #region Nullable LengthValue
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<TDataType> MassValue<TUnitOfMeasure, TDataType>(this Nullable<Mass<TUnitOfMeasure, TDataType>> mass)
            where TUnitOfMeasure : Masses.MassUnitOfMeasure, IDefinedUnitOfMeasure
            where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return mass.HasValue ? mass.Value.MassValue : (TDataType?)null;
        }
        #endregion
    }
}
