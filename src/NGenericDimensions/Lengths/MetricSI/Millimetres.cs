using NGenericDimensions.MetricPrefix;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Lengths.MetricSI
{
    public class Millimetres : Metres<Milli>
    {
    }
}

namespace NGenericDimensions.Extensions
{
    public static class MillimetresExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MillimetresValue<T>(this Length<Lengths.MetricSI.Millimetres, T> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length.LengthValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? MillimetresValue<T>(this Length<Lengths.MetricSI.Millimetres, T>? length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length?.LengthValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SquareMillimetresValue<T>(this Area<Lengths.MetricSI.Millimetres, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? SquareMillimetresValue<T>(this Area<Lengths.MetricSI.Millimetres, T>? area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area?.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T CubeMillimetresValue<T>(this Volume<Lengths.MetricSI.Millimetres, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.VolumeValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? CubeMillimetresValue<T>(this Volume<Lengths.MetricSI.Millimetres, T>? volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume?.VolumeValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class MillimetresNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.MetricSI.Millimetres, T> millimetres<T>(this T length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.MetricSI.Millimetres, T> millimetres<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.SquaredValue;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Lengths.MetricSI.Millimetres, T> millimetres<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.CubedValue;
    }
}