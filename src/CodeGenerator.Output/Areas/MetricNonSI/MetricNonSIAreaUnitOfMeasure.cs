namespace NGenericDimensions.Areas.MetricNonSI
{
    public abstract class MetricNonSIAreaUnitOfMeasure : Length2DUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => stayWithinFamily ? 1 : 10000;
        
        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure) => typeof(MetricNonSIAreaUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        
    }
}