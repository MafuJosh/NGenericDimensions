using NGenericDimensions;
using NGenericDimensions.Areas.MetricNonSI;
using NGenericDimensions.Extensions;
using NGenericDimensions.Extensions.Numbers;
using NGenericDimensions.Lengths.MetricSI;
using NGenericDimensions.Lengths.Uscs;
using NGenericDimensions.MetricPrefix;
using System;
using System.Linq;
using Xunit;

namespace NGenericDimensionsUnitTests
{
    public class AreaTests : TestsHelperBBase
    {
        private static readonly Type[] actualUomsTypesOfArea
            = GetUnitOfMeasuresTypes<NGenericDimensions.Areas.Length2DUnitOfMeasure>(true, true)
            .Concat(GetUnitOfMeasuresTypes<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(true, true))
            .OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfAreaEvenWithoutIDefinedUnitOfMeasure
            = GetUnitOfMeasuresTypes<NGenericDimensions.Areas.Length2DUnitOfMeasure>(false, true)
            .Concat(GetUnitOfMeasuresTypes<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(false, true))
            .Where(o => o.Name != "Length2DUnitOfMeasure" 
                     && o.Name != "Length1DUnitOfMeasure" 
                     && o.Name != "UscsLengthUnitOfMeasure" 
                     && o.Name != "MetricSILengthUnitOfMeasure"
                     && o.Name != "MetricNonSIAreaUnitOfMeasure")
            .OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfUscsLengthUnitOfMeasure
            = GetUnitOfMeasuresTypes<UscsLengthUnitOfMeasure>(true, true).OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfSILengthUnitOfMeasure
            = GetUnitOfMeasuresTypes<MetricSILengthUnitOfMeasure>(true, true).OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfMetricNonSIAreaUnitOfMeasure
            = GetUnitOfMeasuresTypes<NGenericDimensions.Areas.MetricNonSI.MetricNonSIAreaUnitOfMeasure>(true, true).OrderBy(o => o.FullName).ToArray();

        [Fact]
        public void AreaUOMsBaseClassesAndInterfaces()
        {
            var expectedUomsOfMetricNonSIAreaUnitOfMeasure = new[] {
                typeof(Hectares)
            }.OrderBy(o => o.FullName);

            var expectedUomsOfUscsLengthUnitOfMeasure = new[] {
                typeof(Inches),
                typeof(Feet),
                typeof(Yards),
                typeof(Miles)
            }.OrderBy(o => o.FullName);

            var expectedUomsOfSILengthUnitOfMeasure = new[] {
                typeof(Kilometres),
                typeof(Micrometres),
                typeof(Millimetres),
                typeof(Nanometres),
                typeof(Metres<NoPrefix>),
                typeof(Metres<Deca>),
                typeof(Metres<Hecto>),
                typeof(Metres<Kilo>),
                typeof(Metres<Mega>),
                typeof(Metres<Giga>),
                typeof(Metres<Tera>),
                typeof(Metres<Peta>),
                typeof(Metres<Exa>),
                typeof(Metres<Zetta>),
                typeof(Metres<Yotta>),
                typeof(Metres<Deci>),
                typeof(Metres<Centi>),
                typeof(Metres<Milli>),
                typeof(Metres<Micro>),
                typeof(Metres<Nano>),
                typeof(Metres<Pico>),
                typeof(Metres<Femto>),
                typeof(Metres<Atto>),
                typeof(Metres<Zepto>),
                typeof(Metres<Yocto>),
                typeof(Metres)
            }.OrderBy(o => o.FullName);

            var expectedUomsOfArea
                = expectedUomsOfMetricNonSIAreaUnitOfMeasure
                .Concat(expectedUomsOfUscsLengthUnitOfMeasure)
                .Concat(expectedUomsOfSILengthUnitOfMeasure)
                .OrderBy(o => o.FullName);

            Assert.Equal(expectedUomsOfArea, actualUomsTypesOfArea);
            Assert.Equal(expectedUomsOfArea, actualUomsTypesOfAreaEvenWithoutIDefinedUnitOfMeasure);
            Assert.Equal(expectedUomsOfUscsLengthUnitOfMeasure, actualUomsTypesOfUscsLengthUnitOfMeasure);
            Assert.Equal(expectedUomsOfSILengthUnitOfMeasure, actualUomsTypesOfSILengthUnitOfMeasure);
            Assert.Equal(expectedUomsOfMetricNonSIAreaUnitOfMeasure, actualUomsTypesOfMetricNonSIAreaUnitOfMeasure);
        }

