using System;

namespace NGenericDimensions.MetricPrefix
{
    public abstract class MetricPrefixBase : IFormattable
    {
        protected internal decimal Multiplier { get; set; }
        public abstract string UnitSymbol { get; }

        /// <summary>
        /// Returns the simple name of the derived class.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => GetType().Name;

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format == "NU")
            {
                return "";
            }
            else if (format == "SU")
            {
                return UnitSymbol;
            }
            return ToString();
        }
    }

    public class Deca : MetricPrefixBase
    {
        public Deca() => Multiplier = 10m;
        public override string UnitSymbol => "da";
    }

    public class Hecto : MetricPrefixBase
    {
        public Hecto() => Multiplier = 100m;
        public override string UnitSymbol => "h";
    }

    public class Kilo : MetricPrefixBase
    {
        public Kilo() => Multiplier = 1000m;
        public override string UnitSymbol => "k";
    }

    public class Mega : MetricPrefixBase
    {
        public Mega() => Multiplier = 1000000m;
        public override string UnitSymbol => "M";
    }

    public class Giga : MetricPrefixBase
    {
        public Giga() => Multiplier = 1000000000m;
        public override string UnitSymbol => "G";
    }

    public class Tera : MetricPrefixBase
    {
        public Tera() => Multiplier = 1000000000000m;
        public override string UnitSymbol => "T";
    }

    public class Peta : MetricPrefixBase
    {
        public Peta() => Multiplier = 1000000000000000m;
        public override string UnitSymbol => "P";
    }

    public class Exa : MetricPrefixBase
    {
        public Exa() => Multiplier = 1000000000000000000m;
        public override string UnitSymbol => "E";
    }

    public class Zetta : MetricPrefixBase
    {
        public Zetta() => Multiplier = 1000000000000000000000m;
        public override string UnitSymbol => "Z";
    }

    public class Yotta : MetricPrefixBase
    {
        public Yotta() => Multiplier = 1000000000000000000000000m;
        public override string UnitSymbol => "Y";
    }

    public class Deci : MetricPrefixBase
    {
        public Deci() => Multiplier = 0.1m;
        public override string UnitSymbol => "d";
    }

    public class Centi : MetricPrefixBase
    {
        public Centi() => Multiplier = 0.01m;
        public override string UnitSymbol => "c";
    }

    public class Milli : MetricPrefixBase
    {
        public Milli() => Multiplier = 0.001m;
        public override string UnitSymbol => "m";
    }

    public class Micro : MetricPrefixBase
    {
        public Micro() => Multiplier = 0.000001m;
        public override string UnitSymbol => "µ";
    }

    public class Nano : MetricPrefixBase
    {
        public Nano() => Multiplier = 0.000000001m;
        public override string UnitSymbol => "n";
    }

    public class Pico : MetricPrefixBase
    {
        public Pico() => Multiplier = 0.000000000001m;
        public override string UnitSymbol => "p";
    }

    public class Femto : MetricPrefixBase
    {
        public Femto() => Multiplier = 0.000000000000001m;
        public override string UnitSymbol => "f";
    }

    public class Atto : MetricPrefixBase
    {
        public Atto() => Multiplier = 0.000000000000000001m;
        public override string UnitSymbol => "a";
    }

    public class Zepto : MetricPrefixBase
    {
        public Zepto() => Multiplier = 0.000000000000000000001m;
        public override string UnitSymbol => "z";
    }

    public class Yocto : MetricPrefixBase
    {
        public Yocto() => Multiplier = 0.000000000000000000000001m;
        public override string UnitSymbol => "y";
    }
}