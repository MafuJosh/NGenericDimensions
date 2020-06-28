/*
using NGenericDimensions.MetricPrefix;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Masses.MetricSI
{
    public class Kilograms : Grams<Kilo>
    {
    }
}

namespace NGenericDimensions.Extensions
{
    public static class KilogramsExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T KilogramsValue<T>(this Mass<Kilograms, T> mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => mass.MassValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? KilogramsValue<T>(this Mass<Kilograms, T>? mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => mass?.MassValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SquareKilogramsValue<T>(this Area<Kilograms, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? SquareKilogramsValue<T>(this Area<Kilograms, T>? area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area?.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T CubeKilogramsValue<T>(this Volume<Kilograms, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.VolumeValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? CubeKilogramsValue<T>(this Volume<Kilograms, T>? volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume?.VolumeValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class KilogramsNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Mass<Masses.MetricSI.Kilograms, T> kilograms<T>(this T mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Masses.MetricSI.Kilograms, T> kilograms<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.SquaredValue;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Masses.MetricSI.Kilograms, T> kilograms<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.CubedValue;
    }
}
*/
