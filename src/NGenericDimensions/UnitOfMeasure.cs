using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
/// IDimension is the base interface of all dimension data types. It can be used to identify if a datatype is a dimensional datatype and retrieve its value.
/// </summary>
public interface IDimension : IFormattable
{
    double Value { get; }
}

[EditorBrowsable(EditorBrowsableState.Never)]
public interface IDimensionSupportsPerExtension { }

[EditorBrowsable(EditorBrowsableState.Never)]
public struct DimensionPerExtension<TDimension>
    where TDimension : IDimension, IDimensionSupportsPerExtension
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal TDimension PerValue;
}

[EditorBrowsable(EditorBrowsableState.Never)]
public struct DimensionSquareExtension<TDataType>
    where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal TDataType SquaredValue;
}

[EditorBrowsable(EditorBrowsableState.Never)]
public struct DimensionCubeExtension<TDataType>
    where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal TDataType CubedValue;
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
public interface IDefinedUnitOfMeasure {}

/// <summary>
/// These interfaces help control what UOMs of different dimensions are allowed (such as allowing using Millimeters for Area and Volume, but not acres for volume or length, etc.)
/// </summary>
public interface IExponent1Or2 { }
public interface IExponent1Or3 { }

public abstract class UnitOfMeasure : IFormattable
{

    protected abstract double GetMultiplier(bool stayWithinFamily);
    protected abstract bool IsSameFamily(Type typeOfUnitOfMeasure);
    protected virtual int Exponent
    {
        get { return 1; }
    }

    protected internal double GetCompleteMultiplier<T>(int exponent) where T : UnitOfMeasure
    {
        if (this is T)
        {
            return 1;
        }
        else
        {
            dynamic stayWithinFamily = this.IsSameFamily(typeof(T));
            double myMultiplier = ApplyExponentToMultiplier(this.GetMultiplier(stayWithinFamily), this.Exponent, exponent);
            double otherMultiplier = ApplyExponentToMultiplier(UnitOfMeasureGlobals<T>.GlobalInstance.GetMultiplier(stayWithinFamily), UnitOfMeasureGlobals<T>.GlobalInstance.Exponent, exponent);
            return myMultiplier / otherMultiplier;
        }
    }

    private static double ApplyExponentToMultiplier(double multiplier, int lengthExponent, int requestedExponent)
    {
        double newMultiplier = multiplier;
        for (int i = (lengthExponent + 1); i <= requestedExponent; i++)
        {
            newMultiplier *= multiplier;
        }
        return newMultiplier;
    }

    /// <summary>
    /// Returns the simple name of the derived class.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.GetType().Name;
    }

    /// <summary>
    /// Return the singular form of the name of the derived class.
    /// </summary>
    /// <returns></returns>
    internal protected virtual string ToSingularString()
    {
        var name = ToString();

        // use some default logic to try to figure out the singular form of the unit
        if (name.EndsWith("s"))
        {
            return name.Substring(0, name.Length - 1);
        }

        // otherwise just return the name - if this name is plural, then the inheriting class should override this function
        return name;
    }

    public string ToString(string format, IFormatProvider formatProvider)
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

    public virtual string UnitSymbol
    {
        get
        {
            return ToString();
        }
    }

    internal virtual string ToString(IFormattable value, string format, IFormatProvider formatProvider)
    {
        if (format == null)
        { }
        else if (format.Contains("NU"))
        {
            return value.ToString(TrimCustomFormat(format), formatProvider);
        }
        else if (format.Contains("SU"))
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
    protected virtual string DimensionUnitSymbol(IDimension dimension)
    {
        return null;
    }

    internal string GetDimensionalUnitSymbol(IDimension dimension)
    {
        return DimensionUnitSymbol(dimension);
    }

    protected static string TrimCustomFormat(string format)
    {
        if (format == null) return null;
        return format.Replace("NU", "").Replace("LU", "").Replace("SU", "");
    }
}

namespace NGenericDimensions.Extensions
{

    public static class DimensionExtensionMethods
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static DimensionPerExtension<TDimension> per<TDimension>(this TDimension dimensionValue)
            where TDimension : IDimension, IDimensionSupportsPerExtension
        {
            return new DimensionPerExtension<TDimension> { PerValue = dimensionValue };
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static DimensionSquareExtension<TDataType> square<TDataType>(this TDataType squaredValue) where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return new DimensionSquareExtension<TDataType> { SquaredValue = squaredValue };
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static DimensionCubeExtension<TDataType> cube<TDataType>(this TDataType cubedValue) where TDataType : struct, IComparable, IFormattable, IComparable<TDataType>, IEquatable<TDataType>
        {
            return new DimensionCubeExtension<TDataType> { CubedValue = cubedValue };
        }
    }
}