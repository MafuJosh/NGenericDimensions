using System;
using NGenericDimensions;
using NGenericDimensions.Masses;
using NGenericDimensions.Masses.MetricSI;
using NGenericDimensions.Volumes.MetricNonSI;
using NGenericDimensions.Durations;
using NGenericDimensions.MetricPrefix;
using System.Linq;
using NGenericDimensions.Extensions;
using NGenericDimensions.Extensions.Numbers;
using Xunit;

namespace NGenericDimensionsUnitTests
{
    public class MassTests : TestsHelperBBase
    {
        [Fact]
        public void TestMassConstructor()
        {
            // test valid units of measure for mass
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, double>(4.4);
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Grams, double>(4.4);

            // test invalid units of measure of mass
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Areas.MetricNonSI.Hectares, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Durations.Days, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Durations.Hours, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Durations.Microseconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Durations.Milliseconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Durations.Minutes, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Durations.Seconds, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Durations.Ticks, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Lengths.MetricSI.Metres, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Lengths.Uscs.Feet, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Volumes.MetricNonSI.Litres, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Lengths.Length1DUnitOfMeasure, double>(4.4);");

            // test number data types
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Double>(System.Convert.ToDouble(4.44444));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Double>(System.Convert.ToSingle(4.44444));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Single>(System.Convert.ToSingle(4.44444));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Decimal>(System.Convert.ToDecimal(4.44444));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int64>(System.Convert.ToInt64(4));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(System.Convert.ToInt32(4));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int16>(System.Convert.ToInt16(4));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Byte>(System.Convert.ToByte(4));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.SByte>(System.Convert.ToSByte(4));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.UInt16>(System.Convert.ToUInt16(4));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.UInt32>(System.Convert.ToUInt32(4));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.UInt64>(System.Convert.ToUInt64(4));
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Char>(System.Convert.ToChar(4));");
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.DateTime>(new System.DateTime(1000)); // can't stop this from being allowed
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Boolean>(System.Convert.ToBoolean(4));");
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Numerics.BigInteger>(new System.Numerics.BigInteger(4.4));
            // and prove it only allows compatible data types
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(System.Convert.ToInt32(4));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(System.Convert.ToInt16(4));
            _ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(System.Convert.ToByte(4));
            AssertCompilationFails("cannot convert from", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(System.Convert.ToInt64(4));");

            // make sure value gets stored in member variable
            var massB = new Mass<Kilograms, Int32>(3);
            Assert.Equal(3, massB.MassValue);

            // make sure value can be constructed via its own kind of data type, and that it is an exact copy
            var massC = new Mass<Kilograms, Int32>(massB);
            Assert.Equal(massB.MassValue, massC.MassValue);
            Assert.Equal(3, massC.MassValue);
            Assert.Same(massB.UnitOfMeasure, massC.UnitOfMeasure);

            // make sure value of different unit converts propertly via constructor.
            Assert.Equal(5000, (new Mass<Grams, Int32>(new Mass<Kilograms, Int32>(5))).MassValue);
            Assert.Equal(5000, (new Mass<Grams, Int32>(new Mass<Kilograms, Int64>(5))).MassValue);
            Assert.Equal(5500, (new Mass<Grams, Int32>(new Mass<Kilograms, Decimal>(Convert.ToDecimal(5.5)))).MassValue);
            Assert.Equal(5500, (new Mass<Grams, Int32>(new Mass<Kilograms, Double>(5.5))).MassValue);

            // test to make sure we can't use a dimension for the numeric datatype
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Double>>(44.4);");
        }

        [Fact]
        public void TestUnitOfMeasureProperty()
        {
            // make sure the UnitOfMeasure is actually the correct type
            Assert.Same(typeof(Kilograms), (new Mass<Kilograms, Int32>(33)).UnitOfMeasure.GetType());
            Assert.Same(typeof(Kilograms), ((IMass)(new Mass<Kilograms, Int32>(33))).UnitOfMeasure.GetType());
        }


        [Fact]
        public void TestmassConvertToFunction()
        {
            var massA = new Mass<Kilograms, Int32>(333);
            var massB = massA.ConvertTo<Grams, Decimal>();
            Assert.Equal(333000, massB.MassValue);
            Assert.Same(typeof(Grams), massB.UnitOfMeasure.GetType());
            var massC = new Mass<Kilograms, Int32>(333);
            var massD = massC.ConvertTo<decimal>();
            Assert.Equal(333, massD.MassValue);
            Assert.Same(typeof(decimal), massD.MassValue.GetType());
        }

        [Fact]
        public void TestmassCastingOperators()
        {
            // implicit cast to mass
            Mass<Kilograms, Double> massA = 2.2;
            AssertCompilationFails("Cannot implicitly convert type", @"NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Double> massB = System.Convert.ToDecimal(5.5);");

            // explicit cast from mass
            AssertCompilationFails("Cannot implicitly convert type", @"double massB = (new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Double>(3.3));");
            double massB = (double)(new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Double>(3.3));
            Assert.Equal(3.3, massB);
        }

        [Fact]
        public void TestmassAdditionOperators()
        {
            // adding 2 of the exact same mass type ends up with the same type
            {
                var massA = new Mass<Kilograms, double>(2.2);
                var massB = new Mass<Kilograms, double>(3.3);
                var massAB = massA + massB;
                Assert.Same(massA.GetType(), massAB.GetType());
                Assert.Same(massB.GetType(), massAB.GetType());
                Assert.Same(massA.MassValue.GetType(), massAB.MassValue.GetType());
                Assert.Same(massB.MassValue.GetType(), massAB.MassValue.GetType());
                Assert.Equal(5.5, massAB.MassValue);
            }

            // adding 2 of different types of masses should end up with the first one's uon as a system.double
            {
                var massC = new Mass<Kilograms, Int32>(2);
                var massD = new Mass<Kilograms, Byte>(8);
                var massCD = massC + massD;
                Assert.Same(massC.UnitOfMeasure.GetType(), massCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), massCD.MassValue.GetType());
                Assert.Equal(10, massCD.MassValue);
            }
            {
                var massC = new Mass<Grams, Int32>(5);
                var massD = new Mass<Kilograms, Byte>(2);
                var massCD = massC + massD;
                Assert.Same(massC.UnitOfMeasure.GetType(), massCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), massCD.MassValue.GetType());
                Assert.Equal(2005, massCD.MassValue);
            }
            var massE = new Mass<Kilograms, double>(2.2);
            var massF = massE + 5; // c# calls implicit cast to change 5 to mass so that it can use the + operator
            Assert.Equal(7.2, massF.MassValue);
            var massG = 5 + massE;
            Assert.Equal(7.2, massG.MassValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '+' cannot be applied", @"_ = (new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Double>(2.2)) + (new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestMassSubtractionOperators()
        {
            // subtracting 2 of the exact same mass type ends up with the same type
            {
                var massA = new Mass<Kilograms, double>(2.2);
                var massB = new Mass<Kilograms, double>(3.3);
                var massAB = massA - massB;
                Assert.Same(massA.GetType(), massAB.GetType());
                Assert.Same(massB.GetType(), massAB.GetType());
                Assert.Same(massA.MassValue.GetType(), massAB.MassValue.GetType());
                Assert.Same(massB.MassValue.GetType(), massAB.MassValue.GetType());
                Assert.Equal(2.2 - 3.3, massAB.MassValue);
            }

            // subtracting 2 of different types of masses should end up with the first one's uom as a system.double
            {
                var massC = new Mass<Kilograms, Int32>(2);
                var massD = new Mass<Kilograms, Byte>(8);
                var massCD = massC - massD;
                Assert.Same(massC.UnitOfMeasure.GetType(), massCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), massCD.MassValue.GetType());
                Assert.Equal(-6, massCD.MassValue);
            }
            {
                var massC = new Mass<Grams, Int32>(5);
                var massD = new Mass<Kilograms, Byte>(2);
                var massCD = massC - massD;
                Assert.Same(massC.UnitOfMeasure.GetType(), massCD.UnitOfMeasure.GetType());
                Assert.Same(typeof(double), massCD.MassValue.GetType());
                Assert.Equal(-1995, massCD.MassValue);
            }
            var massE = new Mass<Kilograms, double>(2.2);
            var massF = massE - 5; // c# calls implicit cast to change 5 to mass so that it can use the - operator
            Assert.Equal(2.2 - 5, massF.MassValue);
            var massG = 5 - massE;
            Assert.Equal(5 - 2.2, massG.MassValue);

            // don't allow adding a different dimension to it
            AssertCompilationFails(@"Operator '-' cannot be applied", @"_ = (new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Double>(2.2)) - (new NGenericDimensions.Duration<NGenericDimensions.Durations.Hours, System.Double>(3.3));");
        }

        [Fact]
        public void TestMassMultiplicationOperators()
        {
            // multiplying a mass with a value should return the same kind of mass with the value multiplied
            {
                var massA = new Mass<Grams, Int32>(7);
                var massB = massA * 3;
                Assert.Same(massA.GetType(), massB.GetType());
                Assert.Equal(21, massB.MassValue);
                var massC = 3 * massA;
                Assert.Same(massA.GetType(), massC.GetType());
                Assert.Equal(21, massC.MassValue);
            }
        }

        [Fact]
        public void TestMassDivisionOperators()
        {
            // dividing a mass by a scalar results with a mass of the same uom and a datatype of double
            {
                var massA = new Mass<Grams, Int32>(10);
                {
                    var massB = massA / Convert.ToByte(2);
                    Assert.Same(typeof(Mass<Grams, double>), massB.GetType());
                    Assert.Equal(10 / 2, massB.MassValue);
                }
                {
                    var massB = massA / Convert.ToInt16(2);
                    Assert.Same(typeof(Mass<Grams, double>), massB.GetType());
                    Assert.Equal(10 / 2, massB.MassValue);
                }
                {
                    var massB = massA / Convert.ToInt32(2);
                    Assert.Same(typeof(Mass<Grams, double>), massB.GetType());
                    Assert.Equal(10 / 2, massB.MassValue);
                }
                {
                    var massB = massA / Convert.ToInt64(2);
                    Assert.Same(typeof(Mass<Grams, double>), massB.GetType());
                    Assert.Equal(10 / 2, massB.MassValue);
                }
                {
                    var massB = massA / Convert.ToDouble(2);
                    Assert.Same(typeof(Mass<Grams, double>), massB.GetType());
                    Assert.Equal(10 / 2, massB.MassValue);
                }
                {
                    var massB = massA / Convert.ToSingle(2);
                    Assert.Same(typeof(Mass<Grams, double>), massB.GetType());
                    Assert.Equal(10 / 2, massB.MassValue);
                }
                {
                    var massB = massA / Convert.ToDecimal(2);
                    Assert.Same(typeof(Mass<Grams, double>), massB.GetType());
                    Assert.Equal(10 / 2, massB.MassValue);
                }
            }

            // dividing a mass by a mass results with a scalar of datatype of double.
            {
                var massA = new Mass<Grams, Int32>(10);
                var massB = new Mass<Grams, Byte>(2);
                var valueC = massA / massB;
                Assert.Same(typeof(double), valueC.GetType());
                Assert.Equal(10 / 2, valueC);
            }
        }

        [Fact]
        public void TestMassComparisonOperators()
        {
            // compare when masses are exactly the same datatype
            {
                var massA = new Mass<Kilograms, Int32>(70);
                var massB = new Mass<Kilograms, Int32>(70);
                var massC = new Mass<Kilograms, Int32>(71);
                Assert.True(massA == massB);
                Assert.False(massA == massC);
                Assert.False(massA != massB);
                Assert.True(massA != massC);
                Assert.False(massA > massB);
                Assert.True(massA >= massB);
                Assert.False(massA < massB);
                Assert.True(massA <= massB);
                Assert.False(massA > massC);
                Assert.False(massA >= massC);
                Assert.True(massA < massC);
                Assert.True(massA <= massC);
                Assert.False(massC < massA);
                Assert.False(massC <= massA);
                Assert.True(massC > massA);
                Assert.True(massC >= massA);
            }

            // compare a mass to a scalar
            {
                var massA = new Mass<Kilograms, Int32>(70);
                var massB = Convert.ToInt32(70);
                var massC = Convert.ToInt32(71);
                Assert.True(massA == massB);
                Assert.True(massB == massA);
                Assert.False(massA == massC);
                Assert.False(massC == massA);
                Assert.False(massA != massB);
                Assert.False(massB != massA);
                Assert.True(massA != massC);
                Assert.True(massC != massA);
                Assert.False(massA > massB);
                Assert.True(massA >= massB);
                Assert.False(massA < massB);
                Assert.True(massA <= massB);
                Assert.False(massA > massC);
                Assert.False(massA >= massC);
                Assert.True(massA < massC);
                Assert.True(massA <= massC);
                Assert.False(massC < massA);
                Assert.False(massC <= massA);
                Assert.True(massC > massA);
                Assert.True(massC >= massA);
            }

            // compare a mass of one datatype to a mass of another
            {
                var massA = new Mass<Kilograms, Int32>(70);
                var massB = new Mass<Kilograms, Byte>(70);
                var massC = new Mass<Kilograms, Byte>(71);
                Assert.True(massA == massB);
                Assert.False(massA == massC);
                Assert.False(massA != massB);
                Assert.True(massA != massC);
                Assert.False(massA > massB);
                Assert.True(massA >= massB);
                Assert.False(massA < massB);
                Assert.True(massA <= massB);
                Assert.False(massA > massC);
                Assert.False(massA >= massC);
                Assert.True(massA < massC);
                Assert.True(massA <= massC);
                Assert.False(massC < massA);
                Assert.False(massC <= massA);
                Assert.True(massC > massA);
                Assert.True(massC >= massA);
            }

            // compare a mass of a different uom
            {
                var massA = new Mass<Kilograms, Int32>(2);
                var massB = new Mass<Grams, Int16>(2000);
                var massC = new Mass<Grams, Int16>(2005);
                Assert.True(massA == massB);
                Assert.False(massA == massC);
                Assert.False(massA != massB);
                Assert.True(massA != massC);
                Assert.False(massA > massB);
                Assert.True(massA >= massB);
                Assert.False(massA < massB);
                Assert.True(massA <= massB);
                Assert.False(massA > massC);
                Assert.False(massA >= massC);
                Assert.True(massA < massC);
                Assert.True(massA <= massC);
                Assert.False(massC < massA);
                Assert.False(massC <= massA);
                Assert.True(massC > massA);
                Assert.True(massC >= massA);
            }

            // compare a mass to some other dimension
            AssertCompilationFails(@"Operator '==' cannot be applied to operands", @"_ = ((new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) == (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '!=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) != (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<' cannot be applied to operands", @"_ = ((new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) < (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '<=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) <= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>' cannot be applied to operands", @"_ = ((new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) > (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
            AssertCompilationFails(@"Operator '>=' cannot be applied to operands", @"_ = ((new NGenericDimensions.Mass<NGenericDimensions.Masses.MetricSI.Kilograms, System.Int32>(0)) >= (new NGenericDimensions.Volume<NGenericDimensions.Lengths.MetricSI.Kilometres, System.Int32>(0)));");
        }

        [Fact]
        public void TestMassIDimensionValue()
        {
            Assert.Equal(Convert.ToDouble(4), ((IDimension)(new Mass<Kilograms, Int32>(4))).Value);
        }

        [Fact]
        public void TestMassToString()
        {
            Assert.Equal((4.4).ToString(), (new Mass<Kilograms, double>(4.4)).ToString("NU", null));
            Assert.Equal((4.4).ToString() + " Kilograms", (new Mass<Kilograms, double>(4.4)).ToString());
            Assert.Equal((4.4).ToString() + " Kilograms", (new Mass<Kilograms, double>(4.4)).ToString("LU", null));
            Assert.Equal((4.4).ToString() + " kg", (new Mass<Kilograms, double>(4.4)).ToString("SU", null));
            Assert.Equal((4.4).ToString(), (new Mass<Kilograms, double>(4.4)).ToString("NU", null));
        }

        [Fact]
        public void TestMassNumberExtensions()
        {
            Assert.Same(typeof(Mass<Kilograms, Int32>), (5).kilograms().GetType());
            Assert.Equal(444, (444).kilograms().MassValue);
            Assert.Equal(Convert.ToInt16(444), ((Mass<Kilograms, Int16>?)(444)).MassValue().Value);
            Assert.Null(((Mass<Kilograms, Int16>?)(null)).MassValue());
        }
    }
}
