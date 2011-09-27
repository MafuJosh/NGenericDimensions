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

    public class Nanometres : Metres<Nano>
    {

    }

}

namespace NGenericDimensions.Extensions
{

    public static class NanometresExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T NanometresValue<T>(this Length<Lengths.MetricSI.Nanometres, T> length) where T : struct, IComparable, IConvertible
        {
            return length.LengthValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> ManometresValue<T>(this Nullable<Length<Lengths.MetricSI.Nanometres, T>> length) where T : struct, IComparable, IConvertible
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
        public static T SquareNanometresValue<T>(this Area<Lengths.MetricSI.Nanometres, T> area) where T : struct, IComparable, IConvertible
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> SquareManometresValue<T>(this Nullable<Area<Lengths.MetricSI.Nanometres, T>> area) where T : struct, IComparable, IConvertible
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

    public static class NanometresNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.MetricSI.Nanometres, T> nanometers<T>(this T length) where T : struct, IComparable, IConvertible
        {
            return length;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.MetricSI.Nanometres, T> nanometers<T>(this LengthSquareExtension<T> area) where T : struct, IComparable, IConvertible
        {
            return area.Area;
        }

    }

}