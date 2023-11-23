using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using NGenericDimensions;
using System;
using System.Linq;
using Xunit;

namespace NGenericDimensionsUnitTests
{
    public class TestsHelperBBase
    {
        protected readonly static string[] ValidDataTypeConversions =
            {
            @"System.Char>(System.Convert.ToChar(4)", // this works in .net6 but not in an earlier one i think
            @"System.Double>(System.Convert.ToDouble(4.44444)",
            @"System.Double>(System.Convert.ToSingle(4.44444)",
            @"System.Single>(System.Convert.ToSingle(4.44444)",
            @"System.Decimal>(System.Convert.ToDecimal(4.44444)",
            @"System.Int64>(System.Convert.ToInt64(4)",
            @"System.Int32>(System.Convert.ToInt32(4)",
            @"System.Int32>(System.Convert.ToInt16(4)",
            @"System.Int32>(System.Convert.ToByte(4)",
            @"System.Int16>(System.Convert.ToInt16(4)",
            @"System.Byte>(System.Convert.ToByte(4)",
            @"System.SByte>(System.Convert.ToSByte(4)",
            @"System.UInt16>(System.Convert.ToUInt16(4)",
            @"System.UInt32>(System.Convert.ToUInt32(4)",
            @"System.UInt64>(System.Convert.ToUInt64(4)",
            @"System.DateTime>(new System.DateTime(1000)", // can't stop this from being allowed
            @"System.Numerics.BigInteger>(new System.Numerics.BigInteger(4.4)"
            };

        protected readonly static string[] InvalidDataTypeConversions =
            {
            @"System.Boolean>(System.Convert.ToBoolean(4)"
            };

        protected readonly static string[] CannotConvertDataTypeConversions =
            {
            @"System.Int32>(System.Convert.ToInt64(4)"
            };

        protected static void TestConstructor(string dataTypeTest)
        {
            foreach (var validDataTypeConversion in ValidDataTypeConversions)
                AssertCompilationPasses(string.Format(null, dataTypeTest, new[]{ validDataTypeConversion}));
            foreach (var invalidDataTypeConversion in InvalidDataTypeConversions)
                AssertCompilationFails("cannot be used as type parameter", string.Format(null, dataTypeTest, new[] { invalidDataTypeConversion }));
            foreach (var cannotConvertDataTypeConversion in CannotConvertDataTypeConversions)
                AssertCompilationFails("cannot convert from", string.Format(null, dataTypeTest, new[] { cannotConvertDataTypeConversion }));
        }

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

        protected static void AssertCompilationPasses(string csharpline)
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

            Assert.Empty(diagnostics);
        }

        protected static Type[] GetUnitOfMeasuresTypes<TDimension>(bool mustImplementIDefinedUnitOfMeasure, bool inclusive) where TDimension : UnitOfMeasure
        {
            var metricPrefixes = typeof(NGenericDimensions.ILength)
                .Assembly
                .GetTypes()
                .Where(o => typeof(NGenericDimensions.MetricPrefix.MetricPrefixBase).IsAssignableFrom(o))
                .Where(o => o != typeof(NGenericDimensions.MetricPrefix.MetricPrefixBase))
                .ToArray();

            return
                typeof(NGenericDimensions.ILength)
                .Assembly
                .GetTypes()
                .Where(o => !mustImplementIDefinedUnitOfMeasure || typeof(IDefinedUnitOfMeasure).IsAssignableFrom(o))
                .Where(o => !o.IsInterface)
                .Where(o => inclusive == typeof(TDimension).IsAssignableFrom(o))
                .SelectMany(o => o.IsGenericType
                    ? metricPrefixes.Select(m => o.MakeGenericType(m))
                    : new[] { o })
                .ToArray();
        }

        protected static string[] GetUnitOfMeasuresTypeFullNames<TDimension>(bool mustImplementIDefinedUnitOfMeasure, bool inclusive) where TDimension : UnitOfMeasure
        {
            var metricPrefixes = typeof(NGenericDimensions.ILength)
                .Assembly
                .GetTypes()
                .Where(o => typeof(NGenericDimensions.MetricPrefix.MetricPrefixBase).IsAssignableFrom(o))
                .Where(o => o != typeof(NGenericDimensions.MetricPrefix.MetricPrefixBase))
                .ToArray();

            return
                typeof(NGenericDimensions.ILength)
                .Assembly
                .GetTypes()
                .Where(o => !mustImplementIDefinedUnitOfMeasure || typeof(IDefinedUnitOfMeasure).IsAssignableFrom(o))
                .Where(o => !o.IsInterface)
                .Where(o => inclusive == typeof(TDimension).IsAssignableFrom(o))
                .SelectMany(o => o.IsGenericType
                    ? metricPrefixes.Select(m => $@"{o.FullName.Split('`')[0]}<{m.FullName}>") 
                    : new[] { o.FullName })
                .ToArray();
        }
    }
}
