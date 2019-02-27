using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using NGenericDimensions.MetricPrefix;

namespace NGenericDimensions.Lengths.MetricSI
{

    public class Metres : SILengthUnitOfMeasure, IDefinedUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return 1;
        }

        public override string UnitSymbol
        {
            get
            {
                return "m";
            }
        }
    }

    public class Metres<T> : SILengthUnitOfMeasure, IDefinedUnitOfMeasure where T : MetricPrefixBase
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return (double)(UnitOfMeasureGlobals<T>.GlobalInstance.Multiplier);
        }

        public override string UnitSymbol
        {
            get
            {
                return MetricPrefix.UnitSymbol + "m";
            }
        }

        /// <summary>
        /// Returns the simple name of the derived class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MetricPrefix.ToString() + "metres";
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public MetricPrefixBase MetricPrefix
        {
            get { return UnitOfMeasureGlobals<T>.GlobalInstance; }
        }
    }

}

namespace NGenericDimensions.Extensions
{

    public static class MetresExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MetresValue<T>(this Length<Lengths.MetricSI.Metres, T> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return length.LengthValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> MetresValue<T>(this Nullable<Length<Lengths.MetricSI.Metres, T>> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            if (length.HasValue)
            {
                return length.Value.LengthValue;
            }
            else
            {
                return null;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SquareMetresValue<T>(this Area<Lengths.MetricSI.Metres, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> SquareMetresValue<T>(this Nullable<Area<Lengths.MetricSI.Metres, T>> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            if (area.HasValue)
            {
                return area.Value.AreaValue;
            }
            else
            {
                return null;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T CubeMetresValue<T>(this Volume<Lengths.MetricSI.Metres, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return volume.VolumeValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> CubeMetresValue<T>(this Nullable<Volume<Lengths.MetricSI.Metres, T>> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            if (volume.HasValue)
            {
                return volume.Value.VolumeValue;
            }
            else
            {
                return null;
            }
        }

    }

}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class MetresNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.MetricSI.Metres, T> metres<T>(this T length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return length;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.MetricSI.Metres, T> metres<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area.SquaredValue;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Lengths.MetricSI.Metres, T> metres<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return volume.CubedValue;
        }

    }

}