using NGenericDimensions.CodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGenericDimensions.CodeGenerator
{
    public class Dimension
    {
        public string NameUppercase { get; set; }
        public string NamePluralUppercase { get; set; }
        public string NameLowercase { get; set; }
        public string NamePluralLowercase { get; set; }
        public Unit[] Units { get; set; }
        public bool IsBaseDimension { get; set; }
        public bool IsDerivedDimension { get; set; }
        public BaseAndDerivedDimensionPair[] BaseDimensionsThisDerivedFrom { get; set; }
        public BaseAndDerivedDimensionPair[] DerivedDimensionsFromThisBase { get; set; }
        public bool IsUsedExponentiallyInDimensions { get; set; }
        //public ProductWithDimensionBEqualsDimensionC[] ProductWithDimensionBEqualsDimensionC { get; set; } = new ProductWithDimensionBEqualsDimensionC[0];
        public bool IsPerSource { get; set; }
        public BaseAndDerivedDimensionPair[] BaseDimensionsThisDerivedFromInNumerator { get; set; }
        public BaseAndDerivedDimensionPair[] BaseDimensionsThisDerivedFromInDenominator { get; set; }
        public bool IsSquaredDimension { get; set; }
        public bool IsCubedDimension { get; set; }
        public bool IsSquaredOrCubedDimension { get; set; }
    }
}
