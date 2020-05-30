using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using NGenericDimensions.MetricPrefix;

namespace NGenericDimensions.Volumes.MetricNonSI
{

    public class Litres : MetricNonSIVolumeUnitOfMeasure, IDefinedUnitOfMeasure
	{

		protected override double GetMultiplier(bool stayWithinFamily)
		{
			return base.GetMultiplier(stayWithinFamily);
		}

        public override string UnitSymbol
        {
            get
            {
                return "L"; // can be capital or lowercase, "l" looks too much like "1"
            }
        }
	}

    public class Litres<T> : MetricNonSIVolumeUnitOfMeasure, IDefinedUnitOfMeasure where T : MetricPrefixBase
	{

		protected override double GetMultiplier(bool stayWithinFamily)
		{
			return Convert.ToDouble(UnitOfMeasureGlobals<T>.GlobalInstance.Multiplier) * base.GetMultiplier(stayWithinFamily);
		}

        public override string UnitSymbol
        {
            get
            {
                return MetricPrefix.UnitSymbol + "l";
            }
        }

        /// <summary>
        /// Returns the simple name of the derived class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MetricPrefix.ToString() + "litres";
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public MetricPrefixBase MetricPrefix
        {
            get { return UnitOfMeasureGlobals<T>.GlobalInstance; }
        }
	}

}

namespace NGenericDimensions.Extensions
{

    public static class  LitreExtensionMethods
	{

		[EditorBrowsable(EditorBrowsableState.Always)]
        public static T LitresValue<T>(this Volume<Volumes.MetricNonSI.Litres, T> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
		{
			return volume.VolumeValue;
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> LitresValue<T>(this Nullable<Volume<Volumes.MetricNonSI.Litres, T>> volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
		{
			if (volume.HasValue) {
				return volume.Value.VolumeValue;
			} else {
				return null;
			}
		}

	}

}

namespace NGenericDimensions.Extensions.Numbers
{

    public static class LitreNumberExtensionMethods
	{

		[EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Volume<Volumes.MetricNonSI.Litres, T> litres<T>(this T volume) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
		{
			return volume;
		}

	}

}