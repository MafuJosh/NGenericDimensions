using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NGenericDimensions.Areas.MetricNonSI
{

    public class Hectares : MetricNonSIAreaUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return base.GetMultiplier(stayWithinFamily);
        }

    }

}

namespace NGenericDimensions.Extensions
{

    public static class HectareExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T HectaresValue<T>(this Area<Areas.MetricNonSI.Hectares, T> area) where T : struct, IComparable, IConvertible
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> HectaresValue<T>(this Nullable<Area<Areas.MetricNonSI.Hectares, T>> area) where T : struct, IComparable, IConvertible
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

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Areas.MetricNonSI.Hectares, T> hectares<T>(this T area) where T : struct, IComparable, IConvertible
        {
            return area;
        }

    }

}