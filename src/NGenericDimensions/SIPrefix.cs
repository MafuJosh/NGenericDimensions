using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NGenericDimensions.MetricPrefix
{

    public abstract class MetricPrefixBase : IFormattable
    {
        protected internal decimal Multiplier;
        public abstract string UnitSymbol { get; }

        /// <summary>
        /// Returns the simple name of the derived class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().Name;
        }

        public string ToString(string format, IFormatProvider formatProvider)
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

        public Deca()
        {
            Multiplier = 10m;
        }

        public override string UnitSymbol
        {
            get { return "da"; }
        }
    }

    public class Hecto : MetricPrefixBase
    {

        public Hecto()
        {
            Multiplier = 100m;
        }

        public override string UnitSymbol
        {
            get { return "h"; }
        }
    }

    public class Kilo : MetricPrefixBase
    {

        public Kilo()
        {
            Multiplier = 1000m;
        }

        public override string UnitSymbol
        {
            get { return "k"; }
        }
    }

    public class Mega : MetricPrefixBase
    {

        public Mega()
        {
            Multiplier = 1000000m;
        }

        public override string UnitSymbol
        {
            get { return "M"; }
        }
    }

    public class Giga : MetricPrefixBase
    {

        public Giga()
        {
            Multiplier = 1000000000m;
        }

        public override string UnitSymbol
        {
            get { return "G"; }
        }
    }

    public class Tera : MetricPrefixBase
    {

        public Tera()
        {
            Multiplier = 1000000000000m;
        }

        public override string UnitSymbol
        {
            get { return "T"; }
        }
    }

    public class Peta : MetricPrefixBase
    {

        public Peta()
        {
            Multiplier = 1000000000000000m;
        }

        public override string UnitSymbol
        {
            get { return "P"; }
        }
    }

    public class Exa : MetricPrefixBase
    {

        public Exa()
        {
            Multiplier = 1000000000000000000m;
        }

        public override string UnitSymbol
        {
            get { return "E"; }
        }
    }

    public class Zetta : MetricPrefixBase
    {

        public Zetta()
        {
            Multiplier = 1000000000000000000000m;
        }

        public override string UnitSymbol
        {
            get { return "Z"; }
        }
    }

    public class Yotta : MetricPrefixBase
    {

        public Yotta()
        {
            Multiplier = 1000000000000000000000000m;
        }

        public override string UnitSymbol
        {
            get { return "Y"; }
        }
    }

    public class Deci : MetricPrefixBase
    {

        public Deci()
        {
            Multiplier = 0.1m;
        }

        public override string UnitSymbol
        {
            get { return "d"; }
        }
    }

    public class Centi : MetricPrefixBase
    {

        public Centi()
        {
            Multiplier = 0.01m;
        }

        public override string UnitSymbol
        {
            get { return "c"; }
        }
    }

    public class Milli : MetricPrefixBase
    {

        public Milli()
        {
            Multiplier = 0.001m;
        }

        public override string UnitSymbol
        {
            get { return "m"; }
        }
    }

    public class Micro : MetricPrefixBase
    {

        public Micro()
        {
            Multiplier = 0.000001m;
        }

        public override string UnitSymbol
        {
            get { return "µ"; }
        }
    }

    public class Nano : MetricPrefixBase
    {

        public Nano()
        {
            Multiplier = 0.000000001m;
        }

        public override string UnitSymbol
        {
            get { return "n"; }
        }
    }

    public class Pico : MetricPrefixBase
    {

        public Pico()
        {
            Multiplier = 0.000000000001m;
        }

        public override string UnitSymbol
        {
            get { return "p"; }
        }
    }

    public class Femto : MetricPrefixBase
    {

        public Femto()
        {
            Multiplier = 0.000000000000001m;
        }

        public override string UnitSymbol
        {
            get { return "f"; }
        }
    }

    public class Atto : MetricPrefixBase
    {

        public Atto()
        {
            Multiplier = 0.000000000000000001m;
        }

        public override string UnitSymbol
        {
            get { return "a"; }
        }
    }

    public class Zepto : MetricPrefixBase
    {

        public Zepto()
        {
            Multiplier = 0.000000000000000000001m;
        }

        public override string UnitSymbol
        {
            get { return "z"; }
        }
    }

    public class Yocto : MetricPrefixBase
    {

        public Yocto()
        {
            Multiplier = 0.000000000000000000000001m;
        }

        public override string UnitSymbol
        {
            get { return "y"; }
        }
    }

}