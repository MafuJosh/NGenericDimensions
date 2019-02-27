using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace NGenericDimensions.Volumes
{

    public abstract class Length3DUnitOfMeasure : Lengths.LengthUnitOfMeasure
    {

        protected override int DimensionCount
        {
            get { return 3; }
        }

    }

}