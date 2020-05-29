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
    public class AreaTests : TestsHelperBBase
    {
        [TestMethod]
        public void TestAreaConstructor()
        {
            // test valid units of measure for area
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Areas.MetricNonSI.Hectares, double>(4.4); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, double>(4.4); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Metres, double>(4.4); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Micrometres, double>(4.4); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, double>(4.4); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Nanometres, double>(4.4); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.Uscs.Feet, double>(4.4); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.Uscs.Inches, double>(4.4); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.Uscs.Miles, double>(4.4); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.Uscs.Yards, double>(4.4); }

            // test invalid units of measure of area
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Durations.Days, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Durations.Hours, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Durations.Microseconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Durations.Milliseconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Durations.Minutes, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Durations.Seconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Durations.Ticks, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Masses.MetricSI.Grams, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Masses.MetricSI.Kilograms, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Volumes.MetricNonSI.Litres, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.Length1DUnitOfMeasure, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Areas.Length2DUnitOfMeasure, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Areas.MetricNonSI.MetricNonSIAreaUnitOfMeasure, double>(4.4);");

            // test number data types
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Double>(System.Convert.ToDouble(4.44444)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Double>(System.Convert.ToSingle(4.44444)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Single>(System.Convert.ToSingle(4.44444)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Decimal>(System.Convert.ToDecimal(4.44444)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int64>(System.Convert.ToInt64(4)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt32(4)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int16>(System.Convert.ToInt16(4)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Byte>(System.Convert.ToByte(4)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.SByte>(System.Convert.ToSByte(4)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.UInt16>(System.Convert.ToUInt16(4)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.UInt32>(System.Convert.ToUInt32(4)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.UInt64>(System.Convert.ToUInt64(4)); }
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Char>(System.Convert.ToChar(4));");
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.DateTime>(new System.DateTime(1000)); } // can't stop this from being allowed
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Boolean>(System.Convert.ToBoolean(4));");
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Numerics.BigInteger>(new System.Numerics.BigInteger(4.4)); }
            // and prove it only allows compatible data types
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt32(4)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt16(4)); }
            { var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToByte(4)); }
            AssertCompilationFails("has some invalid arguments", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt64(4));");

            // make sure value gets stored in member variable
            var areaB = new Area<Kilometres, Int32>(3);
            Assert.AreEqual(3, areaB.AreaValue);

            // make sure value can be constructed via its own kind of data type, and that it is an exact copy
            var areaC = new Area<Kilometres, Int32>(areaB);
            Assert.AreEqual(areaB.AreaValue, areaC.AreaValue);
            Assert.AreEqual(3, areaC.AreaValue);
            Assert.AreSame(areaB.UnitOfMeasure, areaC.UnitOfMeasure);

            // make sure value of different unit converts propertly via constructor.
            Assert.AreEqual(25000000, (new Area<Metres, Int32>(new Area<Kilometres, Int32>(25))).AreaValue);
            Assert.AreEqual(25000000, (new Area<Metres, Int32>(new Area<Kilometres, Int64>(25))).AreaValue);
            Assert.AreEqual(30250000, (new Area<Metres, Int32>(new Area<Kilometres, Decimal>(Convert.ToDecimal(30.25)))).AreaValue);
            Assert.AreEqual(30250000, (new Area<Metres, Int32>(new Area<Kilometres, Double>(30.25))).AreaValue);

            // test to make sure we can't use a dimension for the numeric datatype
            AssertCompilationFails("cannot be used as type parameter", @"var areaA = new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>>(44.4);");
        }

        [TestMethod]
        public void TestUnitOfMeasureProperty()
        {
            // make sure the UnitOfMeasure is actually the correct type
            Assert.AreSame(typeof(Kilometres), (new Area<Kilometres, Int32>(33)).UnitOfMeasure.GetType());
            Assert.AreSame(typeof(Kilometres), ((IArea)(new Area<Kilometres, Int32>(33))).UnitOfMeasure.GetType());
        }

        [TestMethod]
        public void TestAreaConvertToFunction()
        {
            var areaA = new Area<Kilometres, Int32>(25);
            var areaB = areaA.ConvertTo<Millimetres, Decimal>();
            Assert.AreEqual(25000000000000, areaB.AreaValue);
            Assert.AreSame(typeof(Millimetres), areaB.UnitOfMeasure.GetType());
            var areaC = new Area<Kilometres, Int32>(25);
            var areaD = areaC.ConvertTo<decimal>();
            Assert.AreEqual(25, areaD.AreaValue);
            Assert.AreSame(typeof(decimal), areaD.AreaValue.GetType());
        }

        [TestMethod]
        public void TestAreaCastingOperators()
        {
            // implicit cast to area
            Area<Millimetres, Double> areaA = 2.2;
            AssertCompilationFails("Cannot implicitly convert type", @"NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double> areaB = System.Convert.ToDecimal(5.5);");

            // explicit cast from length
            AssertCompilationFails("Cannot implicitly convert type", @"double areaB = (new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(3.3));");
            double areaB = (double)(new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(3.3));
            Assert.AreEqual(3.3, areaB);
        }

        [TestMethod]
        public void TestAreaAdditionOperators()
        {
            // adding 2 of the exact same area type ends up with the same type
            {
                var areaA = new Area<Feet, double>(2.2);
                var areaB = new Area<Feet, double>(3.3);
                var areaAB = areaA + areaB;
                Assert.AreSame(areaA.GetType(), areaAB.GetType());
                Assert.AreSame(areaB.GetType(), areaAB.GetType());
                Assert.AreSame(areaA.AreaValue.GetType(), areaAB.AreaValue.GetType());
                Assert.AreSame(areaB.AreaValue.GetType(), areaAB.AreaValue.GetType());
                Assert.AreEqual(5.5, areaAB.AreaValue);
            }

            // adding 2 of different types of areas should end up with the first one's uom as a system.double
            {
                var areaC = new Area<Feet, Int32>(2);
                var areaD = new Area<Feet, Byte>(8);
                var areaCD = areaC + areaD;
                Assert.AreSame(areaC.UnitOfMeasure.GetType(), areaCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), areaCD.AreaValue.GetType());
                Assert.AreEqual(10, areaCD.AreaValue);
            }
            {
                var areaC = new Area<Inches, Int32>(5);
                var areaD = new Area<Feet, Byte>(2);
                var areaCD = areaC + areaD;
                Assert.AreSame(areaC.UnitOfMeasure.GetType(), areaCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), areaCD.AreaValue.GetType());
                Assert.AreEqual(293, areaCD.AreaValue);
            }
            var areaE = new Area<Feet, double>(2.2);
            var areaF = areaE + 5; // c# calls implicit cast to change 5 to area so that it can use the + operator
            Assert.AreEqual(7.2, areaF.AreaValue);
            var areaG = 5 + areaE;
            Assert.AreEqual(7.2, areaG.AreaValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '+' cannot be applied", @"var xyz = (new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) + (new NGenericDimensions.Duration<NGenericDimensions.Duration.Hours, System.Double>(3.3));");
        }

        [TestMethod]
        public void TestAreaSubtractionOperators()
        {
            // subtracting 2 of the exact same area type ends up with the same type
            {
                var areaA = new Area<Feet, double>(2.2);
                var areaB = new Area<Feet, double>(3.3);
                var areaAB = areaA - areaB;
                Assert.AreSame(areaA.GetType(), areaAB.GetType());
                Assert.AreSame(areaB.GetType(), areaAB.GetType());
                Assert.AreSame(areaA.AreaValue.GetType(), areaAB.AreaValue.GetType());
                Assert.AreSame(areaB.AreaValue.GetType(), areaAB.AreaValue.GetType());
                Assert.AreEqual(2.2 - 3.3, areaAB.AreaValue);
            }

            // subtracting 2 of different types of areas should end up with the first one's uon as a system.double
            {
                var areaC = new Area<Feet, Int32>(2);
                var areaD = new Area<Feet, Byte>(8);
                var areaCD = areaC - areaD;
                Assert.AreSame(areaC.UnitOfMeasure.GetType(), areaCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), areaCD.AreaValue.GetType());
                Assert.AreEqual(-6, areaCD.AreaValue);
            }
            {
                var areaC = new Area<Inches, Int32>(5);
                var areaD = new Area<Feet, Byte>(2);
                var areaCD = areaC - areaD;
                Assert.AreSame(areaC.UnitOfMeasure.GetType(), areaCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), areaCD.AreaValue.GetType());
                Assert.AreEqual(-283, areaCD.AreaValue);
            }
            var areaE = new Area<Feet, double>(2.2);
            var areaF = areaE - 5; // c# calls implicit cast to change 5 to area so that it can use the - operator
            Assert.AreEqual(2.2 - 5, areaF.AreaValue);
            var areaG = 5 - areaE;
            Assert.AreEqual(5 - 2.2, areaG.AreaValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '-' cannot be applied", @"var xyz = (new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) - (new NGenericDimensions.Duration<NGenericDimensions.Duration.Hours, System.Double>(3.3));");
        }

        [TestMethod]
        public void TestAreaMultiplicationOperators()
        {
            // multiplying a area with a value should return the same kind of area with the value multiplied
            {
                var areaA = new Area<Inches, Int32>(7);
                var areaB = areaA * 3;
                Assert.AreSame(areaA.GetType(), areaB.GetType());
                Assert.AreEqual(21, areaB.AreaValue);
                var areaC = 3 * areaA;
                Assert.AreSame(areaA.GetType(), areaC.GetType());
                Assert.AreEqual(21, areaC.AreaValue);
            }
        }

        [TestMethod]
        public void TestAreaDivisionOperators()
        {
            // dividing a area by a scalar results with a area of the same uom and a datatype of double
            {
                var areaA = new Area<Millimetres, Int32>(10);
                {
                    var areaB = areaA / Convert.ToByte(2);
                    Assert.AreSame(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.AreEqual(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToInt16(2);
                    Assert.AreSame(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.AreEqual(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToInt32(2);
                    Assert.AreSame(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.AreEqual(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToInt64(2);
                    Assert.AreSame(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.AreEqual(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToDouble(2);
                    Assert.AreSame(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.AreEqual(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToSingle(2);
                    Assert.AreSame(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.AreEqual(10 / 2, areaB.AreaValue);
                }
                {
                    var areaB = areaA / Convert.ToDecimal(2);
                    Assert.AreSame(typeof(Area<Millimetres, double>), areaB.GetType());
                    Assert.AreEqual(10 / 2, areaB.AreaValue);
                }
            }

            // dividing a area by a area results with a scalar of datatype of double.
            {
                var areaA = new Area<Millimetres, Int32>(10);
                var areaB = new Area<Millimetres, Byte>(2);
                var valueC = areaA / areaB;
                Assert.AreSame(typeof(double), valueC.GetType());
                Assert.AreEqual(10 / 2, valueC);
            }
        }

        [TestMethod]
        public void TestAreaComparisonOperators()
        {
            // compare when areas are exactly the same datatype
            {
                var areaA = new Area<Kilometres, Int32>(70);
                var areaB = new Area<Kilometres, Int32>(70);
                var areaC = new Area<Kilometres, Int32>(71);
                Assert.IsTrue(areaA == areaB);
                Assert.IsFalse(areaA == areaC);
                Assert.IsFalse(areaA != areaB);
                Assert.IsTrue(areaA != areaC);
                Assert.IsFalse(areaA > areaB);
                Assert.IsTrue(areaA >= areaB);
                Assert.IsFalse(areaA < areaB);
                Assert.IsTrue(areaA <= areaB);
                Assert.IsFalse(areaA > areaC);
                Assert.IsFalse(areaA >= areaC);
                Assert.IsTrue(areaA < areaC);
                Assert.IsTrue(areaA <= areaC);
                Assert.IsFalse(areaC < areaA);
                Assert.IsFalse(areaC <= areaA);
                Assert.IsTrue(areaC > areaA);
                Assert.IsTrue(areaC >= areaA);
            }

            // compare an area to a scalar
            {
                var areaA = new Area<Kilometres, Int32>(70);
                var areaB = Convert.ToInt32(70);
                var areaC = Convert.ToInt32(71);
                Assert.IsTrue(areaA == areaB);
                Assert.IsTrue(areaB == areaA);
                Assert.IsFalse(areaA == areaC);
                Assert.IsFalse(areaC == areaA);
                Assert.IsFalse(areaA != areaB);
                Assert.IsFalse(areaB != areaA);
                Assert.IsTrue(areaA != areaC);
                Assert.IsTrue(areaC != areaA);
                Assert.IsFalse(areaA > areaB);
                Assert.IsTrue(areaA >= areaB);
                Assert.IsFalse(areaA < areaB);
                Assert.IsTrue(areaA <= areaB);
                Assert.IsFalse(areaA > areaC);
                Assert.IsFalse(areaA >= areaC);
                Assert.IsTrue(areaA < areaC);
                Assert.IsTrue(areaA <= areaC);
                Assert.IsFalse(areaC < areaA);
                Assert.IsFalse(areaC <= areaA);
                Assert.IsTrue(areaC > areaA);
                Assert.IsTrue(areaC >= areaA);
            }

            // compare an area of one datatype to an area of another
            {
                var areaA = new Area<Kilometres, Int32>(70);
                var areaB = new Area<Kilometres, Byte>(70);
                var areaC = new Area<Kilometres, Byte>(71);
                Assert.IsTrue(areaA == areaB);
                Assert.IsFalse(areaA == areaC);
                Assert.IsFalse(areaA != areaB);
                Assert.IsTrue(areaA != areaC);
                Assert.IsFalse(areaA > areaB);
                Assert.IsTrue(areaA >= areaB);
                Assert.IsFalse(areaA < areaB);
                Assert.IsTrue(areaA <= areaB);
                Assert.IsFalse(areaA > areaC);
                Assert.IsFalse(areaA >= areaC);
                Assert.IsTrue(areaA < areaC);
                Assert.IsTrue(areaA <= areaC);
                Assert.IsFalse(areaC < areaA);
                Assert.IsFalse(areaC <= areaA);
                Assert.IsTrue(areaC > areaA);
                Assert.IsTrue(areaC >= areaA);
            }

            // compare an area of a different uom
            {
                var areaA = new Area<Feet, Int32>(2);
                var areaB = new Area<Inches, Int16>(288);
                var areaC = new Area<Inches, Int16>(293);
                Assert.IsTrue(areaA == areaB);
                Assert.IsFalse(areaA == areaC);
                Assert.IsFalse(areaA != areaB);
                Assert.IsTrue(areaA != areaC);
                Assert.IsFalse(areaA > areaB);
                Assert.IsTrue(areaA >= areaB);
                Assert.IsFalse(areaA < areaB);
                Assert.IsTrue(areaA <= areaB);
                Assert.IsFalse(areaA > areaC);
                Assert.IsFalse(areaA >= areaC);
                Assert.IsTrue(areaA < areaC);
                Assert.IsTrue(areaA <= areaC);
                Assert.IsFalse(areaC < areaA);
                Assert.IsFalse(areaC <= areaA);
                Assert.IsTrue(areaC > areaA);
                Assert.IsTrue(areaC >= areaA);
            }

            // compare an area to some other dimension
            AssertCompilationFails(@"Operator '==' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Area<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) == (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '!=' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Area<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) != (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Area<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) < (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<=' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Area<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) <= (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Area<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) > (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>=' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Area<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) >= (new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)));");
        }

        [TestMethod]
        public void TestAreaIDimensionValue()
        {
            Assert.AreEqual(Convert.ToDouble(4), ((IDimension)(new Area<Kilometres, Int32>(4))).Value);
        }

        [TestMethod]
        public void TestAreaToString()
        {
            Assert.AreEqual((4.4).ToString() + " Square Feet", (new Area<Feet, double>(4.4)).ToString());
            Assert.AreEqual((4.4).ToString() + " Square Feet", (new Area<Feet, double>(4.4)).ToString("LU", null));
            Assert.AreEqual((4.4).ToString() + " sq. ft.", (new Area<Feet, double>(4.4)).ToString("SU", null));
            Assert.AreEqual((4.4).ToString(), (new Area<Feet, double>(4.4)).ToString("NU", null));
            Assert.AreEqual((4.4).ToString() + " Square Millimetres", (new Area<Millimetres, double>(4.4)).ToString());
            Assert.AreEqual((4.4).ToString() + " Square Millimetres", (new Area<Millimetres, double>(4.4)).ToString("LU", null));
            Assert.AreEqual((4.4).ToString() + " mm²", (new Area<Millimetres, double>(4.4)).ToString("SU", null));
            Assert.AreEqual((4.4).ToString(), (new Area<Millimetres, double>(4.4)).ToString("NU", null));
        }

        [TestMethod]
        public void TestAreaNumberExtensions()
        {
            Assert.AreSame(typeof(Area<Kilometres, Int32>), (5).square().kilometres().GetType());
            Assert.AreEqual(444, (444).square().kilometres().AreaValue);
            Assert.AreEqual(Convert.ToInt16(444), ((Area<Kilometres, Int16>?)(444)).AreaValue().Value);
            Assert.AreEqual(null, ((Area<Kilometres, Int16>?)(null)).AreaValue());
        }
    }
}
