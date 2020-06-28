using NGenericDimensions;
using NGenericDimensions.Durations;
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
    public class LengthTests : TestsHelperBBase
    {
        private static readonly Type[] actualUomsTypesOfLength1DUnitOfMeasure
            = GetUnitOfMeasuresTypes<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(true, true).OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfLength1DUnitOfMeasureEvenWithoutIDefinedUnitOfMeasure
            = GetUnitOfMeasuresTypes<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(false, true)
            .Where(o => o.Name != "Length1DUnitOfMeasure" 
                     && o.Name != "UscsLengthUnitOfMeasure" 
                     && o.Name != "SILengthUnitOfMeasure")
            .OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfUscsLengthUnitOfMeasure
            = GetUnitOfMeasuresTypes<UscsLengthUnitOfMeasure>(true, true).OrderBy(o => o.FullName).ToArray();
        
        private static readonly Type[] actualUomsTypesOfSILengthUnitOfMeasure
            = GetUnitOfMeasuresTypes<SILengthUnitOfMeasure>(true, true).OrderBy(o => o.FullName).ToArray();

        [Fact]
        public void LengthUOMsBaseClassesAndInterfaces()
        {
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

            var expectedUomsOfLength1DUnitOfMeasure 
                = expectedUomsOfUscsLengthUnitOfMeasure
                .Concat(expectedUomsOfSILengthUnitOfMeasure)
                .OrderBy(o => o.FullName);

            Assert.Equal(expectedUomsOfLength1DUnitOfMeasure, actualUomsTypesOfLength1DUnitOfMeasure);
            Assert.Equal(expectedUomsOfLength1DUnitOfMeasure, actualUomsTypesOfLength1DUnitOfMeasureEvenWithoutIDefinedUnitOfMeasure);
            Assert.Equal(expectedUomsOfUscsLengthUnitOfMeasure, actualUomsTypesOfUscsLengthUnitOfMeasure);
            Assert.Equal(expectedUomsOfSILengthUnitOfMeasure, actualUomsTypesOfSILengthUnitOfMeasure);
        }

        [Fact]
        public void TestLengthConstructor()
        {
            var uomsToPass = GetUnitOfMeasuresTypeFullNames<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(true, true);
            var uomsToFail = GetUnitOfMeasuresTypeFullNames<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(true, false);

            // test valid and invalid units of measure for length
            Func<string, string> csharpCode = (t) => $@"_ = new NGenericDimensions.Length<{t}, double>(4.4);";
            foreach (var uomToPass in uomsToPass) AssertCompilationPasses(csharpCode(uomToPass));
            foreach (var uomToFail in uomsToFail) AssertCompilationFails("cannot be used as type parameter", csharpCode(uomToFail));

            // test common constructor tests
            TestConstructor(@"_ = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, {0});");

            // make sure value gets stored in member variable
            var lengthB = new Length<NGenericDimensions.Lengths.MetricSI.Kilometres, Int32>(3);
            Assert.Equal(3, lengthB.LengthValue);

            // make sure value can be constructed via its own kind of data type, and that it is an exact copy
            var lengthC = new Length<NGenericDimensions.Lengths.MetricSI.Kilometres, Int32>(lengthB);
            Assert.Equal(lengthB.LengthValue, lengthC.LengthValue);
            Assert.Equal(3, lengthC.LengthValue);
            Assert.Same(lengthB.UnitOfMeasure, lengthC.UnitOfMeasure);

            // make sure value of different unit converts propertly via constructor.
            Assert.Equal(5000, (new Length<NGenericDimensions.Lengths.MetricSI.Metres, Int32>(new Length<NGenericDimensions.Lengths.MetricSI.Kilometres, Int32>(5))).LengthValue);
            Assert.Equal(5000, (new Length<NGenericDimensions.Lengths.MetricSI.Metres, Int32>(new Length<NGenericDimensions.Lengths.MetricSI.Kilometres, Int64>(5))).LengthValue);
            Assert.Equal(5500, (new Length<NGenericDimensions.Lengths.MetricSI.Metres, Int32>(new Length<NGenericDimensions.Lengths.MetricSI.Kilometres, Decimal>(Convert.ToDecimal(5.5)))).LengthValue);
            Assert.Equal(5500, (new Length<NGenericDimensions.Lengths.MetricSI.Metres, Int32>(new Length<NGenericDimensions.Lengths.MetricSI.Kilometres, Double>(5.5))).LengthValue);

            // test to make sure we can't use a dimension for the numeric datatype
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>>(44.4);");
        }

        [Fact]
        public void TestUnitOfMeasureProperty()
        {
            // make sure the UnitOfMeasure is actually the correct type
            Assert.Same(typeof(NGenericDimensions.Lengths.MetricSI.Kilometres), (new Length<NGenericDimensions.Lengths.MetricSI.Kilometres, Int32>(33)).UnitOfMeasure.GetType());
            Assert.Same(typeof(NGenericDimensions.Lengths.MetricSI.Kilometres), ((ILength)(new Length<NGenericDimensions.Lengths.MetricSI.Kilometres, Int32>(33))).UnitOfMeasure.GetType());
        }

        [Fact]
        public void TestLengthConvertToFunction()
        {
            var lengthA = new Length<NGenericDimensions.Lengths.MetricSI.Kilometres, Int32>(333);
            var lengthB = lengthA.ConvertTo<NGenericDimensions.Lengths.MetricSI.Millimetres, Decimal>();
            Assert.Equal(333000000, lengthB.LengthValue);
            Assert.Same(typeof(NGenericDimensions.Lengths.MetricSI.Millimetres), lengthB.UnitOfMeasure.GetType());
            var lengthC = new Length<NGenericDimensions.Lengths.MetricSI.Kilometres, Int32>(333);
            var lengthD = lengthC.ConvertTo<decimal>();
            Assert.Equal(333, lengthD.LengthValue);
            Assert.Same(typeof(decimal), lengthD.LengthValue.GetType());
        }

        [Fact]
        public void TestLengthCastingOperators()
        {
            // implicit cast to length
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            Length<NGenericDimensions.Lengths.MetricSI.Millimetres, Double> lengthA = 2.2;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            AssertCompilationFails("Cannot implicitly convert type", @"NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double> lengthB = System.Convert.ToDecimal(5.5);");

            // explicit cast from length
            AssertCompilationFails("Cannot implicitly convert type", @"double lengthB = (new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(3.3));");
            double lengthB = (double)(new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(3.3));
            Assert.Equal(3.3, lengthB);
        }

        [Fact]
        public void TestLengthAdditionOperators()
        {
            // adding 2 of the exact same length type ends up with the same type
            {
                var lengthA = new Length<Feet, double>(2.2);
                var lengthB = new Length<Feet, double>(3.3);
                var lengthAB = lengthA + lengthB;
                Assert.Same(lengthA.GetType(), lengthAB.GetType());
                Assert.Same(lengthB.GetType(), lengthAB.GetType());
                Assert.Same(lengthA.LengthValue.GetType(), lengthAB.LengthValue.GetType());
                Assert.Same(lengthB.LengthValue.GetType(), lengthAB.LengthValue.GetType());
                Assert.Equal(5.5, lengthAB.LengthValue);
            }

            // adding 2 of different types of lengths should end up with the first one's uom as a system.double
            {
                var lengthC = new Length<Feet, Int32>(2);
                var lengthD = new Length<Feet, Byte>(8);
                var lengthCD = lengthC + lengthD;
                Assert.Same(lengthC.UnitOfMeasure.GetType(), lengthCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), lengthCD.LengthValue.GetType());
                Assert.Equal(10, lengthCD.LengthValue);
            }
            {
                var lengthC = new Length<Inches, Int32>(5);
                var lengthD = new Length<Feet, Byte>(2);
                var lengthCD = lengthC + lengthD;
                Assert.Same(lengthC.UnitOfMeasure.GetType(), lengthCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), lengthCD.LengthValue.GetType());
                Assert.Equal(29, lengthCD.LengthValue);
            }
            var lengthE = new Length<Feet, double>(2.2);
            var lengthF = lengthE + 5; // c# calls implicit cast to change 5 to length so that it can use the + operator
            Assert.Equal(7.2, lengthF.LengthValue);
            var lengthG = 5 + lengthE;
            Assert.Equal(7.2, lengthG.LengthValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '+' cannot be applied", @"_ = (new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) + (new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestLengthSubtractionOperators()
        {
            // subtracting 2 of the exact same length type ends up with the same type
            {
                var lengthA = new Length<Feet, double>(2.2);
                var lengthB = new Length<Feet, double>(3.3);
                var lengthAB = lengthA - lengthB;
                Assert.Same(lengthA.GetType(), lengthAB.GetType());
                Assert.Same(lengthB.GetType(), lengthAB.GetType());
                Assert.Same(lengthA.LengthValue.GetType(), lengthAB.LengthValue.GetType());
                Assert.Same(lengthB.LengthValue.GetType(), lengthAB.LengthValue.GetType());
                Assert.Equal(2.2 - 3.3, lengthAB.LengthValue);
            }

            // subtracting 2 of different types of lengths should end up with the first one's uon as a system.double
            {
                var lengthC = new Length<Feet, Int32>(2);
                var lengthD = new Length<Feet, Byte>(8);
                var lengthCD = lengthC - lengthD;
                Assert.Same(lengthC.UnitOfMeasure.GetType(), lengthCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), lengthCD.LengthValue.GetType());
                Assert.Equal(-6, lengthCD.LengthValue);
            }
            {
                var lengthC = new Length<Inches, Int32>(5);
                var lengthD = new Length<Feet, Byte>(2);
                var lengthCD = lengthC - lengthD;
                Assert.Same(lengthC.UnitOfMeasure.GetType(), lengthCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), lengthCD.LengthValue.GetType());
                Assert.Equal(-19, lengthCD.LengthValue);
            }
            var lengthE = new Length<Feet, double>(2.2);
            var lengthF = lengthE - 5; // c# calls implicit cast to change 5 to length so that it can use the - operator
            Assert.Equal(2.2 - 5, lengthF.LengthValue);
            var lengthG = 5 - lengthE;
            Assert.Equal(5 - 2.2, lengthG.LengthValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '-' cannot be applied", @"_ = (new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) - (new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestLengthMultiplicationOperators()
        {
            // multiplying a length with a value should return the same kind of length with the value multiplied
            {
                var lengthA = new Length<Inches, Int32>(7);
                var lengthB = lengthA * 3;
                Assert.Same(lengthA.GetType(), lengthB.GetType());
                Assert.Equal(21, lengthB.LengthValue);
                var lengthC = 3 * lengthA;
                Assert.Same(lengthA.GetType(), lengthC.GetType());
                Assert.Equal(21, lengthC.LengthValue);
            }

            // multiplying 2 lengths of the same type gives us a nicely defined Area
            {
                var lengthA = new Length<Inches, Int32>(7);
                var lengthB = new Length<Inches, Int32>(4);
                var areaAB = lengthA * lengthB;
                Assert.Same(typeof(Area<Inches, Int32>), areaAB.GetType());
                Assert.Equal(7 * 4, areaAB.AreaValue);
                Assert.Same(typeof(Inches), areaAB.UnitOfMeasure.GetType());
            }

            // multiplying 2 lengths of differing types gives us an Area with a uom of the first type and a datatype of double
            {
                var lengthA = new Length<Inches, Int32>(7);
                var lengthB = new Length<Feet, Byte>(2);
                var areaAB = lengthA * lengthB;
                Assert.Same(typeof(Area<Inches, double>), areaAB.GetType());
                Assert.Equal(2 * 12 * 7, areaAB.AreaValue);
                Assert.Same(typeof(Inches), areaAB.UnitOfMeasure.GetType());
            }

            // multiplying a length by an area that share the same length uom and same datatype gives us a Volume of the same uom and datatype
            {
                var lengthA = new Length<Inches, Int32>(3);
                var areaB = new Area<Inches, Int32>(4);
                var volumeAB = lengthA * areaB;
                Assert.Same(typeof(Volume<Inches, Int32>), volumeAB.GetType());
                Assert.Equal(3 * 4, volumeAB.VolumeValue);
            }
            {
                var lengthA = new Length<Inches, Int32>(3);
                var areaB = new Area<Inches, Int32>(4);
                var volumeAB = areaB * lengthA;
                Assert.Same(typeof(Volume<Inches, Int32>), volumeAB.GetType());
                Assert.Equal(3 * 4, volumeAB.VolumeValue);
            }

            // multiplying a length by an area with a different uom and/or datatype gives us a volume of the same uom as the length and a double for the datatype.
            {
                var lengthA = new Length<Inches, Int32>(3);
                var areaB = new Area<Feet, Byte>(4);
                var volumeAB = lengthA * areaB;
                Assert.Same(typeof(Volume<Inches, double>), volumeAB.GetType());
                Assert.Equal(3 * 4 * 12 * 12, volumeAB.VolumeValue);
            }
            {
                var lengthA = new Length<Inches, Int32>(3);
                var areaB = new Area<Feet, Byte>(4);
                var volumeAB = areaB * lengthA;
                Assert.Same(typeof(Volume<Inches, double>), volumeAB.GetType());
                Assert.Equal(3 * 4 * 12 * 12, volumeAB.VolumeValue);
            }
        }

        [Fact]
        public void TestLengthDivisionOperators()
        {
            // dividing a length by a scalar results with a length of the same uom and a datatype of double
            {
                var lengthA = new Length<Inches, Int32>(10);
                {
                    var lengthB = lengthA / Convert.ToByte(2);
                    Assert.Same(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.Equal(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToInt16(2);
                    Assert.Same(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.Equal(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToInt32(2);
                    Assert.Same(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.Equal(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToInt64(2);
                    Assert.Same(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.Equal(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToDouble(2);
                    Assert.Same(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.Equal(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToSingle(2);
                    Assert.Same(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.Equal(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToDecimal(2);
                    Assert.Same(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.Equal(10 / 2, lengthB.LengthValue);
                }
            }

            // dividing a length by a length results with a scalar of datatype of double.
            {
                var lengthA = new Length<Inches, Int32>(10);
                var lengthB = new Length<Inches, Byte>(2);
                var valueC = lengthA / lengthB;
                Assert.Same(typeof(double), valueC.GetType());
                Assert.Equal(10 / 2, valueC);
            }

            // dividing an area by a length results with a length of same UOM as length being divided by and a datatype of double
            {
                var areaA = new Area<NGenericDimensions.Lengths.MetricSI.Kilometres, UInt32>(4);
                var lengthB = new Length<NGenericDimensions.Lengths.MetricSI.Millimetres, Decimal>(Convert.ToDecimal(100000));
                var lengthC = areaA / lengthB;
                Assert.Same(typeof(double), lengthC.LengthValue.GetType());
                Assert.Same(typeof(NGenericDimensions.Lengths.MetricSI.Millimetres), lengthC.UnitOfMeasure.GetType());
                Assert.Equal(40000000, lengthC.LengthValue);
            }

            // dividing a length by duration returns Speed of that uom of double.
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Days, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Days, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Hours, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Hours, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Minutes, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Minutes, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Milliseconds, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Milliseconds, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Microseconds, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Microseconds, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = TimeSpan.FromMilliseconds(7000);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds, double>), speedAB.GetType());
                Assert.Equal(70 / (7000 / 1000), speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Deca>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Deca>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Hecto>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Hecto>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Kilo>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Kilo>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Mega>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Mega>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Giga>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Giga>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Tera>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Tera>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Peta>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Peta>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Exa>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Exa>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Zetta>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Zetta>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Yotta>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Yotta>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Deci>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Deci>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Centi>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Centi>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Milli>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Milli>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Micro>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Micro>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Nano>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Nano>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Pico>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Pico>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Femto>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Femto>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Atto>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Atto>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Zepto>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Zepto>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Yocto>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.Same(typeof(Speed<Miles, Seconds<Yocto>, double>), speedAB.GetType());
                Assert.Equal(70 / 7, speedAB.SpeedValue);
            }
        }

        [Fact]
        public void TestLengthComparisonOperators()
        {
            // compare when lengths are exactly the same datatype
            {
                var lengthA = new Length<Miles, Int32>(70);
                var lengthB = new Length<Miles, Int32>(70);
                var lengthC = new Length<Miles, Int32>(71);
                Assert.True(lengthA == lengthB);
                Assert.False(lengthA == lengthC);
                Assert.False(lengthA != lengthB);
                Assert.True(lengthA != lengthC);
                Assert.False(lengthA > lengthB);
                Assert.True(lengthA >= lengthB);
                Assert.False(lengthA < lengthB);
                Assert.True(lengthA <= lengthB);
                Assert.False(lengthA > lengthC);
                Assert.False(lengthA >= lengthC);
                Assert.True(lengthA < lengthC);
                Assert.True(lengthA <= lengthC);
                Assert.False(lengthC < lengthA);
                Assert.False(lengthC <= lengthA);
                Assert.True(lengthC > lengthA);
                Assert.True(lengthC >= lengthA);
            }

            // compare a length to a scalar
            {
                var lengthA = new Length<Miles, Int32>(70);
                var lengthB = Convert.ToInt32(70);
                var lengthC = Convert.ToInt32(71);
                Assert.True(lengthA == lengthB);
                Assert.True(lengthB == lengthA);
                Assert.False(lengthA == lengthC);
                Assert.False(lengthC == lengthA);
                Assert.False(lengthA != lengthB);
                Assert.False(lengthB != lengthA);
                Assert.True(lengthA != lengthC);
                Assert.True(lengthC != lengthA);
                Assert.False(lengthA > lengthB);
                Assert.True(lengthA >= lengthB);
                Assert.False(lengthA < lengthB);
                Assert.True(lengthA <= lengthB);
                Assert.False(lengthA > lengthC);
                Assert.False(lengthA >= lengthC);
                Assert.True(lengthA < lengthC);
                Assert.True(lengthA <= lengthC);
                Assert.False(lengthC < lengthA);
                Assert.False(lengthC <= lengthA);
                Assert.True(lengthC > lengthA);
                Assert.True(lengthC >= lengthA);
            }

            // compare a length of one datatype to a length of another
            {
                var lengthA = new Length<Miles, Int32>(70);
                var lengthB = new Length<Miles, Byte>(70);
                var lengthC = new Length<Miles, Byte>(71);
                Assert.True(lengthA == lengthB);
                Assert.False(lengthA == lengthC);
                Assert.False(lengthA != lengthB);
                Assert.True(lengthA != lengthC);
                Assert.False(lengthA > lengthB);
                Assert.True(lengthA >= lengthB);
                Assert.False(lengthA < lengthB);
                Assert.True(lengthA <= lengthB);
                Assert.False(lengthA > lengthC);
                Assert.False(lengthA >= lengthC);
                Assert.True(lengthA < lengthC);
                Assert.True(lengthA <= lengthC);
                Assert.False(lengthC < lengthA);
                Assert.False(lengthC <= lengthA);
                Assert.True(lengthC > lengthA);
                Assert.True(lengthC >= lengthA);
            }

            // compare a length of a different uon
            {
                var lengthA = new Length<Feet, Int32>(2);
                var lengthB = new Length<Inches, Byte>(24);
                var lengthC = new Length<Inches, Byte>(25);
                Assert.True(lengthA == lengthB);
                Assert.False(lengthA == lengthC);
                Assert.False(lengthA != lengthB);
                Assert.True(lengthA != lengthC);
                Assert.False(lengthA > lengthB);
                Assert.True(lengthA >= lengthB);
                Assert.False(lengthA < lengthB);
                Assert.True(lengthA <= lengthB);
                Assert.False(lengthA > lengthC);
                Assert.False(lengthA >= lengthC);
                Assert.True(lengthA < lengthC);
                Assert.True(lengthA <= lengthC);
                Assert.False(lengthC < lengthA);
                Assert.False(lengthC <= lengthA);
                Assert.True(lengthC > lengthA);
                Assert.True(lengthC >= lengthA);
            }

            // compare a length to some other dimension
            AssertCompilationFails(@"Operator '==' cannot be applied to operands", @"_ = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) == (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '!=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) != (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<' cannot be applied to operands", @"_ = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) < (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) <= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>' cannot be applied to operands", @"_ = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) > (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) >= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
        }

        [Fact]
        public void TestLengthIDimensionValue()
        {
            Assert.Equal(Convert.ToDouble(4), ((IDimension)(new Length<Miles, Int32>(4))).Value);
        }

        [Fact]
        public void TestLengthSquared()
        {
            var lengthA = new Length<Feet, Int32>(5);
            Assert.Same(typeof(Area<Feet, Int32>), lengthA.Squared.GetType());
            Assert.Equal(25, lengthA.Squared.AreaValue);
        }

        [Fact]
        public void TestLengthCubed()
        {
            var lengthA = new Length<Feet, Int32>(5);
            Assert.Same(typeof(Volume<Feet, Int32>), lengthA.Cubed.GetType());
            Assert.Equal(125, lengthA.Cubed.VolumeValue);
        }

        [Fact]
        public void TestLengthToString()
        {
            Assert.Equal((4.4).ToString() + " Feet", (new Length<Feet, double>(4.4)).ToString());
            Assert.Equal((4.4).ToString() + " Feet", (new Length<Feet, double>(4.4)).ToString("LU", null));
            Assert.Equal((4.4).ToString() + " ft.", (new Length<Feet, double>(4.4)).ToString("SU", null));
            Assert.Equal((4.4).ToString(), (new Length<Feet, double>(4.4)).ToString("NU", null));
            Assert.Equal((4.4).ToString() + " Millimetres", (new Length<NGenericDimensions.Lengths.MetricSI.Millimetres, double>(4.4)).ToString());
            Assert.Equal((4.4).ToString() + " Millimetres", (new Length<NGenericDimensions.Lengths.MetricSI.Millimetres, double>(4.4)).ToString("LU", null));
            Assert.Equal((4.4).ToString() + " mm", (new Length<NGenericDimensions.Lengths.MetricSI.Millimetres, double>(4.4)).ToString("SU", null));
            Assert.Equal((4.4).ToString(), (new Length<NGenericDimensions.Lengths.MetricSI.Millimetres, double>(4.4)).ToString("NU", null));
        }

        [Fact]
        public void TestLengthNumberExtensions()
        {
            Assert.Same(typeof(Length<Feet, Int32>), (5).feet().GetType());
            Assert.Equal(444, (444).feet().LengthValue);
            Assert.Same(typeof(Speed<Feet, Minutes, Int32>), (5).feet().per().minute().GetType());
            Assert.Equal(444, (444).feet().per().minute().SpeedValue);
            Assert.Equal(Convert.ToInt16(444), ((Length<Feet, Int16>?)(444)).LengthValue().Value);
            Assert.Null(((Length<Feet, Int16>?)(null)).LengthValue());
            Assert.Equal(15, ((15).square().feet()).AreaValue);
            Assert.Same(typeof(Area<Feet, Int32>), ((15).square().feet()).GetType());
        }
    }
}
