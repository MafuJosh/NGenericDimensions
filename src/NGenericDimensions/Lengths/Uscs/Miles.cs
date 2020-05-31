using System;
using System.ComponentModel;
using NGenericDimensions.Durations;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Lengths.Uscs
{

    public class Miles : UscsLengthUnitOfMeasure, IDefinedUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return base.GetMultiplier(stayWithinFamily) * 5280;
        }

        public override string UnitSymbol
        {
            get
            {
                return "mi.";
            }
        }

        protected override string DimensionUnitSymbol(IDimension dimension)
        {
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
        public static T MilesValue<T>(this Length<Lengths.Uscs.Miles, T> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return length.LengthValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> MilesValue<T>(this Nullable<Length<Lengths.Uscs.Miles, T>> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static T SquareMilesValue<T>(this Area<Lengths.Uscs.Miles, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> SquareMilesValue<T>(this Nullable<Area<Lengths.Uscs.Miles, T>> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static T CubeMilesValue<T>(this Volume<Lengths.Uscs.Miles, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return volume.VolumeValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> CubeMilesValue<T>(this Nullable<Volume<Lengths.Uscs.Miles, T>> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
    public static class MilesNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.Uscs.Miles, T> miles<T>(this T length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return length;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.Uscs.Miles, T> miles<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area.SquaredValue;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Lengths.Uscs.Miles, T> miles<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return volume.CubedValue;
        }

    }

}