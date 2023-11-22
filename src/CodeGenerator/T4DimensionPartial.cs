namespace NGenericDimensions.CodeGenerator
{
    public partial class T4Dimension
    {
        private readonly Dimension dimension;
        private readonly Dimension[] dimensions;
        private readonly SIPrefix[] siPrefixes;

        public T4Dimension(Dimension dimension, Dimension[] dimensions, SIPrefix[] siPrefixes)
        {
            this.dimension = dimension;
            this.dimensions = dimensions;
            this.siPrefixes = siPrefixes;
        }
    }
}
