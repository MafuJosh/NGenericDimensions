using NGenericDimensions.MetricPrefix;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Volumes.MetricNonSI
{
    public class Litres : MetricNonSIVolumeUnitOfMeasure, IDefinedUnitOfMeasure
    {
        public override string UnitSymbol => "L";
    }

    public class Litres<T> : MetricNonSIVolumeUnitOfMeasure, IDefinedUnitOfMeasure where T : MetricPrefixBase
    {
        protected override double GetMultiplier(bool stayWithinFamily) => (double)UnitOfMeasureGlobals<T>.GlobalInstance.Multiplier * base.GetMultiplier(stayWithinFamily);

        public override string UnitSymbol => MetricPrefix.UnitSymbol + "L";

        /// <summary>
        /// Returns the simple name of the derived class.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => MetricPrefix.ToString() + "litres";

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public MetricPrefixBase MetricPrefix => UnitOfMeasureGlobals<T>.GlobalInstance;
    }
}

namespace NGenericDimensions.Extensions
{
    public static class LitresExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T LitresValue<T>(this Volume<Volumes.MetricNonSI.Litres, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume.VolumeValue;
        
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? LitresValue<T>(this Volume<Volumes.MetricNonSI.Litres, T>? volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume?.VolumeValue;
        
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class LitresNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Volumes.MetricNonSI.Litres, T> litres<T>(this T volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => volume;
        
    }
}