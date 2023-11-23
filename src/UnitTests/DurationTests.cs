using NGenericDimensions;
using NGenericDimensions.Durations;
using NGenericDimensions.Extensions;
using NGenericDimensions.Extensions.Numbers;
using NGenericDimensions.Lengths.Uscs;
using NGenericDimensions.MetricPrefix;
using System;
using System.Linq;
using Xunit;

namespace NGenericDimensionsUnitTests
{
    public class DurationTests : TestsHelperBBase
    {
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
        public void DurationUOMsBaseClassesAndInterfaces()
        {
            var expectedUomsOfStandardDurationUnitOfMeasure = new[] {
                typeof(Days),
                typeof(Hours),
                typeof(Microseconds),
                typeof(Milliseconds),
                typeof(Minutes),
                typeof(Ticks),
                typeof(Seconds<NoPrefix>),
                typeof(Seconds<Deca>),
                typeof(Seconds<Hecto>),
                typeof(Seconds<Kilo>),
                typeof(Seconds<Mega>),
                typeof(Seconds<Giga>),
                typeof(Seconds<Tera>),
                typeof(Seconds<Peta>),
                typeof(Seconds<Exa>),
                typeof(Seconds<Zetta>),
                typeof(Seconds<Yotta>),
                typeof(Seconds<Deci>),
                typeof(Seconds<Centi>),
                typeof(Seconds<Milli>),
                typeof(Seconds<Micro>),
                typeof(Seconds<Nano>),
                typeof(Seconds<Pico>),
                typeof(Seconds<Femto>),
                typeof(Seconds<Atto>),
                typeof(Seconds<Zepto>),
                typeof(Seconds<Yocto>),
                typeof(Seconds)
            }.OrderBy(o => o.FullName);

            Assert.Equal(expectedUomsOfStandardDurationUnitOfMeasure, actualUomsTypesOfDurationUnitOfMeasure);
            Assert.Equal(expectedUomsOfStandardDurationUnitOfMeasure, actualUomsTypesOfDurationUnitOfMeasureEvenWithoutIDefinedUnitOfMeasure);
        }

        [Fact]
        public void TestDurationConstructor()
        {
            var uomsToPass = GetUnitOfMeasuresTypeFullNames<DurationUnitOfMeasure>(true, true);
            var uomsToFail = GetUnitOfMeasuresTypeFullNames<DurationUnitOfMeasure>(true, false);

            // test valid and invalid units of measure for length
            Func<string, string> csharpCode = (t) => $@"_ = new NGenericDimensions.Duration<{t}, double>(4.4);";
            foreach (var uomToPass in uomsToPass) AssertCompilationPasses(csharpCode(uomToPass));
            foreach (var uomToFail in uomsToFail) AssertCompilationFails("cannot be used as type parameter", csharpCode(uomToFail));

            // test common constructor tests
            TestConstructor(@"_ = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, {0});");

            // make sure constructor can take a timespan
            _ = new Duration<Hours, Int32>(TimeSpan.FromDays(2));
            Assert.Equal(48, (new Duration<Hours, Int32>(TimeSpan.FromDays(2))).HoursValue());
            Assert.Equal(777, (new Duration<Ticks, Int32>(TimeSpan.FromTicks(777))).TicksValue());
            Assert.Equal(TimeSpan.FromTicks(777), (new Duration<Ticks, Int32>(TimeSpan.FromTicks(777))).TimeSpan);

            // make sure value gets stored in member variable
            var durationB = new Duration<Hours, Int32>(3);
            Assert.Equal(3, durationB.DurationValue);

            // make sure value can be constructed via its own kind of data type, and that it is an exact copy
            var durationC = new Duration<Hours, Int32>(durationB);
            Assert.Equal(durationB.DurationValue, durationC.DurationValue);
            Assert.Equal(3, durationC.DurationValue);
            Assert.Same(durationB.DurationUnitOfMeasure, durationC.DurationUnitOfMeasure);

            // make sure value of different unit converts propertly via constructor.
            Assert.Equal(120, (new Duration<Seconds, Int32>(new Duration<Minutes, Int32>(2))).DurationValue);
            Assert.Equal(120, (new Duration<Seconds, Int32>(new Duration<Minutes, Int64>(2))).DurationValue);
            Assert.Equal(132, (new Duration<Seconds, Int32>(new Duration<Minutes, Decimal>(Convert.ToDecimal(2.2)))).DurationValue);
            Assert.Equal(132, (new Duration<Seconds, Int32>(new Duration<Minutes, Double>(2.2))).DurationValue);

            // test to make sure we can't use a dimension for the numeric datatype
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>>(44.4);");
        }

