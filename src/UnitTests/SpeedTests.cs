using NGenericDimensions;
using NGenericDimensions.Durations;
using NGenericDimensions.Lengths.MetricSI;
using NGenericDimensions.Lengths.Uscs;
using NGenericDimensions.MetricPrefix;
using System;
using System.Linq;
using System.Security.Cryptography;
using Xunit;

namespace NGenericDimensionsUnitTests
{
    public class SpeedTests : TestsHelperBBase
    {
        private static readonly Type[] actualUomsTypesOfLength1DUnitOfMeasure
            = GetUnitOfMeasuresTypes<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(true, true).OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfLength1DUnitOfMeasureEvenWithoutIDefinedUnitOfMeasure
            = GetUnitOfMeasuresTypes<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(false, true)
            .Where(o => o.Name != "Length1DUnitOfMeasure"
                     && o.Name != "UscsLengthUnitOfMeasure"
                     && o.Name != "MetricSILengthUnitOfMeasure")
            .OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfUscsLengthUnitOfMeasure
            = GetUnitOfMeasuresTypes<UscsLengthUnitOfMeasure>(true, true).OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfSILengthUnitOfMeasure
            = GetUnitOfMeasuresTypes<MetricSILengthUnitOfMeasure>(true, true).OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfDurationUnitOfMeasure
            = GetUnitOfMeasuresTypes<DurationUnitOfMeasure>(true, true).OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfDurationUnitOfMeasureEvenWithoutIDefinedUnitOfMeasure
            = GetUnitOfMeasuresTypes<DurationUnitOfMeasure>(false, true)
            .Where(o => o.Name != "DurationUnitOfMeasure"
                     && o.Name != "StandardDurationUnitOfMeasure")
            .OrderBy(o => o.FullName).ToArray();

        private static readonly Type[] actualUomsTypesOfStandardDurationUnitOfMeasure
            = GetUnitOfMeasuresTypes<StandardDurationUnitOfMeasure>(true, true).OrderBy(o => o.FullName).ToArray();


        [Fact]
        public void SpeedUOMsBaseClassesAndInterfaces()
        {
            // currently there are no speed UOMs, just speeds made up of other UOMs
        }

        [Fact(Timeout=120000)]
        public void TestSpeedConstructor()
        {
            var uomsToPass1 = GetUnitOfMeasuresTypeFullNames<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(true, true).ToArray();
            var uomsToFail1 = GetUnitOfMeasuresTypeFullNames<NGenericDimensions.Lengths.Length1DUnitOfMeasure>(true, false).ToArray();
            var uomsToPass2 = GetUnitOfMeasuresTypeFullNames<DurationUnitOfMeasure>(true, true).ToArray();
            var uomsToFail2 = GetUnitOfMeasuresTypeFullNames<DurationUnitOfMeasure>(true, false).ToArray();

            // test valid and invalid units of measure for length
            Func<string, string, string> csharpCode = (l,d) => $@"_ = new NGenericDimensions.Speed<{l}, {d}, double>(4.4);";
            foreach (var uomToPass in (from length in uomsToPass1 from duration in uomsToPass2 select new { length, duration })) AssertCompilationPasses(csharpCode(uomToPass.length, uomToPass.duration));
            foreach (var uomToFail in uomsToFail1) AssertCompilationFails("cannot be used as type parameter", csharpCode(uomToFail, "NGenericDimensions.Durations.Hours"));
            foreach (var uomToFail in uomsToFail2) AssertCompilationFails("cannot be used as type parameter", csharpCode("NGenericDimensions.Lengths.Uscs.Feet", uomToFail));

            // test common constructor tests
            TestConstructor(@"_ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, {0});");

            // test creating speed with a length and duration
            {
                var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Miles, System.Int32>(60);
                var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, System.Byte>(30);
                var speedA = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Minutes, System.Int32>(lengthA, durationA);
                Assert.Equal(2, speedA.SpeedValue);
            }
            {
                var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Miles, System.Int32>(60);
                var durationA = System.TimeSpan.FromMinutes(30);
                var speedA = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Minutes, System.Int32>(lengthA, durationA);
                Assert.Equal(2, speedA.SpeedValue);
            }

            // make sure value gets stored in member variable
            var speedB = new Speed<Miles, Hours, Int32>(3);
            Assert.Equal(3, speedB.SpeedValue);

            // make sure value can be constructed via its own kind of data type, and that it is an exact copy
            var speedC = new Speed<Miles, Hours, Int32>(speedB);
            Assert.Equal(speedB.SpeedValue, speedC.SpeedValue);
            Assert.Equal(3, speedC.SpeedValue);
            Assert.Same(speedB.LengthUnitOfMeasure, speedC.LengthUnitOfMeasure);
            Assert.Same(speedB.DurationUnitOfMeasure, speedC.DurationUnitOfMeasure);

            // make sure value of different unit converts propertly via constructor.
            Assert.Equal(8640, (new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Minutes, System.Int32>(new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds, System.Double>(12))).SpeedValue);

            // test to make sure we can't use a dimension for the numeric datatype
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Volumes.MetricNonSI.Litres, NGenericDimensions.Durations.Minutes, System.Int32>(44);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Volumes.MetricNonSI.Litres, System.Int32>(44);");
        }

