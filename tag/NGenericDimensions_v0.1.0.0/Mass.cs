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

    public interface IMass : IDimension
    {
        Masses.MassUnitOfMeasure UnitOfMeasure { get; }
    }

    public interface IMass<out TUnitOfMeasure> : IMass where TUnitOfMeasure : Masses.MassUnitOfMeasure
    {
    }

    public struct Mass<TUnitOfMeasure, TDataType> : IMass<TUnitOfMeasure>
        where TUnitOfMeasure : Masses.MassUnitOfMeasure
        where TDataType : struct, IComparable, IConvertible
    {


        private TDataType mMass;
        public Mass(TDataType mass)
        {
            mMass = mass;
        }

        public Mass(Mass<TUnitOfMeasure, TDataType> mass)
        {
            mMass = mass.mMass;
        }

        public Mass(IMass massToConvertFrom)
        {
            mMass = (TDataType)(object)(massToConvertFrom.Value * massToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType MassValue
        {
            get { return mMass; }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TUnitOfMeasure UnitOfMeasure
        {
            get { return UnitOfMeasureGlobals<TUnitOfMeasure>.GlobalInstance; }
        }

        private Masses.MassUnitOfMeasure UnitOfMeasure1
        {
            get { return UnitOfMeasure; }
        }
        Masses.MassUnitOfMeasure IMass.UnitOfMeasure
        {
            get { return UnitOfMeasure1; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Mass<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Masses.MassUnitOfMeasure
            where TNewDataType : struct, IComparable, IConvertible
        {
            return (TNewDataType)(object)(ValueAsDouble * UnitOfMeasure1.GetCompleteMultiplier<TNewUnitOfMeasure>(1));
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Mass<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IConvertible
        {
            return (TNewDataType)(object)mMass;
        }

        public static implicit operator Mass<TUnitOfMeasure, TDataType>(TDataType mass)
        {
            return new Mass<TUnitOfMeasure, TDataType>(mass);
        }

        public static explicit operator TDataType(Mass<TUnitOfMeasure, TDataType> mass)
        {
            return mass.mMass;
        }

        public static Mass<TUnitOfMeasure, TDataType> operator +(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(mass1.mMass, mass2.mMass));
        }

        public static Mass<TUnitOfMeasure, double> operator +(Mass<TUnitOfMeasure, TDataType> mass1, IMass mass2)
        {
            return mass1.ValueAsDouble + (mass2.Value * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        public static Mass<TUnitOfMeasure, TDataType> operator -(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(mass1.mMass, mass2.mMass));
        }

        public static Mass<TUnitOfMeasure, double> operator -(Mass<TUnitOfMeasure, TDataType> mass1, IMass mass2)
        {
            return mass1.ValueAsDouble - (mass2.Value * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1));
        }

        public static Mass<TUnitOfMeasure, TDataType> operator *(TDataType mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(mass1, mass2.mMass));
        }

        public static Mass<TUnitOfMeasure, TDataType> operator *(Mass<TUnitOfMeasure, TDataType> mass1, TDataType mass2)
        {
            return new Mass<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(mass1.mMass, mass2));
        }

        public static Mass<TUnitOfMeasure, double> operator /(Mass<TUnitOfMeasure, TDataType> mass1, double mass2)
        {
            return new Mass<TUnitOfMeasure, double>(Convert.ToDouble((object)mass1.mMass) / mass2);
        }

        public static double operator /(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.ValueAsDouble / mass2.ValueAsDouble;
        }

        public static bool operator ==(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.mMass.CompareTo(mass2.mMass) == 0;
        }

        public static bool operator ==(Mass<TUnitOfMeasure, TDataType> mass1, IMass mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.Value * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) == 0;
        }

        public static bool operator !=(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.mMass.CompareTo(mass2.mMass) != 0;
        }

        public static bool operator !=(Mass<TUnitOfMeasure, TDataType> mass1, IMass mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.Value * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) != 0;
        }

        public static bool operator >(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.mMass.CompareTo(mass2.mMass) > 0;
        }

        public static bool operator >(Mass<TUnitOfMeasure, TDataType> mass1, IMass mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.Value * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) > 0;
        }

        public static bool operator <(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.mMass.CompareTo(mass2.mMass) < 0;
        }

        public static bool operator <(Mass<TUnitOfMeasure, TDataType> mass1, IMass mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.Value * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) < 0;
        }

        public static bool operator >=(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.mMass.CompareTo(mass2.mMass) >= 0;
        }

        public static bool operator >=(Mass<TUnitOfMeasure, TDataType> mass1, IMass mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.Value * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) >= 0;
        }

        public static bool operator <=(Mass<TUnitOfMeasure, TDataType> mass1, Mass<TUnitOfMeasure, TDataType> mass2)
        {
            return mass1.mMass.CompareTo(mass2.mMass) <= 0;
        }

        public static bool operator <=(Mass<TUnitOfMeasure, TDataType> mass1, IMass mass2)
        {
            return mass1.ValueAsDouble.CompareTo(mass2.Value * mass2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(1)) <= 0;
        }

        private double ValueAsDouble
        {
            get { return Convert.ToDouble((object)mMass); }
        }
        double IDimension.Value
        {
            get { return ValueAsDouble; }
        }

    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct MassPerExtension<TUnitOfMeasure, TDataType>
        where TUnitOfMeasure : Masses.MassUnitOfMeasure
        where TDataType : struct, IComparable, IConvertible
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Mass<TUnitOfMeasure, TDataType> Mass;
    }
}

namespace NGenericDimensions.Extensions
{

    public static class MassExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType MassValue<TUnitOfMeasure, TDataType>(this Nullable<Mass<TUnitOfMeasure, TDataType>> mass)
            where TUnitOfMeasure : Masses.MassUnitOfMeasure
            where TDataType : struct, IComparable, IConvertible
        {
            return mass.Value.MassValue;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static MassPerExtension<TUnitOfMeasure, TDataType> per<TUnitOfMeasure, TDataType>(this Mass<TUnitOfMeasure, TDataType> mass)
            where TUnitOfMeasure : Masses.MassUnitOfMeasure
            where TDataType : struct, IComparable, IConvertible
        {
            return new MassPerExtension<TUnitOfMeasure, TDataType> { Mass = mass };
        }

    }

}
