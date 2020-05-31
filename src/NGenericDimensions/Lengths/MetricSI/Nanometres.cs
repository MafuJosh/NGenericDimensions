using System;
using System.ComponentModel;
using NGenericDimensions.MetricPrefix;

namespace NGenericDimensions.Lengths.MetricSI
{

    public class Nanometres : Metres<Nano>
    {

    }

}

namespace NGenericDimensions.Extensions
{

    public static class NanometresExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T NanometresValue<T>(this Length<Lengths.MetricSI.Nanometres, T> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return length.LengthValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> ManometresValue<T>(this Nullable<Length<Lengths.MetricSI.Nanometres, T>> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static T SquareNanometresValue<T>(this Area<Lengths.MetricSI.Nanometres, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> SquareManometresValue<T>(this Nullable<Area<Lengths.MetricSI.Nanometres, T>> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static T CubeNanometresValue<T>(this Volume<Lengths.MetricSI.Nanometres, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return volume.VolumeValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> CubeManometresValue<T>(this Nullable<Volume<Lengths.MetricSI.Nanometres, T>> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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

    public static class NanometresNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.MetricSI.Nanometres, T> nanometers<T>(this T length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return length;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.MetricSI.Nanometres, T> nanometers<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area.SquaredValue;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Lengths.MetricSI.Nanometres, T> nanometers<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return volume.CubedValue;
        }

    }

}