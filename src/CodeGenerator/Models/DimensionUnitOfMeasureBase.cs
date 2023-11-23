using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGenericDimensions.CodeGenerator
{
    public class DimensionUnitOfMeasureBase
    {
        public Dimension Dimension { get; set; }
        public bool Is1DInterface { get; set; }
        public bool Is2DInterface { get; set; }
        public bool Is3DInterface { get; set; }
        public string InterfaceName { get; set; }
        public string SubFolder { get; set; }
        public string UnitGroupName { get; set; }
        public DimensionUnitOfMeasureBase BaseInterface { get; set; }
        public string NonFamilyMultiplier { get; set; }
        public string Symbol2D { get; set; }
        public string Symbol3D { get; set; }
    }
}
