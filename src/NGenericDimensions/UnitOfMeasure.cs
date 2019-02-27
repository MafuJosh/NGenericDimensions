using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public interface IDimension
{
    double Value { get; }
}

internal sealed class UnitOfMeasureGlobals<T>
{


    private static T mGlobalInstance = Activator.CreateInstance<T>();
    private UnitOfMeasureGlobals()
    {
    }

    static internal T GlobalInstance
    {
        get { return mGlobalInstance; }
    }

}

public abstract class UnitOfMeasure
{

    protected abstract double GetMultiplier(bool stayWithinFamily);
    protected abstract bool IsSameFamily(Type typeOfUnitOfMeasure);
    protected virtual int DimensionCount
    {
        get { return 1; }
    }

    protected internal double GetCompleteMultiplier<T>(int dimensions) where T : UnitOfMeasure
    {
        if (this is T)
        {
            return 1;
        }
        else
        {
            dynamic stayWithinFamily = this.IsSameFamily(typeof(T));
            double myMultiplier = ApplyDimensionsToMultiplier(this.GetMultiplier(stayWithinFamily), this.DimensionCount, dimensions);
            double otherMultiplier = ApplyDimensionsToMultiplier(UnitOfMeasureGlobals<T>.GlobalInstance.GetMultiplier(stayWithinFamily), UnitOfMeasureGlobals<T>.GlobalInstance.DimensionCount, dimensions);
            return myMultiplier / otherMultiplier;
        }
    }

    private static double ApplyDimensionsToMultiplier(double multiplier, int lengthDimensionCount, int requestedDimensionCount)
    {
        double newMultiplier = multiplier;
        for (int i = (lengthDimensionCount + 1); i <= requestedDimensionCount; i++)
        {
            newMultiplier *= multiplier;
        }
        return newMultiplier;
    }

}
