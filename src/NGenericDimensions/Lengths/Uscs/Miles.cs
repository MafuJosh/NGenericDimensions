using NGenericDimensions.Durations;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Lengths.Uscs
{
    public class Miles : UscsLengthUnitOfMeasure, IDefinedUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => base.GetMultiplier(stayWithinFamily) * 5280;

        public override string UnitSymbol => "mi.";

        protected override string? DimensionUnitSymbol(IDimension dimension)
        {
            if (dimension == null) return null;
            if (((ISpeed)dimension).DurationUnitOfMeasure == UnitOfMeasureGlobals<Hours>.GlobalInstance)
            {
                return "mph";
            }
            return base.DimensionUnitSymbol(dimension);
        }
    }

}

namespace NGenericDimensions.Extensions
{
    public static class MilesExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MilesValue<T>(this Length<Lengths.Uscs.Miles, T> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length.LengthValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? MilesValue<T>(this Length<Lengths.Uscs.Miles, T>? length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length?.LengthValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SquareMilesValue<T>(this Area<Lengths.Uscs.Miles, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? SquareMilesValue<T>(this Area<Lengths.Uscs.Miles, T>? area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area?.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T CubeMilesValue<T>(this Volume<Lengths.Uscs.Miles, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.VolumeValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? CubeMilesValue<T>(this Volume<Lengths.Uscs.Miles, T>? volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume?.VolumeValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class MilesNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.Uscs.Miles, T> miles<T>(this T length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.Uscs.Miles, T> miles<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.SquaredValue;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Lengths.Uscs.Miles, T> miles<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.CubedValue;
    }
}