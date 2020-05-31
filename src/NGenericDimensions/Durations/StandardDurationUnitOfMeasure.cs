namespace NGenericDimensions.Durations
{
    public abstract class StandardDurationUnitOfMeasure : DurationUnitOfMeasure
    {

        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure)
        {
            return typeof(DurationUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);
        }

    }

}