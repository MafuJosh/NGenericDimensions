﻿using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using NGenericDimensions.MetricPrefix;

namespace NGenericDimensions.Lengths.MetricSI
{
    public class Micrometres : Metres<Micro>
    {
    }
}

namespace NGenericDimensions.Extensions
{
    public static class MicrometresExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MicrometresValue<T>(this Length<Lengths.MetricSI.Micrometres, T> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length.LengthValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? MicrometresValue<T>(this Nullable<Length<Lengths.MetricSI.Micrometres, T>> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return length?.LengthValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SquareMicrometresValue<T>(this Area<Lengths.MetricSI.Micrometres, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? SquareMicrometresValue<T>(this Nullable<Area<Lengths.MetricSI.Micrometres, T>> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static T CubeMicrometresValue<T>(this Volume<Lengths.MetricSI.Micrometres, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return volume.VolumeValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? CubeMicrometresValue<T>(this Nullable<Volume<Lengths.MetricSI.Micrometres, T>> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class MicrometresNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.MetricSI.Micrometres, T> micrometres<T>(this T length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return length;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.MetricSI.Micrometres, T> micrometres<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area.SquaredValue;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Lengths.MetricSI.Micrometres, T> micrometres<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return volume.CubedValue;
        }
    }
}