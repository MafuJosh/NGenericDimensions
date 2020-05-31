namespace NGenericDimensions.Lengths
{

    public abstract class Length1DUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or2, IExponent1Or3
    {
        internal protected virtual string AreaUnitSymbol
        {
            get
            {
                return UnitSymbol + @"²";
            }
        }

        internal protected virtual string VolumeUnitSymbol
        {
            get
            {
                return UnitSymbol + @"³";
            }
        }
    }

}