namespace NGenericDimensions.Volumes.MetricNonSI
{
    public abstract class MetricNonSIVolumeUnitOfMeasure : Length3DUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => stayWithinFamily ? 1 : 0.001;

        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure) => typeof(MetricNonSIVolumeUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
    }
}