        [Fact]
        public void TestUnitOfMeasureProperty()
        {
            // make sure the UnitOfMeasure is actually the correct type
            Assert.Same(typeof(NGenericDimensions.Lengths.Uscs.Inches), (new Speed<Inches, Hours, Int32>(33)).LengthUnitOfMeasure.GetType());
            Assert.Same(typeof(NGenericDimensions.Durations.Hours), (new Speed<Inches, Hours, Int32>(33)).DurationUnitOfMeasure.GetType());
        }

        [Fact]
        public void TestSpeedConvertToFunction()
        {
            var speedA = new Speed<Feet, Hours, Int32>(120);
            var speedB = speedA.ConvertTo<Inches, Minutes, Int32>();
            Assert.Equal(Convert.ToDecimal(24.0), speedB.SpeedValue);
            Assert.Same(typeof(Inches), speedB.LengthUnitOfMeasure.GetType());
            Assert.Same(typeof(Minutes), speedB.DurationUnitOfMeasure.GetType());
            var speedC = new Speed<Feet, Hours, Int32>(120);
            var speedD = speedC.ConvertTo<decimal>();
            Assert.Equal(120, speedD.SpeedValue);
            Assert.Same(typeof(decimal), speedD.SpeedValue.GetType());
        }

        [Fact]
        public void TestSpeedCastingOperators()
        {
            // implicit cast to speed
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            Speed<Inches, Minutes, Double> durationA = 2.2;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            AssertCompilationFails("Cannot implicitly convert type", @"NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Minutes, System.Double> speedB = System.Convert.ToDecimal(5.5);");

            // explicit cast from speed
            AssertCompilationFails("Cannot implicitly convert type", @"double speedB = (new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Minutes, System.Double>(3.3));");
            double speedB = (double)(new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Minutes, System.Double>(3.3));
            Assert.Equal(3.3, speedB);
        }

