using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGenericDimensions;
using NGenericDimensions.Lengths;
using NGenericDimensions.Lengths.MetricSI;
using NGenericDimensions.Lengths.Uscs;
using NGenericDimensions.Volumes.MetricNonSI;
using NGenericDimensions.Durations;
using NGenericDimensions.Masses.MetricSI;
using NGenericDimensions.MetricPrefix;
using System.Linq;
using NGenericDimensions.Extensions;
using NGenericDimensions.Extensions.Numbers;

namespace NGenericDimensionsUnitTests
{
    [TestClass]
    public class DurationTests : TestsHelperBBase
    {

        [TestMethod]
        public void TestDurationConstructor()
        {
            // test valid units of measure for duration
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Days, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Milliseconds, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Microseconds, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Ticks, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Deca>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Mega>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Giga>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Tera>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Peta>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Exa>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Deci>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Centi>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Milli>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Micro>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Nano>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Pico>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Femto>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Atto>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4); }

            // test invalid units of measure of duration
            AssertCompilationFails("cannot be used as type parameter", @"var durationA = new NGenericDimensions.Duration<NGenericDimensions.Areas.MetricNonSI.Hectares, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var durationA = new NGenericDimensions.Duration<NGenericDimensions.Lengths.MetricSI.Millimetres, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var durationA = new NGenericDimensions.Duration<NGenericDimensions.Masses.MetricSI.Grams, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var durationA = new NGenericDimensions.Duration<NGenericDimensions.Masses.MetricSI.Kilograms, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var durationA = new NGenericDimensions.Duration<NGenericDimensions.Volumes.MetricNonSI.Litres, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.DurationUnitOfMeasure, double>(4.4);");

