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