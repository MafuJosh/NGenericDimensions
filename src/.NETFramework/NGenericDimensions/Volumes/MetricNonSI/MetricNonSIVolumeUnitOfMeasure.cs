using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace NGenericDimensions.Volumes.MetricNonSI
{

    public abstract class MetricNonSIVolumeUnitOfMeasure : Length3DUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            if (stayWithinFamily)
            {
                return 1;
            }
            else
            {
                return 0.001;
            }
        }

        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure)
        {
            return typeof(MetricNonSIVolumeUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        }

    }

}