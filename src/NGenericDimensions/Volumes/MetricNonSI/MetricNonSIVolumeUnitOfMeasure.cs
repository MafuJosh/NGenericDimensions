namespace NGenericDimensions.Volumes.MetricNonSI
{

    public abstract class MetricNonSIVolumeUnitOfMeasure : Length3DUnitOfMeasure
    {

        protected override double GetMultiplier(bool stayWithinFamily)
        {
            if (stayWithinFamily)
            {
                return 1;
            }
            else
            {
                return 0.001;
            }
        }

        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure)
        {
            return typeof(MetricNonSIVolumeUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        }

    }

}