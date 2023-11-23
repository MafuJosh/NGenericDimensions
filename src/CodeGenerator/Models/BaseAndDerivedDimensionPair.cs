using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGenericDimensions.CodeGenerator
{
    public class BaseAndDerivedDimensionPair
    {
        // DerivedDimension would be the dimension on the left side in the csv
        // BaseDimension would be the dimension on the top in the csv
        // UnitOfMeasureBase would be the what???
        // MostSpecificCommonDimensionUnitOfMeasureBase would be the UnitOfMeasureBase class that is the most specific common base class, to support when a dimension is squared or cubed, etc.
        // ModeDimension would be the dimension on the top in the csv, with the mode applied (so Area instead of Length, for example)

        public Dimension BaseDimension { get; set; }
        public Dimension DerivedDimension { get; set; }
        public Dimension ModeDimension { get; set; }
        public int Mode { get; set; }
        public DimensionUnitOfMeasureBase UnitOfMeasureBase {get;set;}

        public DimensionUnitOfMeasureBase MostSpecificCommonDimensionUnitOfMeasureBase
        {
            get
            {
                // for normal things like Mass, this will return MassUnitOfMeasureBase
                if (!UnitOfMeasureBase.Is1DInterface && !UnitOfMeasureBase.Is2DInterface && !UnitOfMeasureBase.Is3DInterface) return UnitOfMeasureBase;

                // for Length, this will return Length1DUnitOfMeasureBase
                if (Mode == 1 && UnitOfMeasureBase.Is1DInterface) return UnitOfMeasureBase;
                
                // for Area, this will return LengthUnitOfMeasureBase
                // for Volume, this will return LengthUnitOfMeasureBase
                return UnitOfMeasureBase.BaseInterface;
            }
        }

        public bool IsBaseInNumerator => Mode > 0;
        public bool IsBaseInNumeratorWithADenominator => IsBaseInNumerator && DerivedDimension.BaseDimensionsThisDerivedFromInDenominator.Length > 0;
        public bool IsBaseInDenominator => Mode < 0;
        public override int GetHashCode() => base.GetHashCode();

        public override bool Equals(object obj)
        {
            return (obj is BaseAndDerivedDimensionPair objA)
                && objA.BaseDimension == BaseDimension
                && objA.DerivedDimension == DerivedDimension
                && objA.Mode == Mode
                && objA.UnitOfMeasureBase == UnitOfMeasureBase;
        }

        public BaseAndDerivedDimensionPair Inverted()
        {
            return new BaseAndDerivedDimensionPair
            {
                BaseDimension = BaseDimension,
                DerivedDimension = DerivedDimension,
                Mode = -Mode,
                UnitOfMeasureBase = UnitOfMeasureBase
            };
        }
    }
}