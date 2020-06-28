/*
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Masses.MetricSI
{
    public class Grams : MetricSIMassUnitOfMeasure, IDefinedUnitOfMeasure
    {
        public override string UnitSymbol => "g";
    }
}

namespace NGenericDimensions.Extensions
{
    public static class GramsExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T GramsValue<T>(this Mass<Grams, T> mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => mass.MassValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? GramsValue<T>(this Mass<Grams, T>? mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => mass?.MassValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SquareGramsValue<T>(this Area<Grams, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? SquareGramsValue<T>(this Area<Grams, T>? area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area?.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T CubeGramsValue<T>(this Volume<Grams, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.VolumeValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? CubeGramsValue<T>(this Volume<Grams, T>? volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume?.VolumeValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class GramsNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Mass<Masses.MetricSI.Grams, T> grams<T>(this T mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Masses.MetricSI.Grams, T> grams<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.SquaredValue;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Masses.MetricSI.Grams, T> grams<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.CubedValue;
    }
}
*/
