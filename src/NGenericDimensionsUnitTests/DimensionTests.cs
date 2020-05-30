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
    public class DimensionTests : TestsHelperBBase
    {
        [Fact]
        public void TestIDimension()
        {
            // make sure each dimension applies the IDimension interface.

            var lengthA = new Length<Kilometres, double>(4.4);
            Assert.IsAssignableFrom<IDimension>(lengthA);
            Assert.Equal(4.4, (lengthA as IDimension).Value);

            var durationA = new Duration<Seconds, double>(4.4);
            Assert.IsAssignableFrom<IDimension>(durationA);
            Assert.Equal(4.4, (durationA as IDimension).Value);

            var areaA = new Area<Kilometres, double>(4.4);
            Assert.IsAssignableFrom<IDimension>(areaA);
            Assert.Equal(4.4, (areaA as IDimension).Value);

            var massA = new Mass<Kilograms, double>(4.4);
            Assert.IsAssignableFrom<IDimension>(massA);
            Assert.Equal(4.4, (massA as IDimension).Value);

            var speedA = new Speed<Kilometres, Seconds, double>(4.4);
            Assert.IsAssignableFrom<IDimension>(speedA);
            Assert.Equal(4.4, (speedA as IDimension).Value);

            var volumeA = new Volume<Litres, double>(4.4);
            Assert.IsAssignableFrom<IDimension>(volumeA);
            Assert.Equal(4.4, (volumeA as IDimension).Value);

            var volumeB = new Volume<Litres<Kilo>, double>(4.4);
            Assert.IsAssignableFrom<IDimension>(volumeB);
            Assert.Equal(4.4, (volumeB as IDimension).Value);
        }

        [Fact]
        public void TestDimensionInterface()
        {
            var lengthA = new Length<Kilometres, double>(4.4);
            Assert.IsAssignableFrom<ILength>(lengthA);

            var durationA = new Duration<Seconds, double>(4.4);
            Assert.IsAssignableFrom<IDuration>(durationA);

            var areaA = new Area<Kilometres, double>(4.4);
            Assert.IsAssignableFrom<IArea>(areaA);

            var massA = new Mass<Kilograms, double>(4.4);
            Assert.IsAssignableFrom<IMass>(massA);

            var speedA = new Speed<Kilometres, Seconds, double>(4.4);
            Assert.IsAssignableFrom<ISpeed>(speedA);

            var volumeA = new Volume<Litres, double>(4.4);
            Assert.IsAssignableFrom<IVolume>(volumeA);

            var volumeB = new Volume<Litres<Kilo>, double>(4.4);
            Assert.IsAssignableFrom<IVolume>(volumeB);
        }
    }
}