        [Fact]
        public void TestAreaConstructor()
        {
            var uomsToPass = GetUnitOfMeasuresTypeFullNames<NGenericDimensions.Areas.Length2DUnitOfMeasure>(true, true).Concat(GetUnitOfMeasuresTypeFullNames<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(true, true)).ToArray();
            var uomsToFail = GetUnitOfMeasuresTypeFullNames<NGenericDimensions.Areas.Length2DUnitOfMeasure>(true, false).Concat(GetUnitOfMeasuresTypeFullNames<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(true, false)).Except(uomsToPass).ToArray();

            // test valid and invalid units of measure for length
            Func<string, string> csharpCode = (t) => $@"_ = new NGenericDimensions.Area<{t}, double>(4.4);";
            foreach (var uomToPass in uomsToPass) AssertCompilationPasses(csharpCode(uomToPass));
            foreach (var uomToFail in uomsToFail) AssertCompilationFails("cannot be used as type parameter", csharpCode(uomToFail));

            // test common constructor tests
            TestConstructor(@"_ = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, {0});");

            // make sure value gets stored in member variable
            var areaB = new Area<Kilometres, Int32>(3);
            Assert.Equal(3, areaB.AreaValue);

            // make sure value can be constructed via its own kind of data type, and that it is an exact copy
            var areaC = new Area<Kilometres, Int32>(areaB);
            Assert.Equal(areaB.AreaValue, areaC.AreaValue);
            Assert.Equal(3, areaC.AreaValue);
            Assert.Same(areaB.AreaUnitOfMeasure, areaC.AreaUnitOfMeasure);

            // make sure value of different unit converts propertly via constructor.
            Assert.Equal(25000000, (new Area<Metres, Int32>(new Area<Kilometres, Int32>(25))).AreaValue);
            Assert.Equal(25000000, (new Area<Metres, Int32>(new Area<Kilometres, Int64>(25))).AreaValue);
            Assert.Equal(30250000, (new Area<Metres, Int32>(new Area<Kilometres, Decimal>(Convert.ToDecimal(30.25)))).AreaValue);
            Assert.Equal(30250000, (new Area<Metres, Int32>(new Area<Kilometres, Double>(30.25))).AreaValue);

            // test to make sure we can't use a dimension for the numeric datatype
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>>(44.4);");
        }

        [Fact]
        public void TestUnitOfMeasureProperty()
        {
            // make sure the UnitOfMeasure is actually the correct type
            Assert.Same(typeof(Kilometres), (new Area<Kilometres, Int32>(33)).AreaUnitOfMeasure.GetType());
            Assert.Same(typeof(Kilometres), ((IArea)(new Area<Kilometres, Int32>(33))).AreaUnitOfMeasure.GetType());
        }

        [Fact]
        public void TestAreaConvertToFunction()
        {
            var areaA = new Area<Kilometres, Int32>(25);
            var areaB = areaA.ConvertTo<Millimetres, Decimal>();
            Assert.Equal(25000000000000, areaB.AreaValue);
            Assert.Same(typeof(Millimetres), areaB.AreaUnitOfMeasure.GetType());
            var areaC = new Area<Kilometres, Int32>(25);
            var areaD = areaC.ConvertTo<decimal>();
            Assert.Equal(25, areaD.AreaValue);
            Assert.Same(typeof(decimal), areaD.AreaValue.GetType());
        }

