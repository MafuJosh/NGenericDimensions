using NGenericDimensions.MetricPrefix;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Masses.MetricSI
{
    public class Grams : SIMassUnitOfMeasure, IDefinedUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => 1;

        public override string UnitSymbol => "g";
    }

    public class Grams<T> : SIMassUnitOfMeasure, IDefinedUnitOfMeasure where T : MetricPrefixBase
    {
        protected override double GetMultiplier(bool stayWithinFamily) => (double)UnitOfMeasureGlobals<T>.GlobalInstance.Multiplier;

        public override string UnitSymbol => MetricPrefix.UnitSymbol + "g";

        /// <summary>
        /// Returns the simple name of the derived class.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => MetricPrefix.ToString() + "grams";

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public MetricPrefixBase MetricPrefix => UnitOfMeasureGlobals<T>.GlobalInstance;
    }

}

namespace NGenericDimensions.Extensions
{
    public static class GramsExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T GramsValue<T>(this Mass<Masses.MetricSI.Grams, T> mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => mass.MassValue;

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? GramsValue<T>(this Mass<Masses.MetricSI.Grams, T>? mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => mass?.MassValue;
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    public static class GramsNumberExtensionMethods
    {
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Mass<Masses.MetricSI.Grams, T> grams<T>(this T mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => mass;
    }
}