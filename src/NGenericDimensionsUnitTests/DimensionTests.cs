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
    public class DimensionTests : TestsHelperBBase
    {
        [TestMethod]
        public void TestIDimension()
        {
            // make sure each dimension applies the IDimension interface.

            var lengthA = new Length<Kilometres, double>(4.4);
            Assert.IsInstanceOfType(lengthA, typeof(IDimension));
            Assert.AreEqual((lengthA as IDimension).Value, 4.4);

            var durationA = new Duration<Seconds, double>(4.4);
            Assert.IsInstanceOfType(durationA, typeof(IDimension));
            Assert.AreEqual((durationA as IDimension).Value, 4.4);

            var areaA = new Area<Kilometres, double>(4.4);
            Assert.IsInstanceOfType(areaA, typeof(IDimension));
            Assert.AreEqual((areaA as IDimension).Value, 4.4);

            var massA = new Mass<Kilograms, double>(4.4);
            Assert.IsInstanceOfType(massA, typeof(IDimension));
            Assert.AreEqual((massA as IDimension).Value, 4.4);

            var speedA = new Speed<Kilometres, Seconds, double>(4.4);
            Assert.IsInstanceOfType(speedA, typeof(IDimension));
            Assert.AreEqual((speedA as IDimension).Value, 4.4);

            var volumeA = new Volume<Litres, double>(4.4);
            Assert.IsInstanceOfType(volumeA, typeof(IDimension));
            Assert.AreEqual((volumeA as IDimension).Value, 4.4);

            var volumeB = new Volume<Litres<Kilo>, double>(4.4);
            Assert.IsInstanceOfType(volumeB, typeof(IDimension));
            Assert.AreEqual((volumeB as IDimension).Value, 4.4);
        }

        [TestMethod]
        public void TestDimensionInterface()
        {
            var lengthA = new Length<Kilometres, double>(4.4);
            Assert.IsInstanceOfType(lengthA, typeof(ILength));

            var durationA = new Duration<Seconds, double>(4.4);
            Assert.IsInstanceOfType(durationA, typeof(IDuration));

            var areaA = new Area<Kilometres, double>(4.4);
            Assert.IsInstanceOfType(areaA, typeof(IArea));

            var massA = new Mass<Kilograms, double>(4.4);
            Assert.IsInstanceOfType(massA, typeof(IMass));

            var speedA = new Speed<Kilometres, Seconds, double>(4.4);
            Assert.IsInstanceOfType(speedA, typeof(ISpeed));

            var volumeA = new Volume<Litres, double>(4.4);
            Assert.IsInstanceOfType(volumeA, typeof(IVolume));

            var volumeB = new Volume<Litres<Kilo>, double>(4.4);
            Assert.IsInstanceOfType(volumeB, typeof(IVolume));
        }
    }
}
