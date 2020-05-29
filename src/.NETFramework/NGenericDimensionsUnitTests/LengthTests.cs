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
    public class LengthTests : TestsHelperBBase
    {

        [TestMethod]
        public void TestLengthConstructor()
        {
            // test valid units of measure for length
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, double>(4.4); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Metres, double>(4.4); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Micrometres, double>(4.4); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, double>(4.4); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Nanometres, double>(4.4); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, double>(4.4); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Inches, double>(4.4); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Miles, double>(4.4); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Yards, double>(4.4); }

            // test invalid units of measure of length
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Areas.MetricNonSI.Hectares, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Durations.Days, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Durations.Hours, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Durations.Microseconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Durations.Milliseconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Durations.Minutes, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Durations.Seconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Durations.Ticks, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Masses.MetricSI.Grams, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Masses.MetricSI.Kilograms, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Volumes.MetricNonSI.Litres, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.Length1DUnitOfMeasure, double>(4.4);");

            // test number data types
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Double>(System.Convert.ToDouble(4.44444)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Double>(System.Convert.ToSingle(4.44444)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Single>(System.Convert.ToSingle(4.44444)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Decimal>(System.Convert.ToDecimal(4.44444)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int64>(System.Convert.ToInt64(4)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt32(4)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int16>(System.Convert.ToInt16(4)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Byte>(System.Convert.ToByte(4)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.SByte>(System.Convert.ToSByte(4)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.UInt16>(System.Convert.ToUInt16(4)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.UInt32>(System.Convert.ToUInt32(4)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.UInt64>(System.Convert.ToUInt64(4)); }
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Char>(System.Convert.ToChar(4));");
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.DateTime>(new System.DateTime(1000)); } // can't stop this from being allowed
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Boolean>(System.Convert.ToBoolean(4));");
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Numerics.BigInteger>(new System.Numerics.BigInteger(4.4)); }
            // and prove it only allows compatible data types
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt32(4)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt16(4)); }
            { var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToByte(4)); }
            AssertCompilationFails("has some invalid arguments", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt64(4));");

            // make sure value gets stored in member variable
            var lengthB = new Length<Kilometres, Int32>(3);
            Assert.AreEqual(3, lengthB.LengthValue);

            // make sure value can be constructed via its own kind of data type, and that it is an exact copy
            var lengthC = new Length<Kilometres, Int32>(lengthB);
            Assert.AreEqual(lengthB.LengthValue, lengthC.LengthValue);
            Assert.AreEqual(3, lengthC.LengthValue);
            Assert.AreSame(lengthB.UnitOfMeasure, lengthC.UnitOfMeasure);

            // make sure value of different unit converts propertly via constructor.
            Assert.AreEqual(5000, (new Length<Metres, Int32>(new Length<Kilometres, Int32>(5))).LengthValue);
            Assert.AreEqual(5000, (new Length<Metres, Int32>(new Length<Kilometres, Int64>(5))).LengthValue);
            Assert.AreEqual(5500, (new Length<Metres, Int32>(new Length<Kilometres, Decimal>(Convert.ToDecimal(5.5)))).LengthValue);
            Assert.AreEqual(5500, (new Length<Metres, Int32>(new Length<Kilometres, Double>(5.5))).LengthValue);

            // test to make sure we can't use a dimension for the numeric datatype
            AssertCompilationFails("cannot be used as type parameter", @"var lengthA = new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>>(44.4);");
        }

        [TestMethod]
        public void TestUnitOfMeasureProperty()
        {
            // make sure the UnitOfMeasure is actually the correct type
            Assert.AreSame(typeof(Kilometres), (new Length<Kilometres, Int32>(33)).UnitOfMeasure.GetType());
            Assert.AreSame(typeof(Kilometres), ((ILength)(new Length<Kilometres, Int32>(33))).UnitOfMeasure.GetType());
        }

        [TestMethod]
        public void TestLengthConvertToFunction()
        {
            var lengthA = new Length<Kilometres, Int32>(333);
            var lengthB = lengthA.ConvertTo<Millimetres, Decimal>();
            Assert.AreEqual(333000000, lengthB.LengthValue);
            Assert.AreSame(typeof(Millimetres), lengthB.UnitOfMeasure.GetType());
            var lengthC = new Length<Kilometres, Int32>(333);
            var lengthD = lengthC.ConvertTo<decimal>();
            Assert.AreEqual(333, lengthD.LengthValue);
            Assert.AreSame(typeof(decimal), lengthD.LengthValue.GetType());
        }
        
        [TestMethod]
        public void TestLengthCastingOperators()
        {
            // implicit cast to length
            Length<Millimetres, Double> lengthA = 2.2;
            AssertCompilationFails("Cannot implicitly convert type", @"NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double> lengthB = System.Convert.ToDecimal(5.5);");

            // explicit cast from length
            AssertCompilationFails("Cannot implicitly convert type", @"double lengthB = (new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(3.3));");
            double lengthB = (double)(new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(3.3));
            Assert.AreEqual(3.3, lengthB);
        }

        [TestMethod]
        public void TestLengthAdditionOperators()
        {
            // adding 2 of the exact same length type ends up with the same type
            {
                var lengthA = new Length<Feet, double>(2.2);
                var lengthB = new Length<Feet, double>(3.3);
                var lengthAB = lengthA + lengthB;
                Assert.AreSame(lengthA.GetType(), lengthAB.GetType());
                Assert.AreSame(lengthB.GetType(), lengthAB.GetType());
                Assert.AreSame(lengthA.LengthValue.GetType(), lengthAB.LengthValue.GetType());
                Assert.AreSame(lengthB.LengthValue.GetType(), lengthAB.LengthValue.GetType());
                Assert.AreEqual(5.5, lengthAB.LengthValue);
            }

            // adding 2 of different types of lengths should end up with the first one's uom as a system.double
            {
                var lengthC = new Length<Feet, Int32>(2);
                var lengthD = new Length<Feet, Byte>(8);
                var lengthCD = lengthC + lengthD;
                Assert.AreSame(lengthC.UnitOfMeasure.GetType(), lengthCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), lengthCD.LengthValue.GetType());
                Assert.AreEqual(10, lengthCD.LengthValue);
            }
            {
                var lengthC = new Length<Inches, Int32>(5);
                var lengthD = new Length<Feet, Byte>(2);
                var lengthCD = lengthC + lengthD;
                Assert.AreSame(lengthC.UnitOfMeasure.GetType(), lengthCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), lengthCD.LengthValue.GetType());
                Assert.AreEqual(29, lengthCD.LengthValue);
            }
            var lengthE = new Length<Feet, double>(2.2);
            var lengthF = lengthE + 5; // c# calls implicit cast to change 5 to length so that it can use the + operator
            Assert.AreEqual(7.2, lengthF.LengthValue);
            var lengthG = 5 + lengthE;
            Assert.AreEqual(7.2, lengthG.LengthValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '+' cannot be applied", @"var xyz = (new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) + (new NGenericDimensions.Duration<NGenericDimensions.Duration.Hours, System.Double>(3.3));");
        }

        [TestMethod]
        public void TestLengthSubtractionOperators()
        {
            // subtracting 2 of the exact same length type ends up with the same type
            {
                var lengthA = new Length<Feet, double>(2.2);
                var lengthB = new Length<Feet, double>(3.3);
                var lengthAB = lengthA - lengthB;
                Assert.AreSame(lengthA.GetType(), lengthAB.GetType());
                Assert.AreSame(lengthB.GetType(), lengthAB.GetType());
                Assert.AreSame(lengthA.LengthValue.GetType(), lengthAB.LengthValue.GetType());
                Assert.AreSame(lengthB.LengthValue.GetType(), lengthAB.LengthValue.GetType());
                Assert.AreEqual(2.2-3.3, lengthAB.LengthValue);
            }

            // subtracting 2 of different types of lengths should end up with the first one's uon as a system.double
            {
                var lengthC = new Length<Feet, Int32>(2);
                var lengthD = new Length<Feet, Byte>(8);
                var lengthCD = lengthC - lengthD;
                Assert.AreSame(lengthC.UnitOfMeasure.GetType(), lengthCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), lengthCD.LengthValue.GetType());
                Assert.AreEqual(-6, lengthCD.LengthValue);
            }
            {
                var lengthC = new Length<Inches, Int32>(5);
                var lengthD = new Length<Feet, Byte>(2);
                var lengthCD = lengthC - lengthD;
                Assert.AreSame(lengthC.UnitOfMeasure.GetType(), lengthCD.UnitOfMeasure.GetType());
                Assert.AreSame(typeof(double), lengthCD.LengthValue.GetType());
                Assert.AreEqual(-19, lengthCD.LengthValue);
            }
            var lengthE = new Length<Feet, double>(2.2);
            var lengthF = lengthE - 5; // c# calls implicit cast to change 5 to length so that it can use the - operator
            Assert.AreEqual(2.2-5, lengthF.LengthValue);
            var lengthG = 5 - lengthE;
            Assert.AreEqual(5-2.2, lengthG.LengthValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '-' cannot be applied", @"var xyz = (new NGenericDimensions.Length<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) - (new NGenericDimensions.Duration<NGenericDimensions.Duration.Hours, System.Double>(3.3));");
        }

        [TestMethod]
        public void TestLengthMultiplicationOperators()
        {
            // multiplying a length with a value should return the same kind of length with the value multiplied
            {
                var lengthA = new Length<Inches, Int32>(7);
                var lengthB = lengthA * 3;
                Assert.AreSame(lengthA.GetType(), lengthB.GetType());
                Assert.AreEqual(21, lengthB.LengthValue);
                var lengthC = 3 * lengthA;
                Assert.AreSame(lengthA.GetType(), lengthC.GetType());
                Assert.AreEqual(21, lengthC.LengthValue);
            }

            // multiplying 2 lengths of the same type gives us a nicely defined Area
            {
                var lengthA = new Length<Inches, Int32>(7);
                var lengthB = new Length<Inches, Int32>(4);
                var areaAB = lengthA * lengthB;
                Assert.AreSame(typeof(Area<Inches, Int32>), areaAB.GetType());
                Assert.AreEqual(7 * 4, areaAB.AreaValue);
                Assert.AreSame(typeof(Inches), areaAB.UnitOfMeasure.GetType());
            }

            // multiplying 2 lengths of differing types gives us an Area with a uom of the first type and a datatype of double
            {
                var lengthA = new Length<Inches, Int32>(7);
                var lengthB = new Length<Feet, Byte>(2);
                var areaAB = lengthA * lengthB;
                Assert.AreSame(typeof(Area<Inches, double>), areaAB.GetType());
                Assert.AreEqual(2 * 12 * 7, areaAB.AreaValue);
                Assert.AreSame(typeof(Inches), areaAB.UnitOfMeasure.GetType());
            }

            // multiplying a length by an area that share the same length uom and same datatype gives us a Volume of the same uom and datatype
            {
                var lengthA = new Length<Inches, Int32>(3);
                var areaB = new Area<Inches, Int32>(4);
                var volumeAB = lengthA * areaB;
                Assert.AreSame(typeof(Volume<Inches, Int32>), volumeAB.GetType());
                Assert.AreEqual(3 * 4, volumeAB.VolumeValue);
            }
            {
                var lengthA = new Length<Inches, Int32>(3);
                var areaB = new Area<Inches, Int32>(4);
                var volumeAB = areaB * lengthA;
                Assert.AreSame(typeof(Volume<Inches, Int32>), volumeAB.GetType());
                Assert.AreEqual(3 * 4, volumeAB.VolumeValue);
            }

            // multiplying a length by an area with a different uom and/or datatype gives us a volume of the same uom as the length and a double for the datatype.
            {
                var lengthA = new Length<Inches, Int32>(3);
                var areaB = new Area<Feet, Byte>(4);
                var volumeAB = lengthA * areaB;
                Assert.AreSame(typeof(Volume<Inches, double>), volumeAB.GetType());
                Assert.AreEqual(3 * 4 * 12 * 12, volumeAB.VolumeValue);
            }
            {
                var lengthA = new Length<Inches, Int32>(3);
                var areaB = new Area<Feet, Byte>(4);
                var volumeAB = areaB * lengthA;
                Assert.AreSame(typeof(Volume<Inches, double>), volumeAB.GetType());
                Assert.AreEqual(3 * 4 * 12 * 12, volumeAB.VolumeValue);
            }
        }

        [TestMethod]
        public void TestLengthDivisionOperators()
        {
            // dividing a length by a scalar results with a length of the same uom and a datatype of double
            {
                var lengthA = new Length<Inches, Int32>(10);
                {
                    var lengthB = lengthA / Convert.ToByte(2);
                    Assert.AreSame(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.AreEqual(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToInt16(2);
                    Assert.AreSame(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.AreEqual(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToInt32(2);
                    Assert.AreSame(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.AreEqual(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToInt64(2);
                    Assert.AreSame(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.AreEqual(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToDouble(2);
                    Assert.AreSame(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.AreEqual(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToSingle(2);
                    Assert.AreSame(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.AreEqual(10 / 2, lengthB.LengthValue);
                }
                {
                    var lengthB = lengthA / Convert.ToDecimal(2);
                    Assert.AreSame(typeof(Length<Inches, double>), lengthB.GetType());
                    Assert.AreEqual(10 / 2, lengthB.LengthValue);
                }
            }

            // dividing a length by a length results with a scalar of datatype of double.
            {
                var lengthA = new Length<Inches, Int32>(10);
                var lengthB = new Length<Inches, Byte>(2);
                var valueC = lengthA / lengthB;
                Assert.AreSame(typeof(double), valueC.GetType());
                Assert.AreEqual(10 / 2, valueC);
            }

            // dividing an area by a length results with a length of same UOM as length being divided by and a datatype of double
            {
                var areaA = new Area<Kilometres, UInt32>(4);
                var lengthB = new Length<Millimetres, Decimal>(Convert.ToDecimal(100000));
                var lengthC = areaA / lengthB;
                Assert.AreSame(typeof(double), lengthC.LengthValue.GetType());
                Assert.AreSame(typeof(Millimetres), lengthC.UnitOfMeasure.GetType());
                Assert.AreEqual(40000000, lengthC.LengthValue);
            }

            // dividing a length by duration returns Speed of that uom of double.
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Days, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Days, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Hours, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Hours, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Minutes, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Minutes, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Milliseconds, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Milliseconds, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Microseconds, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Microseconds, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = TimeSpan.FromMilliseconds(7000);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds, double>), speedAB.GetType());
                Assert.AreEqual(70 / (7000 / 1000), speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Deca>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Deca>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Hecto>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Hecto>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Kilo>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Kilo>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Mega>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Mega>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Giga>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Giga>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Tera>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Tera>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Peta>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Peta>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Exa>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Exa>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Zetta>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Zetta>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Yotta>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Yotta>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Deci>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Deci>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Centi>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Centi>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Milli>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Milli>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Micro>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Micro>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Nano>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Nano>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Pico>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Pico>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Femto>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Femto>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Atto>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Atto>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Zepto>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Zepto>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
            {
                var lengthA = new Length<Miles, Int32>(70);
                var durationB = new Duration<Seconds<Yocto>, Int32>(7);
                var speedAB = lengthA / durationB;
                Assert.AreSame(typeof(Speed<Miles, Seconds<Yocto>, double>), speedAB.GetType());
                Assert.AreEqual(70 / 7, speedAB.SpeedValue);
            }
        }

        [TestMethod]
        public void TestLengthComparisonOperators()
        {
            // compare when lengths are exactly the same datatype
            {
                var lengthA = new Length<Miles, Int32>(70);
                var lengthB = new Length<Miles, Int32>(70);
                var lengthC = new Length<Miles, Int32>(71);
                Assert.IsTrue(lengthA == lengthB);
                Assert.IsFalse(lengthA == lengthC);
                Assert.IsFalse(lengthA != lengthB);
                Assert.IsTrue(lengthA != lengthC);
                Assert.IsFalse(lengthA > lengthB);
                Assert.IsTrue(lengthA >= lengthB);
                Assert.IsFalse(lengthA < lengthB);
                Assert.IsTrue(lengthA <= lengthB);
                Assert.IsFalse(lengthA > lengthC);
                Assert.IsFalse(lengthA >= lengthC);
                Assert.IsTrue(lengthA < lengthC);
                Assert.IsTrue(lengthA <= lengthC);
                Assert.IsFalse(lengthC < lengthA);
                Assert.IsFalse(lengthC <= lengthA);
                Assert.IsTrue(lengthC > lengthA);
                Assert.IsTrue(lengthC >= lengthA);
            }

            // compare a length to a scalar
            {
                var lengthA = new Length<Miles, Int32>(70);
                var lengthB = Convert.ToInt32(70);
                var lengthC = Convert.ToInt32(71);
                Assert.IsTrue(lengthA == lengthB);
                Assert.IsTrue(lengthB == lengthA);
                Assert.IsFalse(lengthA == lengthC);
                Assert.IsFalse(lengthC == lengthA);
                Assert.IsFalse(lengthA != lengthB);
                Assert.IsFalse(lengthB != lengthA);
                Assert.IsTrue(lengthA != lengthC);
                Assert.IsTrue(lengthC != lengthA);
                Assert.IsFalse(lengthA > lengthB);
                Assert.IsTrue(lengthA >= lengthB);
                Assert.IsFalse(lengthA < lengthB);
                Assert.IsTrue(lengthA <= lengthB);
                Assert.IsFalse(lengthA > lengthC);
                Assert.IsFalse(lengthA >= lengthC);
                Assert.IsTrue(lengthA < lengthC);
                Assert.IsTrue(lengthA <= lengthC);
                Assert.IsFalse(lengthC < lengthA);
                Assert.IsFalse(lengthC <= lengthA);
                Assert.IsTrue(lengthC > lengthA);
                Assert.IsTrue(lengthC >= lengthA);
            }

            // compare a length of one datatype to a length of another
            {
                var lengthA = new Length<Miles, Int32>(70);
                var lengthB = new Length<Miles, Byte>(70);
                var lengthC = new Length<Miles, Byte>(71);
                Assert.IsTrue(lengthA == lengthB);
                Assert.IsFalse(lengthA == lengthC);
                Assert.IsFalse(lengthA != lengthB);
                Assert.IsTrue(lengthA != lengthC);
                Assert.IsFalse(lengthA > lengthB);
                Assert.IsTrue(lengthA >= lengthB);
                Assert.IsFalse(lengthA < lengthB);
                Assert.IsTrue(lengthA <= lengthB);
                Assert.IsFalse(lengthA > lengthC);
                Assert.IsFalse(lengthA >= lengthC);
                Assert.IsTrue(lengthA < lengthC);
                Assert.IsTrue(lengthA <= lengthC);
                Assert.IsFalse(lengthC < lengthA);
                Assert.IsFalse(lengthC <= lengthA);
                Assert.IsTrue(lengthC > lengthA);
                Assert.IsTrue(lengthC >= lengthA);
            }

            // compare a length of a different uon
            {
                var lengthA = new Length<Feet, Int32>(2);
                var lengthB = new Length<Inches, Byte>(24);
                var lengthC = new Length<Inches, Byte>(25);
                Assert.IsTrue(lengthA == lengthB);
                Assert.IsFalse(lengthA == lengthC);
                Assert.IsFalse(lengthA != lengthB);
                Assert.IsTrue(lengthA != lengthC);
                Assert.IsFalse(lengthA > lengthB);
                Assert.IsTrue(lengthA >= lengthB);
                Assert.IsFalse(lengthA < lengthB);
                Assert.IsTrue(lengthA <= lengthB);
                Assert.IsFalse(lengthA > lengthC);
                Assert.IsFalse(lengthA >= lengthC);
                Assert.IsTrue(lengthA < lengthC);
                Assert.IsTrue(lengthA <= lengthC);
                Assert.IsFalse(lengthC < lengthA);
                Assert.IsFalse(lengthC <= lengthA);
                Assert.IsTrue(lengthC > lengthA);
                Assert.IsTrue(lengthC >= lengthA);
            }

            // compare a length to some other dimension
            AssertCompilationFails(@"Operator '==' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) == (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '!=' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) != (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) < (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<=' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) <= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) > (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>=' cannot be applied to operands", @"var xyz = ((new NGenericDimensions.Length<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)) >= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, System.Int32>(0)));");
        }

        [TestMethod]
        public void TestLengthIDimensionValue()
        {
            Assert.AreEqual(Convert.ToDouble(4), ((IDimension)(new Length<Miles, Int32>(4))).Value);
        }

        [TestMethod]
        public void TestLengthSquared()
        {
            var lengthA = new Length<Feet, Int32>(5);
            Assert.AreSame(typeof(Area<Feet, Int32>), lengthA.Squared.GetType());
            Assert.AreEqual(25, lengthA.Squared.AreaValue);
        }

        [TestMethod]
        public void TestLengthCubed()
        {
            var lengthA = new Length<Feet, Int32>(5);
            Assert.AreSame(typeof(Volume<Feet, Int32>), lengthA.Cubed.GetType());
            Assert.AreEqual(125, lengthA.Cubed.VolumeValue);
        }

        [TestMethod]
        public void TestLengthToString()
        {
            Assert.AreEqual((4.4).ToString() + " Feet", (new Length<Feet, double>(4.4)).ToString());
            Assert.AreEqual((4.4).ToString() + " Feet", (new Length<Feet, double>(4.4)).ToString("LU", null));
            Assert.AreEqual((4.4).ToString() + " ft.", (new Length<Feet, double>(4.4)).ToString("SU", null));
            Assert.AreEqual((4.4).ToString(), (new Length<Feet, double>(4.4)).ToString("NU", null));
            Assert.AreEqual((4.4).ToString() + " Millimetres", (new Length<Millimetres, double>(4.4)).ToString());
            Assert.AreEqual((4.4).ToString() + " Millimetres", (new Length<Millimetres, double>(4.4)).ToString("LU", null));
            Assert.AreEqual((4.4).ToString() + " mm", (new Length<Millimetres, double>(4.4)).ToString("SU", null));
            Assert.AreEqual((4.4).ToString(), (new Length<Millimetres, double>(4.4)).ToString("NU", null));
        }

        [TestMethod]
        public void TestLengthNumberExtensions()
        {
            Assert.AreSame(typeof(Length<Feet, Int32>), (5).feet().GetType());
            Assert.AreEqual(444, (444).feet().LengthValue);
            Assert.AreSame(typeof(Speed<Feet, Minutes, Int32>), (5).feet().per().minute().GetType());
            Assert.AreEqual(444, (444).feet().per().minute().SpeedValue);
            Assert.AreEqual(Convert.ToInt16(444), ((Length<Feet, Int16>?)(444)).LengthValue().Value);
            Assert.AreEqual(null, ((Length<Feet, Int16>?)(null)).LengthValue());
            Assert.AreEqual(15, ((15).square().feet()).AreaValue);
            Assert.AreSame(typeof(Area<Feet, Int32>), ((15).square().feet()).GetType());
        }
    }
}
