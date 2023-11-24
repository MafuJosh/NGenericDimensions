using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NGenericDimensions
{
    /// <summary>
    /// IDimension is the base interface of all dimension data types. It can be used to identify if a datatype is a dimensional datatype and retrieve its value.
    /// </summary>
    public interface IDimension : IFormattable, IConvertible
    {
        double Value { get; }

#if NET
        bool IConvertible.ToBoolean(IFormatProvider? provider) => throw new InvalidCastException("The conversion to a Boolean is not supported.");
        char IConvertible.ToChar(IFormatProvider? provider) => throw new InvalidCastException("The conversion to a Char is not supported.");
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => throw new InvalidCastException("The conversion to a DateTime is not supported.");
        string IConvertible.ToString(IFormatProvider? provider) => ToString(null, provider);
#endif
    }

        [EditorBrowsable(EditorBrowsableState.Never)]
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Empty interfaces are sometimes the only way to control a generic constraint.")]
    public interface IDimensionSupportsPerExtension { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct DimensionPerExtension<TDimension> : IEquatable<DimensionPerExtension<TDimension>>
        where TDimension : IDimension, IDimensionSupportsPerExtension
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal readonly TDimension PerValue;
        internal DimensionPerExtension(TDimension perValue) => PerValue = perValue;
        public override bool Equals(object? obj) => obj != null && obj is DimensionPerExtension<TDimension> o && o.PerValue.Equals(PerValue);
        bool IEquatable<DimensionPerExtension<TDimension>>.Equals(DimensionPerExtension<TDimension> other) => EqualityComparer<TDimension>.Default.Equals(PerValue, other.PerValue);
        public override int GetHashCode() => HashCode.Combine(PerValue);
        public static bool operator ==(DimensionPerExtension<TDimension> left, DimensionPerExtension<TDimension> right) => left.Equals(right);
        public static bool operator !=(DimensionPerExtension<TDimension> left, DimensionPerExtension<TDimension> right) => !(left == right);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct DimensionSquareExtension<TDataType> : IEquatable<DimensionSquareExtension<TDataType>>
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal readonly TDataType SquaredValue;
        internal DimensionSquareExtension(TDataType squaredValue) => SquaredValue = squaredValue;
        public override bool Equals(object? obj) => obj != null && obj is DimensionSquareExtension<TDataType> o && o.SquaredValue.Equals(SquaredValue);
        public override int GetHashCode() => HashCode.Combine(SquaredValue);
        bool IEquatable<DimensionSquareExtension<TDataType>>.Equals(DimensionSquareExtension<TDataType> other) => EqualityComparer<TDataType>.Default.Equals(SquaredValue, other.SquaredValue);
        public static bool operator ==(DimensionSquareExtension<TDataType> left, DimensionSquareExtension<TDataType> right) => left.Equals(right);
        public static bool operator !=(DimensionSquareExtension<TDataType> left, DimensionSquareExtension<TDataType> right) => !(left == right);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct DimensionCubeExtension<TDataType> : IEquatable<DimensionCubeExtension<TDataType>>
        where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal readonly TDataType CubedValue;
        internal DimensionCubeExtension(TDataType cubedValue) => CubedValue = cubedValue;
        public override bool Equals(object? obj) => obj != null && obj is DimensionCubeExtension<TDataType> o && o.CubedValue.Equals(CubedValue);
        bool IEquatable<DimensionCubeExtension<TDataType>>.Equals(DimensionCubeExtension<TDataType> other) => EqualityComparer<TDataType>.Default.Equals(CubedValue, other.CubedValue);
        public override int GetHashCode() => HashCode.Combine(CubedValue);
        public static bool operator ==(DimensionCubeExtension<TDataType> left, DimensionCubeExtension<TDataType> right) => left.Equals(right);
        public static bool operator !=(DimensionCubeExtension<TDataType> left, DimensionCubeExtension<TDataType> right) => !(left == right);
    }

    /// <summary>
    /// This internal helper class provides a way to create a global instance of class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal static class UnitOfMeasureGlobals<T>
        where T : class
    {
        static internal T GlobalInstance { get; } = Activator.CreateInstance<T>();
    }

    /// <summary>
    /// This interface is used to detect if a class type is a derived class of UnitOfMeasure.  Only derived types should implement this.  This is used to restrict what classes can be used in the generic signatures.
    /// </summary>
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Empty interfaces are sometimes the only way to control a generic constraint.")]
    public interface IDefinedUnitOfMeasure { }

    /// <summary>
    /// These interfaces help control what UOMs of different dimensions are allowed (such as allowing using Millimeters for Area and Volume, but not acres for volume or length, etc.)
    /// </summary>
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Empty interfaces are sometimes the only way to control a generic constraint.")]
    public interface IExponent1Or2 { }
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Empty interfaces are sometimes the only way to control a generic constraint.")]
    public interface IExponent1Or3 { }

    public abstract class UnitOfMeasure : IFormattable
    {
        protected abstract double GetMultiplier(bool stayWithinFamily);
        protected abstract bool IsSameFamily(Type typeOfUnitOfMeasure);
        protected virtual int Exponent => 1;

        protected internal double GetCompleteMultiplier<T>(int exponent) where T : UnitOfMeasure
        {
            if (this is T)
            {
                return 1;
            }
            else
            {
                var stayWithinFamily = IsSameFamily(typeof(T));
                var myMultiplier = ApplyExponentToMultiplier(GetMultiplier(stayWithinFamily), Exponent, exponent);
                var otherMultiplier = ApplyExponentToMultiplier(UnitOfMeasureGlobals<T>.GlobalInstance.GetMultiplier(stayWithinFamily), UnitOfMeasureGlobals<T>.GlobalInstance.Exponent, exponent);
                return myMultiplier / otherMultiplier;
            }
        }

        private static double ApplyExponentToMultiplier(double multiplier, int lengthExponent, int requestedExponent)
        {
            var newMultiplier = multiplier;
            for (var i = (lengthExponent + 1); i <= requestedExponent; i++)
            {
                newMultiplier *= multiplier;
            }
            return newMultiplier;
        }

        /// <summary>
        /// Returns the simple name of the derived class.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => GetType().Name;

        /// <summary>
        /// Return the singular form of the name of the derived class.
        /// </summary>
        /// <returns></returns>
        internal protected virtual string ToSingularString()
        {
            var name = ToString();

            // use some default logic to try to figure out the singular form of the unit
            if (name.EndsWith("s", StringComparison.Ordinal))
            {
                return name.Substring(0, name.Length - 1);
            }

            // otherwise just return the name - if this name is plural, then the inheriting class should override this function
            return name;
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format == "NU")
            {
                return "";
            }
            else if (format == "SU")
            {
                return UnitSymbol;
            }
            else if (format == "LUS")
            {
            }
            return ToString();
        }

        public virtual string UnitSymbol => ToString();

        internal virtual string ToString(IFormattable value, string? format, IFormatProvider? formatProvider)
        {
            if (format == null)
            { }
            else if (format.Contains("NU", StringComparison.Ordinal))
            {
                return value.ToString(TrimCustomFormat(format), formatProvider);
            }
            else if (format.Contains("SU", StringComparison.Ordinal))
            {
                return value.ToString(TrimCustomFormat(format), formatProvider) + " " + ToString("SU", formatProvider);
            }
            return value.ToString(TrimCustomFormat(format), formatProvider) + " " + ToString(null, formatProvider);
        }

        /// <summary>
        /// Allows a unit to override a dimension's symbol that it is involved in (such as miles overriding to provide mph)
        /// </summary>
        /// <param name="dimension"></param>
        /// <returns></returns>
        protected virtual string? DimensionUnitSymbol(IDimension dimension) => null;

        internal string? GetDimensionalUnitSymbol(IDimension dimension) => DimensionUnitSymbol(dimension);

        protected static string? TrimCustomFormat(string? format) => format?.Replace("NU", "", StringComparison.Ordinal).Replace("LU", "", StringComparison.Ordinal).Replace("SU", "", StringComparison.Ordinal);
    }
}

namespace NGenericDimensions.Extensions
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "In this case we want it to be lowercase, to appear different than other functions.")]
    public static class DimensionExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static DimensionPerExtension<TDimension> per<TDimension>(this TDimension dimensionValue)
            where TDimension : IDimension, IDimensionSupportsPerExtension => new DimensionPerExtension<TDimension>(dimensionValue);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static DimensionSquareExtension<TDataType> square<TDataType>(this TDataType squaredValue) where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => new DimensionSquareExtension<TDataType>(squaredValue);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static DimensionCubeExtension<TDataType> cube<TDataType>(this TDataType cubedValue) where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType> => new DimensionCubeExtension<TDataType>(cubedValue);
    }
}