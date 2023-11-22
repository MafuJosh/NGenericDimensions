using NGenericDimensions.Lengths;

namespace NGenericDimensions.Areas
{
    public abstract class Length2DUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or2
    {
        protected override int Exponent => 2;
        
    }
}