        [Fact]
        public void TestSpeedAdditionOperators()
        {
            // adding 2 of the exact same speed type ends up with the same type
            {
                var speedA = new Speed<Inches, Minutes, double>(2.2);
                var speedB = new Speed<Inches, Minutes, double>(3.3);
                var speedAB = speedA + speedB;
                Assert.Same(speedA.GetType(), speedAB.GetType());
                Assert.Same(speedB.GetType(), speedAB.GetType());
                Assert.Same(speedA.SpeedValue.GetType(), speedAB.SpeedValue.GetType());
                Assert.Same(speedB.SpeedValue.GetType(), speedAB.SpeedValue.GetType());
                Assert.Equal(5.5, speedAB.SpeedValue);
            }

            // adding 2 of different types of speeds should end up with the first one's uom as a system.double
            {
                var speedC = new Speed<Inches, Hours, Int32>(2);
                var speedD = new Speed<Inches, Hours, Byte>(8);
                var speedCD = speedC + speedD;
                Assert.Same(speedC.LengthUnitOfMeasure.GetType(), speedCD.LengthUnitOfMeasure.GetType());
                Assert.Same(speedC.DurationUnitOfMeasure.GetType(), speedCD.DurationUnitOfMeasure.GetType());
                Assert.Same(typeof(double), speedCD.SpeedValue.GetType());
                Assert.Equal(10, speedCD.SpeedValue);
            }
            {
                var speedC = new Speed<Inches, Hours, Int32>(7);
                var speedD = new Speed<Feet, Minutes, Byte>(2);
                var speedCD = speedC + speedD;
                Assert.Same(speedC.LengthUnitOfMeasure.GetType(), speedCD.LengthUnitOfMeasure.GetType());
                Assert.Same(speedC.DurationUnitOfMeasure.GetType(), speedCD.DurationUnitOfMeasure.GetType());
                Assert.Same(typeof(double), speedCD.SpeedValue.GetType());
                Assert.Equal(1447, speedCD.SpeedValue);
            }
            var speedE = new Speed<Miles, Hours, double>(2.2);
            var speedF = speedE + 5; // c# calls implicit cast to change 5 to speed so that it can use the + operator
            Assert.Equal(7.2, speedF.SpeedValue);
            var speedG = 5 + speedE;
            Assert.Equal(7.2, speedG.SpeedValue);

            // don't allow adding a different dimension to it
            _ = (new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Minutes, System.Double>(2.2)) + (new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Hours, System.Double>(3.3));
            AssertCompilationFails(@"Operator '-' cannot be applied", @"_ = (new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Minutes, System.Double>(2.2)) - (new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestSpeedSubtractionOperators()
        {
            // subtracting 2 of the exact same speed type ends up with the same type
            {
                var speedA = new Speed<Miles, Hours, double>(2.2);
                var speedB = new Speed<Miles, Hours, double>(3.3);
                var speedAB = speedA - speedB;
                Assert.Same(speedA.GetType(), speedAB.GetType());
                Assert.Same(speedB.GetType(), speedAB.GetType());
                Assert.Same(speedA.SpeedValue.GetType(), speedAB.SpeedValue.GetType());
                Assert.Same(speedB.SpeedValue.GetType(), speedAB.SpeedValue.GetType());
                Assert.Equal(2.2 - 3.3, speedAB.SpeedValue);
            }

            // subtracting 2 of different types of speeds should end up with the first one's uom as a system.double
            {
                var speedC = new Speed<Miles, Hours, Int32>(2);
                var speedD = new Speed<Miles, Hours, Byte>(8);
                var speedCD = speedC - speedD;
                Assert.Same(speedC.LengthUnitOfMeasure.GetType(), speedCD.LengthUnitOfMeasure.GetType());
                Assert.Same(speedC.DurationUnitOfMeasure.GetType(), speedCD.DurationUnitOfMeasure.GetType());
                Assert.Same(typeof(double), speedCD.SpeedValue.GetType());
                Assert.Equal(-6, speedCD.SpeedValue);
            }
            {
                var speedC = new Speed<Yards, Minutes, Int32>(5);
                var speedD = new Speed<Miles, Hours, Byte>(3);
                var speedCD = speedC - speedD;
                Assert.Same(speedC.LengthUnitOfMeasure.GetType(), speedCD.LengthUnitOfMeasure.GetType());
                Assert.Same(speedC.DurationUnitOfMeasure.GetType(), speedCD.DurationUnitOfMeasure.GetType());
                Assert.Same(typeof(double), speedCD.SpeedValue.GetType());
                Assert.Equal(-83, speedCD.SpeedValue);
            }
            var speedE = new Speed<Miles, Hours, double>(2.2);
            var speedF = speedE - 5; // c# calls implicit cast to change 5 to speed so that it can use the - operator
            Assert.Equal(2.2 - 5, speedF.SpeedValue);
            var speedG = 5 - speedE;
            Assert.Equal(5 - 2.2, speedG.SpeedValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '-' cannot be applied", @"_ = (new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) - (new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestSpeedMultiplicationOperators()
        {
            // multiplying a speed with a value should return the same kind of speed with the value multiplied
            {
                var speedA = new Speed<Millimetres, Minutes, Int32>(7);
                var speedB = speedA * 3;
                Assert.Same(speedA.GetType(), speedB.GetType());
                Assert.Equal(21, speedB.SpeedValue);
                var speedC = 3 * speedA;
                Assert.Same(speedA.GetType(), speedC.GetType());
                Assert.Equal(21, speedC.SpeedValue);
            }

            // multiplying a speed and a duration, where both have the same UOM datatype and scalar datatype, results in length of same length and scalar datatypes as the speed
            {
                var speedA = new Speed<Inches, Days, Int32>(7);
                var durationB = new Duration<Days, Int32>(2);
                var lengthC = speedA * durationB;
                Assert.Same(speedA.LengthUnitOfMeasure.GetType(), lengthC.LengthUnitOfMeasure.GetType());
                Assert.Same(speedA.SpeedValue.GetType(), lengthC.LengthValue.GetType());
                Assert.Equal(14, lengthC.LengthValue);
            }
            {
                var speedA = new Speed<Inches, Days, Int32>(7);
                var durationB = new Duration<Days, Int32>(2);
                var lengthC = durationB * speedA;
                Assert.Same(speedA.LengthUnitOfMeasure.GetType(), lengthC.LengthUnitOfMeasure.GetType());
                Assert.Same(speedA.SpeedValue.GetType(), lengthC.LengthValue.GetType());
                Assert.Equal(14, lengthC.LengthValue);
            }

            // TODO: keep adding multiplication tests
        }

        [Fact]
        public void TestSpeedDivisionOperators()
        {
            // dividing a speed by a scalar results with a speed of the same uoms and a datatype of double
            {
                var speedA = new Speed<Inches, Seconds, Int32>(10);
                {
                    var speedB = speedA / Convert.ToByte(2);
                    Assert.Same(typeof(Speed<Inches, Seconds, double>), speedB.GetType());
                    Assert.Equal(10 / 2, speedB.SpeedValue);
                }
                {
                    var speedB = speedA / Convert.ToInt16(2);
                    Assert.Same(typeof(Speed<Inches, Seconds, double>), speedB.GetType());
                    Assert.Equal(10 / 2, speedB.SpeedValue);
                }
                {
                    var speedB = speedA / Convert.ToInt32(2);
                    Assert.Same(typeof(Speed<Inches, Seconds, double>), speedB.GetType());
                    Assert.Equal(10 / 2, speedB.SpeedValue);
                }
                {
                    var speedB = speedA / Convert.ToInt64(2);
                    Assert.Same(typeof(Speed<Inches, Seconds, double>), speedB.GetType());
                    Assert.Equal(10 / 2, speedB.SpeedValue);
                }
                {
                    var speedB = speedA / Convert.ToDouble(2);
                    Assert.Same(typeof(Speed<Inches, Seconds, double>), speedB.GetType());
                    Assert.Equal(10 / 2, speedB.SpeedValue);
                }
                {
                    var speedB = speedA / Convert.ToSingle(2);
                    Assert.Same(typeof(Speed<Inches, Seconds, double>), speedB.GetType());
                    Assert.Equal(10 / 2, speedB.SpeedValue);
                }
                {
                    var speedB = speedA / Convert.ToDecimal(2);
                    Assert.Same(typeof(Speed<Inches, Seconds, double>), speedB.GetType());
                    Assert.Equal(10 / 2, speedB.SpeedValue);
                }
            }

            // dividing a speed by a speed results with a scalar of datatype of double.
            {
                var speedA = new Speed<Miles, Hours, Int32>(10);
                var speedB = new Speed<Miles, Hours, Byte>(2);
                var valueC = speedA / speedB;
                Assert.Same(typeof(double), valueC.GetType());
                Assert.Equal(10 / 2, valueC);
            }
        }

        [Fact]
        public void TestSpeedComparisonOperators()
        {
            // compare when speeds are exactly the same datatype
            {
                var speedA = new Speed<Miles, Hours, Int32>(70);
                var speedB = new Speed<Miles, Hours, Int32>(70);
                var speedC = new Speed<Miles, Hours, Int32>(71);
                Assert.True(speedA == speedB);
                Assert.False(speedA == speedC);
                Assert.False(speedA != speedB);
                Assert.True(speedA != speedC);
                Assert.False(speedA > speedB);
                Assert.True(speedA >= speedB);
                Assert.False(speedA < speedB);
                Assert.True(speedA <= speedB);
                Assert.False(speedA > speedC);
                Assert.False(speedA >= speedC);
                Assert.True(speedA < speedC);
                Assert.True(speedA <= speedC);
                Assert.False(speedC < speedA);
                Assert.False(speedC <= speedA);
                Assert.True(speedC > speedA);
                Assert.True(speedC >= speedA);
            }

            // compare a speed to a scalar
            {
                var speedA = new Speed<Miles, Hours, Int32>(70);
                var speedB = Convert.ToInt32(70);
                var speedC = Convert.ToInt32(71);
                Assert.True(speedA == speedB);
                Assert.True(speedB == speedA);
                Assert.False(speedA == speedC);
                Assert.False(speedC == speedA);
                Assert.False(speedA != speedB);
                Assert.False(speedB != speedA);
                Assert.True(speedA != speedC);
                Assert.True(speedC != speedA);
                Assert.False(speedA > speedB);
                Assert.True(speedA >= speedB);
                Assert.False(speedA < speedB);
                Assert.True(speedA <= speedB);
                Assert.False(speedA > speedC);
                Assert.False(speedA >= speedC);
                Assert.True(speedA < speedC);
                Assert.True(speedA <= speedC);
                Assert.False(speedC < speedA);
                Assert.False(speedC <= speedA);
                Assert.True(speedC > speedA);
                Assert.True(speedC >= speedA);
            }

            // compare a speed of one datatype of a speed of another
            {
                var speedA = new Speed<Miles, Hours, Int32>(70);
                var speedB = new Speed<Miles, Hours, Byte>(70);
                var speedC = new Speed<Miles, Hours, Byte>(71);
                Assert.True(speedA == speedB);
                Assert.False(speedA == speedC);
                Assert.False(speedA != speedB);
                Assert.True(speedA != speedC);
                Assert.False(speedA > speedB);
                Assert.True(speedA >= speedB);
                Assert.False(speedA < speedB);
                Assert.True(speedA <= speedB);
                Assert.False(speedA > speedC);
                Assert.False(speedA >= speedC);
                Assert.True(speedA < speedC);
                Assert.True(speedA <= speedC);
                Assert.False(speedC < speedA);
                Assert.False(speedC <= speedA);
                Assert.True(speedC > speedA);
                Assert.True(speedC >= speedA);
            }

            // compare a speed of a different uom
            {
                var speedA = new Speed<Yards, Minutes, Int32>(2);
                var speedB = new Speed<Feet, Hours, Int16>(360);
                var speedC = new Speed<Yards, Minutes, Int16>(7205);
                Assert.True(speedA == speedB);
                Assert.False(speedA == speedC);
                Assert.False(speedA != speedB);
                Assert.True(speedA != speedC);
                Assert.False(speedA > speedB);
                Assert.True(speedA >= speedB);
                Assert.False(speedA < speedB);
                Assert.True(speedA <= speedB);
                Assert.False(speedA > speedC);
                Assert.False(speedA >= speedC);
                Assert.True(speedA < speedC);
                Assert.True(speedA <= speedC);
                Assert.False(speedC < speedA);
                Assert.False(speedC <= speedA);
                Assert.True(speedC > speedA);
                Assert.True(speedC >= speedA);
            }

            // compare a speed to some other dimension
            AssertCompilationFails(@"Operator '==' cannot be applied to operands", @"_ = ((new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Hours, System.Int32>(0)) == (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '!=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Hours, System.Int32>(0)) != (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<' cannot be applied to operands", @"_ = ((new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Hours, System.Int32>(0)) < (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Hours, System.Int32>(0)) <= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>' cannot be applied to operands", @"_ = ((new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Hours, System.Int32>(0)) > (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Hours, System.Int32>(0)) >= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
        }

        [Fact]
        public void TestSpeedIDimensionValue()
        {
            Assert.Equal(Convert.ToDouble(4), ((IDimension)(new Speed<Miles, Hours, Int32>(4))).Value);
        }

        [Fact]
        public void TestSpeedToString()
        {
            Assert.Equal((4.4).ToString() + " Miles per Hour", (new Speed<Miles, Hours, double>(4.4)).ToString());
            Assert.Equal((4.4).ToString() + " Miles per Hour", (new Speed<Miles, Hours, double>(4.4)).ToString("LU", null));
            Assert.Equal((4.4).ToString() + " mph", (new Speed<Miles, Hours, double>(4.4)).ToString("SU", null));
            Assert.Equal((4.4).ToString(), (new Speed<Miles, Hours, double>(4.4)).ToString("NU", null));
            Assert.Equal((4.4).ToString() + " Inches per Millisecond", (new Speed<Inches, Milliseconds, double>(4.4)).ToString());
            Assert.Equal((4.4).ToString() + " Inches per Millisecond", (new Speed<Inches, Milliseconds, double>(4.4)).ToString("LU", null));
            Assert.Equal((4.4).ToString() + " in/ms", (new Speed<Inches, Milliseconds, double>(4.4)).ToString("SU", null));
            Assert.Equal((4.4).ToString(), (new Speed<Inches, Milliseconds, double>(4.4)).ToString("NU", null));
            // TODO: add support for knots or some other speed that isn't a ratio... might take some work...
        }

        //[Fact]
        //public void TestDurationNumberExtensions()
        //{
        //    Assert.Same(typeof(Duration<Hours, Int32>), (5).hours().GetType());
        //    Assert.Equal(444, (444).hours().DurationValue);
        //    Assert.Same(typeof(Speed<Feet, Minutes, Int32>), (5).feet().per().minute().GetType());
        //    Assert.Equal(444, (444).feet().per().minute().SpeedValue);
        //    Assert.Equal(Convert.ToInt16(444), ((Duration<Hours, Int16>?)(444)).DurationValue().Value);
        //    Assert.Equal(null, ((Duration<Hours, Int16>?)(null)).DurationValue());
        //}
    }
}
