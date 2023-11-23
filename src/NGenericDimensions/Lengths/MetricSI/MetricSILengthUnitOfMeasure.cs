namespace NGenericDimensions.Lengths.MetricSI
{
    public abstract class MetricSILengthUnitOfMeasure : Length1DUnitOfMeasure
    {
        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure) => typeof(MetricSILengthUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        
    }
}