using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Areas.MetricNonSI
{
    public class Hectares : MetricNonSIAreaUnitOfMeasure, IDefinedUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return base.GetMultiplier(stayWithinFamily);
        }

        public override string UnitSymbol
        {
            get
            {
                return "ha";
            }
        }
    }
}

namespace NGenericDimensions.Extensions
{

    public static class HectareExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T HectaresValue<T>(this Area<Areas.MetricNonSI.Hectares, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> HectaresValue<T>(this Nullable<Area<Areas.MetricNonSI.Hectares, T>> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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

    }

}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class HectareNumberExtensionMethods
    {
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Areas.MetricNonSI.Hectares, T> hectares<T>(this T area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return area;
        }

    }

}