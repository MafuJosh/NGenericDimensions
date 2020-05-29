using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace NGenericDimensions.Durations
{

    public abstract class StandardDurationUnitOfMeasure : DurationUnitOfMeasure
    {

        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure)
        {
            return typeof(DurationUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        }

    }

}