        [Fact]
        public void TestUnitOfMeasureProperty()
        {
            // make sure the UnitOfMeasure is actually the correct type
            Assert.Same(typeof(Hours), (new Duration<Hours, Int32>(33)).DurationUnitOfMeasure.GetType());
            Assert.Same(typeof(Hours), ((IDuration)(new Duration<Hours, Int32>(33))).DurationUnitOfMeasure.GetType());
        }

        [Fact]
        public void TestDurationConvertToFunction()
        {
            var durationA = new Duration<Hours, Int32>(333);
            var durationB = durationA.ConvertTo<Milliseconds, Decimal>();
            Assert.Equal(1198800000, durationB.DurationValue);
            Assert.Same(typeof(Milliseconds), durationB.DurationUnitOfMeasure.GetType());
            var durationC = new Duration<Hours, Int32>(333);
            var durationD = durationC.ConvertTo<decimal>();
            Assert.Equal(333, durationD.DurationValue);
            Assert.Same(typeof(decimal), durationD.DurationValue.GetType());
        }

        [Fact]
        public void TestDurationCastingOperators()
        {
            // implicit cast to duration
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            Duration<Minutes, Double> durationA = 2.2;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            AssertCompilationFails("Cannot implicitly convert type", @"NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, System.Double> durationB = System.Convert.ToDecimal(5.5);");

            // explicit cast from duration
            AssertCompilationFails("Cannot implicitly convert type", @"double durationB = (new NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, System.Double>(3.3));");
            double durationB = (double)(new NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, System.Double>(3.3));
            Assert.Equal(3.3, durationB);

            // explicit cast from TimeSpan
            AssertCompilationFails("Cannot implicitly convert type", @"NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, System.Double> durationE = System.TimeSpan.Zero;");
            TimeSpan timespanC = TimeSpan.FromMinutes(2.2);
            Duration<Minutes, double> durationD = (Duration<Minutes, double>)timespanC;
            Assert.Equal(2.2, durationD.DurationValue);

            // explicit cast to TimeSpan
            AssertCompilationFails("Cannot implicitly convert type", @"System.TimeSpan timespanH = (new NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, System.Double>(3.3));");
            var durationF = new Duration<Minutes, double>(2.2);
            TimeSpan timespanG = (TimeSpan)durationF;
            Assert.Equal(2.2, timespanG.TotalMinutes);
        }

