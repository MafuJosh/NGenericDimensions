namespace NGenericDimensions.Durations
{
    public abstract class StandardDurationUnitOfMeasure : DurationUnitOfMeasure
    {
        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure) => typeof(StandardDurationUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        
    }
}