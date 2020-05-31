namespace NGenericDimensions.Volumes
{

    public abstract class Length3DUnitOfMeasure : Lengths.LengthUnitOfMeasure, IExponent1Or3
    {

        protected override int Exponent
        {
            get { return 3; }
        }

    }

}