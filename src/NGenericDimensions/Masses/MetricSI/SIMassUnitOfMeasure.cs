namespace NGenericDimensions.Masses.MetricSI
{
    public abstract class SIMassUnitOfMeasure : MassUnitOfMeasure
    {
        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure) => typeof(SIMassUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
    }
}