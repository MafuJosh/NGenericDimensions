using System;
using System.ComponentModel;

namespace NGenericDimensions.Lengths.Uscs
{

    public class Feet : UscsLengthUnitOfMeasure, IDefinedUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return base.GetMultiplier(stayWithinFamily);
        }

        public override string UnitSymbol
        {
            get
            {
                return "ft.";
            }
        }

    }

}

namespace NGenericDimensions.Extensions
{

    public static class FeetExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T FeetValue<T>(this Length<Lengths.Uscs.Feet, T> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return length.LengthValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> FeetValue<T>(this Nullable<Length<Lengths.Uscs.Feet, T>> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static T SquareFeetValue<T>(this Area<Lengths.Uscs.Feet, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> SquareFeetValue<T>(this Nullable<Area<Lengths.Uscs.Feet, T>> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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
        public static T CubeFeetValue<T>(this Volume<Lengths.Uscs.Feet, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return volume.VolumeValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> CubeFeetValue<T>(this Nullable<Volume<Lengths.Uscs.Feet, T>> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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

    public static class FeetNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.Uscs.Feet, T> feet<T>(this T length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return length;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.Uscs.Feet, T> feet<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area.SquaredValue;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Lengths.Uscs.Feet, T> feet<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return volume.CubedValue;
        }

    }

}