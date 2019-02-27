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

    public class Kilograms : Grams<Kilo>
    {

    }

}

namespace NGenericDimensions.Extensions
{

    public static class KilogramsExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T KilogramsValue<T>(this Mass<Masses.MetricSI.Kilograms, T> mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return mass.MassValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> KilogramsValue<T>(this Nullable<Mass<Masses.MetricSI.Kilograms, T>> mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
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

    public static class KilogramsNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Mass<Masses.MetricSI.Kilograms, T> kilograms<T>(this T mass) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return mass;
        }

    }

}