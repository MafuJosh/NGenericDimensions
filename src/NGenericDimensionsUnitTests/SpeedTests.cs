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
    public class SpeedTests : TestsHelperBBase
    {

        [Fact]
        public void TestSpeedConstructor()
        {
            // test valid units of measure for speed
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Feet, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Inches, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Miles, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Millimetres, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Kilometres, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Micrometres, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Nanometres, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deca>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Hecto>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Kilo>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Mega>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Giga>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Tera>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Peta>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Exa>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zetta>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yotta>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Deci>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Centi>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Milli>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Micro>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Nano>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Pico>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Femto>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Atto>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Zepto>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Days, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Hours, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Minutes, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Milliseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Microseconds, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Ticks, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Deca>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Hecto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Kilo>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Mega>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Giga>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Tera>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Peta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Exa>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Zetta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Yotta>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Deci>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Centi>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Milli>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Micro>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Nano>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Pico>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Femto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Atto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Zepto>, double>(4.4);
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.MetricSI.Metres<Yocto>, NGenericDimensions.Durations.Seconds<Yocto>, double>(4.4);


            // test invalid units of measure of speed
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Areas.MetricNonSI.Hectares, NGenericDimensions.Durations.Minutes, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Masses.MetricSI.Grams, NGenericDimensions.Durations.Minutes, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Masses.MetricSI.Kilograms, NGenericDimensions.Durations.Minutes, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Volumes.MetricNonSI.Litres, NGenericDimensions.Durations.Minutes, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Durations.Milliseconds, NGenericDimensions.Durations.Minutes, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Durations.Minutes, NGenericDimensions.Areas.MetricNonSI.Hectares, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Durations.Minutes, NGenericDimensions.Masses.MetricSI.Grams, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Durations.Minutes, NGenericDimensions.Masses.MetricSI.Kilograms, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Durations.Minutes, NGenericDimensions.Volumes.MetricNonSI.Litres, double>(4.4);");
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Durations.Minutes, NGenericDimensions.Durations.Milliseconds, double>(4.4);");

            // test number data types
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Double>(System.Convert.ToDouble(4.44444));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Double>(System.Convert.ToSingle(4.44444));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Single>(System.Convert.ToSingle(4.44444));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Decimal>(System.Convert.ToDecimal(4.44444));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Int64>(System.Convert.ToInt64(4));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Int32>(System.Convert.ToInt32(4));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Int16>(System.Convert.ToInt16(4));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Byte>(System.Convert.ToByte(4));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.SByte>(System.Convert.ToSByte(4));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.UInt16>(System.Convert.ToUInt16(4));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.UInt32>(System.Convert.ToUInt32(4));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.UInt64>(System.Convert.ToUInt64(4));
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Char>(System.Convert.ToChar(4));");
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.DateTime>(new System.DateTime(1000)); // can't stop this from being allowed
            AssertCompilationFails("cannot be used as type parameter", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Boolean>(System.Convert.ToBoolean(4));");
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Numerics.BigInteger>(new System.Numerics.BigInteger(4.4));
            // and prove it only allows compatible data types
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Int32>(System.Convert.ToInt32(4));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Int32>(System.Convert.ToInt16(4));
            _ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Int32>(System.Convert.ToByte(4));
            AssertCompilationFails("cannot convert from", @"_ = new NGenericDimensions.Speed<NGenericDimensions.Lengths.Uscs.Yards, NGenericDimensions.Durations.Hours, System.Int32>(System.Convert.ToInt64(4));");

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
                Assert.Same(speedA.LengthUnitOfMeasure.GetType(), lengthC.UnitOfMeasure.GetType());
                Assert.Same(speedA.SpeedValue.GetType(), lengthC.LengthValue.GetType());
                Assert.Equal(14, lengthC.LengthValue);
            }
            {
                var speedA = new Speed<Inches, Days, Int32>(7);
                var durationB = new Duration<Days, Int32>(2);
                var lengthC = durationB * speedA;
                Assert.Same(speedA.LengthUnitOfMeasure.GetType(), lengthC.UnitOfMeasure.GetType());
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
