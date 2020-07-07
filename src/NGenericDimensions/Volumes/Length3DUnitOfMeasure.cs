using NGenericDimensions.Lengths;

namespace NGenericDimensions.Volumes
{
    public abstract class Length3DUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or3
    {
        protected override int Exponent => 3;
    }
}