        [Fact]
        public void TestDurationAdditionOperators()
        {
            // adding 2 of the exact same duration type ends up with the same type
            {
                var durationA = new Duration<Minutes, double>(2.2);
                var durationB = new Duration<Minutes, double>(3.3);
                var durationAB = durationA + durationB;
                Assert.Same(durationA.GetType(), durationAB.GetType());
                Assert.Same(durationB.GetType(), durationAB.GetType());
                Assert.Same(durationA.DurationValue.GetType(), durationAB.DurationValue.GetType());
                Assert.Same(durationB.DurationValue.GetType(), durationAB.DurationValue.GetType());
                Assert.Equal(5.5, durationAB.DurationValue);
            }

            // adding 2 of different types of durations should end up with the first one's uom as a system.double
            {
                var durationC = new Duration<Hours, Int32>(2);
                var durationD = new Duration<Hours, Byte>(8);
                var durationCD = durationC + durationD;
                Assert.Same(durationC.DurationUnitOfMeasure.GetType(), durationCD.DurationUnitOfMeasure.GetType());
                Assert.Same(typeof(double), durationCD.DurationValue.GetType());
                Assert.Equal(10, durationCD.DurationValue);
            }
            {
                var durationC = new Duration<Minutes, Int32>(5);
                var durationD = new Duration<Hours, Byte>(2);
                var durationCD = durationC + durationD;
                Assert.Same(durationC.DurationUnitOfMeasure.GetType(), durationCD.DurationUnitOfMeasure.GetType());
                Assert.Same(typeof(double), durationCD.DurationValue.GetType());
                Assert.Equal(125, durationCD.DurationValue);
            }
            var durationE = new Duration<Hours, double>(2.2);
            var durationF = durationE + 5; // c# calls implicit cast to change 5 to duration so that it can use the + operator
            Assert.Equal(7.2, durationF.DurationValue);
            var durationG = 5 + durationE;
            Assert.Equal(7.2, durationG.DurationValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '+' cannot be applied", @"_ = (new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) + (new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestDurationSubtractionOperators()
        {
            // subtracting 2 of the exact same duration type ends up with the same type
            {
                var durationA = new Duration<Hours, double>(2.2);
                var durationB = new Duration<Hours, double>(3.3);
                var durationAB = durationA - durationB;
                Assert.Same(durationA.GetType(), durationAB.GetType());
                Assert.Same(durationB.GetType(), durationAB.GetType());
                Assert.Same(durationA.DurationValue.GetType(), durationAB.DurationValue.GetType());
                Assert.Same(durationB.DurationValue.GetType(), durationAB.DurationValue.GetType());
                Assert.Equal(2.2 - 3.3, durationAB.DurationValue);
            }

            // subtracting 2 of different types of durations should end up with the first one's uon as a system.double
            {
                var durationC = new Duration<Hours, Int32>(2);
                var durationD = new Duration<Hours, Byte>(8);
                var durationCD = durationC - durationD;
                Assert.Same(durationC.DurationUnitOfMeasure.GetType(), durationCD.DurationUnitOfMeasure.GetType());
                Assert.Same(typeof(double), durationCD.DurationValue.GetType());
                Assert.Equal(-6, durationCD.DurationValue);
            }
            {
                var durationC = new Duration<Minutes, Int32>(5);
                var durationD = new Duration<Hours, Byte>(2);
                var durationCD = durationC - durationD;
                Assert.Same(durationC.DurationUnitOfMeasure.GetType(), durationCD.DurationUnitOfMeasure.GetType());
                Assert.Same(typeof(double), durationCD.DurationValue.GetType());
                Assert.Equal(-115, durationCD.DurationValue);
            }
            var durationE = new Duration<Hours, double>(2.2);
            var durationF = durationE - 5; // c# calls implicit cast to change 5 to duration so that it can use the - operator
            Assert.Equal(2.2 - 5, durationF.DurationValue);
            var durationG = 5 - durationE;
            Assert.Equal(5 - 2.2, durationG.DurationValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '-' cannot be applied", @"_ = (new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) - (new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestDurationMultiplicationOperators()
        {
            // multiplying a duration with a value should return the same kind of duration with the value multiplied
            {
                var durationA = new Duration<Minutes, Int32>(7);
                var durationB = durationA * 3;
                Assert.Same(durationA.GetType(), durationB.GetType());
                Assert.Equal(21, durationB.DurationValue);
                var durationC = 3 * durationA;
                Assert.Same(durationA.GetType(), durationC.GetType());
                Assert.Equal(21, durationC.DurationValue);
            }
        }

        [Fact]
        public void TestDurationDivisionOperators()
        {
            // dividing a duration by a scalar results with a duration of the same uom and a datatype of double
            {
                var durationA = new Duration<Seconds, Int32>(10);
                {
                    var durationB = durationA / Convert.ToByte(2);
                    Assert.Same(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.Equal(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToInt16(2);
                    Assert.Same(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.Equal(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToInt32(2);
                    Assert.Same(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.Equal(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToInt64(2);
                    Assert.Same(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.Equal(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToDouble(2);
                    Assert.Same(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.Equal(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToSingle(2);
                    Assert.Same(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.Equal(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToDecimal(2);
                    Assert.Same(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.Equal(10 / 2, durationB.DurationValue);
                }
            }

            // dividing a duration by a duration results with a scalar of datatype of double.
            {
                var durationA = new Duration<Seconds, Int32>(10);
                var durationB = new Duration<Seconds, Byte>(2);
                var valueC = durationA / durationB;
                Assert.Same(typeof(double), valueC.GetType());
                Assert.Equal(10 / 2, valueC);
            }
        }

        [Fact]
        public void TestDurationComparisonOperators()
        {
            // compare when durationes are exactly the same datatype
            {
                var durationA = new Duration<Hours, Int32>(70);
                var durationB = new Duration<Hours, Int32>(70);
                var durationC = new Duration<Hours, Int32>(71);
                Assert.True(durationA == durationB);
                Assert.False(durationA == durationC);
                Assert.False(durationA != durationB);
                Assert.True(durationA != durationC);
                Assert.False(durationA > durationB);
                Assert.True(durationA >= durationB);
                Assert.False(durationA < durationB);
                Assert.True(durationA <= durationB);
                Assert.False(durationA > durationC);
                Assert.False(durationA >= durationC);
                Assert.True(durationA < durationC);
                Assert.True(durationA <= durationC);
                Assert.False(durationC < durationA);
                Assert.False(durationC <= durationA);
                Assert.True(durationC > durationA);
                Assert.True(durationC >= durationA);
            }

            // compare a duration to a scalar
            {
                var durationA = new Duration<Hours, Int32>(70);
                var durationB = Convert.ToInt32(70);
                var durationC = Convert.ToInt32(71);
                Assert.True(durationA == durationB);
                Assert.True(durationB == durationA);
                Assert.False(durationA == durationC);
                Assert.False(durationC == durationA);
                Assert.False(durationA != durationB);
                Assert.False(durationB != durationA);
                Assert.True(durationA != durationC);
                Assert.True(durationC != durationA);
                Assert.False(durationA > durationB);
                Assert.True(durationA >= durationB);
                Assert.False(durationA < durationB);
                Assert.True(durationA <= durationB);
                Assert.False(durationA > durationC);
                Assert.False(durationA >= durationC);
                Assert.True(durationA < durationC);
                Assert.True(durationA <= durationC);
                Assert.False(durationC < durationA);
                Assert.False(durationC <= durationA);
                Assert.True(durationC > durationA);
                Assert.True(durationC >= durationA);
            }

            // compare a duration of one datatype to a duration of another
            {
                var durationA = new Duration<Hours, Int32>(70);
                var durationB = new Duration<Hours, Byte>(70);
                var durationC = new Duration<Hours, Byte>(71);
                Assert.True(durationA == durationB);
                Assert.False(durationA == durationC);
                Assert.False(durationA != durationB);
                Assert.True(durationA != durationC);
                Assert.False(durationA > durationB);
                Assert.True(durationA >= durationB);
                Assert.False(durationA < durationB);
                Assert.True(durationA <= durationB);
                Assert.False(durationA > durationC);
                Assert.False(durationA >= durationC);
                Assert.True(durationA < durationC);
                Assert.True(durationA <= durationC);
                Assert.False(durationC < durationA);
                Assert.False(durationC <= durationA);
                Assert.True(durationC > durationA);
                Assert.True(durationC >= durationA);
            }

            // compare a duration of a different uom
            {
                var durationA = new Duration<Hours, Int32>(2);
                var durationB = new Duration<Seconds, Int16>(7200);
                var durationC = new Duration<Seconds, Int16>(7205);
                Assert.True(durationA == durationB);
                Assert.False(durationA == durationC);
                Assert.False(durationA != durationB);
                Assert.True(durationA != durationC);
                Assert.False(durationA > durationB);
                Assert.True(durationA >= durationB);
                Assert.False(durationA < durationB);
                Assert.True(durationA <= durationB);
                Assert.False(durationA > durationC);
                Assert.False(durationA >= durationC);
                Assert.True(durationA < durationC);
                Assert.True(durationA <= durationC);
                Assert.False(durationC < durationA);
                Assert.False(durationC <= durationA);
                Assert.True(durationC > durationA);
                Assert.True(durationC >= durationA);
            }

            // compare a duration to some other dimension
            AssertCompilationFails(@"Operator '==' cannot be applied to operands", @"_ = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) == (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '!=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) != (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<' cannot be applied to operands", @"_ = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) < (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) <= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>' cannot be applied to operands", @"_ = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) > (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) >= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
        }

        [Fact]
        public void TestDurationIDimensionValue()
        {
            Assert.Equal(Convert.ToDouble(4), ((IDimension)(new Duration<Hours, Int32>(4))).Value);
        }

        [Fact]
        public void TestDurationToString()
        {
            Assert.Equal((4.4).ToString() + " Hours", (new Duration<Hours, double>(4.4)).ToString());
            Assert.Equal((4.4).ToString() + " Hours", (new Duration<Hours, double>(4.4)).ToString("LU", null));
            Assert.Equal((4.4).ToString() + " hr", (new Duration<Hours, double>(4.4)).ToString("SU", null));
            Assert.Equal((4.4).ToString(), (new Duration<Hours, double>(4.4)).ToString("NU", null));
            Assert.Equal((4.4).ToString() + " Milliseconds", (new Duration<Milliseconds, double>(4.4)).ToString());
            Assert.Equal((4.4).ToString() + " Milliseconds", (new Duration<Milliseconds, double>(4.4)).ToString("LU", null));
            Assert.Equal((4.4).ToString() + " ms", (new Duration<Milliseconds, double>(4.4)).ToString("SU", null));
            Assert.Equal((4.4).ToString(), (new Duration<Milliseconds, double>(4.4)).ToString("NU", null));
        }

        [Fact]
        public void TestDurationNumberExtensions()
        {
            Assert.Same(typeof(Duration<Hours, Int32>), (5).hours().GetType());
            Assert.Equal(444, (444).hours().DurationValue);
            Assert.Same(typeof(Speed<Feet, Minutes, Int32>), (5).feet().per().minute().GetType());
            Assert.Equal(444, (444).feet().per().minute().SpeedValue);
            Assert.Equal(Convert.ToInt16(444), ((Duration<Hours, Int16>?)(444)).DurationValue().Value);
            Assert.Null(((Duration<Hours, Int16>?)(null)).DurationValue());
        }
    }
}
