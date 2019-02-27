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

    public abstract class MetricPrefixBase
    {
        protected internal decimal Multiplier;
    }

    public class Deca : MetricPrefixBase
    {

        public Deca()
        {
            Multiplier = 10m;
        }
    }

    public class Hecto : MetricPrefixBase
    {

        public Hecto()
        {
            Multiplier = 100m;
        }
    }

    public class Kilo : MetricPrefixBase
    {

        public Kilo()
        {
            Multiplier = 1000m;
        }
    }

    public class Mega : MetricPrefixBase
    {

        public Mega()
        {
            Multiplier = 1000000m;
        }
    }

    public class Giga : MetricPrefixBase
    {

        public Giga()
        {
            Multiplier = 1000000000m;
        }
    }

    public class Tera : MetricPrefixBase
    {

        public Tera()
        {
            Multiplier = 1000000000000m;
        }
    }

    public class Peta : MetricPrefixBase
    {

        public Peta()
        {
            Multiplier = 1000000000000000m;
        }
    }

    public class Exa : MetricPrefixBase
    {

        public Exa()
        {
            Multiplier = 1000000000000000000m;
        }
    }

    public class Zetta : MetricPrefixBase
    {

        public Zetta()
        {
            Multiplier = 1000000000000000000000m;
        }
    }

    public class Yotta : MetricPrefixBase
    {

        public Yotta()
        {
            Multiplier = 1000000000000000000000000m;
        }
    }

    public class Deci : MetricPrefixBase
    {

        public Deci()
        {
            Multiplier = 0.1m;
        }
    }

    public class Centi : MetricPrefixBase
    {

        public Centi()
        {
            Multiplier = 0.01m;
        }
    }

    public class Milli : MetricPrefixBase
    {

        public Milli()
        {
            Multiplier = 0.001m;
        }
    }

    public class Micro : MetricPrefixBase
    {

        public Micro()
        {
            Multiplier = 0.000001m;
        }
    }

    public class Nano : MetricPrefixBase
    {

        public Nano()
        {
            Multiplier = 0.000000001m;
        }
    }

    public class Pico : MetricPrefixBase
    {

        public Pico()
        {
            Multiplier = 0.000000000001m;
        }
    }

    public class Femto : MetricPrefixBase
    {

        public Femto()
        {
            Multiplier = 0.000000000000001m;
        }
    }

    public class Atto : MetricPrefixBase
    {

        public Atto()
        {
            Multiplier = 0.000000000000000001m;
        }
    }

    public class Zepto : MetricPrefixBase
    {

        public Zepto()
        {
            Multiplier = 0.000000000000000000001m;
        }
    }

    public class Yocto : MetricPrefixBase
    {

        public Yocto()
        {
            Multiplier = 0.000000000000000000000001m;
        }
    }

}