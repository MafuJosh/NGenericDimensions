using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Xunit;

namespace NGenericDimensionsUnitTests
{
    public class TestsHelperBBase
    {
        protected static void AssertCompilationFails(string expectedError, string csharpline)
        {
            try
            {
                var references = new[] {
                    typeof(System.String).Assembly,
                    typeof(System.Numerics.BigInteger).Assembly,
                    typeof(NGenericDimensions.Masses.MetricSI.Grams).Assembly
                };

                var diagnostics = CSharpScript.Create(
                    csharpline,
                    ScriptOptions.Default.WithReferences(references))
                    .Compile();

                Assert.NotEmpty(diagnostics);
                Assert.All(diagnostics, d => Assert.Contains(expectedError, $"{d.Severity} {d.Id}: {d.GetMessage()}"));
            }
            catch (CompilationErrorException e)
            {
                Assert.Equal(expectedError, e.Message);
            }
        }
    }
}
