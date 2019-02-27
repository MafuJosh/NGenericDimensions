using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace NGenericDimensions.Areas
{

    public abstract class Length2DUnitOfMeasure : Lengths.LengthUnitOfMeasure
    {

        protected override int DimensionCount
        {
            get { return 2; }
        }

    }

}