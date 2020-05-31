using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using NGenericDimensions.MetricPrefix;

namespace NGenericDimensions.Lengths.MetricSI
{
    public class Metres : SILengthUnitOfMeasure, IDefinedUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => 1;

        public override string UnitSymbol => "m";
    }

    public class Metres<T> : SILengthUnitOfMeasure, IDefinedUnitOfMeasure where T : MetricPrefixBase
    {
        protected override double GetMultiplier(bool stayWithinFamily) => (double)(UnitOfMeasureGlobals<T>.GlobalInstance.Multiplier);

        public override string UnitSymbol => MetricPrefix.UnitSymbol + "m";

        /// <summary>
        /// Returns the simple name of the derived class.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => MetricPrefix.ToString() + "metres";

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public MetricPrefixBase MetricPrefix => UnitOfMeasureGlobals<T>.GlobalInstance;
    }

}

namespace NGenericDimensions.Extensions
{
    public static class MetresExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MetresValue<T>(this Length<Lengths.MetricSI.Metres, T> length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length.LengthValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? MetresValue<T>(this Length<Lengths.MetricSI.Metres, T>? length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length?.LengthValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T SquareMetresValue<T>(this Area<Lengths.MetricSI.Metres, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? SquareMetresValue<T>(this Area<Lengths.MetricSI.Metres, T>? area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area?.AreaValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T CubeMetresValue<T>(this Volume<Lengths.MetricSI.Metres, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.VolumeValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? CubeMetresValue<T>(this Volume<Lengths.MetricSI.Metres, T>? volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume?.VolumeValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class MetresNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.MetricSI.Metres, T> metres<T>(this T length) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => length;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.MetricSI.Metres, T> metres<T>(this DimensionSquareExtension<T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.SquaredValue;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Lengths.MetricSI.Metres, T> metres<T>(this DimensionCubeExtension<T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.CubedValue;
    }
}