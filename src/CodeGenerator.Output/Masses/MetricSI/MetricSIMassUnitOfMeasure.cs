namespace NGenericDimensions.Masses.MetricSI
{
    public abstract class MetricSIMassUnitOfMeasure : MassUnitOfMeasure
    {
        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure) => typeof(MetricSIMassUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        
    }
}