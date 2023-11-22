using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGenericDimensions.CodeGenerator
{
    public class Unit
    {
        public string NameUppercase { get; set; }
        public string NamePluralUppercase { get; set; }
        public string NameLowercase { get; set; }
        public string NamePluralLowercase { get; set; }
        public Dimension Dimension { get; set; }
        public string SubFolder { get; set; }
        public string UnitGroupName { get; set; }
        public string UnitSymbol { get; set; }
        public string Namespace { get; set; }
        public string FullClassName { get; set; }
        public string SIPrefix { get; set; }
        public bool InheritsSIPrefix { get; set; }
        public string MetricBaseClassName { get; set; }
        public bool IsMetricBaseUnit { get; set; }
        public Unit FamilyBaseUnit { get; set; }
        public string FamilyMultiplier { get; set; }
        public string FamilyDivisor { get; set; }
        public Unit SIBaseUnit { get; set; }
        public string SIMultiplier { get; set; }
        public string SIDivisor { get; set; }
        public string SquaredSymbol { get; set; }
        public string CubedSymbol { get; set; }
        public bool IsDerivedUnit { get; set; }
    }
}