        [Fact]
        public void TestAreaCastingOperators()
        {
            // implicit cast to area
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            Area<Millimetres, Double> areaA = 2.2;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            AssertCompilationFails("Cannot implicitly convert type", @"NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double> areaB = System.Convert.ToDecimal(5.5);");

            // explicit cast from length
            AssertCompilationFails("Cannot implicitly convert type", @"double areaB = (new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(3.3));");
            double areaB = (double)(new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(3.3));
            Assert.Equal(3.3, areaB);
        }

        [Fact]
        public void TestAreaAdditionOperators()
        {
            // adding 2 of the exact same area type ends up with the same type
            {
                var areaA = new Area<Feet, double>(2.2);
                var areaB = new Area<Feet, double>(3.3);
                var areaAB = areaA + areaB;
                Assert.Same(areaA.GetType(), areaAB.GetType());
                Assert.Same(areaB.GetType(), areaAB.GetType());
                Assert.Same(areaA.AreaValue.GetType(), areaAB.AreaValue.GetType());
                Assert.Same(areaB.AreaValue.GetType(), areaAB.AreaValue.GetType());
                Assert.Equal(5.5, areaAB.AreaValue);
            }

            // adding 2 of different types of areas should end up with the first one's uom as a system.double
            {
                var areaC = new Area<Feet, Int32>(2);
                var areaD = new Area<Feet, Byte>(8);
                var areaCD = areaC + areaD;
                Assert.Same(areaC.AreaUnitOfMeasure.GetType(), areaCD.AreaUnitOfMeasure.GetType());
                Assert.Same(typeof(double), areaCD.AreaValue.GetType());
                Assert.Equal(10, areaCD.AreaValue);
            }
            {
                var areaC = new Area<Inches, Int32>(5);
                var areaD = new Area<Feet, Byte>(2);
                var areaCD = areaC + areaD;
                Assert.Same(areaC.AreaUnitOfMeasure.GetType(), areaCD.AreaUnitOfMeasure.GetType());
                Assert.Same(typeof(double), areaCD.AreaValue.GetType());
                Assert.Equal(293, areaCD.AreaValue);
            }
            var areaE = new Area<Feet, double>(2.2);
            var areaF = areaE + 5; // c# calls implicit cast to change 5 to area so that it can use the + operator
            Assert.Equal(7.2, areaF.AreaValue);
            var areaG = 5 + areaE;
            Assert.Equal(7.2, areaG.AreaValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '+' cannot be applied", @"_ = (new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) + (new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestAreaSubtractionOperators()
        {
            // subtracting 2 of the exact same area type ends up with the same type
            {
                var areaA = new Area<Feet, double>(2.2);
                var areaB = new Area<Feet, double>(3.3);
                var areaAB = areaA - areaB;
                Assert.Same(areaA.GetType(), areaAB.GetType());
                Assert.Same(areaB.GetType(), areaAB.GetType());
                Assert.Same(areaA.AreaValue.GetType(), areaAB.AreaValue.GetType());
                Assert.Same(areaB.AreaValue.GetType(), areaAB.AreaValue.GetType());
                Assert.Equal(2.2 - 3.3, areaAB.AreaValue);
            }

            // subtracting 2 of different types of areas should end up with the first one's uon as a system.double
            {
                var areaC = new Area<Feet, Int32>(2);
                var areaD = new Area<Feet, Byte>(8);
                var areaCD = areaC - areaD;
                Assert.Same(areaC.AreaUnitOfMeasure.GetType(), areaCD.AreaUnitOfMeasure.GetType());
                Assert.Same(typeof(double), areaCD.AreaValue.GetType());
                Assert.Equal(-6, areaCD.AreaValue);
            }
            {
                var areaC = new Area<Inches, Int32>(5);
                var areaD = new Area<Feet, Byte>(2);
                var areaCD = areaC - areaD;
                Assert.Same(areaC.AreaUnitOfMeasure.GetType(), areaCD.AreaUnitOfMeasure.GetType());
                Assert.Same(typeof(double), areaCD.AreaValue.GetType());
                Assert.Equal(-283, areaCD.AreaValue);
            }
            var areaE = new Area<Feet, double>(2.2);
            var areaF = areaE - 5; // c# calls implicit cast to change 5 to area so that it can use the - operator
            Assert.Equal(2.2 - 5, areaF.AreaValue);
            var areaG = 5 - areaE;
            Assert.Equal(5 - 2.2, areaG.AreaValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '-' cannot be applied", @"_ = (new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) - (new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestAreaMultiplicationOperators()
        {
            // multiplying a area with a value should return the same kind of area with the value multiplied
            {
                var areaA = new Area<Inches, Int32>(7);
                var areaB = areaA * 3;
                Assert.Same(areaA.GetType(), areaB.GetType());
                Assert.Equal(21, areaB.AreaValue);
                var areaC = 3 * areaA;
                Assert.Same(areaA.GetType(), areaC.GetType());
                Assert.Equal(21, areaC.AreaValue);
            }
        }

        [Fact]
        public void TestAreaDivisionOperators()
        {
            // dividing a area by a scalar results with a area of the same uom and a datatype of double
            {
                var areaA = new Area<Millimetres, Int32>(10);
                {
                    var areaB = areaA / Convert.ToByte(2);
                    Assert.Same(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.Equal(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToInt16(2);
                    Assert.Same(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.Equal(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToInt32(2);
                    Assert.Same(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.Equal(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToInt64(2);
                    Assert.Same(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.Equal(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToDouble(2);
                    Assert.Same(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.Equal(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToSingle(2);
                    Assert.Same(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.Equal(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToDecimal(2);
                    Assert.Same(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.Equal(10 / 2, areaB.AreaValue);
                }
            }

            // dividing a area by a area results with a scalar of datatype of double.
            {
                var areaA = new Area<Millimetres, Int32>(10);
                var areaB = new Area<Millimetres, Byte>(2);
                var valueC = areaA / areaB;
                Assert.Same(typeof(double), valueC.GetType());
                Assert.Equal(10 / 2, valueC);
            }
        }

        [Fact]
        public void TestAreaComparisonOperators()
        {
            // compare when areas are exactly the same datatype
            {
                var areaA = new Area<Kilometres, Int32>(70);
                var areaB = new Area<Kilometres, Int32>(70);
                var areaC = new Area<Kilometres, Int32>(71);
                Assert.True(areaA == areaB);
                Assert.False(areaA == areaC);
                Assert.False(areaA != areaB);
                Assert.True(areaA != areaC);
                Assert.False(areaA > areaB);
                Assert.True(areaA >= areaB);
                Assert.False(areaA < areaB);
                Assert.True(areaA <= areaB);
                Assert.False(areaA > areaC);
                Assert.False(areaA >= areaC);
                Assert.True(areaA < areaC);
                Assert.True(areaA <= areaC);
                Assert.False(areaC < areaA);
                Assert.False(areaC <= areaA);
                Assert.True(areaC > areaA);
                Assert.True(areaC >= areaA);
            }

            // compare an area to a scalar
            {
                var areaA = new Area<Kilometres, Int32>(70);
                var areaB = Convert.ToInt32(70);
                var areaC = Convert.ToInt32(71);
                Assert.True(areaA == areaB);
                Assert.True(areaB == areaA);
                Assert.False(areaA == areaC);
                Assert.False(areaC == areaA);
                Assert.False(areaA != areaB);
                Assert.False(areaB != areaA);
                Assert.True(areaA != areaC);
                Assert.True(areaC != areaA);
                Assert.False(areaA > areaB);
                Assert.True(areaA >= areaB);
                Assert.False(areaA < areaB);
                Assert.True(areaA <= areaB);
                Assert.False(areaA > areaC);
                Assert.False(areaA >= areaC);
                Assert.True(areaA < areaC);
                Assert.True(areaA <= areaC);
                Assert.False(areaC < areaA);
                Assert.False(areaC <= areaA);
                Assert.True(areaC > areaA);
                Assert.True(areaC >= areaA);
            }

            // compare an area of one datatype to an area of another
            {
                var areaA = new Area<Kilometres, Int32>(70);
                var areaB = new Area<Kilometres, Byte>(70);
                var areaC = new Area<Kilometres, Byte>(71);
                Assert.True(areaA == areaB);
                Assert.False(areaA == areaC);
                Assert.False(areaA != areaB);
                Assert.True(areaA != areaC);
                Assert.False(areaA > areaB);
                Assert.True(areaA >= areaB);
                Assert.False(areaA < areaB);
                Assert.True(areaA <= areaB);
                Assert.False(areaA > areaC);
                Assert.False(areaA >= areaC);
                Assert.True(areaA < areaC);
                Assert.True(areaA <= areaC);
                Assert.False(areaC < areaA);
                Assert.False(areaC <= areaA);
                Assert.True(areaC > areaA);
                Assert.True(areaC >= areaA);
            }

            // compare an area of a different uom
            {
                var areaA = new Area<Feet, Int32>(2);
                var areaB = new Area<Inches, Int16>(288);
                var areaC = new Area<Inches, Int16>(293);
                Assert.True(areaA == areaB);
                Assert.False(areaA == areaC);
                Assert.False(areaA != areaB);
                Assert.True(areaA != areaC);
                Assert.False(areaA > areaB);
                Assert.True(areaA >= areaB);
                Assert.False(areaA < areaB);
                Assert.True(areaA <= areaB);
                Assert.False(areaA > areaC);
                Assert.False(areaA >= areaC);
                Assert.True(areaA < areaC);
                Assert.True(areaA <= areaC);
                Assert.False(areaC < areaA);
                Assert.False(areaC <= areaA);
                Assert.True(areaC > areaA);
                Assert.True(areaC >= areaA);
            }

            // compare an area to some other dimension
            AssertCompilationFails(@"Operator '==' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) == (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '!=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) != (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) < (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) <= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) > (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) >= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
        }

        [Fact]
        public void TestAreaIDimensionValue()
        {
            Assert.Equal(Convert.ToDouble(4), ((IDimension)(new Area<Kilometres, Int32>(4))).Value);
        }

        [Fact]
        public void TestAreaToString()
        {
            Assert.Equal((4.4).ToString() + " Square Feet", (new Area<Feet, double>(4.4)).ToString());
            Assert.Equal((4.4).ToString() + " Square Feet", (new Area<Feet, double>(4.4)).ToString("LU", null));
            Assert.Equal((4.4).ToString() + " sq. ft.", (new Area<Feet, double>(4.4)).ToString("SU", null));
            Assert.Equal((4.4).ToString(), (new Area<Feet, double>(4.4)).ToString("NU", null));
            Assert.Equal((4.4).ToString() + " Square Millimetres", (new Area<Millimetres, double>(4.4)).ToString());
            Assert.Equal((4.4).ToString() + " Square Millimetres", (new Area<Millimetres, double>(4.4)).ToString("LU", null));
            Assert.Equal((4.4).ToString() + " mm²", (new Area<Millimetres, double>(4.4)).ToString("SU", null));
            Assert.Equal((4.4).ToString(), (new Area<Millimetres, double>(4.4)).ToString("NU", null));
        }

        [Fact]
        public void TestAreaNumberExtensions()
        {
            Assert.Same(typeof(Area<Kilometres, Int32>), (5).square().kilometres().GetType());
            Assert.Equal(444, (444).square().kilometres().AreaValue);
            Assert.Equal(Convert.ToInt16(444), ((Area<Kilometres, Int16>?)(444)).AreaValue().Value);
            Assert.Null(((Area<Kilometres, Int16>?)(null)).AreaValue());
        }
    }
}
