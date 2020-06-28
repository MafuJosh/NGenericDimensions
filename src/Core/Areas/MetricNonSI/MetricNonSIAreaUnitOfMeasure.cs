namespace NGenericDimensions.Areas.MetricNonSI
{
    public abstract class MetricNonSIAreaUnitOfMeasure : Length2DUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily)
        {
            if (stayWithinFamily)
            {
                return 1;
            }
            else
            {
                return 10000;
            }
        }

        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure)
        {
            return typeof(MetricNonSIAreaUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        }
    }
}