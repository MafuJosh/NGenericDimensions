using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenericDimensions.Areas.MetricNonSI
{
    public class Hectares : MetricNonSIAreaUnitOfMeasure, IDefinedUnitOfMeasure
    {
        public override string UnitSymbol => "ha";
    }
}

namespace NGenericDimensions.Extensions
{
    public static class HectaresExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T HectaresValue<T>(this Area<Areas.MetricNonSI.Hectares, T> area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area.AreaValue;
        
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T? HectaresValue<T>(this Area<Areas.MetricNonSI.Hectares, T>? area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area?.AreaValue;
        
    }
}

namespace NGenericDimensions.Extensions.Numbers
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class HectaresNumberExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Areas.MetricNonSI.Hectares, T> hectares<T>(this T area) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T> => area;
        
    }
}