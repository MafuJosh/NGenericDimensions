namespace NGenericDimensions.Lengths.MetricSI
{
    public abstract class SILengthUnitOfMeasure : Length1DUnitOfMeasure
    {
        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure) => typeof(SILengthUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
    }
}