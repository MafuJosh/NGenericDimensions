using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NGenericDimensions.Durations
{

    public class Ticks : StandardDurationUnitOfMeasure, IDefinedUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            return 1;
        }

        public override string UnitSymbol
        {
            get
            {
                return "ticks";
            }
        }
    }

}

namespace NGenericDimensions.Extensions
{

    public static class TicksExtensionMethods
    {

        // I'm not including this because nobody usually cares about ticks, it is more an internal thing to .NET
        //<EditorBrowsable(EditorBrowsableState.Advanced)> _
        //<Extension()> _
        //Public Function Ticks(Of T As {Structure, IComparable, IConvertible})(ByVal duration As T) As Duration(Of Ticks, T)
        //    Return duration
        //End Function

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static T TicksValue<T>(this Duration<Durations.Ticks, T> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            return duration.DurationValue;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public static Nullable<T> TicksValue<T>(this Nullable<Duration<Durations.Ticks, T>> duration) where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
        {
            if (duration.HasValue)
            {
                return duration.Value.DurationValue;
            }
            else
            {
                return null;
            }
        }

    }

}