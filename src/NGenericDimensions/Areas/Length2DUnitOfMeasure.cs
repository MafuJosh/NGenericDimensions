using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace NGenericDimensions.Areas
{

    public abstract class Length2DUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or2
    {

        protected override int Exponent
        {
            get { return 2; }
        }
    }

}