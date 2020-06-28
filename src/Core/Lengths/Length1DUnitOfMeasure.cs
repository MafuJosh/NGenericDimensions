namespace NGenericDimensions.Lengths
{
    public abstract class Length1DUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or2, IExponent1Or3
    {
        internal protected virtual string AreaUnitSymbol => UnitSymbol + @"²";

        internal protected virtual string VolumeUnitSymbol => UnitSymbol + @"³";
    }
}