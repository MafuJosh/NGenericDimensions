using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NGenericDimensions.Lengths.Uscs
{

    public class Yards : UscsLengthUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return base.GetMultiplier(stayWithinFamily) * 3;
        }

    }

}

namespace NGenericDimensions.Extensions
{

    public static class YardsExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T YardsValue<T>(this Length<Lengths.Uscs.Yards, T> length) where T : struct, IComparable, IConvertible
        {
            return length.LengthValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> YardsValue<T>(this Nullable<Length<Lengths.Uscs.Yards, T>> length) where T : struct, IComparable, IConvertible
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
        public static T SquareYardsValue<T>(this Area<Lengths.Uscs.Yards, T> area) where T : struct, IComparable, IConvertible
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> SquareYardsValue<T>(this Nullable<Area<Lengths.Uscs.Yards, T>> area) where T : struct, IComparable, IConvertible
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

    public static class YardsNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.Uscs.Yards, T> yards<T>(this T length) where T : struct, IComparable, IConvertible
        {
            return length;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.Uscs.Yards, T> yards<T>(this LengthSquareExtension<T> area) where T : struct, IComparable, IConvertible
        {
            return area.Area;
        }

    }

}