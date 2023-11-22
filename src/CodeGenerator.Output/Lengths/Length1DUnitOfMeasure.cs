namespace NGenericDimensions.Lengths
{
    public abstract class Length1DUnitOfMeasure : LengthUnitOfMeasure, IExponent1Or2, IExponent1Or3
    {
        protected internal virtual string AreaUnitSymbol => $@"{UnitSymbol}²";
        
        protected internal virtual string VolumeUnitSymbol => $@"{UnitSymbol}³";
        
    }
}