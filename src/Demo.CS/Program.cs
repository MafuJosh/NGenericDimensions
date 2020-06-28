using NGenericDimensions.Extensions;
using NGenericDimensions.Extensions.Numbers;
using NGenericDimensions.Lengths.MetricSI;
using NGenericDimensions.Durations;

namespace NGenericDimensions.Demo.CS
{
    class Program
    {
        static void Main()
        {
            var myspeed = (10).miles().per().hour();
            var yourspeed = 20.kilometres() / 2.minutes();
            Length<Metres, double> mylength1 = new Length<Metres, double>(100.0);
            Length<Metres, double> mylength2 = new Length<Metres, double>(200.0);
            Length<Metres, double> mylength3 = 300.0;
            var mylenght4 = mylength1 + mylength2;
            var myarea = mylength1 * mylength2;
            Area<Metres, double> myarea2 = myarea;
            var myduration = new Duration<Minutes, int>(100);
        }
    }
}
