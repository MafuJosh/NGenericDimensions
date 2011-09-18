using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace NGenericDimensions.Masses.MetricSI
{

    public abstract class SIMassUnitOfMeasure : MassUnitOfMeasure
    {

        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure)
        {
            return typeof(SIMassUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        }

    }

}