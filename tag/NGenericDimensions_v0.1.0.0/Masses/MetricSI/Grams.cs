using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using NGenericDimensions.MetricPrefix;

namespace NGenericDimensions.Masses.MetricSI
{

    public class Grams : SIMassUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return 1;
        }

    }

    public class Grams<T> : SIMassUnitOfMeasure where T : MetricPrefixBase
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return (double)UnitOfMeasureGlobals<T>.GlobalInstance.Multiplier;
        }

    }

}

namespace NGenericDimensions.Extensions
{

    public static class GramsExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T GramsValue<T>(this Mass<Masses.MetricSI.Grams, T> mass) where T : struct, IComparable, IConvertible
        {
            return mass.MassValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> GramsValue<T>(this Nullable<Mass<Masses.MetricSI.Grams, T>> mass) where T : struct, IComparable, IConvertible
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

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Mass<Masses.MetricSI.Grams, T> grams<T>(this T mass) where T : struct, IComparable, IConvertible
        {
            return mass;
        }

    }

}