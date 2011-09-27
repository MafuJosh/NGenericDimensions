using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace NGenericDimensions.Lengths.Uscs
{

    public abstract class UscsLengthUnitOfMeasure : Length1DUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            if (stayWithinFamily)
            {
                return 1;
            }
            else
            {
                return 0.3048;
            }
        }

        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure)
        {
            return typeof(UscsLengthUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        }

    }

}