            // test number data types
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(System.Convert.ToDouble(4.44444)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(System.Convert.ToSingle(4.44444)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Single>(System.Convert.ToSingle(4.44444)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Decimal>(System.Convert.ToDecimal(4.44444)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int64>(System.Convert.ToInt64(4)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(System.Convert.ToInt32(4)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int16>(System.Convert.ToInt16(4)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Byte>(System.Convert.ToByte(4)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.SByte>(System.Convert.ToSByte(4)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.UInt16>(System.Convert.ToUInt16(4)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.UInt32>(System.Convert.ToUInt32(4)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.UInt64>(System.Convert.ToUInt64(4)); }
            AssertCompilationFails("cannot be used as type parameter", @"var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Char>(System.Convert.ToChar(4));");
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.DateTime>(new System.DateTime(1000)); } // can't stop this from being allowed
            AssertCompilationFails("cannot be used as type parameter", @"var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Boolean>(System.Convert.ToBoolean(4));");
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Numerics.BigInteger>(new System.Numerics.BigInteger(4.4)); }
            // and prove it only allows compatible data types
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(System.Convert.ToInt32(4)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(System.Convert.ToInt16(4)); }
            { var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(System.Convert.ToByte(4)); }
            AssertCompilationFails("has some invalid arguments", @"var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(System.Convert.ToInt64(4));");

            // make sure constructor can take a timespan
            { var durationA = new Duration<Hours, Int32>(TimeSpan.FromDays(2)); }
            Assert.AreEqual(48, (new Duration<Hours, Int32>(TimeSpan.FromDays(2))).HoursValue());
            Assert.AreEqual(777, (new Duration<Ticks, Int32>(TimeSpan.FromTicks(777))).TicksValue());
            Assert.AreEqual(TimeSpan.FromTicks(777), (new Duration<Ticks, Int32>(TimeSpan.FromTicks(777))).TimeSpan);

            // make sure value gets stored in member variable
            var durationB = new Duration<Hours, Int32>(3);
            Assert.AreEqual(3, durationB.DurationValue);

            // make sure value can be constructed via its own kind of data type, and that it is an exact copy
            var durationC = new Duration<Hours, Int32>(durationB);
            Assert.AreEqual(durationB.DurationValue, durationC.DurationValue);
            Assert.AreEqual(3, durationC.DurationValue);
            Assert.AreSame(durationB.UnitOfMeasure, durationC.UnitOfMeasure);

            // make sure value of different unit converts propertly via constructor.
            Assert.AreEqual(120, (new Duration<Seconds, Int32>(new Duration<Minutes, Int32>(2))).DurationValue);
            Assert.AreEqual(120, (new Duration<Seconds, Int32>(new Duration<Minutes, Int64>(2))).DurationValue);
            Assert.AreEqual(132, (new Duration<Seconds, Int32>(new Duration<Minutes, Decimal>(Convert.ToDecimal(2.2)))).DurationValue);
            Assert.AreEqual(132, (new Duration<Seconds, Int32>(new Duration<Minutes, Double>(2.2))).DurationValue);

            // test to make sure we can't use a dimension for the numeric datatype
            AssertCompilationFails("cannot be used as type parameter", @"var durationA = new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>>(44.4);");
        }

        [TestMethod]
        public void TestUnitOfMeasureProperty()
        {
            // make sure the UnitOfMeasure is actually the correct type
            Assert.AreSame(typeof(Hours), (new Duration<Hours, Int32>(33)).UnitOfMeasure.GetType());
            Assert.AreSame(typeof(Hours), ((IDuration)(new Duration<Hours, Int32>(33))).UnitOfMeasure.GetType());
        }

        [TestMethod]
        public void TestDurationConvertToFunction()
        {
            var durationA = new Duration<Hours, Int32>(333);
            var durationB = durationA.ConvertTo<Milliseconds, Decimal>();
            Assert.AreEqual(1198800000, durationB.DurationValue);
            Assert.AreSame(typeof(Milliseconds), durationB.UnitOfMeasure.GetType());
            var durationC = new Duration<Hours, Int32>(333);
            var durationD = durationC.ConvertTo<decimal>();
            Assert.AreEqual(333, durationD.DurationValue);
            Assert.AreSame(typeof(decimal), durationD.DurationValue.GetType());
        }

        [TestMethod]
        public void TestDurationCastingOperators()
        {
            // implicit cast to duration
            Duration<Minutes, Double> durationA = 2.2;
            AssertCompilationFails("Cannot implicitly convert type", @"NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, System.Double> durationB = System.Convert.ToDecimal(5.5);");

            // explicit cast from duration
            AssertCompilationFails("Cannot implicitly convert type", @"double durationB = (new NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, System.Double>(3.3));");
            double durationB = (double)(new NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, System.Double>(3.3));
            Assert.AreEqual(3.3, durationB);

            // explicit cast from TimeSpan
            AssertCompilationFails("Cannot implicitly convert type", @"NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, System.Double> durationE = System.TimeSpan.Zero;");
            TimeSpan timespanC = TimeSpan.FromMinutes(2.2);
            Duration<Minutes, double> durationD = (Duration<Minutes, double>)timespanC;
            Assert.AreEqual(2.2, durationD.DurationValue);
            
            // explicit cast to TimeSpan
            AssertCompilationFails("Cannot implicitly convert type", @"System.TimeSpan timespanH = (new NGenericDimensions.Duration<NGenericDimensions.Durations.Minutes, System.Double>(3.3));");
            var durationF = new Duration<Minutes, double>(2.2);
            TimeSpan timespanG = (TimeSpan)durationF;
            Assert.AreEqual(2.2, timespanG.TotalMinutes);
        }

        [TestMethod]
        public void TestDurationAdditionOperators()
        {
            // adding 2 of the exact same duration type ends up with the same type
            {
                var durationA = new Duration<Minutes, double>(2.2);
                var durationB = new Duration<Minutes, double>(3.3);
                var durationAB = durationA + durationB;
                Assert.AreSame(durationA.GetType(), durationAB.GetType());
                Assert.AreSame(durationB.GetType(), durationAB.GetType());
                Assert.AreSame(durationA.DurationValue.GetType(), durationAB.DurationValue.GetType());
                Assert.AreSame(durationB.DurationValue.GetType(), durationAB.DurationValue.GetType());
                Assert.AreEqual(5.5, durationAB.DurationValue);
            }

            // adding 2 of different types of durations should end up with the first one's uom as a system.double
            {
                var durationC = new Duration<Hours, Int32>(2);
                var durationD = new Duration<Hours, Byte>(8);
                var durationCD = durationC + durationD;
                Assert.AreSame(durationC.UnitOfMeasure.GetType(), durationCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), durationCD.DurationValue.GetType());
                Assert.AreEqual(10, durationCD.DurationValue);
            }
            {
                var durationC = new Duration<Minutes, Int32>(5);
                var durationD = new Duration<Hours, Byte>(2);
                var durationCD = durationC + durationD;
                Assert.AreSame(durationC.UnitOfMeasure.GetType(), durationCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), durationCD.DurationValue.GetType());
                Assert.AreEqual(125, durationCD.DurationValue);
            }
            var durationE = new Duration<Hours, double>(2.2);
            var durationF = durationE + 5; // c# calls implicit cast to change 5 to duration so that it can use the + operator
            Assert.AreEqual(7.2, durationF.DurationValue);
            var durationG = 5 + durationE;
            Assert.AreEqual(7.2, durationG.DurationValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '+' cannot be applied", @"var xyz = (new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) + (new NGenericDimensions.Duration<NGenericDimensions.Duration.Hours, System.Double>(3.3));");
        }

        [TestMethod]
        public void TestDurationSubtractionOperators()
        {
            // subtracting 2 of the exact same duration type ends up with the same type
            {
                var durationA = new Duration<Hours, double>(2.2);
                var durationB = new Duration<Hours, double>(3.3);
                var durationAB = durationA - durationB;
                Assert.AreSame(durationA.GetType(), durationAB.GetType());
                Assert.AreSame(durationB.GetType(), durationAB.GetType());
                Assert.AreSame(durationA.DurationValue.GetType(), durationAB.DurationValue.GetType());
                Assert.AreSame(durationB.DurationValue.GetType(), durationAB.DurationValue.GetType());
                Assert.AreEqual(2.2 - 3.3, durationAB.DurationValue);
            }

            // subtracting 2 of different types of durations should end up with the first one's uon as a system.double
            {
                var durationC = new Duration<Hours, Int32>(2);
                var durationD = new Duration<Hours, Byte>(8);
                var durationCD = durationC - durationD;
                Assert.AreSame(durationC.UnitOfMeasure.GetType(), durationCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), durationCD.DurationValue.GetType());
                Assert.AreEqual(-6, durationCD.DurationValue);
            }
            {
                var durationC = new Duration<Minutes, Int32>(5);
                var durationD = new Duration<Hours, Byte>(2);
                var durationCD = durationC - durationD;
                Assert.AreSame(durationC.UnitOfMeasure.GetType(), durationCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), durationCD.DurationValue.GetType());
                Assert.AreEqual(-115, durationCD.DurationValue);
            }
            var durationE = new Duration<Hours, double>(2.2);
            var durationF = durationE - 5; // c# calls implicit cast to change 5 to duration so that it can use the - operator
            Assert.AreEqual(2.2 - 5, durationF.DurationValue);
            var durationG = 5 - durationE;
            Assert.AreEqual(5 - 2.2, durationG.DurationValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '-' cannot be applied", @"var xyz = (new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) - (new NGenericDimensions.Duration<NGenericDimensions.Duration.Hours, System.Double>(3.3));");
        }

        [TestMethod]
        public void TestDurationMultiplicationOperators()
        {
            // multiplying a duration with a value should return the same kind of duration with the value multiplied
            {
                var durationA = new Duration<Minutes, Int32>(7);
                var durationB = durationA * 3;
                Assert.AreSame(durationA.GetType(), durationB.GetType());
                Assert.AreEqual(21, durationB.DurationValue);
                var durationC = 3 * durationA;
                Assert.AreSame(durationA.GetType(), durationC.GetType());
                Assert.AreEqual(21, durationC.DurationValue);
            }
        }

        [TestMethod]
        public void TestDurationDivisionOperators()
        {
            // dividing a duration by a scalar results with a duration of the same uom and a datatype of double
            {
                var durationA = new Duration<Seconds, Int32>(10);
                {
                    var durationB = durationA / Convert.ToByte(2);
                    Assert.AreSame(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.AreEqual(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToInt16(2);
                    Assert.AreSame(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.AreEqual(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToInt32(2);
                    Assert.AreSame(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.AreEqual(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToInt64(2);
                    Assert.AreSame(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.AreEqual(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToDouble(2);
                    Assert.AreSame(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.AreEqual(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToSingle(2);
                    Assert.AreSame(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.AreEqual(10 / 2, durationB.DurationValue);
                }
                {
                    var durationB = durationA / Convert.ToDecimal(2);
                    Assert.AreSame(typeof(Duration<Seconds, double>), durationB.GetType());
                    Assert.AreEqual(10 / 2, durationB.DurationValue);
                }
            }

            // dividing a duration by a duration results with a scalar of datatype of double.
            {
                var durationA = new Duration<Seconds, Int32>(10);
                var durationB = new Duration<Seconds, Byte>(2);
                var valueC = durationA / durationB;
                Assert.AreSame(typeof(double), valueC.GetType());
                Assert.AreEqual(10 / 2, valueC);
            }
        }

        [TestMethod]
        public void TestDurationComparisonOperators()
        {
            // compare when durationes are exactly the same datatype
            {
                var durationA = new Duration<Hours, Int32>(70);
                var durationB = new Duration<Hours, Int32>(70);
                var durationC = new Duration<Hours, Int32>(71);
                Assert.IsTrue(durationA == durationB);
                Assert.IsFalse(durationA == durationC);
                Assert.IsFalse(durationA != durationB);
                Assert.IsTrue(durationA != durationC);
                Assert.IsFalse(durationA > durationB);
                Assert.IsTrue(durationA >= durationB);
                Assert.IsFalse(durationA < durationB);
                Assert.IsTrue(durationA <= durationB);
                Assert.IsFalse(durationA > durationC);
                Assert.IsFalse(durationA >= durationC);
                Assert.IsTrue(durationA < durationC);
                Assert.IsTrue(durationA <= durationC);
                Assert.IsFalse(durationC < durationA);
                Assert.IsFalse(durationC <= durationA);
                Assert.IsTrue(durationC > durationA);
                Assert.IsTrue(durationC >= durationA);
            }

            // compare a duration to a scalar
            {
                var durationA = new Duration<Hours, Int32>(70);
                var durationB = Convert.ToInt32(70);
                var durationC = Convert.ToInt32(71);
                Assert.IsTrue(durationA == durationB);
                Assert.IsTrue(durationB == durationA);
                Assert.IsFalse(durationA == durationC);
                Assert.IsFalse(durationC == durationA);
                Assert.IsFalse(durationA != durationB);
                Assert.IsFalse(durationB != durationA);
                Assert.IsTrue(durationA != durationC);
                Assert.IsTrue(durationC != durationA);
                Assert.IsFalse(durationA > durationB);
                Assert.IsTrue(durationA >= durationB);
                Assert.IsFalse(durationA < durationB);
                Assert.IsTrue(durationA <= durationB);
                Assert.IsFalse(durationA > durationC);
                Assert.IsFalse(durationA >= durationC);
                Assert.IsTrue(durationA < durationC);
                Assert.IsTrue(durationA <= durationC);
                Assert.IsFalse(durationC < durationA);
                Assert.IsFalse(durationC <= durationA);
                Assert.IsTrue(durationC > durationA);
                Assert.IsTrue(durationC >= durationA);
            }

            // compare a duration of one datatype to a duration of another
            {
                var durationA = new Duration<Hours, Int32>(70);
                var durationB = new Duration<Hours, Byte>(70);
                var durationC = new Duration<Hours, Byte>(71);
                Assert.IsTrue(durationA == durationB);
                Assert.IsFalse(durationA == durationC);
                Assert.IsFalse(durationA != durationB);
                Assert.IsTrue(durationA != durationC);
                Assert.IsFalse(durationA > durationB);
                Assert.IsTrue(durationA >= durationB);
                Assert.IsFalse(durationA < durationB);
                Assert.IsTrue(durationA <= durationB);
                Assert.IsFalse(durationA > durationC);
                Assert.IsFalse(durationA >= durationC);
                Assert.IsTrue(durationA < durationC);
                Assert.IsTrue(durationA <= durationC);
                Assert.IsFalse(durationC < durationA);
                Assert.IsFalse(durationC <= durationA);
                Assert.IsTrue(durationC > durationA);
                Assert.IsTrue(durationC >= durationA);
            }

            // compare a duration of a different uom
            {
                var durationA = new Duration<Hours, Int32>(2);
                var durationB = new Duration<Seconds, Int16>(7200);
                var durationC = new Duration<Seconds, Int16>(7205);
                Assert.IsTrue(durationA == durationB);
                Assert.IsFalse(durationA == durationC);
                Assert.IsFalse(durationA != durationB);
                Assert.IsTrue(durationA != durationC);
                Assert.IsFalse(durationA > durationB);
                Assert.IsTrue(durationA >= durationB);
                Assert.IsFalse(durationA < durationB);
                Assert.IsTrue(durationA <= durationB);
                Assert.IsFalse(durationA > durationC);
                Assert.IsFalse(durationA >= durationC);
                Assert.IsTrue(durationA < durationC);
                Assert.IsTrue(durationA <= durationC);
                Assert.IsFalse(durationC < durationA);
                Assert.IsFalse(durationC <= durationA);
                Assert.IsTrue(durationC > durationA);
                Assert.IsTrue(durationC >= durationA);
            }

            // compare a duration to some other dimension
            AssertCompilationFails(@"Operator '==' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) == (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '!=' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) != (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) < (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<=' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) <= (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) > (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>=' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Int32>(0)) >= (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
        }

        [TestMethod]
        public void TestDurationIDimensionValue()
        {
            Assert.AreEqual(Convert.ToDouble(4), ((IDimension)(new Duration<Hours, Int32>(4))).Value);
        }

        [TestMethod]
        public void TestDurationToString()
        {
            Assert.AreEqual((4.4).ToString() + " Hours", (new Duration<Hours, double>(4.4)).ToString());
            Assert.AreEqual((4.4).ToString() + " Hours", (new Duration<Hours, double>(4.4)).ToString("LU", null));
            Assert.AreEqual((4.4).ToString() + " hr", (new Duration<Hours, double>(4.4)).ToString("SU", null));
            Assert.AreEqual((4.4).ToString(), (new Duration<Hours, double>(4.4)).ToString("NU", null));
            Assert.AreEqual((4.4).ToString() + " Milliseconds", (new Duration<Milliseconds, double>(4.4)).ToString());
            Assert.AreEqual((4.4).ToString() + " Milliseconds", (new Duration<Milliseconds, double>(4.4)).ToString("LU", null));
            Assert.AreEqual((4.4).ToString() + " ms", (new Duration<Milliseconds, double>(4.4)).ToString("SU", null));
            Assert.AreEqual((4.4).ToString(), (new Duration<Milliseconds, double>(4.4)).ToString("NU", null));
        }

        [TestMethod]
        public void TestDurationNumberExtensions()
        {
            Assert.AreSame(typeof(Duration<Hours, Int32>), (5).hours().GetType());
            Assert.AreEqual(444, (444).hours().DurationValue);
            Assert.AreSame(typeof(Speed<Feet, Minutes, Int32>), (5).feet().per().minute().GetType());
            Assert.AreEqual(444, (444).feet().per().minute().SpeedValue);
            Assert.AreEqual(Convert.ToInt16(444), ((Duration<Hours, Int16>?)(444)).DurationValue().Value);
            Assert.AreEqual(null, ((Duration<Hours, Int16>?)(null)).DurationValue());
        }
    }
}
