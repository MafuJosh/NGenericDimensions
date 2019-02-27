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
    public interface IVolume : IDimension
    {
        Lengths.LengthUnitOfMeasure UnitOfMeasure { get; }
    }

    public interface IVolume<out TUnitOfMeasure> : IVolume where TUnitOfMeasure : Lengths.LengthUnitOfMeasure
    {
    }

    public struct Volume<TUnitOfMeasure, TDataType> : IVolume<TUnitOfMeasure>
        where TUnitOfMeasure : Lengths.LengthUnitOfMeasure
        where TDataType : struct, IComparable, IConvertible
    {


        private TDataType mVolume;
        public Volume(TDataType volume)
        {
            mVolume = volume;
        }

        public Volume(Volume<TUnitOfMeasure, TDataType> volume)
        {
            mVolume = volume.mVolume;
        }

        public Volume(IVolume volumeToConvertFrom)
        {
            mVolume = (TDataType)(object)(volumeToConvertFrom.Value * (volumeToConvertFrom.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)));
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public TDataType VolumeValue
        {
            get { return mVolume; }
        }

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

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Volume<TNewUnitOfMeasure, TNewDataType> ConvertTo<TNewUnitOfMeasure, TNewDataType>()
            where TNewUnitOfMeasure : Lengths.LengthUnitOfMeasure
            where TNewDataType : struct, IComparable, IConvertible
        {
            return (TNewDataType)(object)(ValueAsDouble * (UnitOfMeasure1.GetCompleteMultiplier<TNewUnitOfMeasure>(3)));
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public Volume<TUnitOfMeasure, TNewDataType> ConvertTo<TNewDataType>() where TNewDataType : struct, IComparable, IConvertible
        {
            return (TNewDataType)(object)mVolume;
        }

        public static implicit operator Volume<TUnitOfMeasure, TDataType>(TDataType volume)
        {
            return new Volume<TUnitOfMeasure, TDataType>(volume);
        }

        public static explicit operator TDataType(Volume<TUnitOfMeasure, TDataType> volume)
        {
            return volume.mVolume;
        }

        public static Volume<TUnitOfMeasure, TDataType> operator +(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Add(volume1.mVolume, volume2.mVolume));
        }

        public static Volume<TUnitOfMeasure, double> operator +(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble + (volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)));
        }

        public static Volume<TUnitOfMeasure, TDataType> operator -(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Subtract(volume1.mVolume, volume2.mVolume));
        }

        public static Volume<TUnitOfMeasure, double> operator -(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble - (volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3)));
        }

        public static Volume<TUnitOfMeasure, TDataType> operator *(TDataType volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(volume1, volume2.mVolume));
        }

        public static Volume<TUnitOfMeasure, TDataType> operator *(Volume<TUnitOfMeasure, TDataType> volume1, TDataType volume2)
        {
            return new Volume<TUnitOfMeasure, TDataType>(Math.GenericOperatorMath<TDataType>.Multiply(volume1.mVolume, volume2));
        }

        public static Volume<TUnitOfMeasure, double> operator /(Volume<TUnitOfMeasure, TDataType> volume1, double volume2)
        {
            return new Volume<TUnitOfMeasure, double>(Convert.ToDouble((object)volume1.mVolume) / volume2);
        }

        public static double operator /(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.ValueAsDouble / volume2.ValueAsDouble;
        }

        public static bool operator ==(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.mVolume.CompareTo(volume2.mVolume) == 0;
        }

        public static bool operator ==(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) == 0;
        }

        public static bool operator !=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.mVolume.CompareTo(volume2.mVolume) != 0;
        }

        public static bool operator !=(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) != 0;
        }

        public static bool operator >(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.mVolume.CompareTo(volume2.mVolume) > 0;
        }

        public static bool operator >(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) > 0;
        }

        public static bool operator <(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.mVolume.CompareTo(volume2.mVolume) < 0;
        }

        public static bool operator <(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) < 0;
        }

        public static bool operator >=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.mVolume.CompareTo(volume2.mVolume) >= 0;
        }

        public static bool operator >=(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) >= 0;
        }

        public static bool operator <=(Volume<TUnitOfMeasure, TDataType> volume1, Volume<TUnitOfMeasure, TDataType> volume2)
        {
            return volume1.mVolume.CompareTo(volume2.mVolume) <= 0;
        }

        public static bool operator <=(Volume<TUnitOfMeasure, TDataType> volume1, IVolume volume2)
        {
            return volume1.ValueAsDouble.CompareTo(volume2.Value * (volume2.UnitOfMeasure.GetCompleteMultiplier<TUnitOfMeasure>(3))) <= 0;
        }

        private double ValueAsDouble
        {
            get { return Convert.ToDouble((object)mVolume); }
        }
        double IDimension.Value
        {
            get { return ValueAsDouble; }
        }

    }
}

namespace NGenericDimensions.Extensions
{

    public static class VolumeExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static TDataType VolumeValue<TUnitOfMeasure, TDataType>(this Nullable<Volume<TUnitOfMeasure, TDataType>> volume)
            where TUnitOfMeasure : Lengths.LengthUnitOfMeasure, new()
            where TDataType : struct, IComparable, IConvertible
        {
            return volume.Value.VolumeValue;
        }

    }

}