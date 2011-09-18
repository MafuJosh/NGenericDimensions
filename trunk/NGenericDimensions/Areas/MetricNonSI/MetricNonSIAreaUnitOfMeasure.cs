using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NGenericDimensions.Areas.MetricNonSI
{

    public abstract class MetricNonSIAreaUnitOfMeasure : Length2DUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            if (stayWithinFamily)
            {
                return 1;
            }
            else
            {
                return 10000;
            }
        }

        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure)
        {
            return typeof(MetricNonSIAreaUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        }

    }

}