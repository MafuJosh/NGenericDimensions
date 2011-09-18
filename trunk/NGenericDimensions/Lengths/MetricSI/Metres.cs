using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using NGenericDimensions.MetricPrefix;

namespace NGenericDimensions.Lengths.MetricSI
{

    public class Metres : SILengthUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return 1;
        }

    }

    public class Metres<T> : SILengthUnitOfMeasure where T : MetricPrefixBase
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return (double)(UnitOfMeasureGlobals<T>.GlobalInstance.Multiplier);
        }

    }

}

namespace NGenericDimensions.Extensions
{

    public static class MetresExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MetresValue<T>(this Length<Lengths.MetricSI.Metres, T> length) where T : struct, IComparable, IConvertible
        {
            return length.LengthValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> MetresValue<T>(this Nullable<Length<Lengths.MetricSI.Metres, T>> length) where T : struct, IComparable, IConvertible
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
        public static T SquareMetresValue<T>(this Area<Lengths.MetricSI.Metres, T> area) where T : struct, IComparable, IConvertible
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> SquareMetresValue<T>(this Nullable<Area<Lengths.MetricSI.Metres, T>> area) where T : struct, IComparable, IConvertible
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

    public static class MetresNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.MetricSI.Metres, T> metres<T>(this T length) where T : struct, IComparable, IConvertible
        {
            return length;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.MetricSI.Metres, T> metres<T>(this LengthSquareExtension<T> area) where T : struct, IComparable, IConvertible
        {
            return area.Area;
        }

    }

}