using System;
using System.ComponentModel;
using NGenericDimensions.MetricPrefix;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Masses.MetricSI
{

    public class Grams : SIMassUnitOfMeasure, IDefinedUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return 1;
        }

        public override string UnitSymbol
        {
            get
            {
                return "g";
            }
        }
    }

    public class Grams<T> : SIMassUnitOfMeasure, IDefinedUnitOfMeasure where T : MetricPrefixBase
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return (double)UnitOfMeasureGlobals<T>.GlobalInstance.Multiplier;
        }

        public override string UnitSymbol
        {
            get
            {
                return MetricPrefix.UnitSymbol + "g";
            }
        }

        /// <summary>
        /// Returns the simple name of the derived class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MetricPrefix.ToString() + "grams";
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public MetricPrefixBase MetricPrefix
        {
            get { return UnitOfMeasureGlobals<T>.GlobalInstance; }
        }
    }

}

namespace NGenericDimensions.Extensions
{

    public static class GramsExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T GramsValue<T>(this Mass<Masses.MetricSI.Grams, T> mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return mass.MassValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> GramsValue<T>(this Nullable<Mass<Masses.MetricSI.Grams, T>> mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            if (mass.HasValue)
            {
                return mass.Value.MassValue;
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

    public static class GramsNumberExtensionMethods
    {
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Mass<Masses.MetricSI.Grams, T> grams<T>(this T mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return mass;
        }

    }

}