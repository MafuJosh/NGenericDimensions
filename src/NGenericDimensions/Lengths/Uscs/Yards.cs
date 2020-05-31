using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Lengths.Uscs
{
    public class Yards : UscsLengthUnitOfMeasure, IDefinedUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => base.GetMultiplier(stayWithinFamily) * 3;

        public override string UnitSymbol => "yd.";
    }

}

namespace NGenericDimensions.Extensions
{
    public static class YardsExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T YardsValue<T>(this Length<Lengths.Uscs.Yards, T> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length.LengthValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? YardsValue<T>(this Length<Lengths.Uscs.Yards, T>? length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length?.LengthValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SquareYardsValue<T>(this Area<Lengths.Uscs.Yards, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? SquareYardsValue<T>(this Area<Lengths.Uscs.Yards, T>? area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area?.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T CubeYardsValue<T>(this Volume<Lengths.Uscs.Yards, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.VolumeValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? CubeYardsValue<T>(this Volume<Lengths.Uscs.Yards, T>? volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume?.VolumeValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class YardsNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.Uscs.Yards, T> yards<T>(this T length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.Uscs.Yards, T> yards<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.SquaredValue;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Lengths.Uscs.Yards, T> yards<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.CubedValue;
    }
}