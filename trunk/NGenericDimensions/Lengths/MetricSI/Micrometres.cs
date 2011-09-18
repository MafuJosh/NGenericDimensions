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

    public class Micrometres : Metres<Micro>
    {

    }

}

namespace NGenericDimensions.Extensions
{

    public static class MicrometresExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MicrometresValue<T>(this Length<Lengths.MetricSI.Micrometres, T> length) where T : struct, IComparable, IConvertible
        {
            return length.LengthValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> MicrometresValue<T>(this Nullable<Length<Lengths.MetricSI.Micrometres, T>> length) where T : struct, IComparable, IConvertible
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
        public static T SquareMicrometresValue<T>(this Area<Lengths.MetricSI.Micrometres, T> area) where T : struct, IComparable, IConvertible
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> SquareMicrometresValue<T>(this Nullable<Area<Lengths.MetricSI.Micrometres, T>> area) where T : struct, IComparable, IConvertible
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

    public static class MicrometresNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.MetricSI.Micrometres, T> micrometres<T>(this T length) where T : struct, IComparable, IConvertible
        {
            return length;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.MetricSI.Micrometres, T> micrometres<T>(this LengthSquareExtension<T> area) where T : struct, IComparable, IConvertible
        {
            return area.Area;
        }

    }

}