namespace NGenericDimensions.Lengths.Uscs
{
    public abstract class UscsLengthUnitOfMeasure : Length1DUnitOfMeasure
    {
        protected override double GetMultiplier(bool stayWithinFamily) => stayWithinFamily ? 1 : 0.3048;

        protected override bool IsSameFamily(System.Type typeOfUnitOfMeasure) => typeof(UscsLengthUnitOfMeasure).IsAssignableFrom(typeOfUnitOfMeasure);

        protected internal override string AreaUnitSymbol => @"sq. " + UnitSymbol;

        protected internal override string VolumeUnitSymbol => @"cu. " + UnitSymbol;
    }

}