using System;
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
using Xunit;

namespace NGenericDimensionsUnitTests
{
    public class VolumeTests : TestsHelperBBase
    {
        [Fact]
        public void TestVolumeConstructor()
        {
            // test valid units of measure for volume
            _ = new NGenericDimensions.Volume<NGenericDimensions.Volumes.MetricNonSI.Litres, double>(4.4);
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, double>(4.4);
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Metres, double>(4.4);
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Micrometres, double>(4.4);
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Millimetres, double>(4.4);
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Nanometres, double>(4.4);
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Feet, double>(4.4);
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Inches, double>(4.4);
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Miles, double>(4.4);
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.Uscs.Yards, double>(4.4);

            // test invalid units of measure of volume
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Durations.Days, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Durations.Hours, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Durations.Microseconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Durations.Milliseconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Durations.Minutes, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Durations.Seconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Durations.Ticks, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Grams, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Masses.MetricSI.Kilograms, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Areas.MetricNonSI.Hectares, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Lengths.Length1DUnitOfMeasure, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Volumes.Length3DUnitOfMeasure, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Volumes.MetricNonSI.MetricNonSIVolumeUnitOfMeasure, double>(4.4);");

            // test number data types
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Double>(System.Convert.ToDouble(4.44444));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Double>(System.Convert.ToSingle(4.44444));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Single>(System.Convert.ToSingle(4.44444));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Decimal>(System.Convert.ToDecimal(4.44444));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int64>(System.Convert.ToInt64(4));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt32(4));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int16>(System.Convert.ToInt16(4));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Byte>(System.Convert.ToByte(4));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.SByte>(System.Convert.ToSByte(4));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.UInt16>(System.Convert.ToUInt16(4));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.UInt32>(System.Convert.ToUInt32(4));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.UInt64>(System.Convert.ToUInt64(4));
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Char>(System.Convert.ToChar(4));");
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.DateTime>(new System.DateTime(1000)); // can't stop this from being allowed
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Boolean>(System.Convert.ToBoolean(4));");
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Numerics.BigInteger>(new System.Numerics.BigInteger(4.4));
            // and prove it only allows compatible data types
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt32(4));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt16(4));
            _ = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToByte(4));
            AssertCompilationFails("cannot convert from", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(System.Convert.ToInt64(4));");

            // make sure value gets stored in member variable
            var volumeB = new Volume<Kilometres, Int32>(3);
            Assert.Equal(3, volumeB.VolumeValue);

            // make sure value can be constructed via its own kind of data type, and that it is an exact copy
            var volumeC = new Volume<Kilometres, Int32>(volumeB);
            Assert.Equal(volumeB.VolumeValue, volumeC.VolumeValue);
            Assert.Equal(3, volumeC.VolumeValue);
            Assert.Same(volumeB.UnitOfMeasure, volumeC.UnitOfMeasure);

            // make sure value of different unit converts propertly via constructor.
            Assert.Equal(2000000000, (new Volume<Metres, Int32>(new Volume<Kilometres, Int32>(2))).VolumeValue);
            Assert.Equal(2000000000, (new Volume<Metres, Int32>(new Volume<Kilometres, Int64>(2))).VolumeValue);
            Assert.Equal(166375000000, (new Volume<Metres, Int64>(new Volume<Kilometres, Decimal>(Convert.ToDecimal(166.375)))).VolumeValue);
            Assert.Equal(166375000000, (new Volume<Metres, Int64>(new Volume<Kilometres, Double>(166.375))).VolumeValue);

            // test to make sure we can't use a dimension for the numeric datatype
            AssertCompilationFails("cannot be used as type parameter", @"var volumeA = new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>>(44.4);");
        }

        [Fact]
        public void TestUnitOfMeasureProperty()
        {
            // make sure the UnitOfMeasure is actually the correct type
            Assert.Same(typeof(Kilometres), (new Volume<Kilometres, Int32>(33)).UnitOfMeasure.GetType());
            Assert.Same(typeof(Kilometres), ((IVolume)(new Volume<Kilometres, Int32>(33))).UnitOfMeasure.GetType());
        }

        [Fact]
        public void TestVolumeConvertToFunction()
        {
            var volumeA = new Volume<Kilometres, Int32>(25);
            var volumeB = volumeA.ConvertTo<Millimetres, Decimal>();
            Assert.Equal(Convert.ToDecimal(25000000000000000000.0), volumeB.VolumeValue);
            Assert.Same(typeof(Millimetres), volumeB.UnitOfMeasure.GetType());
            var volumeC = new Volume<Kilometres, Int32>(25);
            var volumeD = volumeC.ConvertTo<decimal>();
            Assert.Equal(25, volumeD.VolumeValue);
            Assert.Same(typeof(decimal), volumeD.VolumeValue.GetType());
        }

        [Fact]
        public void TestVolumeCastingOperators()
        {
            // implicit cast to volume
            Volume<Millimetres, Double> volumeA = 2.2;
            AssertCompilationFails("Cannot implicitly convert type", @"NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double> volumeB = System.Convert.ToDecimal(5.5);");

            // explicit cast from length
            AssertCompilationFails("Cannot implicitly convert type", @"double volumeB = (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(3.3));");
            double volumeB = (double)(new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(3.3));
            Assert.Equal(3.3, volumeB);
        }

        [Fact]
        public void TestVolumeAdditionOperators()
        {
            // adding 2 of the exact same volume type ends up with the same type
            {
                var volumeA = new Volume<Feet, double>(2.2);
                var volumeB = new Volume<Feet, double>(3.3);
                var volumeAB = volumeA + volumeB;
                Assert.Same(volumeA.GetType(), volumeAB.GetType());
                Assert.Same(volumeB.GetType(), volumeAB.GetType());
                Assert.Same(volumeA.VolumeValue.GetType(), volumeAB.VolumeValue.GetType());
                Assert.Same(volumeB.VolumeValue.GetType(), volumeAB.VolumeValue.GetType());
                Assert.Equal(5.5, volumeAB.VolumeValue);
            }

            // adding 2 of different types of volumes should end up with the first one's uom as a system.double
            {
                var volumeC = new Volume<Feet, Int32>(2);
                var volumeD = new Volume<Feet, Byte>(8);
                var volumeCD = volumeC + volumeD;
                Assert.Same(volumeC.UnitOfMeasure.GetType(), volumeCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), volumeCD.VolumeValue.GetType());
                Assert.Equal(10, volumeCD.VolumeValue);
            }
            {
                var volumeC = new Volume<Inches, Int32>(5);
                var volumeD = new Volume<Feet, Byte>(2);
                var volumeCD = volumeC + volumeD;
                Assert.Same(volumeC.UnitOfMeasure.GetType(), volumeCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), volumeCD.VolumeValue.GetType());
                Assert.Equal(3461, volumeCD.VolumeValue);
            }
            var volumeE = new Volume<Feet, double>(2.2);
            var volumeF = volumeE + 5; // c# calls implicit cast to change 5 to volume so that it can use the + operator
            Assert.Equal(7.2, volumeF.VolumeValue);
            var volumeG = 5 + volumeE;
            Assert.Equal(7.2, volumeG.VolumeValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '+' cannot be applied", @"_ = (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) + (new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestVolumeSubtractionOperators()
        {
            // subtracting 2 of the exact same volume type ends up with the same type
            {
                var volumeA = new Volume<Feet, double>(2.2);
                var volumeB = new Volume<Feet, double>(3.3);
                var volumeAB = volumeA - volumeB;
                Assert.Same(volumeA.GetType(), volumeAB.GetType());
                Assert.Same(volumeB.GetType(), volumeAB.GetType());
                Assert.Same(volumeA.VolumeValue.GetType(), volumeAB.VolumeValue.GetType());
                Assert.Same(volumeB.VolumeValue.GetType(), volumeAB.VolumeValue.GetType());
                Assert.Equal(2.2 - 3.3, volumeAB.VolumeValue);
            }

            // subtracting 2 of different types of volumes should end up with the first one's uom as a system.double
            {
                var volumeC = new Volume<Feet, Int32>(2);
                var volumeD = new Volume<Feet, Byte>(8);
                var volumeCD = volumeC - volumeD;
                Assert.Same(volumeC.UnitOfMeasure.GetType(), volumeCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), volumeCD.VolumeValue.GetType());
                Assert.Equal(-6, volumeCD.VolumeValue);
            }
            {
                var volumeC = new Volume<Inches, Int32>(5);
                var volumeD = new Volume<Feet, Byte>(2);
                var volumeCD = volumeC - volumeD;
                Assert.Same(volumeC.UnitOfMeasure.GetType(), volumeCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), volumeCD.VolumeValue.GetType());
                Assert.Equal(-3451, volumeCD.VolumeValue);
            }
            var volumeE = new Volume<Feet, double>(2.2);
            var volumeF = volumeE - 5; // c# calls implicit cast to change 5 to volume so that it can use the - operator
            Assert.Equal(2.2 - 5, volumeF.VolumeValue);
            var volumeG = 5 - volumeE;
            Assert.Equal(5 - 2.2, volumeG.VolumeValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '-' cannot be applied", @"_ = (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Millimetres, System.Double>(2.2)) - (new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestVolumeMultiplicationOperators()
        {
            // multiplying a volume with a value should return the same kind of volume with the value multiplied
            {
                var volumeA = new Volume<Inches, Int32>(7);
                var volumeB = volumeA * 3;
                Assert.Same(volumeA.GetType(), volumeB.GetType());
                Assert.Equal(21, volumeB.VolumeValue);
                var volumeC = 3 * volumeA;
                Assert.Same(volumeA.GetType(), volumeC.GetType());
                Assert.Equal(21, volumeC.VolumeValue);
            }
        }

        [Fact]
        public void TestVolumeDivisionOperators()
        {
            // dividing a volume by a scalar results with a volume of the same uom and a datatype of double
            {
                var volumeA = new Volume<Millimetres, Int32>(10);
                {
                    var volumeB = volumeA / Convert.ToByte(2);
                    Assert.Same(typeof(Volume<Millimetres, double>), volumeB.GetType());
                    Assert.Equal(10 / 2, volumeB.VolumeValue);
                }
                {
                    var volumeB = volumeA / Convert.ToInt16(2);
                    Assert.Same(typeof(Volume<Millimetres, double>), volumeB.GetType());
                    Assert.Equal(10 / 2, volumeB.VolumeValue);
                }
                {
                    var volumeB = volumeA / Convert.ToInt32(2);
                    Assert.Same(typeof(Volume<Millimetres, double>), volumeB.GetType());
                    Assert.Equal(10 / 2, volumeB.VolumeValue);
                }
                {
                    var volumeB = volumeA / Convert.ToInt64(2);
                    Assert.Same(typeof(Volume<Millimetres, double>), volumeB.GetType());
                    Assert.Equal(10 / 2, volumeB.VolumeValue);
                }
                {
                    var volumeB = volumeA / Convert.ToDouble(2);
                    Assert.Same(typeof(Volume<Millimetres, double>), volumeB.GetType());
                    Assert.Equal(10 / 2, volumeB.VolumeValue);
                }
                {
                    var volumeB = volumeA / Convert.ToSingle(2);
                    Assert.Same(typeof(Volume<Millimetres, double>), volumeB.GetType());
                    Assert.Equal(10 / 2, volumeB.VolumeValue);
                }
                {
                    var volumeB = volumeA / Convert.ToDecimal(2);
                    Assert.Same(typeof(Volume<Millimetres, double>), volumeB.GetType());
                    Assert.Equal(10 / 2, volumeB.VolumeValue);
                }
            }

            // dividing a volume by a volume results with a scalar of datatype of double.
            {
                var volumeA = new Volume<Millimetres, Int32>(10);
                var volumeB = new Volume<Millimetres, Byte>(2);
                var valueC = volumeA / volumeB;
                Assert.Same(typeof(double), valueC.GetType());
                Assert.Equal(10 / 2, valueC);
            }
        }

        [Fact]
        public void TestVolumeComparisonOperators()
        {
            // compare when volumes are exactly the same datatype
            {
                var volumeA = new Volume<Kilometres, Int32>(70);
                var volumeB = new Volume<Kilometres, Int32>(70);
                var volumeC = new Volume<Kilometres, Int32>(71);
                Assert.True(volumeA == volumeB);
                Assert.False(volumeA == volumeC);
                Assert.False(volumeA != volumeB);
                Assert.True(volumeA != volumeC);
                Assert.False(volumeA > volumeB);
                Assert.True(volumeA >= volumeB);
                Assert.False(volumeA < volumeB);
                Assert.True(volumeA <= volumeB);
                Assert.False(volumeA > volumeC);
                Assert.False(volumeA >= volumeC);
                Assert.True(volumeA < volumeC);
                Assert.True(volumeA <= volumeC);
                Assert.False(volumeC < volumeA);
                Assert.False(volumeC <= volumeA);
                Assert.True(volumeC > volumeA);
                Assert.True(volumeC >= volumeA);
            }

            // compare an volume to a scalar
            {
                var volumeA = new Volume<Kilometres, Int32>(70);
                var volumeB = Convert.ToInt32(70);
                var volumeC = Convert.ToInt32(71);
                Assert.True(volumeA == volumeB);
                Assert.True(volumeB == volumeA);
                Assert.False(volumeA == volumeC);
                Assert.False(volumeC == volumeA);
                Assert.False(volumeA != volumeB);
                Assert.False(volumeB != volumeA);
                Assert.True(volumeA != volumeC);
                Assert.True(volumeC != volumeA);
                Assert.False(volumeA > volumeB);
                Assert.True(volumeA >= volumeB);
                Assert.False(volumeA < volumeB);
                Assert.True(volumeA <= volumeB);
                Assert.False(volumeA > volumeC);
                Assert.False(volumeA >= volumeC);
                Assert.True(volumeA < volumeC);
                Assert.True(volumeA <= volumeC);
                Assert.False(volumeC < volumeA);
                Assert.False(volumeC <= volumeA);
                Assert.True(volumeC > volumeA);
                Assert.True(volumeC >= volumeA);
            }

            // compare a volume of one datatype to a volume of another
            {
                var volumeA = new Volume<Kilometres, Int32>(70);
                var volumeB = new Volume<Kilometres, Byte>(70);
                var volumeC = new Volume<Kilometres, Byte>(71);
                Assert.True(volumeA == volumeB);
                Assert.False(volumeA == volumeC);
                Assert.False(volumeA != volumeB);
                Assert.True(volumeA != volumeC);
                Assert.False(volumeA > volumeB);
                Assert.True(volumeA >= volumeB);
                Assert.False(volumeA < volumeB);
                Assert.True(volumeA <= volumeB);
                Assert.False(volumeA > volumeC);
                Assert.False(volumeA >= volumeC);
                Assert.True(volumeA < volumeC);
                Assert.True(volumeA <= volumeC);
                Assert.False(volumeC < volumeA);
                Assert.False(volumeC <= volumeA);
                Assert.True(volumeC > volumeA);
                Assert.True(volumeC >= volumeA);
            }

            // compare an volume of a different uom
            {
                var volumeA = new Volume<Feet, Int32>(2);
                var volumeB = new Volume<Inches, Int16>(3456);
                var volumeC = new Volume<Inches, Int16>(3459);
                Assert.True(volumeA == volumeB);
                Assert.False(volumeA == volumeC);
                Assert.False(volumeA != volumeB);
                Assert.True(volumeA != volumeC);
                Assert.False(volumeA > volumeB);
                Assert.True(volumeA >= volumeB);
                Assert.False(volumeA < volumeB);
                Assert.True(volumeA <= volumeB);
                Assert.False(volumeA > volumeC);
                Assert.False(volumeA >= volumeC);
                Assert.True(volumeA < volumeC);
                Assert.True(volumeA <= volumeC);
                Assert.False(volumeC < volumeA);
                Assert.False(volumeC <= volumeA);
                Assert.True(volumeC > volumeA);
                Assert.True(volumeC >= volumeA);
            }

            // compare an volume to some other dimension
            AssertCompilationFails(@"Operator '==' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) == (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '!=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) != (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) < (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) <= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) > (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Area<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)) >= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
        }

        [Fact]
        public void TestVolumeIDimensionValue()
        {
            Assert.Equal(Convert.ToDouble(4), ((IDimension)(new Volume<Kilometres, Int32>(4))).Value);
        }

        [Fact]
        public void TestVolumeToString()
        {
            Assert.Equal((4.4).ToString() + " Cubic Feet", (new Volume<Feet, double>(4.4)).ToString());
            Assert.Equal((4.4).ToString() + " Cubic Feet", (new Volume<Feet, double>(4.4)).ToString("LU", null));
            Assert.Equal((4.4).ToString() + " cu. ft.", (new Volume<Feet, double>(4.4)).ToString("SU", null));
            Assert.Equal((4.4).ToString(), (new Volume<Feet, double>(4.4)).ToString("NU", null));
            Assert.Equal((4.4).ToString() + " Cubic Millimetres", (new Volume<Millimetres, double>(4.4)).ToString());
            Assert.Equal((4.4).ToString() + " Cubic Millimetres", (new Volume<Millimetres, double>(4.4)).ToString("LU", null));
            Assert.Equal((4.4).ToString() + " mm³", (new Volume<Millimetres, double>(4.4)).ToString("SU", null));
            Assert.Equal((4.4).ToString(), (new Volume<Millimetres, double>(4.4)).ToString("NU", null));
        }

        [Fact]
        public void TestVolumeNumberExtensions()
        {
            Assert.Same(typeof(Volume<Kilometres, Int32>), (5).cube().kilometres().GetType());
            Assert.Equal(444, (444).cube().kilometres().VolumeValue);
            Assert.Equal(Convert.ToInt16(444), ((Volume<Kilometres, Int16>?)(444)).VolumeValue().Value);
            Assert.Null(((Volume<Kilometres, Int16>?)(null)).VolumeValue());
        }
    }
}
