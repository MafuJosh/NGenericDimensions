using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGenericDimensions.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine();

            engine.ClearOutputFolder();
            engine.GenerateSIPrefixFile();
            engine.GenerateUnitFiles();
            engine.GenerateDimensionFiles();
            engine.GenerateDimensionUnitOfMeasureBaseFiles();

            //if (Debugger.IsAttached) Console.ReadKey();
        }
    }
}
