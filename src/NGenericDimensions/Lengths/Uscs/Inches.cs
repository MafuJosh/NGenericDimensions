using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Lengths.Uscs
{
    public class Inches : UscsLengthUnitOfMeasure, IDefinedUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => base.GetMultiplier(stayWithinFamily) / 12;
        public override string UnitSymbol => "in.";
    }
}

namespace NGenericDimensions.Extensions
{
    public static class InchesExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T InchesValue<T>(this Length<Lengths.Uscs.Inches, T> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length.LengthValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? InchesValue<T>(this Length<Lengths.Uscs.Inches, T>? length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length?.LengthValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SquareInchesValue<T>(this Area<Lengths.Uscs.Inches, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? SquareInchesValue<T>(this Area<Lengths.Uscs.Inches, T>? area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area?.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T CubeInchesValue<T>(this Volume<Lengths.Uscs.Inches, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.VolumeValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? CubeInchesValue<T>(this Volume<Lengths.Uscs.Inches, T>? volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume?.VolumeValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class InchesNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.Uscs.Inches, T> inches<T>(this T length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.Uscs.Inches, T> inches<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.SquaredValue;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Lengths.Uscs.Inches, T> inches<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.CubedValue;
    }
}