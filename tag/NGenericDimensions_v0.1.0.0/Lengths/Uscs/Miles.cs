using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NGenericDimensions.Lengths.Uscs
{

    public class Miles : UscsLengthUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return base.GetMultiplier(stayWithinFamily) * 5280;
        }

    }

}

namespace NGenericDimensions.Extensions
{

    public static class MilesExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T MilesValue<T>(this Length<Lengths.Uscs.Miles, T> length) where T : struct, IComparable, IConvertible
        {
            return length.LengthValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> MilesValue<T>(this Nullable<Length<Lengths.Uscs.Miles, T>> length) where T : struct, IComparable, IConvertible
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
        public static T SquareMilesValue<T>(this Area<Lengths.Uscs.Miles, T> area) where T : struct, IComparable, IConvertible
        {
            return area.AreaValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> SquareMilesValue<T>(this Nullable<Area<Lengths.Uscs.Miles, T>> area) where T : struct, IComparable, IConvertible
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

    public static class MilesNumberExtensionMethods
    {

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Length<Lengths.Uscs.Miles, T> miles<T>(this T length) where T : struct, IComparable, IConvertible
        {
            return length;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Area<Lengths.Uscs.Miles, T> miles<T>(this LengthSquareExtension<T> area) where T : struct, IComparable, IConvertible
        {
            return area.Area;
        }

    }

}